using ParkCinema.Models;
using ParkCinema.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ParkCinema.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public FakeRepo BackgroundRepository { get; set; }
        DispatcherTimer timer = new DispatcherTimer();
        private ObservableCollection<BackgroundImage> allBackgroundImages;

        public ObservableCollection<BackgroundImage> AllBackgroundImages
        {
            get { return allBackgroundImages; }
            set { allBackgroundImages = value; OnPropertyChanged(); }
        }

        private BackgroundImage image;

        public BackgroundImage BackImage
        {
            get { return image; }
            set { image = value; OnPropertyChanged(); }
        }

        private string path;
        public string Path
        {
            get { return path; }
            set { path = value; OnPropertyChanged(); }
        }
        int count = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            BackImage = AllBackgroundImages[count];
            if (count == 3)
            {
                count = 0;
            }
            else
            {
                count++;
            }
        }
        public MainViewModel()
        {
            BackgroundRepository = new FakeRepo();
            AllBackgroundImages = new ObservableCollection<BackgroundImage>(BackgroundRepository.GetAll());
            BackImage = AllBackgroundImages[count];
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
    }
}
