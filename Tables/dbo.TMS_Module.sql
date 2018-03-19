CREATE TABLE [dbo].[TMS_Module]
(
[Module_ID] [int] NOT NULL IDENTITY(1, 1),
[Modul_Name] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Modul_Desc] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Modul_Title] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TMS_Module] ADD CONSTRAINT [PK_TMS_Module] PRIMARY KEY CLUSTERED  ([Module_ID]) ON [PRIMARY]
GO
