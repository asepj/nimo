SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
create view [dbo].[VW_TMS_Equipment_Detail] as
select a.equip_id,c.* ,equip_tag,equip_desc,Equip_sn,equip_func_log from TMS_equipment a left join tms_equipment_detail b
on a.equip_id=b.equip_id left join tms_area c on a.area_id=c.area_id
GO
