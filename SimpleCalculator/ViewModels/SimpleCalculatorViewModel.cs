using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleCalculator
{
	public class SimpleCalculatorViewModel : INotifyPropertyChanged
	{
		string result = "0";

		public string Result
		{
			get
			{
				return result;
			}

			set
			{
				result = value;
				OnPropertyChanged();
			}
		}

		string userInputs;
		public string UserInputs
		{
			get
			{
				return userInputs;
			}

			set
			{
				userInputs = value;
				OnPropertyChanged();
			}
		}

		public SimpleCalculatorViewModel()
		{

		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName]string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		}
		ICommand _clearCommand;

		public ICommand ClearCommand
		{
			get
			{
				return _clearCommand ?? (_clearCommand = new Command(ClearCommandAction));
			}
		}

		void ClearCommandAction(object obj)
		{
			//throw new NotImplementedException();
			Result = "0";
			UserInputs = string.Empty;
			currentNumber = 0;
			recentOperator = string.Empty;
		}

		ICommand numberCommand;
		public ICommand NumberCommand
		{
			get
			{
				return numberCommand ?? (numberCommand = new Command(NumberCommandAction));
			}
		}

		int currentNumber = 0;
		string recentOperator = string.Empty;
		bool numberPressed = false;
		void NumberCommandAction(object obj)
		{
			var number = Convert.ToInt32(obj);
			if (number != null)
			{
				UserInputs += number;
				if (numberPressed)
				{
					currentNumber = (currentNumber * 10) + number;
				}
				else
				{
					currentNumber = number;
				}
			}
			numberPressed = true;
		}

		Command operatorCommand;
		public Command OperatorCommand
		{
			get
			{
				return operatorCommand ?? (operatorCommand = new Command(OperatorCommandAction));
			}
		}

		void OperatorCommandAction(object obj)
		{
			var operatorText = obj as string;

			if (operatorText == "=")
			{
				operatorText = recentOperator;
			}
			else
			{
				var lastChar = UserInputs.Substring(UserInputs.Length - 1, 1);
				var number = 0;
				var isNumbber = int.TryParse(lastChar, out number);
				if (isNumbber)
				{
					UserInputs += operatorText;
				}

			}

			if (!string.IsNullOrEmpty(operatorText))
			{
				switch (operatorText)
				{
					case "+":
						Result = (Convert.ToInt32(Result) + currentNumber).ToString();
						currentNumber = 0;
						break;
					case "-":
						Result = (Convert.ToInt32(Result) - currentNumber).ToString();
						currentNumber = 0;
						break;
					case "*":
						if (currentNumber > 0)
						{
							if (Result == "0")
							{
								Result = "1";
							}
							Result = (Convert.ToInt32(Result) * currentNumber).ToString();
							currentNumber = 0;
						}
						break;
					case "/":
						if (currentNumber > 0)
						{
							Result = (Convert.ToInt32(Result) / currentNumber).ToString();
							//currentNumber = 0;
						}
						break;
					case "+-":
						Result = (Convert.ToInt32(Result) * -1).ToString();
						break;
					default:
						break;
				}
				//currentNumber = 0;
			}
			recentOperator = operatorText;
			numberPressed = false;
		}

	}
}
