using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain;
using MyTester.Domain;


namespace MyTester.DAL
{
    public class MyContext : DbContext
    {
        public MyContext(string connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }

        public DbSet<Person> PersonSet { get; set; }

        public DbSet<PersonsAnswers> PersonsAnswersesSet { get; set; }

        public DbSet<Query> QuerySet { get; set; }

        public DbSet<VariantAnsver> VariantAnsverSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //отключаем каскадное удаление
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
