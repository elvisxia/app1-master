using System;
using System.ComponentModel;

namespace App1
{
    public class Product : INotifyPropertyChanged
    {
        private string _name = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return _name; }
            set
            {
                if (!String.Equals(_name, value))
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
