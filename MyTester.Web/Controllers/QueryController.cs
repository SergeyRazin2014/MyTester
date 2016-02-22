using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Abstract;

namespace MyTester.Controllers
{
    public class QueryController : Controller
    {
        private IQueryRepo _queryRepo;

        public QueryController(IQueryRepo queryRepo)
        {
            _queryRepo = queryRepo;
        }

        
        public ActionResult GetAll()
        {
            //отдать все вопросы с вариантами ответов

            var res = _queryRepo.GetAll();

            return Json(res, JsonRequestBehavior.AllowGet);

            
        }
    }
}