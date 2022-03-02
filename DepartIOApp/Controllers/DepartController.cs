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
    }
}
