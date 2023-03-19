using ParkCinema.Helpers;
using ParkCinema.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkCinema.Repositories
{
    public class MovieRepository
    {
        public List<Movie> Movies { get; set; }

        public MovieRepository()
        {
            if (!File.Exists("movies.json"))
            {
                Movies = new List<Movie>
                {
                   new Movie{
                Id=1,
                MovieName="Shazam! Fury of the Gods",
                MovieDate="Since 16 March",
                MovieFormat="2D",
                MovieLanguages="TR EN RU",
                Age="12+",
                ImagePath="/images/shazam.jpg",
                MovieCondition="today",
                MovieLink="https://www.youtube.com/watch?v=Zi88i4CpHe4"
            },
            new Movie{
                Id=2,
                MovieName="Forever",
                MovieDate="Since 16 March",
                MovieFormat="2D",
                MovieLanguages="EN TR",
                Age="16+",
                ImagePath="/images/foreverCover.jpg",
                MovieCondition="today",
                MovieLink="https://www.youtube.com/watch?v=-JmVnyJ16d4"
            },
            new Movie{
                Id=3,
                MovieName="The LockSmith",
                MovieDate="Since 16 March",
                MovieFormat="2D",
                MovieLanguages="RU",
                Age="16+",
                ImagePath="/images/theLockSmith.jpg",
                MovieCondition="today",
                MovieLink="https://www.youtube.com/watch?v=tfAg2ylTqPo"
            },
            new Movie{
                Id=4,
                MovieName="Epic Tales",
                MovieDate="Since 16 March",
                MovieFormat="2D",
                MovieLanguages="RU",
                Age="6+",
                ImagePath="/images/epicTales.jpg",
                MovieCondition="today",
                MovieLink="https://www.youtube.com/watch?v=UzHilzZX7iw"
            },
            new Movie{
                Id=5,
                MovieName="Evdə qalmış",
                MovieDate="Since 10 March",
                MovieFormat="2D",
                MovieLanguages="AZ",
                Age="12+",
                ImagePath="/images/evdeCover.jpg",
                MovieCondition="today",
                MovieLink="https://www.youtube.com/watch?v=3E6cjO5kcco"
            },
            new Movie{
                Id=6,
                MovieName="Scream 6",
                MovieDate="Since 9 March",
                MovieFormat="2D",
                MovieLanguages="RU EN",
                Age="18+",
                ImagePath="/images/scream.jpg",
                MovieCondition="today",
                MovieLink="https://www.youtube.com/watch?v=h74AXqw4Opc"
            },
            new Movie{
                Id=7,
                MovieName="65",
                MovieDate="Since 16 March",
                MovieFormat="2D",
                MovieLanguages="EN RU",
                Age="16+",
                ImagePath="/images/65.jpg",
                MovieCondition="today",
                MovieLink="https://www.youtube.com/watch?v=bHXejJq5vr0"
            },
            new Movie{
                Id=8,
                MovieName="Uçuş 811",
                MovieDate="Since 9 March",
                MovieFormat="2D",
                MovieLanguages="TR",
                Age="16+",
                ImagePath="/images/uchush811.jpg",
                MovieCondition="today",
                MovieLink="https://www.youtube.com/watch?v=0ic2a3QztYc"
            },
            new Movie{
                Id=9,
                MovieName="Cocaine Bear",
                MovieDate="Since 23 February",
                MovieFormat="2D",
                MovieLanguages="RU",
                Age="18+",
                ImagePath="/images/cocaineBear.jpg",
                MovieCondition="today",
                MovieLink="https://www.youtube.com/watch?v=DuWEEKeJLMI"
            },
            new Movie{
                Id=10,
                MovieName="Ant-Man and the Wasp: Quantumania",
                MovieDate="Since 16 February",
                MovieFormat="3D / 2D",
                MovieLanguages="RU TR",
                Age="12+",
                ImagePath="/images/antMan.jpg",
                MovieCondition="today",
                MovieLink="https://www.youtube.com/watch?v=5WfTEZJnv_8"
            },
            new Movie{
                Id=11,
                MovieName="Prestij Meselesi",
                MovieDate="Since 3 February",
                MovieFormat="2D",
                MovieLanguages="TR",
                Age="12+",
                ImagePath="/images/prestijCover.png",
                MovieCondition="today",
                MovieLink="https://www.youtube.com/watch?v=zaLV0-2WqEs"
            },
            new Movie{
                Id=12,
                MovieName="Gifted",
                MovieDate="Since 2 February",
                MovieFormat="2D",
                MovieLanguages="EN TR",
                Age="6+",
                ImagePath="/images/giftedCover.jpg",
                MovieCondition="today",
                MovieLink="https://www.youtube.com/watch?v=tI01wBXGHUs"
            },
            new Movie{
                Id=13,
                MovieName="Passengers",
                MovieDate="Since 28 January",
                MovieFormat="2D",
                MovieLanguages="EN RU TR",
                Age="16+",
                ImagePath="/images/passengersCover.jpg",
                MovieCondition="today",
                MovieLink="https://www.youtube.com/watch?v=BJWR0io_SuE"
            },
            new Movie{
                Id=14,
                MovieName="A Beautiful Mind",
                MovieDate="Since 26 January",
                MovieFormat="2D",
                MovieLanguages="EN TR",
                Age="16+",
                ImagePath="/images/abeautifulmindCover.jpg",
                MovieCondition="today",
                MovieLink="https://www.youtube.com/watch?v=9wZM7CQY130"
            },
            new Movie{
                Id=15,
                MovieName="Chernobyl",
                MovieDate="Since 23 January",
                MovieFormat="2D",
                MovieLanguages="EN RU TR",
                Age="16+",
                ImagePath="/images/chernobyl.jpg",
                MovieCondition="today",
                MovieLink="https://www.youtube.com/watch?v=s9APLXM9Ei8"
            },
            new Movie{
                Id=16,
                MovieName="Julia & Julie",
                MovieDate="From 22 March",
                MovieFormat="2D",
                MovieLanguages="EN TR",
                Age="16+",
                ImagePath="/images/julia.jpg",
                MovieCondition="soon",
                MovieLink="https://www.youtube.com/watch?v=ozRK7VXQl-k"
            },
            new Movie{
                Id=17,
                MovieName="Yedinci Koğuştaki Mucize",
                MovieDate="From 25 March",
                MovieFormat="2D",
                MovieLanguages="TR",
                Age="16+",
                ImagePath="/images/yedinci.jpg",
                MovieCondition="soon",
                MovieLink="https://www.youtube.com/watch?v=z_tgY9Nmo18"
            },
            new Movie{
                Id=18,
                MovieName="Bergen",
                MovieDate="From 28 March",
                MovieFormat="2D",
                MovieLanguages="TR",
                Age="16+",
                ImagePath="/images/bergen.png",
                MovieCondition="soon",
                MovieLink="https://www.youtube.com/watch?v=dMsSORIgsOg"
            },
            new Movie{
                Id=19,
                MovieName="Wonder",
                MovieDate="From 28 March",
                MovieFormat="2D",
                MovieLanguages="EN TR",
                Age="6+",
                ImagePath="/images/wonder.jpg",
                MovieCondition="soon",
                MovieLink="https://www.youtube.com/watch?v=Ob7fPOzbmzE"
            },
             new Movie{
                Id=20,
                MovieName="The Fault In Our Stars",
                MovieDate="From 1 April",
                MovieFormat="2D",
                MovieLanguages="EN TR",
                Age="16+",
                ImagePath="/images/thefault.jpg",
                MovieCondition="soon",
                MovieLink="https://www.youtube.com/watch?v=642lKXC97c4"
            }
                };
                FileHelper.WriteMovies(Movies);
            }
            else
            {
                Movies = FileHelper.ReadMovies();
            }
        }
    }
}
