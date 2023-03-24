using ParkCinema.Commands;
using ParkCinema.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ParkCinema.ViewModels
{
    public class SeatUCViewModel : BaseViewModel
    {
        public List<int> Numbers { get; set; } = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private MovieSchedule movie;

        public MovieSchedule Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged(); }
        }
        private int seatNumber;

        public int SeatNumber
        {
            get { return seatNumber; }
            set { seatNumber = value; OnPropertyChanged(); }
        }
        private Visibility sessionVisibility;

        public Visibility SessionVisibility
        {
            get { return sessionVisibility; }
            set { sessionVisibility = value; OnPropertyChanged(); }
        }
        private Visibility placesVisibility;

        public Visibility PlacesVisibility
        {
            get { return placesVisibility; }
            set { placesVisibility = value; OnPropertyChanged(); }
        }

        private Visibility paymentVisibility;

        public Visibility PaymentVisibility
        {
            get { return paymentVisibility; }
            set { paymentVisibility = value; OnPropertyChanged(); }
        }

        private bool isButtonEnable;

        public bool IsButtonEnable
        {
            get { return isButtonEnable; }
            set { isButtonEnable = value; OnPropertyChanged(); }
        }


        private decimal totalprice;

        public decimal TotalPrice
        {
            get { return totalprice; }
            set { totalprice = value; OnPropertyChanged(); }
        }

        public RelayCommand SelectedCommand { get; set; }
        public RelayCommand NextPlacesButtonClickCommand { get; set; }
        public RelayCommand SeatPlaceClickCommand { get; set; }
        static int counter = 0;
        public SeatUCViewModel()
        {
            IsButtonEnable = true;
            SessionVisibility = Visibility.Visible;
            PlacesVisibility = Visibility.Hidden;
            PaymentVisibility = Visibility.Hidden;
            SelectedCommand = new RelayCommand((obj) =>
            {
                var count = obj;
                Count = (int)count;
                TotalPrice = Movie.Price * Count;
            });
            NextPlacesButtonClickCommand = new RelayCommand((obj) =>
            {
                if (Count > 0)
                {
                    SessionVisibility = Visibility.Hidden;
                    PlacesVisibility = Visibility.Visible;
                }
                MessageBox.Show("You have to choose count of person(people)");
            });

            SeatPlaceClickCommand = new RelayCommand((obj) =>
            {
                counter++;
                if (obj is ToggleButton button)
                {
                    button.IsChecked = !button.IsChecked;
                    // Get the row and seat number
                    int row = Grid.GetRow(button);
                    int column = Grid.GetColumn(button);
                }
                if (counter == Count)
                {
                    IsButtonEnable = false;
                }
                //ToggleButton clickedButton = (ToggleButton)obj;
                //int row = Grid.GetRow(clickedButton);
                //int column = Grid.GetColumn(clickedButton);
            });
        }
    }
}
