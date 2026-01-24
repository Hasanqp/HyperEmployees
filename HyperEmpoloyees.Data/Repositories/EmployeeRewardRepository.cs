using HyperEmpoloyees.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Data.EF
{
    public class EmployeeRewardRepository : IDataHelper<EmployeeReward>
    {
        private HyperEmpoloyeesDbContext db;
        private EmployeeReward employeeReward;
        public EmployeeRewardRepository()
        {
            db = new HyperEmpoloyeesDbContext();
            employeeReward = new EmployeeReward();
        }

        public string Add(EmployeeReward table)
        {
            try
            {
                db.Rewards.Add(table);
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
                employeeReward = Find(id);
                db.Rewards.Remove(employeeReward);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public string Edit(EmployeeReward table)
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                db.Rewards.Update(table);
                db.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public EmployeeReward Find(int id)
        {
            try
            {
                return db.Rewards.Find(id) ?? new EmployeeReward();
            }
            catch
            {
                return new EmployeeReward();
            }
        }

        public List<EmployeeReward> GetAllData()
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                return db.Rewards.OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<EmployeeReward>();
            }
        }

        public List<EmployeeReward> GetDataByUser(string userId)
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                return db.Rewards.Where(x => x.UserId == userId).OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<EmployeeReward>();
            }
        }

        public bool IsCanConnect()
        {
            db = new HyperEmpoloyeesDbContext(); return db.Database.CanConnect();
        }

        public List<EmployeeReward> SearchAll(string searchItem)
        {
            try
            {
                return db.Rewards.Where(x => x.Id.ToString() == searchItem ||
                x.UserId == searchItem ||
                x.AddedDate.ToString() == searchItem ||
                x.BookThankDate.ToString() == searchItem ||
                x.Reference.ToString() == searchItem ||
                x.Note.Contains (searchItem)
                )
                    .OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<EmployeeReward>();
            }
        }

        public List<EmployeeReward> SearchByUser(string userId, string searchItem)
        {
            try
            {
                return db.Rewards.Where(x => x.UserId == userId).Where(x => x.Id.ToString() == searchItem ||
                x.UserId == searchItem ||
                x.AddedDate.ToString() == searchItem ||
                x.BookThankDate.ToString() == searchItem ||
                x.Reference.ToString() == searchItem ||
                x.Note.Contains(searchItem)
                )
                    .OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<EmployeeReward>();
            }
        }
    }
}
