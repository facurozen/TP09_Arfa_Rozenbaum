USE [master]
GO
/****** Object:  Database [Mr.Peliculas]    Script Date: 27/10/2022 11:24:37 ******/
CREATE DATABASE [Mr.Peliculas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mr.Peliculas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Mr.Peliculas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Mr.Peliculas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Mr.Peliculas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Mr.Peliculas] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mr.Peliculas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mr.Peliculas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mr.Peliculas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mr.Peliculas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Mr.Peliculas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mr.Peliculas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Mr.Peliculas] SET  MULTI_USER 
GO
ALTER DATABASE [Mr.Peliculas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mr.Peliculas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mr.Peliculas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mr.Peliculas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Mr.Peliculas] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Mr.Peliculas', N'ON'
GO
ALTER DATABASE [Mr.Peliculas] SET QUERY_STORE = OFF
GO
USE [Mr.Peliculas]
GO
/****** Object:  User [alumno]    Script Date: 27/10/2022 11:24:38 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Comentarios]    Script Date: 27/10/2022 11:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentarios](
	[IdComentario] [int] IDENTITY(1,1) NOT NULL,
	[IdPelicula] [int] NOT NULL,
	[Texto] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Comentarios] PRIMARY KEY CLUSTERED 
(
	[IdComentario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneroPorPelicula]    Script Date: 27/10/2022 11:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneroPorPelicula](
	[IdGeneroPelicula] [int] IDENTITY(1,1) NOT NULL,
	[IdGenero] [int] NOT NULL,
	[IdPelicula] [int] NOT NULL,
 CONSTRAINT [PK_GeneroPorPelicula] PRIMARY KEY CLUSTERED 
(
	[IdGeneroPelicula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Generos]    Script Date: 27/10/2022 11:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Generos](
	[IdGenero] [int] IDENTITY(1,1) NOT NULL,
	[NombreGenero] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Generos] PRIMARY KEY CLUSTERED 
(
	[IdGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Peliculas]    Script Date: 27/10/2022 11:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Peliculas](
	[IdPelicula] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Portada] [varchar](200) NOT NULL,
	[Sinopsis] [varchar](200) NOT NULL,
	[Duracion] [time](7) NOT NULL,
	[Año] [int] NOT NULL,
	[IdGenero] [int] NOT NULL,
	[CantLikes] [int] NULL,
 CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED 
(
	[IdPelicula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 27/10/2022 11:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Videos]    Script Date: 27/10/2022 11:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videos](
	[IdVideo] [int] IDENTITY(1,1) NOT NULL,
	[ArchivoVideo] [varchar](200) NOT NULL,
	[Duracion] [time](7) NOT NULL,
	[IdPelicula] [int] NULL,
 CONSTRAINT [PK_Videos] PRIMARY KEY CLUSTERED 
(
	[IdVideo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Generos] ON 

INSERT [dbo].[Generos] ([IdGenero], [NombreGenero]) VALUES (1, N'Acción')
INSERT [dbo].[Generos] ([IdGenero], [NombreGenero]) VALUES (2, N'Aventura')
INSERT [dbo].[Generos] ([IdGenero], [NombreGenero]) VALUES (3, N'Drama')
INSERT [dbo].[Generos] ([IdGenero], [NombreGenero]) VALUES (4, N'Ciencia Ficción')
INSERT [dbo].[Generos] ([IdGenero], [NombreGenero]) VALUES (5, N'Comedia')
INSERT [dbo].[Generos] ([IdGenero], [NombreGenero]) VALUES (6, N'Terror')
SET IDENTITY_INSERT [dbo].[Generos] OFF
GO
SET IDENTITY_INSERT [dbo].[Peliculas] ON 

INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (1, N'Rocky III', N'Rockyiii.png', N'dsgfsdg', CAST(N'03:02:00' AS Time), 1970, 1, 11)
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (2, N'Rocky II', N'rockyii.png', N'dggd', CAST(N'03:06:00' AS Time), 1980, 1, 9)
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (5, N'Rocky I', N'Rocky1.png', N'dggd', CAST(N'02:03:00' AS Time), 1970, 1, 4)
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (6, N'Madagascar', N'madagascar.png', N'safaf', CAST(N'02:01:00' AS Time), 2005, 2, 4)
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (8, N'Free Guy', N'freeguy.png', N'adD', CAST(N'02:02:00' AS Time), 2022, 2, 2)
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (9, N'Golpe Bajo', N'golpebajo.png', N'adssad', CAST(N'02:10:00' AS Time), 2010, 5, 5)
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (10, N'Rambo', N'Rambo.png', N'asfsaf', CAST(N'03:02:00' AS Time), 1980, 1, 2)
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (11, N'21 Blackjack', N'21blackjack.png', N'safafas', CAST(N'02:02:00' AS Time), 2000, 3, 3)
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (12, N'Jurassic Park', N'jurassic.png', N'dfsfs', CAST(N'02:04:00' AS Time), 2010, 4, 0)
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (13, N'Chucky', N'chucky.png', N'sdsgsg', CAST(N'02:04:00' AS Time), 2000, 6, 0)
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (14, N'Pixeles', N'pixels.png', N'safsadfd', CAST(N'02:30:00' AS Time), 2015, 2, 0)
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (15, N'Garra', N'garra.png', N'dsfsf', CAST(N'02:10:00' AS Time), 2022, 3, 0)
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (16, N'Volver al Futuro', N'volveralfuturo.png', N'safdsfds', CAST(N'02:40:00' AS Time), 1990, 4, 0)
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (17, N'Misterio a Bordo', N'Murder_mystery.png', N'awsfsed', CAST(N'02:40:00' AS Time), 2020, 5, 0)
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (18, N'El Conjuro', N'conjuro.png', N'dsgdsfg', CAST(N'02:30:00' AS Time), 2000, 6, 0)
INSERT [dbo].[Peliculas] ([IdPelicula], [Nombre], [Portada], [Sinopsis], [Duracion], [Año], [IdGenero], [CantLikes]) VALUES (19, N'Quieren Volverme Loco', N'quierenVolvermeLoco.png', N'asfdsaf', CAST(N'02:10:00' AS Time), 2005, 5, 0)
SET IDENTITY_INSERT [dbo].[Peliculas] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Nombre], [Email], [Contraseña]) VALUES (1, N'Administrador', N'admin@gmail.com', N'administrador')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Comentarios]  WITH CHECK ADD  CONSTRAINT [FK_Comentarios_Peliculas] FOREIGN KEY([IdPelicula])
REFERENCES [dbo].[Peliculas] ([IdPelicula])
GO
ALTER TABLE [dbo].[Comentarios] CHECK CONSTRAINT [FK_Comentarios_Peliculas]
GO
ALTER TABLE [dbo].[GeneroPorPelicula]  WITH CHECK ADD  CONSTRAINT [FK_GeneroPorPelicula_Generos] FOREIGN KEY([IdGenero])
REFERENCES [dbo].[Generos] ([IdGenero])
GO
ALTER TABLE [dbo].[GeneroPorPelicula] CHECK CONSTRAINT [FK_GeneroPorPelicula_Generos]
GO
ALTER TABLE [dbo].[GeneroPorPelicula]  WITH CHECK ADD  CONSTRAINT [FK_GeneroPorPelicula_Peliculas] FOREIGN KEY([IdPelicula])
REFERENCES [dbo].[Peliculas] ([IdPelicula])
GO
ALTER TABLE [dbo].[GeneroPorPelicula] CHECK CONSTRAINT [FK_GeneroPorPelicula_Peliculas]
GO
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Peliculas] FOREIGN KEY([IdPelicula])
REFERENCES [dbo].[Peliculas] ([IdPelicula])
GO
ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Peliculas]
GO
USE [master]
GO
ALTER DATABASE [Mr.Peliculas] SET  READ_WRITE 
GO
