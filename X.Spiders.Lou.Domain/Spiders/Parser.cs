using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using X.Spiders.Lou.Data.Models;
using X.Spiders.Lou.Domain.Utils;

namespace X.Spiders.Lou.Domain.Spiders
{
    public class Parser
    {
        public async Task ParseLouPan(LouPan louPan, string source)
        {
            IBrowsingContext context = BrowsingContext.New(Configuration.Default);
            IDocument document = await context.OpenAsync(req => req.Content(source));

            var table = document.QuerySelector<AngleSharp.Html.Dom.IHtmlTableElement>("div.hs_xqxx table");
            if (table == null) return;

            louPan.Name = table.Rows[0].Cells[0].Text();
            louPan.District = table.Rows[1].Cells[1].Text();
            louPan.PiWenNo = table.Rows[1].Cells[3].Text();
            louPan.KaiFaShang = table.Rows[2].Cells[1].Text();
            louPan.DongCount = table.Rows[2].Cells[3].Text().XToIntOrNull();
            louPan.ProjectAddress = table.Rows[3].Cells[1].Text();
            louPan.Price = table.Rows[3].Cells[3].Text().XToDecimalOrNull();
            louPan.SalesAddress = table.Rows[4].Cells[1].Text();
            louPan.SalesTel = table.Rows[4].Cells[3].Text();
            louPan.FangCount = table.Rows[5].Cells[1].Text().XToIntOrNull();
            louPan.Bus = table.Rows[5].Cells[3].Text();
            louPan.Area = table.Rows[6].Cells[1].Text().XToDecimalOrNull();
            louPan.Designer = table.Rows[6].Cells[3].Text();
            louPan.BuildingArea = table.Rows[7].Cells[1].Text().XToDecimalOrNull();
            louPan.SalesAgent = table.Rows[7].Cells[3].Text();
            louPan.RongJiRate = table.Rows[8].Cells[1].Text().XToDecimalOrNull();
            louPan.WuYeCompany = table.Rows[8].Cells[3].Text();
            louPan.LvHuaRate = table.Rows[9].Cells[1].Text().XToDecimalOrNull();
            louPan.ShiGongDanWei = table.Rows[9].Cells[3].Text();
            louPan.WuYeFee = table.Rows[10].Cells[1].Text();
            louPan.CompleteDate = table.Rows[10].Cells[3].Text().XToDateTimeOrNull();
            louPan.Description = table.Rows[1].Cells[1].Text();

            ParseLouDong(document, louPan);
        }

        private async Task ParseLouDong(IDocument document, LouPan louPan)
        {
            var table = document.QuerySelector<AngleSharp.Html.Dom.IHtmlTableElement>("div.hs_table table");
            if (table == null) return;

            foreach (var row in table.Rows)
            {
                if (row.Index == 0 || (row.ClassName?.Contains("hs_table1") ?? false)) continue;
                var louDong = new LouDong();
                louDong.Id = GetLouDongId(row.Cells[8].Attributes["onclick"]?.Value);
                if (louDong.Id == null) continue;

                louDong.YuShouZheng = row.Cells[0].Text();
                louDong.DongNo = row.Cells[1].Text();
                louDong.FaZhengDate = row.Cells[2].Text().XToDateTimeOrNull();
                louDong.Area = row.Cells[3].Text().XToDecimalOrNull();
                louDong.GuoTuZheng = row.Cells[4].Text();
                louDong.GongChengGuiHuaZheng = row.Cells[5].Text();
                louDong.YongDiGuiHuaZheng = row.Cells[6].Text();
                louDong.ShiGongZheng = row.Cells[7].Text();

                louDong.LouPan = louPan;
                louPan.LouDongs.Add(louDong);
            }
        }

        private string GetLouDongId(string onclickValue)
        {
            if (string.IsNullOrWhiteSpace(onclickValue)) return null;
            var match = Regex.Match(onclickValue, @"\(.*\)");
            if (!match.Success) return null;

            var arr = match.Value.TrimStart('(').TrimEnd(')').Split(',');
            if (arr.Length <= 1) return null;

            return $"{arr[0].Trim('\'')}_{arr[1]}";
        }

        public async Task ParseTaoFang(LouDong louDong, string source)
        {
            source = $"<table>{source.Trim('"').Replace(@"\/", "/")}</table>";
            IBrowsingContext context = BrowsingContext.New(Configuration.Default);
            IDocument document = await context.OpenAsync(req => req.Content(source));

            var table = document.QuerySelector<AngleSharp.Html.Dom.IHtmlTableElement>("table");
            if (table == null) return;

            foreach (var row in table.Rows)
            {
                var taoFang = new TaoFang();
                taoFang.Num = row.Cells[0].Text();
                if (string.IsNullOrWhiteSpace(taoFang.Num)) continue;
                taoFang.Id = $"{louDong.Id}_{taoFang.Num}";
                taoFang.Floor = row.Cells[1].Text().XToIntOrNull();
                taoFang.Usage = row.Cells[2].Text().XFromUtf16Str();
                taoFang.Type = row.Cells[3].Text().XFromUtf16Str();
                taoFang.BuildingArea = row.Cells[4].Text().XToDecimalOrNull();
                taoFang.TaoNeiArea = row.Cells[5].Text().XToDecimalOrNull();
                taoFang.GongTanArea = row.Cells[6].Text().XToDecimalOrNull();
                taoFang.SaleStatus = row.Cells[7].Text().XFromUtf16Str();

                taoFang.LouDong = louDong;
                louDong.TaoFangs.Add(taoFang);
            }
        }
    }
}
