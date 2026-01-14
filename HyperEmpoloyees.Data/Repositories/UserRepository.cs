using HyperEmpoloyees.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Data.EF
{
    public class UserRepository : IDataHelper<User>
    {
        private HyperEmpoloyeesDbContext db;
        private User user;
        public UserRepository()
        {
            db = new HyperEmpoloyeesDbContext();
            user = new User();
        }

        public string Add(User table)
        {
            try
            {
                db.Users.Add(table);
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
                user = Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public string Edit(User table)
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                db.Users.Update(table);
                db.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public User Find(int id)
        {
            try
            {
                return db.Users.Find(id)?? new User();
            }
            catch
            {
                return new User();
            }
        }

        public List<User> GetAllData()
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                return db.Users.OrderByDescending(x=>x.Id).ToList();
            }
            catch
            {
                return new List<User>();
            }
        }

        public List<User> GetDataByUser(string userId)
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                return db.Users.Where(x => x.UserId == userId).OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<User>();
            }
        }

        public bool IsCanConnect()
        {
            db = new HyperEmpoloyeesDbContext(); return db.Database.CanConnect();
        }

        public List<User> SearchAll(string searchItem)
        {
            try
            {
                return db.Users.Where(x => x.Id.ToString() == searchItem ||
                x.UserId == searchItem ||
                x.Address == searchItem ||
                x.Email == searchItem ||
                x.FullName == searchItem ||
                x.UserName == searchItem ||
                x.Role.Contains(searchItem) ||
                x.CreatedDate.ToString().Contains(searchItem) ||
                x.EditedDate.ToString().Contains(searchItem)
                )
                    .OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<User>();
            }
        }

        public List<User> SearchByUser(string userId, string searchItem)
        {
            try
            {
                return db.Users.Where(x => x.UserId == userId).Where(x => x.Id.ToString() == searchItem ||
                x.UserId == searchItem ||
                x.Address == searchItem ||
                x.Email == searchItem ||
                x.FullName == searchItem ||
                x.UserName == searchItem ||
                x.Role.Contains(searchItem) ||
                x.CreatedDate.ToString().Contains(searchItem) ||
                x.EditedDate.ToString().Contains(searchItem)
                )
                    .OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<User>();
            }
        }
    }
}
