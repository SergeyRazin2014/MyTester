using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTester.DAL.Repositories;
using MyTester.Domain;

namespace MyTester.DAL
{
    public class MyDbInicializer : IDatabaseInitializer<MyContext>
    {
        public void InitializeDatabase(MyContext db)
        {
            if (!Database.Exists(db.Database.Connection.ConnectionString))
                db.Database.Create();

            QueryRepo queryRepo = new QueryRepo(db);

            if (queryRepo.GetAll().Count == 0)
            {
                var query1 = new Query();
                query1.Text = "Какую форму имеет планета земля?";
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
                query2.Text = "К какому семейству относится арбуз?";
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
                query3.Text = "Какую цель преследовали США применив ядерное оружие против Японии?";
                query3.Point = 3;
                var variant1111 = new VariantAnsver();
                variant1111.Text = "Сократить жертвы среди мирных жителей";
                var variant2222 = new VariantAnsver();
                variant2222.Text = "Напугать СССР";
                variant2222.IsRight = true;
                var variant3333 = new VariantAnsver();
                variant3333.Text = "Испытать новое оружие";
                variant3333.IsRight = true;
                query3.VariantsAnsver = new List<VariantAnsver>() { variant1111, variant2222, variant3333 };

                queryRepo.Add(query3);
            }
        }
    }
}
