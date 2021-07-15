using CrudApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Interfaces
{
     public interface IDepartmentRepository
    {

        Task<IEnumerable<Department>> GetAllData();

        Task<Department> Add(Department department);

        Task<Department> GetDepartmentById(int id);

        Task<Department> DeleteDepartment(int departmentId);

    }
}
