namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Player
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

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
                        this.EventCommand,
                        this.KillingSoldierName,
                        this.KilledSoldierName,
                        this.Weapon,
                        Convert.ToString(this.IsHeadShot)
                    });
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            List<string> parameters = commandParameterList.ToList();
            if (parameters.Count == 4)
            {
                this.KillingSoldierName = parameters[0];
                this.KilledSoldierName = parameters[1];
                this.Weapon = parameters[2];
                this.IsHeadShot = Convert.ToBoolean(parameters[3]);
                return true;
            }

            return false;
        }
    }
}