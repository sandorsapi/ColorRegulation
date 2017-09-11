using System.ComponentModel;

namespace Feladat
{
    public class ColorModel : INotifyPropertyChanged
    {

        #region Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        } 
        #endregion

        #region Binding Properties
        double _red;
        public double Red
        {
            get { return _red; }
            set { _red = value; OnPropertyChanged("Red"); }
        }

        double _green;
        public double Green
        {
            get { return _green; }
            set { _green = value; OnPropertyChanged("Green"); }
        }

        double _blue;
        public double Blue
        {
            get { return _blue; }
            set { _blue = value; OnPropertyChanged("Blue"); }
        }
        #endregion

        // ********************************************************************

        public ColorModel()
        {
        }

        // ********************************************************************

        public void Reset()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
        }
    }
}
