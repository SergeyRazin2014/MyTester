using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Repositories;
using Domain;
using MyTester.DAL;
using MyTester.Domain;
using NUnit.Framework;
using NUnit.Framework.Constraints;


namespace Tests.IntegratedTests
{
    [TestFixture]
    class PersonRepoTests
    {


        private MyContext _db;

        [Test]
        public void AddPerson_Simple()
        {
            Person person = new Person();
            person.Surname = "Иванов";
            person.Firstname = "Иван";
            person.Patronymic = "Иванович";

            Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());

            _db = new MyContext(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            PersonRepo repo = new PersonRepo(_db);

            repo.Add(person);

            var res = repo.GetAll();

            Assert.AreEqual(1,res.Count);
        }
    }
}
