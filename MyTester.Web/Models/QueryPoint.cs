using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTester.Domain;

namespace MyTester.Models
{
    public class QueryPoint
    {
        public Query Query { get; set; }

        public List<PersonPoint> PersonPointList { get; set; }
    }
}