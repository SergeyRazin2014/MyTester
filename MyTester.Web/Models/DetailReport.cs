using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTester.Domain;

namespace MyTester.Models
{
    public class DetailReport
    {
        public List<Person> AllPersons { get; set; }

        public List<QueryPoint> Row { get; set; }

        public List<PersonSumPoint> Summary { get; set; }  

        
    }
}