using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Property.Setter.App.Common
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region private fields

        private event PropertyChangedEventHandler _propertyChanged;

        #endregion

        #region public properties

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if (!EventHandlerExtensions.IsRegistered(_propertyChanged, value))
                {
                    _propertyChanged += value;
                }
                else
                {
                    if (Debugger.IsAttached)
                    {
                        // For the developer, for some reason you are hooking into the same PropertyChanged event with the same delegate multiple times.
                        //  The 'IsRegistered' check avoided hooking into this delegate, but you should be aware that your logic is doing something unnecessary.
                        Debugger.Break();
                    }
                }
            }
            remove { _propertyChanged -= value; }
        }

        private static IDispatcher _dispatcher;
        public static IDispatcher Dispatcher
        {
            get => _dispatcher ?? (_dispatcher = new ApplicationDispatcher());
            set => _dispatcher = value;
        }

        #endregion

        #region protected methods

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value) || string.IsNullOrEmpty(propertyName))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void SetProperty<T>(ref T refValue, T value, params Expression<Func<object>>[] propertyExprs)
        {
            if (Equals(value, refValue))
            {
                return;
            }
            refValue = value;
            foreach (var propertyExpr in propertyExprs)
            {
                OnPropertyChanged(propertyExpr);
            }
        }

        protected bool SetProperty<TClassType, TValueType>(TClassType classObj, Expression<Func<TClassType, TValueType>> outExpr, TValueType value, params Expression<Func<object>>[] propertyExprs)
        {
            var expr = (MemberExpression)outExpr.Body;
            var prop = (PropertyInfo)expr.Member;
            var refValue = prop.GetValue(classObj, null);

            if (Equals(value, refValue))
            {
                return false;
            }
            prop.SetValue(classObj, value, null);
            foreach (var propertyExpr in propertyExprs)
            {
                OnPropertyChanged(propertyExpr);
            }

            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = _propertyChanged;

            eventHandler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged<TPropertyType>(Expression<Func<TPropertyType>> propertyExpr)
        {
            string propertyName = GetPropertySymbol(propertyExpr);

            _propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertiesChanged(params Expression<Func<object>>[] propertyExprs)
        {
            foreach (var propertyExpr in propertyExprs)
            {
                OnPropertyChanged(propertyExpr);
            }
        }

        protected string GetPropertySymbol<T>(Expression<Func<T>> expr)
        {
            Expression exprBody = expr.Body;
            if (exprBody is UnaryExpression)
            {
                exprBody = ((UnaryExpression)expr.Body).Operand;
            }

            return ((MemberExpression)exprBody).Member.Name;
        }

        protected void BeginUpdateView(Action action)
        {
            Dispatcher.BeginInvoke(action);
        }

        protected void UpdateView(Action action)
        {
            Dispatcher.Invoke(action);
        }

        #endregion
    }
}
