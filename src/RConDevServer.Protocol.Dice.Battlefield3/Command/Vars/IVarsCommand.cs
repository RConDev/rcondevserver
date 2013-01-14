namespace RConDevServer.Protocol.Dice.Battlefield3.Command.Vars
{
    /// <summary>
    ///     basic interface for vars commands
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IVarsCommand<T> : ICommand where T : struct
    {
        /// <summary>
        ///     get or set the value of the variable
        /// </summary>
        T? Value { get; set; }
    }
}