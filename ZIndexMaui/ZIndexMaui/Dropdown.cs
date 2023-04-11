using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Markup;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ZIndex;

internal class Dropdown : ContentView
{

    public static readonly BindableProperty IsDropDownVisibleProperty =
            BindableProperty.Create(nameof(IsDropDownVisible), typeof(bool), typeof(Dropdown));

    public bool IsDropDownVisible
    {
        get => (bool)GetValue(IsDropDownVisibleProperty);
        set => SetValue(IsDropDownVisibleProperty, value);
    }


    public Dropdown()
    {
        ItemSelectedCommand = new Command(() =>
        {
            Toast
                .Make("Item changed", CommunityToolkit.Maui.Core.ToastDuration.Short)
                .Show();
        });

        OpenDropDownCommand = new Command(() =>
        {
            IsDropdownOpen = !IsDropdownOpen;
            OnPropertyChanged(nameof(IsDropdownOpen));
        });

        Content = InitializeContent();
    }

    private View InitializeContent()
    {
        return new VerticalStackLayout()
        {
            Children =
            {
                new Button()
                    .Text("Open/Close")
                    .Bind(Button.CommandProperty, nameof(OpenDropDownCommand), source: this),
                new CollectionView(){ SelectionMode = SelectionMode.Single}
                    .Bind(CollectionView.IsVisibleProperty, nameof(IsDropdownOpen), source: this)
                    .Bind(CollectionView.ItemsSourceProperty, nameof(Source), source: this)
                    .Bind(CollectionView.SelectionChangedCommandProperty, nameof(ItemSelectedCommand), source: this)
                    .ZIndex(5)
            }
        };
    }

    public ExampleEnum[] Source => Enum
        .GetValues<ExampleEnum>()
        .ToArray();

    public bool IsDropdownOpen { get; set; }

    public ICommand ItemSelectedCommand { get; set; }

    public ICommand OpenDropDownCommand { get; set; }
}

public enum ExampleEnum
{
    One,
    Two,
    Three,
    Four,
}