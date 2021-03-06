USE [master]
GO
/****** Object:  Database [FincaAPI]    Script Date: 12/12/2021 11:12:29 ******/
CREATE DATABASE [FincaAPI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FincaAPI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FincaAPI.mdf' , SIZE = 139264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FincaAPI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FincaAPI_log.ldf' , SIZE = 401408KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FincaAPI] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FincaAPI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FincaAPI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FincaAPI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FincaAPI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FincaAPI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FincaAPI] SET ARITHABORT OFF 
GO
ALTER DATABASE [FincaAPI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FincaAPI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FincaAPI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FincaAPI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FincaAPI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FincaAPI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FincaAPI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FincaAPI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FincaAPI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FincaAPI] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FincaAPI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FincaAPI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FincaAPI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FincaAPI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FincaAPI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FincaAPI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FincaAPI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FincaAPI] SET RECOVERY FULL 
GO
ALTER DATABASE [FincaAPI] SET  MULTI_USER 
GO
ALTER DATABASE [FincaAPI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FincaAPI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FincaAPI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FincaAPI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FincaAPI] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FincaAPI] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FincaAPI', N'ON'
GO
ALTER DATABASE [FincaAPI] SET QUERY_STORE = OFF
GO
USE [FincaAPI]
GO
/****** Object:  Schema [BDFincaAPI]    Script Date: 12/12/2021 11:12:29 ******/
CREATE SCHEMA [BDFincaAPI]
GO
/****** Object:  Table [dbo].[Animales]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Animales](
	[AnimalId] [int] IDENTITY(1,1) NOT NULL,
	[AnimalNumeroId] [int] NOT NULL,
	[AnimalColorId] [int] NOT NULL,
	[AnimalGeneroId] [int] NOT NULL,
	[AnimalEntradaConceptoId] [int] NOT NULL,
	[AnimalEntradaFecha] [date] NOT NULL,
	[AnimalEntradaPeso] [decimal](18, 2) NOT NULL,
	[AnimalEntradaPrecio] [decimal](18, 2) NOT NULL,
	[AnimalSalidaConceptoId] [int] NULL,
	[AnimalSalidaFecha] [datetime] NULL,
	[AnimalSalidaPeso] [decimal](18, 2) NULL,
	[AnimalSalidaPrecio] [decimal](18, 2) NULL,
	[AnimalConsumoMonto] [decimal](18, 2) NULL,
	[AnimalGananciaMonto] [decimal](18, 2) NULL,
	[AnimalGananciaPorcentaje] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Animales] PRIMARY KEY CLUSTERED 
(
	[AnimalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[BitacoraId] [int] IDENTITY(1,1) NOT NULL,
	[Mensaje] [varchar](500) NULL,
	[ActionName] [varchar](50) NULL,
	[Controller] [varchar](50) NULL,
	[Fecha] [datetime] NULL,
	[UsuarioId] [int] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[BitacoraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colores]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colores](
	[ColorId] [int] IDENTITY(1,1) NOT NULL,
	[ColorNombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Colores] PRIMARY KEY CLUSTERED 
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntradaConceptos]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntradaConceptos](
	[EntradaConceptoId] [int] IDENTITY(1,1) NOT NULL,
	[EntradaConceptoNombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EntradaConceptos] PRIMARY KEY CLUSTERED 
(
	[EntradaConceptoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Generos]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Generos](
	[GeneroId] [int] IDENTITY(1,1) NOT NULL,
	[GeneroNombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Generos] PRIMARY KEY CLUSTERED 
(
	[GeneroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Numeros]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Numeros](
	[NumeroId] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [int] NOT NULL,
	[NumeroEstado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Numeros] PRIMARY KEY CLUSTERED 
(
	[NumeroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RolId] [int] IDENTITY(1,1) NOT NULL,
	[RolNombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalidaConceptos]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalidaConceptos](
	[SalidaConceptoId] [int] IDENTITY(1,1) NOT NULL,
	[SalidaConceptoNombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SalidaConceptos] PRIMARY KEY CLUSTERED 
(
	[SalidaConceptoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[UsuarioNombre] [varchar](50) NOT NULL,
	[UsuarioApPaterno] [varchar](50) NULL,
	[UsuarioApMaterno] [varchar](50) NULL,
	[UsuarioEmail] [varchar](50) NULL,
	[RolId] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Animales]  WITH CHECK ADD  CONSTRAINT [FK_Animales_Colores] FOREIGN KEY([AnimalColorId])
REFERENCES [dbo].[Colores] ([ColorId])
GO
ALTER TABLE [dbo].[Animales] CHECK CONSTRAINT [FK_Animales_Colores]
GO
ALTER TABLE [dbo].[Animales]  WITH CHECK ADD  CONSTRAINT [FK_Animales_EntradaConceptos] FOREIGN KEY([AnimalEntradaConceptoId])
REFERENCES [dbo].[EntradaConceptos] ([EntradaConceptoId])
GO
ALTER TABLE [dbo].[Animales] CHECK CONSTRAINT [FK_Animales_EntradaConceptos]
GO
ALTER TABLE [dbo].[Animales]  WITH CHECK ADD  CONSTRAINT [FK_Animales_Generos] FOREIGN KEY([AnimalGeneroId])
REFERENCES [dbo].[Generos] ([GeneroId])
GO
ALTER TABLE [dbo].[Animales] CHECK CONSTRAINT [FK_Animales_Generos]
GO
ALTER TABLE [dbo].[Animales]  WITH CHECK ADD  CONSTRAINT [FK_Animales_Numeros] FOREIGN KEY([AnimalNumeroId])
REFERENCES [dbo].[Numeros] ([NumeroId])
GO
ALTER TABLE [dbo].[Animales] CHECK CONSTRAINT [FK_Animales_Numeros]
GO
ALTER TABLE [dbo].[Animales]  WITH CHECK ADD  CONSTRAINT [FK_Animales_SalidaConceptos] FOREIGN KEY([AnimalSalidaConceptoId])
REFERENCES [dbo].[SalidaConceptos] ([SalidaConceptoId])
GO
ALTER TABLE [dbo].[Animales] CHECK CONSTRAINT [FK_Animales_SalidaConceptos]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_Usuarios] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([UsuarioId])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_Usuarios]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([RolId])
REFERENCES [dbo].[Roles] ([RolId])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
/****** Object:  StoredProcedure [dbo].[Consultar_Numeros_Disponibles]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Consultar_Numeros_Disponibles]
AS
BEGIN
	SELECT * FROM [dbo].[Numeros] where NumeroEstado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[ListarAnimales]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarAnimales]
AS
BEGIN
SELECT
	Animales.AnimalId, 
	Animales.AnimalNumeroId,
	Numeros.Numero, 
	Generos.GeneroNombre, 
	Colores.ColorNombre, 
	Animales.AnimalEntradaFecha, 
	EntradaConceptos.EntradaConceptoNombre, 
	Animales.AnimalEntradaPeso, 
	Animales.AnimalEntradaPrecio, 
	SalidaConceptos.SalidaConceptoNombre, 
	Animales.AnimalSalidaFecha, 
	Animales.AnimalSalidaPeso, 
	Animales.AnimalSalidaPrecio
FROM
	dbo.Animales
	INNER JOIN
	dbo.Numeros
	ON 
		Animales.AnimalNumeroId = Numeros.NumeroId
	INNER JOIN
	dbo.Colores
	ON 
		Animales.AnimalColorId = Colores.ColorId
	INNER JOIN
	dbo.EntradaConceptos
	ON 
		Animales.AnimalEntradaConceptoId = EntradaConceptos.EntradaConceptoId
	INNER JOIN
	dbo.Generos
	ON 
		Animales.AnimalGeneroId = Generos.GeneroId
	INNER JOIN
	dbo.SalidaConceptos
	ON 
		Animales.AnimalSalidaConceptoId = SalidaConceptos.SalidaConceptoId
END
GO
/****** Object:  StoredProcedure [dbo].[ListarNumerosDisponibles]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarNumerosDisponibles]
@numeroId int
AS
BEGIN
Select * from Numeros
where NumeroEstado = 1 or NumeroId = @numeroId
END
GO
/****** Object:  StoredProcedure [dbo].[ListarTablaAnimales]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarTablaAnimales]
AS
BEGIN
SELECT
	Animales.AnimalId, 
	Animales.AnimalNumeroId, 
	Animales.AnimalColorId, 
	Animales.AnimalGeneroId, 
	Animales.AnimalEntradaConceptoId, 
	Animales.AnimalEntradaFecha, 
	Animales.AnimalEntradaPeso, 
	Animales.AnimalEntradaPrecio, 
	Animales.AnimalSalidaConceptoId, 
	Animales.AnimalSalidaFecha, 
	Animales.AnimalSalidaPeso, 
	Animales.AnimalSalidaPrecio, 
	Animales.AnimalConsumoMonto, 
	Animales.AnimalGananciaMonto, 
	Animales.AnimalGananciaPorcentaje
FROM
	dbo.Animales
END
GO
/****** Object:  StoredProcedure [dbo].[Registrar_Bitacora]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Registrar_Bitacora]
	@mensaje varchar (500),
	@accion varchar (50),
	@controlador varchar (50),
	@usuario varchar (50)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Bitacora] (Mensaje, ActionName, Controller, FechaError, UsuarioId)
	VALUES (@mensaje, @accion, @controlador, SYSDATETIME(), @usuario)
END
GO
/****** Object:  StoredProcedure [dbo].[Registrar_CONSUMO]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Registrar_CONSUMO]	
	@idNumero int,
	@monto decimal(18,2)
AS
BEGIN
	UPDATE Animales SET AnimalConsumoMonto = AnimalConsumoMonto+ @monto WHERE AnimalNumeroId = @idNumero AND AnimalSalidaConceptoId = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarSalida]    Script Date: 12/12/2021 11:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarSalida]
	@numeroId int,
	@salidaConceptoId int,
	@salidaFecha DateTime,
	@salidaPeso decimal(18,2),
	@salidaPrecio decimal(18,2)
AS
BEGIN
UPDATE Animales SET AnimalSalidaConceptoId = @salidaConceptoId, AnimalSalidaFecha = @salidaFecha,
					AnimalSalidaPeso = @salidaPeso, AnimalSalidaPrecio = @salidaPrecio, AnimalGananciaMonto= (@salidaPrecio-(AnimalEntradaPrecio+AnimalConsumoMonto))
WHERE AnimalNumeroId = @numeroId;

UPDATE Animales SET AnimalGananciaPorcentaje= ((AnimalGananciaMonto/AnimalSalidaPrecio)*100)
WHERE AnimalNumeroId = @numeroId;

UPDATE Numeros SET NumeroEstado = 'Disponible'
WHERE NumeroId = @numeroId
END
GO
USE [master]
GO
ALTER DATABASE [FincaAPI] SET  READ_WRITE 
GO
