using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Spiders.Lou.Data;
using X.Spiders.Lou.Data.Models;

namespace X.Spiders.Lou.Domain.Spiders
{
    public class Spider
    {
        private static bool IS_RUNNING = false;
        private readonly SpiderDbContext _db;
        private readonly Crawler _crawler;
        public readonly SpiderContext Context = new SpiderContext();

        public Spider(SpiderDbContext db, Crawler crawler)
        {
            _db = db;
            _crawler = crawler;
        }

        public async Task RunAsync()
        {
            if (IS_RUNNING) return;
            IS_RUNNING = true;

            try
            {
                Context.Configs = _db.Configs.ToDictionary(x => x.Key, x => x.Value);

                var louPans = _db.LouPans.Where(x => !x.IsDeleted);
                foreach (var louPan in louPans)
                {
                    await _crawler.CrawlLouPan(Context, louPan);
                }
            }
            finally
            {
                IS_RUNNING = false;
            }
        }
    }
}
