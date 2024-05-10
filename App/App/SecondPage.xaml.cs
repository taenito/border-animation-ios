namespace App;

public partial class SecondPage : ContentPage
{
    SecondPageModel pageModel;

	public SecondPage()
	{
		InitializeComponent();
        BindingContext = pageModel = new SecondPageModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = pageModel.OnAppearing();
    }
}