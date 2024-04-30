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
        public ObservableCollection<Movie> Movies { get; private set; }
        public ObservableCollection<Director> Directors { get; private set; }
        public List<Movie> NonSortMovies { get; private set; }
        private Movie _newMovie;
        private Movie _selectedMovie;
        public string _selectedtype {  get; set; }
        public int _selectedstart { get; set; }
        public int _selectedend { get; set; }
        public List<string> Types { get; private set; }

        public ViewModel1()
        {
            Types = new List<string>
            {
                "Ужас",
                "Драма",
                "Комедия"
            };

            Movies = new ObservableCollection<Movie>
            {
                new Movie{Name = "1+1", Type = "Драма", Start = 2002, Director = "Жанна Штанга", Raiting = 4.5 },
                new Movie{Name = "Сваты", Type = "Комедия", Start = 1999, Director = "Елисей Гиря", Raiting = 5 },
                new Movie{Name = "5 лаба", Type = "Комедия", Start = 2024, Director = "Анастасия Раскина", Raiting = 100 },
                new Movie{Name = "3 лаба", Type = "Ужас", Start = 2024, Director = "Анастасия Раскина", Raiting = 100 },

            };
            NonSortMovies = new List<Movie> {
                new Movie{Name = "1+1", Type = "Драма", Start = 2002, Director = "Жанна Штанга", Raiting = 4.5 },
                new Movie{Name = "Сваты", Type = "Комедия", Start = 1999, Director = "Елисей Гиря", Raiting = 5 },
                new Movie{Name = "5 лаба", Type = "Комедия", Start = 2024, Director = "Анастасия Раскина", Raiting = 100 },
                new Movie{Name = "3 лаба", Type = "Ужас", Start = 2024, Director = "Анастасия Раскина", Raiting = 100 },

            };

            Directors = new ObservableCollection<Director>();

            NewMovie = new Movie();
        }
        public Movie NewMovie
        {
            get => _newMovie;
            set
            {
                _newMovie = value;
                OnPropertyChanged("NewMovie");
            }
        }
        public Movie SelectedMovie
        {
            get
            {
                return _selectedMovie;
            }
            set
            {
                _selectedMovie = value;
                OnPropertyChanged("SelectedMovie");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ICommand addCommand;
        private ICommand removeCommand;
        private ICommand showallCommand;
        private ICommand sortbytype;
        private ICommand sortbyrange;
        private ICommand sortbymintomax;
        private ICommand sortbymaxtomin;
        private ICommand showalldirectors;

        public ICommand ShowAllDirectors => showalldirectors ?? (showalldirectors = new RelayCommand(ShowedAllDirectors));

        public ICommand SortByMinToMax => sortbymintomax ?? (sortbymintomax = new RelayCommand(SortedByMinToMax));
        public ICommand SortByMaxToMin => sortbymaxtomin ?? (sortbymaxtomin = new RelayCommand(SortedByMaxToMin));
        public ICommand SortByRange => sortbyrange ?? (sortbyrange = new RelayCommand(SortedByRange));
        public ICommand SortByType => sortbytype ?? (sortbytype = new RelayCommand(SortedByType));
        public ICommand ShowallCommand => showallCommand ?? (showallCommand = new RelayCommand(ShowAllMovies));

        public ICommand AddCommand => addCommand ?? (addCommand = new RelayCommand(AddMovie));
        public ICommand RemoveCommand => removeCommand ?? (removeCommand = new RelayCommand(RemoveMovie));

        public void AddMovie()
        {
            
            if (NonSortMovies.Contains(NewMovie) == false)
            {
                if (NewMovie.Director == "" || NewMovie.Type == "" ||
                     NewMovie.Name == "" || NewMovie.Start <= 0 || NewMovie.Raiting < 0)
                {
                }
                else
                {
                    NonSortMovies.Add(NewMovie);
                    Movies.Add(NewMovie);
                    NewMovie = new Movie();
                }
            }

        }

        

        public void RemoveMovie()
        {
            //if (SelectedMovie == null)
            //{
            //    var i_1 = -1;
            //    for (int i = 0; i < Movies.Count; i++)
            //    {
            //        if (Movies[i].Name.Equals(NewMovie.Name) & Movies[i].Type.Equals(NewMovie.Type) /*& Movies[i].SelectedDate.Equals(NewMovie.SelectedDate) & Movies[i].Difficultu.Equals(NewMovie.Difficultu)*/)
            //        {
            //            i_1 = i;
            //            break;
            //        }

            //    }

            //    if (i_1 == -1) return;
            //    Movies.RemoveAt(i_1);
            //    NewMovie = new Movie();
            //}

            //else
            //{
                NonSortMovies.Remove(SelectedMovie);
                Movies.Remove(SelectedMovie);
                NewMovie = new Movie();

            //}

        }

        public void ShowAllMovies()
        {
            Movies.Clear();

            foreach (var movie in NonSortMovies) 
            {
                Movies.Add(movie);
            }

            NewMovie = new Movie();

        }

        public void SortedByType()
        {
            if (_selectedtype != "")
            {
                Movies.Clear();
                var SortedMovies = from movie in NonSortMovies 
                                   where movie.Type == _selectedtype 
                                   select movie;              

                foreach (var movie in SortedMovies)
                {
                    Movies.Add(movie);
                }
            }

        }

        public void SortedByRange()
        {
            if(_selectedstart >= 0 & _selectedend >= 0 & _selectedstart <= _selectedend)
            {
                Movies.Clear();
                var SortedMovies = from movie in NonSortMovies
                                   where movie.Start >= _selectedstart && movie.Start <= _selectedend
                                   select movie;

                foreach (var movie in SortedMovies)
                {
                    Movies.Add(movie);
                }

            }

        }

        public void SortedByMinToMax()
        {
            Movies.Clear();
            var SortedMovies = from movie in NonSortMovies
                               orderby movie.Raiting
                               select movie;

            foreach (var movie in SortedMovies)
            {
                Movies.Add(movie);
            }           
        }

        public void SortedByMaxToMin()
        {
            Movies.Clear();
            var SortedMovies = from movie in NonSortMovies
                               orderby movie.Raiting descending
                               select movie;

            foreach (var movie in SortedMovies)
            {
                Movies.Add(movie);
            }

        }

        public void ShowedAllDirectors()
        {
            Directors.Clear();         
            
            var direc = from film in Movies group film by film.Director into g select new { FN = g.Key, NF = g.Count(), AR = g.Average(film => film.Raiting), SW = g.Min(film => film.Start), EW = g.Max(film => film.Start) };
            foreach (var dir in direc)
            {
                Directors.Add(new Director { FullName = dir.FN, Count = dir.NF, AVGRairind = dir.AR, StartYear = dir.SW, EndYear = dir.EW });
            }

        }
    }
}