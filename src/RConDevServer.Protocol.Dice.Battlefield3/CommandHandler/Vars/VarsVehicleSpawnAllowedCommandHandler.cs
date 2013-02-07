﻿namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command.Vars;

    public class VarsVehicleSpawnAllowedCommandHandler 
        : VarsDefaultBoolCommandHandler<VarsVehicleSpawnAllowedCommand>
    {
        public override string Command
        {
            get { return Constants.COMMAND_VARS_VEHICLE_SPAWN_ALLOWED; }
        }
    }
}