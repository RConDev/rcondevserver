namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System;
    using Data;

    public class MapListItemViewModel : ViewModelBase
    {
        public MapListItemViewModel(Action<Action> synchronousInvoker) : base(synchronousInvoker)
        {
            this.Item = new MapListItem();
        }

        public MapListItemViewModel(MapListItem item, Action<Action> synchronousInvoker)
            : base(synchronousInvoker)
        {
            this.Item = item;
        }

        public MapListItem Item { get; set; }

        public Map Map
        {
            get { return this.Item.Map; }
            set
            {
                this.Item.Map = value;
                this.InvokePropertyChanged("Map");
            }
        }

        public GameMode GameMode
        {
            get { return this.Item.Mode; }
            set
            {
                this.Item.Mode = value;
                this.InvokePropertyChanged("GameMode");
            }
        }

        public int Rounds
        {
            get { return this.Item.Rounds; }
            set
            {
                this.Item.Rounds = value;
                this.InvokePropertyChanged("Rounds");
            }
        }
    }
}