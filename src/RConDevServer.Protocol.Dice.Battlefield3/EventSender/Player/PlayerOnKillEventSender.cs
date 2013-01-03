using System;
using System.Collections.Generic;
using System.Linq;
 

namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Player
{
    public class PlayerOnKillEventSender : EventSenderBase
    {
        public string KillingSoldierName { get; set; }

        public string KilledSoldierName { get; set; }

        public string Weapon { get; set; }

        public bool IsHeadShot { get; set; }

        public override string EventCommand
        {
            get { return Constants.EVENT_PLAYER_ON_KILL; }
        }

        public override Packet EventPacket
        {
            get
            {
                return new Packet(PacketOrigin.Server, false, 0, new List<string>
                                                                     {
                                                                         EventCommand,
                                                                         KillingSoldierName,
                                                                         KilledSoldierName,
                                                                         Weapon,
                                                                         Convert.ToString(IsHeadShot)
                                                                     });
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            var parameters = commandParameterList.ToList();
            if (parameters.Count == 4)
            {
                KillingSoldierName = parameters[0];
                KilledSoldierName = parameters[1];
                Weapon = parameters[2];
                IsHeadShot = Convert.ToBoolean(parameters[3]);
                return true;
            }

            return false;
        }
    }
}
