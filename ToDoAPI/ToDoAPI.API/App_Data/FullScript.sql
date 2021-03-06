/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.5026)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
ALTER TABLE [dbo].[TodoItems] DROP CONSTRAINT [FK_TodoItems_Categories]
GO
/****** Object:  Table [dbo].[TodoItems]    Script Date: 1/13/2022 8:45:17 PM ******/
DROP TABLE [dbo].[TodoItems]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 1/13/2022 8:45:17 PM ******/
DROP TABLE [dbo].[Categories]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 1/13/2022 8:45:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TodoItems]    Script Date: 1/13/2022 8:45:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TodoItems](
	[TodoId] [int] IDENTITY(1,1) NOT NULL,
	[Action] [nvarchar](max) NOT NULL,
	[Done] [bit] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_TodoItems] PRIMARY KEY CLUSTERED 
(
	[TodoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (1, N'Miscellaneous', N'Miscellaneous')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (2, N'Kitchen', N'Kitchen')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (3, N'Living Room', N'Living Room')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (4, N'Bedroom 1', N'Master')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (5, N'Bedroom 2', N'Charlie''s Room')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (6, N'Bedroom 3', N'Twin''s Room')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (7, N'Bathroom 1', N'Upstairs Bath')
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (8, N'Bathroom 2', N'Downstairs Bath')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[TodoItems] ON 

INSERT [dbo].[TodoItems] ([TodoId], [Action], [Done], [CategoryId]) VALUES (1, N'Closet Under Stairs', 0, 1)
INSERT [dbo].[TodoItems] ([TodoId], [Action], [Done], [CategoryId]) VALUES (3, N'Dishes', 1, 2)
INSERT [dbo].[TodoItems] ([TodoId], [Action], [Done], [CategoryId]) VALUES (5, N'Organize Toys', 0, 3)
INSERT [dbo].[TodoItems] ([TodoId], [Action], [Done], [CategoryId]) VALUES (6, N'Laundry', 0, 1)
INSERT [dbo].[TodoItems] ([TodoId], [Action], [Done], [CategoryId]) VALUES (7, N'Organize Office Space', 1, 4)
INSERT [dbo].[TodoItems] ([TodoId], [Action], [Done], [CategoryId]) VALUES (8, N'Organize Toys', 0, 5)
INSERT [dbo].[TodoItems] ([TodoId], [Action], [Done], [CategoryId]) VALUES (9, N'Get rid of small clothes', 0, 6)
INSERT [dbo].[TodoItems] ([TodoId], [Action], [Done], [CategoryId]) VALUES (10, N'Clean Tub', 0, 7)
INSERT [dbo].[TodoItems] ([TodoId], [Action], [Done], [CategoryId]) VALUES (11, N'Declutter', 0, 8)
SET IDENTITY_INSERT [dbo].[TodoItems] OFF
ALTER TABLE [dbo].[TodoItems]  WITH CHECK ADD  CONSTRAINT [FK_TodoItems_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[TodoItems] CHECK CONSTRAINT [FK_TodoItems_Categories]
GO
