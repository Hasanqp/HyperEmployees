using HyperEmpoloyees.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Data.EF
{
    public class EmployeesEF : IDataHelper<Employees>
    {
        private DBContext db;
        private Employees employees;
        public EmployeesEF()
        {
            db = new DBContext();
            employees = new Employees();
        }

        public string Add(Employees table)
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
                employees = Find(id);
                db.Employees.Remove(employees);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public string Edit(Employees table)
        {
            try
            {
                db = new DBContext();
                db.Employees.Update(table);
                db.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Employees Find(int id)
        {
            try
            {
                return db.Employees.Find(id)?? new Employees();
            }
            catch
            {
                return new Employees();
            }
        }

        public List<Employees> GetAllData()
        {
            try
            {
                db = new DBContext();
                return db.Employees.OrderByDescending(x=>x.Id).ToList();
            }
            catch
            {
                return new List<Employees>();
            }
        }

        public List<Employees> GetDataByUser(string userId)
        {
            try
            {
                db = new DBContext();
                return db.Employees.Where(x => x.UsersId == userId).OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<Employees>();
            }
        }

        public bool IsCanConnect()
        {
            db = new DBContext(); return db.Database.CanConnect();
        }

        public List<Employees> SearchAll(string searchItem)
        {
            try
            {
                return db.Employees.Where(x => x.Id.ToString() == searchItem ||
                x.UsersId == searchItem ||

                x.Name.Contains(searchItem) ||
                x.JopTitle.Contains(searchItem) ||
                x.EmpState == searchItem ||
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
                return new List<Employees>();
            }
        }

        public List<Employees> SearchByUser(string userId, string searchItem)
        {
            try
            {
                return db.Employees.Where(x => x.UsersId == userId).Where(x => x.Id.ToString() == searchItem ||
                x.UsersId == searchItem ||

                x.Name.Contains(searchItem) ||
                x.JopTitle.Contains(searchItem) ||
                x.EmpState == searchItem ||
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
                return new List<Employees>();
            }
        }
    }
}
