namespace MAUIApp.Pages;

public partial class DetailsPage : ContentPage
{
	private readonly DetailsViewModel _detailsViewModel;
	public DetailsPage(DetailsViewModel detailsViewModel)
	{
		_detailsViewModel = detailsViewModel;
		InitializeComponent();
		BindingContext = _detailsViewModel;
	}

	async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

    
}
