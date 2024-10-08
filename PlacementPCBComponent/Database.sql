USE [master]
GO
/****** Object:  Database [SAPR]    Script Date: 29.05.2024 1:52:31 ******/
CREATE DATABASE [SAPR]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SAPR', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SAPR.mdf' , SIZE = 10485760KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SAPR_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SAPR_log.ldf' , SIZE = 5242880KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SAPR] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SAPR].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SAPR] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SAPR] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SAPR] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SAPR] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SAPR] SET ARITHABORT OFF 
GO
ALTER DATABASE [SAPR] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SAPR] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SAPR] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SAPR] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SAPR] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SAPR] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SAPR] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SAPR] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SAPR] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SAPR] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SAPR] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SAPR] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SAPR] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SAPR] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SAPR] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SAPR] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SAPR] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SAPR] SET RECOVERY FULL 
GO
ALTER DATABASE [SAPR] SET  MULTI_USER 
GO
ALTER DATABASE [SAPR] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SAPR] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SAPR] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SAPR] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SAPR] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SAPR] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SAPR', N'ON'
GO
ALTER DATABASE [SAPR] SET QUERY_STORE = ON
GO
ALTER DATABASE [SAPR] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SAPR]
GO
/****** Object:  Table [dbo].[Areas_of_PCB]    Script Date: 29.05.2024 1:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas_of_PCB](
	[Area_ID] [nvarchar](10) NOT NULL,
	[Project_ID] [nvarchar](10) NOT NULL,
	[Length] [decimal](5, 1) NULL,
	[Width] [decimal](5, 1) NULL,
	[Coordinate_X] [decimal](10, 2) NULL,
	[Coordinate_Y] [decimal](10, 2) NULL,
 CONSTRAINT [PK__Areas_of__4256772E5DED8C8D] PRIMARY KEY CLUSTERED 
(
	[Area_ID] ASC,
	[Project_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Component]    Script Date: 29.05.2024 1:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Component](
	[Component_Marking] [nvarchar](30) NOT NULL,
	[Component_Name] [nvarchar](50) NULL,
	[Footprint_ID] [nvarchar](30) NULL,
	[Dissipation_Power] [decimal](10, 2) NULL,
 CONSTRAINT [PK__Componen__FD720B2354C4E258] PRIMARY KEY CLUSTERED 
(
	[Component_Marking] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Footprint]    Script Date: 29.05.2024 1:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footprint](
	[Footprint_ID] [nvarchar](30) NOT NULL,
	[Length] [decimal](5, 1) NULL,
	[Width] [decimal](5, 1) NULL,
 CONSTRAINT [PK__Footprin__16E6CC73C788A7B6] PRIMARY KEY CLUSTERED 
(
	[Footprint_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PCB]    Script Date: 29.05.2024 1:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PCB](
	[PCB_Marking] [nvarchar](10) NOT NULL,
	[Length] [decimal](5, 1) NULL,
	[Width] [decimal](5, 1) NULL,
PRIMARY KEY CLUSTERED 
(
	[PCB_Marking] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pins]    Script Date: 29.05.2024 1:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pins](
	[Pin_ID] [int] NOT NULL,
	[Component_Marking] [nvarchar](30) NOT NULL,
	[Coordinate_X] [decimal](10, 2) NULL,
	[Coordinate_Y] [decimal](10, 2) NULL,
 CONSTRAINT [PK__Pins__D5B4E16407FB8DEB] PRIMARY KEY CLUSTERED 
(
	[Pin_ID] ASC,
	[Component_Marking] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Placement_of_components]    Script Date: 29.05.2024 1:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Placement_of_components](
	[Positional_Designation] [nvarchar](10) NOT NULL,
	[Project_ID] [nvarchar](10) NOT NULL,
	[Area_ID] [nvarchar](10) NOT NULL,
	[Coordinate_X] [decimal](10, 2) NULL,
	[Coordinate_Y] [decimal](10, 2) NULL,
	[Orientation] [int] NULL,
 CONSTRAINT [PK__Placemen__7D80DA0A2BC12A5B] PRIMARY KEY CLUSTERED 
(
	[Positional_Designation] ASC,
	[Project_ID] ASC,
	[Area_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Placement_of_prohibited_areas]    Script Date: 29.05.2024 1:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Placement_of_prohibited_areas](
	[Prohibited_Area_ID] [nvarchar](10) NOT NULL,
	[PCB_Marking] [nvarchar](10) NOT NULL,
	[Length] [decimal](5, 1) NULL,
	[Width] [decimal](5, 1) NULL,
	[Coordinate_X] [decimal](10, 2) NULL,
	[Coordinate_Y] [decimal](10, 2) NULL,
 CONSTRAINT [PK_Placement_of_prohibited_areas] PRIMARY KEY CLUSTERED 
(
	[Prohibited_Area_ID] ASC,
	[PCB_Marking] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 29.05.2024 1:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Project_ID] [nvarchar](10) NOT NULL,
	[ProjectName] [nvarchar](50) NULL,
	[Scheme_ID] [nvarchar](10) NULL,
	[PCB_Marking] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Project_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scheme]    Script Date: 29.05.2024 1:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scheme](
	[Scheme_ID] [nvarchar](10) NOT NULL,
	[Positional_Designation] [nvarchar](10) NOT NULL,
	[Component_Marking] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Scheme_1] PRIMARY KEY CLUSTERED 
(
	[Scheme_ID] ASC,
	[Positional_Designation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schemes]    Script Date: 29.05.2024 1:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schemes](
	[Scheme_ID] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Scheme_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wire]    Script Date: 29.05.2024 1:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wire](
	[Wire_ID] [nvarchar](10) NOT NULL,
	[Scheme_ID] [nvarchar](10) NOT NULL,
	[Component_Marking] [nvarchar](30) NOT NULL,
	[Pin_ID] [int] NOT NULL,
 CONSTRAINT [PK__Wire__53095F72BB193C39] PRIMARY KEY CLUSTERED 
(
	[Wire_ID] ASC,
	[Scheme_ID] ASC,
	[Component_Marking] ASC,
	[Pin_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Areas_of_PCB] ADD  CONSTRAINT [DF__Areas_of___Coord__5FB337D6]  DEFAULT ((0)) FOR [Coordinate_X]
GO
ALTER TABLE [dbo].[Areas_of_PCB] ADD  CONSTRAINT [DF__Areas_of___Coord__60A75C0F]  DEFAULT ((0)) FOR [Coordinate_Y]
GO
ALTER TABLE [dbo].[Pins] ADD  CONSTRAINT [DF__Pins__Coordinate__3E52440B]  DEFAULT ((0)) FOR [Coordinate_X]
GO
ALTER TABLE [dbo].[Pins] ADD  CONSTRAINT [DF__Pins__Coordinate__3F466844]  DEFAULT ((0)) FOR [Coordinate_Y]
GO
ALTER TABLE [dbo].[Placement_of_components] ADD  CONSTRAINT [DF__Placement__Coord__66603565]  DEFAULT ((0)) FOR [Coordinate_X]
GO
ALTER TABLE [dbo].[Placement_of_components] ADD  CONSTRAINT [DF__Placement__Coord__6754599E]  DEFAULT ((0)) FOR [Coordinate_Y]
GO
ALTER TABLE [dbo].[Placement_of_components] ADD  CONSTRAINT [DF__Placement__Orien__68487DD7]  DEFAULT ((0)) FOR [Orientation]
GO
ALTER TABLE [dbo].[Placement_of_prohibited_areas] ADD  CONSTRAINT [DF__Placement__Coord__3587F3E0]  DEFAULT ((0)) FOR [Coordinate_X]
GO
ALTER TABLE [dbo].[Placement_of_prohibited_areas] ADD  CONSTRAINT [DF__Placement__Coord__367C1819]  DEFAULT ((0)) FOR [Coordinate_Y]
GO
ALTER TABLE [dbo].[Areas_of_PCB]  WITH CHECK ADD  CONSTRAINT [FK__Areas_of___Proje__5EBF139D] FOREIGN KEY([Project_ID])
REFERENCES [dbo].[Project] ([Project_ID])
GO
ALTER TABLE [dbo].[Areas_of_PCB] CHECK CONSTRAINT [FK__Areas_of___Proje__5EBF139D]
GO
ALTER TABLE [dbo].[Component]  WITH CHECK ADD  CONSTRAINT [FK__Component__Footp__3A81B327] FOREIGN KEY([Footprint_ID])
REFERENCES [dbo].[Footprint] ([Footprint_ID])
GO
ALTER TABLE [dbo].[Component] CHECK CONSTRAINT [FK__Component__Footp__3A81B327]
GO
ALTER TABLE [dbo].[Pins]  WITH CHECK ADD  CONSTRAINT [FK__Pins__Component___3D5E1FD2] FOREIGN KEY([Component_Marking])
REFERENCES [dbo].[Component] ([Component_Marking])
GO
ALTER TABLE [dbo].[Pins] CHECK CONSTRAINT [FK__Pins__Component___3D5E1FD2]
GO
ALTER TABLE [dbo].[Placement_of_components]  WITH CHECK ADD  CONSTRAINT [FK__Placement__Proje__6477ECF3] FOREIGN KEY([Project_ID])
REFERENCES [dbo].[Project] ([Project_ID])
GO
ALTER TABLE [dbo].[Placement_of_components] CHECK CONSTRAINT [FK__Placement__Proje__6477ECF3]
GO
ALTER TABLE [dbo].[Placement_of_components]  WITH CHECK ADD  CONSTRAINT [FK_Placement_of_components_Areas_of_PCB] FOREIGN KEY([Area_ID], [Project_ID])
REFERENCES [dbo].[Areas_of_PCB] ([Area_ID], [Project_ID])
GO
ALTER TABLE [dbo].[Placement_of_components] CHECK CONSTRAINT [FK_Placement_of_components_Areas_of_PCB]
GO
ALTER TABLE [dbo].[Placement_of_prohibited_areas]  WITH CHECK ADD  CONSTRAINT [FK_Placement_of_prohibited_areas_PCB] FOREIGN KEY([PCB_Marking])
REFERENCES [dbo].[PCB] ([PCB_Marking])
GO
ALTER TABLE [dbo].[Placement_of_prohibited_areas] CHECK CONSTRAINT [FK_Placement_of_prohibited_areas_PCB]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD FOREIGN KEY([PCB_Marking])
REFERENCES [dbo].[PCB] ([PCB_Marking])
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Schemes] FOREIGN KEY([Scheme_ID])
REFERENCES [dbo].[Schemes] ([Scheme_ID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Schemes]
GO
ALTER TABLE [dbo].[Scheme]  WITH CHECK ADD  CONSTRAINT [FK__Scheme__Componen__5070F446] FOREIGN KEY([Component_Marking])
REFERENCES [dbo].[Component] ([Component_Marking])
GO
ALTER TABLE [dbo].[Scheme] CHECK CONSTRAINT [FK__Scheme__Componen__5070F446]
GO
ALTER TABLE [dbo].[Scheme]  WITH CHECK ADD  CONSTRAINT [FK_Scheme_Schemes] FOREIGN KEY([Scheme_ID])
REFERENCES [dbo].[Schemes] ([Scheme_ID])
GO
ALTER TABLE [dbo].[Scheme] CHECK CONSTRAINT [FK_Scheme_Schemes]
GO
ALTER TABLE [dbo].[Wire]  WITH CHECK ADD  CONSTRAINT [FK_Wire_Pins] FOREIGN KEY([Pin_ID], [Component_Marking])
REFERENCES [dbo].[Pins] ([Pin_ID], [Component_Marking])
GO
ALTER TABLE [dbo].[Wire] CHECK CONSTRAINT [FK_Wire_Pins]
GO
ALTER TABLE [dbo].[Wire]  WITH CHECK ADD  CONSTRAINT [FK_Wire_Schemes] FOREIGN KEY([Scheme_ID])
REFERENCES [dbo].[Schemes] ([Scheme_ID])
GO
ALTER TABLE [dbo].[Wire] CHECK CONSTRAINT [FK_Wire_Schemes]
GO
ALTER TABLE [dbo].[Areas_of_PCB]  WITH CHECK ADD  CONSTRAINT [CK__Areas_of_PCB__619B8048] CHECK  (([Length]<>(0) AND [Width]<>(0)))
GO
ALTER TABLE [dbo].[Areas_of_PCB] CHECK CONSTRAINT [CK__Areas_of_PCB__619B8048]
GO
ALTER TABLE [dbo].[Footprint]  WITH CHECK ADD  CONSTRAINT [CK__Footprint__37A5467C] CHECK  (([Length]<>(0) AND [Width]<>(0)))
GO
ALTER TABLE [dbo].[Footprint] CHECK CONSTRAINT [CK__Footprint__37A5467C]
GO
ALTER TABLE [dbo].[PCB]  WITH CHECK ADD CHECK  (([Length]<>(0) AND [Width]<>(0)))
GO
ALTER TABLE [dbo].[Placement_of_components]  WITH CHECK ADD  CONSTRAINT [CK__Placement__Orien__693CA210] CHECK  (([Orientation]>=(0) AND [Orientation]<=(360)))
GO
ALTER TABLE [dbo].[Placement_of_components] CHECK CONSTRAINT [CK__Placement__Orien__693CA210]
GO
ALTER TABLE [dbo].[Placement_of_prohibited_areas]  WITH CHECK ADD  CONSTRAINT [CK__Placement_of_pro__37703C52] CHECK  (([Length]<>(0) AND [Width]<>(0)))
GO
ALTER TABLE [dbo].[Placement_of_prohibited_areas] CHECK CONSTRAINT [CK__Placement_of_pro__37703C52]
GO
USE [master]
GO
ALTER DATABASE [SAPR] SET  READ_WRITE 
GO
