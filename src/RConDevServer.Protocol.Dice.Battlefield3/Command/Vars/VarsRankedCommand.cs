namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Change the server between ranked/unranked mode
    /// </summary>
    /// <remarks>
    ///     This command can only be used during startup.
    ///     It can only be used to switch the server from ranked to unranked mode;
    ///     the server can never switch back to ranked mode again.
    /// </remarks>
    public class VarsRankedCommand : ICommand
    {
        /// <summary>
        ///     create a new <see cref="VarsRankedCommand" /> instance
        /// </summary>
        /// <param name="isRanked"></param>
        public VarsRankedCommand(bool? isRanked = null)
        {
            this.IsRanked = isRanked;
        }

        /// <summary>
        ///     actual state of the server
        /// </summary>
        public bool? IsRanked { get; set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.VarsRanked; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {this.Command};
            if (this.IsRanked != null)
            {
                words.Add(Convert.ToString(this.IsRanked));
            }
            return words;
        }
    }
}