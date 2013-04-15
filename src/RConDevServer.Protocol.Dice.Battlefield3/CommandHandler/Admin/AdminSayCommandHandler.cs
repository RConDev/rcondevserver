namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using System.Linq;
    using Command;
    using Command.Admin;
    using CommandResponse;
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

            if (command.Receiver.Type == PlayerSubsetType.Team 
                && ( command.Receiver.TeamId < 0 || command.Receiver.TeamId > 16))
            {
                return new InvalidTeamIdResponse();
            }

            if (command.Receiver.Type == PlayerSubsetType.Squad
                && (command.Receiver.SquadId < 0 || command.Receiver.SquadId > 32))
            {
                return new InvalidSquadIdResponse();
            }

            if (command.Receiver.Type == PlayerSubsetType.Player
                && session.Server.PlayerList.Players.All(x => x.Name != command.Receiver.PlayerName))
            {
                return new PlayerNotFoundResponse();
            }

            this.AddEvent(new PlayerOnChatEvent("Server",command.Message, command.Receiver));
            return new OkResponse();
        }

        #endregion
    }
}