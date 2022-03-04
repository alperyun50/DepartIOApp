using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DepartIOApp.Models
{
    public class Employee
    {
        [Key]
        public int empId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string City { get; set; }

        //FKey
        public int departid { get; set; }
        public Department depart { get; set; }
    }
}
