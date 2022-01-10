using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisB_P1API.API.Dtos
{
    public class CustomerDtos
    {
        [Required]
        public string name { get; set; }
    }
}