using System;
using Xamarin.Forms;

namespace SimpleCalculator
{
	public class ResultStack : StackLayout
	{
		public Label UserInputs
		{
			get;
			set;
		} = new Label() { FontSize = 25, Text = "User Inputs", HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, VerticalTextAlignment = TextAlignment.End, HorizontalTextAlignment = TextAlignment.End };


		public Label Result
		{
			get;
			set;
		} = new Label() { FontSize = 55, Text = "Result", HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.StartAndExpand, VerticalTextAlignment = TextAlignment.End, HorizontalTextAlignment = TextAlignment.End };


		public ResultStack()
		{

			Result.SetBinding(Label.TextProperty,"Result");
			UserInputs.SetBinding(Label.TextProperty, "UserInputs");
			Result.TextColor = UserInputs.TextColor = Color.White;
			this.BackgroundColor = Color.Black;
			Padding = new Thickness(10, 20, 10, 20);
			VerticalOptions = LayoutOptions.FillAndExpand;
			HorizontalOptions = LayoutOptions.FillAndExpand;
			var stackLayout = new StackLayout() { HorizontalOptions = LayoutOptions.EndAndExpand, VerticalOptions = LayoutOptions.EndAndExpand };

			stackLayout.Children.Add(UserInputs);
			stackLayout.Children.Add(Result);
			this.Children.Add(stackLayout);
		}
	}
}
