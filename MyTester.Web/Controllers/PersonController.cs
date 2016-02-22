using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Abstract;
using MyTester.Domain;

namespace MyTester.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepo _db;

        public PersonController(IPersonRepo db)
        {
            _db = db;
        }
        
        public void SavePersonsExam(Person person)
        {
            _db.Add(person);
        }
    }
}