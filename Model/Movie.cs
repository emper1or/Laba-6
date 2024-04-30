using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Model
{
    public class Movie: INotifyPropertyChanged
    {
        private string _name;
        private string _type;
        private int _start;
        private string _director;
        private double _raiting;

        public string Name
        {
            get

            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Type
        {
            get

            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }


        public int Start
        {
            get

            {
                return _start;
            }
            set
            {
                _start = value;
                OnPropertyChanged("Start");
            }
        }

        public string Director
        {
            get

            {
                return _director;
            }
            set
            {
                _director = value;
                OnPropertyChanged("Director");
            }
        }

        public double Raiting
        {
            get

            {
                return _raiting;
            }
            set
            {
                _raiting = value;
                OnPropertyChanged("Raiting");
            }
        }
        


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
