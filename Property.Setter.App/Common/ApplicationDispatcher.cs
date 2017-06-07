using System;
using System.Windows;

namespace Property.Setter.App.Common
{
    public class ApplicationDispatcher : IDispatcher
    {
        public void BeginInvoke(Action action)
        {
            var appCurrent = Application.Current;

            if (appCurrent == null)
            {
                return;
            }

            if (appCurrent.CheckAccess() == false)
            {
                appCurrent.Dispatcher.BeginInvoke(action);
            }
            else
            {
                action();
            }
        }

        public void Invoke(Action action)
        {
            var appCurrent = Application.Current;

            if (appCurrent == null)
            {
                return;
            }

            if (appCurrent.Dispatcher.CheckAccess() == false)
            {
                appCurrent.Dispatcher.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
