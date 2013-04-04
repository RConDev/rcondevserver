namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Admin
{
    using Command;
    using Command.Admin;
    using CommandResponse;

    public class AdminEffectiveMaxPlayersCommandHandler : CommandHandlerBase<AdminEffectiveMaxPlayersCommand>
    {
        public override string Command
        {
            get { return CommandNames.AdminEffectiveMaxPlayers; }
        }

        public override ICommandResponse ProcessCommand(AdminEffectiveMaxPlayersCommand command,
                                                        IPacketSession session)
        {
            var response = new DecimalOkResponse(session.Server.ServerInfo.MaxPlayerCount);
            return response;
        }
    }
}