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
        private Person _person1;
        private Person _person2;
        private Query _query1;
        private Query _query2;

        [SetUp]
        public void Start()
        {
            //вопрос 1 и варианты ответа на этот вопрос
            _query1 = new Query();
            _query1.Id = 1;
            _query1.Text = "Какую форму имеет планета земля";
            _query1.Point = 1;
            var variant1 = new VariantAnsver();
            variant1.Id = 1;
            variant1.Text = "круг";
            var variant2 = new VariantAnsver();
            variant2.Id = 2;
            variant2.Text = "квадрат";
            var variant3 = new VariantAnsver();
            variant3.Id = 3;
            variant3.Text = "эллипсоид вращения";
            variant3.IsRight = true;
            _query1.VariantsAnsver = new List<VariantAnsver>() { variant1, variant2, variant3 };

            //вопрос 2 и варианты ответа на этот ворпос
            _query2 = new Query();
            _query2.Id = 2;
            _query2.Text = "К какому семейству относится арбуз";
            _query2.Point = 3;
            var variant11 = new VariantAnsver();
            variant11.Text = "ягода";
            variant11.Id = 4;
            variant11.IsRight = true;
            var variant22 = new VariantAnsver();
            variant22.Id = 5;
            variant22.Text = "фрукт";
            var variant33 = new VariantAnsver();
            variant33.Id = 6;
            variant33.Text = "плотоядное животное";
            _query2.VariantsAnsver = new List<VariantAnsver>() { variant11, variant22, variant33 };

            //пользователь1 (на второй вопрос ответил неправильно - поставил один лишний ответ)
            _person1 = new Person();
            _person1.Id = 1;
            _person1.Firstname = "Ivan";
            _person1.Surname = "Ivanow";
            _person1.Patronymic = "Ivanovich";
            _person1.PersonsAnswers = new List<PersonsAnswers>();

            //ответ пользователя1 на вопрос 1 (галочка)
            PersonsAnswers pa1 = new PersonsAnswers();
            pa1.PersonId = _person1.Id;
            pa1.Query = _query1;
            pa1.VariantAnsver = variant3;

            //ответ пользователя1 на вопрос 2 (галочка)
            PersonsAnswers pa2 = new PersonsAnswers();
            pa2.PersonId = _person1.Id;
            pa2.Query = _query2;
            pa2.VariantAnsver = variant11;

            //второй ответ пользователя1 на вопрос 2 (т.е. пользователь поставил 2 галочки при выборе ответа на этот ворпос)
            PersonsAnswers pa3 = new PersonsAnswers();
            pa3.PersonId = _person1.Id;
            pa3.Query = _query2;
            pa3.VariantAnsver = variant22;

            _person1.PersonsAnswers.Add(pa1);
            _person1.PersonsAnswers.Add(pa2);
            _person1.PersonsAnswers.Add(pa3);

            //пользователь2 (на оба вопроса ответил правильно)
            _person2 = new Person();
            _person2.Id = 2;
            _person2.Firstname = "Firstname2";
            _person2.Surname = "Surname2";
            _person2.Patronymic = "Patronomic2";
            _person2.PersonsAnswers = new List<PersonsAnswers>();

            PersonsAnswers pa11 = new PersonsAnswers();
            pa11.PersonId = _person2.Id;
            pa11.Query = _query1;
            pa11.VariantAnsver = variant3;

            PersonsAnswers pa22 = new PersonsAnswers();
            pa22.PersonId = _person2.Id;
            pa22.Query = _query2;
            pa22.VariantAnsver = variant11;

            _person2.PersonsAnswers.Add(pa11);
            _person2.PersonsAnswers.Add(pa22);




        }

        [Test]
        public void StartTest()
        {
            Assert.AreEqual(3, _person1.PersonsAnswers.Count);
            Assert.AreEqual("Какую форму имеет планета земля", _person1.PersonsAnswers.First().Query.Text);

            Assert.AreEqual(2, _person2.PersonsAnswers.Count);

        }

        [Test]
        public void IsPersonAnswersRight_MoreThenNeedVariant()
        {
            var queryHelper = new QueryHelper();
            var res = queryHelper.IsPersonAnswersRight(_query2, _person1);

            Assert.IsFalse(res);
        }

        [Test]
        public void IsPersonAnswersRight_PersonAnswerCorrect()
        {
            var queryHelper = new QueryHelper();
            var res = queryHelper.IsPersonAnswersRight(_query1, _person1);

            Assert.IsTrue(res);
        }

        [Test]
        public void GetPersonsAnswersByQuery_Test()
        {
            var queryHelper = new QueryHelper();
            var res = queryHelper.GetPersonsAnswersByQuery(_query2, _person1);

            Assert.AreEqual(2, res.Count);
            Assert.IsNotNull(res.FirstOrDefault(e => e.VariantAnsver.Text == "ягода"));
            Assert.IsNotNull(res.FirstOrDefault(e => e.VariantAnsver.Text == "фрукт"));
        }

        [Test]
        public void GetAveragePointByQuery_AllPerosonAnswersRight()
        {
            var queryHelper = new QueryHelper();
            var res = queryHelper.GetAveragePointByQuery(_query1, new List<Person>() { _person1, _person2 });

            Assert.AreEqual(1, res);
        }

        [Test]
        public void GetAveragePointByQuery_OnePersonAnswerRight_SecondNotRight()
        {
            var queryHelper = new QueryHelper();
            double res = queryHelper.GetAveragePointByQuery(_query2, new List<Person>() { _person1, _person2 });

            Assert.AreEqual(1.5, res);
        }

        [Test]
        public void GetQueryAveragePintList_Test()
        {
            var queryHelper = new QueryHelper();
            var res = queryHelper.GetQueryAveragePintList(new List<Query>() { _query1, _query2 }, new List<Person>() { _person1, _person2 });

            Assert.AreEqual(2, res.Count);
            Assert.AreEqual(1, res.First(e => e.Query.Id == 1).AveragePoint);
            Assert.AreEqual(1.5, res.First(e => e.Query.Id == 2).AveragePoint);
        }

        [Test]
        public void GetSummaryReportInfo_Test()
        {
            var queryHelper = new QueryHelper();

            var res = queryHelper.GetSummaryReportInfo(new List<Query>() { _query1, _query2 }, new List<Person>() { _person1 });

            Assert.AreEqual(1, res.PersonCount);
            Assert.AreEqual(2, res.QueryAveragePointList.Count);
        }
    }
}