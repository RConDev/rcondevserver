using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    public class ReservedSlotsViewModel : ViewModelBase
    {
        private readonly ReservedSlots slots;

        public ReservedSlotsViewModel(ReservedSlots slots, Action<Action> invoker) : base(invoker)
        {
            this.slots = slots;
            this.slots.Updated += SlotsOnUpdated;
            ReservedSlots = new ObservableCollection<ReservedSlot>(slots);
            ReservedSlots.CollectionChanged += PlayersOnCollectionChanged;
        }

        
        #region Public Properties

        /// <summary>
        /// Gets / Sets the Option for aggressive Join of VIP-Players
        /// </summary>
        public bool IsAggressiveJoin    
        {
            get { return slots.IsAggressiveJoin; }
            set
            {
                slots.IsAggressiveJoin = value;
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
                    AddItemToSourceCollection(e);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    RemoveItemFromSourceCollection(e);
                    break;
            }
        }

        private void SlotsOnUpdated(object sender, EventArgs eventArgs)
        {
            this.ReservedSlots.CollectionChanged -= PlayersOnCollectionChanged;
            this.ReservedSlots = new ObservableCollection<ReservedSlot>(this.slots);
            this.ReservedSlots.CollectionChanged += PlayersOnCollectionChanged;
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
                    slots.Remove(playerName.PlayerName);
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
                    slots.Add(playerName.PlayerName);
                }
            }
        }

        #endregion
    }
}