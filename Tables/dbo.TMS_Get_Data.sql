CREATE TABLE [dbo].[TMS_Get_Data]
(
[QueryName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[QueryScript] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Tablename] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[TMS_Get_Data] ADD CONSTRAINT [PK_TMS_Get_Data] PRIMARY KEY CLUSTERED  ([QueryName]) ON [PRIMARY]
GO
