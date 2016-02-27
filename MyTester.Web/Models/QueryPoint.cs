using MyTester.Domain;
using System.Collections.Generic;

namespace MyTester.Models
{
    public class QueryPoint
    {
        public Query Query { get; set; }

        public List<PersonPoint> PersonPointList { get; set; }
    }
}