﻿namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command.Vars;

    public class VarsMiniMapCommandHandler : VarsDefaultBoolCommandHandler<VarsMiniMapCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_MINIMAP; }
        }
    }
}