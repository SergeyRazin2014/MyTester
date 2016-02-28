using MyTester.DAL;
using MyTester.Domain;
using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using MyTester.DAL.Repositories;

namespace MyTester.IntegratedTests.IntegratedTests
{
    [TestFixture]
    internal class PersonRepoTests
    {
        private MyContext _db;

        [SetUp]
        public void Start()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());
            _db = new MyContext(ConfigurationManager.ConnectionStrings[0].ConnectionString);
        }

        [TearDown]
        public void Finish()
        {
            if (Database.Exists(_db.Database.Connection.ConnectionString))
                _db.Database.Delete();
        }

        [Test]
        public void AddPerson_Simple()
        {
            Person person = new Person();
            person.Surname = "Иванов";
            person.Firstname = "Иван";
            person.Patronymic = "Иванович";

            PersonRepo repo = new PersonRepo(_db);

            repo.Add(person);

            var res = repo.GetAll();

            Assert.AreEqual(1, res.Count);
        }

        [Test]
        public void GetAll_WithPersonAnswers()
        {
            //-------вопросы--------------↓
            QueryRepo queryRepo = new QueryRepo(_db);

            var query1 = new Query();
            query1.Text = "Какую форму имеет планета земля";
            query1.Point = 1;
            var variant11 = new VariantAnsver();
            variant11.Text = "круг";
            var variant22 = new VariantAnsver();
            variant22.Text = "квадрат";
            var variant33 = new VariantAnsver();
            variant33.Text = "эллипсоид вращения";
            variant33.IsRight = true;
            query1.VariantsAnsver = new List<VariantAnsver>() { variant11, variant22, variant33 };

            queryRepo.Add(query1);

            var query2 = new Query();
            query2.Text = "К какому семейству относится арбуз";
            query2.Point = 2;
            var variant111 = new VariantAnsver();
            variant111.Text = "ягода";
            variant111.IsRight = true;
            var variant222 = new VariantAnsver();
            variant222.Text = "фрукт";
            var variant333 = new VariantAnsver();
            variant333.Text = "плотоядное животное";
            query2.VariantsAnsver = new List<VariantAnsver>() { variant111, variant222, variant333 };

            queryRepo.Add(query2);

            var query3 = new Query();
            query3.Text = "Какую цель преследовали США применив ядерное оружие проитв Японии?";
            query3.Point = 3;
            var variant1111 = new VariantAnsver();
            variant1111.Text = "Сохранить жизни людей";
            var variant2222 = new VariantAnsver();
            variant2222.Text = "Напугать СССР";
            variant2222.IsRight = true;
            var variant3333 = new VariantAnsver();
            variant3333.Text = "Испытать новое оружие";
            variant3333.IsRight = true;
            query3.VariantsAnsver = new List<VariantAnsver>() { variant1111, variant2222, variant3333 };

            queryRepo.Add(query3);
            //-------вопросы--------------↑

            //--------пользователь с ответами↓
            Person pers1 = new Person();
            pers1.Surname = "фамилия1";
            pers1.Firstname = "имя1";
            pers1.Patronymic = "отчество1";

            PersonsAnswers personAnswers1 = new PersonsAnswers();
            personAnswers1.PersonId = pers1.Id;
            personAnswers1.Query = query1;
            personAnswers1.VariantAnsver = variant11;

            PersonsAnswers personAnswers2 = new PersonsAnswers();
            personAnswers2.PersonId = pers1.Id;
            personAnswers2.Query = query2;
            personAnswers2.VariantAnsver = variant111;

            pers1.PersonsAnswers = new List<PersonsAnswers>() { personAnswers1, personAnswers2 };

            PersonRepo personRepo = new PersonRepo(_db);
            personRepo.Add(pers1);
            //--------пользователь с ответами↑

            var resultPerosn = personRepo.GetAll();

            Assert.AreEqual(1, resultPerosn.Count);

            Assert.AreEqual(2, resultPerosn.First().PersonsAnswers.Count);
        }

        [Test]
        public void ClearResult_Test()
        {
            //-------вопросы--------------↓
            QueryRepo queryRepo = new QueryRepo(_db);

            var query1 = new Query();
            query1.Text = "Какую форму имеет планета земля";
            query1.Point = 1;
            var variant11 = new VariantAnsver();
            variant11.Text = "круг";
            var variant22 = new VariantAnsver();
            variant22.Text = "квадрат";
            var variant33 = new VariantAnsver();
            variant33.Text = "эллипсоид вращения";
            variant33.IsRight = true;
            query1.VariantsAnsver = new List<VariantAnsver>() { variant11, variant22, variant33 };

            queryRepo.Add(query1);

            var query2 = new Query();
            query2.Text = "К какому семейству относится арбуз";
            query2.Point = 2;
            var variant111 = new VariantAnsver();
            variant111.Text = "ягода";
            variant111.IsRight = true;
            var variant222 = new VariantAnsver();
            variant222.Text = "фрукт";
            var variant333 = new VariantAnsver();
            variant333.Text = "плотоядное животное";
            query2.VariantsAnsver = new List<VariantAnsver>() { variant111, variant222, variant333 };

            queryRepo.Add(query2);

            var query3 = new Query();
            query3.Text = "Какую цель преследовали США применив ядерное оружие проитв Японии?";
            query3.Point = 3;
            var variant1111 = new VariantAnsver();
            variant1111.Text = "Сохранить жизни людей";
            var variant2222 = new VariantAnsver();
            variant2222.Text = "Напугать СССР";
            variant2222.IsRight = true;
            var variant3333 = new VariantAnsver();
            variant3333.Text = "Испытать новое оружие";
            variant3333.IsRight = true;
            query3.VariantsAnsver = new List<VariantAnsver>() { variant1111, variant2222, variant3333 };

            queryRepo.Add(query3);
            //-------вопросы--------------↑

            //--------пользователь с ответами↓
            Person pers1 = new Person();
            pers1.Surname = "фамилия1";
            pers1.Firstname = "имя1";
            pers1.Patronymic = "отчество1";

            PersonsAnswers personAnswers1 = new PersonsAnswers();
            personAnswers1.PersonId = pers1.Id;
            personAnswers1.Query = query1;
            personAnswers1.VariantAnsver = variant11;

            PersonsAnswers personAnswers2 = new PersonsAnswers();
            personAnswers2.PersonId = pers1.Id;
            personAnswers2.Query = query2;
            personAnswers2.VariantAnsver = variant111;

            pers1.PersonsAnswers = new List<PersonsAnswers>() { personAnswers1, personAnswers2 };

            PersonRepo personRepo = new PersonRepo(_db);
            personRepo.Add(pers1);
            //--------пользователь с ответами↑

            var resultPerosn = personRepo.GetAll();

            Assert.AreEqual(1, resultPerosn.Count);

            Assert.AreEqual(2, resultPerosn.First().PersonsAnswers.Count);

            personRepo.ClearResult();

            var res = personRepo.GetAll();

            Assert.AreEqual(0,res.First().PersonsAnswers.Count);
        }
    }
}