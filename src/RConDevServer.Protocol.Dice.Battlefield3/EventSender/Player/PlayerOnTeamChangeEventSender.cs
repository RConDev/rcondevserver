using System;
using System.Collections.Generic;
using System.Linq;
 

namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Player
{
    public class PlayerOnTeamChangeEventSender : EventSenderBase
    {
        public string SoldierName { get; set; }

        public int TeamId { get; set; }

        public int SquadId { get; set; }

        public override string EventCommand
        {
            get { return RConDevServer.Protocol.Dice.Battlefield3.Constants.EVENT_PLAYER_ON_TEAM_CHANGE; }
        }

        public override Packet EventPacket
        {
            get
            {
                return new Packet(PacketOrigin.Server, false, 0, new List<string>
                                                                     {
                                                                         EventCommand,
                                                                         SoldierName,
                                                                         Convert.ToString(TeamId),
                                                                         Convert.ToString(SquadId)
                                                                     });
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            var parameters = commandParameterList.ToList();
            if (parameters.Count == 3)
            {
                SoldierName = parameters[0];
                TeamId = Convert.ToInt32(parameters[1]);
                SquadId = Convert.ToInt32(parameters[2]);

                return true;
            }
            return false;
        }
    }
}
