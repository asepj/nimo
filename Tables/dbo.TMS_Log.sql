CREATE TABLE [dbo].[TMS_Log]
(
[Date_Entry] [date] NOT NULL,
[Tagname] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Classification] [int] NOT NULL,
[NotifNumber] [varchar] (40) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MaintenanceNote] [varchar] (300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[WaitingSparePart] [int] NOT NULL CONSTRAINT [DF_TMS_Log_WaitingSparePart] DEFAULT ((0)),
[StartDate] [datetime] NOT NULL,
[EndDate] [datetime] NULL
) ON [PRIMARY]
GO
