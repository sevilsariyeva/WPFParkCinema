﻿using ParkCinema.Commands;
using ParkCinema.Models;
using ParkCinema.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ParkCinema.ViewModels
{
    public class AdminUCViewModel : BaseViewModel
    {
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand LogoClickCommand { get; set; }
        public RelayCommand EditMovieCommand { get; set; }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }
        private ObservableCollection<Movie> allMovies;

        public ObservableCollection<Movie> AllMovies
        {
            get { return allMovies; }
            set { allMovies = value; OnPropertyChanged(); }
        }


        public AdminUCViewModel()
        {
            AllMovies = new ObservableCollection<Movie>(App.MovieRepo.Movies);
            LoginCommand = new RelayCommand((obj) =>
            {
                if (Email == "sevilsariyeva@gmail.com" && Password == "sevil2023")
                {

                }
            });
            LogoClickCommand = new RelayCommand((obj) =>
            {
                App.BackPage = App.MyGrid.Children[0];

                var uc = new HomeUC();
                var vm = new HomeUCViewModel();

                uc.DataContext = vm;
                App.MyGrid.Children.Add(uc);
            });
            EditMovieCommand = new RelayCommand((obj) =>
            {
                var mov = obj as Movie;
                var vm = new EditUCViewModel();
                vm.Movie = mov;
                var uc = new EditUC();
                uc.DataContext = vm;
                foreach (var item in App.MovieRepo.Movies)
                {
                    if (item == mov)
                    {
                        vm.Title = mov.MovieName;
                        vm.Year = mov.MovieYear;
                        vm.Genre = mov.MovieGenre;
                        vm.Director = mov.MovieDirector;
                        vm.Actor = mov.MovieActors;
                        vm.Country = mov.MovieCountry;
                        vm.Language = mov.MovieLanguages;
                        vm.Duration = mov.MovieDuration;
                        vm.Rating = mov.Rating;
                        vm.Price = mov.MoviePrice;
                        vm.ImagePath = mov.ImagePath;
                        vm.AgeLimit = mov.Age;
                        vm.Condition = mov.MovieCondition;
                    }
                }
                App.MyGrid.Children.Add(uc);
            });
        }
    }
}
