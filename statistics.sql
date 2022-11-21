select a.NewName,b.DongNo,c.Num,c.* 
from [dbo].[LouPans] a join [dbo].[LouDongs] b on a.Id=b.LouPanId
join [dbo].[TaoFangs] c on b.Id=c.LouDongId
where c.SaleStatusChangeTime>GETDATE()-7
order by a.NewName, b.DongNo, c.Num