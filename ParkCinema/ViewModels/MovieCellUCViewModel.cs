using ParkCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ParkCinema.ViewModels
{
    public class MovieCellViewModel : BaseViewModel
    {
        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set
            {
                movie = value;
                
                if (movie.MovieName.Length >= 30)
                {
                    movie.MovieName = movie.MovieName.Substring(0, 25);
                }
                OnPropertyChanged();
            }
        }

        public WrapPanel StarsPanel { get; set; }

        public MovieCellViewModel()
        {

        }

    }
}
