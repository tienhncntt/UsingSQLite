using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace UsingSQLite.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Trang chủ";
            ViewListFlowerTypeCommand = new DelegateCommand(ViewListFlowerTypeCommandExecute);
            ViewListFlowerCommand = new DelegateCommand(ViewListFlowerCommandExecute);
            AddFlowerTypeCommand = new DelegateCommand(AddFlowerTypeCommandExecute);
            AddFlowerCommand = new DelegateCommand(AddFlowerCommandExecute);
        }

        public ICommand ViewListFlowerTypeCommand { get; }

        public void ViewListFlowerTypeCommandExecute()
        {
            NavigationService.NavigateAsync("ViewListFlowerTypePage");
        }

        public ICommand ViewListFlowerCommand { get; }

        public void ViewListFlowerCommandExecute()
        {
            NavigationService.NavigateAsync("ViewListFlowerPage");
        }

        public ICommand AddFlowerTypeCommand { get; }

        public void AddFlowerTypeCommandExecute()
        {
            NavigationService.NavigateAsync("AddFlowerTypePage");
        }

        public ICommand AddFlowerCommand { get; }

        public void AddFlowerCommandExecute()
        {
            NavigationService.NavigateAsync("AddFlowerPage");
        }

    }
}
