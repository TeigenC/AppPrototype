using System.Threading.Tasks;

namespace Bloom.Pages;

public partial class LoadingScreen : ContentPage
{
	public LoadingScreen()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		await Task.Delay(3000);

		Application.Current.MainPage = new NavigationPage(new MainPage());
	}
}