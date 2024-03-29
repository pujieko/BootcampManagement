﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BootcampManagement.Data.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Access_Card> Access_Card { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<Aspect> Aspects { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<Batch_Class> Batch_Class { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Education_History> Education_History { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee_Access> Employee_Access { get; set; }
        public virtual DbSet<Employee_Certification> Employee_Certification { get; set; }
        public virtual DbSet<Employee_Language> Employee_Language { get; set; }
        public virtual DbSet<Employee_Locker> Employee_Locker { get; set; }
        public virtual DbSet<Employee_Role> Employee_Role { get; set; }
        public virtual DbSet<Employee_Skill> Employee_Skill { get; set; }
        public virtual DbSet<Error_Bank> Error_Bank { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<Id_Card> Id_Card { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Locker> Lockers { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }
        public virtual DbSet<Placement> Placements { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Regency> Regencies { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<Village> Villages { get; set; }
        public virtual DbSet<Work_Experience> Work_Experience { get; set; }
    }
}
