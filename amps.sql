USE [master]
GO
/****** Object:  Database [amps]    Script Date: 1/5/2015 12:30:38 AM ******/
CREATE DATABASE [amps]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'amps', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\amps.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'amps_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\amps_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [amps] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [amps].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [amps] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [amps] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [amps] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [amps] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [amps] SET ARITHABORT OFF 
GO
ALTER DATABASE [amps] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [amps] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [amps] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [amps] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [amps] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [amps] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [amps] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [amps] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [amps] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [amps] SET  DISABLE_BROKER 
GO
ALTER DATABASE [amps] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [amps] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [amps] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [amps] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [amps] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [amps] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [amps] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [amps] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [amps] SET  MULTI_USER 
GO
ALTER DATABASE [amps] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [amps] SET DB_CHAINING OFF 
GO
ALTER DATABASE [amps] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [amps] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [amps] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'amps', N'ON'
GO
USE [amps]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID] [nvarchar](50) NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeNumber] [int] IDENTITY(10000000,1) NOT NULL,
	[FirstName] [varchar](15) NOT NULL,
	[MidleName] [varchar](15) NULL,
	[LastName] [varchar](15) NULL,
	[Surname] [varchar](15) NOT NULL,
	[Title] [varchar](5) NULL,
	[Initials] [nvarchar](3) NULL,
	[IDNumber] [nvarchar](13) NOT NULL,
	[DOB] [date] NOT NULL,
	[Gender] [varchar](6) NOT NULL,
	[CivilStatus] [varchar](15) NOT NULL,
	[Religion] [varchar](20) NOT NULL,
	[Citizenship] [nvarchar](20) NOT NULL,
	[Duty] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PagIbig]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PagIbig](
	[PagIbigSalaryBracetNo] [nvarchar](50) NOT NULL,
	[MonthlyCompensationFrom] [decimal](18, 2) NOT NULL,
	[MonthlyCompensationTo] [decimal](18, 2) NOT NULL,
	[EmployeeShare] [decimal](18, 2) NOT NULL,
	[EmployerShare] [decimal](18, 2) NOT NULL,
	[TotalMonthlyContribution] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PagIbigSalaryBracetNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhilHealth]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhilHealth](
	[PhilHealthSalaryBracetNo] [nvarchar](50) NOT NULL,
	[SalaryRangeFrom] [decimal](18, 2) NULL,
	[SalaryRangeTo] [decimal](18, 2) NOT NULL,
	[SalaryBase] [decimal](18, 2) NULL,
	[EmployeeShare] [decimal](18, 2) NOT NULL,
	[EmployerShare] [decimal](18, 2) NOT NULL,
	[TotalMonthlyPremium] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK__PhilHealth__5BE2A6F2] PRIMARY KEY CLUSTERED 
(
	[PhilHealthSalaryBracetNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Positions]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[PositionID] [nvarchar](50) NOT NULL,
	[PositionName] [nvarchar](50) NOT NULL,
	[Salary] [int] NOT NULL,
	[DepartmentID] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SSS]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SSS](
	[SSSSalaryBracetNo] [nvarchar](50) NOT NULL,
	[SalaryRangeFrom] [decimal](18, 2) NOT NULL,
	[SalaryRangeTo] [decimal](18, 2) NOT NULL,
	[SalaryBase] [decimal](18, 2) NULL,
	[SocialSecurityEmployerShare] [decimal](18, 2) NOT NULL,
	[SocialSecurityEmployeeShare] [decimal](18, 2) NOT NULL,
	[SocialSecurityTotal] [decimal](18, 2) NOT NULL,
	[EmployerShare] [decimal](18, 2) NOT NULL,
	[TotalContributionEmployeeShare] [decimal](18, 2) NOT NULL,
	[TotalContributionEmployerShare] [decimal](18, 2) NOT NULL,
	[TotalContribution] [decimal](18, 2) NOT NULL,
	[TotalContributionForSEVMOFW] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK__SSS__5DCAEF64] PRIMARY KEY CLUSTERED 
