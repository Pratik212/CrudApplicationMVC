using CrudApplication.Data;
using CrudApplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecksController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IChecksRepository _checksRepository;

        public ChecksController(DataContext context , IChecksRepository checksRepository)
        {
            _context = context;
            _checksRepository = checksRepository;
        }

        public async Task<IActionResult> GetAllCheck()
        {
            var check = await _checksRepository.GetAll();

            var result = check.Select(x=>new { 
                x.Name,
                x.Value
            });

            return Ok(result);
        }
    }
}
