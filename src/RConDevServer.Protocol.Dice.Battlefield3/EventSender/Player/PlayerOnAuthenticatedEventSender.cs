namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Player
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Event;
    using Event.Player;

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
                if (this._event == null)
                {
                    return null;
                }

                return new Packet(PacketOrigin.Server, false, 0, this._event.ToWords());
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            string[] parameters = commandParameterList.ToArray();
            if (parameters.Length == 1)
            {
                this._event = new PlayerOnAuthenticatedEvent(parameters[0]);
                return true;
            }
            return false;
        }
    }
}