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
	}
}

