using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Core
{
    public class Role
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public bool Value { get; set; }

        // Navigations
        public int UsersId { get; set; }
        public User Users { get; set; }
    }
}
