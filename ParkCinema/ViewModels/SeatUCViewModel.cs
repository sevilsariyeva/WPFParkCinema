using ParkCinema.Commands;
using ParkCinema.Models;
using ParkCinema.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand OrderCommand { get; set; }
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

        public List<int> SelectedRows { get; set; } = new List<int> { };
        public List<int> SelectedColumns { get; set; } = new List<int> { };

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
        private string emailname;

        public string EmailName
        {
            get { return emailname; }
            set { emailname = value; OnPropertyChanged(); }
        }

        private string userPassword;

        public string Password
        {
            get { return userPassword; }
            set
            {
                userPassword = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        static int m = 0;
        static int n = 0;
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
            CloseCommand = new RelayCommand((obj) =>
            {
                App.MyGrid.Children.RemoveAt(1);

            });
            OrderCommand = new RelayCommand((obj) =>
            {
                
                foreach (var item in App.EmailRepo.Emails)
                {
                    if(item.UserEmail==EmailName && item.UserPassword == Password.ToString())
                    {
                        
                        for (int i = 0; i < Count; i++)
                        {
                            var uc = new TicketUC();
                            uc.Margin = new Thickness(n,0,0,0);
                            n += 140;
                            var vm = new TicketUCViewModel();
                            vm.Movie = Movie;
                            foreach (var img in App.MovieRepo.Movies)
                            {
                                if (Movie.MovieName == img.MovieName)
                                {
                                    vm.ImagePath = img.ImagePath;
                                    break;
                                }
                            }
                            vm.SelectedRow = SelectedRows[m];
                            vm.SelectedColumn = SelectedColumns[m];
                            uc.DataContext = vm;
                            App.MyGrid.Children.Add(uc);
                            m++;
                        }
                        
                        MailMessage mail = new MailMessage();
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");

                        mail.From = new MailAddress("vstudio7377@gmail.com");
                        mail.To.Add(EmailName);
                        //mail.Subject = Subject;
                        //mail.Body = Body;

                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential("vstudio7377@gmail.com", "vbsqxayxsgjktzbn");
                        smtp.EnableSsl = true;

                        //smtp.Send(mail);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Email or Password!");
                    }
                }
                //if (Email != null)
                //{
                //    if (!Email.Contains("@gmail.com"))
                //    {
                //        MessageBox.Show("You can only add Gmail!");
                //    }
                //}
                //if (Password.Length < 8)
                //{
                //    MessageBox.Show("Password Length must be greater than or equal to 8");
                //}
                //else if (!Password.ToString().Any(char.IsUpper))
                //{ 
                //    MessageBox.Show("Password must contain at least one uppercase letter!");
                //}
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
                            SelectedRows.Add(SelectedRow);
                            SelectedColumns.Add(SelectedColumn);
                            break;
                        }
                    }
                }
            });
        }
    }
}

