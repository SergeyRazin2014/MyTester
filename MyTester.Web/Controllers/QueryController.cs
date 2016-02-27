using DAL.Abstract;
using MyTester.Infrastructure;
using System.Web.Mvc;

namespace MyTester.Controllers
{
    public class QueryController : Controller
    {
        private IQueryRepo _queryRepo;
        private IPersonRepo _personRepo;

        public QueryController(IQueryRepo queryRepo, IPersonRepo perosnRepo)
        {
            _queryRepo = queryRepo;
            _personRepo = perosnRepo;
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

            var res = new QueryHelper().GetSummaryReportInfo(allQuerys, allPersons);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPersonAverageReport()
        {
            var allPersons = _personRepo.GetAll();
            var allQuerys = _queryRepo.GetAll();

            var res = new QueryHelper().GetPersonAverageList(allPersons, allQuerys);

            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}