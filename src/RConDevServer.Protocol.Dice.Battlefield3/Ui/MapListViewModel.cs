using System;
using System.Collections.Generic;

using System.Linq;
using RConDevServer.Protocol.Dice.Battlefield3.Data;
using Remotion.Linq.Collections;

namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
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
            Server = server;
            MapList = server.MapList;
            MapList.Updated += MapListOnUpdated;
            AvailableMaps = server.AvailableMaps;
            AvailableModes = server.AvailableModes;

            InitializeMapListItems();
        }

        private void InitializeMapListItems()
        {
            if (this.MapListItems != null)
            {
                this.MapListItems.ItemInserted -= ItemsOnItemInserted;
                this.MapListItems.ItemRemoved -= ItemsOnItemRemoved;
            }

            var items = new ObservableCollection<MapListItemViewModel>();
            foreach (var item in MapList.Items.Select(x => new MapListItemViewModel(x, this.SynchronousInvoker)))
            {
                items.Add(item);
            }
            items.ItemInserted += ItemsOnItemInserted;
            items.ItemRemoved += ItemsOnItemRemoved;
            this.MapListItems = items;

        }

        #endregion

        #region Private Methods
        #endregion

        #region Public Methods

        public int MoveMapListItemUp(MapListItemViewModel currentItem)
        {
            var items = this.MapList.Items;
            var currentIndex = items.IndexOf(currentItem.Item);
            if (currentIndex == 0)
            {
                // it's the first item, no chance to move it up
                return 0;
            }

            var nextIndex = currentIndex - 1;
            items.Insert(nextIndex, currentItem.Item);
            items.RemoveAt(currentIndex + 1);
            this.InitializeMapListItems();
            InvokePropertyChanged(null);
            return nextIndex;
        }

        public int MoveMapListItemDown(MapListItemViewModel currentItem)
        {
            var items = this.MapList.Items;
            var currentIndex = items.IndexOf(currentItem.Item);
            if (currentIndex == items.Count - 1 )
            {
                return currentIndex;
            }

            var nextIndex = currentIndex + 1;
            items.RemoveAt(currentIndex);
            items.Insert(nextIndex, currentItem.Item);
            this.InitializeMapListItems();
            InvokePropertyChanged(null);
            return nextIndex;
        }

        #endregion

        #region Event Handler

        private void MapListOnUpdated(object sender, EventArgs eventArgs)
        {
            InitializeMapListItems();
            InvokePropertyChanged(null);
        }

        private void ItemsOnItemInserted(object sender, ObservableCollectionChangedEventArgs<MapListItemViewModel> observableCollectionChangedEventArgs)
        {
            Server.MapList.Add(observableCollectionChangedEventArgs.Item.Item);
        }

        private void ItemsOnItemRemoved(object sender, ObservableCollectionChangedEventArgs<MapListItemViewModel> observableCollectionChangedEventArgs)
        {
            Server.MapList.Remove(observableCollectionChangedEventArgs.Item.Item);
        }

        #endregion
    }
}
