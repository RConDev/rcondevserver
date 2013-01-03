using System.Collections.Generic;
using System.Linq;
using RConDevServer.Protocol.Dice.Battlefield3.Event;
using RConDevServer.Protocol.Dice.Battlefield3.Event.Player;

namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Player
{
    public class PlayerOnAuthenticatedEventSender : EventSenderBase
    {
        private IEvent _event;

        public override string EventCommand
        {
            get { return Constants.EVENT_PLAYER_ON_AUTHENTICATED; }
        }

        public override Packet EventPacket
        {
            get
            {
                if (_event == null)
                {
                    return null;
                }

                return new Packet(PacketOrigin.Server, false, 0, _event.ToWords());
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            var parameters = commandParameterList.ToArray();
            if (parameters.Length == 1)
            {
                _event = new PlayerOnAuthenticatedEvent(parameters[0]);
                return true;
            }
            return false;
        }
    }
}