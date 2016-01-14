using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuthWebApiKios.Context
{
    public class MyDbInitializer : CreateDatabaseIfNotExists<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            //// create 3 students to seed the database
            //context.Students.Add(new Student { ID = 1, FirstName = "Mark", LastName = "Richards", EnrollmentDate = DateTime.Now });
            //context.Students.Add(new Student { ID = 2, FirstName = "Paula", LastName = "Allen", EnrollmentDate = DateTime.Now });
            //context.Students.Add(new Student { ID = 3, FirstName = "Tom", LastName = "Hoover", EnrollmentDate = DateTime.Now });
            //base.Seed(context);
        }
    }
}