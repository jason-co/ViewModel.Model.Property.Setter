﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using Property.Setter.UWP.Common;

namespace Property.Setter.UWP.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            ToDoItems = new ObservableCollection<ToDoViewModel>();
        }

        public ObservableCollection<ToDoViewModel> ToDoItems { get; }

        private bool _openCreateDialog;
        public bool OpenCreateDialog
        {
            get => _openCreateDialog;
            set => SetProperty(
                ref _openCreateDialog,
                value);
        }

        private ToDoViewModel _createToDo;
        public ToDoViewModel CreateToDo
        {
            get => _createToDo;
            set => SetProperty(
                ref _createToDo,
                value);
        }

        #region Open Create Dialog Command

        private RelayCommand _openCreateDialogCommand;

        public ICommand OpenCreateDialogCommand => RelayCommand.CreateCommand(
            ref _openCreateDialogCommand,
            OpenCreateDialogExecute);

        private void OpenCreateDialogExecute()
        {
            CreateToDo = new ToDoViewModel(item => ToDoItems.Remove(item));

            OpenCreateDialog = true;
        }

        #endregion

        #region Close Create Dialog Command

        private RelayCommand<bool> _closeCreateDialogCommand;

        public ICommand CloseCreateDialogCommand => RelayCommand.CreateCommand(
            ref _closeCreateDialogCommand,
            CloseCreateDialogExecute);

        private void CloseCreateDialogExecute(bool isSaving)
        {
            if (isSaving)
            {
                ToDoItems.Add(CreateToDo);
            }

            OpenCreateDialog = false;
        }

        #endregion
    }
}
