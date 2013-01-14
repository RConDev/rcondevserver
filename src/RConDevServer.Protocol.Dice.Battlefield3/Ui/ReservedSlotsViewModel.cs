namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using Data;

    public class ReservedSlotsViewModel : ViewModelBase
    {
        private readonly ReservedSlots slots;

        public ReservedSlotsViewModel(ReservedSlots slots, Action<Action> invoker) : base(invoker)
        {
            this.slots = slots;
            this.slots.Updated += this.SlotsOnUpdated;
            this.ReservedSlots = new ObservableCollection<ReservedSlot>(slots);
            this.ReservedSlots.CollectionChanged += this.PlayersOnCollectionChanged;
        }

        #region Public Properties

        /// <summary>
        ///     Gets / Sets the Option for aggressive Join of VIP-Players
        /// </summary>
        public bool IsAggressiveJoin
        {
            get { return this.slots.IsAggressiveJoin; }
            set
            {
                this.slots.IsAggressiveJoin = value;
                this.InvokePropertyChanged("IsAggressiveJoin");
            }
        }

        public ObservableCollection<ReservedSlot> ReservedSlots { get; private set; }

        #endregion

        #region Event Handler

        private void PlayersOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    this.AddItemToSourceCollection(e);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    this.RemoveItemFromSourceCollection(e);
                    break;
            }
        }

        private void SlotsOnUpdated(object sender, EventArgs eventArgs)
        {
            this.ReservedSlots.CollectionChanged -= this.PlayersOnCollectionChanged;
            this.ReservedSlots = new ObservableCollection<ReservedSlot>(this.slots);
            this.ReservedSlots.CollectionChanged += this.PlayersOnCollectionChanged;
            this.InvokePropertyChanged(null);
        }

        #endregion

        #region Private Methods

        private void RemoveItemFromSourceCollection(NotifyCollectionChangedEventArgs eventArgs)
        {
            foreach (object oldItem in eventArgs.OldItems)
            {
                var playerName = oldItem as ReservedSlot;
                if (playerName != null)
                {
                    this.slots.Remove(playerName.PlayerName);
                }
            }
        }

        private void AddItemToSourceCollection(NotifyCollectionChangedEventArgs eventArgs)
        {
            foreach (object item in eventArgs.NewItems)
            {
                var playerName = item as ReservedSlot;
                if (playerName != null)
                {
                    this.slots.Add(playerName.PlayerName);
                }
            }
        }

        #endregion
    }
}