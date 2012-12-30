using System;
using System.Collections.Generic;
using System.Linq;
 
using RConDevServer.Protocol.Dice.Battlefield3.Util;

namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Player
{
    public class PlayerOnLeaveEventSender : EventSenderBase
    {
        public string SoldierName { get; set; }

        public Data.Player PlayerInfo { get; set; }

        public override string EventCommand
        {
            get { return RConDevServer.Protocol.Dice.Battlefield3.Constants.EVENT_PLAYER_ON_LEAVE; }
        }

        public override Packet EventPacket
        {
            get
            {
                var packet = new Packet(PacketOrigin.Server, false, 0, new List<string> {EventCommand, SoldierName});
                if (PlayerInfo != null)
                    StringListExtensions.AddRange(packet.Words, PlayerInfo.ToWords());
                return packet;
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            var parameters = commandParameterList.ToList();
            if (parameters.Count == 7)
            {
                this.SoldierName = parameters[0];
                this.PlayerInfo = new Data.Player()
                                      {
                                          Name = parameters[0],
                                          EaGuid = parameters[1],
                                          TeamId = Convert.ToInt32(parameters[2]),
                                          SquadId = Convert.ToInt32(parameters[3]),
                                          Kills = Convert.ToInt32(parameters[4]),
                                          Deaths = Convert.ToInt32(parameters[5]),
                                          Score = Convert.ToInt32(parameters[6])
                                      };
                return true;
            }
            return false;
        }
    }
}
