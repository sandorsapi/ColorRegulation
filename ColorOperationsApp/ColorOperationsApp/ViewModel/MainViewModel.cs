using Feladat;
using GalaSoft.MvvmLight;
using System.Configuration;

namespace ColorOperationsApp.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		private ColorListViewModel ColorListViewModel;
		private SlidersViewModel SlidersViewModel;
		private ColorPanelViewModel ColorPanelViewModel;
		private ColorModel colorModel = new ColorModel();

		private string appName = ConfigurationManager.AppSettings["MainWindowName"];

		public MainViewModel()
		{
			this.ColorListViewModel = new ColorListViewModel(colorModel);
			this.SlidersViewModel = new SlidersViewModel(colorModel);
			this.ColorPanelViewModel = new ColorPanelViewModel(colorModel, SlidersViewModel);
		}

		public ColorListViewModel ContentColorListViewModel
		{
			get { return ColorListViewModel; }
			set { Set(nameof(ContentColorListViewModel), ref ColorListViewModel, value); }
		}

		public SlidersViewModel ContentSlidersViewModel
		{
			get { return SlidersViewModel; }
			set { Set(nameof(ContentSlidersViewModel), ref SlidersViewModel, value); }
		}

		public ColorPanelViewModel ContentColorPanelViewModel
		{
			get { return ColorPanelViewModel; }
			set { Set(nameof(ContentColorPanelViewModel), ref ColorPanelViewModel, value); }
		}

		public string AppName
		{
			get { return appName; }
			set { Set(nameof(AppName), ref appName, value); }
		}
	}
}