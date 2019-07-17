CREATE DATABASE [Person]
GO
USE [Person]
GO
/****** Object:  Table [dbo].[Register]    Script Date: 2019/04/30 1:33:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Register](
	[RegNo] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[ConfirmPassword] [varchar](100) NOT NULL,
	[Countries] [varchar](100) NULL,
	[Fav_Color] [varchar](50) NULL,
	[Birthday] [date] NULL,
	[PhoneNo] [varchar](12) NULL,
	[Comments] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[RegNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_getRegister]    Script Date: 2019/04/30 1:33:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_getRegister]
As
Begin
	Select r.Name,
		   r.Surname,
		   r.Email,
		   r.Password,
		   r.ConfirmPassword,
		   r.Fav_Color,
		   r.Birthday,
		   r.PhoneNo,
		   r.Comments
	From Register r
End
GO
/****** Object:  StoredProcedure [dbo].[sp_Register]    Script Date: 2019/04/30 1:33:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_Register]
@Name varchar(50),
	@Surname varchar(50),
	@Email varchar(100),
	@Password varchar(100),
	@ConfirmPassword varchar(100),
	@Countries varchar(100),
	@Fav_Color varchar(50),
	@Birthday date,
	@PhoneNo varchar(12),
	@Comments varchar(500)
As 
Begin
Insert into Register
Select @Name,
	   @Surname,
	   @Email,
	   @Password,
	   @ConfirmPassword,
	   @Countries,
	   @Fav_Color,
	   @Birthday,
	   @PhoneNo,
	   @Comments
End
GO
