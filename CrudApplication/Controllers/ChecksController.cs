using CrudApplication.Data;
using CrudApplication.Interfaces;
using CrudApplication.Models;
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
        [HttpGet]
        [Route("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetAllCheck()
        {
            var check = await _checksRepository.GetAll();

            var result = check.Select(x=>new { 
                x.Id,
                x.Name,
                x.Value
            });

            return Ok(result);
        }


        [HttpPost]
        [Route("add")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> Add([FromBody]Check check)
        {
            var checkObj = new Check()
            {
                Name = check.Name,
                Value = check.Value
            };

            var result = await _checksRepository.AddCheck(checkObj);

            return Ok(result);


        }

        #region UpdateCheck

        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> UpdateData(int id, [FromForm] Check check)
        {

            var getCheckvalue = await _checksRepository.GetValueById(id);

            if (getCheckvalue == null)
            {
                return NotFound();
            }

            getCheckvalue.Name = check.Name;
            getCheckvalue.Value = check.Value;

            _context.SaveChanges();

            return Ok(new
            {
                getCheckvalue.Name,
                getCheckvalue.Value
            });

        }


        #endregion


        #region GETBYID

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetCheckById(int id)
        {
            var checksData = await _checksRepository.GetValueById(id);

            return Ok(new
            {
                checksData.Id,
                checksData.Name,
                checksData.Value
            });
        }

        #endregion
    }
}
