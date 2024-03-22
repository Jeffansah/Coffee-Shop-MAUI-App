using System;


namespace MAUIApp.ViewModels
{
	[QueryProperty(nameof(FromSearch), nameof(FromSearch))]
	public partial class AllCoffeesViewModel : ObservableObject
	{
		private readonly CoffeeService _coffeeService;
		public AllCoffeesViewModel(CoffeeService coffeeService)
		{
			_coffeeService = coffeeService;
			Coffees = new(_coffeeService.GetAllCoffees());
		}

		public ObservableCollection<Coffee> Coffees { get; set; }

		[ObservableProperty]
		private bool _fromSearch;

		[ObservableProperty]
		private bool _searching;

		[RelayCommand]
		private async Task SearchCoffees(string searchTerm)
		{
			Coffees.Clear();
			Searching = true;
			await Task.Delay(500);
			foreach (var coffee in _coffeeService.SearchCoffees(searchTerm))
			{
				Coffees.Add(coffee);
			}
			Searching = false;
		}
	}
}

