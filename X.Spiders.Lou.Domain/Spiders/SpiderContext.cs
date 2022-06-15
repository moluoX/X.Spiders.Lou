using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Spiders.Lou.Data.Models;

namespace X.Spiders.Lou.Domain.Spiders
{
    public class SpiderContext
    {
        public Dictionary<string, string?> Configs { get; set; }

        public IList<LouPan> LouPans { get; set; } = new List<LouPan>();
    }
}
