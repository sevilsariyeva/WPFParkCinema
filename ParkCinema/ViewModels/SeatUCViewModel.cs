using ParkCinema.Commands;
using ParkCinema.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace ParkCinema.ViewModels
{
    public class SeatUCViewModel : BaseViewModel
    {
        public RelayCommand SelectedCommand { get; set; }
        public RelayCommand NextPlacesButtonClickCommand { get; set; }
        public RelayCommand BackSessionButtonClickCommand { get; set; }
        public RelayCommand BackPlacesButtonClickCommand { get; set; }
        public RelayCommand NextPaymentButtonClickCommand { get; set; }
        public RelayCommand PlaceClickCommand { get; set; }
        public List<int> Numbers { get; set; } = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private MovieSchedule movie;
        private int count;
        private Visibility sessionVisibility;
        private Visibility placesVisibility;
        private Visibility paymentVisibility;
        private string sessionBackground;
        private string placesBackground;
        private string paymentBackground;
        private bool isButtonEnabled;
        private decimal totalprice;
        static int counter = 0;
        private string seat;



        public MovieSchedule Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }
        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged(); }
        }
        public Visibility SessionVisibility
        {
            get { return sessionVisibility; }
            set { sessionVisibility = value; OnPropertyChanged(); }
        }
        public Visibility PlacesVisibility
        {
            get { return placesVisibility; }
            set { placesVisibility = value; OnPropertyChanged(); }
        }
        public Visibility PaymentVisibility
        {
            get { return paymentVisibility; }
            set { paymentVisibility = value; OnPropertyChanged(); }
        }
        public string SessionBackground
        {
            get { return sessionBackground; }
            set { sessionBackground = value; OnPropertyChanged(); }
        }
        public string PlacesBackground
        {
            get { return placesBackground; }
            set { placesBackground = value; OnPropertyChanged(); }
        }
        public string PaymentBackground
        {
            get { return paymentBackground; }
            set { paymentBackground = value; OnPropertyChanged(); }
        }
        public bool IsButtonEnabled
        {
            get { return isButtonEnabled; }
            set { isButtonEnabled = value; OnPropertyChanged(); }
        }
        public decimal TotalPrice
        {
            get { return totalprice; }
            set { totalprice = value; OnPropertyChanged(); }
        }
        private int row;

        public int SelectedRow
        {
            get { return row; }
            set { row = value; OnPropertyChanged(); }
        }
        private int column;

        public int SelectedColumn
        {
            get { return column; }
            set { column = value; OnPropertyChanged(); }
        }
        public string Seat
        {
            get { return seat; }
            set { seat = value; OnPropertyChanged(); }
        }
        private SecureString userPassword;

        public SecureString Password
        {
            get { return userPassword; }
            set
            {
                userPassword = value;
                OnPropertyChanged(nameof(Password));

            }
        }


        public SeatUCViewModel()
        {
            SessionVisibility = Visibility.Visible;
            PlacesVisibility = Visibility.Hidden;
            PaymentVisibility = Visibility.Hidden;
            SessionBackground = "#7c2121";
            PlacesBackground = "Red";
            PaymentBackground = "Red";
            IsButtonEnabled = true;
            SelectedCommand = new RelayCommand((obj) =>
            {
                IsButtonEnabled = true;
                var count = obj;
                Count = (int)count;
                if (Count > 0)
                {
                    TotalPrice = Movie.Price * Count;
                }
                
            });
            NextPlacesButtonClickCommand = new RelayCommand((obj) =>
            {
                if (Count > 0)
                {
                    SessionVisibility = Visibility.Hidden;
                    PlacesVisibility = Visibility.Visible;
                    SessionBackground = "Red";
                    PlacesBackground = "#7c2121";
                }
                else
                {
                    MessageBox.Show("You have to choose count of person(people)");
                }
            });
            NextPaymentButtonClickCommand = new RelayCommand((obj) =>
            {
                if (IsButtonEnabled == false)
                {
                    SessionVisibility = Visibility.Hidden;
                    PlacesVisibility = Visibility.Hidden;
                    PaymentVisibility = Visibility.Visible;
                    SessionBackground = "Red";
                    PlacesBackground = "Red";
                    PaymentBackground = "#7c2121";
                }
                else
                {
                    MessageBox.Show("Place quantity must equal the number of tickets you've specified");
                }
            });
            BackSessionButtonClickCommand = new RelayCommand((obj) =>
            {
                if (Count > 0)
                {
                    SessionVisibility = Visibility.Visible;
                    PlacesVisibility = Visibility.Hidden;
                    PlacesBackground = "Red";
                    SessionBackground = "#7c2121";
                }
            });
            BackPlacesButtonClickCommand = new RelayCommand((obj) =>
            {
                if (Count > 0)
                {
                    PlacesVisibility = Visibility.Visible;
                    PaymentVisibility = Visibility.Hidden;
                    PlacesBackground = "#7c2121";
                    PaymentBackground = "Red";
                }

            });

            PlaceClickCommand = new RelayCommand((obj) =>
            {

                if (counter + 1 < Count)
                {
                    counter++;
                }
                else if (counter + 1 == Count)
                {
                    counter++;
                    IsButtonEnabled = false;
                }
                else
                {
                    IsButtonEnabled = false;
                    return;
                }
                Grid grid = obj as Grid;
                if (grid == null) return;

                foreach (UIElement child in grid.Children)
                {
                    ToggleButton toggleButton = child as ToggleButton;
                    if (toggleButton != null)
                    {
                        if (toggleButton.IsChecked == true && toggleButton.Name != "Checked")
                        {
                            SelectedRow = Grid.GetRow(toggleButton);
                            SelectedColumn = Grid.GetColumn(toggleButton);
                            if (SelectedRow == 0)
                            {
                                SelectedColumn++;
                            }
                            else if (SelectedRow > 0 && SelectedRow < 11)
                            {
                                SelectedColumn--;
                            }
                            else
                            {
                                SelectedColumn -= 2;
                            }
                            SelectedRow = Math.Abs(SelectedRow - 12);
                            Seat += " Row - ";
                            Seat += SelectedRow;
                            Seat += " Seat - ";
                            Seat += SelectedColumn;
                            if (counter == Count)
                            {
                                Seat += ".";
                            }
                            else
                            {
                                Seat += ",";
                            }
                            toggleButton.Name = "Checked";
                            break;
                        }
                    }
                }
            });
        }
    }
}

