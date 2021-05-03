using System;

namespace MarvellousPoker.Controllers.Adjuvants
{
    public static class EventHandlerExtentions
    {
        public static void SafeRaise(this EventHandler handler, object sender, EventArgs e) =>
            handler?.Invoke(sender, e);

        public static void SafeRaise<TEventArgs>(this EventHandler<TEventArgs> handler, object sender, TEventArgs e)
            where TEventArgs : EventArgs => handler?.Invoke(sender, e);
    }
}
