USE [master]
GO
/****** Object:  Database [EventDB]    Script Date: 04-06-2020 22:22:04 ******/
CREATE DATABASE [EventDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EventDB', FILENAME = N'C:\Users\Heema\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\EventDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EventDB_log', FILENAME = N'C:\Users\Heema\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\EventDB.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EventDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EventDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EventDB] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [EventDB] SET ANSI_NULLS ON 
GO
ALTER DATABASE [EventDB] SET ANSI_PADDING ON 
GO
ALTER DATABASE [EventDB] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [EventDB] SET ARITHABORT ON 
GO
ALTER DATABASE [EventDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EventDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EventDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EventDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EventDB] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [EventDB] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [EventDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EventDB] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [EventDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EventDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EventDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EventDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EventDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EventDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EventDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EventDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EventDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EventDB] SET RECOVERY FULL 
GO
ALTER DATABASE [EventDB] SET  MULTI_USER 
GO
ALTER DATABASE [EventDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EventDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EventDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EventDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EventDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EventDB] SET QUERY_STORE = OFF
GO
USE [EventDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [EventDB]
GO
/****** Object:  Table [dbo].[Tbladmin]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbladmin](
	[Adminid] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[Profilepic] [varchar](50) NULL,
	[Contactno] [varchar](10) NULL,
	[Createddate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Adminid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblcategory]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblcategory](
	[Categoryid] [int] IDENTITY(1,1) NOT NULL,
	[Categoryname] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Categoryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblchat]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblchat](
	[Chatid] [int] IDENTITY(1,1) NOT NULL,
	[Message] [varchar](100) NOT NULL,
	[Senderid] [int] NOT NULL,
	[Receiverid] [int] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Createddate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Chatid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblcity]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblcity](
	[Cityid] [int] IDENTITY(1,1) NOT NULL,
	[Cityname] [varchar](50) NOT NULL,
	[Stateid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Cityid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblclient]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblclient](
	[Clientid] [int] IDENTITY(1,1) NOT NULL,
	[Address] [varchar](200) NULL,
	[Zip] [int] NULL,
	[Gender] [tinyint] NULL,
	[Name] [varchar](50) NOT NULL,
	[Dateofbirth] [date] NULL,
	[Userid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Clientid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbleventmanager]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbleventmanager](
	[Eventmanagerid] [int] IDENTITY(1,1) NOT NULL,
	[Companyname] [varchar](100) NULL,
	[Website] [varchar](100) NULL,
	[Name] [varchar](50) NULL,
	[Userid] [int] NOT NULL,
	[About] [varchar](100) NULL,
	[Coverpic] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Eventmanagerid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblmanagertender]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblmanagertender](
	[Managertenderid] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Cityid] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Eventmanagerid] [int] NOT NULL,
	[Subcategoryid] [int] NOT NULL,
	[Startingdate] [datetime] NOT NULL,
	[Endingdate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Managertenderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblmanagertenderbid]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblmanagertenderbid](
	[Managertenderbidid] [int] IDENTITY(1,1) NOT NULL,
	[Managertenderid] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Eventmanagerid] [int] NOT NULL,
	[Createddate] [datetime] NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[Is_selected] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Managertenderbidid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblmanagertenderbidimages]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblmanagertenderbidimages](
	[Managertenderbidimagesid] [int] IDENTITY(1,1) NOT NULL,
	[Managertenderbidid] [int] NOT NULL,
	[ImageURL] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Managertenderbidimagesid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblnotification]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblnotification](
	[Notificationid] [int] IDENTITY(1,1) NOT NULL,
	[Message] [varchar](250) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Createddate] [datetime] NOT NULL,
	[Fromuserid] [int] NOT NULL,
	[Touserid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Notificationid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblpastwork]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblpastwork](
	[Pastworkid] [int] IDENTITY(1,1) NOT NULL,
	[Eventmanagerid] [int] NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[Createddate] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Subcategoryid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Pastworkid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblpastworkimage]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblpastworkimage](
	[Pastworkimageid] [int] IDENTITY(1,1) NOT NULL,
	[Pastworkid] [int] NOT NULL,
	[ImageURL] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Pastworkimageid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblpastworklike]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblpastworklike](
	[Pastworklikeid] [int] IDENTITY(1,1) NOT NULL,
	[Pastworkid] [int] NOT NULL,
	[Clientid] [int] NOT NULL,
	[Createddate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Pastworklikeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblpastworkvideo]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblpastworkvideo](
	[Pastworkvideoid] [int] IDENTITY(1,1) NOT NULL,
	[Pastworkid] [int] NOT NULL,
	[VideoURL] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Pastworkvideoid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblreporteventmnager]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblreporteventmnager](
	[Reporteventmanagerid] [int] IDENTITY(1,1) NOT NULL,
	[Reason] [varchar](100) NOT NULL,
	[Createddate] [datetime] NOT NULL,
	[Eventmanagerid] [int] NOT NULL,
	[Clientid] [int] NOT NULL,
	[Status] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Reporteventmanagerid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblreportuser]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblreportuser](
	[Reportuserid] [int] IDENTITY(1,1) NOT NULL,
	[Reason] [varchar](150) NOT NULL,
	[Createddate] [datetime] NOT NULL,
	[Eventmanagerid] [int] NOT NULL,
	[Clientid] [int] NOT NULL,
	[Status] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Reportuserid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblreview]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblreview](
	[Reviewid] [int] IDENTITY(1,1) NOT NULL,
	[Review] [varchar](150) NOT NULL,
	[Clientid] [int] NOT NULL,
	[Createddate] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Eventmanagerid] [int] NOT NULL,
	[Rating] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Reviewid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblstate]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblstate](
	[Stateid] [int] IDENTITY(1,1) NOT NULL,
	[Statename] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Stateid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblsubcategory]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblsubcategory](
	[Subcategoryid] [int] IDENTITY(1,1) NOT NULL,
	[Subcategoryname] [varchar](50) NOT NULL,
	[Categoryid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Subcategoryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbluser]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbluser](
	[Userid] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Usertype] [tinyint] NOT NULL,
	[Contactno] [varchar](10) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Profilepic] [varchar](100) NULL,
	[Cityid] [int] NOT NULL,
	[Registrationdate] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblusertender]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblusertender](
	[Usertenderid] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](1500) NOT NULL,
	[Clientid] [int] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Cityid] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Subcategoryid] [int] NOT NULL,
	[Startingdate] [datetime] NOT NULL,
	[Endingdate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Usertenderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblusertenderbid]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblusertenderbid](
	[Usertenderbidid] [int] IDENTITY(1,1) NOT NULL,
	[Usertenderid] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Description] [varchar](1500) NOT NULL,
	[Is_selected] [tinyint] NULL,
	[Eventmanagerid] [int] NOT NULL,
	[Createddate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Usertenderbidid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblusertenderbidimages]    Script Date: 04-06-2020 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblusertenderbidimages](
	[Usertenderbidimagesid] [int] IDENTITY(1,1) NOT NULL,
	[Usertenderbidid] [int] NOT NULL,
	[ImageURL] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Usertenderbidimagesid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbladmin] ON 

INSERT [dbo].[Tbladmin] ([Adminid], [Username], [Password], [Email], [Profilepic], [Contactno], [Createddate]) VALUES (1, N'admin', N'admin', N'admin@gmail.com', NULL, N'7894561230', CAST(N'2020-04-12T13:29:17.433' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tbladmin] OFF
SET IDENTITY_INSERT [dbo].[Tblcategory] ON 

INSERT [dbo].[Tblcategory] ([Categoryid], [Categoryname]) VALUES (1, N'Seminars')
INSERT [dbo].[Tblcategory] ([Categoryid], [Categoryname]) VALUES (2, N'Conferences')
INSERT [dbo].[Tblcategory] ([Categoryid], [Categoryname]) VALUES (3, N'Reunions')
INSERT [dbo].[Tblcategory] ([Categoryid], [Categoryname]) VALUES (4, N'Parties')
INSERT [dbo].[Tblcategory] ([Categoryid], [Categoryname]) VALUES (5, N'Workshops')
SET IDENTITY_INSERT [dbo].[Tblcategory] OFF
SET IDENTITY_INSERT [dbo].[Tblcity] ON 

INSERT [dbo].[Tblcity] ([Cityid], [Cityname], [Stateid]) VALUES (1, N'Surat', 1)
INSERT [dbo].[Tblcity] ([Cityid], [Cityname], [Stateid]) VALUES (2, N'bardoli', 1)
SET IDENTITY_INSERT [dbo].[Tblcity] OFF
SET IDENTITY_INSERT [dbo].[Tblclient] ON 

INSERT [dbo].[Tblclient] ([Clientid], [Address], [Zip], [Gender], [Name], [Dateofbirth], [Userid]) VALUES (1, N'Udhna , Surat', 394210, 0, N'vivek reshamwala', NULL, 1)
SET IDENTITY_INSERT [dbo].[Tblclient] OFF
SET IDENTITY_INSERT [dbo].[Tbleventmanager] ON 

INSERT [dbo].[Tbleventmanager] ([Eventmanagerid], [Companyname], [Website], [Name], [Userid], [About], [Coverpic]) VALUES (1, N'Kessar Events India', N'www.kessarevents.com', N'Herry Patel', 2, N'Pandesara,Surat.', N'33611.event-grid.jpg')
INSERT [dbo].[Tbleventmanager] ([Eventmanagerid], [Companyname], [Website], [Name], [Userid], [About], [Coverpic]) VALUES (2, N'Luxurito Events -Destination Wedding Planning Company', N'www.luxuritoevents.in/', N'Heema Patel', 3, N'Vesu,Surat', N'987052.event-grid.jpg')
SET IDENTITY_INSERT [dbo].[Tbleventmanager] OFF
SET IDENTITY_INSERT [dbo].[Tblmanagertender] ON 

INSERT [dbo].[Tblmanagertender] ([Managertenderid], [Description], [Status], [Cityid], [Price], [Eventmanagerid], [Subcategoryid], [Startingdate], [Endingdate]) VALUES (1, N'Nice', 0, 2, 30000, 1, 3, CAST(N'2020-05-27T10:00:05.000' AS DateTime), CAST(N'2020-06-16' AS Date))
SET IDENTITY_INSERT [dbo].[Tblmanagertender] OFF
SET IDENTITY_INSERT [dbo].[Tblpastwork] ON 

INSERT [dbo].[Tblpastwork] ([Pastworkid], [Eventmanagerid], [Description], [Createddate], [Status], [Subcategoryid]) VALUES (1, 1, N'Good', CAST(N'2020-05-19T10:50:20.000' AS DateTime), 0, 2)
INSERT [dbo].[Tblpastwork] ([Pastworkid], [Eventmanagerid], [Description], [Createddate], [Status], [Subcategoryid]) VALUES (2, 2, N'Nice', CAST(N'2020-05-29T10:20:30.000' AS DateTime), 0, 1)
INSERT [dbo].[Tblpastwork] ([Pastworkid], [Eventmanagerid], [Description], [Createddate], [Status], [Subcategoryid]) VALUES (3, 2, N'Good work', CAST(N'2020-05-30T10:50:20.000' AS DateTime), 0, 7)
INSERT [dbo].[Tblpastwork] ([Pastworkid], [Eventmanagerid], [Description], [Createddate], [Status], [Subcategoryid]) VALUES (4, 1, N'Nice', CAST(N'2020-06-01T20:20:30.000' AS DateTime), 0, 6)
SET IDENTITY_INSERT [dbo].[Tblpastwork] OFF
SET IDENTITY_INSERT [dbo].[Tblstate] ON 

INSERT [dbo].[Tblstate] ([Stateid], [Statename]) VALUES (1, N'Gujarat')
SET IDENTITY_INSERT [dbo].[Tblstate] OFF
SET IDENTITY_INSERT [dbo].[Tblsubcategory] ON 

INSERT [dbo].[Tblsubcategory] ([Subcategoryid], [Subcategoryname], [Categoryid]) VALUES (1, N'Personal Development', 1)
INSERT [dbo].[Tblsubcategory] ([Subcategoryid], [Subcategoryname], [Categoryid]) VALUES (2, N'Business', 1)
INSERT [dbo].[Tblsubcategory] ([Subcategoryid], [Subcategoryname], [Categoryid]) VALUES (3, N'Academia', 1)
INSERT [dbo].[Tblsubcategory] ([Subcategoryid], [Subcategoryname], [Categoryid]) VALUES (4, N'Christmas', 4)
INSERT [dbo].[Tblsubcategory] ([Subcategoryid], [Subcategoryname], [Categoryid]) VALUES (5, N'New Year''s', 4)
INSERT [dbo].[Tblsubcategory] ([Subcategoryid], [Subcategoryname], [Categoryid]) VALUES (6, N'Dance', 4)
INSERT [dbo].[Tblsubcategory] ([Subcategoryid], [Subcategoryname], [Categoryid]) VALUES (7, N'Birthday', 4)
INSERT [dbo].[Tblsubcategory] ([Subcategoryid], [Subcategoryname], [Categoryid]) VALUES (8, N'Anniversary', 4)
SET IDENTITY_INSERT [dbo].[Tblsubcategory] OFF
SET IDENTITY_INSERT [dbo].[Tbluser] ON 

INSERT [dbo].[Tbluser] ([Userid], [Username], [Password], [Usertype], [Contactno], [Email], [Profilepic], [Cityid], [Registrationdate], [Status]) VALUES (1, N'vivek', N'123', 1, N'7845120369', N'vivek@gmail.com', N'47923user8-128x128.jpg', 1, CAST(N'2020-05-08T10:55:51.213' AS DateTime), 0)
INSERT [dbo].[Tbluser] ([Userid], [Username], [Password], [Usertype], [Contactno], [Email], [Profilepic], [Cityid], [Registrationdate], [Status]) VALUES (2, N'herry', N'123', 2, N'7845120365', N'herry@gmail.com', N'74403user1-128x128.jpg', 1, CAST(N'2020-05-08T10:56:52.810' AS DateTime), 0)
INSERT [dbo].[Tbluser] ([Userid], [Username], [Password], [Usertype], [Contactno], [Email], [Profilepic], [Cityid], [Registrationdate], [Status]) VALUES (3, N'heema', N'123', 2, N'9685741230', N'heema@gmail.com', N'38783avatar-4', 2, CAST(N'2020-05-28T10:55:51.213' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Tbluser] OFF
SET IDENTITY_INSERT [dbo].[Tblusertender] ON 

INSERT [dbo].[Tblusertender] ([Usertenderid], [Description], [Clientid], [Status], [Cityid], [Price], [Subcategoryid], [Startingdate], [Endingdate]) VALUES (1, N'Nice', 1, 0, 1, 25000, 2, CAST(N'2020-05-27T13:00:00.000' AS DateTime), CAST(N'2020-06-03' AS Date))
INSERT [dbo].[Tblusertender] ([Usertenderid], [Description], [Clientid], [Status], [Cityid], [Price], [Subcategoryid], [Startingdate], [Endingdate]) VALUES (2, N'My Birthday', 1, 0, 1, 5000, 7, CAST(N'2020-05-28T11:01:28.060' AS DateTime), CAST(N'2020-07-18' AS Date))
SET IDENTITY_INSERT [dbo].[Tblusertender] OFF
SET IDENTITY_INSERT [dbo].[Tblusertenderbid] ON 

INSERT [dbo].[Tblusertenderbid] ([Usertenderbidid], [Usertenderid], [Price], [Description], [Is_selected], [Eventmanagerid], [Createddate]) VALUES (1, 1, 1452, N'i''am best for business seminars.', 0, 1, CAST(N'2020-06-04T21:28:27.127' AS DateTime))
INSERT [dbo].[Tblusertenderbid] ([Usertenderbidid], [Usertenderid], [Price], [Description], [Is_selected], [Eventmanagerid], [Createddate]) VALUES (2, 1, 1500, N'im good for seminars.', 0, 2, CAST(N'2020-06-04T22:18:20.360' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tblusertenderbid] OFF
SET IDENTITY_INSERT [dbo].[Tblusertenderbidimages] ON 

INSERT [dbo].[Tblusertenderbidimages] ([Usertenderbidimagesid], [Usertenderbidid], [ImageURL]) VALUES (1, 1, N'72372_Bid_1.1.upcoming-small.jpg')
INSERT [dbo].[Tblusertenderbidimages] ([Usertenderbidimagesid], [Usertenderbidid], [ImageURL]) VALUES (2, 1, N'47314_Bid_1.upcoming-big.jpg')
INSERT [dbo].[Tblusertenderbidimages] ([Usertenderbidimagesid], [Usertenderbidid], [ImageURL]) VALUES (3, 1, N'2758_Bid_event-3.jpg')
INSERT [dbo].[Tblusertenderbidimages] ([Usertenderbidimagesid], [Usertenderbidid], [ImageURL]) VALUES (1002, 2, N'90486_Bid_2.jpg')
INSERT [dbo].[Tblusertenderbidimages] ([Usertenderbidimagesid], [Usertenderbidid], [ImageURL]) VALUES (1003, 2, N'10085_Bid_5.event-grid.jpg')
INSERT [dbo].[Tblusertenderbidimages] ([Usertenderbidimagesid], [Usertenderbidid], [ImageURL]) VALUES (1004, 2, N'29584_Bid_7.event-grid.jpg')
SET IDENTITY_INSERT [dbo].[Tblusertenderbidimages] OFF
ALTER TABLE [dbo].[Tbladmin] ADD  DEFAULT (getdate()) FOR [Createddate]
GO
ALTER TABLE [dbo].[Tblchat] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Tblchat] ADD  DEFAULT (getdate()) FOR [Createddate]
GO
ALTER TABLE [dbo].[Tblmanagertender] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Tblmanagertender] ADD  DEFAULT (getdate()) FOR [Startingdate]
GO
ALTER TABLE [dbo].[Tblmanagertenderbid] ADD  DEFAULT (getdate()) FOR [Createddate]
GO
ALTER TABLE [dbo].[Tblmanagertenderbid] ADD  DEFAULT ((0)) FOR [Is_selected]
GO
ALTER TABLE [dbo].[Tblnotification] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Tblnotification] ADD  DEFAULT (getdate()) FOR [Createddate]
GO
ALTER TABLE [dbo].[Tblpastwork] ADD  DEFAULT (getdate()) FOR [Createddate]
GO
ALTER TABLE [dbo].[Tblpastwork] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Tblpastworklike] ADD  DEFAULT (getdate()) FOR [Createddate]
GO
ALTER TABLE [dbo].[Tblreporteventmnager] ADD  DEFAULT (getdate()) FOR [Createddate]
GO
ALTER TABLE [dbo].[Tblreporteventmnager] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Tblreportuser] ADD  DEFAULT (getdate()) FOR [Createddate]
GO
ALTER TABLE [dbo].[Tblreportuser] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Tblreview] ADD  DEFAULT (getdate()) FOR [Createddate]
GO
ALTER TABLE [dbo].[Tblreview] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Tbluser] ADD  DEFAULT (getdate()) FOR [Registrationdate]
GO
ALTER TABLE [dbo].[Tbluser] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Tblusertender] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Tblusertender] ADD  DEFAULT (getdate()) FOR [Startingdate]
GO
ALTER TABLE [dbo].[Tblusertenderbid] ADD  DEFAULT ((0)) FOR [Is_selected]
GO
ALTER TABLE [dbo].[Tblusertenderbid] ADD  DEFAULT (getdate()) FOR [Createddate]
GO
ALTER TABLE [dbo].[Tblchat]  WITH CHECK ADD  CONSTRAINT [fk_Tblchat_ToTbluser1] FOREIGN KEY([Senderid])
REFERENCES [dbo].[Tbluser] ([Userid])
GO
ALTER TABLE [dbo].[Tblchat] CHECK CONSTRAINT [fk_Tblchat_ToTbluser1]
GO
ALTER TABLE [dbo].[Tblchat]  WITH CHECK ADD  CONSTRAINT [fk_Tblchat_ToTbluser2] FOREIGN KEY([Receiverid])
REFERENCES [dbo].[Tbluser] ([Userid])
GO
ALTER TABLE [dbo].[Tblchat] CHECK CONSTRAINT [fk_Tblchat_ToTbluser2]
GO
ALTER TABLE [dbo].[Tblcity]  WITH CHECK ADD  CONSTRAINT [FK_Tblcity_ToTblState] FOREIGN KEY([Stateid])
REFERENCES [dbo].[Tblstate] ([Stateid])
GO
ALTER TABLE [dbo].[Tblcity] CHECK CONSTRAINT [FK_Tblcity_ToTblState]
GO
ALTER TABLE [dbo].[Tblclient]  WITH CHECK ADD  CONSTRAINT [FK_Tblclient_ToTbluser] FOREIGN KEY([Userid])
REFERENCES [dbo].[Tbluser] ([Userid])
GO
ALTER TABLE [dbo].[Tblclient] CHECK CONSTRAINT [FK_Tblclient_ToTbluser]
GO
ALTER TABLE [dbo].[Tbleventmanager]  WITH CHECK ADD  CONSTRAINT [FK_Tbleventmanager_ToTbluser] FOREIGN KEY([Userid])
REFERENCES [dbo].[Tbluser] ([Userid])
GO
ALTER TABLE [dbo].[Tbleventmanager] CHECK CONSTRAINT [FK_Tbleventmanager_ToTbluser]
GO
ALTER TABLE [dbo].[Tblmanagertender]  WITH CHECK ADD  CONSTRAINT [fk_Tblmanagertender_ToTblcity] FOREIGN KEY([Cityid])
REFERENCES [dbo].[Tblcity] ([Cityid])
GO
ALTER TABLE [dbo].[Tblmanagertender] CHECK CONSTRAINT [fk_Tblmanagertender_ToTblcity]
GO
ALTER TABLE [dbo].[Tblmanagertender]  WITH CHECK ADD  CONSTRAINT [fk_Tblmanagertender_ToTblsubcategory] FOREIGN KEY([Subcategoryid])
REFERENCES [dbo].[Tblsubcategory] ([Subcategoryid])
GO
ALTER TABLE [dbo].[Tblmanagertender] CHECK CONSTRAINT [fk_Tblmanagertender_ToTblsubcategory]
GO
ALTER TABLE [dbo].[Tblmanagertender]  WITH CHECK ADD  CONSTRAINT [fk_Tblmanagertender_ToTbluser] FOREIGN KEY([Eventmanagerid])
REFERENCES [dbo].[Tbleventmanager] ([Eventmanagerid])
GO
ALTER TABLE [dbo].[Tblmanagertender] CHECK CONSTRAINT [fk_Tblmanagertender_ToTbluser]
GO
ALTER TABLE [dbo].[Tblmanagertenderbid]  WITH CHECK ADD  CONSTRAINT [fk_Tblmanagertenderbid_ToTbleventmanager] FOREIGN KEY([Eventmanagerid])
REFERENCES [dbo].[Tbleventmanager] ([Eventmanagerid])
GO
ALTER TABLE [dbo].[Tblmanagertenderbid] CHECK CONSTRAINT [fk_Tblmanagertenderbid_ToTbleventmanager]
GO
ALTER TABLE [dbo].[Tblmanagertenderbid]  WITH CHECK ADD  CONSTRAINT [fk_Tblmanagertenderbid_ToTblmanagertender] FOREIGN KEY([Managertenderid])
REFERENCES [dbo].[Tblmanagertender] ([Managertenderid])
GO
ALTER TABLE [dbo].[Tblmanagertenderbid] CHECK CONSTRAINT [fk_Tblmanagertenderbid_ToTblmanagertender]
GO
ALTER TABLE [dbo].[Tblmanagertenderbidimages]  WITH CHECK ADD  CONSTRAINT [fk_Tblmanagertenderbidimages_ToTblmanagertenderbid] FOREIGN KEY([Managertenderbidid])
REFERENCES [dbo].[Tblmanagertenderbid] ([Managertenderbidid])
GO
ALTER TABLE [dbo].[Tblmanagertenderbidimages] CHECK CONSTRAINT [fk_Tblmanagertenderbidimages_ToTblmanagertenderbid]
GO
ALTER TABLE [dbo].[Tblnotification]  WITH CHECK ADD  CONSTRAINT [fk_Tblnotification_ToTbluser1] FOREIGN KEY([Fromuserid])
REFERENCES [dbo].[Tbluser] ([Userid])
GO
ALTER TABLE [dbo].[Tblnotification] CHECK CONSTRAINT [fk_Tblnotification_ToTbluser1]
GO
ALTER TABLE [dbo].[Tblnotification]  WITH CHECK ADD  CONSTRAINT [fk_Tblnotification_ToTbluser2] FOREIGN KEY([Touserid])
REFERENCES [dbo].[Tbluser] ([Userid])
GO
ALTER TABLE [dbo].[Tblnotification] CHECK CONSTRAINT [fk_Tblnotification_ToTbluser2]
GO
ALTER TABLE [dbo].[Tblpastwork]  WITH CHECK ADD  CONSTRAINT [fk_Tblpastwork_ToTbleventmanager] FOREIGN KEY([Eventmanagerid])
REFERENCES [dbo].[Tbleventmanager] ([Eventmanagerid])
GO
ALTER TABLE [dbo].[Tblpastwork] CHECK CONSTRAINT [fk_Tblpastwork_ToTbleventmanager]
GO
ALTER TABLE [dbo].[Tblpastwork]  WITH CHECK ADD  CONSTRAINT [fk_Tblpastwork_ToTblsubcategory] FOREIGN KEY([Subcategoryid])
REFERENCES [dbo].[Tblsubcategory] ([Subcategoryid])
GO
ALTER TABLE [dbo].[Tblpastwork] CHECK CONSTRAINT [fk_Tblpastwork_ToTblsubcategory]
GO
ALTER TABLE [dbo].[Tblpastworkimage]  WITH CHECK ADD  CONSTRAINT [fk_Tblpastworkimage_ToTblpastwork] FOREIGN KEY([Pastworkid])
REFERENCES [dbo].[Tblpastwork] ([Pastworkid])
GO
ALTER TABLE [dbo].[Tblpastworkimage] CHECK CONSTRAINT [fk_Tblpastworkimage_ToTblpastwork]
GO
ALTER TABLE [dbo].[Tblpastworklike]  WITH CHECK ADD  CONSTRAINT [fk_Tblpastworklike_ToTblclient] FOREIGN KEY([Clientid])
REFERENCES [dbo].[Tblclient] ([Clientid])
GO
ALTER TABLE [dbo].[Tblpastworklike] CHECK CONSTRAINT [fk_Tblpastworklike_ToTblclient]
GO
ALTER TABLE [dbo].[Tblpastworklike]  WITH CHECK ADD  CONSTRAINT [fk_Tblpastworklike_ToTblpastwork] FOREIGN KEY([Pastworkid])
REFERENCES [dbo].[Tblpastwork] ([Pastworkid])
GO
ALTER TABLE [dbo].[Tblpastworklike] CHECK CONSTRAINT [fk_Tblpastworklike_ToTblpastwork]
GO
ALTER TABLE [dbo].[Tblpastworkvideo]  WITH CHECK ADD  CONSTRAINT [fk_Tblpastworkvideo_ToTblpastwork] FOREIGN KEY([Pastworkid])
REFERENCES [dbo].[Tblpastwork] ([Pastworkid])
GO
ALTER TABLE [dbo].[Tblpastworkvideo] CHECK CONSTRAINT [fk_Tblpastworkvideo_ToTblpastwork]
GO
ALTER TABLE [dbo].[Tblreporteventmnager]  WITH CHECK ADD  CONSTRAINT [fk_Tblreporteventmnager_ToTblclient] FOREIGN KEY([Clientid])
REFERENCES [dbo].[Tblclient] ([Clientid])
GO
ALTER TABLE [dbo].[Tblreporteventmnager] CHECK CONSTRAINT [fk_Tblreporteventmnager_ToTblclient]
GO
ALTER TABLE [dbo].[Tblreporteventmnager]  WITH CHECK ADD  CONSTRAINT [fk_Tblreporteventmnager_ToTbleventmanager] FOREIGN KEY([Eventmanagerid])
REFERENCES [dbo].[Tbleventmanager] ([Eventmanagerid])
GO
ALTER TABLE [dbo].[Tblreporteventmnager] CHECK CONSTRAINT [fk_Tblreporteventmnager_ToTbleventmanager]
GO
ALTER TABLE [dbo].[Tblreportuser]  WITH CHECK ADD  CONSTRAINT [fk_Tblreportuser_ToTblclient] FOREIGN KEY([Clientid])
REFERENCES [dbo].[Tblclient] ([Clientid])
GO
ALTER TABLE [dbo].[Tblreportuser] CHECK CONSTRAINT [fk_Tblreportuser_ToTblclient]
GO
ALTER TABLE [dbo].[Tblreportuser]  WITH CHECK ADD  CONSTRAINT [fk_Tblreportuser_ToTbleventmanager] FOREIGN KEY([Eventmanagerid])
REFERENCES [dbo].[Tbleventmanager] ([Eventmanagerid])
GO
ALTER TABLE [dbo].[Tblreportuser] CHECK CONSTRAINT [fk_Tblreportuser_ToTbleventmanager]
GO
ALTER TABLE [dbo].[Tblreview]  WITH CHECK ADD  CONSTRAINT [fk_Tblreview_ToTblclient] FOREIGN KEY([Clientid])
REFERENCES [dbo].[Tblclient] ([Clientid])
GO
ALTER TABLE [dbo].[Tblreview] CHECK CONSTRAINT [fk_Tblreview_ToTblclient]
GO
ALTER TABLE [dbo].[Tblreview]  WITH CHECK ADD  CONSTRAINT [fk_Tblreview_ToTbleventmanager] FOREIGN KEY([Eventmanagerid])
REFERENCES [dbo].[Tbleventmanager] ([Eventmanagerid])
GO
ALTER TABLE [dbo].[Tblreview] CHECK CONSTRAINT [fk_Tblreview_ToTbleventmanager]
GO
ALTER TABLE [dbo].[Tblsubcategory]  WITH CHECK ADD  CONSTRAINT [FK_Tblsubcategory_ToTblCategory] FOREIGN KEY([Categoryid])
REFERENCES [dbo].[Tblcategory] ([Categoryid])
GO
ALTER TABLE [dbo].[Tblsubcategory] CHECK CONSTRAINT [FK_Tblsubcategory_ToTblCategory]
GO
ALTER TABLE [dbo].[Tbluser]  WITH CHECK ADD  CONSTRAINT [FK_Tbluser_Tblcity] FOREIGN KEY([Cityid])
REFERENCES [dbo].[Tblcity] ([Cityid])
GO
ALTER TABLE [dbo].[Tbluser] CHECK CONSTRAINT [FK_Tbluser_Tblcity]
GO
ALTER TABLE [dbo].[Tblusertender]  WITH CHECK ADD  CONSTRAINT [FK_Tblusertender_ToTblcity] FOREIGN KEY([Cityid])
REFERENCES [dbo].[Tblcity] ([Cityid])
GO
ALTER TABLE [dbo].[Tblusertender] CHECK CONSTRAINT [FK_Tblusertender_ToTblcity]
GO
ALTER TABLE [dbo].[Tblusertender]  WITH CHECK ADD  CONSTRAINT [FK_Tblusertender_ToTblclient] FOREIGN KEY([Clientid])
REFERENCES [dbo].[Tblclient] ([Clientid])
GO
ALTER TABLE [dbo].[Tblusertender] CHECK CONSTRAINT [FK_Tblusertender_ToTblclient]
GO
ALTER TABLE [dbo].[Tblusertender]  WITH CHECK ADD  CONSTRAINT [FK_Tblusertender_ToTblsubcategory] FOREIGN KEY([Subcategoryid])
REFERENCES [dbo].[Tblsubcategory] ([Subcategoryid])
GO
ALTER TABLE [dbo].[Tblusertender] CHECK CONSTRAINT [FK_Tblusertender_ToTblsubcategory]
GO
ALTER TABLE [dbo].[Tblusertenderbid]  WITH CHECK ADD  CONSTRAINT [FK_Tblusertenderbid_ToTbleventmanager] FOREIGN KEY([Eventmanagerid])
REFERENCES [dbo].[Tbleventmanager] ([Eventmanagerid])
GO
ALTER TABLE [dbo].[Tblusertenderbid] CHECK CONSTRAINT [FK_Tblusertenderbid_ToTbleventmanager]
GO
ALTER TABLE [dbo].[Tblusertenderbid]  WITH CHECK ADD  CONSTRAINT [FK_Tblusertenderbid_ToTblusertender] FOREIGN KEY([Usertenderid])
REFERENCES [dbo].[Tblusertender] ([Usertenderid])
GO
ALTER TABLE [dbo].[Tblusertenderbid] CHECK CONSTRAINT [FK_Tblusertenderbid_ToTblusertender]
GO
ALTER TABLE [dbo].[Tblusertenderbidimages]  WITH CHECK ADD  CONSTRAINT [FK_Tblusertenderbidimages_ToTblusertenderbid] FOREIGN KEY([Usertenderbidid])
REFERENCES [dbo].[Tblusertenderbid] ([Usertenderbidid])
GO
ALTER TABLE [dbo].[Tblusertenderbidimages] CHECK CONSTRAINT [FK_Tblusertenderbidimages_ToTblusertenderbid]
GO
USE [master]
GO
ALTER DATABASE [EventDB] SET  READ_WRITE 
GO
