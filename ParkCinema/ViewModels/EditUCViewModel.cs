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

namespace ParkCinema.ViewModels
{
    public class EditUCViewModel : BaseViewModel
    {
        public RelayCommand ResetChangesCommand { get; set; }
        public RelayCommand MainClickCommand { get; set; }
        public RelayCommand SaveChangesCommand { get; set; }

        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }
        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; OnPropertyChanged(); }
        }

        private string genre;

        public string Genre
        {
            get { return genre; }
            set { genre = value; OnPropertyChanged(); }
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
            set { writer = value; OnPropertyChanged(); }
        }

        private string actor;

        public string Actor
        {
            get { return actor; }
            set { actor = value; OnPropertyChanged(); }
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
            set { language = value; OnPropertyChanged(); }
        }

        private string duration;

        public string Duration
        {
            get { return duration; }
            set { duration = value; OnPropertyChanged(); }
        }

        private double rating;

        public double Rating
        {
            get { return rating; }
            set { rating = value; OnPropertyChanged(); }
        }

        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }
        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; OnPropertyChanged(); }
        }

        private string ageLimit;

        public string AgeLimit
        {
            get { return ageLimit; }
            set { ageLimit = value; OnPropertyChanged(); }
        }

        private string condition;

        public string Condition
        {
            get { return condition; }
            set { condition = value; OnPropertyChanged(); }
        }

        private List<Movie> _dataList;
        public List<Movie> DataList
        {
            get { return _dataList; }
            set { _dataList = value; OnPropertyChanged(nameof(DataList)); }
        }
        public void LoadData()
        {
            string json = File.ReadAllText("movies.json");
            DataList = JsonConvert.DeserializeObject<List<Movie>>(json);
        }

        public void SaveData()
        {
            string json = JsonConvert.SerializeObject(DataList);
            File.WriteAllText("movies.json", json);
        }

        // Method to update a field in an object in the list
        public void UpdateData(int index, string newName)
        {
            DataList[index].MovieName = newName;
            SaveData();
        }
        public EditUCViewModel()
        {
            MainClickCommand = new RelayCommand((obj) =>
            {

            });

            ResetChangesCommand = new RelayCommand((obj) =>
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
                        Director=element.MovieDirector;
                        AgeLimit=element.Age;
                        Country=element.MovieCountry;
                        Duration=element.MovieDuration;
                        Language=element.MovieLanguages;
                        Year = element.MovieYear;
                        ImagePath=element.ImagePath;

                    }
                }
            });
            SaveChangesCommand = new RelayCommand((obj) =>
            {
                foreach (var item in App.MovieRepo.Movies)
                {
                    if (item.Id == Movie.Id)
                    {
                        string jsonString = File.ReadAllText("movies.json");

                        // Deserialize the JSON string into a C# object
                        var data = JsonConvert.DeserializeObject<List<Movie>>(jsonString);

                        // Access the specific element you want to edit
                        var element = data.FirstOrDefault(e => e.Id == item.Id);

                        // Edit the field of the element
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

                        // Serialize the C# object back into a JSON string
                        jsonString = JsonConvert.SerializeObject(data);

                        // Write the updated JSON string back to the file
                        File.WriteAllText("movies.json", jsonString);
                    }
                }
            });
        }
    }
}
