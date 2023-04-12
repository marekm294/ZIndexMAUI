namespace ZIndexMaui;

using CommunityToolkit.Maui.Alerts;
using System.Windows.Input;

public partial class XamlDropdown : ContentView
{
    public XamlDropdown()
    {
        ItemSelectedCommand = new Command(() =>
        {
            Toast.Make("Item changed", CommunityToolkit.Maui.Core.ToastDuration.Short)
                .Show();
        });

        OpenDropDownCommand = new Command(() =>
        {
            IsDropdownOpen = !IsDropdownOpen;
            OnPropertyChanged(nameof(IsDropdownOpen));
        });

        InitializeComponent();
    }

    public ExampleEnum[] Source => Enum
        .GetValues<ExampleEnum>()
        .ToArray();

    public bool IsDropdownOpen { get; set; }

    public ICommand ItemSelectedCommand { get; set; }

    public ICommand OpenDropDownCommand { get; set; }
}