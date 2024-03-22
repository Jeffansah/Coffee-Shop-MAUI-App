namespace MAUIApp.Pages;

public partial class AllCoffeesPage : ContentPage
{
	private readonly AllCoffeesViewModel _allCoffeesViewModel;
	public AllCoffeesPage(AllCoffeesViewModel allCoffeesViewModel)
	{
		InitializeComponent();
		_allCoffeesViewModel = allCoffeesViewModel;
		BindingContext = _allCoffeesViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		if (_allCoffeesViewModel.FromSearch)
		{
			await Task.Delay(200);
			searchBar.Focus();
		}
    }

    void searchBar_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
	{
		if(!string.IsNullOrEmpty(e.OldTextValue) && string.IsNullOrWhiteSpace(e.NewTextValue))
		{
			_allCoffeesViewModel.SearchCoffeesCommand.Execute(null);
		}
	}
}
