using MyTester.DAL.Abstract;
using System;

namespace MyTester.DAL.Repositories
{
    public class PersonsAnswersRepo : IPersonsAnswersRepo
    {
        private MyContext _db;

        public PersonsAnswersRepo(MyContext db)
        {
            _db = db;
        }

        public void ClearResult()
        {
            var objCtx = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)_db).ObjectContext;
            objCtx.ExecuteStoreCommand("TRUNCATE TABLE [PersonsAnswers]");
        }
    }
}