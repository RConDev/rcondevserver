namespace RConDevServer.Protocol.Dice.Battlefield3
{
    using System.Collections.Generic;

    public interface IPacketSerializer<T> where T : IPacket
    {
        byte[] Serialize(Packet packet);

        IEnumerable<Packet> Deserialize(byte[] packetData);
    }
}