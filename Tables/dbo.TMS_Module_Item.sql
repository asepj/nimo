CREATE TABLE [dbo].[TMS_Module_Item]
(
[Item_ID] [bigint] NOT NULL IDENTITY(1, 1),
[Module_ID] [int] NOT NULL,
[Item_Name] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Item_Desc] [varchar] (40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Item_Table] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Query_View] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[View_Page] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF__TMS_Modul__View___29572725] DEFAULT ('grid')
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TMS_Module_Item] ADD CONSTRAINT [PK_TMS_Module_Item] PRIMARY KEY CLUSTERED  ([Item_ID]) ON [PRIMARY]
GO
