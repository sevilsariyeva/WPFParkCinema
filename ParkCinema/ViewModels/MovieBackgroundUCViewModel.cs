using Microsoft.Web.WebView2.Wpf;
using ParkCinema.Commands;
using ParkCinema.Models;
using ParkCinema.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ParkCinema.ViewModels
{
    public class MovieBackgroundUCViewModel : BaseViewModel
    {
        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }
        private string _youTubeUrl;
        public string YouTubeUrl
        {
            get { return _youTubeUrl; }
            set
            {
                if (_youTubeUrl != value)
                {
                    _youTubeUrl = value;
                    OnPropertyChanged(nameof(YouTubeUrl));
                    OnPropertyChanged(nameof(YouTubeEmbedUrl));
                }
            }
        }

        public string YouTubeEmbedUrl
        {
            get
            {
                // Parse the video ID from the YouTube URL
                string videoId = ExtractVideoId(YouTubeUrl);

                // Construct the YouTube video embed URL
                return "https://www.youtube.com/embed/" + videoId;
            }
        }

        private string ExtractVideoId(string youTubeUrl)
        {
            // Parse the video ID from the YouTube URL
            string videoId = "";

            if (youTubeUrl.Contains("youtube.com/watch?v="))
            {
                int index = youTubeUrl.IndexOf("youtube.com/watch?v=") + 20;
                videoId = youTubeUrl.Substring(index, 11);
            }
            else if (youTubeUrl.Contains("youtu.be/"))
            {
                int index = youTubeUrl.IndexOf("youtu.be/") + 9;
                videoId = youTubeUrl.Substring(index, 11);
            }

            return videoId;
        }
        private ObservableCollection<Movie> movies;

        public ObservableCollection<Movie> AllMovies
        {
            get { return movies; }
            set { movies = value; OnPropertyChanged(); }
        }
        public RelayCommand AppleClickCommand { get; set; }
        public RelayCommand AndroidClickCommand { get; set; }
        public RelayCommand LogoClickCommand { get; set; }
        public RelayCommand MovieNameClickCommand { get; set; }
        public Random a = new Random(); // replace from new Random(DateTime.Now.Ticks.GetHashCode());
                                        // Since similar code is done in default constructor internally
        public List<int> randomList = new List<int>();
        public ObservableCollection<Movie> movieList = new ObservableCollection<Movie>();
        int MyNumber = 0;

        public MovieBackgroundUCViewModel()
        {

            Movie = new Movie();

            LogoClickCommand = new RelayCommand((obj) =>
            {
                App.BackPage = App.MyGrid.Children[0];

                var uc = new HomeUC();
                var vm = new HomeUCViewModel();

                uc.DataContext = vm;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(uc);
            });
            AppleClickCommand = new RelayCommand((obj) =>
            {
                System.Diagnostics.Process.Start("https://apps.apple.com/us/app/park-cinema/id1119977600?ls=1");
            });
            AndroidClickCommand = new RelayCommand((obj) =>
            {
                System.Diagnostics.Process.Start("https://play.google.com/store/apps/details?id=az.parkcinema.app&hl=ru");
            });
            MovieNameClickCommand = new RelayCommand((obj) =>
            {
                var temp = obj as Movie;
                movieList = new ObservableCollection<Movie>();

                var vm = new MovieBackgroundUCViewModel();
                vm.Movie = temp;
                var movies = new ObservableCollection<Movie>();
                var moviesShort = new ObservableCollection<Movie>();
                for (int i = 1; i <= App.MovieRepo.Movies.Count; i++)
                {
                    if (i == vm.Movie.Id)
                    {
                        for (int j = 0; j < i - 1; j++)
                        {
                            movies.Add(App.MovieRepo.Movies[j]);
                        }
                        for (int j = i; j < App.MovieRepo.Movies.Count; j++)
                        {
                            movies.Add(App.MovieRepo.Movies[j]);
                        }
                        for (int k = 0; k < 5;)
                        {
                            MyNumber = a.Next(0, movies.Count);
                            if (!randomList.Contains(MyNumber) && MyNumber != vm.Movie.Id)
                            {
                                k++;
                                movieList.Add(movies[MyNumber]);
                                randomList.Add(MyNumber);
                            }
                        }

                        break;
                    }
                }
                vm.AllMovies = movieList;
                var uc = new MovieBackgroundUC();
                uc.DataContext = vm;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(uc);
            });
        }
    }
}
