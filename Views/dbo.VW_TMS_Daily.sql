SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO



CREATE view [dbo].[VW_TMS_Daily] as
select *,24-[Running Hours]-[CM S\D]-[pm s\d]-[process upset] 'Standby' from(select a.*,case when tagname IS not null then RH else 0 end 'Process Upset' from(select a.*,case when tagname IS not null then RH else 0 end 'PM S\D' from(select a.*,case when tagname IS not null then RH else 0 end 'CM S\D' from(
select a.date_time'Date',a.tagname 'Instrument Tag',case when b.tagname is not null then b.rh else a.rh end 'Running Hours' from tms_rh a left join tms_rh_validate b
on a.TagName=b.tagname and a.Date_Time =b.date_time
union
select a.Date_Time,a.tagname,a.rh from tms_rh_validate a left join TMS_RH b on a.tagname=b.TagName and a.date_time=b.Date_Time
where b.TagName is null) a left join
(select 
	date_time,
	tagname,
	cast(case 
		when CAST(startdate as date)=CAST(enddate AS date) then DATEDIFF(minute,startdate,enddate)   
		when cast(startdate as date)=date_time then datediff(MINUTE,startdate,DATEADD(D,1,date_time)) 
		when date_time=cast(enddate as date) then DATEDIFF(MINUTE,date_time,enddate) 
		when DATEDIFF(hour,startdate,date_time)>=24 then 24*60
	end as float)/60 RH 
	from tms_log a,(select distinct(date_time) date_time from(select distinct(date_time)date_time from TMS_RH union select distinct(date_time) from TMS_RH_validate union select distinct(CAST(startdate as DATE)) from tms_log union select distinct(CAST(enddate as DATE)) from tms_log)a) b
where a.classification=2 and b.Date_Time between cast(a.startdate as date) and cast(a.enddate as date) and DATEDIFF(minute,date_time,enddate)>0) b
on a.Date=b.date_time and a.[Instrument Tag]=b.tagname) a left join
(select 
	date_time,
	tagname,
	cast(case 
		when CAST(startdate as date)=CAST(enddate AS date) then DATEDIFF(minute,startdate,enddate)   
		when cast(startdate as date)=date_time then datediff(MINUTE,startdate,DATEADD(D,1,date_time)) 
		when date_time=cast(enddate as date) then DATEDIFF(MINUTE,date_time,enddate) 
		when DATEDIFF(hour,startdate,date_time)>=24 then 24*60
	end as float)/60 RH 
	from tms_log a,(select distinct(date_time) date_time from(select distinct(date_time)date_time from TMS_RH union select distinct(date_time) from TMS_RH_validate union select distinct(CAST(startdate as DATE)) from tms_log union select distinct(CAST(enddate as DATE)) from tms_log)a) b
where a.classification=3 and b.Date_Time between cast(a.startdate as date) and cast(a.enddate as date) and DATEDIFF(minute,date_time,enddate)>0) b
on a.Date=b.date_time and a.[Instrument Tag]=b.tagname) a left join
(select 
	date_time,
	tagname,
	cast(case 
		when CAST(startdate as date)=CAST(enddate AS date) then DATEDIFF(minute,startdate,enddate)   
		when cast(startdate as date)=date_time then datediff(MINUTE,startdate,DATEADD(D,1,date_time)) 
		when date_time=cast(enddate as date) then DATEDIFF(MINUTE,date_time,enddate) 
		when DATEDIFF(hour,startdate,date_time)>=24 then 24*60
	end as float)/60 RH 
	from tms_log a,(select distinct(date_time) date_time from(select distinct(date_time)date_time from TMS_RH union select distinct(date_time) from TMS_RH_validate union select distinct(CAST(startdate as DATE)) from tms_log union select distinct(CAST(enddate as DATE)) from tms_log)a) b
where a.classification=4 and b.Date_Time between cast(a.startdate as date) and cast(a.enddate as date) and DATEDIFF(minute,date_time,enddate)>0) b
on a.Date=b.date_time and a.[Instrument Tag]=b.tagname)a






--GO




GO
