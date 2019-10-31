using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace UsingSQLite.ViewModels
{
	public class ViewListFlowerPageViewModel : ViewModelBase
	{
        public ViewListFlowerPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            AddFlowerCommand = new DelegateCommand(AddFlowerCommandExecute);
        }

        public ICommand AddFlowerCommand { get; }

        public void AddFlowerCommandExecute()
        {
            NavigationService.NavigateAsync("AddFlowerPage");
        }

    }
}
