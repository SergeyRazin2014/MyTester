using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTester.Domain;

namespace DAL.Abstract
{
    public interface IPersonRepo
    {
        List<Person> GetAll();

        void Add(Person person);
    }
}
