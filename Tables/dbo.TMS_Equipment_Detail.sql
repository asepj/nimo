CREATE TABLE [dbo].[TMS_Equipment_Detail]
(
[Equip_ID] [bigint] NOT NULL,
[Equip_Desc] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Equip_SN] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Equip_Func_Log] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
