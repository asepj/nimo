SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
create view [dbo].[VW_TMS_EEOH] as
select Date_Time,TagName,Area_Desc,Equip_Desc,Equip_SN,Equip_Func_Log,LRPTarget,case when EE=0 then 'Engine Exchange' else 'Over Hault' end EE,NextActionHours,Notes from TMS_EEOH a,TMS_Equipment b,TMS_Equipment_Detail c,TMS_Area d
where a.tagname=b.Equip_Tag and b.Equip_ID=c.Equip_ID and b.Area_ID=d.Area_ID
GO
