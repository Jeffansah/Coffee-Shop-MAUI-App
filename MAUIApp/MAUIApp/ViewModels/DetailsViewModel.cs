using System;

namespace MAUIApp.ViewModels
{
	[QueryProperty(nameof(Coffee), nameof(Coffee))]
	public partial class DetailsViewModel : ObservableObject
	{
		public DetailsViewModel()
		{
		}

		[ObservableProperty]
		private Coffee _coffee;

		[RelayCommand]
		private void AddToCart()
		{
			Coffee.CartQuantity++;
		}

		[RelayCommand]
		private void RemoveFromCart()
		{
			if (Coffee.CartQuantity > 0)
			{
				Coffee.CartQuantity--;
			}
		}

		[RelayCommand]
		private async Task ViewCart()
		{
			if (Coffee.CartQuantity > 0)
			{
				// go to cart
			}
			else
			{
				await Toast.Make("Please add your desired quantity to cart.", ToastDuration.Short).Show();
			}
		}
	}
}

