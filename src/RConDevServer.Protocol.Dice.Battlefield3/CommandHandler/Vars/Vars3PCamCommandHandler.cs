namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command.Vars;

    public class Vars3PCamCommandHandler : VarsDefaultBoolCommandHandler<Vars3PCamCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_3_P_CAM; }
        }
    }
}