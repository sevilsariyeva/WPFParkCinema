using ParkCinema.Commands;
using ParkCinema.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkCinema.ViewModels
{
    public class ScheduleUCViewModel : BaseViewModel
    {
        private MovieSchedule movie;

        public MovieSchedule Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }
        private List<string> _dates;

        public List<string> Dates
        {
            get { return _dates; }
            set { _dates = value; OnPropertyChanged("Dates"); }
        }

        private ObservableCollection<MovieSchedule> movies = new ObservableCollection<MovieSchedule>();

        public ObservableCollection<MovieSchedule> Movies
        {
            get { return movies; }
            set { movies = value; OnPropertyChanged(); }
        }
        public RelayCommand ButtonCommand { get; set; }
        public RelayCommand SelectedCommand { get; set; }
        public ScheduleUCViewModel()
        {
            Dates = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                Dates.Add(DateTime.Now.AddDays(i).ToShortDateString().ToString());
            }

            ButtonCommand = new RelayCommand((obj) =>
            {

            });
            SelectedCommand = new RelayCommand((obj) =>
            {
                var date = obj as string;
                var newMovies = new ObservableCollection<MovieSchedule>();

                foreach (var item in App.ScheduleRepo.MovieSchedules)
                {
                    if (date == item.MovieDate)
                    {
                        newMovies.Add(item);
                    }
                }

                Movies = newMovies;
            });
        }

    }
}
