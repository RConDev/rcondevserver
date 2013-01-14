namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Player
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Data;
    using Util;

    public class PlayerOnLeaveEventSender : EventSenderBase
    {
        public string SoldierName { get; set; }

        public PlayerInfo PlayerInfo { get; set; }

        public override string EventCommand
        {
            get { return Constants.EVENT_PLAYER_ON_LEAVE; }
        }

        public override Packet EventPacket
        {
            get
            {
                var packet = new Packet(PacketOrigin.Server, false, 0,
                                        new List<string> {this.EventCommand, this.SoldierName});
                if (this.PlayerInfo != null)
                {
                    StringListExtensions.AddRange(packet.Words, this.PlayerInfo.ToWords());
                }
                return packet;
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            List<string> parameters = commandParameterList.ToList();
            if (parameters.Count == 7)
            {
                this.SoldierName = parameters[0];
                this.PlayerInfo = new PlayerInfo
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