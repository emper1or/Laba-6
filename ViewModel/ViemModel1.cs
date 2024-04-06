using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Model;

namespace ViewModel
{
    public class ViewModel1 : INotifyPropertyChanged
    {
        public ObservableCollection<Employee> Employees {  get; private  set; }
        private Employee _newEmployee;

        public ViewModel1()
        {
            Employees = new ObservableCollection<Employee>();
            NewEmployee = new Employee();
        }
        public Employee NewEmployee
        {
            get => _newEmployee;
            set
            {
                _newEmployee = value;
                OnPropertyChanged("NewEmployee");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ICommand addCommand;
        private ICommand removeCommand;

        public ICommand AddCommand => addCommand ?? (addCommand = new RelayCommand(AddEmployee));
        public ICommand RemoveCommand => removeCommand ?? (removeCommand = new RelayCommand(RemoveEmployee));

        public void AddEmployee()
        {
            if (Employees.Contains(NewEmployee) == false)
            {
                if (NewEmployee.SelectedDate < DateTime.Today.AddDays(14) || NewEmployee.Difficultu == "" ||
                    NewEmployee.Name == "" || NewEmployee.PrepodName == "")
                {
                }
                else
                {
                    Employees.Add(NewEmployee);
                    NewEmployee = new Employee(); }
                
                
            }
        }

        public void RemoveEmployee()
        {
            var i_1 = -1;
            for (int i = 0;  i < Employees.Count; i++) 
            {
                if (Employees[i].Name.Equals(NewEmployee.Name) & Employees[i].PrepodName.Equals(NewEmployee.PrepodName) & Employees[i].SelectedDate.Equals(NewEmployee.SelectedDate) & Employees[i].Difficultu.Equals(NewEmployee.Difficultu))
                {
                    i_1 = i;
                    break;
                }
                
            }

            if (i_1 == -1) return;
            Employees.RemoveAt(i_1);
            NewEmployee = new Employee();

        }


        


    }
}