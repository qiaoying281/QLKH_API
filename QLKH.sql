USE [master]
GO
/****** Object:  Database [QLKH]    Script Date: 3/31/2024 5:37:33 PM ******/
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'QLKH')
BEGIN
    ALTER DATABASE [QLKH] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [QLKH];
END

CREATE DATABASE [QLKH]
CONTAINMENT = NONE
ON PRIMARY 
( 
    NAME = N'QLKH', 
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLKH.mdf', 
    SIZE = 73728KB, 
    MAXSIZE = UNLIMITED, 
    FILEGROWTH = 65536KB 
) 
LOG ON 
( 
    NAME = N'QLKH_log', 
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLKH_log.ldf', 
    SIZE = 8192KB, 
    MAXSIZE = 2048GB, 
    FILEGROWTH = 65536KB 
)
WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF;
GO

USE [QLKH]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[__Migrations](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Accounts]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[Accounts](
	[accountID] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
	[avatar] [nvarchar](max) NULL,
	[password] [nvarchar](max) NOT NULL,
	[status] [nvarchar](max) NOT NULL,
	[decentralizationId] [int] NOT NULL,
	[resetPasswordToken] [nvarchar](max) NOT NULL,
	[resetPasswordTokenExpiry] [datetime2](7) NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[accountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[Answers](
	[answerID] [int] IDENTITY(1,1) NOT NULL,
	[questionID] [int] NOT NULL,
	[rightAnswer] [bit] NOT NULL,
	[content] [nvarchar](max) NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[answerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseParts]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[CourseParts](
	[coursePartID] [int] IDENTITY(1,1) NOT NULL,
	[courseID] [int] NOT NULL,
	[partTitle] [nvarchar](max) NOT NULL,
	[amout] [int] NOT NULL,
	[duration] [int] NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
	[index] [int] NOT NULL,
 CONSTRAINT [PK_CourseParts] PRIMARY KEY CLUSTERED 
(
	[coursePartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[Courses](
	[courseID] [int] IDENTITY(1,1) NOT NULL,
	[courseName] [nvarchar](max) NOT NULL,
	[courseDescription] [nvarchar](max) NOT NULL,
	[tutorID] [int] NOT NULL,
	[cost] [int] NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[courseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Decentralizations]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[Decentralizations](
	[decentralizationID] [int] IDENTITY(1,1) NOT NULL,
	[authorityName] [nvarchar](max) NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Decentralizations] PRIMARY KEY CLUSTERED 
(
	[decentralizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollments]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[Enrollments](
	[enrollmentID] [int] IDENTITY(1,1) NOT NULL,
	[studentID] [int] NOT NULL,
	[courseID] [int] NOT NULL,
	[tutorID] [int] NOT NULL,
	[enrollmentDate] [datetime2](7) NOT NULL,
	[statusTypeID] [int] NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Enrollments] PRIMARY KEY CLUSTERED 
(
	[enrollmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exams]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[Exams](
	[examID] [int] IDENTITY(1,1) NOT NULL,
	[coursePartID] [int] NOT NULL,
	[examTypeID] [int] NOT NULL,
	[examName] [nvarchar](max) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[workTime] [int] NOT NULL,
	[dueDate] [datetime2](7) NOT NULL,
	[minGrade] [float] NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Exams] PRIMARY KEY CLUSTERED 
(
	[examID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamTypes]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[ExamTypes](
	[examTypeID] [int] IDENTITY(1,1) NOT NULL,
	[examTypeName] [nvarchar](max) NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ExamTypes] PRIMARY KEY CLUSTERED 
(
	[examTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fees]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[Fees](
	[feeID] [int] IDENTITY(1,1) NOT NULL,
	[studentID] [int] NOT NULL,
	[courseID] [int] NOT NULL,
	[cost] [int] NOT NULL,
	[status] [nvarchar](max) NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
	[isChecked] [bit] NOT NULL,
 CONSTRAINT [PK_Fees] PRIMARY KEY CLUSTERED 
(
	[feeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lectures]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[Lectures](
	[lectureID] [int] IDENTITY(1,1) NOT NULL,
	[coursePartID] [int] NOT NULL,
	[lectureTitle] [nvarchar](max) NOT NULL,
	[lectureLink] [nvarchar](max) NOT NULL,
	[duration] [int] NULL,
	[isWatched] [bit] NOT NULL,
	[isWatching] [bit] NOT NULL,
	[isAvailable] [bit] NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
	[index] [int] NOT NULL,
 CONSTRAINT [PK_Lectures] PRIMARY KEY CLUSTERED 
(
	[lectureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentHistorys]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[PaymentHistorys](
	[paymentHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[studentID] [int] NOT NULL,
	[paymentTypeID] [int] NOT NULL,
	[paymentName] [nvarchar](max) NOT NULL,
	[amount] [int] NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PaymentHistorys] PRIMARY KEY CLUSTERED 
(
	[paymentHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentTypes]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[PaymentTypes](
	[paymentTypeID] [int] IDENTITY(1,1) NOT NULL,
	[paymentTypeName] [nvarchar](max) NOT NULL,
	[creatAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PaymentTypes] PRIMARY KEY CLUSTERED 
(
	[paymentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[Questions](
	[questionID] [int] IDENTITY(1,1) NOT NULL,
	[examID] [int] NOT NULL,
	[questionName] [nvarchar](max) NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[questionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusTypes]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[StatusTypes](
	[statusTypeID] [int] IDENTITY(1,1) NOT NULL,
	[statusName] [nvarchar](max) NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_StatusTypes] PRIMARY KEY CLUSTERED 
(
	[statusTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[Students](
	[studentID] [int] IDENTITY(1,1) NOT NULL,
	[accountID] [int] NOT NULL,
	[fullName] [nvarchar](max) NOT NULL,
	[contactNumber] [nvarchar](max) NOT NULL,
	[provinceID] [int] NULL,
	[districtID] [int] NULL,
	[communeID] [int] NULL,
	[email] [nvarchar](max) NOT NULL,
	[totalMoney] [int] NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Submissions]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[Submissions](
	[submissionID] [int] IDENTITY(1,1) NOT NULL,
	[examID] [int] NOT NULL,
	[studentID] [int] NOT NULL,
	[submissionDate] [datetime2](7) NOT NULL,
	[examTimes] [int] NOT NULL,
	[grade] [int] NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Submissions] PRIMARY KEY CLUSTERED 
(
	[submissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TutorAssignments]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[TutorAssignments](
	[tutorAssignmentID] [int] IDENTITY(1,1) NOT NULL,
	[tutorID] [int] NOT NULL,
	[courseID] [int] NOT NULL,
	[numberOfStudent] [int] NOT NULL,
	[assignmentDate] [datetime2](7) NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TutorAssignments] PRIMARY KEY CLUSTERED 
(
	[tutorAssignmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tutors]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[Tutors](
	[tutorID] [int] IDENTITY(1,1) NOT NULL,
	[accountID] [int] NOT NULL,
	[fullName] [nvarchar](max) NOT NULL,
	[contactNumber] [nvarchar](max) NOT NULL,
	[provinceID] [int] NULL,
	[districtID] [int] NULL,
	[communeID] [int] NULL,
	[email] [nvarchar](max) NOT NULL,
	[createdAt] [datetime2](7) NOT NULL,
	[updatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Tutors] PRIMARY KEY CLUSTERED 
(
	[tutorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VerifyCodes]    Script Date: 3/31/2024 5:37:33 PM ******/

CREATE TABLE [dbo].[VerifyCodes](
	[verifyCodeID] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
	[code] [nvarchar](max) NOT NULL,
	[expiredTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_VerifyCodes] PRIMARY KEY CLUSTERED 
(
	[verifyCodeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Accounts_decentralizationId]    Script Date: 3/31/2024 5:37:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_Accounts_decentralizationId] ON [dbo].[Accounts]
(
	[decentralizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Answers_questionID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Answers_questionID] ON [dbo].[Answers]
(
	[questionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseParts_courseID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_CourseParts_courseID] ON [dbo].[CourseParts]
(
	[courseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Courses_tutorID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Courses_tutorID] ON [dbo].[Courses]
(
	[tutorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Enrollments_statusTypeID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Enrollments_statusTypeID] ON [dbo].[Enrollments]
(
	[statusTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Enrollments_studentID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Enrollments_studentID] ON [dbo].[Enrollments]
(
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Exams_coursePartID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Exams_coursePartID] ON [dbo].[Exams]
(
	[coursePartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Exams_examTypeID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Exams_examTypeID] ON [dbo].[Exams]
(
	[examTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Fees_studentID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Fees_studentID] ON [dbo].[Fees]
(
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Lectures_coursePartID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Lectures_coursePartID] ON [dbo].[Lectures]
(
	[coursePartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PaymentHistorys_paymentTypeID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_PaymentHistorys_paymentTypeID] ON [dbo].[PaymentHistorys]
(
	[paymentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PaymentHistorys_studentID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_PaymentHistorys_studentID] ON [dbo].[PaymentHistorys]
(
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Questions_examID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Questions_examID] ON [dbo].[Questions]
(
	[examID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Students_accountID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Students_accountID] ON [dbo].[Students]
(
	[accountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Submissions_studentID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Submissions_studentID] ON [dbo].[Submissions]
(
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TutorAssignments_tutorID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_TutorAssignments_tutorID] ON [dbo].[TutorAssignments]
(
	[tutorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tutors_accountID]    Script Date: 3/31/2024 5:37:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tutors_accountID] ON [dbo].[Tutors]
(
	[accountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CourseParts] ADD  DEFAULT ((0)) FOR [index]
GO
ALTER TABLE [dbo].[Fees] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isChecked]
GO
ALTER TABLE [dbo].[Lectures] ADD  DEFAULT ((0)) FOR [index]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Decentralizations_decentralizationId] FOREIGN KEY([decentralizationId])
REFERENCES [dbo].[Decentralizations] ([decentralizationID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Decentralizations_decentralizationId]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions_questionID] FOREIGN KEY([questionID])
REFERENCES [dbo].[Questions] ([questionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions_questionID]
GO
ALTER TABLE [dbo].[CourseParts]  WITH CHECK ADD  CONSTRAINT [FK_CourseParts_Courses_courseID] FOREIGN KEY([courseID])
REFERENCES [dbo].[Courses] ([courseID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseParts] CHECK CONSTRAINT [FK_CourseParts_Courses_courseID]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Tutors_tutorID] FOREIGN KEY([tutorID])
REFERENCES [dbo].[Tutors] ([tutorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Tutors_tutorID]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollments_StatusTypes_statusTypeID] FOREIGN KEY([statusTypeID])
REFERENCES [dbo].[StatusTypes] ([statusTypeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enrollments_StatusTypes_statusTypeID]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollments_Students_studentID] FOREIGN KEY([studentID])
REFERENCES [dbo].[Students] ([studentID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enrollments_Students_studentID]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_CourseParts_coursePartID] FOREIGN KEY([coursePartID])
REFERENCES [dbo].[CourseParts] ([coursePartID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_CourseParts_coursePartID]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_ExamTypes_examTypeID] FOREIGN KEY([examTypeID])
REFERENCES [dbo].[ExamTypes] ([examTypeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_ExamTypes_examTypeID]
GO
ALTER TABLE [dbo].[Fees]  WITH CHECK ADD  CONSTRAINT [FK_Fees_Students_studentID] FOREIGN KEY([studentID])
REFERENCES [dbo].[Students] ([studentID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Fees] CHECK CONSTRAINT [FK_Fees_Students_studentID]
GO
ALTER TABLE [dbo].[Lectures]  WITH CHECK ADD  CONSTRAINT [FK_Lectures_CourseParts_coursePartID] FOREIGN KEY([coursePartID])
REFERENCES [dbo].[CourseParts] ([coursePartID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lectures] CHECK CONSTRAINT [FK_Lectures_CourseParts_coursePartID]
GO
ALTER TABLE [dbo].[PaymentHistorys]  WITH CHECK ADD  CONSTRAINT [FK_PaymentHistorys_PaymentTypes_paymentTypeID] FOREIGN KEY([paymentTypeID])
REFERENCES [dbo].[PaymentTypes] ([paymentTypeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaymentHistorys] CHECK CONSTRAINT [FK_PaymentHistorys_PaymentTypes_paymentTypeID]
GO
ALTER TABLE [dbo].[PaymentHistorys]  WITH CHECK ADD  CONSTRAINT [FK_PaymentHistorys_Students_studentID] FOREIGN KEY([studentID])
REFERENCES [dbo].[Students] ([studentID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaymentHistorys] CHECK CONSTRAINT [FK_PaymentHistorys_Students_studentID]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Exams_examID] FOREIGN KEY([examID])
REFERENCES [dbo].[Exams] ([examID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Exams_examID]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Accounts_accountID] FOREIGN KEY([accountID])
REFERENCES [dbo].[Accounts] ([accountID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Accounts_accountID]
GO
ALTER TABLE [dbo].[Submissions]  WITH CHECK ADD  CONSTRAINT [FK_Submissions_Students_studentID] FOREIGN KEY([studentID])
REFERENCES [dbo].[Students] ([studentID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Submissions] CHECK CONSTRAINT [FK_Submissions_Students_studentID]
GO
ALTER TABLE [dbo].[TutorAssignments]  WITH CHECK ADD  CONSTRAINT [FK_TutorAssignments_Tutors_tutorID] FOREIGN KEY([tutorID])
REFERENCES [dbo].[Tutors] ([tutorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TutorAssignments] CHECK CONSTRAINT [FK_TutorAssignments_Tutors_tutorID]
GO
ALTER TABLE [dbo].[Tutors]  WITH CHECK ADD  CONSTRAINT [FK_Tutors_Accounts_accountID] FOREIGN KEY([accountID])
REFERENCES [dbo].[Accounts] ([accountID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tutors] CHECK CONSTRAINT [FK_Tutors_Accounts_accountID]
GO
USE [master]
GO
ALTER DATABASE [QLKH] SET  READ_WRITE 
GO