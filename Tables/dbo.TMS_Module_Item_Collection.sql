CREATE TABLE [dbo].[TMS_Module_Item_Collection]
(
[Item_Collection_ID] [bigint] NOT NULL IDENTITY(1, 1),
[Item_ID] [bigint] NOT NULL,
[Column_Name] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Column_Name_View] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Column_DataType] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Entry_Data] [bit] NOT NULL,
[Column_Entry_Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Column_View_Index] [int] NOT NULL,
[Hidden] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TMS_Module_Item_Collection] ADD CONSTRAINT [PK_TMS_Module_Item_collection] PRIMARY KEY CLUSTERED  ([Item_Collection_ID]) ON [PRIMARY]
GO
