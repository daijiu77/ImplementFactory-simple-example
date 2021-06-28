USE [DbTest]
GO

/****** Object:  Table [dbo].[WorkInfo]    Script Date: 2021/6/29 0:43:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[WorkInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeInfoID] [int] NULL,
	[CompanyName] [varchar](50) NULL,
	[CompanyNameEn] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


