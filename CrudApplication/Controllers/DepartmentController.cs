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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly DataContext _context;

        public DepartmentController(IDepartmentRepository departmentRepository , DataContext context)
        {
            _departmentRepository = departmentRepository;
            _context = context;
        }

        #region GETALLDEPARTMENTDATA

        [HttpGet]
        [Route("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetAll()
        {
            var depObj = await _departmentRepository.GetAllData();

            return Ok(depObj.Select(x=>new { 
                x.Id,
                x.DepartmentName,
                x.Email
            }));
        }
        #endregion

        #region ADDDEPARTMENT

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult>AddData([FromBody] DepartmentDto departmentDto)
        {

            var departmentObj = new Department()
            {
                DepartmentName = departmentDto.DepartmentName,
                Email = departmentDto.Email
            };

            await _departmentRepository.Add(departmentObj);

            return Ok(new
            {
                departmentObj.Id,
                departmentObj.DepartmentName,
                departmentObj.Email
            });
        }

        #endregion

        #region GETBYID

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var departmentData = await _departmentRepository.GetDepartmentById(id);

            return Ok(new { 
                departmentData.Id,
                departmentData.DepartmentName,
                departmentData.Email
            });
        }

        #endregion

        #region UPDATEDepartment

        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult>UpdateData(int id , [FromForm] DepartmentDto departmentDto)
        {

            var getdepartment = await _departmentRepository.GetDepartmentById(id);

            if(getdepartment == null)
            {
                return NotFound();
            }

            getdepartment.DepartmentName = departmentDto.DepartmentName;
            getdepartment.Email = departmentDto.Email;

            _context.SaveChanges();

            return Ok(new
            {
                getdepartment.Id,
                getdepartment.DepartmentName,
                getdepartment.Email
            });
        }

        #endregion

        #region DELETESTUDENT

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {

            var departmentDelete = await _departmentRepository.GetDepartmentById(id);

            if (departmentDelete == null)
            {
                return NotFound($"Department Id = {id} Not Found");
            }

            return await _departmentRepository.DeleteDepartment(id);
        }

        #endregion

    }
}
