namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender
{
    using System.Collections.Generic;
    using Common;

    public abstract class EventSenderBase : ICanSendEvents
    {
        public abstract string EventCommand { get; }

        public abstract Packet EventPacket { get; }

        public void Send(Battlefield3Server server)
        {
            foreach (PacketSession session in server.PacketSessions)
            {
                session.RaiseServerEvent(this.EventPacket);
            }
        }

        public abstract bool SetParameters(IEnumerable<string> commandParameterList);
    }
}