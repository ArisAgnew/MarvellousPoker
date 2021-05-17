using System;

namespace MarvellousPoker.Controllers.Adjuvants
{
    public static class EventHandlerExtentions
    {
        public static void SafeEvoke(this EventHandler handler, object sender, EventArgs e) =>
            handler?.Invoke(sender, e);

        public static void SafeEvoke<TEventArgs>(this EventHandler<TEventArgs> handler, object sender, TEventArgs e)
            where TEventArgs : class => handler?.Invoke(sender, e);
    }
}
