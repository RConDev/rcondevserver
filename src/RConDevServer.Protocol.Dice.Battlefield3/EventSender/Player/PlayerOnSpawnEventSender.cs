namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Player
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class PlayerOnSpawnEventSender : EventSenderBase
    {
        public string SoldierName { get; set; }

        public int TeamId { get; set; }

        public override string EventCommand
        {
            get { return Constants.EVENT_PLAYER_ON_SPAWN; }
        }

        public override Packet EventPacket
        {
            get
            {
                return new Packet(PacketOrigin.Server, false, 0,
                                  new List<string> {this.EventCommand, this.SoldierName, Convert.ToString(this.TeamId)});
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            List<string> parameters = commandParameterList.ToList();
            if (parameters.Count == 2)
            {
                this.SoldierName = parameters[0];
                this.TeamId = Convert.ToInt32(parameters[1]);
                return true;
            }
            return false;
        }
    }
}