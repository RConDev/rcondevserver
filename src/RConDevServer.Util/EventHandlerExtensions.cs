using System;

namespace RConDevServer.Util
{
    /// <summary>
    /// this class delivers extension methods for
    /// </summary>
    public static class EventHandlerExtensions
    {
        /// <summary>
        /// invokes the complete invokation list of the <see cref="EventHandler{TEventArgs}"/>
        /// </summary>
        /// <param name="eventHandler"></param>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void InvokeAll<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object sender, TEventArgs args) where TEventArgs : EventArgs
        {
            var invokeList = eventHandler.GetInvocationList();
            foreach (var invDelegate in invokeList)
            {
                invDelegate.DynamicInvoke(sender, args);
            }
        }
    }
}
