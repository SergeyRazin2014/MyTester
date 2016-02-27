using System.Diagnostics;
using DAL.Abstract;
using MyTester.Infrastructure;
using System.Web.Mvc;

namespace MyTester.Controllers
{
    public class QueryController : Controller
    {
        private IQueryRepo _queryRepo;
        private IPersonRepo _personRepo;

        public QueryController(IQueryRepo queryRepo, IPersonRepo personRepo)
        {
            _queryRepo = queryRepo;
            _personRepo = personRepo;
        }

        public JsonResult GetAll()
        {
            var res = _queryRepo.GetAll();

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSummaryReportInfo()
        {
            var allPersons = _personRepo.GetAll();
            var allQuerys = _queryRepo.GetAll();

            var res = new ReportHelper().GetSummaryReportInfo(allQuerys, allPersons);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPersonAverageReport()
        {
            var allPersons = _personRepo.GetAll();
            var allQuerys = _queryRepo.GetAll();

            var res = new ReportHelper().GetPersonAverageList(allPersons, allQuerys);

            return Json(res, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetDetailReport()
        {
            var allPersons = _personRepo.GetAll();
            var allQuerys = _queryRepo.GetAll();

            var res = new ReportHelper().GetDetailReport(allPersons, allQuerys); 

            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}