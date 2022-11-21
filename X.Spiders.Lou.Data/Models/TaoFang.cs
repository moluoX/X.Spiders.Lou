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
        public DateTime? SaleStatusChangeTime { get; set; }

        public LouDong? LouDong { get; set; }

        public string CalCssClass()
        {
            if (SaleStatus == "已售")
            {
                if (SaleStatusChangeTime == null) return "sold";
                var days = (DateTime.Now.Date - SaleStatusChangeTime.Value.Date).Days;
                return days <= 30 ? $"sold{days}" : "sold";
            }
            else
                return SaleStatusChangeTime == null ? "unsold" : "returns";
        }

        public string CalColor()
        {
            if (SaleStatus == "已售")
            {
                if (SaleStatusChangeTime == null) return "cornflowerblue";
                var days = (DateTime.Now.Date - SaleStatusChangeTime.Value.Date).Days;
                if (days > 30) return "cornflowerblue";
                var gb = (days * 7).ToString("X2");
                return $"#ff{gb}{gb}";
            }
            else
                return SaleStatusChangeTime == null ? "darkgray" : "lightgreen";
        }
    }
}
