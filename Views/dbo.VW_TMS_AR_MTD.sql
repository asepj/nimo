SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
create view [dbo].[VW_TMS_AR_MTD] as
select DATE,[Instrument Tag],(totrh+totpu+totstandby)*100/timeav Availability,(totrh+totpu+totstandby)*100/timeav Reliability from(select b.date,a.[Instrument Tag],SUM(a.[running hours]) totrh,SUM(a.[cm s\d]) totcm,SUM(a.[pm s\d]) totpm,SUM(a.[process upset]) totpu,SUM(a.[standby]) totstandby,(DATEDIFF(D,'01-'+CONVERT(varchar(3),b.date,100)+'-'+right(Convert(varchar(20),b.date,100),4),b.date)+1)*24 timeav from vw_tms_daily a, vw_tms_daily b
where a.[instrument tag]=b.[instrument tag] and
      a.date<=b.date and a.date>='01-'+CONVERT(varchar(3),b.date,100)+'-'+right(Convert(varchar(20),b.date,100),4)      
group by b.date,a.[instrument tag])a
GO
