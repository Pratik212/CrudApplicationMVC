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
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly DataContext _context;

        public StudentController(IStudentRepository studentRepository , DataContext context)
        {
            _studentRepository = studentRepository;
            _context = context;
        }

        #region GETALLSTUDENT

        [HttpGet]
        [Route("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetStudents()
        {
            var studResult = await _studentRepository.GetAllStudent();

            var obj = studResult.Select(x => new
            {
                x.StudentId,
                x.FirstName,
                x.LastName,
                x.Address,
                x.PhoneNumber,
                x.City

            });

            return Ok(obj);
        }
        #endregion

        #region ADDSTUDENT

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> AddStduent(StudentDto studentDto)
        {
            var studObj = new Student()
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Address = studentDto.Address,
                PhoneNumber = studentDto.PhoneNumber,
                City = studentDto.City
            };

            await _studentRepository.AddStudent(studObj);

            return Ok(new
            {
                studObj.FirstName,
                studObj.LastName,
                studObj.Address,
                studObj.PhoneNumber,
                studObj.City
            });
        }

        #endregion

        #region UPDATESTUDENT

        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult>UpdateStudent(int id, [FromBody]StudentDto studentDto )
        {
            var getStudent = await _studentRepository.GetStudentById(id);

            if (getStudent == null)
            {
                NotFound();
            }

            getStudent.FirstName = studentDto.FirstName;
            getStudent.LastName = studentDto.LastName;
            getStudent.Address = studentDto.Address;
            getStudent.PhoneNumber = studentDto.PhoneNumber;
            getStudent.City = studentDto.City;

            _context.SaveChanges();
            return Ok(new
            {
                getStudent.StudentId,
                getStudent.FirstName,
                getStudent.LastName,
                getStudent.Address,
                getStudent.PhoneNumber,
                getStudent.City
            });
        }

        #endregion

        #region DELETESTUDENT

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<ActionResult<Student>> DeleteStudent(int id, Info info)
        {


            var infoDelete = await _studentRepository.GetStudentById(id);


            if (infoDelete == null)
            {
                return NotFound($"Info Id = {id} Not Found");
            }

            return await _studentRepository.DeleteStudent(id);
        }

        #endregion
    }
}
