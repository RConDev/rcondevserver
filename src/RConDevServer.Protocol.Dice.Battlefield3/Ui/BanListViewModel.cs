namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using Data;
    using Util;

    public class BanListViewModel : ViewModelBase
    {
        public BanListViewModel(IBanList banList, BanTypes banTypes, Action<Action> synchronousInvoker)
            : base(synchronousInvoker)
        {
            this.BanList = banList;
            this.BanTypes = banTypes;
            this.BanListItems =
                new ObservableCollection<BanListItemViewModel>(
                    this.BanList.Select(x => new BanListItemViewModel(x, synchronousInvoker)));
            this.BanListItems.CollectionChanged += this.BanListItemsOnCollectionChanged;
        }

        #region Event Handler

        private void BanListItemsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            switch (eventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    this.BaseAddItems(eventArgs);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    this.BaseRemoveItems(eventArgs);
                    break;
            }
            this.InvokePropertyChanged(null);
        }

        #endregion

        #region Private Methods

        private void BaseRemoveItems(NotifyCollectionChangedEventArgs eventArgs)
        {
            foreach (BanListItemViewModel item in eventArgs.OldItems)
            {
                this.BanList.Remove(item.Item);
            }
        }

        private void BaseAddItems(NotifyCollectionChangedEventArgs eventArgs)
        {
            foreach (BanListItemViewModel item in eventArgs.NewItems)
            {
                this.BanList.Add(item.Item);
            }
        }

        #endregion

        public IBanList BanList { get; private set; }

        public IEnumerable<KeyValuePair<IdType, string>> IdTypesDataSource
        {
            get { return EnumExtensions.ToDataSource<IdType>(); }
        }

        public BanTypes BanTypes { get; private set; }

        public ObservableCollection<BanListItemViewModel> BanListItems { get; private set; }
    }
}