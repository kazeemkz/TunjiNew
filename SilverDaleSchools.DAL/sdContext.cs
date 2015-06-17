using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SilverDaleSchools.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SilverDaleSchools.DAL;
//using SilverDaleSchools.Model;
//using SilverDaleSchools.Model;
//using eLibrary.DAL;


namespace SilverDaleSchools.DAL
{
    public class sdContext : DbContext
    {
        public sdContext()
            : base("stDatabase")
        {

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<sdContext, sdConfiguration>());
        }
        //public DbSet<PrimarySchoolStudent> PrimarySchoolStudents { get; set; }
        //public DbSet<Photo> Photos { get; set; }
        //public DbSet<Exam1> Exams1 { get; set; }
        //public DbSet<Exam2> Exams2 { get; set; }
        //public DbSet<Subject> Subjects { get; set; }
        //public DbSet<SubjectRegistration> SubjectRegistrations { get; set; }
        //public DbSet<PrimarySchoolStaff> PrimarySchoolStaff { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Person> People { get; set; }
        //public DbSet<Store> Store { get; set; }
        //public DbSet<Exam> Exams { get; set; }
        //public DbSet<StudentFees> StudentFees { get; set; }
        public DbSet<MyRole> MyRoles { get; set; }
       // public DbSet<Student> Student { get; set; }
        public DbSet<Result> Result { get; set; }
      //  public DbSet<Staff> Staff { get; set; }

        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        //public DbSet<SchoolFeePayment> SchoolFeePayments { get; set; }
        //public DbSet<OnlineExam> OnlineExams { get; set; }
        //public DbSet<Choice> Choices { get; set; }
        //public DbSet<Question> Questions { get; set; }
        //public DbSet<QuestionPhoto> QuestionPhoto { get; set; }
        //public DbSet<Blog> Blogs { get; set; }
        public DbSet<SubjectRegistration> SubjectRegistrations { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<Information> Information { get; set; }
        //public DbSet<PractiseSave> PractiseSave { get; set; }
        //public DbSet<SecondarySchoolStudent> SecondarySchoolStudent { get; set; }
        //public DbSet<Code> Code { get; set; }
        //public DbSet<Password> Password { get; set; }
        //public DbSet<Attendance> Attendance { get; set; }
        //public DbSet<AttendanceStaff> AttendanceStaff { get; set; }
        public DbSet<NewsBoard> NewsBoard { get; set; }

        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<TeachingClass> TeachingClass { get; set; }
        public DbSet<TeachingDay> TeachingDay { get; set; }
        public DbSet<TeachingSubject> TeachingSubject { get; set; }
        public DbSet<TeachingTime> TeachingTime { get; set; }
        //public DbSet<Parent> Parent { get; set; }
        //public DbSet<AuditTrail> AuditTrail { get; set; }
        //public DbSet<BulkSMS> BulkSMS { get; set; }
        //public DbSet<Term> Term { get; set; }

        //public DbSet<AdditionalChapterText> AdditionalChapterText { get; set; }
        //public DbSet<Chapter> Chapter { get; set; }
        //public DbSet<TextBook> TextBook { get; set; }
        //public DbSet<Course> Course { get; set; }

        //public DbSet<Hostel> Hostel { get; set; }
        //public DbSet<Room> Room { get; set; }
        //public DbSet<SchoolFeesType> SchoolFeesType { get; set; }
        //public DbSet<TermRegistration> TermRegistration { get; set; }
        //public DbSet<SchoolFeesAccount> SchoolFeesAccount { get; set; }
        //public DbSet<Salary> Salary { get; set; }
        //public DbSet<Deduction> Deduction { get; set; }
        //public DbSet<Loan> Loan { get; set; }
        //public DbSet<LatenessDeduction> LatenessDeduction { get; set; }
        //public DbSet<DeductionHistory> DeductionHistory { get; set; }
        //public DbSet<SalaryPaymentHistory> SalaryPaymentHistory { get; set; }
        //public DbSet<SchoolAccount> SchoolAccount { get; set; }

        //public DbSet<AbscentDeduction> AbscentDeduction { get; set; }

        //public DbSet<Supplier> Supplier { get; set; }

        //public DbSet<SupplierOrder> SupplierOrder { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Subject>().HasMany(c => c.SubjectRegistration).WithMany(i => i.Subjects).Map(t => t.MapLeftKey("SubjectID").MapRightKey("SubjectRegistrationID")
.ToTable("SubjectSubjectRegistration"));
//            modelBuilder.Entity<Subject>().HasMany(c => c.SubjectRegistration).WithMany(i => i.Subjects).Map(t => t.MapLeftKey("SubjectID").MapRightKey("PersonID")
//.ToTable("Person"));



        }


//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            // modelBuilder.Entity<Exam>().HasKey(p => p.ExamID).Property(p => p.ExamID).HasDatabaseGenerationOption(DatabaseGenerationOption.None);
//            // modelBuilder.Entity<Exam>().ToTable("Exam");
//            modelBuilder.Entity<SchoolFeesType>().HasKey(p => p.SchoolFeesTypeID);

//            modelBuilder.Entity<Photo>().Property(p => p.PhotoImage).HasColumnType("image");
//            base.OnModelCreating(modelBuilder);

//            modelBuilder.Entity<Subject>().HasMany(c => c.SubjectRegistrations).WithMany(i => i.Subjects).Map(t => t.MapLeftKey("SubjectID").MapRightKey("SubjectRegistrationID")
//.ToTable("SubjectSubjectRegistration"));


////            modelBuilder.Entity<Deduction>().HasMany(c => c.ThePrimarySchoolStaff).WithMany(i => i.TheDeduction).Map(t => t.MapLeftKey("DeductionID").MapRightKey("PersonID")
////.ToTable("DeductionPrimarySchoolStaff"));



//        }



    }
}
