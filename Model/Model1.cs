using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Model
{
    public class Employee : INotifyPropertyChanged
    {
        private string _name;
        private string _prepodname;
        private string _difficulty;
        private DateTime _date = DateTime.Today;
 
        

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

        public string PrepodName
        {
            get

            {
                return _prepodname;
            }
            set
            {
                _prepodname = value;
                OnPropertyChanged("PrepodName");
            }
        }


        public string Difficultu
        {
            get

            {
                return _difficulty;
            }
            set
            {
                _difficulty = value;
                OnPropertyChanged("Difficultu");
            }
        }

        public DateTime SelectedDate
        {
            get

            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged("SelectedDate");
            }
        }

        public string DateOfStartWork
        {
            get

            {
                return SelectedDate.AddDays(-14).ToString("M/d/yyyy").Replace('.','/');
            }
            set { }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
