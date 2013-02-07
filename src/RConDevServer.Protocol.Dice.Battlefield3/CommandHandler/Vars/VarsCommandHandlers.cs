namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    using Command;

    public class VarsCommandHandlers: CommandHandlers
    {
        public VarsCommandHandlers()
        {
            this.RegisterCommandHandler( new VarsGamePasswordCommandHandler());
            this.RegisterCommandHandler( new VarsServerNameCommandHandler());
            this.RegisterCommandHandler( new VarsRankedCommandHandler());
            this.RegisterCommandHandler( new VarsAutoBalanceCommandHandler());
            this.RegisterCommandHandler( new VarsFriendlyFireCommandHandler());
            this.RegisterCommandHandler( new VarsServerDescriptionCommandHandler());
            this.RegisterCommandHandler( new VarsMaxPlayersCommandHandler());
            this.RegisterCommandHandler( new VarsIdleTimeoutCommandHandler());
            this.RegisterCommandHandler( new VarsAutoBalanceCommandHandler());
            this.RegisterCommandHandler( new VarsCrossHairCommandHandler());
            this.RegisterCommandHandler( new VarsHudCommandHandler());
            this.RegisterCommandHandler( new VarsKillCamCommandHandler());
            this.RegisterCommandHandler( new VarsMiniMapCommandHandler());
            this.RegisterCommandHandler( new VarsServerMessageCommandHandler());
            this.RegisterCommandHandler( new Vars3DSpottingCommandHandler());
            this.RegisterCommandHandler( new VarsMiniMapSpottingCommandHandler());
            this.RegisterCommandHandler( new VarsNameTagCommandHandler());
            this.RegisterCommandHandler( new Vars3PCamCommandHandler());
            this.RegisterCommandHandler( new VarsTeamKillCountForKickCommandHandler());
            this.RegisterCommandHandler( new VarsTeamKillValueForKickCommandHandler());
            this.RegisterCommandHandler( new VarsTeamKillValueIncreaseCommandHandler());
            this.RegisterCommandHandler( new VarsTeamKillValueDecreaseCommandHandler());
            this.RegisterCommandHandler( new VarsTeamKillKickForBanCommandHandler());
            this.RegisterCommandHandler( new VarsIdleBanRoundsCommandHandler());
            this.RegisterCommandHandler( new VarsRoundStartPlayerCountCommandHandler());
            this.RegisterCommandHandler( new VarsRoundRestartPlayerCountCommandHandler());
            this.RegisterCommandHandler( new VarsRoundLockdownCountdownCommandHandler());
            this.RegisterCommandHandler( new VarsVehicleSpawnAllowedCommandHandler());
            this.RegisterCommandHandler( new VarsVehicleSpawnDelayCommandHandler());
            this.RegisterCommandHandler( new VarsSoldierHealthCommandHandler());
            this.RegisterCommandHandler( new VarsPlayerRespawnTimeCommandHandler());
            this.RegisterCommandHandler( new VarsPlayerManDownTimeCommandHandler());
            this.RegisterCommandHandler( new VarsBulletDamageCommandHandler());
            this.RegisterCommandHandler( new VarsGameModeCounterCommandHandler());
            this.RegisterCommandHandler( new VarsOnlySquadLeaderSpawnCommandHandler());
            this.RegisterCommandHandler( new VarsUnlockModeCommandHandler());
            this.RegisterCommandHandler( new VarsRegenerateHealthCommandHandler());
            this.RegisterCommandHandler( new VarsPremiumStatusCommandHandler());
        }
    }
}