﻿using HyperEmpoloyees.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Data.EF
{
    public class SystemRecordsEF : IDataHelper<SystemRecords>
    {
        private DBContext db;
        private SystemRecords systemRecords;
        public SystemRecordsEF()
        {
            db = new DBContext();
            systemRecords = new SystemRecords();
        }

        public string Add(SystemRecords table)
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

        public string Edit(SystemRecords table)
        {
            try
            {
                db = new DBContext();
                db.SystemRecords.Update(table);
                db.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SystemRecords Find(int id)
        {
            try
            {
                return db.SystemRecords.Find(id)?? new SystemRecords();
            }
            catch
            {
                return new SystemRecords();
            }
        }

        public List<SystemRecords> GetAllData()
        {
            try
            {
                db = new DBContext();
                return db.SystemRecords.OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<SystemRecords>();
            }
        }

        public List<SystemRecords> GetDataByUser(string userId)
        {
            try
            {
                db = new DBContext();
                return db.SystemRecords.Where(x=>x.UsersId.ToString() ==userId).OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<SystemRecords>();
            }
        }

        public bool IsCanConnect()
        {
            db = new DBContext(); return db.Database.CanConnect();
        }

        public List<SystemRecords> SearchAll(string searchItem)
        {
            try
            {
                return db.SystemRecords.Where(x => x.Id.ToString() == searchItem ||
                x.UsersId.ToString() == searchItem ||
                x.UserFullName.Contains(searchItem) ||
                x.MachinId == searchItem ||
                x.Title.Contains(searchItem) ||
                x.Description.Contains(searchItem) ||
                x.CreatedDate.ToString().Contains(searchItem)
                )
                    .OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<SystemRecords>();
            }
        }

        public List<SystemRecords> SearchByUser(string userId, string searchItem)
        {
            try
            {
                return db.SystemRecords.Where(x=>x.UsersId.ToString()==userId).Where(x => x.Id.ToString() == searchItem ||
               x.UsersId.ToString() == searchItem ||
                x.UserFullName.Contains(searchItem) ||
                x.MachinId == searchItem ||
                x.Title.Contains(searchItem) ||
                x.Description.Contains(searchItem) ||
                x.CreatedDate.ToString().Contains(searchItem)
                )
                    .OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<SystemRecords>();
            }
        }
    }
}