(
	[SSSSalaryBracetNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblUser]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[userID] [int] IDENTITY(1000,1) NOT NULL,
	[EmpNoUsers] [int] NOT NULL,
	[username] [nvarchar](15) NOT NULL,
	[userpwd] [nvarchar](15) NOT NULL,
	[PwdAttempts] [int] NOT NULL,
	[userType] [bit] NOT NULL,
	[lock] [bit] NOT NULL,
	[Blocked] [bit] NOT NULL,
	[SerialNumber] [nvarchar](35) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Positions]  WITH CHECK ADD  CONSTRAINT [FK_Positions_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[Positions] CHECK CONSTRAINT [FK_Positions_Departments]
GO
/****** Object:  StoredProcedure [dbo].[aprocedureSelectUsers]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[aprocedureSelectUsers]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	Select *
	from Users
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[bprocedureCountDepartment]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[bprocedureCountDepartment]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	select Count(DepartmentID) from Departments
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[bprocedureDeleteDepartment]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[bprocedureDeleteDepartment]
	@DepartmentID nvarchar(50) 
AS
	delete from Departments where DepartmentID  = @DepartmentID 
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[bprocedureInsertDepartment]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[bprocedureInsertDepartment]
	@DepartmentID nvarchar(50),
	@DepartmentName nvarchar(50)
AS
	insert into Departments VALUES (@DepartmentID,@DepartmentName)
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[bprocedureLastIDDepartment]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[bprocedureLastIDDepartment]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	SELECT TOP (1) DepartmentID FROM Departments ORDER BY DepartmentID DESC
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[bprocedureSearchDepartment]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[bprocedureSearchDepartment]
	@Input VARCHAR(50)
	AS
	 
	select *
	 from Departments  where  DepartmentID like @Input or 
	 DepartmentName like @Input  
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[bprocedureSelectDepartment]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[bprocedureSelectDepartment]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	Select *
	from Departments 
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[bprocedureUpdateDepartment]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[bprocedureUpdateDepartment]
	@DepartmentID nvarchar(50),
	@DepartmentName nvarchar(50)
AS
	Update Departments Set DepartmentName = @DepartmentName
	Where DepartmentID = @DepartmentID
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[cprocedureCountPosition]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cprocedureCountPosition]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	select Count(PositionID) from Positions
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[cprocedureDeletePosition]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cprocedureDeletePosition]
	@PositionID nvarchar(50) 
  
AS
	delete from Positions where PositionID  = @PositionID 
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[cprocedureInsertPosition]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cprocedureInsertPosition]
	@PositionID nvarchar(50),
	@PositionName nvarchar(50),
	@Salary int,
	@DepartmentID nvarchar(50)
AS
	insert into Positions VALUES (@PositionID,
	@PositionName,
	@Salary,
	@DepartmentID)
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[cprocedureJoinPositionDepartment]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cprocedureJoinPositionDepartment]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	Select Positions.PositionID,
	Positions.PositionName,
	Positions.Salary,
	Departments.DepartmentName
	from Positions inner join Departments on Positions.DepartmentID = Departments.DepartmentID
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[cprocedureLastIDPosition]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cprocedureLastIDPosition]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
SELECT TOP (1) PositionID FROM Positions ORDER BY PositionID DESC
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[cprocedureSearchPosition]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cprocedureSearchPosition]
	@Input VARCHAR(50)
	AS
	 
	Select Positions.PositionID,
	Positions.PositionName,
	Positions.Salary,
	Departments.DepartmentName
	from Positions inner join Departments on Positions.DepartmentID = Departments.DepartmentID  where  Positions.PositionID like @Input
	or Positions.PositionName like @Input 
	or Positions.Salary like @Input 
    or Departments.DepartmentName like @Input 
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[cprocedureUpdatePosition]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cprocedureUpdatePosition]
	@PositionID nvarchar(50),
	@PositionName nvarchar(50),
	@Salary int,
	@DepartmentID nvarchar(50)
AS
	Update Positions Set PositionName = @PositionName,
	Salary = @Salary,
	DepartmentID = @DepartmentID
	Where PositionID = @PositionID
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[dprocedureCountSSS]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[dprocedureCountSSS]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	
	select Count(SSSSalaryBracetNo) from SSS
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[dprocedureDeletetSSS]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[dprocedureDeletetSSS]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	delete from SSS
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[dprocedureInsertSSS]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[dprocedureInsertSSS]
	@SSSSalaryBracetNo nvarchar(50),
	@SalaryRangeFrom float,
	@SalaryRangeTo float,
	@SalaryBase float,
	@SocialSecurityEmployeeShare float,
	@SocialSecurityEmployerShare float,
	@SocialSecurityTotal float,
	@EmployerShare float,
	@TotalContributionEmployeeShare float,
	@TotalContributionEmployerShare float,
	@TotalContribution float,
	@TotalContributionForSEVMOFW float
AS
	insert into SSS VALUES (@SSSSalaryBracetNo,
	@SalaryRangeFrom,
	@SalaryRangeTo,
	@SalaryBase,
	@SocialSecurityEmployeeShare,
	@SocialSecurityEmployerShare,
	@SocialSecurityTotal,
	@EmployerShare,
	@TotalContributionEmployeeShare,
	@TotalContributionEmployerShare,
	@TotalContribution,
	@TotalContributionForSEVMOFW)
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[dprocedureLastIDSSS]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[dprocedureLastIDSSS]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	SELECT TOP (1) SSSSalaryBracetNo FROM SSS ORDER BY SSSSalaryBracetNo DESC
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[dprocedureSearchSSS]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[dprocedureSearchSSS]
	@Input VARCHAR(50)
	AS
	 
	select * from SSS where SalaryRangeFrom like @Input 
	or SalaryBase like @Input 
	or SocialSecurityEmployeeShare like @Input 
 	or SocialSecurityEmployerShare like @Input 
	or SocialSecurityTotal like @Input 
	  
	or EmployerShare like @Input 
	or TotalContributionEmployeeShare like @Input 
 	or TotalContributionEmployerShare like @Input 
	or TotalContribution like @Input 
	or TotalContributionForSEVMOFW like @Input
	or SSSSalaryBracetNo like @Input
	order by SSSSalaryBracetNo
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[dprocedureSelectSSS]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[dprocedureSelectSSS]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	select * from SSS  ORDER BY SSSSalaryBracetNo
	return
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[EditManage]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EditManage]
@username nvarchar(50),
@password nvarchar(50)
as 
update TblUser set UserName=@username,[Password]=@password
GO
/****** Object:  StoredProcedure [dbo].[eprocedureCountPhilHealth]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eprocedureCountPhilHealth]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	select Count(PhilHealthSalaryBracetNo) from PhilHealth
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[eprocedureDeletetPhilHealth]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eprocedureDeletetPhilHealth]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	delete from PhilHealth
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[eprocedureInsertPhilHealth]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eprocedureInsertPhilHealth]

	@PhilHealthSalaryBracetNo nvarchar(50),
	@SalaryRangeFrom  decimal,
	@SalaryRangeTo  decimal,
	@SalaryBase decimal,
	@EmployeeShare decimal,
	@EmployerShare decimal,
	@TotalMonthlyPremium decimal
AS
	insert into PhilHealth VALUES (@PhilHealthSalaryBracetNo,
	@SalaryRangeFrom,
	@SalaryRangeTo,
	@SalaryBase,
	@EmployeeShare,
	@EmployerShare,
	@TotalMonthlyPremium)
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[eprocedureLastIDPhilHealth]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eprocedureLastIDPhilHealth]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	SELECT TOP (1) PhilHealthSalaryBracetNo FROM PhilHealth ORDER BY PhilHealthSalaryBracetNo DESC
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[eprocedureSearchPhilHealth]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eprocedureSearchPhilHealth]
	@Input VARCHAR(50)
	AS
	 
	Select *
	from PhilHealth where SalaryRangeFrom like @Input 
	or SalaryBase like @Input 
	or EmployeeShare like @Input 
 	or EmployerShare like @Input 
	or PhilHealthSalaryBracetNo like @Input 
	or TotalMonthlyPremium like @Input
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[eprocedureSelectPhilHealth]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eprocedureSelectPhilHealth]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	Select *
	from PhilHealth
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[fprocedureCountPagIbig]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fprocedureCountPagIbig]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	select Count(PagIbigSalaryBracetNo) from PagIbig
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[fprocedureDeletetPagIbig]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fprocedureDeletetPagIbig]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	delete from PagIbig
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[fprocedureInsertPagIbig]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fprocedureInsertPagIbig]
	@PagIbigSalaryBracetNo nvarchar(50),
	@MonthlyCompensationFrom decimal(18,2),
	@MonthlyCompensationTo decimal(18,2),
 	@EmployeeShare decimal(18,2),
	@EmployerShare decimal(18,2),
	@TotalMonthlyContribution decimal(18,2)
AS
	insert into PagIbig VALUES (@PagIbigSalaryBracetNo,
	@MonthlyCompensationFrom,
	@MonthlyCompensationTo,
 	@EmployeeShare,
	@EmployerShare,
	@TotalMonthlyContribution)
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[fprocedureLastIDPagIbig]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fprocedureLastIDPagIbig]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	SELECT TOP (1) PagIbigSalaryBracetNo FROM PagIbig ORDER BY PagIbigSalaryBracetNo DESC
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[fprocedureSearchPagIbig]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fprocedureSearchPagIbig]
	@Input VARCHAR(50)
	AS
	 
	Select *
	from PagIbig where MonthlyCompensationFrom like @Input 
	or MonthlyCompensationTo like @Input 
	or EmployeeShare like @Input 
 	or EmployerShare like @Input 
	or TotalMonthlyContribution like @Input 
	or PagIbigSalaryBracetNo like @Input
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[fprocedureSelectPagIbig]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fprocedureSelectPagIbig]
	/*
	(
	@parameter1 int = 5,
	@parameter2 datatype OUTPUT
	)
	*/
AS
	Select *
	from PagIbig 
	RETURN

GO
/****** Object:  StoredProcedure [dbo].[InsertManage]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertManage]
@username nvarchar(50),
@password nvarchar(50)
as 
insert into TblUser (UserName,[Password]) values (@username ,@password)
GO
/****** Object:  StoredProcedure [dbo].[LoginToApp]    Script Date: 1/5/2015 12:30:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LoginToApp]
@username nvarchar(50),
@password nvarchar(50)
as
select COUNT(*) from [dbo].[TblUser] where UserName=@username and Password=@password

GO
USE [master]
GO
ALTER DATABASE [amps] SET  READ_WRITE 
GO
