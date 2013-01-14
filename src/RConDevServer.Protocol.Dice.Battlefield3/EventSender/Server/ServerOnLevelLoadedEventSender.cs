namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Server
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Data;

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
                        this.EventCommand,
                        this.Map.ToWord(),
                        this.GameMode.ToWord(),
                        Convert.ToString(this.RoundsPlayed),
                        Convert.ToString(this.TotalRounds)
                    });
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            List<string> parameters = commandParameterList.ToList();
            if (parameters.Count == 4)
            {
                this.Map = this.availableMaps.FindByCode(parameters[0]);
                this.GameMode = GameModes.FindByCode(parameters[1]);
                this.RoundsPlayed = Convert.ToInt32(parameters[2]);
                this.TotalRounds = Convert.ToInt32(parameters[3]);

                return true;
            }
            return false;
        }
    }
}