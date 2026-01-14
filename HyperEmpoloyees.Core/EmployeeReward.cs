using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Core
{
    public class EmployeeReward
    {
        public int Id { get; set; }
        public int EffectValue { get; set; }
        public string Reference { get; set; }
        public DateTime BookThankDate { get; set; }
        public string Note { get; set; }
        public DateTime AddedDate { get; set; }

        // Navigatoins
        public int EmployeesId { get; set; }
        public Employee Employee { get; set; }
        public string UserId { get; set; }
    }
}
