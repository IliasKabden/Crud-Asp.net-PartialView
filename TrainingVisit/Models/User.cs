using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingVisit.Models
{
    public class User
    {
        public int idUser { get; set; }
        public string NameUser { get; set; }
        public string Surname { get; set; }
        public DateTime UserBirthdate { get; set; }

        public string NameTrainig { get; set; }
    }
}