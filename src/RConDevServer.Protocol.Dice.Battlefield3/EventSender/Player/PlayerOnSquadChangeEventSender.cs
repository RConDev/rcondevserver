namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Player
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class PlayerOnSquadChangeEventSender : EventSenderBase
    {
        public string SoldierName { get; set; }

        public int TeamId { get; set; }

        public int SquadId { get; set; }


        public override string EventCommand
        {
            get { return Constants.EVENT_PLAYER_ON_SQUAD_CHANGE; }
        }

        public override Packet EventPacket
        {
            get
            {
                return new Packet(PacketOrigin.Server, false, 0, new List<string>
                    {
                        this.EventCommand,
                        this.SoldierName,
                        Convert.ToString(this.TeamId),
                        Convert.ToString(this.SquadId)
                    });
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            List<string> parameters = commandParameterList.ToList();
            if (parameters.Count == 3)
            {
                this.SoldierName = parameters[0];
                this.TeamId = Convert.ToInt32(parameters[1]);
                this.SquadId = Convert.ToInt32(parameters[2]);

                return true;
            }
            return false;
        }
    }
}