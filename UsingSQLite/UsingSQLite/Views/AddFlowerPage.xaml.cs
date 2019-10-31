using Xamarin.Forms;

namespace UsingSQLite.Views
{
    public partial class AddFlowerPage : ContentPage
    {
        public static AddFlowerPage Instance { get; private set; }
        public AddFlowerPage()
        {
            InitializeComponent();
            Instance = this;
        }
        public void ShowAlert()
        {
            DisplayAlert("Thông báo", "Thêm hoa thành công", "OK");
        }
    }
}
