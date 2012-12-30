using System.Collections.ObjectModel;

namespace RConDevServer.Protocol.Dice.Battlefield3.Ui
{
    public class PacketList : ObservableCollection<Packet>
    {
        public PacketList(int maxElements = 100)
        {
            MaxElements = maxElements;
        }

        public int MaxElements { get; private set; }
    }
}