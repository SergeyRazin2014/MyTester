using DAL.Abstract;
using MyTester.Domain;
using System;
using System.Web.Mvc;

namespace MyTester.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepo _personRepo;

        public PersonController(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        public void SavePersonsExam(Person person)
        {
            _personRepo.Add(person);
        }

        public ActionResult GetAll()
        {
            var res = _personRepo.GetAll();

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPersonsWithRightAnswers()
        {
            throw new NotImplementedException();
        }
    }
}