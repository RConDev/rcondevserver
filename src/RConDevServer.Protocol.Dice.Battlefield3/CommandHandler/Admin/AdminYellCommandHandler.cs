namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using System;
    using System.Linq;
    using Command;
    using CommandFactory.Admin;
    using Common;
    using Data;

    public class AdminYellCommandHandler : CommandHandlerBase
    {
        public override string Command
        {
            get { return CommandNames.AdminYell; }
        }

        public override bool OnCreatingResponse(PacketSession session, ICommand command, Packet requestPacket, Packet responsePacket)
        {
            string message = requestPacket.Words[1];
            int duration = (requestPacket.Words.Count > 2) ? Convert.ToInt32(requestPacket.Words[2]) : 10;
            PlayerSubset playerSubset = (requestPacket.Words.Count > 3)
                                            ? PlayerSubset.FromWords(requestPacket.Words.Skip(3).ToList())
                                            : new PlayerSubset(PlayerSubsetType.All);

            if (message.Length >= 256)
            {
                responsePacket.Words.Add(Constants.RESPONSE_TOO_LONG_MESSAGE);
                return true;
            }

            switch (playerSubset.Type)
            {
                case PlayerSubsetType.None:
                    responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                    return true;

                case PlayerSubsetType.All:
                    responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
                    return true;

                case PlayerSubsetType.Team:
                    responsePacket.Words.Add(playerSubset.TeamId <= 16
                                                 ? Constants.RESPONSE_SUCCESS
                                                 : Constants.RESPONSE_INVALID_TEAM);
                    return true;

                case PlayerSubsetType.Squad:
                    if (playerSubset.TeamId <= 16)
                    {
                        responsePacket.Words.Add(playerSubset.SquadId <= 32
                                                     ? Constants.RESPONSE_SUCCESS
                                                     : Constants.RESPONSE_INVALID_SQUAD);
                    }
                    else
                    {
                        responsePacket.Words.Add(Constants.RESPONSE_INVALID_TEAM);
                    }
                    return true;

                case PlayerSubsetType.Player:

                    responsePacket.Words.Add(
                        session.Server.PlayerList.Players.Any(x => x.Name == playerSubset.PlayerName)
                            ? Constants.RESPONSE_SUCCESS
                            : Constants.RESPONSE_PLAYER_NOT_FOUND);
                    return true;
            }

            return false;
        }
    }
}