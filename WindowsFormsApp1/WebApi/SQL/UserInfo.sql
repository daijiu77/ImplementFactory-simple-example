USE [DbTest]
GO

if exists(select * from sysobjects where name='UserInfo')
begin
drop table [dbo].[UserInfo]
end

/****** Object:  Table [dbo].[UserInfo]    Script Date: 2020/8/22 16:17:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UserInfo](
	[id] [uniqueidentifier] NOT NULL primary key DEFAULT (newid()),
	[name] [varchar](50) NULL,
	[age] [int] NULL,
	[address] [varchar](500) NULL,
	cdatetime datetime default(convert(varchar(50),getdate(),121))
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


