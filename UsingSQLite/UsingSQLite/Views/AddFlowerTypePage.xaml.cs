using Xamarin.Forms;

namespace UsingSQLite.Views
{
    public partial class AddFlowerTypePage : ContentPage
    {
        public static AddFlowerTypePage Instance { get; private set; }
        public AddFlowerTypePage()
        {
            InitializeComponent();
            Instance = this;
        }

        public void ShowAlert()
        {
            DisplayAlert("Thông báo", "Thêm loại hoa thành công", "OK");
        }
    }
}
