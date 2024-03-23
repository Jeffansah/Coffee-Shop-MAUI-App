using System;

namespace MAUIApp.ViewModels
{
	[QueryProperty(nameof(Coffee), nameof(Coffee))]
	public partial class DetailsViewModel : ObservableObject, IDisposable
	{
		private readonly CartViewModel _cartViewModel;
		public DetailsViewModel(CartViewModel cartViewModel)
		{
			_cartViewModel = cartViewModel;

			_cartViewModel.CartCleared += OnCartCleared;

			_cartViewModel.CartItemRemoved += OnCartItemRemoved;

			_cartViewModel.CartItemUpdated += OnCartItemUpdated;
		}

		private void OnCartCleared(object? sender, EventArgs e) => Coffee.CartQuantity = 0;

		private void OnCartItemRemoved(object? sender, Coffee c) => OnCartItemChanged(c, 0);

		private void OnCartItemUpdated(object? sender, Coffee c) => OnCartItemChanged(c, c.CartQuantity);

		private void OnCartItemChanged(Coffee c, int quantity)
		{
			if (c.Name == Coffee.Name)
			{
				Coffee.CartQuantity = quantity;
			}
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

		public void Dispose()
		{
            _cartViewModel.CartCleared -= OnCartCleared;

            _cartViewModel.CartItemRemoved -= OnCartItemRemoved;

            _cartViewModel.CartItemUpdated -= OnCartItemUpdated;
        }
	}
}

