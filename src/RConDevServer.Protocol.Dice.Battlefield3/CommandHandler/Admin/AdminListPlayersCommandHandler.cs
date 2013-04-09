namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using Command;
    using Command.Admin;
    using CommandResponse;
    using Common;

    /// <summary>
    /// Implementation of <see cref="ICanHandleClientCommands{TCommand}"/> for <see cref="AdminListPlayersCommand"/>
    /// </summary>
    public class AdminListPlayersCommandHandler : CommandHandlerBase<AdminListPlayersCommand>
    {
        #region ICanHandleClientCommands Members

        /// <summary>
        ///     gets the string command for which the current 
        ///     <see cref="ICanHandleClientCommands{TCommand}" /> implementation
        ///     is responsible for
        /// </summary>
        public override string Command
        {
            get { return CommandNames.AdminListPlayers; }
        }

        /// <summary>
        /// Processes the <see cref="ICommand"/> the current handler is responsible for
        /// </summary>
        /// <param name="command"></param>
        /// <param name="session"></param>
        public override ICommandResponse ProcessCommand(AdminListPlayersCommand command, IPacketSession session)
        {
            return new PlayerListOkResponse(session.Server.PlayerList, true);
        }

        #endregion
    }
}