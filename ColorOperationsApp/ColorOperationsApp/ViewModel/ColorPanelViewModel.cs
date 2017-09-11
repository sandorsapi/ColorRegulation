using Feladat;
using GalaSoft.MvvmLight;
using System;
using System.Windows.Media;

namespace ColorOperationsApp.ViewModel
{
	public class ColorPanelViewModel : ViewModelBase
	{
		#region Properties

		private ColorModel colorModel;
		private SlidersViewModel sliderViewModel;
		private Color colorValues = Color.FromRgb(0, 0, 0);

		public Color ColorValues
		{
			get { return colorValues; }
			set { Set(nameof(ColorValues), ref colorValues, value); }
		}

		#endregion Properties

		public ColorPanelViewModel(ColorModel _colorModel, SlidersViewModel _slidersViewModel)
		{
			this.sliderViewModel = _slidersViewModel;
			this.colorModel = _colorModel;

			this.sliderViewModel.OnChangedColorValue += new SliderChanged(ChangedPanelColor);
		}

		private void ChangedPanelColor()
		{
			colorModel.Red = sliderViewModel.SliderRValue;
			colorModel.Green = sliderViewModel.SliderGValue;
			colorModel.Blue = sliderViewModel.SliderBValue;

			ColorValues = Color.FromRgb(Convert.ToByte(colorModel.Red * 255), Convert.ToByte(colorModel.Green * 255), Convert.ToByte(colorModel.Blue * 255));
		}
	}
}