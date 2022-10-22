USE [master]
GO
/****** Object:  Database [Mr.Peliculas]    Script Date: 22/10/2022 00:22:41 ******/
CREATE DATABASE [Mr.Peliculas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mr.Peliculas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Mr.Peliculas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Mr.Peliculas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Mr.Peliculas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [Mr.Peliculas] SET QUERY_STORE = OFF
GO
USE [Mr.Peliculas]
GO
/****** Object:  Table [dbo].[Comentarios]    Script Date: 22/10/2022 00:22:41 ******/
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
/****** Object:  Table [dbo].[GeneroPorPelicula]    Script Date: 22/10/2022 00:22:41 ******/
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
/****** Object:  Table [dbo].[Generos]    Script Date: 22/10/2022 00:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Generos](
	[IdGenero] [int] IDENTITY(1,1) NOT NULL,
	[Genero] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Generos] PRIMARY KEY CLUSTERED 
(
	[IdGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Peliculas]    Script Date: 22/10/2022 00:22:41 ******/
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
 CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED 
(
	[IdPelicula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 22/10/2022 00:22:41 ******/
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
/****** Object:  Table [dbo].[Videos]    Script Date: 22/10/2022 00:22:41 ******/
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
