using DepartIOApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartIOApp.Controllers
{
    public class EmployeeController : Controller
    {
        DbDContext c = new DbDContext();

        public IActionResult Index()
        {
            var emp = c.Employees.Include(x=>x.depart).ToList();

            return View(emp);
        }
    }
}
