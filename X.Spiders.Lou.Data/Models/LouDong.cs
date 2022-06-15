using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Spiders.Lou.Data.Models
{
    public class LouDong
    {
        public DateTime LastModifiedTime { get; set; }

        [Key]
        [MaxLength(50)]
        [Required]
        public string Id { get; set; }
        [MaxLength(50)]
        public string? YuShouZheng { get; set; }
        [MaxLength(50)]
        public string? DongNo { get; set; }
        public DateTime? FaZhengDate { get; set; }
        public decimal? Area { get; set; }
        [MaxLength(50)]
        public string? GuoTuZheng { get; set; }
        [MaxLength(50)]
        public string? GongChengGuiHuaZheng { get; set; }
        [MaxLength(50)]
        public string? YongDiGuiHuaZheng { get; set; }
        [MaxLength(50)]
        public string? ShiGongZheng { get; set; }

        public LouPan? LouPan { get; set; }
        public IList<TaoFang> TaoFangs { get; set; } = new List<TaoFang>();

        [NotMapped]
        public string? FangLinkKey1
        {
            get
            {
                return Id?.Split('_')[0];
            }
        }

        [NotMapped]
        public string? FangLinkKey2
        {
            get
            {
                return Id?.Split('_')[1];
            }
        }
    }
}
