using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baymax.Models
{
    public class AddressModel
    {
        [Required]
        [RegularExpression(@"[A-Z]|[a-z]|[0-9]|\.|\/|\,|\:|\'|\s|\-")]
        public string Line1 {get;set;}
        [RegularExpression(@"[A-Z]|[a-z]|[0-9]|\.|\/|\,|\:|\'|\s|\-")]
        public string Line2 { get; set; }
        [RegularExpression(@"[A-Z]|[a-z]|[0-9]|\.|\/|\,|\:|\'|\s|\-")]
        public string Line3 { get; set; }
        [RegularExpression(@"[A-Z]|[a-z]|[0-9]|\.|\/|\,|\:|\'|\s|\-")]
        [Required]
        public string Town { get; set; }
        [MaxLength(18)]
        [RegularExpression(@"[A-Z]|[a-z]|[0-9]|\.|\/|\,|\:|\'|\s|\-")]
        [Required]
        public string County { get; set; }
        [MaxLength(8)]
        [RegularExpression(@"[A-Z]|[a-z]|[0-9]|\s")]
        [Required]
        public string Postcode { get; set; }

        public override string ToString()
        {
            var lines = new [] {Line1, Line2, Line3, Town, County, Postcode};
            return string.Join(", ", lines.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()));
        }
    }
}
