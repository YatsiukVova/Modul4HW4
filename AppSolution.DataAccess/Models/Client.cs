using System;
using System.Collections.Generic;
using System.Text;

namespace AppSolution.DataAccess.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
