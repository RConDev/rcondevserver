using System;
using System.Collections.Generic;
using System.Linq;
 
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Server
{
    public class ServerOnLevelLoadedEventSender : EventSenderBase
    {
        private readonly Maps availableMaps;

        public ServerOnLevelLoadedEventSender(Maps availableMaps)
        {
            this.availableMaps = availableMaps;
        }

        #region Constructors



        #endregion

        public Map Map { get; set; }

        public GameMode GameMode { get; set; }

        public int RoundsPlayed { get; set; }

        public int TotalRounds { get; set; }

        public override string EventCommand
        {
            get { return Constants.EVENT_SERVER_ON_LEVEL_LOADED; }
        }

        public override Packet EventPacket
        {
            get
            {
                return new Packet(PacketOrigin.Server, false, 0, new List<string>
                                                                       {
                                                                           EventCommand,
                                                                           Map.ToWord(),
                                                                           GameMode.ToWord(),
                                                                           Convert.ToString(RoundsPlayed),
                                                                           Convert.ToString(TotalRounds)
                                                                       });
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            var parameters = commandParameterList.ToList();
            if (parameters.Count == 4)
            {
                Map = availableMaps.FindByCode(parameters[0]);
                GameMode = GameModes.FindByCode(parameters[1]);
                RoundsPlayed = Convert.ToInt32(parameters[2]);
                TotalRounds = Convert.ToInt32(parameters[3]);

                return true;
            }
            return false;
        }
    }
}
