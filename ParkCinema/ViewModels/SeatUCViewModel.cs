using ParkCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public SeatUCViewModel()
        {

        }
    }
}
