namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command.Vars;

    public class VarsCrossHairCommandHandler : VarsDefaultBoolCommandHandler<VarsCrossHairCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_CROSS_HAIR; }
        }
    }
}