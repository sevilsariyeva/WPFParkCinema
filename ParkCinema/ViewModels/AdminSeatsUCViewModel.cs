using ParkCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkCinema.ViewModels
{
    public class AdminSeatsUCViewModel:BaseViewModel
    {
        private MovieSchedule movie;

        public MovieSchedule Movie
        {
            get { return movie; }
            set { movie = value;OnPropertyChanged(); }
        }

        public AdminSeatsUCViewModel()
        {

        }
    }
}
