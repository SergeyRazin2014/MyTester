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

            Database.SetInitializer(new MyDbInicializer());


            
            //--------------------------------------------------------------------------

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}