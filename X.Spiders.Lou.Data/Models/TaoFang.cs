using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Spiders.Lou.Data.Models
{
    public class TaoFang
    {
        public DateTime LastModifiedTime { get; set; }

        [Key]
        [MaxLength(100)]
        [Required]
        public string Id { get; set; }
        [MaxLength(50)]
        public string? Num { get; set; }
        public int? Floor { get; set; }
        [MaxLength(50)]
        public string? Usage { get; set; }
        [MaxLength(50)]
        public string? Type { get; set; }
        public decimal? BuildingArea { get; set; }
        public decimal? TaoNeiArea { get; set; }
        public decimal? GongTanArea { get; set; }
        [MaxLength(50)]
        public string? SaleStatus { get; set; }

        public LouDong? LouDong { get; set; }
    }
}
