CREATE TABLE [dbo].[TMS_Group_Area_Name]
(
[Group_Area_ID] [bigint] NOT NULL IDENTITY(1, 1),
[Group_Area_Desc] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TMS_Group_Area_Name] ADD CONSTRAINT [PK_TMS_Group_Area] PRIMARY KEY CLUSTERED  ([Group_Area_ID]) ON [PRIMARY]
GO
