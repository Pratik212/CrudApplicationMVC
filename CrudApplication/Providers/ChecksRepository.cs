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
    public class ChecksRepository : IChecksRepository
    {
        private readonly DataContext _context;

        public ChecksRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Check> AddCheck(Check check)
        {
            var checkObj = await _context.Checks.AddAsync(check);

            _context.SaveChanges();

            return checkObj.Entity;
        }

        public async Task<IEnumerable<Check>> GetAll()
        {
            return await _context.Checks.ToListAsync();
        }

        public async Task<Check> GetValueById(int id)
        {
            return await _context.Checks.FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
