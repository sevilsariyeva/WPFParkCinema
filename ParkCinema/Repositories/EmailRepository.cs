using ParkCinema.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkCinema.Repositories
{
    public class EmailRepository
    {
        public List<Email> Emails { get; set; }

        public EmailRepository()
        {
            if (!File.Exists("emails.json"))
            {
                Emails = new List<Email>
                {
                    new Email
                    {
                        UserName="Sevil",
                        UserSurname="Sariyeva",
                        UserEmail="sevilsariyeva00@gmail.com",
                        UserPassword="sevsar2000"
                    }
                };
            }
        }
    }
}
