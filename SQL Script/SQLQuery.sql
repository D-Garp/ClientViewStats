USE [master]
GO
/****** Object:  Database [ClientListDB]    Script Date: 2024/08/21 19:49:40 ******/
CREATE DATABASE [ClientListDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ClientListDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ClientListDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ClientListDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ClientListDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ClientListDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ClientListDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ClientListDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ClientListDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ClientListDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ClientListDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ClientListDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ClientListDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ClientListDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ClientListDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ClientListDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ClientListDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ClientListDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ClientListDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ClientListDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ClientListDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ClientListDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ClientListDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ClientListDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ClientListDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ClientListDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ClientListDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ClientListDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ClientListDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ClientListDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ClientListDB] SET  MULTI_USER 
GO
ALTER DATABASE [ClientListDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ClientListDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ClientListDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ClientListDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ClientListDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ClientListDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ClientListDB', N'ON'
GO
ALTER DATABASE [ClientListDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [ClientListDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ClientListDB]
GO
/****** Object:  Table [dbo].[tblClientData]    Script Date: 2024/08/21 19:49:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblClientData](
	[ClientName] [varchar](255) NOT NULL,
	[DateRegistered] [datetime] NULL,
	[Location] [varchar](255) NULL,
	[NumberOfUsers] [numeric](16, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vwLocations]    Script Date: 2024/08/21 19:49:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwLocations]
AS
SELECT DISTINCT[Location]
	,COUNT(ClientName) Clients
	,SUM(NumberOfUsers) Users
FROM tblClientData
GROUP BY [Location]
GO
/****** Object:  View [dbo].[vwRegistrationDate]    Script Date: 2024/08/21 19:49:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwRegistrationDate]
AS
SELECT MAX([DateRegistered]) DateRegistered
	,COUNT(ClientName) Clients
	,SUM(NumberOfUsers) Users
FROM tblClientData
GROUP BY DATENAME(YEAR,DateRegistered)
		, DATENAME(MONTH,DateRegistered)
		, DATENAME(Day,DateRegistered)
GO
INSERT [dbo].[tblClientData] ([ClientName], [DateRegistered], [Location], [NumberOfUsers]) VALUES (N'Base', CAST(N'2023-09-27T00:00:00.000' AS DateTime), N'Win', CAST(240 AS Numeric(16, 0)))
GO
INSERT [dbo].[tblClientData] ([ClientName], [DateRegistered], [Location], [NumberOfUsers]) VALUES (N'Business', CAST(N'2023-09-27T00:00:00.000' AS DateTime), N'Benoni', CAST(862 AS Numeric(16, 0)))
GO
INSERT [dbo].[tblClientData] ([ClientName], [DateRegistered], [Location], [NumberOfUsers]) VALUES (N'Client1', CAST(N'2023-07-28T00:00:00.000' AS DateTime), N'Win', CAST(300 AS Numeric(16, 0)))
GO
INSERT [dbo].[tblClientData] ([ClientName], [DateRegistered], [Location], [NumberOfUsers]) VALUES (N'Me', CAST(N'2024-08-08T00:00:00.000' AS DateTime), N'Midrand', CAST(560 AS Numeric(16, 0)))
GO
INSERT [dbo].[tblClientData] ([ClientName], [DateRegistered], [Location], [NumberOfUsers]) VALUES (N'Testing', CAST(N'2023-09-27T00:00:00.000' AS DateTime), N'Benoni', CAST(500 AS Numeric(16, 0)))
GO
INSERT [dbo].[tblClientData] ([ClientName], [DateRegistered], [Location], [NumberOfUsers]) VALUES (N'Vhutshilo', CAST(N'2009-07-09T00:00:00.000' AS DateTime), N'Benoni', CAST(300 AS Numeric(16, 0)))
GO
USE [master]
GO
ALTER DATABASE [ClientListDB] SET  READ_WRITE 
GO

USE [ClientListDB]
GO
/****** Object:  StoredProcedure [dbo].[spSaveClientData]    Script Date: 2024/08/21 22:54:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*******************************************************************
Created By:			Vhutshilo Funyufuynu
Created Date:		08 August 2024
Modified:
Example:			EXEC spSaveClientData @ClientName = 'Vhutshilo'
									 , @DateRegistered = GETDATE()
									 , @Location = 'Home'
									 , @NumberOfUsers = 10

********************************************************************/
CREATE   PROCEDURE [dbo].[spSaveClientData]
		@ClientName VARCHAR(255), 
		@DateRegistered DateTime = NULL,
		@Location VARCHAR(255) = '',
		@NumberOfUsers Numeric(16,0) NULL
AS
BEGIN
	
	--Variables
	DECLARE @Validations TABLE ([Message] VARCHAR(MAX))

	--Validations
	IF(NULLIF(@ClientName,'')) IS NULL
	BEGIN
		INSERT INTO @Validations
		SELECT 'NO Client Name Provided'
	END

	IF(NULLIF(@Location,'')) IS NULL
	BEGIN
		INSERT INTO @Validations
		SELECT 'No Location Provided'
	END

	IF(@DateRegistered IS  NULL)
	BEGIN
		INSERT INTO @Validations
		SELECT 'No Date Registered Provided'
	END

	IF(ISNULL(@NumberOfUsers,0) < 1)
	BEGIN
		INSERT INTO @Validations
		SELECT 'No Date Registered Provided'
	END

	--Validating
	IF NOT EXISTS( SELECT TOP 1 1 FROM @Validations)
	BEGIN
		
		INSERT INTO tblClientData (
			[ClientName],
			[Location],
			[DateRegistered],
			[NumberOfUsers]
		)
		SELECT @ClientName
			 , @Location
			 , @DateRegistered
			 , @NumberOfUsers
	END

	--Returning table
	SELECT * 
	FROM @Validations

END
GO


USE [ClientListDB] 
GO
SELECT
    'Data source=' + @@SERVERNAME + ';Initial catalog= ClientListDB'+
    CASE TYPE_DESC
        WHEN 'WINDOWS_LOGIN' 
            THEN ';trusted_connection=true'
        ELSE
            ';user id=' + SUSER_NAME() + ';password=<<YourPassword>>'
    END
    AS ConnectionString
FROM sys.server_principals
WHERE NAME = SUSER_NAME()
