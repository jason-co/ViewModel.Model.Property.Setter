using System;
using System.Threading.Tasks;

namespace Property.Setter.UWP.Common
{
    public interface IDispatcher
    {
        Task BeginInvoke(Action action);

        Task Invoke(Action action);
    }
}
