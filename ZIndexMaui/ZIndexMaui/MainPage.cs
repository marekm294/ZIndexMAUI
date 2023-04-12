namespace ZIndexMaui;

using CommunityToolkit.Maui.Markup;
using System.Windows.Input;

public class MainPage : ContentPage
{
    public MainPage()
    {
        NavigationPage.SetHasNavigationBar(this, false);
        NavigateCommand = new Command(async () =>
        {
            await Navigation.PushAsync(new XamlMainPage());
        });

        Content = InitializeContent();
    }

    private View InitializeContent()
    {
        return new VerticalStackLayout()
        {
            new Dropdown()
                .ZIndex(5)
                .Height(100),
            new Button()
                .Text("Test")
                .Bind(Button.CommandProperty, nameof(NavigateCommand), source: this),
        };
    }

    public ICommand NavigateCommand { get; set; }
}