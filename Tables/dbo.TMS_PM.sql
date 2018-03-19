CREATE TABLE [dbo].[TMS_PM]
(
[Date_Time] [date] NOT NULL,
[TagName] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[PMType] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[PMO] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[RH] [float] NULL,
[Result] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NPM] [float] NULL,
[Remarks] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
