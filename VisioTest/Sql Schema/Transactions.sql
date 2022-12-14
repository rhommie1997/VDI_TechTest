create database [VDI_TechTest]
USE [VDI_TechTest]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 11/13/2022 3:51:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Transaction_ID] [char](14) NOT NULL,
	[Tipe_Customer] [varchar](20) NOT NULL,
	[Point_Reward] [float] NOT NULL,
	[TOTAL_BELANJA] [float] NOT NULL,
	[Diskon] [float] NOT NULL,
	[TotalBayar] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Transaction_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
