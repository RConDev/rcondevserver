using System;
using System.Collections.Generic;
using System.Linq;
 
using RConDevServer.Protocol.Dice.Battlefield3.Data;
using RConDevServer.Protocol.Dice.Battlefield3.Util;

namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Player
{
    public class PlayerOnChatEventSender : EventSenderBase
    {
        public string SoldierName { get; set; }

        public string Text { get; set; }

        public PlayerSubset PlayerSubset { get; set; }

        public override string EventCommand
        {
            get { return RConDevServer.Protocol.Dice.Battlefield3.Constants.EVENT_PLAYER_ON_CHAT; }
        }

        public override Packet EventPacket
        {
            get
            {
                var packet = new Packet(PacketOrigin.Server, false, 0, new List<string>
                                                                           {
                                                                               EventCommand,
                                                                               SoldierName,
                                                                               Text,
                                                                           });
                StringListExtensions.AddRange(packet.Words, PlayerSubset.ToWords());
                return packet;
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            var parameters = commandParameterList.ToList();

            if(parameters.Count == 0)
                return false;

            SoldierName = parameters[0];
            Text = parameters[1];
            if (parameters.Count == 3 && parameters[2].ToLower() == "all")
            {
                PlayerSubset = new PlayerSubset()
                                   {
                                       Type = PlayerSubsetType.All
                                   };
                return true;
            }
            
            if (parameters.Count == 4)
            {
                if (parameters[2].ToLower() == "player")
                {
                    PlayerSubset = new PlayerSubset
                                       {
                                           Type = PlayerSubsetType.Player, 
                                           PlayerName = parameters[3]
                                       };
                }
                if (parameters[2].ToLower() == "team")
                {
                    PlayerSubset = new PlayerSubset
                                       {
                                           Type = PlayerSubsetType.Team, 
                                           TeamId = Convert.ToInt32(parameters[3])
                                       };
                }
                return true;
            }

            if (parameters.Count == 5 && parameters[2].ToLower() == "squad")
            {
                PlayerSubset = new PlayerSubset
                                   {
                                       Type = PlayerSubsetType.Squad, 
                                       TeamId = Convert.ToInt32(parameters[3]), 
                                       SquadId = Convert.ToInt32(parameters[4])
                                   };
                return true;
            }
            return false;
        }
    }
}
