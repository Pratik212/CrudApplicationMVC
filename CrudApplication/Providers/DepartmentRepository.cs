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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;

        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Department> Add(Department department)
        {
            var result = await _context.Departments.AddAsync(department);

            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Department> DeleteDepartment(int departmentId)
        {
            var departmentObj = await _context.Departments.FirstOrDefaultAsync(e => e.Id == departmentId);
            if (departmentObj != null)
            {
                _context.Departments.Remove(departmentObj);
                await _context.SaveChangesAsync();
                return departmentObj;
            }

            return null;
        }

        public async Task<IEnumerable<Department>> GetAllData()
        {
            return await _context.Departments.ToListAsync();    
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
