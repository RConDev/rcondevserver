namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Player
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class PlayerOnJoinEventSender : EventSenderBase
    {
        public string SoldierName { get; private set; }

        public string Guid { get; private set; }

        public override string EventCommand
        {
            get { return Constants.EVENT_PLAYER_ON_JOIN; }
        }

        public override Packet EventPacket
        {
            get
            {
                return new Packet(PacketOrigin.Server, false, 0,
                                  new List<string> {this.EventCommand, this.SoldierName, this.Guid});
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            List<string> parameters = commandParameterList.ToList();
            if (parameters.Count == 2)
            {
                this.SoldierName = parameters[0];
                this.Guid = parameters[1];
                return true;
            }
            return false;
        }
    }
}