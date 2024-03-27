USE [master]
GO
/****** Object:  Database [MusicSchool]    Script Date: 27.03.2024 5:07:16 ******/
CREATE DATABASE [MusicSchool]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MusicSchool', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MusicSchool.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MusicSchool_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MusicSchool_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MusicSchool] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MusicSchool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MusicSchool] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MusicSchool] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MusicSchool] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MusicSchool] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MusicSchool] SET ARITHABORT OFF 
GO
ALTER DATABASE [MusicSchool] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MusicSchool] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MusicSchool] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MusicSchool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MusicSchool] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MusicSchool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MusicSchool] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MusicSchool] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MusicSchool] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MusicSchool] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MusicSchool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MusicSchool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MusicSchool] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MusicSchool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MusicSchool] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MusicSchool] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MusicSchool] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MusicSchool] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MusicSchool] SET  MULTI_USER 
GO
ALTER DATABASE [MusicSchool] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MusicSchool] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MusicSchool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MusicSchool] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MusicSchool] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MusicSchool] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MusicSchool] SET QUERY_STORE = ON
GO
ALTER DATABASE [MusicSchool] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MusicSchool]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 27.03.2024 5:07:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Courses_ID] [int] IDENTITY(1,1) NOT NULL,
	[Course_name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Courses_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Journal]    Script Date: 27.03.2024 5:07:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journal](
	[Journal_ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Lesson] [int] NOT NULL,
	[Date_lesson] [datetime] NOT NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[Journal_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 27.03.2024 5:07:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[Lesson_ID] [int] IDENTITY(1,1) NOT NULL,
	[Lesson_name] [nvarchar](50) NULL,
	[ID_courses] [int] NOT NULL,
	[TextContent] [nvarchar](max) NULL,
	[MediaContent] [nvarchar](max) NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[Lesson_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 27.03.2024 5:07:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[Post_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name_post] [nvarchar](50) NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[Post_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 27.03.2024 5:07:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Student_ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[Course_1] [bit] NULL,
	[Course_2] [bit] NULL,
	[Course_3] [bit] NULL,
	[Telephone_number] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](80) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Student_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentsJournal]    Script Date: 27.03.2024 5:07:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsJournal](
	[ID_journal] [int] NOT NULL,
	[ID_student] [int] NOT NULL,
 CONSTRAINT [PK_StudentsJournal] PRIMARY KEY CLUSTERED 
(
	[ID_journal] ASC,
	[ID_student] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserJournal]    Script Date: 27.03.2024 5:07:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserJournal](
	[ID_user] [int] NOT NULL,
	[ID_journal] [int] NOT NULL,
 CONSTRAINT [PK_UserJournal_1] PRIMARY KEY CLUSTERED 
(
	[ID_user] ASC,
	[ID_journal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 27.03.2024 5:07:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Users_ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_post] [int] NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Users_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Courses_ID], [Course_name], [Description]) VALUES (1, N'Азы', N'На данном курсе вы познакомитесь с азами гитары')
INSERT [dbo].[Courses] ([Courses_ID], [Course_name], [Description]) VALUES (2, N'Продвинутый', N'На данном курсе вы научитесь играть на электро-гитарах')
INSERT [dbo].[Courses] ([Courses_ID], [Course_name], [Description]) VALUES (3, N'Мастер', N'На данном курсе вы уже будете писать свою музыку')
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Journal] ON 

