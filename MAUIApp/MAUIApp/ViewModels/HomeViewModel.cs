using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MAUIApp.Models;
using MAUIApp.Services;

namespace MAUIApp.ViewModels
{
	public partial class HomeViewModel : ObservableObject
	{
		private readonly CoffeeService _coffeeService;
		public HomeViewModel(CoffeeService coffeeService)
		{
			_coffeeService = coffeeService;
			Coffees = new(_coffeeService.GetPopularCoffees());
		}

		public ObservableCollection<Coffee> Coffees { get; set; }

		[RelayCommand]
		private async Task GoToAllCoffeesPage(bool fromSearch = false)
		{
			var parameters = new Dictionary<string, object>
			{
				[nameof(AllCoffeesViewModel.FromSearch)] = fromSearch
			};
			await Shell.Current.GoToAsync(nameof(AllCoffeesPage), animate: true, parameters);
		}

		[RelayCommand]
		private async Task GoToDetailsPage(Coffee coffee)
		{
			var parameters = new Dictionary<string, object>
			{
				[nameof(DetailsViewModel.Coffee)] = coffee
			};
			await Shell.Current.GoToAsync(nameof(DetailsPage), animate: true, parameters);

		}
	}
}

