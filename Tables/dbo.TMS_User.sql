CREATE TABLE [dbo].[TMS_User]
(
[User_ID] [bigint] NOT NULL IDENTITY(1, 1),
[User_Account] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[User_Name] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[User_Priv] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TMS_User] ADD CONSTRAINT [PK_TMS_User] PRIMARY KEY CLUSTERED  ([User_ID]) ON [PRIMARY]
GO
