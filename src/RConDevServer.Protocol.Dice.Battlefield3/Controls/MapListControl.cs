namespace RConDevServer.Protocol.Dice.Battlefield3.Controls
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Resource.Properties;
    using Ui;

    /// <summary>
    ///     This control enables the features of editing the map list of the server instance
    /// </summary>
    public partial class MapListControl : UserControl
    {
        private MapListViewModel dataContext;

        #region Public Properties

        /// <summary>
        ///     Gets or sets the data context for this control
        /// </summary>
        public MapListViewModel DataContext
        {
            get { return this.dataContext; }
            set
            {
                if (this.dataContext != null)
                {
                    this.dataContext.PropertyChanged -= this.DataContextOnPropertyChanged;
                }

                this.dataContext = value;
                if (this.dataContext != null)
                {
                    this.dbsMapList.DataSource = this.dataContext;
                    this.dataContext.PropertyChanged += this.DataContextOnPropertyChanged;
                    this.dbsMapList.ResetBindings(false);

                    this.dbsAvailableMaps.DataSource = this.dataContext.AvailableMaps;
                    this.dbsAvailableMaps.ResetBindings(false);

                    this.dbsAvailableModes.DataSource = this.dataContext.AvailableModes;
                    this.dbsAvailableModes.ResetBindings(false);
                }
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Creates a new instance from <see cref="MapListControl" />
        /// </summary>
        public MapListControl()
        {
            this.InitializeComponent();
            this.dbsNewItem.DataSource = this.CreateNewItem();

            this.btnUp.Image = Resources.gnome_web_up16;
            this.btnDown.Image = Resources.gnome_web_down16;
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Creates an empty item for creating new list items
        /// </summary>
        /// <returns></returns>
        private MapListItemViewModel CreateNewItem()
        {
            return new MapListItemViewModel(x => this.Invoke(x));
        }

        #endregion

        #region Event Handler

        private void BtnAddClick(object sender, EventArgs e)
        {
            var item = this.dbsNewItem.Current as MapListItemViewModel;
            this.dataContext.MapListItems.Add(item);
            this.dbsMapList.ResetBindings(false);
            this.dbsNewItem.DataSource = this.CreateNewItem();
        }

        private void MitRemoveItemClick(object sender, EventArgs e)
        {
            var item = this.dbsMapListItems.Current as MapListItemViewModel;
            if (item != null)
            {
                this.dataContext.MapListItems.Remove(item);
                this.dbsMapListItems.ResetBindings(false);
            }
        }

        private void MitSetAsCurrentClick(object sender, EventArgs e)
        {
            var currentMapListItem = this.dbsMapListItems.Current as MapListItemViewModel;
            if (currentMapListItem != null && this.dataContext != null)
            {
                this.dataContext.Server.MapList.CurrentItem = currentMapListItem.Item;
            }
        }

        private void DataContextOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == null)
            {
                this.dbsMapList.DataSource = this.dataContext;
                this.dbsMapList.ResetBindings(false);

                this.dbsMapListItems.DataSource = this.dataContext.MapListItems;
                this.dbsMapListItems.ResetBindings(false);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            var currentItem = this.dbsMapListItems.Current as MapListItemViewModel;
            if (currentItem != null)
            {
                this.dbsMapListItems.CurrencyManager.Position = this.dataContext.MoveMapListItemUp(currentItem);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            var currentItem = this.dbsMapListItems.Current as MapListItemViewModel;
            if (currentItem != null)
            {
                this.dbsMapListItems.CurrencyManager.Position = this.dataContext.MoveMapListItemDown(currentItem);
            }
        }

        #endregion
    }
}