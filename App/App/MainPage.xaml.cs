namespace App;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    void Button_Clicked(object sender, EventArgs e) {
        Container1.HorizontalOptions = Container1.HorizontalOptions.Alignment == LayoutOptions.Fill.Alignment ? LayoutOptions.Start : LayoutOptions.Fill;
    }

    void Button2_Clicked(object sender, EventArgs e)
    {
        FloatingActionButton.IsExtended = !FloatingActionButton.IsExtended;
    }

    void Button3_Clicked(object sender, EventArgs e) {
        _ = App.NavigationPage?.PushAsync(new SecondPage());
    }
}