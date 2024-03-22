using System;
using MAUIApp.Models;

namespace MAUIApp.Services
{
	public class CoffeeService
	{
		private readonly static IEnumerable<Coffee> _coffees = new
			List<Coffee>
		{
			new Coffee
			{
				Name="Cappucino",
				Image="cappucino",
				Price=3.49
			},new Coffee
			{
				Name="Latte",
				Image="latte",
				Price=3.49
			},
			new Coffee
			{
				Name="Flat White",
				Image="flatwhite",
				Price=3.49
			},new Coffee
			{
				Name="Americano",
				Image="americano",
				Price=2.49
			},new Coffee
			{
				Name="Mocha",
				Image="mocha",
				Price=3.25
			},new Coffee
			{
				Name="Espresso",
				Image="espresso",
				Price=2.49
			},new Coffee
			{
				Name="Machiatto",
				Image="machiatto",
				Price=3.49
			},new Coffee
			{
				Name="Iced Coffee",
				Image="icedcoffee",
				Price=3.49
			},new Coffee
			{
				Name="Turkish Coffee",
				Image="turkishcoffee",
				Price=3.49
			},
			new Coffee
			{
				Name="Cold brew",
				Image="coldbrw",
				Price=3.00
			}
		};

		public IEnumerable<Coffee> GetAllCoffees() => _coffees;

		public IEnumerable<Coffee> GetPopularCoffees(int count = 6) => _coffees
			.OrderBy(p => Guid.NewGuid()).Take(count);

		public IEnumerable<Coffee> SearchCoffees(string searchTerm) =>
			string.IsNullOrWhiteSpace(searchTerm) ? _coffees : _coffees.Where(p => p.Name
			.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
	}
}

