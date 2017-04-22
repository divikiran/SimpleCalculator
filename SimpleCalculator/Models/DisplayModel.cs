using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleCalculator
{
	public class DisplayModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName]string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		string displayText;

		public string DisplayText
		{
			get
			{
				return displayText;
			}

			set
			{
				displayText = value;
				OnPropertyChanged();
			}
		}

		public DisplayModel()
		{
		}
	}
}
