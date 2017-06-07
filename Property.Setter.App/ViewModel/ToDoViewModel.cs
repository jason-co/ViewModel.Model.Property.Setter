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
            set
            {
                var name = _toDo.Name;
                if (SetProperty(
                    ref name,
                    value))
                {
                    _toDo.Name = name;
                }
            }
        }

        public string Category
        {
            get => _toDo.Category;
            set
            {
                var category = _toDo.Category;
                if (SetProperty(
                    ref category,
                    value))
                {
                    _toDo.Category = category;
                }
            }
        }

        public DateTime Date
        {
            get => _toDo.Date;
            set
            {
                var date = _toDo.Date;
                if (SetProperty(
                    ref date,
                    value))
                {
                    _toDo.Date = date;
                }
            }
        }
    }
}
