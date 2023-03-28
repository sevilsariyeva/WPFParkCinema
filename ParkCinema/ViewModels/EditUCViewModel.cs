using ParkCinema.Commands;
using ParkCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkCinema.ViewModels
{
    public class EditUCViewModel:BaseViewModel
    {
        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set { movie = value;OnPropertyChanged(); }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value;OnPropertyChanged(); }
        }
        private string year;

        public string Year
        {
            get { return year; }
            set { year = value;OnPropertyChanged(); }
        }

        private string genre;

        public string Genre
        {
            get { return genre; }
            set { genre = value;OnPropertyChanged(); }
        }

        private string director;

        public string Director
        {
            get { return director; }
            set { director = value; OnPropertyChanged(); }
        }

        private string writer;

        public string Writer
        {
            get { return writer; }
            set { writer = value;OnPropertyChanged(); }
        }

        private string actor;

        public string Actor
        {
            get { return actor; }
            set { actor = value;OnPropertyChanged(); }
        }
        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; OnPropertyChanged(); }
        }

        private string language;

        public string Language
        {
            get { return language; }
            set { language = value;OnPropertyChanged(); }
        }

        private string duration;

        public string Duration
        {
            get { return duration; }
            set { duration = value;OnPropertyChanged(); }
        }

        private double rating;

        public double Rating
        {
            get { return rating; }
            set { rating = value;OnPropertyChanged(); }
        }

        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value;OnPropertyChanged(); }
        }

        public RelayCommand MainClickCommand { get; set; }
        public EditUCViewModel()
        {
            
            MainClickCommand = new RelayCommand((obj) =>
            {

            });
        }
    }
}
