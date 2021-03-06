USE [master]
GO
/****** Object:  Database [POSDBMS]    Script Date: 11/08/2021 18:19:06 ******/
CREATE DATABASE [POSDBMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'POSDBMS', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\POSDBMS.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'POSDBMS_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\POSDBMS_log.ldf' , SIZE = 4224KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [POSDBMS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [POSDBMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [POSDBMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [POSDBMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [POSDBMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [POSDBMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [POSDBMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [POSDBMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [POSDBMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [POSDBMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [POSDBMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [POSDBMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [POSDBMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [POSDBMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [POSDBMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [POSDBMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [POSDBMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [POSDBMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [POSDBMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [POSDBMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [POSDBMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [POSDBMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [POSDBMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [POSDBMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [POSDBMS] SET RECOVERY FULL 
GO
ALTER DATABASE [POSDBMS] SET  MULTI_USER 
GO
ALTER DATABASE [POSDBMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [POSDBMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [POSDBMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [POSDBMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [POSDBMS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'POSDBMS', N'ON'
GO
USE [POSDBMS]
GO
/****** Object:  User [basharali]    Script Date: 11/08/2021 18:19:06 ******/
CREATE USER [basharali] FOR LOGIN [basharali] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [basharali]
GO
ALTER ROLE [db_datareader] ADD MEMBER [basharali]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [basharali]
GO
/****** Object:  Table [dbo].[tbl_Customer]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Customer](
	[Cu_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address1] [nvarchar](max) NULL,
	[Address2] [nvarchar](max) NULL,
	[phone1] [nvarchar](max) NULL,
	[phone2] [nvarchar](max) NULL,
	[fax] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[website] [nvarchar](max) NULL,
	[licence] [nvarchar](max) NULL,
	[remark] [nvarchar](max) NULL,
	[status] [bit] NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_tbl_Customer] PRIMARY KEY CLUSTERED 
(
	[Cu_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Customer_CashRecord]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Customer_CashRecord](
	[Cash_ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[user_id] [int] NULL,
	[Credit] [money] NULL,
	[Debit] [money] NULL,
 CONSTRAINT [PK_tbl_Customer_CashRecord] PRIMARY KEY CLUSTERED 
(
	[Cash_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Designation]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Designation](
	[DSIG_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[user_id] [int] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_tbl_Designation] PRIMARY KEY CLUSTERED 
(
	[DSIG_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Employee]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Employee](
	[EMP_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address1] [nvarchar](max) NULL,
	[Address2] [nvarchar](max) NULL,
	[phone1] [nvarchar](max) NULL,
	[phone2] [nvarchar](max) NULL,
	[NICNO] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[DSIG_ID] [int] NULL,
	[BasicSalary] [money] NULL,
	[remark] [nvarchar](max) NULL,
	[status] [bit] NULL,
	[user_id] [int] NULL,
	[AddDate] [date] NULL,
 CONSTRAINT [PK_tbl_Employee] PRIMARY KEY CLUSTERED 
(
	[EMP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_EmployeeAccount]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_EmployeeAccount](
	[EMP_AC_ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Time] [time](7) NULL,
	[Salary] [money] NULL,
	[Deduction] [money] NULL,
	[EMP_ID] [int] NULL,
	[user_id] [int] NULL,
	[Remarks] [nvarchar](max) NULL,
	[Allownce] [money] NULL,
	[AllowRemark] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_EmployeeAccount_1] PRIMARY KEY CLUSTERED 
(
	[EMP_AC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_ExpenseInvoice]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ExpenseInvoice](
	[EXPINVOICE_ID] [int] IDENTITY(1,1) NOT NULL,
	[EXPMENU_ID] [int] NULL,
	[Price] [money] NULL,
	[Remark] [nvarchar](max) NULL,
	[EXP_ID] [int] NULL,
 CONSTRAINT [PK_tbl_ExpenseInvoice] PRIMARY KEY CLUSTERED 
(
	[EXPINVOICE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_ExpenseMenu]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ExpenseMenu](
	[EXPMENU_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[user_id] [int] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_tbl_ExpenseMenu] PRIMARY KEY CLUSTERED 
(
	[EXPMENU_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_ExpenseOrder]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ExpenseOrder](
	[EXP_ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_tbl_Expense] PRIMARY KEY CLUSTERED 
(
	[EXP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Item]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Item](
	[item_id] [int] IDENTITY(1,1) NOT NULL,
	[item_name] [nvarchar](max) NULL,
	[item_tp] [money] NULL,
	[item_costprice] [money] NULL,
	[item_retail] [money] NULL,
	[item_stock] [int] NULL,
	[item_packing] [int] NULL,
	[item_ministock] [int] NULL,
	[item_state] [bit] NULL,
	[user_id] [int] NULL,
	[item_stockout] [int] NULL,
 CONSTRAINT [PK_tbl_Item] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Loan]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Loan](
	[Lo_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address1] [nvarchar](max) NULL,
	[Address2] [nvarchar](max) NULL,
	[phone1] [nvarchar](max) NULL,
	[phone2] [nvarchar](max) NULL,
	[fax] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[website] [nvarchar](max) NULL,
	[licence] [nvarchar](max) NULL,
	[remark] [nvarchar](max) NULL,
	[status] [bit] NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_tbl_Loan] PRIMARY KEY CLUSTERED 
(
	[Lo_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Loan_CashRecord]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Loan_CashRecord](
	[Cash_ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[user_id] [int] NULL,
	[Credit] [money] NULL,
	[Debit] [money] NULL,
 CONSTRAINT [PK_tbl_Loan_CashRecord] PRIMARY KEY CLUSTERED 
(
	[Cash_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_PurchaseAccount]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_PurchaseAccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Time] [time](7) NULL,
	[Type] [varchar](max) NULL,
	[Credit] [money] NULL,
	[Debit] [money] NULL,
	[purchase_order_id] [int] NULL,
	[Purchase_ret_ID] [int] NULL,
	[cash_id] [int] NULL,
	[sup_id] [int] NULL,
	[user_id] [int] NULL,
	[Balance] [money] NULL,
 CONSTRAINT [PK_tbl_PurchaseAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_PurchaseInvoice]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PurchaseInvoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Item_id] [int] NULL,
	[Bonus] [int] NULL,
	[Qty] [int] NULL,
	[Disc] [int] NULL,
	[Price] [money] NULL,
	[purchase_order_id] [int] NULL,
 CONSTRAINT [PK_tbl_PurchaseInvoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_PurchaseOrder]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_PurchaseOrder](
	[purchase_order_id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [time](7) NULL,
	[Sup_ID] [int] NULL,
	[user_id] [int] NULL,
	[Dis] [money] NULL,
	[Date] [date] NULL,
	[Type] [varchar](max) NULL,
	[InvoiceNo] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[purchase_order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_PurchaseReturnInvoice]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PurchaseReturnInvoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Item_id] [int] NULL,
	[Bonus] [int] NULL,
	[Qty] [int] NULL,
	[Disc] [int] NULL,
	[Price] [money] NULL,
	[Purchase_ret_ID] [int] NULL,
 CONSTRAINT [PK_tbl_PurchaseReturnInvoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_PurchaseReturnOrder]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_PurchaseReturnOrder](
	[Purchase_ret_ID] [int] IDENTITY(1,1) NOT NULL,
	[Time] [time](7) NULL,
	[Sup_ID] [int] NULL,
	[user_id] [int] NULL,
	[Dis] [money] NULL,
	[Date] [date] NULL,
	[Type] [varchar](max) NULL,
	[InvoiceNo] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_PurchaseReturnOrder] PRIMARY KEY CLUSTERED 
(
	[Purchase_ret_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_SaleAccount]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_SaleAccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Time] [time](7) NULL,
	[Type] [varchar](max) NULL,
	[Credit] [money] NULL,
	[Debit] [money] NULL,
	[Sale_Order_ID] [int] NULL,
	[Sale_Return_ID] [int] NULL,
	[cash_id] [int] NULL,
	[Cu_ID] [int] NULL,
	[user_id] [int] NULL,
	[Balance] [money] NULL,
 CONSTRAINT [PK_tbl_SaleAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_SaleInvoice]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SaleInvoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Item_id] [int] NULL,
	[Bonus] [int] NULL,
	[Qty] [int] NULL,
	[Disc] [int] NULL,
	[Price] [money] NULL,
	[Sale_Order_ID] [int] NULL,
	[Tp_Price] [money] NULL,
 CONSTRAINT [PK_tbl_SaleInvoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_SaleOrder]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_SaleOrder](
	[Sale_Order_ID] [int] IDENTITY(1,1) NOT NULL,
	[Time] [time](7) NULL,
	[Cu_ID] [int] NULL,
	[user_id] [int] NULL,
	[Dis] [money] NULL,
	[Date] [date] NULL,
	[Type] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_SaleOrder] PRIMARY KEY CLUSTERED 
(
	[Sale_Order_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_SaleReturnInvoice]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SaleReturnInvoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Item_id] [int] NULL,
	[Bonus] [int] NULL,
	[Qty] [int] NULL,
	[Disc] [int] NULL,
	[Price] [money] NULL,
	[Sale_Return_ID] [int] NULL,
	[Tp_Price] [nchar](10) NULL,
 CONSTRAINT [PK_tbl_SaleReturnInvoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_SaleReturnOrder]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_SaleReturnOrder](
	[Sale_Return_ID] [int] IDENTITY(1,1) NOT NULL,
	[Time] [time](7) NULL,
	[Cu_ID] [int] NULL,
	[user_id] [int] NULL,
	[Dis] [money] NULL,
	[Date] [date] NULL,
	[Type] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_SaleReturnOrder] PRIMARY KEY CLUSTERED 
(
	[Sale_Return_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Supplier]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Supplier](
	[Sup_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address1] [nvarchar](max) NULL,
	[Address2] [nvarchar](max) NULL,
	[phone1] [nvarchar](max) NULL,
	[phone2] [nvarchar](max) NULL,
	[fax] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[website] [nvarchar](max) NULL,
	[licence] [nvarchar](max) NULL,
	[remark] [nvarchar](max) NULL,
	[status] [bit] NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_tbl_Supplier] PRIMARY KEY CLUSTERED 
(
	[Sup_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Supplier_CashRecord]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Supplier_CashRecord](
	[Cash_ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[user_id] [int] NULL,
	[Credit] [money] NULL,
	[Debit] [money] NULL,
 CONSTRAINT [PK_tbl_Supplier_CashRecord] PRIMARY KEY CLUSTERED 
(
	[Cash_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_TransferAccount]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_TransferAccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Time] [time](7) NULL,
	[Type] [varchar](max) NULL,
	[Credit] [money] NULL,
	[Debit] [money] NULL,
	[Transfer_In_ID] [int] NULL,
	[Transfer_Out_ID] [int] NULL,
	[cash_id] [int] NULL,
	[lo_id] [int] NULL,
	[user_id] [int] NULL,
	[Balance] [money] NULL,
 CONSTRAINT [PK_tbl_TransferAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_TransferInInvoice]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TransferInInvoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Item_id] [int] NULL,
	[Bonus] [int] NULL,
	[Qty] [int] NULL,
	[Disc] [int] NULL,
	[Price] [money] NULL,
	[Transfer_In_ID] [int] NULL,
	[Tp_Price] [money] NULL,
 CONSTRAINT [PK_tbl_TransferInInvoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_TransferInOrder]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_TransferInOrder](
	[Transfer_In_ID] [int] IDENTITY(1,1) NOT NULL,
	[Time] [time](7) NULL,
	[Lo_ID] [int] NULL,
	[user_id] [int] NULL,
	[Dis] [money] NULL,
	[Date] [date] NULL,
	[Type] [varchar](max) NULL,
	[InvoiceNo] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_TransferInOrder] PRIMARY KEY CLUSTERED 
(
	[Transfer_In_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_TransferOutInvoice]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TransferOutInvoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Item_id] [int] NULL,
	[Bonus] [int] NULL,
	[Qty] [int] NULL,
	[Disc] [int] NULL,
	[Price] [money] NULL,
	[Transfer_Out_ID] [int] NULL,
	[Tp_Price] [money] NULL,
 CONSTRAINT [PK_tbl_TransferOutInvoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_TransferOutOrder]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_TransferOutOrder](
	[Transfer_Out_ID] [int] IDENTITY(1,1) NOT NULL,
	[Time] [time](7) NULL,
	[Lo_ID] [int] NULL,
	[user_id] [int] NULL,
	[Dis] [money] NULL,
	[Date] [date] NULL,
	[Type] [varchar](max) NULL,
	[InvoiceNo] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_TransferOutOrder] PRIMARY KEY CLUSTERED 
(
	[Transfer_Out_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 11/08/2021 18:19:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_user](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](max) NULL,
	[user_password] [nvarchar](max) NULL,
	[status] [bit] NULL,
	[productFile] [bit] NULL,
	[prductstatus] [bit] NULL,
	[productmaster] [bit] NULL,
	[productlist] [bit] NULL,
	[purchasestock] [bit] NULL,
	[purchasemaster] [bit] NULL,
	[purchaselist] [bit] NULL,
	[purchasereturn] [bit] NULL,
	[purchasereturnmaster] [bit] NULL,
	[purchasereturnlist] [bit] NULL,
	[prodaccount] [bit] NULL,
	[prodaccmaster] [bit] NULL,
	[prodacclist] [bit] NULL,
	[prodreport] [bit] NULL,
	[customerFile] [bit] NULL,
	[customerstatus] [bit] NULL,
	[customermaster] [bit] NULL,
	[customerlist] [bit] NULL,
	[saleinvoice] [bit] NULL,
	[saleinvoicemaster] [bit] NULL,
	[saleinvoicelist] [bit] NULL,
	[salereturn] [bit] NULL,
	[salereturnmaster] [bit] NULL,
	[salereturnlist] [bit] NULL,
	[custaccount] [bit] NULL,
	[custaccmaster] [bit] NULL,
	[custacclist] [bit] NULL,
	[customerreport] [bit] NULL,
	[branche] [bit] NULL,
	[branchstatus] [bit] NULL,
	[branchmaster] [bit] NULL,
	[branchlist] [bit] NULL,
	[transferin] [bit] NULL,
	[transferinmaster] [bit] NULL,
	[transferinlist] [bit] NULL,
	[transferout] [bit] NULL,
	[transferoutmaster] [bit] NULL,
	[transferoutlist] [bit] NULL,
	[branchaccount] [bit] NULL,
	[branchaccmaster] [bit] NULL,
	[branchacclist] [bit] NULL,
	[loanreport] [bit] NULL,
	[supplier] [bit] NULL,
	[supplierstatus] [bit] NULL,
	[suppliermaster] [bit] NULL,
	[supplierlist] [bit] NULL,
	[Report] [bit] NULL,
	[Employee] [bit] NULL,
	[Expense] [bit] NULL,
	[Setting] [bit] NULL,
 CONSTRAINT [PK_tbl_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[tbl_Designation]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Designation_tbl_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_user] ([user_id])
GO
ALTER TABLE [dbo].[tbl_Designation] CHECK CONSTRAINT [FK_tbl_Designation_tbl_user]
GO
ALTER TABLE [dbo].[tbl_Employee]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Employee_tbl_Designation] FOREIGN KEY([DSIG_ID])
REFERENCES [dbo].[tbl_Designation] ([DSIG_ID])
GO
ALTER TABLE [dbo].[tbl_Employee] CHECK CONSTRAINT [FK_tbl_Employee_tbl_Designation]
GO
ALTER TABLE [dbo].[tbl_Employee]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Employee_tbl_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_user] ([user_id])
GO
ALTER TABLE [dbo].[tbl_Employee] CHECK CONSTRAINT [FK_tbl_Employee_tbl_user]
GO
ALTER TABLE [dbo].[tbl_EmployeeAccount]  WITH CHECK ADD  CONSTRAINT [FK_tbl_EmployeeAccount_tbl_Employee] FOREIGN KEY([EMP_ID])
REFERENCES [dbo].[tbl_Employee] ([EMP_ID])
GO
ALTER TABLE [dbo].[tbl_EmployeeAccount] CHECK CONSTRAINT [FK_tbl_EmployeeAccount_tbl_Employee]
GO
ALTER TABLE [dbo].[tbl_EmployeeAccount]  WITH CHECK ADD  CONSTRAINT [FK_tbl_EmployeeAccount_tbl_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_user] ([user_id])
GO
ALTER TABLE [dbo].[tbl_EmployeeAccount] CHECK CONSTRAINT [FK_tbl_EmployeeAccount_tbl_user]
GO
ALTER TABLE [dbo].[tbl_Item]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Item_tbl_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_user] ([user_id])
GO
ALTER TABLE [dbo].[tbl_Item] CHECK CONSTRAINT [FK_tbl_Item_tbl_user]
GO
ALTER TABLE [dbo].[tbl_Loan]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Loan_tbl_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_user] ([user_id])
GO
ALTER TABLE [dbo].[tbl_Loan] CHECK CONSTRAINT [FK_tbl_Loan_tbl_user]
GO
ALTER TABLE [dbo].[tbl_PurchaseAccount]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseAccount_tbl_Supplier] FOREIGN KEY([sup_id])
REFERENCES [dbo].[tbl_Supplier] ([Sup_ID])
GO
ALTER TABLE [dbo].[tbl_PurchaseAccount] CHECK CONSTRAINT [FK_tbl_PurchaseAccount_tbl_Supplier]
GO
ALTER TABLE [dbo].[tbl_PurchaseInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseInvoice_tbl_Item] FOREIGN KEY([Item_id])
REFERENCES [dbo].[tbl_Item] ([item_id])
GO
ALTER TABLE [dbo].[tbl_PurchaseInvoice] CHECK CONSTRAINT [FK_tbl_PurchaseInvoice_tbl_Item]
GO
ALTER TABLE [dbo].[tbl_PurchaseInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseInvoice_tbl_PurchaseOrder] FOREIGN KEY([purchase_order_id])
REFERENCES [dbo].[tbl_PurchaseOrder] ([purchase_order_id])
GO
ALTER TABLE [dbo].[tbl_PurchaseInvoice] CHECK CONSTRAINT [FK_tbl_PurchaseInvoice_tbl_PurchaseOrder]
GO
ALTER TABLE [dbo].[tbl_PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseOrder_tbl_Supplier] FOREIGN KEY([Sup_ID])
REFERENCES [dbo].[tbl_Supplier] ([Sup_ID])
GO
ALTER TABLE [dbo].[tbl_PurchaseOrder] CHECK CONSTRAINT [FK_tbl_PurchaseOrder_tbl_Supplier]
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseReturnInvoice_tbl_Item] FOREIGN KEY([Item_id])
REFERENCES [dbo].[tbl_Item] ([item_id])
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnInvoice] CHECK CONSTRAINT [FK_tbl_PurchaseReturnInvoice_tbl_Item]
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseReturnInvoice_tbl_PurchaseReturnOrder] FOREIGN KEY([Purchase_ret_ID])
REFERENCES [dbo].[tbl_PurchaseReturnOrder] ([Purchase_ret_ID])
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnInvoice] CHECK CONSTRAINT [FK_tbl_PurchaseReturnInvoice_tbl_PurchaseReturnOrder]
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnOrder]  WITH CHECK ADD  CONSTRAINT [FK_tbl_PurchaseReturnOrder_tbl_Supplier] FOREIGN KEY([Sup_ID])
REFERENCES [dbo].[tbl_Supplier] ([Sup_ID])
GO
ALTER TABLE [dbo].[tbl_PurchaseReturnOrder] CHECK CONSTRAINT [FK_tbl_PurchaseReturnOrder_tbl_Supplier]
GO
ALTER TABLE [dbo].[tbl_SaleAccount]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleAccount_tbl_Customer] FOREIGN KEY([Cu_ID])
REFERENCES [dbo].[tbl_Customer] ([Cu_ID])
GO
ALTER TABLE [dbo].[tbl_SaleAccount] CHECK CONSTRAINT [FK_tbl_SaleAccount_tbl_Customer]
GO
ALTER TABLE [dbo].[tbl_SaleAccount]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleAccount_tbl_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_user] ([user_id])
GO
ALTER TABLE [dbo].[tbl_SaleAccount] CHECK CONSTRAINT [FK_tbl_SaleAccount_tbl_user]
GO
ALTER TABLE [dbo].[tbl_SaleInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleInvoice_tbl_Item] FOREIGN KEY([Item_id])
REFERENCES [dbo].[tbl_Item] ([item_id])
GO
ALTER TABLE [dbo].[tbl_SaleInvoice] CHECK CONSTRAINT [FK_tbl_SaleInvoice_tbl_Item]
GO
ALTER TABLE [dbo].[tbl_SaleInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleInvoice_tbl_SaleOrder] FOREIGN KEY([Sale_Order_ID])
REFERENCES [dbo].[tbl_SaleOrder] ([Sale_Order_ID])
GO
ALTER TABLE [dbo].[tbl_SaleInvoice] CHECK CONSTRAINT [FK_tbl_SaleInvoice_tbl_SaleOrder]
GO
ALTER TABLE [dbo].[tbl_SaleOrder]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleOrder_tbl_Customer] FOREIGN KEY([Cu_ID])
REFERENCES [dbo].[tbl_Customer] ([Cu_ID])
GO
ALTER TABLE [dbo].[tbl_SaleOrder] CHECK CONSTRAINT [FK_tbl_SaleOrder_tbl_Customer]
GO
ALTER TABLE [dbo].[tbl_SaleOrder]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleOrder_tbl_Customer1] FOREIGN KEY([Cu_ID])
REFERENCES [dbo].[tbl_Customer] ([Cu_ID])
GO
ALTER TABLE [dbo].[tbl_SaleOrder] CHECK CONSTRAINT [FK_tbl_SaleOrder_tbl_Customer1]
GO
ALTER TABLE [dbo].[tbl_SaleReturnInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleReturnInvoice_tbl_Item] FOREIGN KEY([Item_id])
REFERENCES [dbo].[tbl_Item] ([item_id])
GO
ALTER TABLE [dbo].[tbl_SaleReturnInvoice] CHECK CONSTRAINT [FK_tbl_SaleReturnInvoice_tbl_Item]
GO
ALTER TABLE [dbo].[tbl_SaleReturnInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleReturnInvoice_tbl_SaleReturnOrder] FOREIGN KEY([Sale_Return_ID])
REFERENCES [dbo].[tbl_SaleReturnOrder] ([Sale_Return_ID])
GO
ALTER TABLE [dbo].[tbl_SaleReturnInvoice] CHECK CONSTRAINT [FK_tbl_SaleReturnInvoice_tbl_SaleReturnOrder]
GO
ALTER TABLE [dbo].[tbl_SaleReturnOrder]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SaleReturnOrder_tbl_Customer] FOREIGN KEY([Cu_ID])
REFERENCES [dbo].[tbl_Customer] ([Cu_ID])
GO
ALTER TABLE [dbo].[tbl_SaleReturnOrder] CHECK CONSTRAINT [FK_tbl_SaleReturnOrder_tbl_Customer]
GO
ALTER TABLE [dbo].[tbl_Supplier]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Supplier_tbl_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[tbl_user] ([user_id])
GO
ALTER TABLE [dbo].[tbl_Supplier] CHECK CONSTRAINT [FK_tbl_Supplier_tbl_user]
GO
ALTER TABLE [dbo].[tbl_TransferAccount]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TransferAccount_tbl_Loan] FOREIGN KEY([lo_id])
REFERENCES [dbo].[tbl_Loan] ([Lo_ID])
GO
ALTER TABLE [dbo].[tbl_TransferAccount] CHECK CONSTRAINT [FK_tbl_TransferAccount_tbl_Loan]
GO
ALTER TABLE [dbo].[tbl_TransferInInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TransferInInvoice_tbl_Item] FOREIGN KEY([Item_id])
REFERENCES [dbo].[tbl_Item] ([item_id])
GO
ALTER TABLE [dbo].[tbl_TransferInInvoice] CHECK CONSTRAINT [FK_tbl_TransferInInvoice_tbl_Item]
GO
ALTER TABLE [dbo].[tbl_TransferInInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TransferInInvoice_tbl_TransferInOrder] FOREIGN KEY([Transfer_In_ID])
REFERENCES [dbo].[tbl_TransferInOrder] ([Transfer_In_ID])
GO
ALTER TABLE [dbo].[tbl_TransferInInvoice] CHECK CONSTRAINT [FK_tbl_TransferInInvoice_tbl_TransferInOrder]
GO
ALTER TABLE [dbo].[tbl_TransferInOrder]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TransferInOrder_tbl_Loan] FOREIGN KEY([Lo_ID])
REFERENCES [dbo].[tbl_Loan] ([Lo_ID])
GO
ALTER TABLE [dbo].[tbl_TransferInOrder] CHECK CONSTRAINT [FK_tbl_TransferInOrder_tbl_Loan]
GO
ALTER TABLE [dbo].[tbl_TransferOutInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TransferOutInvoice_tbl_Item] FOREIGN KEY([Item_id])
REFERENCES [dbo].[tbl_Item] ([item_id])
GO
ALTER TABLE [dbo].[tbl_TransferOutInvoice] CHECK CONSTRAINT [FK_tbl_TransferOutInvoice_tbl_Item]
GO
ALTER TABLE [dbo].[tbl_TransferOutInvoice]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TransferOutInvoice_tbl_TransferOutOrder] FOREIGN KEY([Transfer_Out_ID])
REFERENCES [dbo].[tbl_TransferOutOrder] ([Transfer_Out_ID])
GO
ALTER TABLE [dbo].[tbl_TransferOutInvoice] CHECK CONSTRAINT [FK_tbl_TransferOutInvoice_tbl_TransferOutOrder]
GO
ALTER TABLE [dbo].[tbl_TransferOutOrder]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TransferOutOrder_tbl_Loan] FOREIGN KEY([Lo_ID])
REFERENCES [dbo].[tbl_Loan] ([Lo_ID])
GO
ALTER TABLE [dbo].[tbl_TransferOutOrder] CHECK CONSTRAINT [FK_tbl_TransferOutOrder_tbl_Loan]
GO
USE [master]
GO
ALTER DATABASE [POSDBMS] SET  READ_WRITE 
GO
