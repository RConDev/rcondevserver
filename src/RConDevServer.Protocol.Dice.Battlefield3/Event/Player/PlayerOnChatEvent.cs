namespace RConDevServer.Protocol.Dice.Battlefield3.Event.Player
{
    using System.Collections.Generic;
    using Data;

    /// <summary>
    ///     The <see cref="PlayerOnChatEvent" /> is send, after a "a"
    /// </summary>
    public class PlayerOnChatEvent : IEvent
    {
        /// <summary>
        ///     Creates an event that is send after admin.say / admin.yell
        /// </summary>
        /// <param name="senderName"></param>
        /// <param name="message"></param>
        /// <param name="receivers"></param>
        public PlayerOnChatEvent(string senderName, string message, PlayerSubset receivers)
        {
            this.Receivers = receivers;
            this.Message = message;
            this.SenderName = senderName;
        }

        /// <summary>
        ///     The Name of the sender of the message
        /// </summary>
        public string SenderName { get; private set; }

        /// <summary>
        ///     The Message itself
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        ///     The receivers of the message
        /// </summary>
        public PlayerSubset Receivers { get; private set; }

        #region ToWords()

        /// <summary>
        ///     Creates a words representation for sending a packet to the client
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ToWords()
        {
            var words = new List<string> {this.Event, this.SenderName, this.Message};
            words.AddRange(this.Receivers.ToWords());
            return words;
        }

        #endregion

        /// <summary>
        ///     Returns the event name
        /// </summary>
        public string Event
        {
            get { return Constants.EVENT_PLAYER_ON_CHAT; }
        }
    }
}