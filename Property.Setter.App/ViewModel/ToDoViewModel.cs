using System;
using Property.Setter.App.Common;
using Property.Setter.App.Model;

namespace Property.Setter.App.ViewModel
{
    public class ToDoViewModel : ViewModelBase
    {
        private readonly ToDo _toDo;

        public ToDoViewModel()
        {
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

        public DateTime Date
        {
            get => _toDo.Date;
            set => SetProperty(
                _toDo,
                t => t.Date,
                value);
        }
    }
}
