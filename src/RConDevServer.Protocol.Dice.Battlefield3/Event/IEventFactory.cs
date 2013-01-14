namespace RConDevServer.Protocol.Dice.Battlefield3.Event
{
    /// <summary>
    ///     Interface for creating <see cref="IEvent" /> instances
    /// </summary>
    public interface IEventFactory
    {
        /// <summary>
        ///     Creates an <see cref="IEvent" /> instance from string
        /// </summary>
        /// <param name="eventString"></param>
        /// <returns></returns>
        IEvent FromString(string eventString);
    }
}