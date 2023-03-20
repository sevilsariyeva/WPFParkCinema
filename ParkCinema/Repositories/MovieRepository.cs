﻿using ParkCinema.Helpers;
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
                ImagePath="/images/shazamCover.jpg",
                MovieCondition="today",
                MovieCountry="USA",
                MovieDirector="David F. Sandberg",
                MovieGenre="Fantasy, Action, Thriller, Comedy, Crime, Adventure",
                MovieActors="Grace Caroline Currey Zachary Levi Helen Mirren",
                About="The film continues the story of teenage Billy Batson who, upon reciting the magic word \"SHAZAM!\" is transformed into his adult Super Hero alter ego, Shazam.",
                MovieDuration="02:10:00",
                MovieYear=2022,
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
                MovieCountry="USA",
                MovieDirector="Matthew Miller",
                MovieGenre="Crime, Drama, Fantasy, Mystery, Sci-Fi",
                MovieActors="Ioan GruffuddAlana De La GarzaJoel David Moore",
                About="A 200-year-old man works in the New York City Morgue trying to find a key to unlock the curse of his immortality.",
                MovieDuration="02:10:00",
                MovieYear=2014,
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
                MovieCountry="USA",
                MovieDirector="Nicolas Harvard",
                MovieGenre="Action, Mystery, Thriller",
                MovieActors="Kate Bosworth Ryan Phillippe Jeffrey Nordling",
                About="A thief fresh out of prison, tries to work his way back into the life of his daughter and ex-fiancé. Determined, he is forced to use the skills he has as a gifted locksmith. Things take a tumultuous turn after an unexpected disappearance.",
                MovieDuration="01:40:00",
                MovieYear=2023,
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
                MovieCountry="USA",
                MovieDirector="David Alaux, Eric Tosti, Jean-François Tosti",
                MovieGenre="Animation, Adventure, Comedy",
                MovieActors="Kate Bosworth Ryan Phillippe Jeffrey Nordling",
                About="Life in Yolcos, a beautiful and prosperous port city in ancient Greece, is peaceful until the population is threatened by the wrath of Poseidon. A young, adventurous mouse and the cat who adopted her help the aged Jason and his Argonauts in their quest to save the city.",
                MovieDuration="01:40:00",
                MovieYear=2023,
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
                MovieCountry="Azerbaijan",
                MovieDirector="Valeh Ahmadov",
                MovieGenre="Romantic comedy",
                MovieActors="Kəmalə Piriyeva Şəhriyar Əbilov Həmidə Ömərova Mehriban Xanlarova Sanura Cəfərova Kənan Yusif",
                About="Ruslan and Sevda must get married by the age of 30 by the compulsion of their parents. “You are spinster”, “when do you move, baby?” young people who are tired of their words as such do not want to get married, but events confront them. Will they spend their 30s as single or married? How will the way they choose to get rid of the word ” spinster ” change their lives?",
                MovieDuration="01:40:00",
                MovieYear=2023,
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
                MovieCountry="USA",
                MovieDirector="Matt Bettinelli-Olpin, Tyler Gillett",
                MovieGenre="Horror, Mystery, Thriller",
                MovieActors="Melissa Barrera Jenna Ortega Courteney Cox",
                About="In the next installment, the survivors of the Ghostface killings leave Woodsboro behind and start a fresh chapter in New York City.",
                MovieDuration="02:10:00",
                MovieYear=2023,
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
                MovieCountry="USA",
                MovieDirector="Scott Beck, Bryan Woods",
                MovieGenre="Adventure, Drama, Sci-Fi",
                MovieActors="Adam Driver Ariana Greenblatt Chloe Coleman",
                About="An astronaut crash lands on a mysterious planet only to discover he's not alone.",
                MovieDuration="01:40:00",
                MovieYear=2023,
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
                MovieCountry="Turkey",
                MovieDirector="Hakan Kerim Karademir",
                MovieGenre="Drama",
                MovieActors="Burcu Kara Emre Karayel Yosi Mizrahi",
                About="Follows the story of Azra and Cengiz, a couple who take a precious stone worth $2 million to auction in the USA, on the plane number 811. A distrustful death on the plane from Istanbul to New York changes the fate of all passengers.",
                MovieDuration="01:40:00",
                MovieYear=2023,
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
                MovieCountry="USA",
                MovieDirector="Elizabeth Banks",
                MovieGenre="Comedy, Thriller",
                MovieActors="Keri RussellAlden Ehrenreich O'Shea Jackson Jr",
                About="An oddball group of cops, criminals, tourists and teens converge on a Georgia forest where a huge black bear goes on a murderous rampage after unintentionally ingesting cocaine.",
                MovieDuration="01:40:00",
                MovieYear=2023,
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
                MovieCountry="USA",
                MovieDirector="Peyton Reed",
                MovieGenre="Action, Adventure, Comedy",
                MovieActors="Kathryn Newton Jonathan Majors Evangeline Lilly",
                About="Scott Lang and Hope Van Dyne, along with Hank Pym and Janet Van Dyne, explore the Quantum Realm, where they interact with strange creatures and embark on an adventure that goes beyond the limits of what they thought was possible.",
                MovieDuration="02:10:00",
                MovieYear=2022,
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
                MovieCountry="Turkey",
                MovieDirector="Mahsun Kırmızıgül",
                MovieGenre="Drama",
                MovieActors="Biran Damla Yilmaz Melisa Döngel Erkan Petekkaya",
                About="Film tells the story of the legendary music label in the 1990s, where Mahsun and many other stars like Özcan Deniz became superstars.",
                MovieDuration="02:10:00",
                MovieYear=2023,
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
                MovieCountry="USA",
                MovieDirector="Marc Webb",
                MovieGenre="Drama",
                MovieActors="Chris Evans Mckenna Grace Lindsay Duncan",
                About="Frank, a single man raising his child prodigy niece Mary, is drawn into a custody battle with his mother.",
                MovieDuration="02:10:00",
                MovieYear=2017,
                MovieLink="https://www.youtube.com/watch?v=tI01wBXGHUs"
            },
            new Movie{
                Id=13,
                MovieName="Kutsal Damacana 4",
                MovieDate="Since 26 January",
                MovieFormat="2D",
                MovieLanguages="TR",
                Age="16+",
                ImagePath="/images/kutsalCover.jpg",
                MovieCondition="today",
                MovieCountry="Turkey",
                MovieDirector="Kamil Çetin",
                MovieGenre="Comedy",
                MovieActors="Şafak Sezer Ersin Korkut Onur Böyüktopçu Müjde Uzman",
                About="It tells the story of Fikret, who accidentally becomes a priest. Fikret finds himself in an unpredictable position on the priesthood path he accidentally entered. Unexpectedly rising to the Vatican, Fikret now decides to return to his homeland.",
                MovieDuration="01:40:00",
                MovieYear=2023,
                MovieLink="https://www.youtube.com/watch?v=HphAPON03o8"
            },
            new Movie{
                Id=14,
                MovieName="Passengers",
                MovieDate="Since 26 January",
                MovieFormat="2D",
                MovieLanguages="EN RU TR",
                Age="16+",
                ImagePath="/images/passengersCover.jpg",
                MovieCondition="today",
                MovieCountry="USA",
                MovieDirector="Morten Tyldum",
                MovieGenre="Science Fiction , Drama, Thriller, Adventure, Romance",
                MovieActors="Jennifer Lawrence Chris Pratt Michael Sheen Laurence Fishburne Andy García",
                About="A malfunction in a sleeping pod on a spacecraft traveling to a distant colony planet wakes one passenger 90 years early.",
                MovieDuration="02:30:00",
                MovieYear=2016,
                MovieLink="https://www.youtube.com/watch?v=BJWR0io_SuE"
            },
            new Movie{
                Id=15,
                MovieName="A Beautiful Mind",
                MovieDate="Since 24 January",
                MovieFormat="2D",
                MovieLanguages="EN TR",
                Age="16+",
                ImagePath="/images/abeautifulmindCover.jpg",
                MovieCondition="soon",
                MovieCountry="USA",
                MovieDirector="Ron Howard",
                MovieGenre="Biography, Drama",
                MovieActors="Akiva Goldsman Sylvia Nasar",
                About="After John Nash, a brilliant but asocial mathematician, accepts secret work in cryptography, his life takes a turn for the nightmarish.",
                MovieDuration="01:40:00",
                MovieYear=2001,
                MovieLink="https://www.youtube.com/watch?v=9wZM7CQY130"
            },
            new Movie{
                Id=16,
                MovieName="Chernobyl",
                MovieDate="Since 23 January",
                MovieFormat="2D",
                MovieLanguages="EN RU TR",
                Age="16+",
                ImagePath="/images/chernobyl.jpg",
                MovieCondition="today",
                MovieCountry="USA",
                MovieDirector="Craig Mazin",
                MovieGenre="Drama, History, Thriller",
                MovieActors="Jessie Buckley Jared Harris Stellan Skarsgård",
                About="In April 1986, an explosion at the Chernobyl nuclear power plant in the Union of Soviet Socialist Republics becomes one of the world's worst man-made catastrophes.",
                MovieDuration="01:10:00",
                MovieYear=2019,
                MovieLink="https://www.youtube.com/watch?v=s9APLXM9Ei8"
            },
            new Movie{
                Id=17,
                MovieName="Julia & Julie",
                MovieDate="From 22 March",
                MovieFormat="2D",
                MovieLanguages="EN TR",
                Age="16+",
                ImagePath="/images/julia.jpg",
                MovieCondition="soon",
                MovieCountry="USA",
                MovieDirector="Nora Ephron",
                MovieGenre="Biography, Drama, Romance",
                MovieActors="Amy Adams Meryl StreepChris Messina",
                About="Julia Child's story of her start in the cooking profession is intertwined with blogger Julie Powell's 2002 challenge to cook all the recipes in Child's first book.",
                MovieDuration="01:40:00",
                MovieYear=2009,
                MovieLink="https://www.youtube.com/watch?v=ozRK7VXQl-k"
            },
            new Movie{
                Id=18,
                MovieName="Yedinci Koğuştaki Mucize",
                MovieDate="From 25 March",
                MovieFormat="2D",
                MovieLanguages="TR",
                Age="16+",
                ImagePath="/images/yedinci.jpg",
                MovieCondition="soon",
                MovieCountry="USA",
                MovieDirector="Mehmet Ada Öztekin",
                MovieGenre="Drama",
                MovieActors="Aras Bulut Iynemli Nisa Sofiya Aksongur Deniz Baysal",
                About="A story of love between a mentally-ill father who was wrongly accused of murder and his lovely six year old daughter. Prison will be their home. Based on the 2013 Korean movie Miracle in Cell No. 7 (2013).",
                MovieDuration="01:40:00",
                MovieYear=2019,
                MovieLink="https://www.youtube.com/watch?v=z_tgY9Nmo18"
            },
            new Movie{
                Id=19,
                MovieName="Bergen",
                MovieDate="From 28 March",
                MovieFormat="2D",
                MovieLanguages="TR",
                Age="16+",
                ImagePath="/images/bergen.png",
                MovieCondition="soon",
                MovieCountry="USA",
                MovieDirector="Caner Alper Mehmet Binay",
                MovieGenre="Biography, Drama, Music",
                MovieActors="Farah Zeynep Abdullah Erdal Besikçioglu Sebnem Sönmez",
                About="Bergen, a valuable turkish arabesque singer, fights to stay afloat despite all the difficulties in her life.",
                MovieDuration="01:40:00",
                MovieYear=2023,
                MovieLink="https://www.youtube.com/watch?v=dMsSORIgsOg"
            },
            new Movie{
                Id=20,
                MovieName="Wonder",
                MovieDate="From 28 March",
                MovieFormat="2D",
                MovieLanguages="EN TR",
                Age="6+",
                ImagePath="/images/wonder.jpg",
                MovieCondition="soon",
                MovieCountry="USA",
                MovieDirector="Stephen Chbosky",
                MovieGenre="Drama, Family",
                MovieActors="Jacob Tremblay Owen Wilson Izabela Vidovic",
                About="Based on the New York Times bestseller, this movie tells the incredibly inspiring and heartwarming story of August Pullman, a boy with facial differences who enters the fifth grade, attending a mainstream elementary school for the first time.",
                MovieDuration="01:40:00",
                MovieYear=2017,
                MovieLink="https://www.youtube.com/watch?v=Ob7fPOzbmzE"
            },
             new Movie{
                Id=21,
                MovieName="The Fault In Our Stars",
                MovieDate="From 1 April",
                MovieFormat="2D",
                MovieLanguages="EN TR",
                Age="16+",
                ImagePath="/images/thefault.jpg",
                MovieCondition="soon",
                MovieCountry="USA",
                MovieDirector="Josh Boone",
                MovieGenre="Drama, Romance",
                MovieActors="Shailene Woodley Ansel ElgortNat Wolff",
                About="Two teenage cancer patients begin a life-affirming journey to visit a reclusive author in Amsterdam.",
                MovieDuration="01:40:00",
                MovieYear=2023,
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
