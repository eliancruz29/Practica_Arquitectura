use [master]
go

IF DB_Id('PracticaArquitectura') IS NOT NULL
BEGIN
	DROP DATABASE [PracticaArquitectura]
END
go

CREATE DATABASE [PracticaArquitectura]
go

USE [PracticaArquitectura]
GO

/****** Object:  Table [dbo].[Peticiones]    Script Date: 3/21/2017 12:27:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Peticiones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](30) NOT NULL,
	[Apellido] [nvarchar](30) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](10) NOT NULL,
	[Cedula] [nvarchar](11) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Peticion] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Peticiones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PeticionesNoProcesadas]    Script Date: 3/21/2017 12:36:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PeticionesNoProcesadas](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](30) NOT NULL,
	[Apellido] [nvarchar](30) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](10) NOT NULL,
	[Cedula] [nvarchar](11) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Peticion] [nvarchar](1000) NOT NULL
) ON [PRIMARY]

GO
