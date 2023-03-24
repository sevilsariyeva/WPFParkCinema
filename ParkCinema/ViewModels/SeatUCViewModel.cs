﻿using ParkCinema.Commands;
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

        private bool _isToggleButtonChecked;
        public bool IsToggleButtonChecked
        {
            get { return _isToggleButtonChecked; }
            set
            {
                if (_isToggleButtonChecked != value)
                {
                    _isToggleButtonChecked = value;
                    OnPropertyChanged(nameof(IsToggleButtonChecked));
                }
            }
        }

        private decimal totalprice;

        public decimal TotalPrice
        {
            get { return totalprice; }
            set { totalprice = value; OnPropertyChanged(); }
        }
        private int row;

        public int RowOrder
        {
            get { return row; }
            set { row = value; OnPropertyChanged(); }
        }

        public RelayCommand SelectedCommand { get; set; }
        public RelayCommand NextPlacesButtonClickCommand { get; set; }
        public RelayCommand PlaceClickCommand { get; set; }
        static int counter = 0;
        public SeatUCViewModel()
        {
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
                else
                {
                    MessageBox.Show("You have to choose count of person(people)");
                }
            });

            PlaceClickCommand = new RelayCommand((obj) =>
            {

                if (IsToggleButtonChecked == true)
                {
                    if (counter <= Count)
                    {
                        counter++;
                        IsToggleButtonChecked = !IsToggleButtonChecked;
                        //button.IsChecked = !button.IsChecked;
                        //int row = Grid.GetRow(button);
                        //int column = Grid.GetColumn(button);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    counter--;
                }
                RowOrder = counter;

            });
        }
    }
}
