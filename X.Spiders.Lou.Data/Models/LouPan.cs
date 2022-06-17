using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Spiders.Lou.Data.Models
{
    public class LouPan
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime LastModifiedTime { get; set; }

        [Key]
        [MaxLength(50)]
        [Required]
        public string Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(50)]
        public string? District { get; set; }
        [MaxLength(50)]
        public string? PiWenNo { get; set; }
        [MaxLength(50)]
        public string? KaiFaShang { get; set; }
        public int? DongCount { get; set; }
        [MaxLength(200)]
        public string? ProjectAddress { get; set; }
        public decimal? Price { get; set; }
        [MaxLength(200)]
        public string? SalesAddress { get; set; }
        [MaxLength(50)]
        public string? SalesTel { get; set; }
        public int? FangCount { get; set; }
        [MaxLength(200)]
        public string? Bus { get; set; }
        public decimal? Area { get; set; }
        [MaxLength(50)]
        public string? Designer { get; set; }
        public decimal? BuildingArea { get; set; }
        [MaxLength(50)]
        public string? SalesAgent { get; set; }
        public decimal? RongJiRate { get; set; }
        [MaxLength(50)]
        public string? WuYeCompany { get; set; }
        public decimal? LvHuaRate { get; set; }
        [MaxLength(50)]
        public string? ShiGongDanWei { get; set; }
        [MaxLength(50)]
        public string? WuYeFee { get; set; }
        public DateTime? CompleteDate { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [MaxLength(50)]
        public string? NewName { get; set; }

        public IList<LouDong> LouDongs { get; set; } = new List<LouDong>();
    }
}
