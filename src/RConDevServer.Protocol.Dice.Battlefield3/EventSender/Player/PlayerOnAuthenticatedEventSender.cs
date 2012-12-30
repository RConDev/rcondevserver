using System.Collections.Generic;
using System.Linq;

namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Player
{
    public class PlayerOnAuthenticatedEventSender : EventSenderBase
    {
        public string SoldierName { get; set; }

        public override string EventCommand
        {
            get { return Constants.EVENT_PLAYER_ON_AUTHENTICATED; }
        }

        public override Packet EventPacket
        {
            get
            {
                if (string.IsNullOrEmpty(SoldierName)) 
                    return null;

                return new Packet(PacketOrigin.Server, false, 0, new List<string> {EventCommand, SoldierName});
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            var parameters = commandParameterList.ToArray();
            if (parameters.Length == 1)
            {
                SoldierName = parameters[0];
                return true;
            }
            return false;
        }
    }
}