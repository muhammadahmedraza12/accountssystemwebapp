USE [master]
GO
/****** Object:  Database [AccountsSystem 1]    Script Date: 11/4/2023 3:48:17 PM ******/
CREATE DATABASE [AccountsSystem 1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AccountsSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AccountsSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AccountsSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AccountsSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AccountsSystem 1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AccountsSystem 1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AccountsSystem 1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET ARITHABORT OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AccountsSystem 1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AccountsSystem 1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AccountsSystem 1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AccountsSystem 1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET RECOVERY FULL 
GO
ALTER DATABASE [AccountsSystem 1] SET  MULTI_USER 
GO
ALTER DATABASE [AccountsSystem 1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AccountsSystem 1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AccountsSystem 1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AccountsSystem 1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AccountsSystem 1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AccountsSystem 1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AccountsSystem 1', N'ON'
GO
ALTER DATABASE [AccountsSystem 1] SET QUERY_STORE = OFF
GO
USE [AccountsSystem 1]
GO
/****** Object:  Table [dbo].[tbl_ChartofAccount]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ChartofAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Mid] [int] NULL,
	[AccountName] [varchar](500) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_tbl_ChartofAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Fixed]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Fixed](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FixedAccount] [varchar](100) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_tbl_Fixed] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_GeneralLedger]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_GeneralLedger](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[AccountId] [int] NULL,
	[RefNo] [int] NULL,
	[TypeId] [int] NULL,
	[Debit] [decimal](18, 2) NULL,
	[Credit] [decimal](18, 2) NULL,
	[Description] [varchar](100) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_tbl_GeneralLedger] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_JournalDetail]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_JournalDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RefId] [int] NULL,
	[AccountId] [int] NULL,
	[Debit] [decimal](18, 2) NULL,
	[Credit] [decimal](18, 2) NULL,
	[Description] [varchar](500) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_tbl_JournalDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_JournalMaster]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_JournalMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [varchar](max) NULL,
	[Date] [date] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_tbl_JournalMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_MasterAccount]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MasterAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fid] [int] NULL,
	[MasterAccount] [varchar](500) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_tbl_MasterAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PaymentDetail]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PaymentDetail](
	[PDId] [int] IDENTITY(1,1) NOT NULL,
	[PId] [int] NULL,
	[DebitAccountId] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Description] [varchar](max) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_tbl_PaymentDetail] PRIMARY KEY CLUSTERED 
(
	[PDId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PaymentMaster]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PaymentMaster](
	[PId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [varchar](500) NULL,
	[Date] [date] NULL,
	[CreditAccountId] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Description] [varchar](max) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_tbl_PaymentMaster] PRIMARY KEY CLUSTERED 
(
	[PId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ReceiptDetail]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ReceiptDetail](
	[RDId] [int] IDENTITY(1,1) NOT NULL,
	[RId] [int] NULL,
	[CreditAccountId] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Description] [varchar](max) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_tbl_ReceiptDetail] PRIMARY KEY CLUSTERED 
(
	[RDId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ReceiptMaster]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ReceiptMaster](
	[RId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [varchar](500) NULL,
	[Date] [date] NULL,
	[DebitAccountId] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Description] [varchar](max) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_tbl_ReceiptMaster] PRIMARY KEY CLUSTERED 
(
	[RId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TransactionType]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TransactionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](500) NULL,
	[ShortName] [varchar](50) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_tbl_TransactionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_ChartofAccount]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ChartofAccount_tbl_MasterAccount] FOREIGN KEY([Mid])
REFERENCES [dbo].[tbl_MasterAccount] ([Id])
GO
ALTER TABLE [dbo].[tbl_ChartofAccount] CHECK CONSTRAINT [FK_tbl_ChartofAccount_tbl_MasterAccount]
GO
ALTER TABLE [dbo].[tbl_GeneralLedger]  WITH CHECK ADD  CONSTRAINT [FK_tbl_GeneralLedger_tbl_ChartofAccount] FOREIGN KEY([AccountId])
REFERENCES [dbo].[tbl_ChartofAccount] ([Id])
GO
ALTER TABLE [dbo].[tbl_GeneralLedger] CHECK CONSTRAINT [FK_tbl_GeneralLedger_tbl_ChartofAccount]
GO
ALTER TABLE [dbo].[tbl_GeneralLedger]  WITH CHECK ADD  CONSTRAINT [FK_tbl_GeneralLedger_tbl_TransactionType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[tbl_TransactionType] ([Id])
GO
ALTER TABLE [dbo].[tbl_GeneralLedger] CHECK CONSTRAINT [FK_tbl_GeneralLedger_tbl_TransactionType]
GO
ALTER TABLE [dbo].[tbl_MasterAccount]  WITH CHECK ADD  CONSTRAINT [FK_tbl_MasterAccount_tbl_Fixed] FOREIGN KEY([Fid])
REFERENCES [dbo].[tbl_Fixed] ([Id])
GO
ALTER TABLE [dbo].[tbl_MasterAccount] CHECK CONSTRAINT [FK_tbl_MasterAccount_tbl_Fixed]
GO
ALTER TABLE [dbo].[tbl_ReceiptDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ReceiptDetail_tbl_ReceiptMaster] FOREIGN KEY([RId])
REFERENCES [dbo].[tbl_ReceiptMaster] ([RId])
GO
ALTER TABLE [dbo].[tbl_ReceiptDetail] CHECK CONSTRAINT [FK_tbl_ReceiptDetail_tbl_ReceiptMaster]
GO
/****** Object:  StoredProcedure [dbo].[DeleteChartfAccount]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[DeleteChartfAccount]
@Id int
as
delete from tbl_GeneralLedger where RefNo = @Id and TypeId= 1
delete from tbl_ChartofAccount where Id =@Id
GO
/****** Object:  StoredProcedure [dbo].[DeleteMasterAc]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteMasterAc]
@id int
as
delete from tbl_MasterAccount
where id =@id

GO
/****** Object:  StoredProcedure [dbo].[deletereceiptmaster]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deletereceiptmaster]
 @RId int
 as
 delete From tbl_ReceiptMaster where RId = @RId
GO
/****** Object:  StoredProcedure [dbo].[GetAllChartFAccount]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[GetAllChartFAccount]
as
select gl.RefNo,gl.Date,gl.Debit,gl.Credit,
C.AccountName,C.Id,C.Mid,
M.MasterAccount 
from tbl_GeneralLedger gl
 inner join tbl_ChartofAccount C on gl.RefNo = C.Id
 inner join tbl_MasterAccount M on C.Mid = M.Id
 where gl.TypeId=1
GO
/****** Object:  StoredProcedure [dbo].[GetAllMasterAc]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllMasterAc]

as
select ma.Id,ma.Fid,ma.MasterAccount,ma.Status,f.FixedAccount from tbl_MasterAccount ma
inner join tbl_Fixed f on ma.Fid = f.id


GO
/****** Object:  StoredProcedure [dbo].[GetAllreceiptmaster]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllreceiptmaster]

 as
 select  rm.InvoiceNo,rm.Date,rm.Amount,rm.RId,rm.Description from tbl_ReceiptMaster  rm 
GO
/****** Object:  StoredProcedure [dbo].[GetByIdChartFAccount]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[GetByIdChartFAccount]
@id int
as
select gl.RefNo,gl.Date,gl.Debit,gl.Credit,gl.AccountId,
C.AccountName,C.Id,
M.MasterAccount 
from tbl_GeneralLedger gl
 inner join tbl_ChartofAccount C on gl.AccountId = C.Id
 inner join tbl_MasterAccount M on C.Mid = M.Id
 where RefNo=@id and TypeId=1
GO
/****** Object:  StoredProcedure [dbo].[GetByIDMAsterAc]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetByIDMAsterAc]
@id int
as
select ma.id,ma.Fid,ma.MasterAccount,ma.Status,f.FixedAccount from tbl_MasterAccount ma
inner join tbl_Fixed f on ma.Fid = f.id
where ma.id=@id
GO
/****** Object:  StoredProcedure [dbo].[GetbyIDreceiptmaster]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetbyIDreceiptmaster]
 @RId int
 as
 select  rm.InvoiceNo,rm.Date,rm.Amount,rm.RId,rm.Description from tbl_ReceiptMaster  rm 

 where RId= @RId 
GO
/****** Object:  StoredProcedure [dbo].[GetByMasterAc]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetByMasterAc]
@id int
as
select ma.Id,ma.Fid,ma.MasterAccount,ma.Status,f.FixedAccount from tbl_MasterAccount ma
inner join tbl_Fixed f on ma.Fid = f.id
where ma.id =@id

GO
/****** Object:  StoredProcedure [dbo].[InsertChartFAccount]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[InsertChartFAccount]
@Mid int,
@AccountName varchar(500),
@Debit decimal(18,2),
@Credit decimal(18,2),
@Date date
as
insert into tbl_ChartofAccount (Mid,AccountName) values(@Mid,@AccountName)
Declare @Id int = Scope_Identity()
insert into tbl_GeneralLedger (Date,RefNo,Debit,Credit,TypeId) values (@Date,@Id,@Debit,@Credit,1)

Select 'OK'
GO
/****** Object:  StoredProcedure [dbo].[InsertfeeVoucher]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertfeeVoucher]
@RefNo int,
@InvoiceNo varchar(max),
@Date date ,
@Amount decimal(18,2),
@AccountId int,
@Debit decimal(18,2),
@Credit decimal(18,2)
as
insert into tbl_JournalMaster(InvoiceNo,Date,Amount) values(@InvoiceNo,@Date,@Amount)
Declare @Id int = Scope_Identity()
insert into tbl_JournalDetail(Debit,Credit,AccountId) values(@Debit,@Credit,@AccountId)
Declare @RefId int = Scope_Identity()
insert into tbl_GeneralLedger(RefNo,AccountId,TypeId,Debit,Credit,Date) values (@Id,@AccountId,4,@Debit,@Credit,@Date)
GO
/****** Object:  StoredProcedure [dbo].[InsertMasterAc]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertMasterAc]
@Fid int,
@MasterAccount varchar (500),
@Status int
as
Insert into tbl_MasterAccount
Values (@Fid,@MasterAccount,@Status)



select * from tbl_Fixed
GO
/****** Object:  StoredProcedure [dbo].[insertreceiptmaster]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertreceiptmaster]
 @InvoiceNo varchar (500) , @Date date , @Description varchar (max) , @Amount decimal (18,2) 
 as
 insert into  tbl_ReceiptMaster 
 (InvoiceNo , Date , Description , Amount)values(@InvoiceNo, @Date ,@Description , @Amount)
GO
/****** Object:  StoredProcedure [dbo].[UpDateChartFAccount]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[UpDateChartFAccount]

@Id int,
@Mid int,
@AccountName varchar(500),
@Debit decimal(18,2),
@Credit decimal(18,2),
@Date date
as
Update tbl_ChartofAccount
set
Mid = @Mid,
AccountName= @AccountName
where Id = @Id
update tbl_GeneralLedger  
set
Debit= @Debit,
Credit= @Credit,
Date= @Date
where RefNo = @Id and TypeId = 1
GO
/****** Object:  StoredProcedure [dbo].[updateMasterAc]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateMasterAc]
@id int,
@Fid int,
@MasterAccount varchar (500),
@Status int
as
update tbl_MasterAccount
set 
Fid = @Fid,
MasterAccount = @MasterAccount,
Status = @Status
where id =@id
GO
/****** Object:  StoredProcedure [dbo].[updatereceiptmaster]    Script Date: 11/4/2023 3:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updatereceiptmaster]
  @InvoiceNo varchar (500) , @Date date , @Description varchar (max) , @Amount decimal (18,2) , @RId int 
  as
  update tbl_ReceiptMaster
  set InvoiceNo =@InvoiceNo ,
  Date= @Date ,
  Description= @Description ,
  Amount= @Amount
  where
  RId = @RId
GO
USE [master]
GO
ALTER DATABASE [AccountsSystem 1] SET  READ_WRITE 
GO
