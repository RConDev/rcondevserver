namespace RConDevServer.Protocol.Dice.Battlefield3.Tests.Command.Vars
{
    using System;
    using Battlefield3.Command;

    public abstract class IntVarsCommandTestBase<TCommand> : VarsCommandTestBase<TCommand, int?>
        where TCommand : class, IVarsCommand<int?>
    {
        public override TCommand CreateCommandWithValue()
        {
            return Activator.CreateInstance(typeof(TCommand), this.GetValue()) as TCommand;
        }

        public override TCommand CreateCommandWithoutValue()
        {
            return Activator.CreateInstance(typeof(TCommand), (int?) null) as TCommand;
        }

        public override int? GetValue()
        {
            return 123;
        }

        public override string GetStringValue()
        {
            return "123";
        }
    }
}