using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ChampSupermarket.Models;

namespace ChampSupermarket.DAL
{
    public class SupermarketInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SupermarketContext>
    {
        protected override void Seed(SupermarketContext context)
        {
            var supliers = new List<Suplier>
            {
            new Suplier{SuplierID=1000,SuplierName="Osem",Adress="Hertzel 6, Tel Aviv",Phone=039511984}/*,
            new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}*/
            };

            supliers.ForEach(s => context.supliers.Add(s));
            context.SaveChanges();
            var products = new List<Product>
            {
            /*new Product{ProductID=500,NameProduct="Bamba",Price=5.90,Description="Very Tasty",SuplierID=1000},
            new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
            new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
            new Course{CourseID=1045,Title="Calculus",Credits=4,},
            new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
            new Course{CourseID=2021,Title="Composition",Credits=3,},
            new Course{CourseID=2042,Title="Literature",Credits=4,}*/
            };
            products.ForEach(s => context.products.Add(s));
            context.SaveChanges();
            var clients = new List<Client>
            {
            new Client{ID=315995852,FirstName="Amit",LastName="Munichor",PhoneNum=0527331414,Age=18}/*,
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050,},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},*/
            };
            clients.ForEach(s => context.clients.Add(s));
            context.SaveChanges();
        }
    }
}