using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RConDevServer.Protocol.Dice.Battlefield3.Ui;

namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    public partial class BanListControl : UserControl
    {
        private BanListViewModel dataContext;

        public BanListControl()
        {
            InitializeComponent();

            this.dbsNewItem.DataSource = this.CreateNewBanListItem();
        }

        private BanListItemViewModel CreateNewBanListItem()
        {
            return new BanListItemViewModel(x => this.Invoke(x));
        }

        public BanListViewModel DataContext
        {
            get { return this.dataContext; }
            set
            {
                this.dataContext = value;
                if (this.DataContext != null)
                {
                    this.dbsBanList.DataSource = this.dataContext;
                    this.dbsBanList.ResetBindings(false);

                    this.dbsIdTypes.DataSource = this.dataContext.IdTypes;
                    this.dbsIdTypes.ResetBindings(false);

                    this.dbsBanTypes.DataSource = this.dataContext.BanTypes;
                    this.dbsBanTypes.ResetBindings(false);
                }
            }
        }

        #region Event Handler

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var newItem = this.dbsNewItem.Current as BanListItemViewModel;
            if (newItem != null)
            {
                this.dataContext.BanListItems.Add(newItem);
                this.dbsBanListItems.ResetBindings(false);
                
                this.dbsNewItem.DataSource = this.CreateNewBanListItem();
                this.dbsNewItem.ResetBindings(false);
            }
        }

        private void mitRemoveItem_Click(object sender, EventArgs e)
        {
            var currentItem = this.dbsBanListItems.Current as BanListItemViewModel;
            if (currentItem != null)
            {
                this.dataContext.BanListItems.Remove(currentItem);
            }
        }

        #endregion

        
    }
}
