namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using System.Linq;
    using Command;
    using Command.Admin;
    using CommandResponse;
    using Common;
    using Data;
    using Event.Player;

    /// <summary>
    /// Implementation of <see cref="ICanHandleClientCommands{TCommand}"/> for <see cref="AdminSayCommand"/>
    /// </summary>
    public class AdminSayCommandHandler : CommandHandlerBase<AdminSayCommand>
    {
        #region ICanHandleClientCommands Members

        /// <summary>
        ///     gets the string command for which the current 
        ///     <see cref="ICanHandleClientCommands{TCommand}" /> implementation
        ///     is responsible for
        /// </summary>
        public override string Command
        {
            get { return CommandNames.AdminSay; }
        }

        /// <summary>
        /// Processes the <see cref="ICommand"/> the current handler is responsible for
        /// </summary>
        /// <param name="command"></param>
        /// <param name="session"></param>
        public override ICommandResponse ProcessCommand(AdminSayCommand command, IPacketSession session)
        {
            if (command.Message.Length >= 128)
            {
                return new TooLongMessageResponse();
            }

            this.AddEvent(new PlayerOnChatEvent("Server",command.Message, command.Receiver));

            return new OkResponse();
        }

        public override bool OnCreatingResponse(PacketSession session, AdminSayCommand command, Packet requestPacket, Packet responsePacket)
        {
            string message = requestPacket.Words[1];
            PlayerSubset playerSubset = PlayerSubset.FromWords(requestPacket.Words.Skip(2).ToList());

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