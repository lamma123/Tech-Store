USE [master]
GO
/****** Object:  Database [SWP391]    Script Date: 16/10/2023 14:20:43 ******/
CREATE DATABASE [SWP391]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SWP391', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SWP391.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SWP391_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SWP391_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SWP391] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SWP391].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SWP391] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SWP391] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SWP391] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SWP391] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SWP391] SET ARITHABORT OFF 
GO
ALTER DATABASE [SWP391] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SWP391] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SWP391] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SWP391] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SWP391] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SWP391] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SWP391] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SWP391] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SWP391] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SWP391] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SWP391] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SWP391] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SWP391] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SWP391] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SWP391] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SWP391] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SWP391] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SWP391] SET RECOVERY FULL 
GO
ALTER DATABASE [SWP391] SET  MULTI_USER 
GO
ALTER DATABASE [SWP391] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SWP391] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SWP391] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SWP391] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SWP391] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SWP391] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SWP391', N'ON'
GO
ALTER DATABASE [SWP391] SET QUERY_STORE = OFF
GO
USE [SWP391]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 16/10/2023 14:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[EmployeeID] [int] NULL,
	[ShipperID] [int] NULL,
	[CustomerID] [nchar](5) NULL,
	[Role] [int] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 16/10/2023 14:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 16/10/2023 14:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [nchar](5) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Region] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Emloyees]    Script Date: 16/10/2023 14:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emloyees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](50) NULL,
	[BirthDate] [datetime] NULL,
	[Address] [nvarchar](100) NULL,
	[City] [nvarchar](50) NULL,
	[Region] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Notes] [nvarchar](200) NULL,
 CONSTRAINT [PK_Emloyees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 16/10/2023 14:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Voucher] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 16/10/2023 14:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [nchar](5) NULL,
	[EmployeeID] [int] NULL,
	[ShipperID] [int] NULL,
	[OrderDate] [datetime] NULL,
	[AcceptedDate] [datetime] NULL,
	[DeliveryDateFrom] [datetime] NULL,
	[DeliveryDateTo] [datetime] NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Region] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[Note] [nvarchar](150) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 16/10/2023 14:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[PostID] [int] IDENTITY(1,1) NOT NULL,
	[PostTitle] [nvarchar](50) NULL,
	[PostContent] [nvarchar](200) NULL,
	[EmployeeID] [int] NULL,
	[PublishedDate] [datetime] NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 16/10/2023 14:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[CategoryID] [int] NULL,
	[UnitPrice] [money] NULL,
	[UnitInStock] [int] NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shippers]    Script Date: 16/10/2023 14:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shippers](
	[ShipperID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[BirthDate] [datetime] NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Region] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Notes] [nvarchar](50) NULL,
 CONSTRAINT [PK_Shippers] PRIMARY KEY CLUSTERED 
