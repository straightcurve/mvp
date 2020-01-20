USE [master]
GO

/****** Object:  Database [JiraClone]    Script Date: 1/20/2020 8:50:08 AM ******/
CREATE DATABASE [JiraClone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JiraClone', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\JiraClone.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JiraClone_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\JiraClone_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JiraClone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [JiraClone] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [JiraClone] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [JiraClone] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [JiraClone] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [JiraClone] SET ARITHABORT OFF 
GO

ALTER DATABASE [JiraClone] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [JiraClone] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [JiraClone] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [JiraClone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [JiraClone] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [JiraClone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [JiraClone] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [JiraClone] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [JiraClone] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [JiraClone] SET  DISABLE_BROKER 
GO

ALTER DATABASE [JiraClone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [JiraClone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [JiraClone] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [JiraClone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [JiraClone] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [JiraClone] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [JiraClone] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [JiraClone] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [JiraClone] SET  MULTI_USER 
GO

ALTER DATABASE [JiraClone] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [JiraClone] SET DB_CHAINING OFF 
GO

ALTER DATABASE [JiraClone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [JiraClone] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [JiraClone] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [JiraClone] SET QUERY_STORE = OFF
GO

ALTER DATABASE [JiraClone] SET  READ_WRITE 
GO


USE [JiraClone]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 1/20/2020 8:51:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users_test] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [JiraClone]
GO

/****** Object:  Table [dbo].[Projects]    Script Date: 1/20/2020 8:53:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Projects](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Key] [varchar](50) NOT NULL,
	[Lead] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Users_Projects] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO

ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Users_Projects]
GO


USE [JiraClone]
GO

/****** Object:  Table [dbo].[Columns]    Script Date: 1/20/2020 8:50:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Columns](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Columns] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Columns]  WITH CHECK ADD  CONSTRAINT [FK_Columns_Projects] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ID])
GO

ALTER TABLE [dbo].[Columns] CHECK CONSTRAINT [FK_Columns_Projects]
GO

USE [JiraClone]
GO

/****** Object:  Table [dbo].[Issues]    Script Date: 1/20/2020 8:54:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Issues](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ColumnID] [int] NOT NULL,
	[Summary] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Issues] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Issues]  WITH CHECK ADD  CONSTRAINT [FK_Issues_Columns] FOREIGN KEY([ColumnID])
REFERENCES [dbo].[Columns] ([ID])
GO

ALTER TABLE [dbo].[Issues] CHECK CONSTRAINT [FK_Issues_Columns]
GO



USE [JiraClone]
GO

/****** Object:  StoredProcedure [dbo].[Columns_Insert]    Script Date: 1/20/2020 8:54:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Columns_Insert]
	@Name nvarchar(50),
	@ProjectID int
AS
BEGIN
	INSERT INTO [dbo].[Columns]
           ([Name]
		   ,[ProjectID])
     VALUES
           (@Name
           ,@ProjectID)
END
GO


USE [JiraClone]
GO

/****** Object:  StoredProcedure [dbo].[Columns_Update]    Script Date: 1/20/2020 8:55:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Columns_Update]
	@ID int,
	@Name nvarchar(50),
	@ProjectID int
AS
BEGIN
	UPDATE Columns 
	SET
		[Name]= @Name,
		[ProjectID] = @ProjectID
	WHERE
		[ID] = @ID
END
GO


USE [JiraClone]
GO

/****** Object:  StoredProcedure [dbo].[Issues_Insert]    Script Date: 1/20/2020 8:55:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Issues_Insert]
	@Summary nvarchar(50),
	@ColumnID int
AS
BEGIN
	INSERT INTO [dbo].[Issues]
           ([Summary]
		   ,[ColumnID])
     VALUES
           (@Summary
           ,@ColumnID)
END
GO


USE [JiraClone]
GO

/****** Object:  StoredProcedure [dbo].[Issues_Update]    Script Date: 1/20/2020 8:55:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Issues_Update]
	@ID int,
	@Summary nvarchar(50),
	@ColumnID int
AS
BEGIN
	UPDATE Issues
	SET
		[Summary]= @Summary,
		[ColumnID] = @ColumnID
	WHERE
		[ID] = @ID
END
GO


USE [JiraClone]
GO

/****** Object:  StoredProcedure [dbo].[Projects_Insert]    Script Date: 1/20/2020 8:55:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Projects_Insert]
	@Name nvarchar(50),
	@Key nvarchar(50),
	@Lead nvarchar(50),
	@UserID int
AS
BEGIN
	INSERT INTO [dbo].[Projects]
           ([Name]
           ,[Key]
		   ,[Lead]
		   ,[UserID])
     VALUES
           (@Name
           ,@Key
           ,@Lead
           ,@UserID)
END
GO


USE [JiraClone]
GO

/****** Object:  StoredProcedure [dbo].[Projects_Update]    Script Date: 1/20/2020 8:56:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Projects_Update]
	@ID int,
	@Name nvarchar(50),
	@Key nvarchar(50),
	@Lead nvarchar(50),
	@UserID int
AS
BEGIN
	UPDATE Projects 
	SET
		[Name]= @Name,
        [Key] = @Key,
		[Lead] = @Lead,
		[UserID] = @UserID
	WHERE
		[ID] = @ID
END
GO


USE [JiraClone]
GO

/****** Object:  StoredProcedure [dbo].[Users_Insert]    Script Date: 1/20/2020 8:56:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Users_Insert]
	@Username nvarchar(50),
	@Password nvarchar(50)
AS
BEGIN
	INSERT INTO [dbo].[Users]
           ([Username]
           ,[Password])
     VALUES
           (@Username
           ,@Password)
END
GO


USE [JiraClone]
GO

/****** Object:  StoredProcedure [dbo].[Users_Update]    Script Date: 1/20/2020 8:57:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Users_Update]
	@ID int,
	@Username nvarchar(50),
	@Password nvarchar(50)
AS
BEGIN
	UPDATE Users 
	SET
		[Username] = @Username,
		[Password] = @Password
	WHERE
		[ID] = @ID
END
GO


