namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using System.Linq;
    using Command;
    using Command.Admin;
    using CommandResponse;
    using Data;

    /// <summary>
    /// Implementation of <see cref="ICanHandleClientCommands{TCommand}"/> for <see cref="AdminYellCommand"/>
    /// </summary>
    public class AdminYellCommandHandler : CommandHandlerBase<AdminYellCommand>
    {
        /// <summary>
        ///     gets the string command for which the current 
        ///     <see cref="ICanHandleClientCommands{TCommand}" /> implementation
        ///     is responsible for
        /// </summary>
        public override string Command
        {
            get { return CommandNames.AdminYell; }
        }

        /// <summary>
        /// Processes the <see cref="ICommand"/> the current handler is responsible for
        /// </summary>
        /// <param name="command"></param>
        /// <param name="session"></param>
        public override ICommandResponse ProcessCommand(AdminYellCommand command, IPacketSession session)
        {
            if (command.Message.Length >= 256)
            {
                return new TooLongMessageResponse();
            }

            if (command.PlayerSubset.Type == PlayerSubsetType.Team
                && (command.PlayerSubset.TeamId < 0 || command.PlayerSubset.TeamId > 16))
            {
                return new InvalidTeamIdResponse();
            }

            if (command.PlayerSubset.Type == PlayerSubsetType.Squad
                && (command.PlayerSubset.SquadId < 0 || command.PlayerSubset.SquadId > 32))
            {
                return new InvalidSquadIdResponse();
            }

            if (command.PlayerSubset.Type == PlayerSubsetType.Player
                && session.Server.PlayerList.Players.All(x => x.Name != command.PlayerSubset.PlayerName))
            {
                return new PlayerNotFoundResponse();
            }

            return new OkResponse();
        }
    }
}