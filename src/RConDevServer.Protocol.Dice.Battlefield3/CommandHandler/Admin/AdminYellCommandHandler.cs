using System;
using System.Linq;
using RConDevServer.Protocol.Dice.Battlefield3.Data;

namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    public class AdminYellCommandHandler : ICanHandleClientCommands
    {
        public string Command
        {
            get { return RConDevServer.Protocol.Dice.Battlefield3.Constants.COMMAND_ADMIN_YELL; }
        }

        public bool OnCreatingResponse(PacketSession session, Packet requestPacket, Packet responsePacket)
        {
            var message = requestPacket.Words[1];
            var duration = (requestPacket.Words.Count > 2) ? Convert.ToInt32(requestPacket.Words[2]) : 10;
            var playerSubset = (requestPacket.Words.Count > 3)
                                   ? PlayerSubset.FromWords(requestPacket.Words.Skip(3).ToList())
                                   : new PlayerSubset { Type = PlayerSubsetType.All };

            if (message.Length >= 256)
            {
                responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_TOO_LONG_MESSAGE);
                return true;
            }

            switch (playerSubset.Type)
            {
                case PlayerSubsetType.None:
                    responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_INVALID_ARGUMENTS);
                    return true;

                case PlayerSubsetType.All:
                    responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_SUCCESS);
                    return true;

                case PlayerSubsetType.Team:
                    responsePacket.Words.Add(playerSubset.TeamId <= 16
                                                 ? RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_SUCCESS
                                                 : RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_INVALID_TEAM);
                    return true;

                case PlayerSubsetType.Squad:
                    if (playerSubset.TeamId <= 16)
                    {
                        responsePacket.Words.Add(playerSubset.SquadId <= 32
                                                     ? RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_SUCCESS
                                                     : RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_INVALID_SQUAD);
                    }
                    else
                    {
                        responsePacket.Words.Add(RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_INVALID_TEAM);
                    }
                    return true;

                case PlayerSubsetType.Player:

                    responsePacket.Words.Add(
                        session.Server.PlayerList.Players.Any(x => x.Name == playerSubset.PlayerName)
                            ? RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_SUCCESS
                            : RConDevServer.Protocol.Dice.Battlefield3.Constants.RESPONSE_PLAYER_NOT_FOUND);
                    return true;

            }

            return false;
        }
    }
}
