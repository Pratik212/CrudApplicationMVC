using CrudApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Interfaces
{
     public interface IInfoRepository
    {
        Task<IEnumerable<Info>> GetAll();

        Task<Info> GetById(int id);

        Task<Info> AddInfo(Info info);

        Task<Info> DeleteInfo(int id);
        void SaveChanges();
    }
}
