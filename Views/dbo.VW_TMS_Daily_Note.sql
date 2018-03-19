SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
create view [dbo].[VW_TMS_Daily_Note] as
select a.*,maintenancenote'Process Upset' from(select a.*,maintenancenote'PM Comment' from(select a.*,maintenancenote 'CM Comment' from(select a.date_time,a.TagName,b.comment 'Running Hours Comment' from(select *from(select distinct(date_time) from(select distinct(date_time) date_time from tms_rh union
select distinct(date_time) from tms_rh_validate)a)a ,(select distinct(tagname)from tms_rh)b)a left join tms_rh_validate b on a.date_time=b.date_time and a.TagName=b.tagname)a left join
(select a.date_time,tagname,maintenancenote  from(select distinct(date_time) from(select distinct(date_time) date_time from tms_rh union
select distinct(date_time) from tms_rh_validate)a)a left join tms_log b
on a.date_time between CAST(startdate as date) and CAST(enddate as date) and classification=2
where tagname is not null) b on a.date_time=b.date_time and a.TagName=b.tagname)a left join
(select a.date_time,tagname,maintenancenote  from(select distinct(date_time) from(select distinct(date_time) date_time from tms_rh union
select distinct(date_time) from tms_rh_validate)a)a left join tms_log b
on a.date_time between CAST(startdate as date) and CAST(enddate as date) and classification=3
where tagname is not null) b on a.date_time=b.date_time and a.TagName=b.tagname)a left join
(select a.date_time,tagname,maintenancenote  from(select distinct(date_time) from(select distinct(date_time) date_time from tms_rh union
select distinct(date_time) from tms_rh_validate)a)a left join tms_log b
on a.date_time between CAST(startdate as date) and CAST(enddate as date) and classification=4
where tagname is not null) b on a.date_time=b.date_time and a.TagName=b.tagname
GO
