using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Controllers
{
    public class StudentInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }
    }
}
