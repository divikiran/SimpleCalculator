using Xamarin.Forms;

namespace SimpleCalculator
{
	public partial class SimpleCalculatorPage : ContentPage
	{
		public SimpleCalculatorPage()
		{
			InitializeComponent();
			BindingContext = new SimpleCalculatorViewModel();

		}
	}
}
