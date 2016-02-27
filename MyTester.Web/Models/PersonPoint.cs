using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTester.Domain;

namespace MyTester.Models
{
    public class PersonPoint
    {
        public Query Query { get; set; }

        public Person Person { get; set; }

        public double Point { get; set; }
    }
}