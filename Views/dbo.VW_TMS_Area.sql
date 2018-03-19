SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
create view [dbo].[VW_TMS_Area] as
select user_account,c.group_area_desc,d.area_id,e.area_desc from tms_user a, tms_user_area b, tms_group_area_name c,tms_group_area_member d,tms_area e
where a.user_priv>1 and a.user_id=b.user_id and b.group_area_id=c.group_area_id and d.group_area_id=c.group_area_id and d.area_id=e.area_id union
select user_account,'Administrator',area_id,area_desc from tms_user a,tms_area b
where a.user_priv=1
GO
