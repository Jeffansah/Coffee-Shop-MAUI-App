using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUIApp.Models
{
	public partial class Coffee : ObservableObject
	{
		public string Name { get; set; }
		public string Image { get; set; }
		public double Price { get; set; }

		[ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
		private int _cartQuantity;

		public double Amount => CartQuantity * Price;

		public Coffee Clone() => MemberwiseClone() as Coffee;
    }
}

