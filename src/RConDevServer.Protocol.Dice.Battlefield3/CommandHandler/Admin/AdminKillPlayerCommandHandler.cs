namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using System.Linq;
    using Command;
    using Command.Admin;
    using CommandResponse;
    using Common;

    /// <summary>
    /// Implementation of <see cref="ICanHandleClientCommands{TCommand}"/> for <see cref="AdminKillPlayerCommand"/>
    /// </summary>
    public class AdminKillPlayerCommandHandler : CommandHandlerBase<AdminKillPlayerCommand>
    {
        /// <summary>
        ///     gets the string command for which the current 
        ///     <see cref="ICanHandleClientCommands{TCommand}" /> implementation
        ///     is responsible for
        /// </summary>
        public override string Command
        {
            get { return CommandNames.AdminKillPlayer; }
        }

        /// <summary>
        /// Processes the <see cref="ICommand"/> the current handler is responsible for
        /// </summary>
        /// <param name="command"></param>
        /// <param name="session"></param>
        public override ICommandResponse ProcessCommand(AdminKillPlayerCommand command, IPacketSession session)
        {
            var players = session.Server.PlayerList.Players;
            if (players.Any(x => x.Name == command.SoldierName))
            {
                return new OkResponse();
            }

            return new InvalidPlayerNameResponse();
        }
    }
}