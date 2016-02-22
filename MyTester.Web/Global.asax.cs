using System.Collections.Generic;
using System.Configuration;
using MyTester.DAL;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using DAL.Repositories;
using Domain;

namespace MyTester
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            //☻--------------------------------------------------------------------------

            //Database.SetInitializer(new MyDbInicializer());

            Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());
            var _db = new MyContext(ConfigurationManager.ConnectionStrings[0].ConnectionString);

            var  query = new Query();
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
            //--------------------------------------------------------------------------

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}