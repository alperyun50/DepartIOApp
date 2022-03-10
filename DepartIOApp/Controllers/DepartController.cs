using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartIOApp.Models;

namespace DepartIOApp.Controllers
{
    public class DepartController : Controller
    {
        DbDContext c = new DbDContext();

        public IActionResult Index()
        {
            var dept = c.Departments.ToList();
            return View(dept);
        }

        [HttpGet]
        public IActionResult NewDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewDepartment(Department d)
        {
            c.Departments.Add(d);
            c.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDepartment(int id)
        {
            var dept = c.Departments.Find(id);
            c.Departments.Remove(dept);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult GetDepartment(int id)
        {
            var dept = c.Departments.Find(id);
            
            return View("GetDepartment", dept);
        }

        public IActionResult UpdateDepartment(Department d)
        {
            var dept = c.Departments.Find(d.id);

            dept.id = d.id;
            dept.departmentName = d.departmentName;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DepartmentDetail(int id)
        {
            var values = c.Employees.Where(x => x.departid == id).ToList();
            var departname = c.Departments.Where(x => x.id == id).Select(x => x.departmentName).FirstOrDefault();

            // send departname to ui
            ViewBag.departname = departname;
            return View(values);
        }
    }
}
