using System;
namespace MAUIApp.ViewModels
{
	public partial class CartViewModel : ObservableObject
	{
		public event EventHandler<Coffee> CartItemRemoved;
		public event EventHandler CartCleared;
		public event EventHandler<Coffee> CartItemUpdated;

		public ObservableCollection<Coffee> Items { get; set; } = new();

		[ObservableProperty]
		private double _totalAmount;

		private void RecalculateTotalAmount() => TotalAmount = Items.Sum(i => i.Amount);

		[RelayCommand]
		private void UpdateCartItem(Coffee coffee)
		{
			var Item = Items.FirstOrDefault(i => i.Name == coffee.Name);
			if(Item is not null)
			{
				Item.CartQuantity = coffee.CartQuantity;
			}
			else
			{
				Items.Add(coffee.Clone());
			}
			RecalculateTotalAmount();
		}

		[RelayCommand]
		private async void RemoveCartItem(string name)
		{
			var item = Items.FirstOrDefault(i => i.Name == name);
			if(item is not null)
			{
				Items.Remove(item);
				RecalculateTotalAmount();

				CartItemRemoved?.Invoke(this, item);

				var snackbarOptions = new SnackbarOptions
				{
					CornerRadius = 10
				};

				await Snackbar.Make($"'{item.Name}' removed from cart", () =>
				{
					Items.Add(item);
					RecalculateTotalAmount();
					CartItemUpdated?.Invoke(this, item);
				}, "Undo", TimeSpan.FromSeconds(5), snackbarOptions).Show();
			}
		}

		[RelayCommand]
		private async void ClearCart()
		{
			if(await Shell.Current.DisplayAlert("Confirm clear", "Are you sure you want to clear the cart?", "Yes", "No"))
			{
                Items.Clear();
                RecalculateTotalAmount();
				CartCleared?.Invoke(this, EventArgs.Empty);
				await Toast.Make("Cart cleared", ToastDuration.Short).Show();
            }
		}

		[RelayCommand]
		private async Task PlaceOrder()
		{
            Items.Clear();
            RecalculateTotalAmount();
			//Go to Checkout
        }
	}
}

