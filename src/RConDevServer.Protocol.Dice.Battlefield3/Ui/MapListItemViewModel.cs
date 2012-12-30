using System;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    public class MapListItemViewModel : ViewModelBase
    {
        public MapListItem Item { get; set; }

        public Map Map
        {
            get
            {
                return this.Item.Map;
            }
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
                Item.Mode = value;
                InvokePropertyChanged("GameMode");
            }
        }

        public int Rounds
        {
            get { return this.Item.Rounds; }
            set
            {
                this.Item.Rounds = value;
                InvokePropertyChanged("Rounds");
            }
        }

        public MapListItemViewModel(Action<Action> synchronousInvoker) : base(synchronousInvoker)
        {
            this.Item = new MapListItem();
        }

        public MapListItemViewModel(MapListItem item, Action<Action> synchronousInvoker)
            : base(synchronousInvoker)
        {
            Item = item;
        }
    }
}