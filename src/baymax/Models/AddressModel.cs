using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace baymax.Models
{
    public class AddressModel
    {
        [Required]
        [MaxLength(16)]
        public string Line1 {get;set;}
        public string Line2 { get; set; }
    }
}
