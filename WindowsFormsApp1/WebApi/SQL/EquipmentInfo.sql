USE [DbTest]
GO

if exists(select * from sysobjects where name='EquipmentInfo')
begin
drop table [dbo].[EquipmentInfo]
end
go

/****** Object:  Table [dbo].[EquipmentInfo]    Script Date: 2020/9/4 13:37:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EquipmentInfo](
	[id] [uniqueidentifier] NOT NULL,
	[height] [int] NULL,
	[width] [int] NULL,
	[equipmentName] [varchar](50) NULL,
	[code] [varchar](50) NULL,
	[cdatetime] [datetime] NULL,
 CONSTRAINT [PK_EquipmentInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EquipmentInfo] ADD  CONSTRAINT [DF_EquipmentInfo_id]  DEFAULT (newid()) FOR [id]
GO

ALTER TABLE [dbo].[EquipmentInfo] ADD  CONSTRAINT [DF_EquipmentInfo_cdatetime]  DEFAULT (getdate()) FOR [cdatetime]
GO


