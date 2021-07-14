using CrudApplication.Data;
using CrudApplication.Interfaces;
using CrudApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Providers
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Student> AddStudent(Student student)
        {
            var studentObj = await _context.Students.AddAsync(student);

            _context.SaveChanges();
            return studentObj.Entity;
        }

        public async Task<Student> DeleteStudent(int studentId)
        {
            var studentObj = await _context.Students.FirstOrDefaultAsync(e => e.StudentId == studentId);
            if (studentObj != null)
            {
                _context.Students.Remove(studentObj);
                await _context.SaveChangesAsync();
                return studentObj;
            }

            return null;
        }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            return await _context.Students.FirstOrDefaultAsync(x=>x.StudentId == studentId);

        }
    }
}
