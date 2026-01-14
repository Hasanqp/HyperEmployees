using HyperEmpoloyees.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Data.EF
{
    public class EmployeeRepository : IDataHelper<Employee>
    {
        private HyperEmpoloyeesDbContext db;
        private Employee employee;
        public EmployeeRepository()
        {
            db = new HyperEmpoloyeesDbContext();
            employee = new Employee();
        }

        public string Add(Employee table)
        {
            try
            {
                db.Employees.Add(table);
                db.SaveChanges();
                return "1";
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                employee = Find(id);
                db.Employees.Remove(employee);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public string Edit(Employee table)
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                db.Employees.Update(table);
                db.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Employee Find(int id)
        {
            try
            {
                return db.Employees.Find(id)?? new Employee();
            }
            catch
            {
                return new Employee();
            }
        }

        public List<Employee> GetAllData()
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                return db.Employees.OrderByDescending(x=>x.Id).ToList();
            }
            catch
            {
                return new List<Employee>();
            }
        }

        public List<Employee> GetDataByUser(string userId)
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                return db.Employees.Where(x => x.UsersId == userId).OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<Employee>();
            }
        }

        public bool IsCanConnect()
        {
            db = new HyperEmpoloyeesDbContext(); return db.Database.CanConnect();
        }

        public List<Employee> SearchAll(string searchItem)
        {
            try
            {
                return db.Employees.Where(x => x.Id.ToString() == searchItem ||
                x.UsersId == searchItem ||

                x.Name.Contains(searchItem) ||
                x.JobTitle.Contains(searchItem) ||
                x.EmploymentState == searchItem ||
                x.LastPromotionDate.ToString()== searchItem||

                x.CurrentDegree.ToString()== searchItem ||
                x.CurrentStage.ToString()== searchItem ||
                x.CurrentSalary.ToString() == searchItem ||
                x.CurrentDate.ToString() == searchItem ||

                x.NextDegree.ToString() == searchItem ||
                x.NextStage.ToString() == searchItem ||
                x.NextSalary.ToString() == searchItem ||
                x.NextDate.ToString() == searchItem ||

                x.Note.Contains(searchItem) ||

                x.AddedDate.ToString() == searchItem ||
                x.UpdateDate.ToString() == searchItem
                )
                    .OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<Employee>();
            }
        }

        public List<Employee> SearchByUser(string userId, string searchItem)
        {
            try
            {
                return db.Employees.Where(x => x.UsersId == userId).Where(x => x.Id.ToString() == searchItem ||
                x.UsersId == searchItem ||

                x.Name.Contains(searchItem) ||
                x.JobTitle.Contains(searchItem) ||
                x.EmploymentState == searchItem ||
                x.LastPromotionDate.ToString() == searchItem ||

                x.CurrentDegree.ToString() == searchItem ||
                x.CurrentStage.ToString() == searchItem ||
                x.CurrentSalary.ToString() == searchItem ||
                x.CurrentDate.ToString() == searchItem ||

                x.NextDegree.ToString() == searchItem ||
                x.NextStage.ToString() == searchItem ||
                x.NextSalary.ToString() == searchItem ||
                x.NextDate.ToString() == searchItem ||

                x.Note.Contains(searchItem) ||
                x.AddedDate.ToString() == searchItem ||
                x.UpdateDate.ToString() == searchItem
                )
                    .OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<Employee>();
            }
        }
    }
}
