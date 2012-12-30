using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Server
{
    public class ServerOnMaxPlayerCountChangedEventSender : EventSenderBase 
    {
        public override string EventCommand { get { return Constants.EVENT_SERVER_ON_MAX_PLAYER_COUNT_CHANGE; } }
        
        public override Packet EventPacket { get
        {
            return new Packet(PacketOrigin.Server, false, 0, new List<string>
                                                                 {
                                                                     EventCommand,
                                                                     Convert.ToString(Count)
                                                                 });
        } }

        public int Count { get; private set; } 

        public override bool SetParameters (IEnumerable<string> commandParameterList)
        {
            var parameters = commandParameterList.ToList();
            if (parameters.Count == 1)
            {
                Count = Convert.ToInt32(parameters[0]);
                return true;
            }
            return false;
        }
    }
}
