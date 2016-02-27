using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTester.Domain;

namespace MyTester.Models
{
    public class PersonAverage
    {
        public Person Person { get; set; }

        public double AveragePoint { get; set; }
    }
}