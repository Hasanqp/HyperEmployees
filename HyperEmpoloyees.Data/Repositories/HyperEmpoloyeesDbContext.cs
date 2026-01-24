using HyperEmpoloyees.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Data.EF
{
    public class HyperEmpoloyeesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conString = "Server=(localdb)\\MSSQLLocalDB;Database=HyperEmpolyeesDB;Encrypt=false;Trusted_Connection=True;";
            //optionsBuilder.UseSqlServer(ConString.ConStringValue);
            optionsBuilder.UseSqlServer(conString);
        }


        // Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SystemRecord> SystemRecords { get; set; }
        public DbSet<SalaryRate> SalaryRates { get; set;}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeReward> Rewards { get; set; }
        public DbSet<EmployeesRecord> EmployeesRecords { get; set; }
    }
}
