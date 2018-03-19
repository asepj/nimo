CREATE TABLE [dbo].[TMS_RH_Validate]
(
[Date_Entry] [datetime] NOT NULL CONSTRAINT [DF_TMS_RH_Validate_Date_Entry] DEFAULT (getdate()),
[TagName] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[RH] [float] NOT NULL,
[Comment] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Date_Time] [date] NOT NULL
) ON [PRIMARY]
GO
