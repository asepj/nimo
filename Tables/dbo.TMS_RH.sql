CREATE TABLE [dbo].[TMS_RH]
(
[Date_Time] [date] NOT NULL,
[TagName] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[RH] [float] NOT NULL,
[Status] [int] NOT NULL
) ON [PRIMARY]
GO