(
	[ShipperID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vouchers]    Script Date: 16/10/2023 14:20:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vouchers](
	[VoucherID] [int] IDENTITY(1,1) NOT NULL,
	[VoucherCode] [nchar](10) NULL,
	[Discount] [real] NULL,
	[ExpDateFrom] [datetime] NULL,
	[ExpDateTo] [datetime] NULL,
 CONSTRAINT [PK_Vouchers] PRIMARY KEY CLUSTERED 
(
	[VoucherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 
GO
INSERT [dbo].[Accounts] ([AccountID], [Email], [Password], [EmployeeID], [ShipperID], [CustomerID], [Role]) VALUES (1, N'customer@gmail.com', N'123', NULL, NULL, N'ALFKI', 1)
GO
INSERT [dbo].[Accounts] ([AccountID], [Email], [Password], [EmployeeID], [ShipperID], [CustomerID], [Role]) VALUES (2, N'marketing@gmail.com', N'123', 1, NULL, NULL, 2)
GO
INSERT [dbo].[Accounts] ([AccountID], [Email], [Password], [EmployeeID], [ShipperID], [CustomerID], [Role]) VALUES (3, N'seller@gmail.com', N'123', 2, NULL, NULL, 3)
GO
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description]) VALUES (1, N'Laptop', NULL)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description]) VALUES (2, N'Tablet', NULL)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description]) VALUES (3, N'Smartphone', NULL)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [Region], [Country], [Phone]) VALUES (N'ALFKI', N'Maria Anders', N'Obere Str. 57', N'Berlin', NULL, N'Germany', N'030-00743212')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [Region], [Country], [Phone]) VALUES (N'ANATR', N'Hanna Moos', N'Avda. de la Constitución 2222', N'México D.F.', NULL, N'Mexico', N'(5) 555-4729')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [Region], [Country], [Phone]) VALUES (N'ANTON', N'Thomas Hardy', N'Mataderos  2312', N'México D.F.', NULL, N'Mexico', N'(5) 555-3932')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [Region], [Country], [Phone]) VALUES (N'AROUT', N'Christina Berglund', N'120 Hanover Sq.', N'London', NULL, N'UK', N'(171) 555-7788')
GO
INSERT [dbo].[Customers] ([CustomerID], [Name], [Address], [City], [Region], [Country], [Phone]) VALUES (N'ASGVK', N'Laurence Lebihan', N'Forsterstr. 57', N'Madrid', NULL, N'Spain', N'0921-12 34 65')
GO
SET IDENTITY_INSERT [dbo].[Emloyees] ON 
GO
INSERT [dbo].[Emloyees] ([EmployeeID], [EmployeeName], [BirthDate], [Address], [City], [Region], [Country], [Phone], [Notes]) VALUES (1, N'Fuller', CAST(N'1966-01-27T00:00:00.000' AS DateTime), N'908 W. Capital Way', N'Tacoma', NULL, N'USA', N'(206) 555-9482', NULL)
GO
INSERT [dbo].[Emloyees] ([EmployeeID], [EmployeeName], [BirthDate], [Address], [City], [Region], [Country], [Phone], [Notes]) VALUES (2, N'Leverling', CAST(N'1955-03-04T00:00:00.000' AS DateTime), N'722 Moss Bay Blvd.', N'Tacoma', NULL, N'USA', N'(206) 555-3412', NULL)
GO
INSERT [dbo].[Emloyees] ([EmployeeID], [EmployeeName], [BirthDate], [Address], [City], [Region], [Country], [Phone], [Notes]) VALUES (3, N'Peacock', CAST(N'1955-03-04T00:00:00.000' AS DateTime), N'4110 Old Redmond Rd.', N'Tacoma', NULL, N'USA', N'(206) 555-8122', NULL)
GO
INSERT [dbo].[Emloyees] ([EmployeeID], [EmployeeName], [BirthDate], [Address], [City], [Region], [Country], [Phone], [Notes]) VALUES (4, N'Buchanan', CAST(N'1963-07-02T00:00:00.000' AS DateTime), N'14 Garrett Hill', N'Tacoma', NULL, N'USA', N'(71) 555-4848', NULL)
GO
INSERT [dbo].[Emloyees] ([EmployeeID], [EmployeeName], [BirthDate], [Address], [City], [Region], [Country], [Phone], [Notes]) VALUES (5, N'Suyama', CAST(N'1963-07-02T00:00:00.000' AS DateTime), N'Coventry House
Miner Rd.', N'Tacoma', NULL, N'USA', N'(71) 555-7773', NULL)
GO
INSERT [dbo].[Emloyees] ([EmployeeID], [EmployeeName], [BirthDate], [Address], [City], [Region], [Country], [Phone], [Notes]) VALUES (6, N'King', CAST(N'1963-07-02T00:00:00.000' AS DateTime), N'Edgeham Hollow
Winchester Way', N'Tacoma', NULL, N'UK', N'(71) 555-5598', NULL)
GO
INSERT [dbo].[Emloyees] ([EmployeeID], [EmployeeName], [BirthDate], [Address], [City], [Region], [Country], [Phone], [Notes]) VALUES (7, N'Callahan', CAST(N'1963-07-02T00:00:00.000' AS DateTime), N'4726 - 11th Ave. N.E.', N'Tacoma', NULL, N'UK', N'(206) 555-1189', NULL)
GO
INSERT [dbo].[Emloyees] ([EmployeeID], [EmployeeName], [BirthDate], [Address], [City], [Region], [Country], [Phone], [Notes]) VALUES (9, NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Emloyees] OFF
GO
INSERT [dbo].[OrderDetails] ([OrderID], [ProductID], [UnitPrice], [Quantity], [Voucher]) VALUES (2, 3, 12.0000, 12, 1)
GO
INSERT [dbo].[OrderDetails] ([OrderID], [ProductID], [UnitPrice], [Quantity], [Voucher]) VALUES (2, 4, 130000.0000, 2, 1)
GO
INSERT [dbo].[OrderDetails] ([OrderID], [ProductID], [UnitPrice], [Quantity], [Voucher]) VALUES (2, 5, 12333.0000, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (2, N'ALFKI', 3, 1, CAST(N'2023-10-10T00:00:00.000' AS DateTime), CAST(N'2023-10-10T00:00:00.000' AS DateTime), NULL, NULL, N'Hanoi', N'Hanoi', N'Ha noi', N'VietNam', 2, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (3, N'ANTON', 2, 1, CAST(N'2023-10-10T00:00:00.000' AS DateTime), CAST(N'2023-10-10T00:00:00.000' AS DateTime), NULL, NULL, N'Hanoi', N'Hanoi', N'Hanoi', N'VietNam', 2, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (4, N'ASGVK', 1, 2, CAST(N'2023-10-10T00:00:00.000' AS DateTime), CAST(N'2023-10-10T00:00:00.000' AS DateTime), NULL, NULL, N'Hanoi', N'Hanoi', N'Hanoi', N'VietNam', 1, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (5, N'AROUT', 1, 2, CAST(N'2023-10-10T00:00:00.000' AS DateTime), CAST(N'2023-10-10T00:00:00.000' AS DateTime), NULL, NULL, N'VinhVinh', N'Vinh', N'Vinh', N'Vinh', 2, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (6, N'ASGVK', 1, 1, CAST(N'2023-10-01T00:00:00.000' AS DateTime), CAST(N'2023-10-10T00:00:00.000' AS DateTime), NULL, NULL, N'Saigon', N'Saigon', N'Saigon', N'VietNam', 2, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (7, N'ANATR', 2, 2, CAST(N'2023-10-03T00:00:00.000' AS DateTime), CAST(N'2023-10-03T00:00:00.000' AS DateTime), NULL, NULL, N'Saigon', N'Saigon', N'Saigon', N'VietNam', 2, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (8, N'ANATR', 3, 3, CAST(N'2023-10-03T00:00:00.000' AS DateTime), CAST(N'2023-10-03T00:00:00.000' AS DateTime), NULL, NULL, N'Saigon', N'Saigon', N'Saigon', N'VietNam', 2, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (9, N'ASGVK', 2, 3, CAST(N'2023-10-03T00:00:00.000' AS DateTime), CAST(N'2023-10-03T00:00:00.000' AS DateTime), NULL, NULL, N'Saigon', N'Saigon', N'Saigon', N'VietNam', 2, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (10, N'AROUT', 2, 3, CAST(N'2023-10-03T00:00:00.000' AS DateTime), CAST(N'2023-10-03T00:00:00.000' AS DateTime), NULL, NULL, N'Saigon', N'Saigon', N'Saigon', N'VietNam', 2, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (14, N'AROUT', 3, 3, CAST(N'2023-10-03T00:00:00.000' AS DateTime), CAST(N'2023-10-03T00:00:00.000' AS DateTime), NULL, NULL, N'Saigon', N'Saigon', N'Saigon', N'VietNam', 2, N'123')
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (15, N'AROUT', 3, 4, CAST(N'2023-10-13T00:00:00.000' AS DateTime), CAST(N'2023-10-13T00:00:00.000' AS DateTime), CAST(N'2023-10-16T14:16:32.123' AS DateTime), NULL, N'Saigon', N'Saigon', N'Saigon', N'VietNam', 3, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (16, N'AROUT', 3, 1, CAST(N'2023-10-13T00:00:00.000' AS DateTime), CAST(N'2023-10-13T00:00:00.000' AS DateTime), NULL, NULL, N'Hanoi', N'Hanoi', N'Hanoi', N'VietNam', 2, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (17, N'AROUT', 2, 3, CAST(N'2023-10-13T00:00:00.000' AS DateTime), CAST(N'2023-10-13T00:00:00.000' AS DateTime), NULL, NULL, N'Hanoi', N'Hanoi', N'Hanoi', N'VietNam', 2, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (19, N'AROUT', 2, 2, CAST(N'2023-10-13T00:00:00.000' AS DateTime), CAST(N'2023-10-13T00:00:00.000' AS DateTime), NULL, NULL, N'Hanoi', N'Hanoi', N'Hanoi', N'VietNam', 2, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (20, N'ASGVK', 1, 1, CAST(N'2023-10-13T00:00:00.000' AS DateTime), CAST(N'2023-10-13T00:00:00.000' AS DateTime), NULL, NULL, N'DaNang', N'DaNang', N'DaNang', N'VietNam', 2, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (21, N'ASGVK', 1, 2, CAST(N'2023-10-13T00:00:00.000' AS DateTime), CAST(N'2023-10-13T00:00:00.000' AS DateTime), NULL, NULL, N'DaNang', N'DaNang', N'DaNang', N'VietNam', 2, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (22, N'ASGVK', 1, 1, CAST(N'2023-10-13T00:00:00.000' AS DateTime), CAST(N'2023-10-13T00:00:00.000' AS DateTime), NULL, NULL, N'DaNang', N'DaNang', N'DaNang', N'VietNam', 2, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [EmployeeID], [ShipperID], [OrderDate], [AcceptedDate], [DeliveryDateFrom], [DeliveryDateTo], [Address], [City], [Region], [Country], [Status], [Note]) VALUES (23, N'ASGVK', 2, NULL, CAST(N'2023-10-13T00:00:00.000' AS DateTime), CAST(N'2023-10-13T00:00:00.000' AS DateTime), NULL, NULL, N'DaNang', N'DaNang', N'DaNang', N'VietNam', 2, N'tuy tam')
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitInStock], [Description]) VALUES (1, N'Asus VivoBook', 1, 50000.0000, 10, NULL)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitInStock], [Description]) VALUES (2, N'HP 245', 1, 70000.0000, 10, NULL)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitInStock], [Description]) VALUES (3, N'Lenovo IdeaPad 3', 1, 10000.0000, 20, NULL)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitInStock], [Description]) VALUES (4, N'Samsung Galaxy Tab S6', 2, 30000.0000, 15, NULL)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitInStock], [Description]) VALUES (5, N'CoolPad Tab Tasker 10', 2, 35000.0000, 12, NULL)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitInStock], [Description]) VALUES (6, N'Masstel Tab 10M', 2, 23000.0000, 21, NULL)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitInStock], [Description]) VALUES (7, N'Iphone 15 Promax', 3, 150000.0000, 23, NULL)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitInStock], [Description]) VALUES (8, N'Samsung Galaxy S22', 3, 230000.0000, 16, NULL)
GO
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitInStock], [Description]) VALUES (9, N'Oppo Reno 8 ', 3, 210000.0000, 14, NULL)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Shippers] ON 
GO
INSERT [dbo].[Shippers] ([ShipperID], [Name], [BirthDate], [Address], [City], [Region], [Country], [Phone], [Notes]) VALUES (1, N'Philip Cramer', CAST(N'1996-10-09T00:00:00.000' AS DateTime), N'C/ Romero, 33', N'Sevilla', NULL, N'Spain', N'41101', NULL)
GO
INSERT [dbo].[Shippers] ([ShipperID], [Name], [BirthDate], [Address], [City], [Region], [Country], [Phone], [Notes]) VALUES (2, N'Daniel Tonini', CAST(N'1996-11-08T00:00:00.000' AS DateTime), N'Åkergatan 24', N'Bräcke', NULL, N'Sweden', N'80805', NULL)
GO
INSERT [dbo].[Shippers] ([ShipperID], [Name], [BirthDate], [Address], [City], [Region], [Country], [Phone], [Notes]) VALUES (3, N'Annette Roulet', CAST(N'1996-11-21T00:00:00.000' AS DateTime), N'Berliner Platz 43', N'München', NULL, N'Germany', N'05442-030', NULL)
GO
INSERT [dbo].[Shippers] ([ShipperID], [Name], [BirthDate], [Address], [City], [Region], [Country], [Phone], [Notes]) VALUES (4, N'Yoshi Tannamuri', CAST(N'1996-11-13T00:00:00.000' AS DateTime), N'Berliner Platz 43', N'München', NULL, N'Germany', N'8022', NULL)
GO
SET IDENTITY_INSERT [dbo].[Shippers] OFF
GO
SET IDENTITY_INSERT [dbo].[Vouchers] ON 
GO
INSERT [dbo].[Vouchers] ([VoucherID], [VoucherCode], [Discount], [ExpDateFrom], [ExpDateTo]) VALUES (1, N'SE12332   ', 10, CAST(N'2021-10-10T00:00:00.000' AS DateTime), CAST(N'2024-10-10T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Vouchers] OFF
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Customers]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Emloyees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Emloyees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Emloyees]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Shippers] FOREIGN KEY([ShipperID])
REFERENCES [dbo].[Shippers] ([ShipperID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Shippers]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Vouchers] FOREIGN KEY([Voucher])
REFERENCES [dbo].[Vouchers] ([VoucherID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Vouchers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Emloyees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Emloyees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Emloyees]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Shippers] FOREIGN KEY([ShipperID])
REFERENCES [dbo].[Shippers] ([ShipperID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Shippers]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Emloyees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Emloyees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Emloyees]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
USE [master]
GO
ALTER DATABASE [SWP391] SET  READ_WRITE 
GO
