USE [DevHNWow]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 03/06/2015 22:49:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NULL,
	[IntroductionDate] [datetime] NULL,
	[Cost] [decimal](18, 2) NULL,
	[Price] [decimal](18, 2) NULL,
	[AccountId] [int] NULL,
	[Stock] [int] NULL,
	[IsDiscontinued] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

