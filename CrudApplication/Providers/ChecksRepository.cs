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
        public async Task<IEnumerable<Check>> GetAll()
        {
            return await _context.Checks.ToListAsync();
        }
    }
}
