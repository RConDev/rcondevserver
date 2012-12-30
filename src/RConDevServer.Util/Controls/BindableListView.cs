using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RConDevServer.Util.Controls
{
    public class BindableListView : ListView
    {
        private CurrencyManager currencyManager;
        private DataView dataView;

        #region Constructor

        public BindableListView() : base()
        {
            dataView = new DataView();
        }

        #endregion

        private object dataSource;

        [Bindable(true)]
        [Category("Data")]
        [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")]
        public object DataSource
        {
            get { return dataSource; }
            set
            {
                if (dataSource == value) return;

                dataSource = value;
                Bind();
            }
        }

        private void Bind()
        {
            // clear all existing items in the listview
            Items.Clear();

            // 
            if (this.DataSource is BindingSource)
            {
                var dbs = dataSource as BindingSource;
                
                if (dbs != null)
                {
                    // add an event-handler which handles changing the datasource
                    dbs.DataSourceChanged += BindingSoureOnDataSourceChanged;

                    currencyManager = dbs.CurrencyManager;

                    
                    foreach(object item in currencyManager.List)
                    {
                        Items.Add(new ListViewItem(new[] {"1"}));
                    }
                }
            }
        }

        #region EventHandler

        private void BindingSoureOnDataSourceChanged(object sender, EventArgs eventArgs)
        {
            Bind();
        }

        #endregion
    }
}
