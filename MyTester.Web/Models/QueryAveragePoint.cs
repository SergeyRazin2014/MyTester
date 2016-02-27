using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTester.Domain;

namespace MyTester.Models
{
    public class QueryAveragePoint
    {
        public Query Query { get; set; }
        public double AveragePoint { get; set; }
    }
}