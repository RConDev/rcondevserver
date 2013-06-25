namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// This Enum defines the way a player is identified 
    /// (for example in a ban list)
    /// </summary>
    public enum IdType
    {
        /// <summary>
        /// identified by player name
        /// </summary>
        [Display(Name="Player Name")]
        Name,
        
        /// <summary>
        /// identified by IP-Address
        /// </summary>
        [Display(Name = "IP-Address")]
        IpAddress,
        
        /// <summary>
        /// identified by players EA_GUID
        /// </summary>
        [Display(Name = "Player GUID")]
        Guid
    }
}