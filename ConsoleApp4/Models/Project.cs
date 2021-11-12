using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Models
{
   public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartedDate { get; set; }
        public List<EmployeeProject> EmployeeProject { get; set; } = new List<EmployeeProject>();
    }
}
