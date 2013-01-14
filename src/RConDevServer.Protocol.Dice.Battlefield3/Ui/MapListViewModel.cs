namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Remotion.Linq.Collections;

    public class MapListViewModel : ViewModelBase
    {
        public Battlefield3Server Server { get; set; }

        #region Public Properties

        public MapList MapList { get; private set; }

        public Maps AvailableMaps { get; set; }

        public GameModes AvailableModes { get; set; }

        public ObservableCollection<MapListItemViewModel> MapListItems { get; private set; }

        #endregion

        #region Constructors

        public MapListViewModel(Battlefield3Server server, Action<Action> synchronousInvoker) : base(synchronousInvoker)
        {
            this.Server = server;
            this.MapList = server.MapList;
            this.MapList.Updated += this.MapListOnUpdated;
            this.AvailableMaps = server.AvailableMaps;
            this.AvailableModes = server.AvailableModes;

            this.InitializeMapListItems();
        }

        private void InitializeMapListItems()
        {
            if (this.MapListItems != null)
            {
                this.MapListItems.ItemInserted -= this.ItemsOnItemInserted;
                this.MapListItems.ItemRemoved -= this.ItemsOnItemRemoved;
            }

            var items = new ObservableCollection<MapListItemViewModel>();
            foreach (
                MapListItemViewModel item in
                    this.MapList.Items.Select(x => new MapListItemViewModel(x, this.SynchronousInvoker)))
            {
                items.Add(item);
            }
            items.ItemInserted += this.ItemsOnItemInserted;
            items.ItemRemoved += this.ItemsOnItemRemoved;
            this.MapListItems = items;
        }

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public int MoveMapListItemUp(MapListItemViewModel currentItem)
        {
            IList<MapListItem> items = this.MapList.Items;
            int currentIndex = items.IndexOf(currentItem.Item);
            if (currentIndex == 0)
            {
                // it's the first item, no chance to move it up
                return 0;
            }

            int nextIndex = currentIndex - 1;
            items.Insert(nextIndex, currentItem.Item);
            items.RemoveAt(currentIndex + 1);
            this.InitializeMapListItems();
            this.InvokePropertyChanged(null);
            return nextIndex;
        }

        public int MoveMapListItemDown(MapListItemViewModel currentItem)
        {
            IList<MapListItem> items = this.MapList.Items;
            int currentIndex = items.IndexOf(currentItem.Item);
            if (currentIndex == items.Count - 1)
            {
                return currentIndex;
            }

            int nextIndex = currentIndex + 1;
            items.RemoveAt(currentIndex);
            items.Insert(nextIndex, currentItem.Item);
            this.InitializeMapListItems();
            this.InvokePropertyChanged(null);
            return nextIndex;
        }

        #endregion

        #region Event Handler

        private void MapListOnUpdated(object sender, EventArgs eventArgs)
        {
            this.InitializeMapListItems();
            this.InvokePropertyChanged(null);
        }

        private void ItemsOnItemInserted(object sender,
                                         ObservableCollectionChangedEventArgs<MapListItemViewModel>
                                             observableCollectionChangedEventArgs)
        {
            this.Server.MapList.Add(observableCollectionChangedEventArgs.Item.Item);
        }

        private void ItemsOnItemRemoved(object sender,
                                        ObservableCollectionChangedEventArgs<MapListItemViewModel>
                                            observableCollectionChangedEventArgs)
        {
            this.Server.MapList.Remove(observableCollectionChangedEventArgs.Item.Item);
        }

        #endregion
    }
}