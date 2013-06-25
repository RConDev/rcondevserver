namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    using System;
    using System.Windows.Forms;
    using Data;
    using Ui;
    using Util;

    public partial class BanListControl : UserControl
    {
        private BanListViewModel dataContext;

        public BanListControl()
        {
            this.InitializeComponent();

            this.dbsNewItem.DataSource = this.CreateNewBanListItem();
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

                    // ComboBox
                    this.idTypeComboBox.DataSource = dataContext.IdTypesDataSource;
                    this.idTypeComboBox.ValueMember = "Key";
                    this.idTypeComboBox.DisplayMember = "Value";

                    // Grid
                    this.IdType.ValueType = typeof (IdType);
                    this.IdType.DataSource = dataContext.IdTypesDataSource; 
                    this.IdType.ValueMember = "Key";
                    this.IdType.DisplayMember = "Value";

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

        private BanListItemViewModel CreateNewBanListItem()
        {
            return new BanListItemViewModel(x => this.Invoke(x));
        }
    }
}