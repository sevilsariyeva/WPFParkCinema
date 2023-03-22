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
    public class ScheduleRepository
    {
        public List<MovieSchedule> MovieSchedules { get; set; }

        public ScheduleRepository()
        {
            if (!File.Exists("movieSchedule.json"))
            {
                MovieSchedules = new List<MovieSchedule>
                {
                    new MovieSchedule
                    {
                        Id=1,
                        MovieName="Shazam! Fury of the Gods",
                        MovieDate=new DateTime(2023, 3, 28).ToShortDateString().ToString(),
                        MovieDateTime=new DateTime(2023,3,28,15,0,0).ToShortTimeString().ToString(),
                        Theater="Deniz Mall",
                        Price=9,
                        Duration=TimeSpan.FromMinutes(136)
                    },
                    new MovieSchedule
                    {
                        Id=2,
                        MovieName="Forever",
                        MovieDate=new DateTime(2023, 3, 28).ToShortDateString().ToString(),
                        MovieDateTime=new DateTime(2023,3,28,13,0,0).ToShortTimeString().ToString(),
                        Theater="Deniz Mall",
                        Price=10,
                        Duration=TimeSpan.FromMinutes(136)
                    },
                    new MovieSchedule
                    {
                        Id=3,
                        MovieName="Forever",
                        MovieDate=new DateTime(2023, 3, 29).ToShortDateString().ToString(),
                        MovieDateTime=new DateTime(2023,3,28,15,0,0).ToShortTimeString().ToString(),
                        Theater="28 Mall",
                        Price=10,
                        Duration=TimeSpan.FromMinutes(136)
                    },
                    new MovieSchedule
                    {
                        Id=4,
                        MovieName="Forever",
                        MovieDate=new DateTime(2023, 3, 30).ToShortDateString().ToString(),
                        MovieDateTime=new DateTime(2023,3,28,15,0,0).ToShortTimeString().ToString(),
                        Theater="Ganjlik Mall",
                        Price=10,
                        Duration=TimeSpan.FromMinutes(136)
                    },
                    new MovieSchedule
                    {
                        Id=5,
                        MovieName="Shazam! Fury of the Gods",
                        MovieDate=new DateTime(2023, 3, 28).ToShortDateString().ToString(),
                        MovieDateTime=new DateTime(2023,3,28,15,0,0).ToShortTimeString().ToString(),
                        Theater="28 Mall",
                        Price=9,
                        Duration=TimeSpan.FromMinutes(136)
                    },
                    new MovieSchedule
                    {
                        Id=6,
                        MovieName="Shazam! Fury of the Gods",
                        MovieDate=new DateTime(2023, 3, 25).ToShortDateString().ToString(),
                        MovieDateTime=new DateTime(2023,3,25,18,0,0).ToShortTimeString().ToString(),
                        Theater="Ganjlik Mall",
                        Price=9,
                        Duration=TimeSpan.FromMinutes(136)
                    },
                    new MovieSchedule
                    {
                        Id=7,
                        MovieName="The LockSmith",
                        MovieDate=new DateTime(2023, 3, 25).ToShortDateString().ToString(),
                        MovieDateTime=new DateTime(2023,3,23,15,0,0).ToShortTimeString().ToString(),
                        Theater="28 Mall",
                        Price=10,
                        Duration=TimeSpan.FromMinutes(136)
                    }
                };
                FileHelper.WriteMovieSchedule(MovieSchedules);
            }
            
        }
    }
}
