using Bloom.Pages;

namespace Bloom;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCalendarButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CalendarPage());
    }

    private async void OnInfoButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InfoPage());
    }
}
