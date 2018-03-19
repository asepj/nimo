SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
create view [dbo].[VW_TMS_Running_Strategy] as 
select Date_Time,TagName,Area_Desc,equip_desc,Equip_sn,equip_func_log,case when running=1 then 'Running' else 'Stop' end Running from(select calcdate Date_Time,TagName,running from dbo.explodedate('2018-01-01') a, tms_rs b
where calcdate between date_time and DATEADD(D,running_issued_day-1,date_time))a left join vw_tms_equipment_detail b
on replace(a.tagname,' ','')=b.equip_tag
GO
