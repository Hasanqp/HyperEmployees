using HyperEmpoloyees.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Data.EF
{
    public class UsersEF : IDataHelper<Users>
    {
        private DBContext db;
        private Users users;
        public UsersEF()
        {
            db = new DBContext();
            users = new Users();
        }

        public string Add(Users table)
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
                users = Find(id);
                db.Users.Remove(users);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public string Edit(Users table)
        {
            try
            {
                db = new DBContext();
                db.Users.Update(table);
                db.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Users Find(int id)
        {
            try
            {
                return db.Users.Find(id)?? new Users();
            }
            catch
            {
                return new Users();
            }
        }

        public List<Users> GetAllData()
        {
            try
            {
                db = new DBContext();
                return db.Users.OrderByDescending(x=>x.Id).ToList();
            }
            catch
            {
                return new List<Users>();
            }
        }

        public List<Users> GetDataByUser(string userId)
        {
            try
            {
                db = new DBContext();
                return db.Users.Where(x => x.UserId == userId).OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<Users>();
            }
        }

        public bool IsCanConnect()
        {
            db = new DBContext(); return db.Database.CanConnect();
        }

        public List<Users> SearchAll(string searchItem)
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
                return new List<Users>();
            }
        }

        public List<Users> SearchByUser(string userId, string searchItem)
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
                return new List<Users>();
            }
        }
    }
}
