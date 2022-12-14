USE [master]
GO
/****** Object:  Database [DBernalExamenSQLClient]    Script Date: 12/11/2022 3:34:36 PM ******/
CREATE DATABASE [DBernalExamenSQLClient]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBernalExamenSQLClient', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBernalExamenSQLClient.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBernalExamenSQLClient_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBernalExamenSQLClient_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DBernalExamenSQLClient] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBernalExamenSQLClient].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBernalExamenSQLClient] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET RECOVERY FULL 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET  MULTI_USER 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBernalExamenSQLClient] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBernalExamenSQLClient] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DBernalExamenSQLClient]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 12/11/2022 3:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[IdAutor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED 
(
	[IdAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Editorial]    Script Date: 12/11/2022 3:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Editorial](
	[IdEditorial] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Editorial] PRIMARY KEY CLUSTERED 
(
	[IdEditorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 12/11/2022 3:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[IdGenero] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Genero] PRIMARY KEY CLUSTERED 
(
	[IdGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 12/11/2022 3:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[IdLibro] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[IdAutor] [int] NULL,
	[NumeroPaginas] [int] NULL,
	[FechaPublicacion] [date] NULL,
	[IdEditorial] [int] NULL,
	[Edicion] [varchar](50) NULL,
	[IdGenero] [int] NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Autor] ON 

INSERT [dbo].[Autor] ([IdAutor], [Nombre]) VALUES (1, N'Tony Robbins')
INSERT [dbo].[Autor] ([IdAutor], [Nombre]) VALUES (2, N'Dale Carnegie')
INSERT [dbo].[Autor] ([IdAutor], [Nombre]) VALUES (3, N'Tim Ferriss')
INSERT [dbo].[Autor] ([IdAutor], [Nombre]) VALUES (4, N'Robert Kiyosaki')
INSERT [dbo].[Autor] ([IdAutor], [Nombre]) VALUES (5, N'Daniel Goleman')
INSERT [dbo].[Autor] ([IdAutor], [Nombre]) VALUES (6, N'Eckhart Tolle')
SET IDENTITY_INSERT [dbo].[Autor] OFF
GO
SET IDENTITY_INSERT [dbo].[Editorial] ON 

INSERT [dbo].[Editorial] ([IdEditorial], [Nombre]) VALUES (1, N'Salamandra')
INSERT [dbo].[Editorial] ([IdEditorial], [Nombre]) VALUES (2, N'Libro feliz')
INSERT [dbo].[Editorial] ([IdEditorial], [Nombre]) VALUES (3, N'Panini')
INSERT [dbo].[Editorial] ([IdEditorial], [Nombre]) VALUES (4, N'Free Books')
INSERT [dbo].[Editorial] ([IdEditorial], [Nombre]) VALUES (5, N'Portal Books')
INSERT [dbo].[Editorial] ([IdEditorial], [Nombre]) VALUES (6, N'History')
SET IDENTITY_INSERT [dbo].[Editorial] OFF
GO
SET IDENTITY_INSERT [dbo].[Genero] ON 

INSERT [dbo].[Genero] ([IdGenero], [Nombre]) VALUES (1, N'Terror')
INSERT [dbo].[Genero] ([IdGenero], [Nombre]) VALUES (2, N'Aventura')
INSERT [dbo].[Genero] ([IdGenero], [Nombre]) VALUES (3, N'Novela Romantica')
INSERT [dbo].[Genero] ([IdGenero], [Nombre]) VALUES (4, N'Autoayuda')
INSERT [dbo].[Genero] ([IdGenero], [Nombre]) VALUES (5, N'Suspenso')
INSERT [dbo].[Genero] ([IdGenero], [Nombre]) VALUES (6, N'Obra Literaria')
SET IDENTITY_INSERT [dbo].[Genero] OFF
GO
SET IDENTITY_INSERT [dbo].[Libro] ON 

INSERT [dbo].[Libro] ([IdLibro], [Nombre], [IdAutor], [NumeroPaginas], [FechaPublicacion], [IdEditorial], [Edicion], [IdGenero]) VALUES (1, N'Poder sin limites', 2, 200, CAST(N'1992-01-01' AS Date), 6, N'Standar Version', 4)
INSERT [dbo].[Libro] ([IdLibro], [Nombre], [IdAutor], [NumeroPaginas], [FechaPublicacion], [IdEditorial], [Edicion], [IdGenero]) VALUES (2, N'Inteligencia emocional', 5, 300, CAST(N'1982-01-01' AS Date), 1, N'Deluxe Edition', 6)
INSERT [dbo].[Libro] ([IdLibro], [Nombre], [IdAutor], [NumeroPaginas], [FechaPublicacion], [IdEditorial], [Edicion], [IdGenero]) VALUES (4, N'Habitos Atomicos', 3, 180, CAST(N'2000-03-02' AS Date), 2, N'American Version', 4)
INSERT [dbo].[Libro] ([IdLibro], [Nombre], [IdAutor], [NumeroPaginas], [FechaPublicacion], [IdEditorial], [Edicion], [IdGenero]) VALUES (5, N'El poder del ahora', 6, 400, CAST(N'2000-01-05' AS Date), 5, N'Spain Version', 6)
INSERT [dbo].[Libro] ([IdLibro], [Nombre], [IdAutor], [NumeroPaginas], [FechaPublicacion], [IdEditorial], [Edicion], [IdGenero]) VALUES (7, N'Harry Potter', 5, 600, CAST(N'2022-03-04' AS Date), 3, N'Salamandra', 2)
SET IDENTITY_INSERT [dbo].[Libro] OFF
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Autor] FOREIGN KEY([IdAutor])
REFERENCES [dbo].[Autor] ([IdAutor])
GO
ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Autor]
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Editorial] FOREIGN KEY([IdEditorial])
REFERENCES [dbo].[Editorial] ([IdEditorial])
GO
ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Editorial]
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD  CONSTRAINT [FK_Genero] FOREIGN KEY([IdGenero])
REFERENCES [dbo].[Genero] ([IdGenero])
GO
ALTER TABLE [dbo].[Libro] CHECK CONSTRAINT [FK_Genero]
GO
/****** Object:  StoredProcedure [dbo].[AutorGet]    Script Date: 12/11/2022 3:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AutorGet]
	@IdAutor INT = NULL 
AS
BEGIN
	SELECT [IdAutor]
      ,[Nombre]
	FROM [dbo].[Autor]
	WHERE @IdAutor IS NULL OR IdAutor = @IdAutor
END
GO
/****** Object:  StoredProcedure [dbo].[EditorialGet]    Script Date: 12/11/2022 3:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditorialGet]
	@IdEditorial INT = NULL 
AS
BEGIN
	SELECT [IdEditorial]
      ,[Nombre]
	FROM [dbo].[Editorial]
	WHERE @IdEditorial IS NULL OR IdEditorial = @IdEditorial
END
GO
/****** Object:  StoredProcedure [dbo].[GeneroGet]    Script Date: 12/11/2022 3:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GeneroGet]
	@IdGenero INT = NULL 
AS
BEGIN	
	SELECT [IdGenero]
		,[Nombre]
	FROM [dbo].[Genero]
	WHERE @IdGenero IS NULL OR IdGenero = @IdGenero
END
GO
/****** Object:  StoredProcedure [dbo].[LibroAdd]    Script Date: 12/11/2022 3:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LibroAdd]
	--IdLibro INT IDENTITY(1,1),
	@Nombre VARCHAR(50),
	@IdAutor INT,
	@NumeroPaginas INT,
	@FechaPublicacion VARCHAR(20),
	@IdEditorial INT,
	@Edicion VARCHAR(50),
	@IdGenero INT
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
		
			INSERT INTO [dbo].[Libro]
			   ([Nombre]
			   ,[IdAutor]
			   ,[NumeroPaginas]
			   ,[FechaPublicacion]
			   ,[IdEditorial]
			   ,[Edicion]
			   ,[IdGenero])
		 VALUES
			   (@Nombre, 
			   @IdAutor, 
			   @NumeroPaginas, 
			   CONVERT(DATE, @FechaPublicacion, 103),
			   @IdEditorial,
			   @Edicion, 
			   @IdGenero)
		
			COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH
	
END

GO
/****** Object:  StoredProcedure [dbo].[LibroDelete]    Script Date: 12/11/2022 3:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LibroDelete]
	@IdLibro INT
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
		IF EXISTS (SELECT IdLibro FROM Libro WHERE IdLibro = @IdLibro)
			BEGIN
				DELETE FROM [dbo].[Libro]
				WHERE IdLibro = @IdLibro
				COMMIT
			END
		ELSE 
			BEGIN
				ROLLBACK
			END
		END TRY
		BEGIN CATCH 
			ROLLBACK
		END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[LibroGet]    Script Date: 12/11/2022 3:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LibroGet] 
	@IdLibro INT = NULL
AS
BEGIN
	SELECT [IdLibro]
      ,L.[Nombre]
      ,L.[IdAutor]
      ,L.[NumeroPaginas]
      ,L.[FechaPublicacion]
      ,L.[IdEditorial]
      ,L.[Edicion]
      ,L.[IdGenero]

	  ,A.Nombre AS AutorNombre

	  ,E.Nombre AS EditorialNombre

	  ,G.Nombre AS GeneroNombre

  FROM [dbo].[Libro] AS L
  INNER JOIN Autor AS A ON L.IdAutor = A.IdAutor
  INNER JOIN Editorial AS E ON L.IdEditorial = E.IdEditorial
  INNER JOIN Genero AS G ON L.[IdGenero] = G.IdGenero
  WHERE @IdLibro IS NULL OR L.IdLibro = @IdLibro


END

GO
/****** Object:  StoredProcedure [dbo].[LibroUpdate]    Script Date: 12/11/2022 3:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LibroUpdate]
	@IdLibro INT,
	@Nombre VARCHAR(50),
	@IdAutor INT,
	@NumeroPaginas INT,
	@FechaPublicacion VARCHAR(20),
	@IdEditorial INT,
	@Edicion VARCHAR(50),
	@IdGenero INT
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
		IF EXISTS (SELECT IdLibro FROM Libro WHERE IdLibro = @IdLibro)
			BEGIN
				UPDATE [dbo].[Libro]
				SET [Nombre] = @Nombre
					,[IdAutor] = @IdAutor
					,[NumeroPaginas] = @NumeroPaginas
					,[FechaPublicacion] = CONVERT(DATE, @FechaPublicacion, 103)
					,[IdEditorial] = @IdEditorial
					,[Edicion] = @Edicion
					,[IdGenero] = @IdGenero
				WHERE IdLibro = @IdLibro
				COMMIT
			END
		ELSE 
			BEGIN
				ROLLBACK
			END
		END TRY
		BEGIN CATCH 
			ROLLBACK
		END CATCH

END

GO
USE [master]
GO
ALTER DATABASE [DBernalExamenSQLClient] SET  READ_WRITE 
GO
