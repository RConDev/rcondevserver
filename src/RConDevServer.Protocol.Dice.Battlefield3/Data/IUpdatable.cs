namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    using System;

    public interface IUpdatable
    {
        event EventHandler<EventArgs> Updated;
    }
}