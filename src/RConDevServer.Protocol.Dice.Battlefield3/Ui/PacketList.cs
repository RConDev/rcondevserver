namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    using System.Collections.ObjectModel;
    using Common;

    public class PacketList : ObservableCollection<Packet>
    {
        public PacketList(int maxElements = 100)
        {
            this.MaxElements = maxElements;
        }

        public int MaxElements { get; private set; }
    }
}