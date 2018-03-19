CREATE TABLE [dbo].[TMS_Equipment]
(
[Equip_ID] [bigint] NOT NULL IDENTITY(1, 1),
[Equip_Tag] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Area_ID] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TMS_Equipment] ADD CONSTRAINT [PK_TMS_Equipment] PRIMARY KEY CLUSTERED  ([Equip_ID]) ON [PRIMARY]
GO
