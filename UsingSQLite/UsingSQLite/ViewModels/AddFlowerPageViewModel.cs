using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using UsingSQLite.Models;
using UsingSQLite.Views;

namespace UsingSQLite.ViewModels
{
    public class AddFlowerPageViewModel : ViewModelBase
    {
        private ObservableCollection<FlowerType> _listFlowerType;
        public ObservableCollection<FlowerType> ListFlowerType
        {
            get => _listFlowerType;
            set => SetProperty(ref _listFlowerType, value);
        }

        private FlowerType _selectedFlower;
        public FlowerType SelectedFlower
        {
            get => _selectedFlower;
            set => SetProperty(ref _selectedFlower , value);
        }

        private string _flowerName;

        public string FlowerName
        {
            get => _flowerName;
            set => SetProperty(ref _flowerName, value);
        }

        private string _flowerImage;

        public string FlowerImage
        {
            get => _flowerImage;
            set => SetProperty(ref _flowerImage, value);
        }

        private string _price;

        public string Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        private string _decription;
        

        public string Decription
        {
            get => _decription;
            set => SetProperty(ref _decription, value);
        }
        public AddFlowerPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            AddFlowerCommand = new DelegateCommand(AddFlowerCommandExecute);

            var _listFlowerType = App.Database.GetListFlowerType().Result;

            ListFlowerType = new ObservableCollection<FlowerType>(_listFlowerType);

        }

        public ICommand AddFlowerCommand { get; }

        public async void AddFlowerCommandExecute()
        {
            var flower = new Flower()
            {
                FlowerTypeID = SelectedFlower.FlowerTypeID,
                FlowerName = FlowerName,
                FlowerImage = "flower.jpg",
                Decription = Decription,
                Price = Convert.ToInt32(Price)
            };
            await App.Database.InsertFlower(flower);

            AddFlowerPage.Instance.ShowAlert();

            await NavigationService.GoBackToRootAsync();
        }
    }
}
