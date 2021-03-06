USE [master]
GO
/****** Object:  Database [Renocan_Db]    Script Date: 2/18/2018 9:57:31 PM ******/
CREATE DATABASE [Renocan_Db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Renocan_Db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Renocan_Db.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Renocan_Db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Renocan_Db_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Renocan_Db] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Renocan_Db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Renocan_Db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Renocan_Db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Renocan_Db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Renocan_Db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Renocan_Db] SET ARITHABORT OFF 
GO
ALTER DATABASE [Renocan_Db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Renocan_Db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Renocan_Db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Renocan_Db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Renocan_Db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Renocan_Db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Renocan_Db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Renocan_Db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Renocan_Db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Renocan_Db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Renocan_Db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Renocan_Db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Renocan_Db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Renocan_Db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Renocan_Db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Renocan_Db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Renocan_Db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Renocan_Db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Renocan_Db] SET  MULTI_USER 
GO
ALTER DATABASE [Renocan_Db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Renocan_Db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Renocan_Db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Renocan_Db] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Renocan_Db] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Renocan_Db]
GO
/****** Object:  User [aman]    Script Date: 2/18/2018 9:57:31 PM ******/
CREATE USER [aman] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Activity](
	[Activity_ID] [int] IDENTITY(1,1) NOT NULL,
	[Activity_Date] [date] NULL,
	[Reviews_Commented] [nvarchar](max) NULL,
	[Ratings] [int] NULL,
	[Company_ID] [int] NULL,
	[Targeted_Company] [int] NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[Activity_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Admin_Signup]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin_Signup](
	[Admin_ID] [int] IDENTITY(1,1) NOT NULL,
	[Admin_Name] [nvarchar](50) NULL,
	[Admin_Designation] [nvarchar](50) NULL,
	[Admin_Employee_ID] [int] NULL,
	[Admin_Contact_Number] [nvarchar](15) NULL,
	[Admin_Address] [nvarchar](50) NULL,
	[User_CategoryId] [int] NULL,
	[Admin_Password] [nvarchar](50) NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Admin_Signup] PRIMARY KEY CLUSTERED 
(
	[Admin_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bookmarks]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bookmarks](
	[Bookmark_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NULL,
	[User_TypeId] [int] NULL,
	[Company_ID] [int] NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Bookmarks] PRIMARY KEY CLUSTERED 
(
	[Bookmark_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Client_Signup]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Client_Signup](
	[Client_ID] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [nvarchar](50) NULL,
	[Last_Name] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Create_Password] [nvarchar](50) NULL,
	[Phone] [nvarchar](15) NULL,
	[IsNewsletter] [nvarchar](50) NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Client_Signup] PRIMARY KEY CLUSTERED 
(
	[Client_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Company_Service_Location]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company_Service_Location](
	[Company_Service_Location_Id] [int] IDENTITY(1,1) NOT NULL,
	[Company_ID] [int] NULL,
	[Location_ID] [int] NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Company_Service_Location] PRIMARY KEY CLUSTERED 
(
	[Company_Service_Location_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Image_Gallary]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Image_Gallary](
	[Image_ID] [int] IDENTITY(1,1) NOT NULL,
	[Image_Name] [nvarchar](50) NULL,
	[Image_Path] [nvarchar](50) NULL,
	[User_ID] [int] NULL,
	[Image_Type_ID] [int] NULL,
	[User_Typeid] [int] NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Image_Gallary] PRIMARY KEY CLUSTERED 
(
	[Image_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Image_Type]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Image_Type](
	[Image_Type_ID] [int] IDENTITY(1,1) NOT NULL,
	[Image_Type_Name] [nvarchar](50) NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Image_Type] PRIMARY KEY CLUSTERED 
