namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Admin
{
    using System.Collections.Generic;
    using Data;

    /// <summary>
    ///     implementation of the admin.say command
    /// </summary>
    public class SayCommand : ICommand
    {
        /// <summary>
        ///     creates an instance of <see cref="SayCommand" />
        /// </summary>
        /// <param name="message"></param>
        /// <param name="receiver"></param>
        public SayCommand(string message, PlayerSubset receiver)
        {
            this.Message = message;
            this.Receiver = receiver;
        }

        /// <summary>
        ///     the message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     the players who will receive the message
        /// </summary>
        public PlayerSubset Receiver { get; set; }

        /// <summary>
        ///     The command name
        /// </summary>
        public string Command
        {
            get { return CommandNames.AdminSay; }
        }

        /// <summary>
        ///     Generates the words needed to create the <see cref="RConDevServer.Protocol.Dice.Common.IPacket" />
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            var words = new List<string>
                {
                    this.Command,
                    this.Message
                };
            words.AddRange(this.Receiver.ToWords());
            return words;
        }
    }
}