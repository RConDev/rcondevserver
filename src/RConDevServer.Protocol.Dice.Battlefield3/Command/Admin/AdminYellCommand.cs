namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Admin
{
    using System;
    using System.Collections.Generic;
    using Data;

    /// <summary>
    ///     the command "admin.yell"
    /// </summary>
    public class AdminYellCommand : ICommand
    {
        /// <summary>
        ///     creates a new instance of <see cref="AdminYellCommand" />
        /// </summary>
        /// <param name="message"></param>
        /// <param name="duration"></param>
        /// <param name="playerSubset"></param>
        public AdminYellCommand(string message, int? duration = null, PlayerSubset playerSubset = null)
        {
            this.Message = message;
            this.Duration = duration;
            this.PlayerSubset = playerSubset;
        }

        /// <summary>
        ///     the message to be displayed
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        ///     optional duration in seconds the <see cref="Message" /> is displayed
        /// </summary>
        public int? Duration { get; private set; }

        /// <summary>
        ///     optional <see cref="PlayerSubset" /> the message is displayed to
        /// </summary>
        public PlayerSubset PlayerSubset { get; private set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.AdminYell; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {this.Command, this.Message};
            if (this.Duration.HasValue)
            {
                words.Add(Convert.ToString(this.Duration));
            }
            if (this.PlayerSubset != null)
            {
                words.AddRange(this.PlayerSubset.ToWords());
            }
            return words;
        }
    }
}