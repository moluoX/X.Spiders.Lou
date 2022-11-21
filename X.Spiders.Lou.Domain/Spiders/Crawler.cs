using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Spiders.Lou.Data.Models;
using X.Spiders.Lou.Domain.Utils;

namespace X.Spiders.Lou.Domain.Spiders
{
    public class Crawler
    {
        private readonly HttpClient _httpClient;
        private readonly Parser _parser;
        private readonly Storer _storer;

        public Crawler(HttpClient httpClient, Parser parser, Storer storer)
        {
            _httpClient = httpClient;
            _parser = parser;
            _storer = storer;
        }

        public async Task CrawlLouPan(SpiderContext context, LouPan louPan)
        {
            var uri = string.Format(context.Configs["LouPanUri"], louPan.Id);
            var responseString = await _httpClient.GetStringAsync(uri);

            await _parser.ParseLouPan(louPan, responseString);
            await _storer.StoreLouPan(louPan);

            context.LouPans.Add(new LouPan
            {
                Id = louPan.Id,
                Name = louPan.Name,
                LouDongs = louPan.LouDongs.Select(x => new LouDong
                {
                    Id = x.Id,
                    DongNo = x.DongNo
                }).ToList()
            });

            foreach (var louDong in louPan.LouDongs)
            {
                await CrawlTaoFang(context, louDong);
            }
        }

        private async Task CrawlTaoFang(SpiderContext context, LouDong louDong)
        {
            var uri = context.Configs["TaoFangUri"];
            var content = new StringContent(
                string.Format(context.Configs["TaoFangBody"], louDong.FangLinkKey1, louDong.FangLinkKey2),
                Encoding.UTF8, "application/x-www-form-urlencoded");
            //var response = await _httpClient.PostAsync(uri, content);
            var response = new Func<HttpResponseMessage>(() => _httpClient.PostAsync(uri, content).Result).WithRetry();

            if (!response.IsSuccessStatusCode) return;

            var taoFangs = await _parser.ParseTaoFang(louDong, await response.Content.ReadAsStringAsync());
            await _storer.StoreTaoFang(taoFangs);

            context.LouPans.First(x => x.Id == louDong.LouPan.Id)
                .LouDongs.First(x => x.Id == louDong.Id)
                .TaoFangs = louDong.TaoFangs.Select(x => new TaoFang
                {
                    Id = x.Id,
                    Num = x.Num
                }).ToList();
        }
    }
}
