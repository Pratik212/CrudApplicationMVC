using CrudApplication.Data;
using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Controllers
{
    public class PersonController : Controller
    {

        private readonly DataContext _context;

        public PersonController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Person> objList = _context.Persons.ToList();

            return View(objList);
        }
    }
}
