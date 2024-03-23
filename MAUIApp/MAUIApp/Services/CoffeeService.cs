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
    Name="Cappuccino",
    Image="cappucino",
    Price=3.49,
    Description="A cherished morning ritual, the cappuccino is a harmonious blend of rich espresso and steamed milk foam that creates a luxurious treat for the senses. Each sip offers a creamy texture with deep coffee undertones."
},
new Coffee
{
    Name="Latte",
    Image="latte",
    Price=3.49,
    Description="The latte reigns supreme as a silky beverage, where gently poured milk creates a delicate artwork atop the robust espresso base, making each cup a masterpiece of flavor and design."
},
new Coffee
{
    Name="Flat White",
    Image="flatwhite",
    Price=3.49,
    Description="Originating from the shores of Australia and New Zealand, the flat white boasts a strong coffee presence softened by the velvety layer of microfoam, delivering a refined coffee experience."
},
new Coffee
{
    Name="Americano",
    Image="americano",
    Price=2.49,
    Description="The Americano captures the essence of an espresso diluted in hot water, offering a lighter body but maintaining a deep, invigorating flavor profile that's both accessible and satisfying."
},
new Coffee
{
    Name="Mocha",
    Image="mocha",
    Price=3.25,
    Description="A beverage that satisfies the coffee aficionado and the chocolate lover alike, the mocha is a decadent fusion of cocoa and espresso, crowned with whipped cream for a luxurious indulgence."
},
new Coffee
{
    Name="Espresso",
    Image="espresso",
    Price=2.49,
    Description="Espresso, the quintessential Italian brew, is a concentrated symphony of coffee, with a rich crema that speaks of its supreme quality and a taste profile that's as intense as it is beloved."
},
new Coffee
{
    Name="Machiatto",
    Image="machiatto",
    Price=3.49,
    Description="A dash of frothy milk atop a shot of dark, concentrated espresso, the macchiato offers a stark yet harmonious contrast that is both invigorating and delightfully complex."
},
new Coffee
{
    Name="Iced Coffee",
    Image="icedcoffee",
    Price=3.49,
    Description="Perfect for a hot day, iced coffee provides a refreshing pause. This chilled concoction is more than just coffee over ice – it's a cool escape that energizes and reinvigorates."
},
new Coffee
{
    Name="Turkish Coffee",
    Image="turkishcoffee",
    Price=3.49,
    Description="Steeped in tradition, Turkish coffee is meticulously prepared using finely ground beans to create a potent and fragrant cup that's often shared among friends and accompanied by a sweet treat."
},
new Coffee
{
    Name="Cold Brew",
    Image="coldbrew",
    Price=3.00,
    Description="Cold brew coffee, known for its smooth profile and subtle sweetness, is the result of patient brewing in cold water, resulting in a coffee that's refreshing and gentle on the palate."
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

