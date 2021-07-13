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
    public class InfoRepository : IInfoRepository
    {
        private readonly DataContext _context;

        public InfoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Info> AddInfo(Info info)
        {
            var infoObj = await _context.Infos.AddAsync(info);

            _context.SaveChanges();
            return infoObj.Entity;
        }

        public async Task<Info> DeleteInfo(int id)
        {

            var infoObj = await _context.Infos.FirstOrDefaultAsync(e => e.Id == id);
            if (infoObj != null)
            {
                _context.Infos.Remove(infoObj);
                await _context.SaveChangesAsync();
                return infoObj;
            }

            return null;
        }

        public async Task<IEnumerable<Info>> GetAll()
        {
            return await _context.Infos.ToListAsync();
        }

        public async Task<Info> GetById(int id)
        {
            return await _context.Infos.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async void SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