INSERT [dbo].[Journal] ([Journal_ID], [ID_Lesson], [Date_lesson]) VALUES (1, 1, CAST(N'2024-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Journal] ([Journal_ID], [ID_Lesson], [Date_lesson]) VALUES (2, 1, CAST(N'2024-03-22T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Journal] OFF
GO
SET IDENTITY_INSERT [dbo].[Lessons] ON 

INSERT [dbo].[Lessons] ([Lesson_ID], [Lesson_name], [ID_courses], [TextContent], [MediaContent]) VALUES (1, N'Знакомство с гитарой', 1, NULL, NULL)
INSERT [dbo].[Lessons] ([Lesson_ID], [Lesson_name], [ID_courses], [TextContent], [MediaContent]) VALUES (2, N'Изучение первых аккордов', 1, NULL, NULL)
INSERT [dbo].[Lessons] ([Lesson_ID], [Lesson_name], [ID_courses], [TextContent], [MediaContent]) VALUES (3, N'Первая песня', 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Lessons] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([Post_ID], [Name_post]) VALUES (1, N'Admin')
INSERT [dbo].[Post] ([Post_ID], [Name_post]) VALUES (2, N'Teacher')
INSERT [dbo].[Post] ([Post_ID], [Name_post]) VALUES (3, N'test')
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Student_ID], [LastName], [FirstName], [MiddleName], [Course_1], [Course_2], [Course_3], [Telephone_number], [Address]) VALUES (1, N'Канищева', N'Дария', N'Дмитриевна', 1, 0, 0, N'+79030356363', N'Г. Тула, ул Пушкинская 32, кв 268')
INSERT [dbo].[Students] ([Student_ID], [LastName], [FirstName], [MiddleName], [Course_1], [Course_2], [Course_3], [Telephone_number], [Address]) VALUES (2, N'Хаустов', N'Тимофей', N'Викторович', 1, 0, 0, N'+78243828348', N'Г. Тула')
INSERT [dbo].[Students] ([Student_ID], [LastName], [FirstName], [MiddleName], [Course_1], [Course_2], [Course_3], [Telephone_number], [Address]) VALUES (3, N'Кирилов', N'Кирил', N'Кириллович', 1, 0, 0, N'+85384583479', N'no')
INSERT [dbo].[Students] ([Student_ID], [LastName], [FirstName], [MiddleName], [Course_1], [Course_2], [Course_3], [Telephone_number], [Address]) VALUES (4, N'Машинистов', N'Машинист', N'Машинистович', 1, 0, 0, N'+7425857837', N'yes')
INSERT [dbo].[Students] ([Student_ID], [LastName], [FirstName], [MiddleName], [Course_1], [Course_2], [Course_3], [Telephone_number], [Address]) VALUES (5, N'Кролёв', N'Артём', N'Николаевич', 1, 0, 0, N'+752387537', N'no')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
INSERT [dbo].[StudentsJournal] ([ID_journal], [ID_student]) VALUES (1, 1)
INSERT [dbo].[StudentsJournal] ([ID_journal], [ID_student]) VALUES (1, 2)
INSERT [dbo].[StudentsJournal] ([ID_journal], [ID_student]) VALUES (2, 1)
INSERT [dbo].[StudentsJournal] ([ID_journal], [ID_student]) VALUES (2, 2)
INSERT [dbo].[StudentsJournal] ([ID_journal], [ID_student]) VALUES (2, 3)
GO
INSERT [dbo].[UserJournal] ([ID_user], [ID_journal]) VALUES (2, 1)
INSERT [dbo].[UserJournal] ([ID_user], [ID_journal]) VALUES (2, 2)
INSERT [dbo].[UserJournal] ([ID_user], [ID_journal]) VALUES (5, 2)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (1, 1, N'Канищева', N'Дария', N'Дмитриевна', N'1234')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (2, 2, N'Митина', N'Екатерина', N'Владимировна', N'4321')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (3, 1, N'Алексей', N'Александр', N'Мишка', N'5234223')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (4, 1, N'Мишаня', N'Маша', N'Саша', N'1231')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (5, 2, N'Учителев', N'Учитель', N'Учительевич', N'543')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (6, 1, N'aaa', N'aaa', N'vvv', N'password')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (7, 1, N'aaa', N'aaa', N'vvv', N'password')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (8, 1, N'aaa', N'aaa', N'vvv', N'password')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (10, 1, N'test', N'test', N'ttt', N'ttt')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (11, 1, N'test', N'test', N'ttt', N'ttt')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (12, 1, N'test', N'test', N'ttt', N'ttt')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (13, 2, N'Тестик', N'Пестик', N'Шестик', N'Семестр')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (14, 1, N'string', N'string', N'string', N'string')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (15, 2, N'string', N'string', N'string', N'string')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (16, 1, N'string', N'string', N'string', N'aaaa')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (17, 1, N'zzzzzzzzz', N'zzzzzzzzzzzz', N'zzzzzzzz', N'zzzzzzzzzzzz')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (18, 1, N'zzzzzzzzz', N'zzzzzzzzzzzz', N'zzzzzzzz', N'zzzzzzzzzzzz')
INSERT [dbo].[Users] ([Users_ID], [ID_post], [LastName], [FirstName], [MiddleName], [Password]) VALUES (19, 1, N'zzzzzzzzz', N'zzzzzzzzzzzz', N'zzzzzzzz', N'zzzzzzzzzzzz')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [FK_Journal_Lessons] FOREIGN KEY([ID_Lesson])
REFERENCES [dbo].[Lessons] ([Lesson_ID])
GO
ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [FK_Journal_Lessons]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Lessons_Courses] FOREIGN KEY([ID_courses])
REFERENCES [dbo].[Courses] ([Courses_ID])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Lessons_Courses]
GO
ALTER TABLE [dbo].[StudentsJournal]  WITH CHECK ADD  CONSTRAINT [FK_StudentsJournal_Journal] FOREIGN KEY([ID_journal])
REFERENCES [dbo].[Journal] ([Journal_ID])
GO
ALTER TABLE [dbo].[StudentsJournal] CHECK CONSTRAINT [FK_StudentsJournal_Journal]
GO
ALTER TABLE [dbo].[StudentsJournal]  WITH CHECK ADD  CONSTRAINT [FK_StudentsJournal_Students] FOREIGN KEY([ID_student])
REFERENCES [dbo].[Students] ([Student_ID])
GO
ALTER TABLE [dbo].[StudentsJournal] CHECK CONSTRAINT [FK_StudentsJournal_Students]
GO
ALTER TABLE [dbo].[UserJournal]  WITH CHECK ADD  CONSTRAINT [FK_UserJournal_Journal] FOREIGN KEY([ID_journal])
REFERENCES [dbo].[Journal] ([Journal_ID])
GO
ALTER TABLE [dbo].[UserJournal] CHECK CONSTRAINT [FK_UserJournal_Journal]
GO
ALTER TABLE [dbo].[UserJournal]  WITH CHECK ADD  CONSTRAINT [FK_UserJournal_Users] FOREIGN KEY([ID_user])
REFERENCES [dbo].[Users] ([Users_ID])
GO
ALTER TABLE [dbo].[UserJournal] CHECK CONSTRAINT [FK_UserJournal_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Post] FOREIGN KEY([ID_post])
REFERENCES [dbo].[Post] ([Post_ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Post]
GO
USE [master]
GO
ALTER DATABASE [MusicSchool] SET  READ_WRITE 
GO
