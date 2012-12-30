using System;

namespace RConDevServer.Protocol.Dice.Battlefield3.Data
{
    public interface IUpdatable
    {
        event EventHandler<EventArgs> Updated;
    }
}