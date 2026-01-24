using HyperEmpoloyees.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Data.EF
{
    public class EmployeeRecordsRepository : IDataHelper<EmployeesRecord>
    {
        private HyperEmpoloyeesDbContext db;
        private EmployeesRecord employeesRecord;
        public EmployeeRecordsRepository()
        {
            db = new HyperEmpoloyeesDbContext();
            employeesRecord = new EmployeesRecord();
        }

        public string Add(EmployeesRecord table)
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
                employeesRecord = Find(id);
                db.EmployeesRecords.Remove(employeesRecord);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public string Edit(EmployeesRecord table)
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                db.EmployeesRecords.Update(table);
                db.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public EmployeesRecord Find(int id)
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                return db.EmployeesRecords.Find(id)?? new EmployeesRecord();
            }
            catch
            {
                return new EmployeesRecord();
            }
        }

        public List<EmployeesRecord> GetAllData()
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                return db.EmployeesRecords.OrderByDescending(x=>x.Id).ToList();
            }
            catch
            {
                return new List<EmployeesRecord>();
            }
        }

        public List<EmployeesRecord> GetDataByUser(string userId)
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                return db.EmployeesRecords.Where(x => x.UsersId == userId).OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<EmployeesRecord>();
            }
        }

        public bool IsCanConnect()
        {
            db = new HyperEmpoloyeesDbContext(); return db.Database.CanConnect();
        }

        public List<EmployeesRecord> SearchAll(string searchItem)
        {
            try
            {
                return db.EmployeesRecords.Where(x => x.Id.ToString() == searchItem ||
                x.UsersId == searchItem ||

                x.Name.Contains(searchItem) ||
                x.JobTitle.Contains(searchItem) ||
                x.EmploymentStatus == searchItem ||
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
                return new List<EmployeesRecord>();
            }
        }

        public List<EmployeesRecord> SearchByUser(string userId, string searchItem)
        {
            try
            {
                return db.EmployeesRecords.Where(x => x.UsersId == userId).Where(x => x.Id.ToString() == searchItem ||
                x.UsersId == searchItem ||

                x.Name.Contains(searchItem) ||
                x.JobTitle.Contains(searchItem) ||
                x.EmploymentStatus == searchItem ||
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
                return new List<EmployeesRecord>();
            }
        }
    }
}
