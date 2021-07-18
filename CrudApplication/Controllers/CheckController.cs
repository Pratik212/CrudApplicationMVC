using CrudApplication.Data;
using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Controllers
{
    public class CheckController : Controller
    {
        private readonly DataContext _context;

        public CheckController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Check> objList = _context.Checks;

            return View(objList);
        }

        public IActionResult Update()
        {
            return View();
        }
    }
}
