﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Abstract;
using Domain;
using MyTester.Domain;
using MyTester.Models;

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

        public ActionResult GetAll()
        {
            var res = _db.GetAll();

            return Json(res,JsonRequestBehavior.AllowGet);
        }
    }
}