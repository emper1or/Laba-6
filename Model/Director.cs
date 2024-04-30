using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Director: INotifyPropertyChanged
    {
        private string _fullname;
        private int _count;
        private double _avgraiting;
        private int _startyear;
        private int _endyear;

        public string FullName
        {
            get

            {
                return _fullname;
            }
            set
            {
                _fullname = value;
                OnPropertyChanged("FullName");
            }
        }

        public int Count
        {
            get

            {
                return _count;
            }
            set
            {
                _count = value;
                OnPropertyChanged("Count");
            }
        }


        public double AVGRairind
        {
            get

            {
                return _avgraiting;
            }
            set
            {
                _avgraiting = value;
                OnPropertyChanged("AVGRairind");
            }
        }

        public int StartYear
        {
            get

            {
                return _startyear;
            }
            set
            {
                _startyear = value;
                OnPropertyChanged("StartYear");
            }
        }

        public int EndYear
        {
            get

            {
                return _endyear;
            }
            set
            {
                _endyear = value;
                OnPropertyChanged("EndYear");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

