SET NOCOUNT ON
GO

USE master
GO
if exists (select * from sysdatabases where name='SavedDashboards')
		drop database SavedDashboards
GO

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE SavedDashboards
  ON PRIMARY (NAME = N''SavedDashboards'', FILENAME = N''' + @device_directory + N'SavedDashboards.mdf'')
  LOG ON (NAME = N''SavedDashboards_log'',  FILENAME = N''' + @device_directory + N'SavedDashboards.ldf'')
  COLLATE SQL_Latin1_General_CP1_CI_AI')
GO

USE [SavedDashboards]
GO

/****** Object:  Table [dbo].[Dashboards]    Script Date: 07/06/2016 15:51:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Dashboards](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Dashboard] [varbinary](max) NULL,
	[Caption] [nvarchar](255) NULL,
 CONSTRAINT [PK_Dashboards] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO