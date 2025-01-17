﻿using HyperEmpoloyees.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Data.EF
{
    public class DBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            /*string conString = "Server=WIN-FKUQ8A2A5DL\\SQLEXPRESS;Database=HyperEmpolyeesDB;Encrypt=false;Trusted_Connection=True;";*/
            optionsBuilder.UseSqlServer(ConString.ConStringValue);
        }


        // Tables
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<SystemRecords> SystemRecords { get; set; }
        public DbSet<SalaryRate> SalaryRate { get; set;}
        public DbSet<Employees> Employees { get; set; }
        public DbSet<BookThanks> BookThanks { get; set; }
        public DbSet<EmployeesRecords> EmployeesRecords { get; set; }
    }
}
