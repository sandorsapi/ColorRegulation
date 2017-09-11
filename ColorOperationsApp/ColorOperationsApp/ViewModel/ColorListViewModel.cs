using ColorOperationsApp.Models;
using Feladat;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace ColorOperationsApp.ViewModel
{
	public class ColorListViewModel : ViewModelBase
	{
		#region Commands

		public RelayCommand AddCommand { get; private set; }
		public RelayCommand RemoveCommand { get; private set; }

		#endregion Commands

		#region Properties

		private ConvertColorModelToRGB colorModelRGB = new ConvertColorModelToRGB();
		public ObservableCollection<ConvertColorModelToRGB> ColorListItems { get; private set; }
		private ColorModel colorModel;
		private ConvertColorModelToRGB selectedRGB;

		public ConvertColorModelToRGB SelectedRGB
		{
			get { return selectedRGB; }
			set { Set(nameof(SelectedRGB), ref selectedRGB, value); }
		}

		#endregion Properties

		public ColorListViewModel(ColorModel _colorModel)
		{
			this.colorModel = _colorModel;
			AddCommand = new RelayCommand(AddToList);
			RemoveCommand = new RelayCommand(RemoveFromList);
			ColorListItems = new ObservableCollection<ConvertColorModelToRGB>();
		}

		#region Events

		private void AddToList()
		{
			colorModelRGB.RGB = Color.FromRgb(Convert.ToByte(colorModel.Red * 255), Convert.ToByte(colorModel.Green * 255), Convert.ToByte(colorModel.Blue * 255));
			ColorListItems.Add(colorModelRGB);
			colorModelRGB = new ConvertColorModelToRGB();
		}

		private void RemoveFromList()
		{
			if (SelectedRGB != null)
			{
				var selectedindex = ColorListItems.IndexOf(SelectedRGB);
				ColorListItems.RemoveAt(selectedindex);
			}
		}

		#endregion Events
	}
}