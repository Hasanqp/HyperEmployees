using HyperEmpoloyees.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Data.EF
{
    public class SystemRecordRepository : IDataHelper<SystemRecord>
    {
        private HyperEmpoloyeesDbContext db;
        private SystemRecord systemRecords;
        public SystemRecordRepository()
        {
            db = new HyperEmpoloyeesDbContext();
            systemRecords = new SystemRecord();
        }

        public string Add(SystemRecord table)
        {
            try
            {
                db.SystemRecords.Add(table);
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
                systemRecords=Find(id);
                db.SystemRecords.Remove(systemRecords);
                db.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Edit(SystemRecord table)
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                db.SystemRecords.Update(table);
                db.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SystemRecord Find(int id)
        {
            try
            {
                return db.SystemRecords.Find(id)?? new SystemRecord();
            }
            catch
            {
                return new SystemRecord();
            }
        }

        public List<SystemRecord> GetAllData()
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                return db.SystemRecords.OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<SystemRecord>();
            }
        }

        public List<SystemRecord> GetDataByUser(string userId)
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                return db.SystemRecords.Where(x=>x.UsersId.ToString() ==userId).OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<SystemRecord>();
            }
        }

        public bool IsCanConnect()
        {
            db = new HyperEmpoloyeesDbContext(); return db.Database.CanConnect();
        }

        public List<SystemRecord> SearchAll(string searchItem)
        {
            try
            {
                return db.SystemRecords.Where(x => x.Id.ToString() == searchItem ||
                x.UsersId.ToString() == searchItem ||
                x.UserFullName.Contains(searchItem) ||
                x.MachineId == searchItem ||
                x.Title.Contains(searchItem) ||
                x.Description.Contains(searchItem) ||
                x.CreatedDate.ToString().Contains(searchItem)
                )
                    .OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<SystemRecord>();
            }
        }

        public List<SystemRecord> SearchByUser(string userId, string searchItem)
        {
            try
            {
                return db.SystemRecords.Where(x=>x.UsersId.ToString()==userId).Where(x => x.Id.ToString() == searchItem ||
               x.UsersId.ToString() == searchItem ||
                x.UserFullName.Contains(searchItem) ||
                x.MachineId == searchItem ||
                x.Title.Contains(searchItem) ||
                x.Description.Contains(searchItem) ||
                x.CreatedDate.ToString().Contains(searchItem)
                )
                    .OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<SystemRecord>();
            }
        }
    }
}
