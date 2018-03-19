SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
create view [dbo].[VW_TMS_Last_PM] as
select Date_Time,TagName,Area_Desc,Equip_Desc,Equip_SN,Equip_Func_Log,PMType,PMO,RH,Result,NPM,Remarks from TMS_PM a,TMS_Equipment b,TMS_Equipment_Detail c,TMS_Area d
where a.tagname=b.Equip_Tag and b.Equip_ID=c.Equip_ID and b.Area_ID=d.Area_ID
GO
