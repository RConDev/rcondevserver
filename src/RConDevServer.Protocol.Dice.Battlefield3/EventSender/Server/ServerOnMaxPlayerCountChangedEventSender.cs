namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Server
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class ServerOnMaxPlayerCountChangedEventSender : EventSenderBase
    {
        public override string EventCommand
        {
            get { return Constants.EVENT_SERVER_ON_MAX_PLAYER_COUNT_CHANGE; }
        }

        public override Packet EventPacket
        {
            get
            {
                return new Packet(PacketOrigin.Server, false, 0, new List<string>
                    {
                        this.EventCommand,
                        Convert.ToString(this.Count)
                    });
            }
        }

        public int Count { get; private set; }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            List<string> parameters = commandParameterList.ToList();
            if (parameters.Count == 1)
            {
                this.Count = Convert.ToInt32(parameters[0]);
                return true;
            }
            return false;
        }
    }
}