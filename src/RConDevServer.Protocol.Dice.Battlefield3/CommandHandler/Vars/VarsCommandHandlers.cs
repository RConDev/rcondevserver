namespace RConDevServer.Protocol.Dice.Battlefield3.CommandHandler.Vars
{
    public class VarsCommandHandlers : CommandHandlers
    {
        public VarsCommandHandlers()
        {
            RegisterCommandHandler(new VarsGamePasswordCommandHandler());
            RegisterCommandHandler(new VarsServerNameCommandHandler());
            RegisterCommandHandler(new VarsRankedCommandHandler());
            RegisterCommandHandler(new VarsAutoBalanceCommandHandler());
            RegisterCommandHandler(new VarsBannerUrlCommandHandler());
            RegisterCommandHandler(new VarsFriendlyFireCommandHandler());
            RegisterCommandHandler(new VarsServerDescriptionCommandHandler());
            RegisterCommandHandler(new VarsMaxPlayersCommandHandler());
            RegisterCommandHandler(new VarsIdleTimeOutCommandHandler());
            RegisterCommandHandler(new VarsAutoBalanceCommandHandler());
            RegisterCommandHandler(new VarsCrossHairCommandHandler());
            RegisterCommandHandler(new VarsHudCommandHandler());
            RegisterCommandHandler(new VarsKillCamCommandHandler());
            RegisterCommandHandler(new VarsMiniMapCommandHandler());
            RegisterCommandHandler(new VarsServerMessageCommandHandler());
            RegisterCommandHandler(new Vars3DSpottingCommandHandler());
            RegisterCommandHandler(new VarsMiniMapSpottingCommandHandler());
            RegisterCommandHandler(new VarsNameTagCommandHandler());
            RegisterCommandHandler(new Vars3PCamCommandHandler());
            RegisterCommandHandler(new VarsTeamKillCountForKickCommandHandler());
            RegisterCommandHandler(new VarsTeamKillValueForKickCommandHandler());
            RegisterCommandHandler(new VarsTeamKillValueIncreaseCommandHandler());
            RegisterCommandHandler(new VarsTeamKillValueDecreaseCommandHandler());
            RegisterCommandHandler(new VarsTeamKillKickForBanCommandHandler());
            RegisterCommandHandler(new VarsIdleBanRoundsCommandHandler());
            RegisterCommandHandler(new VarsRoundStartPlayerCountCommandHandler());
            RegisterCommandHandler(new VarsRoundRestartPlayerCountCommandHandler());
            RegisterCommandHandler(new VarsRoundLockdownCountdownCommandHandler());
            RegisterCommandHandler(new VarsVehicleSpawnAllowedCommandHandler());
            RegisterCommandHandler(new VarsVehicleSpawnDelayCommandHandler());
            RegisterCommandHandler(new VarsSoldierHealthCommandHandler());
            RegisterCommandHandler(new VarsPlayerRespawnTimeCommandHandler());
            RegisterCommandHandler(new VarsPlayerManDownTimeCommandHandler());
            RegisterCommandHandler(new VarsBulletDamageCommandHandler());
            RegisterCommandHandler(new VarsGameModeCounterCommandHandler());
            RegisterCommandHandler(new VarsOnlySquadLeaderSpawnCommandHandler());
            RegisterCommandHandler(new VarsUnlockModeCommandHandler());
            RegisterCommandHandler(new VarsRegenerateHealthCommandHandler());
            RegisterCommandHandler(new VarsPremiumStatusCommandHandler());
        }
    }
}