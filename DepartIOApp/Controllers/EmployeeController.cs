using DepartIOApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet]
        public IActionResult NewEmployee()
        {
            // used for dropdown list
            List<SelectListItem> values = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.departmentName,
                                               Value = x.id.ToString()
                                           }).ToList();
            ViewBag.vals = values;
            return View();
        }

        public IActionResult NewEmployee(Employee p)
        {
            // relational db id update(from dropdown list in NewEmployee page)
            var emp = c.Departments.Where(x => x.id == p.depart.id).FirstOrDefault();
            p.depart = emp;

            c.Employees.Add(p);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
