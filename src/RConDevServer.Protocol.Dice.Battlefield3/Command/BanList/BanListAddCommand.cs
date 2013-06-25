namespace RConDevServer.Protocol.Dice.Battlefield3.Command.BanList
{
    using System.Collections.Generic;
    using Data;

    /// <summary>
    ///     Add player to ban list for a certain amount of time
    /// </summary>
    /// <remarks>
    ///     Adding a new name/IP/GUID ban will replace any previous ban for that name/IP/GUID timeout can
    ///     take three forms:
    ///         perm - permanent [default]
    ///         rounds {integer} - until the given number of rounds has passed
    ///         seconds {integer} - number of seconds until ban expires
    ///     Id-type can be any of these
    ///         name – A soldier name
    ///         ip – An IP address
    ///         guid – A player guid
    ///     Id could be either a soldier name, ip address or guid depending on id-type.
    ///     Reason is optional and defaults to “Banned by admin”; max length 80 chars.
    /// </remarks>
    public class BanListAddCommand : ICommand
    {
        /// <summary>
        /// Create a new <see cref="BanListAddCommand"/> instance
        /// </summary>
        /// <param name="idType"></param>
        /// <param name="id"></param>
        /// <param name="timeout"></param>
        /// <param name="reason"></param>
        public BanListAddCommand(IdType idType, string id, Timeout timeout, string reason = null)
        {
            this.IdType = idType;
            this.Id = id;
            this.Timeout = timeout;
            this.Reason = reason;
        }

        /// <summary>
        /// Id-Type
        /// </summary>
        public IdType IdType { get; private set; }

        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// timeout
        /// </summary>
        public Timeout Timeout { get; private set; }

        /// <summary>
        /// the ban reason
        /// </summary>
        public string Reason { get; private set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.BanListAdd; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            var words = new List<string>{Command, IdTypeExtension.ToWord(this.IdType) , Id};
            words.AddRange(Timeout.ToWords());
            if (!string.IsNullOrEmpty(Reason))
            {
                words.Add(Reason);
            }
            return words;
        }
    } 
}