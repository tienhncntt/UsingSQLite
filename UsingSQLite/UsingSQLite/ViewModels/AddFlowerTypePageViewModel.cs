using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using UsingSQLite.Models;
using UsingSQLite.Views;

namespace UsingSQLite.ViewModels
{
    public class AddFlowerTypePageViewModel : ViewModelBase
    {
        private string _flowerTypeName;

        public string FlowerTypeName
        {
            get => _flowerTypeName;
            set => SetProperty(ref _flowerTypeName , value);
        }

        public AddFlowerTypePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            ConfirmCommand = new DelegateCommand(ConfirmCommandExecute);
        }

        public ICommand ConfirmCommand { get; }
        public async void ConfirmCommandExecute()
        {
            if (FlowerTypeName == null)
            {
                return;
            }
            var flowerType = new FlowerType()
            {
                FlowerTypeName = FlowerTypeName
            };
            await App.Database.InsertFlowerType(flowerType);
            AddFlowerTypePage.Instance.ShowAlert();
            await NavigationService.GoBackToRootAsync();
        }
    }
}
