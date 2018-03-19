SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO



CREATE view [dbo].[VW_TMS_Module] as
select user_account,b.Modul_Name,Modul_Desc,Modul_Title,Module_ID from tms_user a, tms_module b
where a.User_Priv=1 union
select user_account,b.Modul_Name,Modul_Desc,Modul_Title,Module_ID from tms_user a, tms_module b
where a.User_Priv>1and b.Module_ID<3



GO
