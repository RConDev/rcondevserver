namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.BanList
{
    using Command;
    using Command.BanList;
    using CommandResponse;
    using global::Common.Logging;

    /// <summary>
    /// Implementation of <see cref="ICanHandleClientCommands{TCommand}"/> for <see cref="BanListClearCommand"/>
    /// </summary>
    public class BanListClearCommandHandler : CommandHandlerBase<BanListClearCommand>
    {
        private static readonly ILog logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     gets the string command for which the current 
        ///     <see cref="ICanHandleClientCommands{TCommand}" /> implementation
        ///     is responsible for
        /// </summary>
        public override string Command
        {
            get { return CommandNames.BanListClear; }
        }

        /// <summary>
        /// Processes the <see cref="ICommand"/> the current handler is responsible for
        /// </summary>
        /// <param name="command"></param>
        /// <param name="session"></param>
        public override ICommandResponse ProcessCommand(BanListClearCommand command, IPacketSession session)
        {
            logger.DebugFormat("Cleaning current ban list with {0} items", session.Server.BanList.Count);
            session.Server.BanList.Clear();

            logger.Debug("Ban list successfully cleaned");
            return new OkResponse();
        }
    }
}