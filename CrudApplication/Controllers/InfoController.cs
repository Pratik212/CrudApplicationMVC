using CrudApplication.Data;
using CrudApplication.Dtos;
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
    public class InfoController : ControllerBase
    {
        private readonly IInfoRepository _infoRepository;
        private readonly DataContext _context;

        public InfoController(IInfoRepository infoRepository , DataContext context)
        {
            _infoRepository = infoRepository;
            _context = context;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllInfo()
        {
            var getInfo = await _infoRepository.GetAll();
            var result = getInfo.Select(x => new
            {
                x.Id,
                x.Name,
                x.Fname
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> AddInfo(InfoDto infoDto)
        {
            var infoObj = new Info()
            {
                Name = infoDto.Name,
                Fname = infoDto.Fname
            };

            await _infoRepository.AddInfo(infoObj);
            _infoRepository.SaveChanges();

            return Ok(new
            {
                infoObj.Id,
                infoObj.Name,
                infoObj.Fname
            });
        }


        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> UpdateInfo(int id , InfoDto infoDto)
        {

            var getInfo = await _infoRepository.GetById(id);

            if(getInfo == null)
            {
                NotFound();
            }

            getInfo.Name = infoDto.Name;
            getInfo.Fname = infoDto.Fname;


             _context.SaveChanges();
            return Ok(new
            {
                getInfo.Id,
                getInfo.Name,
                getInfo.Fname
            });
        }


        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<ActionResult<Info>> DeleteInfo(int id , Info info)
        {
          

            var infoDelete = await _infoRepository.GetById(id);


            if (infoDelete == null)
            {
                return NotFound($"Info Id = {id} Not Found");
            }

            return await _infoRepository.DeleteInfo(id);
        }
    }
}
