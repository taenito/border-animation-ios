namespace App
{
    public partial class App : Application
    {
        public static NavigationPage? NavigationPage { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = NavigationPage = new NavigationPage(new MainPage());
        }
    }
}
