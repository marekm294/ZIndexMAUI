using CommunityToolkit.Maui.Markup;
using ZIndex;

public class MainPage : ContentPage
{
    public MainPage()
    {
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
        };
    }
}