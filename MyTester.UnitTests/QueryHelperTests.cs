using Domain;
using MyTester.Domain;
using MyTester.Infrastructure;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MyTester.UnitTests
{
    [TestFixture]
    public class QueryHelperTests
    {
        private Person person;
        private Query query1;
        private Query query2;

        [SetUp]
        public void Start()
        {
            //вопрос 1 и варианты ответа на этот вопрос
            query1 = new Query();
            query1.Id = 1;
            query1.Text = "Какую форму имеет планета земля";
            query1.Point = 1;
            var variant11 = new VariantAnsver();
            variant11.Id = 1;
            variant11.Text = "круг";
            var variant22 = new VariantAnsver();
            variant22.Id = 2;
            variant22.Text = "квадрат";
            var variant33 = new VariantAnsver();
            variant33.Id = 3;
            variant33.Text = "эллипсоид вращения";
            variant33.IsRight = true;
            query1.VariantsAnsver = new List<VariantAnsver>() { variant11, variant22, variant33 };

            //вопрос 2 и варианты ответа на этот ворпос
            query2 = new Query();
            query2.Id = 2;
            query2.Text = "К какому семейству относится арбуз";
            query2.Point = 2;
            var variant111 = new VariantAnsver();
            variant111.Text = "ягода";
            variant111.Id = 4;
            variant111.IsRight = true;
            var variant222 = new VariantAnsver();
            variant222.Id = 5;
            variant222.Text = "фрукт";
            var variant333 = new VariantAnsver();
            variant333.Id = 6;
            variant333.Text = "плотоядное животное";
            query2.VariantsAnsver = new List<VariantAnsver>() { variant111, variant222, variant333 };

            //пользователь
            person = new Person();
            person.Id = 1;
            person.Firstname = "Ivan";
            person.Surname = "Ivanow";
            person.Patronymic = "Ivanovich";
            person.PersonsAnswers = new List<PersonsAnswers>();

            //ответ пользователя на вопрос 1 (галочка)
            PersonsAnswers pa1 = new PersonsAnswers();
            pa1.PersonId = person.Id;
            pa1.Query = query1;
            pa1.VariantAnsver = variant33;

            //ответ пользователя на вопрос 2 (галочка)
            PersonsAnswers pa2 = new PersonsAnswers();
            pa2.PersonId = person.Id;
            pa2.Query = query2;
            pa2.VariantAnsver = variant111;

            //второй ответ пользователя на вопрос 2 (т.е. пользователь поставил 2 галочки при выборе ответа на этот ворпос)
            PersonsAnswers pa3 = new PersonsAnswers();
            pa3.PersonId = person.Id;
            pa3.Query = query2;
            pa3.VariantAnsver = variant222;


            person.PersonsAnswers.Add(pa1);
            person.PersonsAnswers.Add(pa2);
            person.PersonsAnswers.Add(pa3);
        }

        [Test]
        public void StartTest()
        {
            Assert.AreEqual(3, person.PersonsAnswers.Count);
            Assert.AreEqual("Какую форму имеет планета земля", person.PersonsAnswers.First().Query.Text);
        }

        [Test]
        public void IsPersonAnswersRight_MoreThenNeedVariant()
        {
            var queryHelper = new QueryHelper();
            var res = queryHelper.IsPersonAnswersRight(query2, person);

            Assert.IsFalse(res);
        }

        [Test]
        public void IsPersonAnswersRight_PersonAnswerCorrect()
        {
            var queryHelper = new QueryHelper();
            var res = queryHelper.IsPersonAnswersRight(query1, person);

            Assert.IsTrue(res);
        }

        [Test]
        public void GetPersonsAnswersByQuery_Test()
        {
            var queryHelper = new QueryHelper();
            var res = queryHelper.GetPersonsAnswersByQuery(query2, person);

            Assert.AreEqual(2, res.Count);
            Assert.IsNotNull(res.FirstOrDefault(e => e.VariantAnsver.Text == "ягода"));
            Assert.IsNotNull(res.FirstOrDefault(e => e.VariantAnsver.Text == "фрукт"));
        }

        [Test]
        public void GetAveragePointByQuery_OnePerosonAnswersRight()
        {
            var queryHelper = new QueryHelper();
            var res = queryHelper.GetAveragePointByQuery(query1, new List<Person>() { person });

            Assert.AreEqual(1, res);

        }

        [Test]
        public void GetAveragePointByQuery_noOnePersonAnswerRight()
        {
            var queryHelper = new QueryHelper();
            var res = queryHelper.GetAveragePointByQuery(query2, new List<Person>() { person });

            Assert.AreEqual(0, res);
        }

        [Test]
        public void GetSummaryReportInfo_Test()
        {
            var queryHelper = new QueryHelper();
            var res = queryHelper.GetSummaryReportInfo(new List<Query>() {query1, query2}, new List<Person>() {person});

            Assert.AreEqual(1,res.PersonCount);
            Assert.AreEqual(2,res.QueryAveragePointList.Count);
        }
    }
}