using System;
using System.Collections.Generic;
using System.Linq;
 

namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Server
{
    public class ServerOnRoundOverEventSender : EventSenderBase
    {
        public int WinningTeam { get; set; }

        public override string EventCommand
        {
            get { return RConDevServer.Protocol.Dice.Battlefield3.Constants.EVENT_SERVER_ON_ROUND_OVER; }
        }

        public override Packet EventPacket
        {
            get
            {
                return new Packet(PacketOrigin.Server, false, 0, new List<string>
                                                                       {
                                                                           EventCommand, 
                                                                           Convert.ToString(WinningTeam)
                                                                       });
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            var parameters = commandParameterList.ToList();
            if (parameters.Count == 1)
            {
                WinningTeam = Convert.ToInt32(parameters[0]);
                return true;
            }
            return false;
        }
    }
}
