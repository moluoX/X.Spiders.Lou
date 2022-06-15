using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Spiders.Lou.Data;
using X.Spiders.Lou.Data.Models;

namespace X.Spiders.Lou.Domain.Spiders
{
    public class Storer
    {
        private readonly SpiderDbContext _db;

        public Storer(SpiderDbContext db)
        {
            _db = db;
        }

        public async Task StoreLouPan(LouPan louPan)
        {
            louPan.LastModifiedTime = DateTime.Now;
            if (_db.LouPans.Any(x => x.Id == louPan.Id))
                _db.LouPans.Update(louPan);
            else
                _db.LouPans.Add(louPan);

            foreach (var louDong in louPan.LouDongs)
            {
                louDong.LastModifiedTime = DateTime.Now;
                if (_db.LouDongs.Any(x => x.Id == louDong.Id))
                    _db.LouDongs.Update(louDong);
                else
                    _db.LouDongs.Add(louDong);
            }

            await _db.SaveChangesAsync();
        }

        public async Task StoreTaoFang(IList<TaoFang> taoFangs)
        {
            foreach (TaoFang taoFang in taoFangs)
            {
                taoFang.LastModifiedTime = DateTime.Now;
                if (_db.TaoFangs.Any(x => x.Id == taoFang.Id))
                    _db.TaoFangs.Update(taoFang);
                else
                    _db.TaoFangs.Add(taoFang);
            }
            await _db.SaveChangesAsync();
        }
    }
}
