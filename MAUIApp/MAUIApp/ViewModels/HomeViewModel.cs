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
	}
}

