using System.Collections.Generic;
using System.Linq;

namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Punkbuster
{
    public class PunkbusterOnMessageEventSender : EventSenderBase
    {
        public string Message { get; set; }

        public override string EventCommand
        {
            get { return Constants.EVENT_PUNKBUSTER_ON_MESSAGE; }
        }

        public override Packet EventPacket
        {
            get { return new Packet(PacketOrigin.Server, false, 0, new List<string>{EventCommand, Message}); }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            var parameters = commandParameterList.ToList();
            if (parameters.Count == 1)
            {
                Message = parameters[0];
                return true;
            }
            return false;
        }
    }
}
