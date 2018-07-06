using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace NHibernateDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {App_Start.NHibernateProfilerBootstrapper.PreStart();

            var cfg = new Configuration();

            //c5fg.DataBaseIntegration (x => {
            //    x.ConnectionString = "Data Source=SFA;Initial Catalog=RizalTest01;Integrated Security=True";
            //    x.Driver<SqlClientDriver>();
            //    x.Dialect<MsSql2012Dialect>();
            //    x.LogSqlInConsole = true;
            //});
            //cfg.AddAssembly(Assembly.GetExecutingAssembly());

            cfg.Configure();
            cfg.DataBaseIntegration(x => { x.BatchSize = 5; x.LogSqlInConsole = true; });
            var sefact = cfg.BuildSessionFactory();

            using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var studentUsingTheFirstQuery = session.Get<Student>(Guid.Parse("7B0DD8D5-4C34-4981-9F59-FDBD47AD12FB"));
                    var studentUsingTheSecondQuery = session.Get<Student>(Guid.Parse("7B0DD8D5-4C34-4981-9F59-FDBD47AD12FB"));
                }
                //using (var tx = session.BeginTransaction())
                //{
                //    var students = session.CreateCriteria<Student>().List<Student>();

                //    for (int i = 0; i < 10; i++)
                //    {

                //        var student = new Student
                //        {
                //            Name = "FirstName" + i.ToString(),
                //            LastName = "LastName" + i.ToString(),
                //            AcademicStanding = StudentAcademicStanding.Good
                //        };

                //        session.Save(student);
                //    }
                //    tx.Commit();

                //foreach (Student s in students)
                //session.Delete(s); 
                //tx.Commit();

                //foreach (var student in students)
                //{
                //    Console.WriteLine("{0} {1} {2} {3}",
                //       student.ID, student.Name, student.LastName, student.AcademicStanding);
                //}
            }
            Console.Read();
        }
    }
}

