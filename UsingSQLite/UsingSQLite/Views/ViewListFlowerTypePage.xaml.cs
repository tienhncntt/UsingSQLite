using UsingSQLite.Models;
using UsingSQLite.ViewModels;
using Xamarin.Forms;

namespace UsingSQLite.Views
{
    public partial class ViewListFlowerTypePage : ContentPage
    {
        public ViewListFlowerTypePage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedFlowerType = sender as FlowerType;
            ViewListFlowerTypePageViewModel.Instance.SelectFlowerType(selectedFlowerType);
        }
    }
}
