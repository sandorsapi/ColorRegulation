using Feladat;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;

namespace ColorOperationsApp.ViewModel
{
	public delegate void SliderChanged();

	public class SlidersViewModel : ViewModelBase
	{
		public event SliderChanged OnChangedColorValue;

		#region Commands

		public RelayCommand ResetCommand { get; private set; }
		public RelayCommand EnterRCommand { get; private set; }
		public RelayCommand EnterGCommand { get; private set; }
		public RelayCommand EnterBCommand { get; private set; }

		#endregion Commands

		#region Properties

		private ColorModel colorModel;

		private double sliderRValue;

		public double SliderRValue
		{
			get { return sliderRValue; }
			set
			{
				Set(nameof(SliderRValue), ref sliderRValue, value);
				OnChangedColorValue();
				TextRValue = Convert.ToInt32(colorModel.Red * 255);
			}
		}

		private double sliderGValue;

		public double SliderGValue
		{
			get { return sliderGValue; }
			set
			{
				Set(nameof(SliderGValue), ref sliderGValue, value);
				OnChangedColorValue();
				TextGValue = Convert.ToInt32(colorModel.Green * 255);
			}
		}

		private double sliderBValue;

		public double SliderBValue
		{
			get { return sliderBValue; }
			set
			{
				Set(nameof(SliderBValue), ref sliderBValue, value);
				OnChangedColorValue();
				TextBValue = Convert.ToInt32(colorModel.Blue * 255);
			}
		}

		private int textRValue;

		public int TextRValue
		{
			get { return textRValue; }
			set { Set(nameof(TextRValue), ref textRValue, value); }
		}

		private int textGValue;

		public int TextGValue
		{
			get { return textGValue; }
			set { Set(nameof(TextGValue), ref textGValue, value); }
		}

		private int textBValue;

		public int TextBValue
		{
			get { return textBValue; }
			set { Set(nameof(TextBValue), ref textBValue, value); }
		}

		#endregion Properties

		public SlidersViewModel(ColorModel _colorModel)
		{
			this.colorModel = _colorModel;
			ResetCommand = new RelayCommand(ResetSliders);
			EnterRCommand = new RelayCommand(TextBoxREnter);
			EnterGCommand = new RelayCommand(TextBoxGEnter);
			EnterBCommand = new RelayCommand(TextBoxBEnter);
		}

		#region Events

		private void ResetSliders()
		{
			SliderRValue = 0;
			SliderGValue = 0;
			SliderBValue = 0;
			TextRValue = 0;
			TextGValue = 0;
			TextBValue = 0;
		}

		private void TextBoxREnter()
		{
			if (TextRValue >= 0 && TextRValue <= 255)
			{
				colorModel.Red = (Convert.ToDouble(TextRValue) / 255);
				SliderRValue = colorModel.Red;
			}
			else
			{
				MessageBox.Show("Csak 0-tól 255-ig terjedő érték adható meg!", "Hibás érték!", MessageBoxButton.OK, MessageBoxImage.Information);
				TextRValue = 0;
			}
		}

		private void TextBoxGEnter()
		{
			if (TextGValue >= 0 && TextGValue <= 255)
			{
				colorModel.Green = (Convert.ToDouble(TextGValue) / 255);
				SliderGValue = colorModel.Green;
			}
			else
			{
				MessageBox.Show("Csak 0-tól 255-ig terjedő érték adható meg!", "Hibás érték!", MessageBoxButton.OK, MessageBoxImage.Information);
				TextGValue = 0;
			}
		}

		private void TextBoxBEnter()
		{
			if (TextBValue >= 0 && TextBValue <= 255)
			{
				colorModel.Blue = (Convert.ToDouble(TextBValue) / 255);
				SliderBValue = colorModel.Blue;
			}
			else
			{
				MessageBox.Show("Csak 0-tól 255-ig terjedő érték adható meg!", "Hibás érték!", MessageBoxButton.OK, MessageBoxImage.Information);
				TextBValue = 0;
			}
		}

		#endregion Events
	}
}