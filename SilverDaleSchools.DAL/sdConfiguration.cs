namespace SilverDaleSchools.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
   
    using MvcMembership;
    using SilverDaleSchools.Model;
    using SilverDaleSchools.DAL;
    using System.Collections.Generic;


    internal sealed class sdConfiguration : DbMigrationsConfiguration<SilverDaleSchools.DAL.sdContext>
    {
        public sdConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }


        protected override void Seed(sdContext context)
        {

            UnitOfWork work = new UnitOfWork();
          //  work.NewsBoardRepository.Get();

            if (!Roles.RoleExists("SuperAdmin"))
            {
                Roles.CreateRole("SuperAdmin");
            }
            if (!Roles.RoleExists("Student"))
            {
                Roles.CreateRole("Student");
            }

            if (!Roles.RoleExists("Lecturer"))
            {
                Roles.CreateRole("Lecturer");
            }

            //if (!Roles.RoleExists("Class Teacher"))
            //{
            //    Roles.CreateRole("Class Teacher");
            //}

            //if (!Roles.RoleExists("Subject Teacher"))
            //{
            //    Roles.CreateRole("Subject Teacher");
            //}

            //if (!Roles.RoleExists("Teacher"))
            //{
            //    Roles.CreateRole("Teacher");
            //}
          //  Membership.GetUser("5000001");


         if(Membership.GetUser("5000001") == null)
            {
                Person theStaff = new Person();
                theStaff.FirstName = "Admin";
                theStaff.LastName = "ariyoo";
                theStaff.MiddleName = "ariyoo";
                theStaff.UserID = 5000001;
              //  theStaff.DOB = DateTime.Now;
                theStaff.Sex = "Male";
                theStaff.Role = "SuperAdmin";
                theStaff.EnrollmentDate = DateTime.Now;
                work.PersonRepository.Insert(theStaff);
                work.Save();
               // UnitOfWork work = new UnitOfWork();
                Membership.CreateUser("5000001", "ariyoo", "kayode@yahoo.com");
                Roles.AddUserToRole("5000001", "SuperAdmin");
                Tweaker.AdjustTimer("5000001");
              //  Membership.CreateUser("5000002", "koyejo", "koyejo@yahoo.com");
               // Roles.AddUserToRole("5000002", "SuperAdmin");
           }


         if (Membership.GetUser("5000002") == null)
         {
             Person theStaff = new Person();
             theStaff.FirstName = "Tunji";
             theStaff.LastName = "Tunji";
             theStaff.MiddleName = "Tunji";
             theStaff.UserID = 5000002;
            // theStaff.DOB = DateTime.Now;
             theStaff.Sex = "Male";
             theStaff.Role = "SuperAdmin";
             theStaff.EnrollmentDate = DateTime.Now;
             work.PersonRepository.Insert(theStaff);
             work.Save();

               Membership.CreateUser("5000002", "tunji1", "koyejo@yahoo.com");
             Roles.AddUserToRole("5000002", "SuperAdmin");
             Tweaker.AdjustTimer("5000002");
         }



        

            //    LibraryUser theLabUser = new LibraryUser
            //    {
            //        DOB = DateTime.Now,
            //        FirstName = "kayode",
            //        LastName = "kayode",
            //        Level = "",
            //        UserName = "kayode",
            //        LevelType = "",
            //        LevelTaught = "",
            //        LevelTaughtType = "",
            //        TelePhoneNumber = "08166196673",
            //        ClassTeacher = "",
            //        UserType = "NonTeaching-Staff",
            //        EnrollmentDate = DateTime.Now

            //    };

            //    work.LibraryUserRepository.Insert(theLabUser);
            //    work.Save();
            //    if (work.LevelRepository.Get().ToList().Count == 0)
            //    {
            //        Level theLEvel = new Level();
            //        theLEvel.Name = "JSS1";
            //        work.LevelRepository.Insert(theLEvel);

            //        Level theLEvelJSS2 = new Level();
            //        theLEvelJSS2.Name = "JSS2";
            //        work.LevelRepository.Insert(theLEvelJSS2);

            //        Level theLEvelJSS3 = new Level();
            //        theLEvelJSS3.Name = "JSS3";
            //        work.LevelRepository.Insert(theLEvelJSS3);

            //        Level theLEvelSS1 = new Level();
            //        theLEvelSS1.Name = "SS1";
            //        work.LevelRepository.Insert(theLEvelSS1);

            //        Level theLEvelSS2 = new Level();
            //        theLEvelSS2.Name = "SS2";
            //        work.LevelRepository.Insert(theLEvelSS2);

            //        Level theLEvelSS3 = new Level();
            //        theLEvelSS3.Name = "SS3";
            //        work.LevelRepository.Insert(theLEvelSS3);
            //        work.Save();

            //    }

            //    if (work.MyRoleRepository.Get().ToList().Count == 0)
            //    {
            //        MyRole theRole1 = new MyRole();
            //        theRole1.RoleName = "Student";
            //        theRole1.Upload = "";
            //        theRole1.Exam = "List-Create-";
            //        theRole1.Book = "";
            //        theRole1.BorrowedItem = "Details-";
            //        theRole1.Shelf = "Details-";
            //        theRole1.Course = "";
            //        work.MyRoleRepository.Insert(theRole1);



            //        MyRole theRole2 = new MyRole();
            //        theRole2.RoleName = "SuperAdmin";
            //        theRole2.Upload = "";
            //        theRole2.Exam = "";
            //        theRole2.Book = "";
            //        theRole2.BorrowedItem = "";
            //        theRole2.Shelf = "";
            //        theRole2.Course = "";
            //        work.MyRoleRepository.Insert(theRole2);


            //        MyRole theRole3 = new MyRole();
            //        theRole3.RoleName = "Admin";
            //        theRole3.Upload = "List-Create-Edit-";
            //        theRole3.Exam = "";
            //        theRole3.Book = "";
            //        theRole3.BorrowedItem = "List-Create-Edit-Delete-";
            //        theRole3.Shelf = "List-";
            //        theRole3.Course = "List-";
            //        work.MyRoleRepository.Insert(theRole3);


            //        MyRole theRole4 = new MyRole();
            //        theRole4.RoleName = "Teacher";
            //        theRole4.Upload = "List-Create-Edit-Delete-Details-";
            //        theRole4.Exam = "List-Create-Edit-Delete-Details-";
            //        theRole4.Book = "List-Details-";
            //        theRole4.BorrowedItem = "";
            //        theRole4.Shelf = "";
            //        theRole4.Course = "List-Create-Edit-Delete-Details-";
            //        work.MyRoleRepository.Insert(theRole4);
            //        work.Save();

            //  }

        }




        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data. E.g.
        //
        //    context.People.AddOrUpdate(
        //      p => p.FullName,
        //      new Person { FullName = "Andrew Peters" },
        //      new Person { FullName = "Brice Lambson" },
        //      new Person { FullName = "Rowan Miller" }
        //    );
        //
        //    if (!Roles.RoleExists("Admin"))
        //    {
        //        Roles.CreateRole("Admin");
        //    }

        //    if (!Roles.RoleExists("User"))
        //    {
        //        Roles.CreateRole("User");
        //    }




        //    if (Membership.GetUser("kazeemkz") == null)
        //    {
        //        Membership.CreateUser("kazeemkz", "oyeyemi", "kazeemkz@yahoo.com");
        //        Roles.AddUserToRole("kazeemkz", "Admin");
        //    }
        //    context.Cards.AddOrUpdate(d => d.CardNumber, new Card() { CardNumber = "12345678909" },
        //    new Card { CardNumber = "8901234456" },
        //    new Card { CardNumber = "8901234456" },
        //    new Card { CardNumber = "8901234426" },
        //    new Card { CardNumber = "8901234656" });

        //    context.Subscriptions.AddOrUpdate(d => d.StartDate, new Subscription { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30), SubNature = SubscriptionStatus.Active, UserName = "wasiu", LoadCard = "1234568900" });
        //    context.JHUsers.AddOrUpdate(d => d.UserName, new JHUser() { Email = "wasiuabioye@gmail.com", UserName = "wasiu", AreaOfInterest = "Computer Programming", EnableAlert = false, MobileNumber = "08008320847" });
        //    Membership.CreateUser("wasiu", "wasiuabioye", "wasiu@yahoo.com");
        //    Roles.AddUserToRole("wasiu", "User");
    }
}

