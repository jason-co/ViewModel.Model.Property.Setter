using System;

namespace Property.Setter.App.Common
{
    public class RelayCommandEventArgs : EventArgs
    {
        public object Parameter { get; private set; }

        public RelayCommandEventArgs(object parameter)
        {
            Parameter = parameter;
        }
    }
}