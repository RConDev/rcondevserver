namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using System.Linq;
    using Command;
    using CommandFactory.Admin;
    using Data;
    using Event.Player;

    public class AdminSayCommandHandler : CommandHandlerBase
    {
        public AdminSayCommandHandler() : base(null, new SayCommandFactory())
        {
        }

        #region ICanHandleClientCommands Members

        public override string Command
        {
            get { return CommandNames.AdminSay; }
        }

        public override bool OnCreatingResponse(PacketSession session,
                                                Packet requestPacket,
                                                Packet responsePacket,
                                                ICommand command)
        {
            var message = requestPacket.Words[1];
            var playerSubset = PlayerSubset.FromWords(requestPacket.Words.Skip(2).ToList());

            if (message.Length >= 128)
            {
                responsePacket.Words.Add(Constants.RESPONSE_TOO_LONG_MESSAGE);
                return true;
            }

            bool result = false;
            switch (playerSubset.Type)
            {
                case PlayerSubsetType.None:
                    responsePacket.Words.Add(Constants.RESPONSE_INVALID_ARGUMENTS);
                    result = true;
                    break;

                case PlayerSubsetType.All:
                    responsePacket.Words.Add(Constants.RESPONSE_SUCCESS);
                    result = true;
                    break;

                case PlayerSubsetType.Team:
                    responsePacket.Words.Add(playerSubset.TeamId <= 16
                                                 ? Constants.RESPONSE_SUCCESS
                                                 : Constants.RESPONSE_INVALID_TEAM);
                    result = true;
                    break;

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
                    result = true;
                    break;

                case PlayerSubsetType.Player:

                    responsePacket.Words.Add(
                        session.Server.PlayerList.Players.Any(x => x.Name == playerSubset.PlayerName)
                            ? Constants.RESPONSE_SUCCESS
                            : Constants.RESPONSE_PLAYER_NOT_FOUND);
                    result = true;
                    break;
            }

            // publish event 
            var onChatEvent = new PlayerOnChatEvent("Server", message, playerSubset);
            session.Server.PublishEvent(onChatEvent);

            return result;
        }

        #endregion
    }
}