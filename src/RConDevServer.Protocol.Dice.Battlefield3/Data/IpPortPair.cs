namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    /// <summary>
    /// This class represents the type IpPortPair from the RCon protocol of
    /// Battlefield 3
    /// </summary>
    public class IpPortPair
    {
        public string Ip { get; set; }

        public int Port { get; set; }

        public string ToWord()
        {
            return string.Format("{0}:{1}", this.Ip, this.Port);
        }
    }
}