(
	[Image_Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Location]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location](
	[Location_ID] [int] IDENTITY(1,1) NOT NULL,
	[Location_Name] [nvarchar](50) NULL,
	[Postal_Code] [nvarchar](50) NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Location_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Registration_Company]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Registration_Company](
	[Company_ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[Email] [nvarchar](50) NULL,
	[Create_Password] [nvarchar](50) NULL,
	[Owner_First_Name] [nvarchar](50) NULL,
	[Owner_Last_Name] [nvarchar](50) NULL,
	[IsAggrement] [bit] NULL,
	[Is_Paid] [bit] NULL,
	[Website_Add] [nvarchar](50) NULL,
	[Bussiness_Description] [nvarchar](max) NULL,
	[Profile_Information] [nvarchar](max) NULL,
	[Products] [nvarchar](max) NULL,
	[Services] [nvarchar](max) NULL,
	[Brands] [nvarchar](max) NULL,
	[Specialities] [nvarchar](max) NULL,
	[Year_Established] [nvarchar](50) NULL,
	[Return_Policy_URL] [nvarchar](50) NULL,
	[Payment_Method_URL] [nvarchar](50) NULL,
	[Licences_URL] [nvarchar](max) NULL,
	[Insurance_URL] [nvarchar](50) NULL,
	[Certificates_URL] [nvarchar](50) NULL,
	[Pricing] [nvarchar](50) NULL,
	[Contract_Based] [nvarchar](50) NULL,
	[Warranty] [nvarchar](50) NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Registration_Company] PRIMARY KEY CLUSTERED 
(
	[Company_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Request_Review_History]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Request_Review_History](
	[Request_Review_History_ID] [int] IDENTITY(1,1) NOT NULL,
	[Review_ID] [int] NULL,
	[Job_Description] [nvarchar](50) NULL,
	[Client_Phone] [nvarchar](15) NULL,
	[Email] [nvarchar](50) NULL,
	[IsEmailSent] [bit] NULL,
	[IsSmsSent] [bit] NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Request_Review_History] PRIMARY KEY CLUSTERED 
(
	[Request_Review_History_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reviews](
	[Review_ID] [int] IDENTITY(1,1) NOT NULL,
	[Service_Request_ID] [int] NULL,
	[ReviewedBy] [nvarchar](50) NULL,
	[ReviewedDate] [date] NULL,
	[Service_Review_Status_ID] [int] NULL,
	[Review_Title] [nvarchar](50) NULL,
	[Approximate_Cost] [nvarchar](50) NULL,
	[Review_Details] [nvarchar](max) NULL,
	[Review_Rating] [int] NULL,
	[Review_Time] [time](7) NULL,
	[IsAnonymous] [bit] NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Review_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Scoreboard]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Scoreboard](
	[Scoreboard_ID] [int] IDENTITY(1,1) NOT NULL,
	[Visitor_ID] [int] NULL,
	[Visitor_Name] [nvarchar](50) NULL,
	[Visitor_Ip] [varbinary](16) NULL,
	[Leads] [nvarchar](50) NULL,
	[Company_ID] [int] NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Scoreboard] PRIMARY KEY CLUSTERED 
(
	[Scoreboard_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Service_Category]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Service_Category](
	[Category_ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL CONSTRAINT [DF_Service_Category_Creation_Date]  DEFAULT (getdate()),
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL CONSTRAINT [DF_Service_Category_Is_Active]  DEFAULT ((1)),
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Service_Category] PRIMARY KEY CLUSTERED 
(
	[Category_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Service_Request]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Service_Request](
	[Service_Request_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NULL,
	[User_TypeId] [int] NULL,
	[Company_Category_ID] [int] NULL,
	[Service_Request_Status_ID] [int] NOT NULL,
	[Request_Date] [datetime] NULL,
	[Request_Reply] [nvarchar](50) NULL,
	[Problem_description] [nvarchar](50) NULL,
	[Kind_of_Location] [nvarchar](50) NULL,
	[Postal_Code] [nvarchar](50) NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Service_Request] PRIMARY KEY CLUSTERED 
(
	[Service_Request_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Service_Request_Status]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Service_Request_Status](
	[Service_Request_Status_ID] [int] IDENTITY(1,1) NOT NULL,
	[Service_Request_Status_Name] [nvarchar](50) NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Service_Request_Status] PRIMARY KEY CLUSTERED 
(
	[Service_Request_Status_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Service_Review_Status]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Service_Review_Status](
	[Service_Review_Status_ID] [int] IDENTITY(1,1) NOT NULL,
	[Service_Review_Status] [nvarchar](50) NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_Service_Review_Status] PRIMARY KEY CLUSTERED 
(
	[Service_Review_Status_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_Type]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User_Type](
	[User_TypeId] [int] IDENTITY(1,1) NOT NULL,
	[User_TypeName] [nvarchar](50) NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_User_Type] PRIMARY KEY CLUSTERED 
(
	[User_TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VIisitor_Log]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VIisitor_Log](
	[User_Log_ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Time_In] [time](7) NULL,
	[Time_Out] [time](7) NULL,
	[Company_ID] [int] NULL,
	[Creation_By] [nvarchar](50) NULL,
	[Creation_Date] [datetime] NULL,
	[Updated_By] [nvarchar](50) NULL,
	[Updated_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_VIisitor_Log] PRIMARY KEY CLUSTERED 
(
	[User_Log_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Activity] ADD  CONSTRAINT [DF_Activity_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Activity] ADD  CONSTRAINT [DF_Activity_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Admin_Signup] ADD  CONSTRAINT [DF_Admin_Signup_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Admin_Signup] ADD  CONSTRAINT [DF_Admin_Signup_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Bookmarks] ADD  CONSTRAINT [DF_Bookmarks_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Bookmarks] ADD  CONSTRAINT [DF_Bookmarks_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Client_Signup] ADD  CONSTRAINT [DF_Client_Signup_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Client_Signup] ADD  CONSTRAINT [DF_Client_Signup_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Company_Service_Location] ADD  CONSTRAINT [DF_Company_Service_Location_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Company_Service_Location] ADD  CONSTRAINT [DF_Company_Service_Location_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Image_Gallary] ADD  CONSTRAINT [DF_Image_Gallary_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Image_Gallary] ADD  CONSTRAINT [DF_Image_Gallary_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Image_Type] ADD  CONSTRAINT [DF_Image_Type_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Image_Type] ADD  CONSTRAINT [DF_Image_Type_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Registration_Company] ADD  CONSTRAINT [DF_Registration_Company_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Registration_Company] ADD  CONSTRAINT [DF_Registration_Company_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Request_Review_History] ADD  CONSTRAINT [DF_Request_Review_History_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Request_Review_History] ADD  CONSTRAINT [DF_Request_Review_History_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Reviews] ADD  CONSTRAINT [DF_Reviews_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Scoreboard] ADD  CONSTRAINT [DF_Scoreboard_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Scoreboard] ADD  CONSTRAINT [DF_Scoreboard_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Service_Request] ADD  CONSTRAINT [DF_Service_Request_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Service_Request] ADD  CONSTRAINT [DF_Service_Request_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Service_Request_Status] ADD  CONSTRAINT [DF_Service_Request_Status_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Service_Request_Status] ADD  CONSTRAINT [DF_Service_Request_Status_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[Service_Review_Status] ADD  CONSTRAINT [DF_Service_Review_Status_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[Service_Review_Status] ADD  CONSTRAINT [DF_Service_Review_Status_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[User_Type] ADD  CONSTRAINT [DF_User_Type_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[User_Type] ADD  CONSTRAINT [DF_User_Type_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
ALTER TABLE [dbo].[VIisitor_Log] ADD  CONSTRAINT [DF_VIisitor_Log_Creation_Date]  DEFAULT (getdate()) FOR [Creation_Date]
GO
ALTER TABLE [dbo].[VIisitor_Log] ADD  CONSTRAINT [DF_VIisitor_Log_Is_Active]  DEFAULT ((1)) FOR [Is_Active]
GO
/****** Object:  StoredProcedure [dbo].[Insert_Update_Client_Registration]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Insert_Update_Client_Registration]
@Client_ID int = null
,@First_Name Nvarchar (50)
,@Last_Name Nvarchar (50)
,@City Nvarchar (50)
,@State Nvarchar (50)
,@Email Nvarchar (50)
,@Create_Password Nvarchar (50)
,@Phone Nvarchar (20)
,@IsNewsletter Nvarchar (50)
,@UserIP Nvarchar (20)
,@Created_By Nvarchar(50) 
AS
BEGIN

if( @Client_ID is null)
begin
	If not exists( select top 1 1 from Client_Signup(nolock) where  Email=@Email and Is_Active = 1 )
	begin
		Insert into Client_Signup (First_Name,Last_Name,City,State,Email,Create_Password,Phone,IsNewsletter,Ip)
		values (
		@First_Name,
		@Last_Name,
		@City,
		@State,
		@Email,
		@Create_Password,  
		@Phone,
		@IsNewsletter,
		@UserIP )
		Select 'Update Sucessfully' as Status

	end
	else
    Select 'already exist' as Status

end

else
begin

If not exists( select top 1 1 from Client_Signup(nolock) where  Email=@Email and Is_Active = 1 and Client_ID != @Client_ID)
	begin

	UPdate Client_Signup set 
	

First_Name=@First_Name
,Last_Name=@Last_Name
,City=@City
,State =@State
,Email =@Email
,Create_Password =@Create_Password
,Phone =@Phone
,IsNewsletter =@IsNewsletter
,Updated_By =@Created_By
,Updated_Date=Updated_Date
,Ip= @UserIP
where Client_ID = @Client_ID 
	Select 'Update Sucessfully' as Status
	 end

	 else
	 Select 'already exist' as Status

end

END
GO
/****** Object:  StoredProcedure [dbo].[Select_BusinessCategory]    Script Date: 2/18/2018 9:57:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Select_BusinessCategory]
AS
BEGIN
	
SET NOCOUNT ON

Select Category_ID,
CategoryName
 from Service_Category (nolock)
where Is_Active= 1

SET NOCOUNT OFF
END

GO
USE [master]
GO
ALTER DATABASE [Renocan_Db] SET  READ_WRITE 
GO
