using System.Collections.Generic;

namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender
{
    public abstract class EventSenderBase : ICanSendEvents
    {
        public abstract string EventCommand { get; }

        public abstract Packet EventPacket { get; }

        public void Send(Battlefield3Server server)
        {
            foreach (var session in server.PacketSessions)
            {
                session.RaiseServerEvent(EventPacket);
            }
        }

        public abstract bool SetParameters(IEnumerable<string> commandParameterList);
    }
}
