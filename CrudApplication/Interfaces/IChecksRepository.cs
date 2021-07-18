using CrudApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Interfaces
{
    public interface IChecksRepository
    {
        Task<IEnumerable<Check>> GetAll();
        
        Task<Check> AddCheck(Check check);

        Task<Check> GetValueById(int id);
    }
}
