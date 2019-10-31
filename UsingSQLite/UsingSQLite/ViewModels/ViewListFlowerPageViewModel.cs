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
    public class ViewListFlowerPageViewModel : ViewModelBase
    {
        private ObservableCollection<Flower> _listFlower;

        public ObservableCollection<Flower> ListFlower
        {
            get => _listFlower;
            set => SetProperty(ref _listFlower , value);
        }
        public ViewListFlowerPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            AddFlowerCommand = new DelegateCommand(AddFlowerCommandExecute);
            ListFlower = new ObservableCollection<Flower>();
            ListFlower = new ObservableCollection<Flower>(App.Database.GetListFlower().Result);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters != null && parameters.ContainsKey("selectFlowerType"))
            {
                var selectFlowerType = (FlowerType)parameters["selectFlowerType"];
                ListFlower = new ObservableCollection<Flower>(App.Database.GetListFlowerByFlowerType(selectFlowerType.FlowerTypeID).Result);
            }
        }

        public ICommand AddFlowerCommand { get; }

        public void AddFlowerCommandExecute()
        {
            NavigationService.NavigateAsync("AddFlowerPage");
        }

    }
}
