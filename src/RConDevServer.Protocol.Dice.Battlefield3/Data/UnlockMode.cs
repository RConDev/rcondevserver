namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    /// <summary>
    ///     Specifies which set of unlocks should be available to players.
    /// </summary>
    public enum UnlockMode
    {
        /// <summary>
        ///     all unlocks for player, including purchased DLCs
        /// </summary>
        All,

        /// <summary>
        ///     all unlocks for player, excluding DLCs
        /// </summary>
        Common,

        /// <summary>
        ///     unlocks for player according to his stats
        /// </summary>
        Stats,

        /// <summary>
        ///     only the base set of weapons
        /// </summary>
        None
    }
}