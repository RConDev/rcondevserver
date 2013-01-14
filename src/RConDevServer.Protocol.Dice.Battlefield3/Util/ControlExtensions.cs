namespace RConDevServer.Protocol.Dice.Battlefield3.Util
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// </summary>
    /// <remarks>http://stackoverflow.com/questions/783925/control-invoke-with-input-parameters</remarks>
    public static class ControlExtensions
    {
        public static TResult InvokeEx<TControl, TResult>(this TControl control,
                                                          Func<TControl, TResult> func)
            where TControl : Control
        {
            return control.InvokeRequired
                       ? (TResult) control.Invoke(func, control)
                       : func(control);
        }

        public static void InvokeEx<TControl>(this TControl control,
                                              Action<TControl> func)
            where TControl : Control
        {
            InvokeEx(control, c =>
                {
                    func(c);
                    return c;
                });
        }

        public static void InvokeEx<TControl>(this TControl control, Action action)
            where TControl : Control
        {
            InvokeEx(control, c => action());
        }
    }
}