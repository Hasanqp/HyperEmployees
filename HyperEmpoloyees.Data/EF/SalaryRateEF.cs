using HyperEmpoloyees.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Data.EF
{
    public class SalaryRateEF : IDataHelper<SalaryRate>
    {
        private DBContext db;
        private SalaryRate salaryRate;
        public SalaryRateEF()
        {
            db = new DBContext();
            salaryRate = new SalaryRate();
        }

        public string Add(SalaryRate table)
        {
            try
            {
                db.SalaryRate.Add(table);
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
                salaryRate = Find(id);
                db.SalaryRate.Remove(salaryRate);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public string Edit(SalaryRate table)
        {
            try
            {
                db = new DBContext();
                db.SalaryRate.Update(table);
                db.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SalaryRate Find(int id)
        {
            try
            {
                return db.SalaryRate.Find(id)?? new SalaryRate();
            }
            catch
            {
                return new SalaryRate();
            }
        }

        public List<SalaryRate> GetAllData()
        {
            try
            {
                db = new DBContext();
                return db.SalaryRate.OrderByDescending(x=>x.Id).ToList();
            }
            catch
            {
                return new List<SalaryRate>();
            }
        }

        public List<SalaryRate> GetDataByUser(string userId)
        {
            try
            {
                db = new DBContext();
                return db.SalaryRate.Where(x => x.UsersId == userId).OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<SalaryRate>();
            }
        }

        public bool IsCanConnect()
        {
            db = new DBContext(); return db.Database.CanConnect();
        }

        public List<SalaryRate> SearchAll(string searchItem)
        {
            try
            {
                return db.SalaryRate.Where(x => x.Id.ToString() == searchItem ||
                x.UsersId == searchItem ||
                x.Degree.ToString() == searchItem ||
                x.Salary.ToString() == searchItem ||
                x.BounsYearRate.ToString() == searchItem ||
                x.PromotionYear.ToString() == searchItem 
                )
                    .OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<SalaryRate>();
            }
        }

        public List<SalaryRate> SearchByUser(string userId, string searchItem)
        {
            try
            {
                return db.SalaryRate.Where(x => x.UsersId == userId).Where(x => x.Id.ToString() == searchItem ||
                x.UsersId == searchItem ||
                x.Degree.ToString() == searchItem ||
                x.Salary.ToString() == searchItem ||
                x.BounsYearRate.ToString() == searchItem ||
                x.PromotionYear.ToString() == searchItem
                )
                    .OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<SalaryRate>();
            }
        }
    }
}
