using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using MyTester.Domain;

namespace MyTester.Models
{
    public class PersonsQuerysAnswer
    {
        public Person Person { get; set; }
        public List<Query> PersonsAnswers { get; set; }
        
    }
}