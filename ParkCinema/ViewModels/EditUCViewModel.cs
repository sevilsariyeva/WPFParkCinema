using Microsoft.Win32;
using Newtonsoft.Json;
using ParkCinema.Commands;
using ParkCinema.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace ParkCinema.ViewModels
{
    public class EditUCViewModel : BaseViewModel
    {
        public RelayCommand ResetChangesCommand { get; set; }
        public RelayCommand MainClickCommand { get; set; }
        public RelayCommand SaveChangesCommand { get; set; }
        public RelayCommand ImageClickCommand { get; set; }
        private void Reset()
        {
            foreach (var item in App.MovieRepo.Movies)
            {
                if (item.Id == Movie.Id)
                {
                    string jsonString = File.ReadAllText("movies.json");

                    var data = JsonConvert.DeserializeObject<List<Movie>>(jsonString);

                    var element = data.FirstOrDefault(e => e.Id == item.Id);

                    Title = element.MovieName;
                    Genre = element.MovieGenre;
                    Price = element.MoviePrice;
                    Director = element.MovieDirector;
                    AgeLimit = element.Age;
                    Country = element.MovieCountry;
                    Duration = element.MovieDuration;
                    Language = element.MovieLanguages;
                    Year = element.MovieYear;
                    ImagePath = element.ImagePath;

                }
            }
        }
        private void OpenImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                byte[] imageBytes = File.ReadAllBytes(filePath);

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = new MemoryStream(imageBytes);
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                var path = Path.GetFullPath(openFileDialog.FileName);
                ImagePath = path;

                foreach (var item in App.MovieRepo.Movies)
                {
                    if (item.Id == Movie.Id)
                    {
                        string jsonString = File.ReadAllText("movies.json");

                        var data = JsonConvert.DeserializeObject<List<Movie>>(jsonString);

                        var element = data.FirstOrDefault(e => e.Id == item.Id);


                        element.ImagePath = ImagePath;
                        jsonString = JsonConvert.SerializeObject(data);

                        File.WriteAllText("movies.json", jsonString);

                    }
                }
            }
        }
        private void Save()
        {
            foreach (var item in App.MovieRepo.Movies)
            {
                if (item.Id == Movie.Id)
                {
                    string jsonString = File.ReadAllText("movies.json");

                    var data = JsonConvert.DeserializeObject<List<Movie>>(jsonString);

                    var element = data.FirstOrDefault(e => e.Id == item.Id);

                    element.MovieName = Title;
                    element.MovieGenre = Genre;
                    element.MoviePrice = Price;
                    element.MovieDirector = Director;
                    element.Age = AgeLimit;
                    element.MovieCountry = Country;
                    element.MovieDuration = Duration;
                    element.MovieLanguages = Language;
                    element.MovieYear = Year;
                    element.ImagePath = ImagePath;

                    jsonString = JsonConvert.SerializeObject(data);

                    File.WriteAllText("movies.json", jsonString);
                }
            }
        }

        private Movie movie;
        private string title;
        private int year;
        private string genre;
        private string director;
        private string writer;
        private string actor;
        private string country;
        private string language;
        private string duration;
        private double rating;
        private decimal price;
        private string imagePath;
        private string ageLimit;
        private string condition;
        
        public Movie Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }
        public int Year
        {
            get { return year; }
            set { year = value; OnPropertyChanged(); }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; OnPropertyChanged(); }
        }
        public string Director
        {
            get { return director; }
            set { director = value; OnPropertyChanged(); }
        }
        public string Writer
        {
            get { return writer; }
            set { writer = value; OnPropertyChanged(); }
        }
        public string Actor
        {
            get { return actor; }
            set { actor = value; OnPropertyChanged(); }
        }
        public string Country
        {
            get { return country; }
            set { country = value; OnPropertyChanged(); }
        }
        public string Language
        {
            get { return language; }
            set { language = value; OnPropertyChanged(); }
        }
        public string Duration
        {
            get { return duration; }
            set { duration = value; OnPropertyChanged(); }
        }
        public double Rating
        {
            get { return rating; }
            set { rating = value; OnPropertyChanged(); }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }
        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; OnPropertyChanged(); }
        }
        public string AgeLimit
        {
            get { return ageLimit; }
            set { ageLimit = value; OnPropertyChanged(); }
        }
        public string Condition
        {
            get { return condition; }
            set { condition = value; OnPropertyChanged(); }
        }
        public EditUCViewModel()
        {
            MainClickCommand = new RelayCommand((obj) =>
            {

            });

            ResetChangesCommand = new RelayCommand((obj) =>
            {
                Reset();
            });
            SaveChangesCommand = new RelayCommand((obj) =>
            {
                Save(); 
            });
            ImageClickCommand = new RelayCommand((obj) =>
            {
                OpenImage();
            });
        }
    }
}
