using HyperEmpoloyees.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Data.EF
{
    public class RoleRepository : IDataHelper<Role>
    {
        private HyperEmpoloyeesDbContext db;
        private Role roles;
        public RoleRepository()
        {
            db = new HyperEmpoloyeesDbContext();
            roles = new Role();
        }

        public string Add(Role table)
        {
            try
            {
                db.Roles.Add(table);
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
                roles=Find(id);
                db.Roles.Remove(roles);
                db.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Edit(Role table)
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                db.Roles.Update(table);
                db.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Role Find(int id)
        {
            try
            {
                return db.Roles.Find(id)?? new Role();
            }
            catch
            {
                return new Role();
            }
        }

        public List<Role> GetAllData()
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                return db.Roles.OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<Role>();
            }
        }

        public List<Role> GetDataByUser(string userId)
        {
            try
            {
                db = new HyperEmpoloyeesDbContext();
                return db.Roles.Where(x=>x.UsersId.ToString()==userId).OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<Role>();
            }
        }

        public bool IsCanConnect()
        {
            db = new HyperEmpoloyeesDbContext(); return db.Database.CanConnect();
        }

        public List<Role> SearchAll(string searchItem)
        {
            try
            {
                return db.Roles.Where(x => x.Id.ToString() == searchItem    
                )
                    .OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<Role>();
            }
        }

        public List<Role> SearchByUser(string userId, string searchItem)
        {
            try
            {
                return db.Roles.Where(x=>x.UsersId.ToString()==userId).Where(x => x.Id.ToString() == searchItem
                )
                    .OrderByDescending(x => x.Id).ToList();
            }
            catch
            {
                return new List<Role>();
            }
        }
    }
}
