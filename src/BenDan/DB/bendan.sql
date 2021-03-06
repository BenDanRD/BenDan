USE [bendan]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2018/7/30 15:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] NOT NULL,
	[UserName] [nvarchar](20) NULL,
	[NickName] [nvarchar](20) NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](20) NULL,
	[Gender] [int] NULL,
	[Birthday] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[IntroDuction] [nvarchar](500) NULL,
	[IsDelete] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Gender]  DEFAULT ((0)) FOR [Gender]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别（0保密，1女，2男 ）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' 是否删除（0正常，1删除）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
