using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Models
{
    public class Person
    {

        public Nullable<long> PersonId { get; set; }

        public bool Selected { get; set; }

        public string Name { get; set; }

    }
}
