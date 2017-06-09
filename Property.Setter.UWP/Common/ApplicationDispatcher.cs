using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace Property.Setter.UWP.Common
{
    public class ApplicationDispatcher : IDispatcher
    {
        public async Task BeginInvoke(Action action)
        {
            var windowCurrent = Window.Current;

            if (windowCurrent == null)
            {
                return;
            }

            if (windowCurrent.Dispatcher.HasThreadAccess)
            {
                action();
            }
            else
            {
                await Window.Current.Dispatcher.RunAsync(
                    CoreDispatcherPriority.Normal,
                    () => action());
            }
        }

        public async Task Invoke(Action action)
        {
            var windowCurrent = Window.Current;

            if (windowCurrent == null)
            {
                return;
            }

            if (windowCurrent.Dispatcher.HasThreadAccess)
            {
                action();
            }
            else
            {
                await Window.Current.Dispatcher.RunAsync(
                    CoreDispatcherPriority.Normal,
                    () => action());
            }
        }
    }
}
