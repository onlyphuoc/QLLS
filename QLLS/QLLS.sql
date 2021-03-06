USE [QLLS]
GO
/****** Object:  StoredProcedure [dbo].[SP_Login]    Script Date: 12/26/2018 03:37:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_Login]
@userName nvarchar(100),
@pass nvarchar (100)
as 
begin
select * from dbo.Account where UserName = @userName and Pass = @pass
end

GO
/****** Object:  Table [dbo].[Account]    Script Date: 12/26/2018 03:37:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](100) NOT NULL,
	[Pass] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[TypeAcc] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ('1') FOR [Pass]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ('name') FOR [DisplayName]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [TypeAcc]
GO
