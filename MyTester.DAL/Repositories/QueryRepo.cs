using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Abstract;
using Domain;
using MyTester.DAL;

namespace DAL.Repositories
{
    public class QueryRepo : IQueryRepo
    {
        private MyContext _db;

        public QueryRepo(MyContext db)
        {
            _db = db;
        }

        public void Add(Query query)
        {
            _db.QuerySet.Add(query);
            _db.SaveChanges();
        }

        public List<Query> GetAll()
        {
            var res = _db.QuerySet.Include("VariantsAnsver").ToList();
            return res;
        }
    }
}
