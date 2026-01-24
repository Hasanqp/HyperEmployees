using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Core
{
    public class Employee
    {
        public int Id { get; set; }

        // General Data
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string EmploymentState { get; set; }
        public DateTime LastPromotionDate { get; set; }

        // Current Salary
        public int CurrentDegree { get; set; }
        public int CurrentStage { get; set; }
        public float CurrentSalary { get; set; }
        public DateTime CurrentDate { get; set; }

        // Next Salary
        public int NextDegree { get; set; }
        public int NextStage { get; set; }
        public float NextSalary { get; set; }
        public DateTime NextDate { get; set; }

        // Other
        public string Note { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        // Relations
        public string UsersId { get; set; }

        public List<EmployeeReward> Rewards { get; set; }
        public List<EmployeesRecord> Records { get; set; }
    }
}
