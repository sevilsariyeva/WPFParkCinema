using ParkCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkCinema.ViewModels
{
    public class BackgroundImageViewModel:BaseViewModel
    {
		private BackgroundImage image;

		public BackgroundImage backImage
		{
			get { return image; }
			set { image = value; }
		}

	}
}
