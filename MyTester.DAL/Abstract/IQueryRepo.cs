using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTester.Domain;

namespace DAL.Abstract
{
    public interface IQueryRepo
    {
        List<Query> GetAll();

        void Add(Query query);
    }
}
