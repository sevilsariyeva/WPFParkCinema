using Microsoft.Web.WebView2.Wpf;
using ParkCinema.Commands;
using ParkCinema.Models;
using ParkCinema.Views.UserControls;
using System;
using System.Collections.Generic;
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

        public RelayCommand AppleClickCommand { get; set; }
        public RelayCommand AndroidClickCommand { get; set; }
        public RelayCommand LogoClickCommand { get; set; }
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
        }
    }
}
