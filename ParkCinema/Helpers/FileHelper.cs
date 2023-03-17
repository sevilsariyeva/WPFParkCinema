using Newtonsoft.Json;
using ParkCinema.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace ParkCinema.Helpers
{
    public class FileHelper
    {
        public static void WriteMovies(List<Movie> movies)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter("movies.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, movies);
                }
            }
        }

        //public static void WriteStudents(List<Student> students)
        //{
        //    var serializer = new JsonSerializer();

        //    using (var sw = new StreamWriter("students.json"))
        //    {
        //        using (var jw = new JsonTextWriter(sw))
        //        {
        //            jw.Formatting = Formatting.Indented;
        //            serializer.Serialize(jw, students);
        //        }
        //    }
        //}

        //public static List<Student> ReadStudents()
        //{
        //    List<Student> students = null;
        //    var serializer = new JsonSerializer();
        //    using (var sr = new StreamReader("students.json"))
        //    {
        //        using (var jr = new JsonTextReader(sr))
        //        {
        //            students = serializer.Deserialize<List<Student>>(jr);
        //        }
        //    }
        //    return students;
        //}

        public static List<Movie> ReadMovies()
        {
            List<Movie> movies = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader("movies.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    movies = serializer.Deserialize<List<Movie>>(jr);
                }
            }
            return movies;
        }
    }
}
