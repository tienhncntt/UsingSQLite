using Prism;
using Prism.Ioc;
using System;
using System.IO;
using UsingSQLite.Services;
using UsingSQLite.ViewModels;
using UsingSQLite.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UsingSQLite
{
    public partial class App
    {
        static SQLiteService _database;
        public static SQLiteService Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new SQLiteService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.db3"));
                }
                return _database;
            }
        }
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewListFlowerTypePage, ViewListFlowerTypePageViewModel>();
            containerRegistry.RegisterForNavigation<ViewListFlowerPage, ViewListFlowerPageViewModel>();
            containerRegistry.RegisterForNavigation<AddFlowerTypePage, AddFlowerTypePageViewModel>();
            containerRegistry.RegisterForNavigation<AddFlowerPage, AddFlowerPageViewModel>();
        }
    }
}
