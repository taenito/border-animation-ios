using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace App;

public partial class SecondPageModel : ObservableObject
{
    [ObservableProperty]
    bool _isLoading = true;

    [ObservableProperty]
    ItemViewModel? _item;

    public async Task OnAppearing()
    {
        await Task.Delay(1000);

        Item = new()
        {
            ShowError = true,
            ErrorText =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."

        };

        IsLoading = !IsLoading;
    }
}