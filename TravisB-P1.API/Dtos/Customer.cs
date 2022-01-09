using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisB_P1.API.Dtos
{
    public class Customer
    {
        [Required]
        public string _Name { get; set; }
    }
}

