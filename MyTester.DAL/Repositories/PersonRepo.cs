using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Abstract;
using Domain;
using MyTester.DAL;
using MyTester.Domain;

namespace DAL.Repositories
{
    public class PersonRepo:IPersonRepo
    {
        public MyContext _db;

        public PersonRepo(MyContext context)
        {
            _db = context;
        }

        public void Add(Person person)
        {
            _db.PersonSet.Add(person);
            _db.SaveChanges();
        }

        public List<Person> GetAll()
        {
            var result = _db.PersonSet.Include(e => e.PersonsAnswers).ToList();
            return result;
        }


    }
}
