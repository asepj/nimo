SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE view [dbo].[VW_TMS_Module_Item] as
select user_account,c.module_id,modul_name,item_name,item_desc,item_id,query_view,view_page from tms_module_item a, tms_user b,tms_module c
where b.user_priv=1 and a.module_id=c.module_id union
select user_account,c.module_id,modul_name,item_name,item_desc,item_id,query_view,view_page  from tms_module_item a, tms_user b,tms_module c
where b.user_priv>1 and a.module_id<3 and a.module_id=c.module_id 

GO
