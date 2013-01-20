namespace RConDevServer.Protocol.Dice.Battlefield3.EventSender.Player
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Data;
    using Util;

    public class PlayerOnChatEventSender : EventSenderBase
    {
        public string SoldierName { get; set; }

        public string Text { get; set; }

        public PlayerSubset PlayerSubset { get; set; }

        public override string EventCommand
        {
            get { return Constants.EVENT_PLAYER_ON_CHAT; }
        }

        public override Packet EventPacket
        {
            get
            {
                var packet = new Packet(PacketOrigin.Server, false, 0, new List<string>
                    {
                        this.EventCommand,
                        this.SoldierName,
                        this.Text,
                    });
                StringListExtensions.AddRange(packet.Words, this.PlayerSubset.ToWords());
                return packet;
            }
        }

        public override bool SetParameters(IEnumerable<string> commandParameterList)
        {
            List<string> parameters = commandParameterList.ToList();

            if (parameters.Count == 0)
            {
                return false;
            }

            this.SoldierName = parameters[0];
            this.Text = parameters[1];
            if (parameters.Count == 3 && parameters[2].ToLower() == "all")
            {
                this.PlayerSubset = new PlayerSubset(PlayerSubsetType.All);
                return true;
            }

            if (parameters.Count == 4)
            {
                if (parameters[2].ToLower() == "player")
                {
                    this.PlayerSubset = new PlayerSubset(

                        type: PlayerSubsetType.Player,
                        playerName: parameters[3]
                        );
                }
                if (parameters[2].ToLower() == "team")
                {
                    this.PlayerSubset = new PlayerSubset
                        (PlayerSubsetType.Team,
                            teamId : Convert.ToInt32(parameters[3])
                        );
                }
                return true;
            }

            if (parameters.Count == 5 && parameters[2].ToLower() == "squad")
            {
                this.PlayerSubset = new PlayerSubset
                    (PlayerSubsetType.Squad,
                        teamId: Convert.ToInt32(parameters[3]),
                        squadId: Convert.ToInt32(parameters[4])
                    );
                return true;
            }
            return false;
        }
    }
}