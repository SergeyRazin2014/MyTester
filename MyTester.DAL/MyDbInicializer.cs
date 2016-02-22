using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using Domain;

namespace MyTester.DAL
{
    public class MyDbInicializer:IDatabaseInitializer<MyContext>
    {
        public void InitializeDatabase(MyContext db)
        {
            if (!Database.Exists(db.Database.Connection.ConnectionString))
                db.Database.Create();

            QueryRepo queryRepo = new QueryRepo(db);

            if (queryRepo.GetAll().Count == 0)
            {
                var query            = new Query();
                query.Text           = "text1";
                var variant1         = new VariantAnsver();
                variant1.Text        = "variant1";
                var variant2         = new VariantAnsver();
                variant2.Text        = "variant2";
                var variant3         = new VariantAnsver();
                variant3.Text        = "variant3";
                query.VariantsAnsver = new List<VariantAnsver>() { variant1, variant2, variant3 };

                queryRepo.Add(query);
            }
        }
    }
}
