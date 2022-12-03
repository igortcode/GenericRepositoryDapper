USE [DapperGRP]
GO

/****** Object:  Table [dbo].[product]    Script Date: 03/12/2022 13:48:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[product]') AND type in (N'U'))
DROP TABLE [dbo].[product]
GO

/****** Object:  Table [dbo].[product]    Script Date: 03/12/2022 13:48:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[product](
	[Id] [varchar](36) PRIMARY KEY DEFAULT NEWID(),
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](300) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL
) ON [PRIMARY]
GO


