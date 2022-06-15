using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Spiders.Lou.Data.Models
{
    public class Config
    {
        [Key]
        [MaxLength(50)]
        [Required]
        public string Key { get; set; }
        public string? Value { get; set; }
        public string? Remark { get; set; }
    }
}
