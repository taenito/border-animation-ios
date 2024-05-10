using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace App;

public partial class ItemViewModel : ObservableObject
{
    [ObservableProperty]
    bool _showError;

    [ObservableProperty]
    string? _errorText;
}