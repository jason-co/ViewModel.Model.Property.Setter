using System;
using System.Windows.Input;
using Property.Setter.UWP.Common;
using Property.Setter.UWP.Model;

namespace Property.Setter.UWP.ViewModel
{
    public class ToDoViewModel : ViewModelBase
    {
        private readonly Action<ToDoViewModel> _deleteItemAction;

        private readonly ToDo _toDo;

        public ToDoViewModel(Action<ToDoViewModel> deleteItemAction)
        {
            _deleteItemAction = deleteItemAction;
            _toDo = new ToDo
            {
                Date = DateTime.UtcNow
            };
        }

        public string Name
        {
            get => _toDo.Name;
            set => SetProperty(
                _toDo,
                t => t.Name,
                value);
        }

        public string Category
        {
            get => _toDo.Category;
            set => SetProperty(
                _toDo,
                t => t.Category,
                value);
        }

        public DateTimeOffset Date
        {
            get => _toDo.Date;
            set => SetProperty(
                _toDo,
                t => t.Date,
                value);
        }

        #region Delete Item Command

        private RelayCommand _deleteItemCommand;

        public ICommand DeleteItemCommand => RelayCommand.CreateCommand(
            ref _deleteItemCommand,
            DeleteItemExecute);

        private void DeleteItemExecute()
        {
            _deleteItemAction(this);
        }

        #endregion
    }
}
