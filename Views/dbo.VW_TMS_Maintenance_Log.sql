SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
create view [dbo].[VW_TMS_Maintenance_Log] as
select calcdate Date,Tagname,Area_Desc,Equip_Desc,Equip_SN,Equip_Func_Log,cast(case when CAST(startdate as date)=CAST(enddate as date) then DATEDIFF(MI,StartDate,EndDate) when StartDate>=calcdate then DATEDIFF(MI,StartDate,dateadd(D,1,calcdate)) when DATEDIFF(D,calcdate,EndDate)>1 then 60*24 when EndDate>=calcdate then DATEDIFF(MI,calcdate,EndDate) end as float)/60 Downtime,Description,NotifNumber,MaintenanceNote,case when EndDate IS null then 'N0' else 'Yes' end Completed,case when WaitingSparePart=1 then 'Yes' else 'No' end WaitingSparePart from tms_log a,TMS_Equipment b,TMS_Equipment_Detail c,TMS_Area d,TMS_Work_Classification e,dbo.explodedate('2018-01-01') f
where a.Tagname=b.Equip_Tag and b.Equip_ID=c.Equip_ID and b.Area_ID=d.Area_ID and a.Classification=e.Status_ID and f.calcdate between CAST(startdate as DATE) and EndDate and EndDate!=calcdate

GO
