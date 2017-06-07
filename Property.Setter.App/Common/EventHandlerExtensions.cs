using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace Property.Setter.App.Common
{
    public static class EventHandlerExtensions
    {
        public static bool IsRegistered(this EventHandler handler, Delegate prospectiveHandler)
        {
            return handler.IsEventHandlerRegistered(prospectiveHandler);
        }

        public static bool IsRegistered<T>(this EventHandler<T> handler, Delegate prospectiveHandler) where T : EventArgs
        {
            return handler.IsEventHandlerRegistered(prospectiveHandler);
        }

        public static bool IsRegistered(this DependencyPropertyChangedEventHandler handler, Delegate prospectiveHandler)
        {
            return handler.IsEventHandlerRegistered(prospectiveHandler);
        }

        public static bool IsRegistered(PropertyChangedEventHandler handler, Delegate prospectiveHandler)
        {
            if (handler == null)
                return false;

            return handler.GetInvocationList().Any(
                       existingHandler => existingHandler == prospectiveHandler) || handler.IsEventHandlerRegistered(prospectiveHandler);
        }

        private static bool IsEventHandlerRegistered(this MulticastDelegate multDelegate, Delegate prospectiveHandler)
        {
            if (multDelegate == null)
                return false;

            return multDelegate.GetInvocationList()
                               .Any(
                                   existingHandler => existingHandler == prospectiveHandler);
        }
    }
}
