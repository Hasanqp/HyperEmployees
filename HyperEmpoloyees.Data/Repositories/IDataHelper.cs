using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Data.EF
{
    public interface IDataHelper<Table>
    {
        // Read { Admin | User }
        List<Table> GetAllData(); // Admin
        List<Table> GetDataByUser(string userId); // User
        List<Table> SearchAll(string searchItem); // Admin
        List<Table> SearchByUser(string userId,string searchItem); // User
        Table Find(int id);

        // Write
        string Add(Table table); // "1== success" , Error
        string Edit(Table table); // "1== success" , Error
        string Delete(int id); // "1== success" , Error

        // other
        bool IsCanConnect();
    }
}
