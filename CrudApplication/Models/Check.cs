using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Models
{
    public class Check
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
