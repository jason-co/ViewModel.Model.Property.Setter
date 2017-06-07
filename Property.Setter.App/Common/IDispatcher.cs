using System;

namespace Property.Setter.App.Common
{
    public interface IDispatcher
    {
        void BeginInvoke(Action action);

        void Invoke(Action action);
    }
}
