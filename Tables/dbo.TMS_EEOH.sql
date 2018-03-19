CREATE TABLE [dbo].[TMS_EEOH]
(
[Date_Time] [date] NOT NULL,
[TagName] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LRPTarget] [float] NULL,
[EE] [bit] NULL CONSTRAINT [DF_TMS_EEOH_EE] DEFAULT ((0)),
[NextActionHours] [float] NULL,
[Notes] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
