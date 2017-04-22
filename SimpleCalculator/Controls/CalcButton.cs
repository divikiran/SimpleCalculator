using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleCalculator
{
	public class CalcButton : StackLayout
	{
		public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(CalcButton), null);
		public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandProperty), typeof(object), typeof(CalcButton), null);
		public static readonly BindableProperty DisplayTextProperty = BindableProperty.Create(nameof(DisplayText), typeof(string), typeof(CalcButton), string.Empty, propertyChanged: MyTextChanged);
		public static readonly BindableProperty LabelColorProperty = BindableProperty.Create(nameof(LabelColor), typeof(Color), typeof(CalcButton), default(Color), propertyChanged: LabelColorChanged);

		public Color LabelColor
		{
			get { return (Color)GetValue(LabelColorProperty); }
			set { SetValue(LabelColorProperty, value); }
		}

		static void LabelColorChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var color = (Color)newValue;
			if (color != null)
			{ 
				((CalcButton)bindable).LabelColorChanged(color); 
			}
		}

		void LabelColorChanged(Color color)
		{
			Device.BeginInvokeOnMainThread(() => { this.DisplayLabel.BackgroundColor = color; this.DisplayLabel.TextColor = Color.White; });
		}

		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		public object CommandParameter
		{
			get { return GetValue(CommandParameterProperty); }
			set { SetValue(CommandParameterProperty, value); }
		}

		public string DisplayText
		{
			get
			{
				return (string)GetValue(DisplayTextProperty);
			}
			set
			{
				SetValue(DisplayTextProperty, value);
			}
		}

		public Label DisplayLabel
		{
			get;
			set;
		} = new Label() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center };

		public static void MyTextChanged(BindableObject bindable, object oldValue, object newValue)
		{
			((CalcButton)bindable).TextChanged(newValue.ToString());
		}

		public void TextChanged(string newText)
		{
			Device.BeginInvokeOnMainThread(() => this.DisplayLabel.Text = newText);
		}

		public CalcButton()
		{
			DisplayLabel.BackgroundColor = Color.FromHex("#C5C6CA");

			DisplayLabel.FontSize = 40;

			this.HorizontalOptions = LayoutOptions.FillAndExpand;
			this.VerticalOptions = LayoutOptions.FillAndExpand;
			this.Children.Add(DisplayLabel);

			var gestureRecognizer = new TapGestureRecognizer();

			gestureRecognizer.Tapped += (s, e) =>
			{
				if (Command != null && Command.CanExecute(CommandParameter))
				{
					Command.Execute(CommandParameter);
				}
			};
			this.GestureRecognizers.Add(gestureRecognizer);
		}
	}
}
