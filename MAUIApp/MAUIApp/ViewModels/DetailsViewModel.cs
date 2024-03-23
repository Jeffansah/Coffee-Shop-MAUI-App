using System;

namespace MAUIApp.ViewModels
{
	[QueryProperty(nameof(Coffee), nameof(Coffee))]
	public partial class DetailsViewModel : ObservableObject
	{ 
		private readonly CartViewModel _cartViewModel;
		public DetailsViewModel(CartViewModel cartViewModel)
		{
			_cartViewModel = cartViewModel;
		}

		[ObservableProperty]
		private Coffee _coffee;

		[RelayCommand]
		private void AddToCart()
		{
			Coffee.CartQuantity++;
            _cartViewModel.UpdateCartItemCommand.Execute(Coffee);

        }

        [RelayCommand]
		private void RemoveFromCart()
		{
			if (Coffee.CartQuantity > 0)
			{
				Coffee.CartQuantity--;
				_cartViewModel.UpdateCartItemCommand.Execute(Coffee);
			}
		}

		[RelayCommand]
		private async Task ViewCart()
		{
			if (Coffee.CartQuantity > 0)
			{
				await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
			}
			else
			{
				await Toast.Make("Please add your desired quantity to cart.", ToastDuration.Short).Show();
			}
		}
	}
}

