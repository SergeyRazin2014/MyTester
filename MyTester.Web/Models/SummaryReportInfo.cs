using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTester.Models
{
    public class SummaryReportInfo
    {
        public int PersonCount { get; set; }

        public List<QueryAveragePoint> QueryAveragePointList { get; set; }
    }
}