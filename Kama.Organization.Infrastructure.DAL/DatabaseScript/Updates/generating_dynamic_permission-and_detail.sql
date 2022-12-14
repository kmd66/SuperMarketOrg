USE [Kama.Sm.Organization]
GO
/****** Object:  Table [org].[DynamicPermission]    Script Date: 7/12/2020 2:16:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [org].[DynamicPermission](
	[ID] [uniqueidentifier] NOT NULL,
	[ApplicationID] [uniqueidentifier] NOT NULL,
	[ObjectID] [uniqueidentifier] NOT NULL,
	[Order] [int] NOT NULL,
	[CreationDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_DynamicPermission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [org].[DynamicPermissionDetail]    Script Date: 7/12/2020 2:16:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [org].[DynamicPermissionDetail](
	[ID] [uniqueidentifier] NOT NULL,
	[DynamicPermissionID] [uniqueidentifier] NOT NULL,
	[Type] [tinyint] NOT NULL,
	[GuidValue] [uniqueidentifier] NULL,
	[ByteValue] [tinyint] NOT NULL,
 CONSTRAINT [PK_DynamicPermissionDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [org].[DynamicPermissionDetail]  WITH CHECK ADD  CONSTRAINT [FK_DynamicPermissionDetail_DynamicPermission] FOREIGN KEY([DynamicPermissionID])
REFERENCES [org].[DynamicPermission] ([ID])
GO
ALTER TABLE [org].[DynamicPermissionDetail] CHECK CONSTRAINT [FK_DynamicPermissionDetail_DynamicPermission]
GO
