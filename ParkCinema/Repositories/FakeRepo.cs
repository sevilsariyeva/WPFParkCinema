using ParkCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkCinema.Repositories
{
    public class FakeRepo
    {
        
        public List<BackgroundImage> GetAll()
        {
            return new List<BackgroundImage>
            {
                new BackgroundImage{Id=1,MovieName="Kutsal Damacana 4",MovieDate="26 January", ImagePath="/images/kutsal.jpg"},
                new BackgroundImage{Id=2,MovieName="Prestij Meselesi",MovieDate="2 February",ImagePath="/images/prestij-cover.png"},
                new BackgroundImage{Id=3,MovieName="Evdə qalmış",MovieDate="9 February",ImagePath="/images/evde.jpg"},
                new BackgroundImage{Id=4,MovieName="Ant-Man and the Wasp: Quantumania",ImagePath="/images/ant-cover.png"},
            };
        }
    }
}
