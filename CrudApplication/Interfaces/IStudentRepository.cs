using CrudApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudent();

        Task<Student> AddStudent(Student student);
        Task<Student> GetStudentById(int studentId);

        Task<Student> DeleteStudent(int studentId);

    }
}
