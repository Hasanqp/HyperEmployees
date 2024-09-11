using HyperEmpoloyees.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Data.EF
{
    public class EmployeesRecordsEF : IDataHelper<EmployeesRecords>
    {
        private DBContext db;
        private EmployeesRecords employeesRecords;
        public EmployeesRecordsEF()
        {
            db = new DBContext();
            employeesRecords = new EmployeesRecords();
        }

        public string Add(EmployeesRecords table)
        {
            try
            {
                db.EmployeesRecords.Add(table);
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
                employeesRecords = Find(id);
                db.EmployeesRecords.Remove(employeesRecords);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public string Edit(EmployeesRecords table)
        {
            try
            {
                db = new DBContext();
                db.EmployeesRecords.Update(table);
                db.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public EmployeesRecords Find(int id)
        {
            try
            {
                db = new DBContext();
                return db.EmployeesRecords.Find(id)?? new EmployeesRecords();
            }
            catch
            {
                return new EmployeesRecords();
            }
        }

        public List<EmployeesRecords> GetAllData()
        {
            try
            {
                db = new DBContext();
                return db.EmployeesRecords.OrderByDescending(x=>x.Id).ToList();
            }
            catch
            {
                return new List<EmployeesRecords>();
            }
        }

        public List<EmployeesRecords> GetDataByUser(string userId)
        {
            try
            {
                db = new DBContext();
                return db.EmployeesRecords.Where(x => x.UsersId == userId).OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<EmployeesRecords>();
            }
        }

        public bool IsCanConnect()
        {
            db = new DBContext(); return db.Database.CanConnect();
        }

        public List<EmployeesRecords> SearchAll(string searchItem)
        {
            try
            {
                return db.EmployeesRecords.Where(x => x.Id.ToString() == searchItem ||
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
                return new List<EmployeesRecords>();
            }
        }

        public List<EmployeesRecords> SearchByUser(string userId, string searchItem)
        {
            try
            {
                return db.EmployeesRecords.Where(x => x.UsersId == userId).Where(x => x.Id.ToString() == searchItem ||
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
                return new List<EmployeesRecords>();
            }
        }
    }
}
