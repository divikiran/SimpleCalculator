using System;
using SimpleCalculator.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
//[assembly: ExportRenderer(typeof(Label), typeof(CustomLabelRenderer))]
namespace SimpleCalculator.iOS
{
	public class CustomLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Label> e)
		{
			base.OnElementChanged(e);

			var label = Control as UILabel;
			if (label != null)
			{
				label.AdjustsFontSizeToFitWidth = true;
				label.Lines = 1;
				label.BaselineAdjustment = UIBaselineAdjustment.AlignCenters;
				label.LineBreakMode = UILineBreakMode.Clip;
			}
		}
	}
}
