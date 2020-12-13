﻿using KBDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBDataAccessLibrary.DataAccess
{
    public class KBContext : DbContext
    {
        public KBContext(DbContextOptions options) : base(options) { }
        public DbSet<AgeCategory> AgeCategories { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}