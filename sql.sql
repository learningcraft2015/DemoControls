USE [master]
GO
/****** Object:  Database [STUDENT]    Script Date: 8/11/2015 1:44:42 PM ******/
CREATE DATABASE [STUDENT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'STUDENT', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\STUDENT.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'STUDENT_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\STUDENT_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [STUDENT] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [STUDENT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [STUDENT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [STUDENT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [STUDENT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [STUDENT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [STUDENT] SET ARITHABORT OFF 
GO
ALTER DATABASE [STUDENT] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [STUDENT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [STUDENT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [STUDENT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [STUDENT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [STUDENT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [STUDENT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [STUDENT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [STUDENT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [STUDENT] SET  DISABLE_BROKER 
GO
ALTER DATABASE [STUDENT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [STUDENT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [STUDENT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [STUDENT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [STUDENT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [STUDENT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [STUDENT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [STUDENT] SET RECOVERY FULL 
GO
ALTER DATABASE [STUDENT] SET  MULTI_USER 
GO
ALTER DATABASE [STUDENT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [STUDENT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [STUDENT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [STUDENT] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [STUDENT] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'STUDENT', N'ON'
GO
USE [STUDENT]
GO
/****** Object:  Table [dbo].[FileUp]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FileUp](
	[FileId] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](50) NULL,
 CONSTRAINT [PK_FileUp] PRIMARY KEY CLUSTERED 
(
	[FileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Countries]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
	[CountryStatus] [int] NOT NULL CONSTRAINT [DF_tbl_Countries_CountryStatus]  DEFAULT ((1)),
 CONSTRAINT [PK_tbl_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Registration]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Registration](
	[RegistrationId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL CONSTRAINT [DF_tbl_Registration_UserId]  DEFAULT ((1)),
	[UserTypeId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[Address] [nvarchar](max) NULL,
	[Gender] [int] NULL,
	[CountryId] [int] NULL,
	[State] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[MobileNumber] [nvarchar](50) NOT NULL,
	[UserEmail] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Status] [int] NULL,
	[DepartmentId] [int] NULL,
	[SemesterId] [int] NULL,
	[StartAcademicYear] [int] NULL,
	[EndAcademicYear] [int] NULL,
 CONSTRAINT [PK_tbl_Registration] PRIMARY KEY CLUSTERED 
(
	[RegistrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_State]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_State](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[CountryId] [int] NULL,
 CONSTRAINT [PK_tbl_State] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Student]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[DOB] [datetime] NULL,
	[Gender] [int] NULL,
 CONSTRAINT [PK_tbl_FAQ] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Users]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[UserTypeID] [int] NOT NULL,
	[UserEmail] [nvarchar](50) NOT NULL,
	[UserCreatedDate] [datetime] NOT NULL CONSTRAINT [DF_tbl_Users_UserCreatedDate]  DEFAULT (getdate()),
	[UserStatus] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_UserTypes]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserTypes](
	[UserTypeID] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_UserTypes] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblGallery]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblGallery](
	[GalleryId] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](50) NULL,
	[Title] [varchar](50) NULL,
 CONSTRAINT [PK_tblGallery] PRIMARY KEY CLUSTERED 
(
	[GalleryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[FileUp] ON 

INSERT [dbo].[FileUp] ([FileId], [FileName]) VALUES (1, N'1ed4be8c-b858-4148-9ed5-b2c48b4d6e25.txt')
SET IDENTITY_INSERT [dbo].[FileUp] OFF
SET IDENTITY_INSERT [dbo].[tbl_Countries] ON 

INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (2, N'Albania', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (3, N'Algeria', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (4, N'American Samoa', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (5, N'Angola', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (7, N'Antartica', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (8, N'Antigua and Barbuda', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (9, N'Argentina', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (10, N'Armenia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (11, N'Aruba', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (13, N'Australia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (14, N'Austria', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (15, N'Azerbaijan', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (16, N'Bahamas', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (17, N'Bahrain', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (18, N'Bangladesh', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (19, N'Barbados', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (20, N'Belarus', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (21, N'Belgium', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (22, N'Belize', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (24, N'Bermuda', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (25, N'Bhutan', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (26, N'Bolivia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (27, N'Bosnia and Herzegovina', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (28, N'Botswana', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (29, N'Brazil', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (30, N'British Virgin Islands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (31, N'Brunei', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (32, N'Bulgaria', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (33, N'Burkina Faso', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (34, N'Burma', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (35, N'Burundi', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (36, N'Cambodia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (37, N'Cameroon', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (38, N'Canada', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (39, N'Cape Verde', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (40, N'Cayman Islands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (41, N'Central African Republic', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (42, N'Chad', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (43, N'Chile', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (44, N'China', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (45, N'Christmas Island', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (46, N'Clipperton Island', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (47, N'Cocos (Keeling) Islands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (48, N'Colombia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (49, N'Comoros', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (50, N'Congo, Democratic Republic of the', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (51, N'Congo, Republic of the', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (52, N'Cook Islands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (53, N'Costa Rica', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (54, N'Cote d''Ivoire', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (55, N'Croatia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (56, N'Cuba', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (57, N'Cyprus', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (58, N'Czeck Republic', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (59, N'Denmark', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (60, N'Djibouti', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (61, N'Dominica', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (62, N'Dominican Republic', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (63, N'Ecuador', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (64, N'Egypt', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (65, N'El Salvador', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (66, N'Equatorial Guinea', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (67, N'Eritrea', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (68, N'Estonia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (69, N'Ethiopia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (70, N'Europa Island', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (71, N'Falkland Islands (Islas Malvinas)', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (72, N'Faroe Islands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (73, N'Fiji', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (74, N'Finland', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (75, N'France', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (76, N'French Guiana', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (77, N'French Polynesia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (78, N'French Southern and Antarctic Lands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (80, N'Gambia, The', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (81, N'Gaza Strip', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (82, N'Georgia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (83, N'Germany', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (84, N'Ghana', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (85, N'Gibraltar', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (86, N'Glorioso  Islands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (87, N'Greece', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (88, N'Greenland', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (89, N'Grenada', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (90, N'Guadeloupe', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (91, N'Guam', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (92, N'Guatemala', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (93, N'Guernsey', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (94, N'Guinea', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (95, N'Guinea-Bissau', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (96, N'Guyana', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (97, N'Haiti', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (98, N'Heard Island and McDonald Islands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (99, N'Holy See (Vatican City)', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (100, N'Honduras', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (101, N'Hong  Kong', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (102, N'Howland Island', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (103, N'Hungary', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (104, N'Iceland', 1)
GO
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (105, N'India', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (106, N'Indonesia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (107, N'Iran', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (108, N'Iraq', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (109, N'Ireland', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (110, N'Ireland, Northern', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (111, N'Israel', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (112, N'Italy', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (113, N'Jamaica', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (114, N'Jan Mayen', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (115, N'Japan', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (116, N'Jarvis Island', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (117, N'Jersey', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (118, N'Johnston Atoll', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (119, N'Jordan', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (120, N'Juan de Nova Island', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (121, N'Kazakhstan', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (122, N'Kenya', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (123, N'Kiribati', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (124, N'Korea, North', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (125, N'Korea, South', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (126, N'Kuwait', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (127, N'Kyrgyzstan', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (128, N'Laos', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (129, N'Latvia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (130, N'Lebanon', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (131, N'Lesotho', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (132, N'Liberia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (133, N'Libya', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (134, N'Liechtenstein', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (135, N'Lithuania', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (136, N'Luxembourg', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (137, N'Macau', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (138, N'Macedonia, The Former Yugoslav Republic of', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (139, N'Madagascar', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (140, N'Malawi', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (141, N'Malaysia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (142, N'Maldives', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (143, N'Mali', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (144, N'Malta', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (145, N'Man, Isle of', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (146, N'Marshall Islands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (147, N'Martinique', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (148, N'Mauritania', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (149, N'Mauritius', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (150, N'Mayotte', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (151, N'Mexico', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (152, N'Micronesia, Federated States of', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (153, N'Midway Islands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (154, N'Moldova', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (155, N'Monaco', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (156, N'Mongolia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (157, N'Montserrat', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (158, N'Morocco', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (159, N'Mozambique', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (160, N'Namibia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (161, N'Nauru', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (162, N'Nepal', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (163, N'Netherlands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (164, N'Netherlands Antilles', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (165, N'New Caledonia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (166, N'New Zealand', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (167, N'Nicaragua', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (168, N'Niger', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (169, N'Nigeria', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (170, N'Niue', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (171, N'Norfolk Island', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (172, N'Northern Mariana Islands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (173, N'Norway', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (174, N'Oman', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (175, N'Pakistan', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (176, N'Palau', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (177, N'Panama', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (178, N'Papua New Guinea', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (179, N'Paraguay', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (180, N'Peru', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (181, N'Philippines', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (182, N'Pitcaim Islands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (183, N'Poland', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (184, N'Portugal', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (185, N'Puerto Rico', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (186, N'Qatar', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (187, N'Reunion', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (188, N'Romainia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (189, N'Russia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (190, N'Rwanda', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (191, N'Saint Helena', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (192, N'Saint Kitts and Nevis', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (193, N'Saint Lucia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (194, N'Saint Pierre and Miquelon', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (195, N'Saint Vincent and the  Grenadines', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (196, N'Samoa', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (197, N'San Marino', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (198, N'Sao Tome and Principe', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (199, N'Saudi Arabia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (200, N'Scotland', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (201, N'Senegal', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (202, N'Seychelles', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (203, N'Sierra Leone', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (204, N'Singapore', 1)
GO
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (205, N'Slovakia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (206, N'Slovenia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (207, N'Solomon Islands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (208, N'Somalia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (209, N'South Africa', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (210, N'South Georgia and the South Sandwich Islandss', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (211, N'Spain', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (212, N'Spratly Islands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (213, N'Sri Lanka', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (214, N'Sudan', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (215, N'Suriname', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (216, N'Svalbard', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (217, N'Swaziland', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (218, N'Sweden', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (219, N'Switzerland', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (220, N'Syria', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (221, N'Taiwan', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (222, N'Tajikistan', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (223, N'Tanzania', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (224, N'Thailand', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (225, N'Tobago', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (226, N'Toga', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (227, N'Tokelau', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (228, N'Tonga', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (229, N'Trinidad', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (230, N'Tunisia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (231, N'Turkey', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (232, N'Turkmenistan', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (233, N'Tuvalu', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (234, N'Uganda', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (235, N'Ukraine', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (236, N'United Arab Emirates', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (237, N'United Kingdom', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (238, N'Uruguay', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (239, N'USA', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (240, N'Uzbekistan', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (241, N'Vanuatu', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (242, N'Venezuela', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (243, N'Vietnam', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (244, N'Virgin Islands', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (245, N'Wales', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (246, N'Wallis and Futuna', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (247, N'West Bank', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (248, N'Western Sahara', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (249, N'Yemen', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (250, N'Yugoslavia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (251, N'Zambia', 1)
INSERT [dbo].[tbl_Countries] ([CountryId], [CountryName], [CountryStatus]) VALUES (252, N'Zimbabwe', 1)
SET IDENTITY_INSERT [dbo].[tbl_Countries] OFF
SET IDENTITY_INSERT [dbo].[tbl_Registration] ON 

INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (1, 0, 2, N'userone', CAST(N'2015-03-26 00:00:00.000' AS DateTime), N'cvcxcvggyuy', 1, 9, N'GHiff', N'FDGyff', N'234237666', N'userone@gmail.com', N'12345', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (2, 3, 2, N'usertwo', CAST(N'2015-11-03 00:00:00.000' AS DateTime), N'dsf', 1, 13, N'sdf', N'sdf', N'121212121212', N'usertwo@gmail.com', N'12345', 1, 1, 1, 2012, 2017)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (3, 4, 2, N'userthree', CAST(N'2015-10-03 00:00:00.000' AS DateTime), N'cxvx', 1, 18, N'sdfds', N'dsfs', N'1321234124', N'userthree@gmail.com', N'12345', 1, 2, 2, 2012, 2018)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (4, 5, 2, N'userfour', CAST(N'2015-02-03 00:00:00.000' AS DateTime), N'sdfsd', 1, 18, N'cxzc', N'zxcz', N'2342352345', N'userfour@gmail.com', N'12345', 1, 2, 3, 2012, 2013)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (5, 6, 2, N'lincy', CAST(N'2015-03-03 00:00:00.000' AS DateTime), N'dfdffgghhg', 2, 105, N'Kerala', N'Cochin', N'657678787889', N'lincy@gmail.com', N'Lincy@123', 1, 4, 6, 2012, 2015)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (6, NULL, 2, N'aaa', CAST(N'2015-04-20 10:41:37.793' AS DateTime), NULL, 0, 0, NULL, NULL, N'111', N'aaa@gmail.com', N'aaa', 0, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (7, NULL, 2, N'aaa', CAST(N'2015-04-20 10:59:37.160' AS DateTime), NULL, 0, 0, NULL, NULL, N'123', N'aaa@gmail.com', N'aaa', 0, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (8, NULL, 2, N'aaa', CAST(N'2015-04-20 11:07:43.360' AS DateTime), NULL, 0, 0, NULL, NULL, N'111', N'aaa@gmail.com', N'aaa', 0, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (9, NULL, 2, N'aaa', CAST(N'2015-04-20 11:10:53.317' AS DateTime), NULL, 0, 0, NULL, NULL, N'111', N'aaa@gmail.com', N'aaa', 0, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (10, NULL, 2, N'aa', CAST(N'2015-04-20 11:18:06.380' AS DateTime), NULL, 0, 0, NULL, NULL, N'11', N'aaa@gmail.com', N'aaa', 0, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (11, NULL, 2, N'aa', CAST(N'2015-04-20 11:20:11.023' AS DateTime), NULL, 0, 0, NULL, NULL, N'1', N'aaa@gmail.com', N'aaa', 0, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (12, NULL, 2, N'aaa', CAST(N'2015-04-20 11:29:47.063' AS DateTime), NULL, 0, 0, NULL, NULL, N'11', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (13, NULL, 2, N'aa', CAST(N'2015-04-20 11:31:48.517' AS DateTime), NULL, 0, 0, NULL, NULL, N'123', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (14, NULL, 2, N'aaa', CAST(N'2015-04-20 11:41:29.007' AS DateTime), NULL, 0, 0, NULL, NULL, N'1234', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (15, NULL, 2, N'aaa', CAST(N'2015-04-20 11:41:29.007' AS DateTime), NULL, 0, 0, NULL, NULL, N'1234', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (16, 15, 2, N'aaa', CAST(N'2015-04-20 11:41:29.007' AS DateTime), NULL, 0, 0, NULL, NULL, N'1234', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (17, 16, 2, N'aaa', CAST(N'2015-04-20 11:41:29.007' AS DateTime), NULL, 0, 0, NULL, NULL, N'1234', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (18, 17, 2, N'aaa', CAST(N'2015-04-20 11:41:29.007' AS DateTime), NULL, 0, 0, NULL, NULL, N'1234', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (19, 18, 2, N'aaa', CAST(N'2015-04-20 11:41:29.007' AS DateTime), NULL, 0, 0, NULL, NULL, N'1234', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (20, 19, 2, N'aaa', CAST(N'2015-04-20 11:41:29.007' AS DateTime), NULL, 0, 0, NULL, NULL, N'1234', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (21, 20, 2, N'aaa', CAST(N'2015-04-20 11:41:29.007' AS DateTime), NULL, 0, 0, NULL, NULL, N'1234', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (22, 21, 2, N'aaa', CAST(N'2015-04-20 11:41:29.007' AS DateTime), NULL, 0, 0, NULL, NULL, N'1234', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (23, 22, 2, N'aaa', CAST(N'2015-04-20 11:41:29.007' AS DateTime), NULL, 0, 0, NULL, NULL, N'1234', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (24, 23, 2, N'aaa', CAST(N'2015-04-20 11:41:29.007' AS DateTime), NULL, 0, 0, NULL, NULL, N'1234', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (25, 24, 2, N'aaa', CAST(N'2015-04-20 11:41:29.007' AS DateTime), NULL, 0, 0, NULL, NULL, N'1234', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (26, 25, 2, N'aaa', CAST(N'2015-04-20 11:41:29.007' AS DateTime), NULL, 0, 0, NULL, NULL, N'1234', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (27, 7, 2, N'aaa', CAST(N'2015-04-20 11:41:29.007' AS DateTime), NULL, 0, 0, NULL, NULL, N'1234', N'aaa@gmail.com', N'aaa', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (28, 8, 2, N'qwerty', CAST(N'2015-04-20 11:55:59.053' AS DateTime), NULL, 0, 0, NULL, NULL, N'123456', N'qwerty@gmail.com', N'qwerty', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (29, 9, 3, N'lab', CAST(N'2015-04-20 11:59:48.590' AS DateTime), NULL, 0, 0, NULL, NULL, N'123', N'lab@gmail.com', N'lab', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (30, 10, 5, N'guest', CAST(N'2015-04-20 16:03:22.250' AS DateTime), NULL, 0, 0, NULL, NULL, N'12345', N'guest@gmail.com', N'guest', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (31, 11, 4, N'library', CAST(N'2015-04-23 18:06:58.733' AS DateTime), NULL, 0, 0, NULL, NULL, N'12334', N'library@gmail.com', N'library', 1, 0, 0, 0, 0)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (32, 12, 2, N'revathy', CAST(N'1993-06-14 00:00:00.000' AS DateTime), NULL, 2, NULL, NULL, N'cherthala', N'12356789', N'revathy@gmail.com', N'revathy', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Registration] ([RegistrationId], [UserId], [UserTypeId], [Name], [DateOfBirth], [Address], [Gender], [CountryId], [State], [City], [MobileNumber], [UserEmail], [Password], [Status], [DepartmentId], [SemesterId], [StartAcademicYear], [EndAcademicYear]) VALUES (33, 13, 3, N'CRO', CAST(N'2015-06-09 00:00:00.000' AS DateTime), NULL, 1, NULL, NULL, N'EKM', N'12345678', N'CRO@gmail.com', N'cro', 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_Registration] OFF
SET IDENTITY_INSERT [dbo].[tbl_State] ON 

INSERT [dbo].[tbl_State] ([StateId], [Name], [CountryId]) VALUES (1, N'Kerala', 105)
INSERT [dbo].[tbl_State] ([StateId], [Name], [CountryId]) VALUES (2, N'Tamil Nadu', 105)
INSERT [dbo].[tbl_State] ([StateId], [Name], [CountryId]) VALUES (3, N'Karnadaka', 105)
SET IDENTITY_INSERT [dbo].[tbl_State] OFF
SET IDENTITY_INSERT [dbo].[tbl_Student] ON 

INSERT [dbo].[tbl_Student] ([Id], [Name], [Age], [DOB], [Gender]) VALUES (1, N'Kiran', 24, CAST(N'2015-07-30 11:54:18.020' AS DateTime), 1)
INSERT [dbo].[tbl_Student] ([Id], [Name], [Age], [DOB], [Gender]) VALUES (2, N'Dheeraj', 28, CAST(N'2015-07-30 11:54:18.020' AS DateTime), 1)
INSERT [dbo].[tbl_Student] ([Id], [Name], [Age], [DOB], [Gender]) VALUES (3, N'Martin', 30, CAST(N'2015-07-30 11:54:18.020' AS DateTime), 1)
INSERT [dbo].[tbl_Student] ([Id], [Name], [Age], [DOB], [Gender]) VALUES (4, N'Preethy', 26, CAST(N'2015-07-30 11:54:18.020' AS DateTime), 1)
INSERT [dbo].[tbl_Student] ([Id], [Name], [Age], [DOB], [Gender]) VALUES (6, N'Asha', 25, CAST(N'2015-07-30 11:54:18.020' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[tbl_Student] OFF
SET IDENTITY_INSERT [dbo].[tbl_Users] ON 

INSERT [dbo].[tbl_Users] ([UserID], [Password], [UserTypeID], [UserEmail], [UserCreatedDate], [UserStatus]) VALUES (1, N'admin', 1, N'admin@gmail.com', CAST(N'2015-06-18 15:32:51.550' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[tbl_Users] OFF
SET IDENTITY_INSERT [dbo].[tbl_UserTypes] ON 

INSERT [dbo].[tbl_UserTypes] ([UserTypeID], [UserTypeName]) VALUES (1, N'Admin')
INSERT [dbo].[tbl_UserTypes] ([UserTypeID], [UserTypeName]) VALUES (2, N'User')
INSERT [dbo].[tbl_UserTypes] ([UserTypeID], [UserTypeName]) VALUES (3, N'CRO')
SET IDENTITY_INSERT [dbo].[tbl_UserTypes] OFF
SET IDENTITY_INSERT [dbo].[tblGallery] ON 

INSERT [dbo].[tblGallery] ([GalleryId], [FileName], [Title]) VALUES (1, N'e4db4203-4716-436f-a038-7a020de6f3c8.jpg', N'See')
INSERT [dbo].[tblGallery] ([GalleryId], [FileName], [Title]) VALUES (2, N'e389636d-d9e9-46ce-9385-7ae339d7cfef.jpg', N'Kiran')
INSERT [dbo].[tblGallery] ([GalleryId], [FileName], [Title]) VALUES (3, N'23623471-0f15-4f5a-b15d-a6ecc100af3e.jpg', N'Flower')
INSERT [dbo].[tblGallery] ([GalleryId], [FileName], [Title]) VALUES (4, N'075c0609-af63-4b60-aa4e-6d03ef5e30e0.jpg', N'koala')
INSERT [dbo].[tblGallery] ([GalleryId], [FileName], [Title]) VALUES (5, N'e63c723c-230c-47ef-830e-08f250333c05.jpg', N'pen')
INSERT [dbo].[tblGallery] ([GalleryId], [FileName], [Title]) VALUES (6, N'6284f62d-1b56-4108-98eb-fb34f426cde9.jpg', N'hy')
SET IDENTITY_INSERT [dbo].[tblGallery] OFF
/****** Object:  StoredProcedure [dbo].[sps_CountryModelSelect]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sps_CountryModelSelect]
(
    @Flag INT, 
    @CountryId INT
    

   
)
AS
BEGIN
-- select single Country
  IF (@Flag=1) 
	  BEGIN
	   SELECT     CountryId, CountryName,CountryStatus FROM   tbl_Countries WHERE CountryId= @CountryId
	  
	END
  ELSE IF (@Flag=2) -- select Countries
  BEGIN
			  
			  
			  SELECT     CountryId, CountryName,CountryStatus FROM         tbl_Countries
  END
  
END








GO
/****** Object:  StoredProcedure [dbo].[sps_FileUpViewModelInsert]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sps_FileUpViewModelInsert]
    @FileName NVARCHAR(50) ,
	 @Id INT OUTPUT,
    @Result INT OUTPUT
AS
    BEGIN
        SET @Result = 0;
       
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
        SET NOCOUNT ON;

    -- Insert statements for procedure here

        IF NOT EXISTS ( SELECT  FileName
                        FROM   [dbo].[FileUp]
                        WHERE   FileName = @FileName )
            BEGIN

                INSERT  INTO [dbo].[FileUp]
                        ( FileName)
                VALUES  ( @FileName)
                IF ( @@ERROR = 0 )
                    BEGIN
                        SET @Id = @@IDENTITY;
                        SET @Result = 1;
                    END 
                ELSE
                    SET @Result = 0;
            END
        ELSE
            BEGIN
                SET @Result = -1;
            END
	


    END



GO
/****** Object:  StoredProcedure [dbo].[sps_GalleryViewModelInsert]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sps_GalleryViewModelInsert]
    @FileName NVARCHAR(50) ,
	 @Id INT OUTPUT,
	 @Title  NVARCHAR(50),
    @Result INT OUTPUT
AS
    BEGIN
        SET @Result = 0;
       
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
        SET NOCOUNT ON;

    -- Insert statements for procedure here

        IF NOT EXISTS ( SELECT  FileName
                        FROM   [dbo].[FileUp]
                        WHERE   FileName = @FileName )
            BEGIN

                INSERT  INTO [dbo].[tblGallery]
                        ( FileName,Title)
                VALUES  ( @FileName,@Title)
                IF ( @@ERROR = 0 )
                    BEGIN
                        SET @Id = @@IDENTITY;
                        SET @Result = 1;
                    END 
                ELSE
                    SET @Result = 0;
            END
        ELSE
            BEGIN
                SET @Result = -1;
            END
	


    END



GO
/****** Object:  StoredProcedure [dbo].[sps_GalleryViewModelSelect]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[sps_GalleryViewModelSelect]
	 @Flag INT, 
    @Id INT
   AS
BEGIN
IF (@Flag=1) 
	  BEGIN
	  
SELECT      GalleryId,FileName,Title
FROM         [dbo].[tblGallery] where GalleryId=@Id
	 

			
	  END
 ELSE IF (@Flag=2) 
	  BEGIN
	  
SELECT      GalleryId,FileName,Title
FROM         [dbo].[tblGallery]
	 

			
	  END
 
end







GO
/****** Object:  StoredProcedure [dbo].[sps_GalleryViewModelUpdate]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sps_GalleryViewModelUpdate]
    (
      @Flag INT ,
      @GalleryId INT ,
      @FileName NVARCHAR(50) ,
      @Title NVARCHAR(50) ,
      
      @Result INT OUTPUT

    )
AS
    BEGIN
        SET @Result = 0;
        IF ( @Flag = 4 )
            BEGIN 

                UPDATE  [dbo].[tblGallery]
                SET     FileName = @FileName ,
              
                        Title = @Title 
                     
                WHERE   GalleryId = @GalleryId
                IF ( @@ERROR = 0 )
                    BEGIN
				

                        SET @Result = 1;  

                    END
                ELSE
                    SET @Result = 0  
            END
	
    END








GO
/****** Object:  StoredProcedure [dbo].[sps_RegistrationViewModelDelete]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sps_RegistrationViewModelDelete]
    (
      @Flag INT ,
      @RegistrationId INT ,
      @Result INT OUTPUT
    )
AS
    BEGIN

        SET @Result = 0;
        IF ( @Flag = 3 )
            BEGIN
                DELETE  FROM tbl_Registration
                WHERE   RegistrationId = @RegistrationId
			 
                IF ( @@ERROR = 0 )
                    SET @Result = 1
                ELSE
                    SET @Result = 0
            END
	
	
    END








GO
/****** Object:  StoredProcedure [dbo].[sps_RegistrationViewModelInsert]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
CREATE PROCEDURE [dbo].[sps_RegistrationViewModelInsert] 
	-- Add the parameters for the stored procedure here
    @UserId INT ,
    @UserTypeId INT ,
    @Name NVARCHAR(50) ,
    @DateOfBirth DATETIME ,
    @Gender INT ,
    @City NVARCHAR(50) ,
    @MobileNumber NVARCHAR(50) ,
    @UserEmail NVARCHAR(50) ,
    @Password NVARCHAR(50) ,
    @Status INT ,
    @RegistrationId INT OUTPUT ,
    @Result INT OUTPUT
AS
    BEGIN

        SET @Result = 0;
        SET @RegistrationId = 0;
        IF NOT EXISTS ( SELECT  *
                        FROM    tbl_Users
                        WHERE   UserEmail = @UserEmail )
            BEGIN 
   
    -- insert to user table	FROM tbl_Registrations TABLE		     
			     
			    
                INSERT  INTO tbl_Users
                        ( Password ,
                          UserTypeId ,
                          UserEmail ,
                          UserStatus
                        )
                VALUES  ( @Password ,
                          @UserTypeId ,
                          @UserEmail ,
                          @Status
                        )
					
		        
                 
                SET @UserId = @@IDENTITY;    

				
                  

    -- Insert statements for procedure here
                INSERT  INTO tbl_Registration
                        ( UserId ,
                          UserTypeId ,
                          Name ,
                          
                          DateOfBirth ,
                          Gender ,
                        
                          City ,
                          MobileNumber ,
                          UserEmail ,
                          Password ,
                          Status 
                         
	
	
	                    )
                VALUES  ( @UserId ,
                          @UserTypeId ,
                          @Name ,
                          
                          @DateOfBirth ,
                          @Gender ,
                         
                          @City ,
                          @MobileNumber ,
                          @UserEmail ,
                          @Password ,
                          @Status 
                         
	
	
	                    )
                IF ( @@ERROR = 0 )
                    BEGIN
                        SET @RegistrationId = @@IDENTITY;
                        SET @Result = 1;
                    END 
                ELSE
                    SET @Result = 0;
			   
            END
        ELSE
            SET @Result = -1 --  ALREADY EXIST		   
    END








GO
/****** Object:  StoredProcedure [dbo].[sps_RegistrationViewModelSelect]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sps_RegistrationViewModelSelect]
    (
      @Flag INT ,
      @RegistrationId INT
    )
AS
    BEGIN
--
        IF ( @Flag = 1 )
            BEGIN
	  
                SELECT  RegistrationId ,
                        UserId ,
                        UserTypeId ,
                        Name ,
                        DateOfBirth ,
                        Address ,
                        Gender ,
                        CountryId ,
                        State ,
                        City ,
                        MobileNumber ,
                        UserEmail ,
                        Password ,
                        Status ,
                        DepartmentId ,
                        SemesterId ,
                        StartAcademicYear ,
                        EndAcademicYear
                FROM    tbl_Registration
                WHERE   RegistrationId = @RegistrationId


            END
        ELSE
            IF ( @Flag = 2 ) --
                BEGIN


                    SELECT  RegistrationId ,
                            UserId ,
                            UserTypeId ,
                            Name ,
                            DateOfBirth ,
                            Address ,
                            Gender ,
                            CountryId ,
                            State ,
                            City ,
                            MobileNumber ,
                            UserEmail ,
                            Password ,
                            Status ,
                            DepartmentId ,
                            SemesterId ,
                            StartAcademicYear ,
                            EndAcademicYear
                    FROM    tbl_Registration


                END
  
    END








GO
/****** Object:  StoredProcedure [dbo].[sps_RegistrationViewModelUpdate]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sps_RegistrationViewModelUpdate]
    (
      @Flag INT ,
      @RegistrationId INT ,
      @UserId INT ,
      @Name NVARCHAR(50) ,
      @Address NVARCHAR(50) ,
      @DateOfBirth DATETIME ,
      @Gender NVARCHAR(50) ,
      @CountryId INT ,
      @State NVARCHAR(50) ,
      @City NVARCHAR(50) ,
      @MobileNumber NVARCHAR(50) ,
      @DepartmentId INT ,
      @SemesterId INT ,
      @StartAcademicYear INT ,
      @EndAcademicYear INT ,
      @Result INT OUTPUT

    )
AS
    BEGIN
        SET @Result = 0;
        IF ( @Flag = 4 )
            BEGIN 

                UPDATE  dbo.tbl_Registration
                SET     UserId = @UserId ,
                        Name = @Name ,
                        Address = @Address ,
                        DateOfBirth = @DateOfBirth ,
                        Gender = @Gender ,
                        CountryId = @CountryId ,
                        State = @State ,
                        City = @City ,
                        MobileNumber = @MobileNumber ,
                        DepartmentId = @DepartmentId ,
                        SemesterId = @SemesterId ,
                        StartAcademicYear = @StartAcademicYear ,
                        EndAcademicYear = @EndAcademicYear
                WHERE   RegistrationId = @RegistrationId
                IF ( @@ERROR = 0 )
                    BEGIN
				

                        SET @Result = 1;  

                    END
                ELSE
                    SET @Result = 0  
            END
	
    END








GO
/****** Object:  StoredProcedure [dbo].[sps_StateOptionSelectViewModelSelect]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sps_StateOptionSelectViewModelSelect]
(
    @Flag INT
 
    

   
)
AS
BEGIN
-- select single Country
  IF (@Flag=6) 
	  BEGIN
	   SELECT     StateId,Name,CountryId,( select CountryName from tbl_Countries where CountryId=[dbo].[tbl_State].[CountryId])as CountryName FROM   tbl_State 
	  
	END

  
END








GO
/****** Object:  StoredProcedure [dbo].[sps_StudentViewModelDelete]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sps_StudentViewModelDelete]
	@Flag INT,
@Id INT,
@Result INT OUTPUT
AS
BEGIN
	SET @Result=0;
	IF (@Flag = 3)
		BEGIN
			DELETE FROM dbo.tbl_Student  WHERE Id=@Id 
			 
			 IF(@@ERROR =0)

				  SET @Result = 1
			 ELSE 
				  SET @Result = 0
		END
	
	
END







GO
/****** Object:  StoredProcedure [dbo].[sps_StudentViewModelInsert]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sps_StudentViewModelInsert]
    @Name NVARCHAR(50) ,
    @Age INT ,
    @Id INT OUTPUT ,
    @Result INT OUTPUT
AS
    BEGIN
        SET @Result = 0;
        SET @Id = 0;
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
        SET NOCOUNT ON;

    -- Insert statements for procedure here

        IF NOT EXISTS ( SELECT  Name
                        FROM    dbo.tbl_Student
                        WHERE   Name = @Name )
            BEGIN

                INSERT  INTO tbl_Student
                        ( Name, Age )
                VALUES  ( @Name, @Age )
                IF ( @@ERROR = 0 )
                    BEGIN
                        SET @Id = @@IDENTITY;
                        SET @Result = 1;
                    END 
                ELSE
                    SET @Result = 0;
            END
        ELSE
            BEGIN
                SET @Result = -1;
            END
	


    END



GO
/****** Object:  StoredProcedure [dbo].[sps_StudentViewModelKeywordSearch]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sps_StudentViewModelKeywordSearch]
	-- Add the parameters for the stored procedure here
    @PageIndex INT ,
    @PageSize INT ,
	@Keyword varchar(50),
    @TotalCount INT OUTPUT
AS
    BEGIN

        SELECT  @TotalCount = COUNT(*)
        FROM    [dbo].[tbl_Student] where  Name Like @Keyword+'%';

        WITH    CTESelect
                  AS ( SELECT   S.Id ,
                                S.Name ,
                                S.Age ,
								S.Gender,
                                ROW_NUMBER() OVER ( ORDER BY Id ) AS RowNumber
                       FROM     [dbo].[tbl_Student]S  where  S.Name Like @Keyword+'%'
                     )
            SELECT  Id ,
                    Name ,
                    Age ,
					Gender,
                    RowNumber
            FROM    CTESelect
            WHERE   RowNumber BETWEEN ( @PageIndex * @PageSize ) + 1
                              AND     ( @PageIndex * @PageSize ) + @PageSize
		
		


    END






GO
/****** Object:  StoredProcedure [dbo].[sps_StudentViewModelKeywordSearchWithOutPaging]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sps_StudentViewModelKeywordSearchWithOutPaging] 
(
@Flag int,
	@Keyword nvarchar(50)
	)
  
AS
    BEGIN

  IF ( @Flag = 7)
            BEGIN

       SELECT   S.Id ,
                                S.Name ,
                                S.Age ,
								S.Gender
                              
                       FROM     [dbo].[tbl_Student] S  where  S.Name Like @Keyword+'%'
                   
		
		
  end

    END






GO
/****** Object:  StoredProcedure [dbo].[sps_StudentViewModelReport]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sps_StudentViewModelReport]
	-- Add the parameters for the stored procedure here
   (
   @Flag int,
	@StartDate DateTime,
    @EndDate DateTime
	)
AS
    BEGIN
	  IF ( @Flag = 8)
            BEGIN

       SELECT   S.Id ,
                                S.Name ,
                                S.Age ,
								S.Gender,
								S.DOB
                                
                       FROM     [dbo].[tbl_Student]S  where  S.DOB Between @StartDate and @EndDate
                   
		end


    END






GO
/****** Object:  StoredProcedure [dbo].[sps_StudentViewModelSearch]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sps_StudentViewModelSearch] 
	-- Add the parameters for the stored procedure here
    @PageIndex INT ,
    @PageSize INT ,
    @TotalCount INT OUTPUT
AS
    BEGIN

        SELECT  @TotalCount = COUNT(*)
        FROM    [dbo].[tbl_Student];

        WITH    CTESelect
                  AS ( SELECT   S.Id ,
                                S.Name ,
                                S.Age ,
                                ROW_NUMBER() OVER ( ORDER BY Id ) AS RowNumber
                       FROM     [dbo].[tbl_Student] S
                     )
            SELECT  Id ,
                    Name ,
                    Age ,
                    RowNumber
            FROM    CTESelect
            WHERE   RowNumber BETWEEN ( @PageIndex * @PageSize ) + 1
                              AND     ( @PageIndex * @PageSize ) + @PageSize
		
		


    END






GO
/****** Object:  StoredProcedure [dbo].[sps_StudentViewModelSelect]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[sps_StudentViewModelSelect]
	 @Flag INT, 
    @Id INT
   AS
BEGIN
  IF (@Flag=1) 
	  BEGIN
	  
SELECT      Id,Name, Age
FROM         tbl_Student  WHERE Id= @Id
	 

			
	  END
  ELSE IF (@Flag=2) 
  BEGIN
			 
SELECT       Id,Name, Age
FROM          dbo.tbl_Student
END
ELSE IF (@Flag=5) 
  BEGIN
			 
SELECT       Id,Name
FROM          dbo.tbl_Student
END
end







GO
/****** Object:  StoredProcedure [dbo].[sps_StudentViewModelUpdate]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sps_StudentViewModelUpdate] 
	@Flag int,
	@Id int,
	@Name nvarchar(50),	
	@Age int,
	

	@Result int output
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update dbo.tbl_Student 
	set
Name=@Name,
Age=@Age
	where Id=@Id 

	IF(@@ERROR = 0)  
			 BEGIN
				

			SET @Result = 1;  

			END
		 ELSE   
		SET @Result = 0  
END






GO
/****** Object:  StoredProcedure [dbo].[sps_UserViewModelSelect]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sps_UserViewModelSelect]
(
    @Flag INT, 
    @UserID INT,
    @UserEmail VARCHAR(50),
    @Password VARCHAR(50),
    @UserTypeID INT
)
AS
BEGIN
  IF (@Flag=1)
	  BEGIN
	  SELECT  UserID, Password, UserTypeID, UserEmail, UserCreatedDate, UserStatus
		FROM  tbl_Users WHERE UserID=@UserID
	  
		
	  END
  ELSE IF (@Flag=2)
  BEGIN
		SELECT  UserID, Password,  UserTypeID, UserEmail, UserCreatedDate, UserStatus
		FROM  tbl_Users
  END
   ELSE IF (@Flag=6)
  BEGIN
		SELECT  UserID,  Password,  UserTypeID, UserEmail, UserCreatedDate, UserStatus
		FROM  tbl_Users
		
		WHERE UserEmail=@UserEmail AND [Password] = @Password  AND UserStatus=1;
  END
END








GO
/****** Object:  StoredProcedure [dbo].[sps_UserViewModelUpdate]    Script Date: 8/11/2015 1:44:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sps_UserViewModelUpdate]  
( 
@UserId int,
@Flag INT,
@OldPassword nvarchar(50),
@Password nvarchar(50),
@UserTypeId int,
@UserEmail nvarchar(50),
@UserStatus INT ,
@Result INT OUTPUT

)
AS
BEGIN
SET @Result =0;

 IF (@Flag = 5)  
	BEGIN  
	UPDATE tbl_Users SET UserStatus=@UserStatus  
		WHERE UserId = @UserId  
		 IF(@@ERROR =0)  
		SET @Result = 1;  
		 ELSE   
		SET @Result = 0  
	END  
	ELSE IF (@Flag = 7)  
	BEGIN  

	 IF  Exists (SELECT * from tbl_Users where UserEmail= @UserEmail and Password=@OldPassword AND UserStatus=1)  
   BEGIN 

	UPDATE tbl_Users SET [Password]=@Password  
		WHERE UserEmail = @UserEmail; --and UserStatus=1;
		 IF(@@ERROR =0)  
		SET @Result = 1;  
		 ELSE   
		SET @Result = 0    
    END
	ELSE
	BEGIN
	    SET @Result = -2;
	END
	

	END  

END








GO
USE [master]
GO
ALTER DATABASE [STUDENT] SET  READ_WRITE 
GO
