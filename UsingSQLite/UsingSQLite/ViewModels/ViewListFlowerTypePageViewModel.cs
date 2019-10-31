using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using UsingSQLite.Models;

namespace UsingSQLite.ViewModels
{
    public class ViewListFlowerTypePageViewModel : ViewModelBase
    {
        public static ViewListFlowerTypePageViewModel Instance { get; private set; }
        public ObservableCollection<FlowerType> ListFlowerType { get; set; }

        private bool _isVisible;
        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible , value);
        }
        public ViewListFlowerTypePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            ListFlowerType = new ObservableCollection<FlowerType>(App.Database.GetListFlowerType().Result);
            if (ListFlowerType.Count == 0)
                IsVisible = true;
            else
                IsVisible = false;
            AddFlowerTypeCommand = new DelegateCommand(AddFlowerTypeCommandExe);
            Instance = this;
        }

        public ICommand AddFlowerTypeCommand { get; }

        public void AddFlowerTypeCommandExe()
        {
            NavigationService.NavigateAsync("AddFlowerTypePage");
        }

        public void SelectFlowerType(FlowerType flowerType)
        {
            
        }
    }
}
