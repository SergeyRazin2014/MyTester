using MyTester.DAL;
using MyTester.DAL.Repositories;
using MyTester.Domain;
using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

namespace MyTester.IntegratedTests.IntegratedTests
{
    [TestFixture]
    public class QueryRepoTests
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
        public void AddQuery_CheckOnlyQueryCount()
        {
            var query = new Query();
            query.Text = "text1";
            var variant1 = new VariantAnsver();
            variant1.Text = "variant1";
            var variant2 = new VariantAnsver();
            variant2.Text = "variant2";
            var variant3 = new VariantAnsver();
            variant3.Text = "variant3";
            query.VariantsAnsver = new List<VariantAnsver>() { variant1, variant2, variant3 };

            QueryRepo repo = new QueryRepo(_db);
            repo.Add(query);

            var querysList = repo.GetAll();

            Assert.AreEqual(1, querysList.Count);
        }

        [Test]
        public void AddQuery_CheckVariantAnswersCount()
        {
            var query = new Query();
            query.Text = "text1";
            var variant1 = new VariantAnsver();
            variant1.Text = "variant1";
            var variant2 = new VariantAnsver();
            variant2.Text = "variant2";
            var variant3 = new VariantAnsver();
            variant3.Text = "variant3";
            query.VariantsAnsver = new List<VariantAnsver>() { variant1, variant2, variant3 };

            QueryRepo repo = new QueryRepo(_db);
            repo.Add(query);

            var querysList = repo.GetAll();

            Assert.AreEqual(3, querysList.First().VariantsAnsver.Count);

            var variantAnswersTextList = querysList.First().VariantsAnsver.Select(e => e.Text);

            Assert.That(variantAnswersTextList, Has.Member("variant1"));
            Assert.That(variantAnswersTextList, Has.Member("variant2"));
            Assert.That(variantAnswersTextList, Has.Member("variant3"));
        }
    }
}