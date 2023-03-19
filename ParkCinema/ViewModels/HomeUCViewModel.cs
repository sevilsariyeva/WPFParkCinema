using ParkCinema.Commands;
using ParkCinema.Models;
using ParkCinema.Repositories;
using ParkCinema.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.TextFormatting;
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

        private string movieName;

        public string MovieName
        {
            get { return movieName; }
            set { movieName = value; OnPropertyChanged(); }
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
            if (count == 4)
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
        public RelayCommand FifthClickCommand { get; set; }
        public RelayCommand TodayClickCommand { get; set; }
        public RelayCommand SoonClickCommand { get; set; }
        public RelayCommand AppleClickCommand { get; set; }
        public RelayCommand AndroidClickCommand { get; set; }
        public RelayCommand FaceBookClickCommand { get; set; }
        public RelayCommand TwitterClickCommand { get; set; }
        public RelayCommand YoutubeClickCommand { get; set; }
        public RelayCommand LogoClickCommand { get; set; }
        public RelayCommand MovieNameClickCommand { get; set; }
        public RelayCommand SelectedItemChangedCommand { get; set; }
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
            FifthClickCommand = new RelayCommand((obj) =>
            {
                BackImage = AllBackgroundImages[4];
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
            SoonClickCommand = new RelayCommand((obj) =>
            {
                var movies = (App.MovieRepo.Movies.Where((m) => m.MovieCondition == "soon").ToList());
                List<Movie> movies1 = new List<Movie>();
                movies.ForEach(m =>
                {
                    movies1.Add(m);
                });
                AllMovies = new ObservableCollection<Movie>(movies1);
            });
            AppleClickCommand = new RelayCommand((obj) =>
            {
                System.Diagnostics.Process.Start("https://apps.apple.com/us/app/park-cinema/id1119977600?ls=1");
            });
            AndroidClickCommand = new RelayCommand((obj) =>
            {
                System.Diagnostics.Process.Start("https://play.google.com/store/apps/details?id=az.parkcinema.app&hl=ru");
            });
            FaceBookClickCommand = new RelayCommand((obj) =>
            {
                System.Diagnostics.Process.Start("https://www.facebook.com/ParkCinema");
            });
            TwitterClickCommand = new RelayCommand((obj) =>
            {
                System.Diagnostics.Process.Start("https://twitter.com/park_cinema");
            });
            YoutubeClickCommand = new RelayCommand((obj) =>
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/channel/UC0NJN0gCCx_DbJlkPfD30Ag/feed");
            });
            LogoClickCommand = new RelayCommand((obj) =>
            {
                App.BackPage = App.MyGrid.Children[0];
                App.MyGrid.Children.RemoveAt(0);

                var uc = new HomeUC();
                var vm = new HomeUCViewModel();

                uc.DataContext = vm;
                App.MyGrid.Children.Add(uc);
            });
            MovieNameClickCommand = new RelayCommand((obj) =>
            {
                timer.Stop();
                var temp = obj as Movie;

                var vm = new MovieBackgroundUCViewModel();
                vm.Movie = temp;
                var uc = new MovieBackgroundUC();
                uc.DataContext = vm;
                
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(uc);
            });
        }

    }
}
