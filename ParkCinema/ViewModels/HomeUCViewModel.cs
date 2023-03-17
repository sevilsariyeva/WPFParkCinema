using ParkCinema.Commands;
using ParkCinema.Models;
using ParkCinema.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ParkCinema.ViewModels
{
    public class HomeUCViewModel : BaseViewModel
    {
        public BackgroundRepository BackgroundRepository { get; set; }
        DispatcherTimer timer = new DispatcherTimer();

        private ObservableCollection<Movie> movies;

        public ObservableCollection<Movie> AllMovies
        {
            get { return movies; }
            set { movies = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BackgroundImage> allBackgroundImages;

        public ObservableCollection<BackgroundImage> AllBackgroundImages
        {
            get { return allBackgroundImages; }
            set { allBackgroundImages = value; OnPropertyChanged(); }
        }

        private BackgroundImage image;

        public BackgroundImage BackImage
        {
            get { return image; }
            set { image = value; OnPropertyChanged(); }
        }

        int count = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            BackImage = AllBackgroundImages[count];
            if (count == 3)
            {
                count = 0;
            }
            else
            {
                count++;
            }
        }
        public RelayCommand FirstClickCommand { get; set; }
        public RelayCommand SecondClickCommand { get; set; }
        public RelayCommand ThirdClickCommand { get; set; }
        public RelayCommand FourthClickCommand { get; set; }
        public RelayCommand TodayClickCommand { get; set; }
        public HomeUCViewModel()
        {
            BackgroundRepository = new BackgroundRepository();
            AllBackgroundImages = new ObservableCollection<BackgroundImage>(BackgroundRepository.GetAll());
            AllMovies = new ObservableCollection<Movie>(App.MovieRepo.Movies);
            BackImage = AllBackgroundImages[count];
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Timer_Tick;
            timer.Start();

            FirstClickCommand = new RelayCommand((obj) =>
            {
                BackImage = AllBackgroundImages[0];
                timer.Stop();
            });
            SecondClickCommand = new RelayCommand((obj) =>
            {
                BackImage = AllBackgroundImages[1];
                timer.Stop();
            });
            ThirdClickCommand = new RelayCommand((obj) =>
            {
                BackImage = AllBackgroundImages[2];
                timer.Stop();
            });
            FourthClickCommand = new RelayCommand((obj) =>
            {
                BackImage = AllBackgroundImages[3];
                timer.Stop();
            });
            TodayClickCommand = new RelayCommand((obj) =>
            {
                var movies = (App.MovieRepo.Movies.Where((m) => m.MovieCondition == "today").ToList());
                List<Movie> movies1 = new List<Movie>();
                movies.ForEach(m =>
                {
                    movies1.Add(m);
                });
                AllMovies = new ObservableCollection<Movie>(movies1);
            });
        }

    }
}
