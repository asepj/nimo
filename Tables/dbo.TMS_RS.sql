CREATE TABLE [dbo].[TMS_RS]
(
[Date_Time] [date] NOT NULL,
[Tagname] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Running] [bit] NOT NULL,
[Running_Issued_Day] [int] NOT NULL
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TMS_RS] ON [dbo].[TMS_RS] ([Date_Time]) ON [PRIMARY]
GO
