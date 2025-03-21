USE [master]
GO
/****** Object:  Database [DBTienda]    Script Date: 12/3/2025 14:19:19 ******/
CREATE DATABASE [DBTienda]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBTienda', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DBTienda.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBTienda_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DBTienda_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DBTienda] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBTienda].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBTienda] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBTienda] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBTienda] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBTienda] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBTienda] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBTienda] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBTienda] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBTienda] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBTienda] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBTienda] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBTienda] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBTienda] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBTienda] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBTienda] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBTienda] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBTienda] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBTienda] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBTienda] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBTienda] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBTienda] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBTienda] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBTienda] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBTienda] SET RECOVERY FULL 
GO
ALTER DATABASE [DBTienda] SET  MULTI_USER 
GO
ALTER DATABASE [DBTienda] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBTienda] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBTienda] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBTienda] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBTienda] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBTienda] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBTienda', N'ON'
GO
ALTER DATABASE [DBTienda] SET QUERY_STORE = ON
GO
ALTER DATABASE [DBTienda] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DBTienda]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[IdMedida] [int] NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CorrelativoVenta]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CorrelativoVenta](
	[Serie] [varchar](3) NOT NULL,
	[Numero] [int] NOT NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Serie] ASC,
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[IdDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [int] NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[PrecioTotal] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medida]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medida](
	[IdMedida] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Abreviatura] [varchar](4) NOT NULL,
	[Equivalente] [varchar](4) NOT NULL,
	[Valor] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMedida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[IdMenu] [int] IDENTITY(1,1) NOT NULL,
	[NombreMenu] [varchar](50) NOT NULL,
	[IdMenuPadre] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuRol]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuRol](
	[IdMenuRol] [int] IDENTITY(1,1) NOT NULL,
	[IdMenu] [int] NULL,
	[IdRol] [int] NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMenuRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Negocio]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Negocio](
	[IdNegocio] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [varchar](100) NULL,
	[RUT] [varchar](20) NULL,
	[Direccion] [varchar](100) NULL,
	[Celular] [varchar](10) NULL,
	[Correo] [varchar](30) NULL,
	[SimboloMoneda] [varchar](5) NULL,
	[NombreLogo] [varchar](100) NULL,
	[UrlLogo] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNegocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[PrecioCompra] [decimal](10, 2) NOT NULL,
	[PrecioVenta] [decimal](10, 2) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NULL,
	[NombreCompleto] [varchar](50) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Clave] [varchar](100) NOT NULL,
	[ResetearClave] [bit] NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[NumeroVenta] [varchar](10) NULL,
	[IdUsuarioRegistro] [int] NULL,
	[NombreCliente] [varchar](60) NOT NULL,
	[PrecioTotal] [decimal](10, 2) NOT NULL,
	[PagoCon] [decimal](10, 2) NULL,
	[Cambio] [decimal](10, 2) NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [IdMedida], [Activo]) VALUES (1, N'Accesorios', 1, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [IdMedida], [Activo]) VALUES (2, N'Tornillo', 3, 0)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [IdMedida], [Activo]) VALUES (3, N'Tornillos 1/2 Pulgada', 1, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [IdMedida], [Activo]) VALUES (4, N'Tornillos 1/4 Pulgada', 1, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [IdMedida], [Activo]) VALUES (5, N'Hombre Solo', 1, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [IdMedida], [Activo]) VALUES (6, N'Bristol', 1, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [IdMedida], [Activo]) VALUES (7, N'Parches', 1, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [IdMedida], [Activo]) VALUES (8, N'Prueba', 1, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [IdMedida], [Activo]) VALUES (9, N'Prueba 2.0', 1, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [IdMedida], [Activo]) VALUES (10, N'Cable', 2, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [IdMedida], [Activo]) VALUES (11, N'', 3, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [IdMedida], [Activo]) VALUES (12, N'Tornillo', 3, 1)
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [IdMedida], [Activo]) VALUES (13, N'Chapas', 1, 1)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
INSERT [dbo].[CorrelativoVenta] ([Serie], [Numero], [Activo]) VALUES (N'001', 6, 1)
INSERT [dbo].[CorrelativoVenta] ([Serie], [Numero], [Activo]) VALUES (N'002', 0, 0)
GO
SET IDENTITY_INSERT [dbo].[DetalleVenta] ON 

INSERT [dbo].[DetalleVenta] ([IdDetalleVenta], [IdVenta], [IdProducto], [Cantidad], [PrecioVenta], [PrecioTotal]) VALUES (1, 1, 2, 1, CAST(300.00 AS Decimal(10, 2)), CAST(300.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([IdDetalleVenta], [IdVenta], [IdProducto], [Cantidad], [PrecioVenta], [PrecioTotal]) VALUES (2, 2, 2, 1, CAST(300.00 AS Decimal(10, 2)), CAST(300.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([IdDetalleVenta], [IdVenta], [IdProducto], [Cantidad], [PrecioVenta], [PrecioTotal]) VALUES (3, 3, 2, 1, CAST(300.00 AS Decimal(10, 2)), CAST(300.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([IdDetalleVenta], [IdVenta], [IdProducto], [Cantidad], [PrecioVenta], [PrecioTotal]) VALUES (4, 4, 2, 10, CAST(300.00 AS Decimal(10, 2)), CAST(3000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([IdDetalleVenta], [IdVenta], [IdProducto], [Cantidad], [PrecioVenta], [PrecioTotal]) VALUES (5, 5, 2, 10, CAST(300.00 AS Decimal(10, 2)), CAST(3000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([IdDetalleVenta], [IdVenta], [IdProducto], [Cantidad], [PrecioVenta], [PrecioTotal]) VALUES (6, 6, 2, 6, CAST(300.00 AS Decimal(10, 2)), CAST(1800.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[DetalleVenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Medida] ON 

INSERT [dbo].[Medida] ([IdMedida], [Nombre], [Abreviatura], [Equivalente], [Valor]) VALUES (1, N'Unidad', N'ud', N'ud', 1)
INSERT [dbo].[Medida] ([IdMedida], [Nombre], [Abreviatura], [Equivalente], [Valor]) VALUES (2, N'Metro', N'mtr', N'mtr', 1)
INSERT [dbo].[Medida] ([IdMedida], [Nombre], [Abreviatura], [Equivalente], [Valor]) VALUES (3, N'Kilogramo', N'kg', N'kg', 1)
SET IDENTITY_INSERT [dbo].[Medida] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([IdMenu], [NombreMenu], [IdMenuPadre]) VALUES (1, N'ventas', 0)
INSERT [dbo].[Menu] ([IdMenu], [NombreMenu], [IdMenuPadre]) VALUES (2, N'inventario', 0)
INSERT [dbo].[Menu] ([IdMenu], [NombreMenu], [IdMenuPadre]) VALUES (3, N'reportes', 0)
INSERT [dbo].[Menu] ([IdMenu], [NombreMenu], [IdMenuPadre]) VALUES (4, N'usuarios', 0)
INSERT [dbo].[Menu] ([IdMenu], [NombreMenu], [IdMenuPadre]) VALUES (5, N'configuracion', 0)
INSERT [dbo].[Menu] ([IdMenu], [NombreMenu], [IdMenuPadre]) VALUES (6, N'nuevo', 1)
INSERT [dbo].[Menu] ([IdMenu], [NombreMenu], [IdMenuPadre]) VALUES (7, N'historial', 1)
INSERT [dbo].[Menu] ([IdMenu], [NombreMenu], [IdMenuPadre]) VALUES (8, N'productos', 2)
INSERT [dbo].[Menu] ([IdMenu], [NombreMenu], [IdMenuPadre]) VALUES (9, N'categorias', 2)
INSERT [dbo].[Menu] ([IdMenu], [NombreMenu], [IdMenuPadre]) VALUES (10, N'ventas', 3)
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuRol] ON 

INSERT [dbo].[MenuRol] ([IdMenuRol], [IdMenu], [IdRol], [Activo]) VALUES (1, 1, 1, 1)
INSERT [dbo].[MenuRol] ([IdMenuRol], [IdMenu], [IdRol], [Activo]) VALUES (2, 2, 1, 1)
INSERT [dbo].[MenuRol] ([IdMenuRol], [IdMenu], [IdRol], [Activo]) VALUES (3, 3, 1, 1)
INSERT [dbo].[MenuRol] ([IdMenuRol], [IdMenu], [IdRol], [Activo]) VALUES (4, 4, 1, 1)
INSERT [dbo].[MenuRol] ([IdMenuRol], [IdMenu], [IdRol], [Activo]) VALUES (5, 5, 1, 1)
INSERT [dbo].[MenuRol] ([IdMenuRol], [IdMenu], [IdRol], [Activo]) VALUES (6, 6, 1, 1)
INSERT [dbo].[MenuRol] ([IdMenuRol], [IdMenu], [IdRol], [Activo]) VALUES (7, 7, 1, 1)
INSERT [dbo].[MenuRol] ([IdMenuRol], [IdMenu], [IdRol], [Activo]) VALUES (8, 8, 1, 1)
INSERT [dbo].[MenuRol] ([IdMenuRol], [IdMenu], [IdRol], [Activo]) VALUES (9, 9, 1, 1)
INSERT [dbo].[MenuRol] ([IdMenuRol], [IdMenu], [IdRol], [Activo]) VALUES (10, 10, 1, 1)
INSERT [dbo].[MenuRol] ([IdMenuRol], [IdMenu], [IdRol], [Activo]) VALUES (11, 1, 2, 1)
INSERT [dbo].[MenuRol] ([IdMenuRol], [IdMenu], [IdRol], [Activo]) VALUES (12, 6, 2, 1)
INSERT [dbo].[MenuRol] ([IdMenuRol], [IdMenu], [IdRol], [Activo]) VALUES (13, 7, 2, 1)
SET IDENTITY_INSERT [dbo].[MenuRol] OFF
GO
SET IDENTITY_INSERT [dbo].[Negocio] ON 

INSERT [dbo].[Negocio] ([IdNegocio], [RazonSocial], [RUT], [Direccion], [Celular], [Correo], [SimboloMoneda], [NombreLogo], [UrlLogo]) VALUES (1, N'Proyecto Hogar', N'100100100', N'Ejemplo', N'3115039917', N'ejemplo@gmail.com', N'$', N'wfeqiwgpxoupewiwpcia', N'https://res.cloudinary.com/dtwb7m7uv/image/upload/v1740338843/wfeqiwgpxoupewiwpcia.png')
SET IDENTITY_INSERT [dbo].[Negocio] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([IdProducto], [IdCategoria], [Codigo], [Descripcion], [PrecioCompra], [PrecioVenta], [Cantidad], [Activo]) VALUES (1, 1, N'1010', N'Prueba', CAST(20.00 AS Decimal(10, 2)), CAST(30.00 AS Decimal(10, 2)), 20, 0)
INSERT [dbo].[Producto] ([IdProducto], [IdCategoria], [Codigo], [Descripcion], [PrecioCompra], [PrecioVenta], [Cantidad], [Activo]) VALUES (2, 1, N'2020', N'Prueba 2.0', CAST(200.00 AS Decimal(10, 2)), CAST(300.00 AS Decimal(10, 2)), 1, 1)
INSERT [dbo].[Producto] ([IdProducto], [IdCategoria], [Codigo], [Descripcion], [PrecioCompra], [PrecioVenta], [Cantidad], [Activo]) VALUES (3, 5, N'10101010101', N'hombre solo', CAST(9000.00 AS Decimal(10, 2)), CAST(11000.00 AS Decimal(10, 2)), 20, 1)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([IdRol], [Nombre]) VALUES (1, N'Administrador')
INSERT [dbo].[Rol] ([IdRol], [Nombre]) VALUES (2, N'Ventas')
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IdUsuario], [IdRol], [NombreCompleto], [Correo], [NombreUsuario], [Clave], [ResetearClave], [Activo]) VALUES (1, 2, N'Juan', N'juan@gmail.com', N'juan', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 0, 1)
INSERT [dbo].[Usuario] ([IdUsuario], [IdRol], [NombreCompleto], [Correo], [NombreUsuario], [Clave], [ResetearClave], [Activo]) VALUES (2, 2, N'Juan Nicolas Barreto Sanchez', N'barretosanchez11@gmail.com', N'jbarreto', N'62c31220fba687ed7498c8ac79f7c0fddbb3356fde65cd49fb', 1, 0)
INSERT [dbo].[Usuario] ([IdUsuario], [IdRol], [NombreCompleto], [Correo], [NombreUsuario], [Clave], [ResetearClave], [Activo]) VALUES (3, 2, N'Juan Nicolás', N'barretosanchez10@gmail.com', N'jnbarreto', N'¦e¤Y B/A~HgïÜO¸ J?ÿ ~™Ž†÷÷¢zã', 1, 0)
INSERT [dbo].[Usuario] ([IdUsuario], [IdRol], [NombreCompleto], [Correo], [NombreUsuario], [Clave], [ResetearClave], [Activo]) VALUES (4, 1, N'Nicolas', N'barretosanchez12@gmail.com', N'jnsanchez', N'ef8e41ddb67aa8125b80725558f4d4712b2182496ca6184366', 1, 0)
INSERT [dbo].[Usuario] ([IdUsuario], [IdRol], [NombreCompleto], [Correo], [NombreUsuario], [Clave], [ResetearClave], [Activo]) VALUES (5, 1, N'Juan Nicolas', N'barretosanchez7@gmail.com', N'barretosanchez', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 0, 1)
INSERT [dbo].[Usuario] ([IdUsuario], [IdRol], [NombreCompleto], [Correo], [NombreUsuario], [Clave], [ResetearClave], [Activo]) VALUES (6, 1, N'Jhon Jairo Barreto', N'barretosanchez60@gmail.com', N'jhon', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 0, 0)
INSERT [dbo].[Usuario] ([IdUsuario], [IdRol], [NombreCompleto], [Correo], [NombreUsuario], [Clave], [ResetearClave], [Activo]) VALUES (7, 2, N'Daniela Gomez', N'barretosanchez6@gmail.com', N'daniela', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 0, 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Venta] ON 

INSERT [dbo].[Venta] ([IdVenta], [NumeroVenta], [IdUsuarioRegistro], [NombreCliente], [PrecioTotal], [PagoCon], [Cambio], [FechaRegistro], [Activo]) VALUES (1, N'001-000001', 1, N'Prueba', CAST(300.00 AS Decimal(10, 2)), CAST(100.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2025-02-23T14:15:03.097' AS DateTime), 1)
INSERT [dbo].[Venta] ([IdVenta], [NumeroVenta], [IdUsuarioRegistro], [NombreCliente], [PrecioTotal], [PagoCon], [Cambio], [FechaRegistro], [Activo]) VALUES (2, N'001-000002', 1, N'Prueba', CAST(300.00 AS Decimal(10, 2)), CAST(100.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2025-02-23T14:19:07.663' AS DateTime), 1)
INSERT [dbo].[Venta] ([IdVenta], [NumeroVenta], [IdUsuarioRegistro], [NombreCliente], [PrecioTotal], [PagoCon], [Cambio], [FechaRegistro], [Activo]) VALUES (3, N'001-000003', 1, N'', CAST(300.00 AS Decimal(10, 2)), CAST(300.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2025-02-23T14:26:43.770' AS DateTime), 1)
INSERT [dbo].[Venta] ([IdVenta], [NumeroVenta], [IdUsuarioRegistro], [NombreCliente], [PrecioTotal], [PagoCon], [Cambio], [FechaRegistro], [Activo]) VALUES (4, N'001-000004', 1, N'', CAST(3000.00 AS Decimal(10, 2)), CAST(1000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(N'2025-02-23T14:27:50.820' AS DateTime), 1)
INSERT [dbo].[Venta] ([IdVenta], [NumeroVenta], [IdUsuarioRegistro], [NombreCliente], [PrecioTotal], [PagoCon], [Cambio], [FechaRegistro], [Activo]) VALUES (5, N'001-000005', 1, N'Prueba', CAST(3000.00 AS Decimal(10, 2)), CAST(50000.00 AS Decimal(10, 2)), CAST(47000.00 AS Decimal(10, 2)), CAST(N'2025-02-25T11:36:05.933' AS DateTime), 1)
INSERT [dbo].[Venta] ([IdVenta], [NumeroVenta], [IdUsuarioRegistro], [NombreCliente], [PrecioTotal], [PagoCon], [Cambio], [FechaRegistro], [Activo]) VALUES (6, N'001-000006', 5, N'', CAST(1800.00 AS Decimal(10, 2)), CAST(3000.00 AS Decimal(10, 2)), CAST(1200.00 AS Decimal(10, 2)), CAST(N'2025-03-09T17:53:20.240' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Venta] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__6B0F5AE0EBC1383C]    Script Date: 12/3/2025 14:19:20 ******/
ALTER TABLE [dbo].[Usuario] ADD UNIQUE NONCLUSTERED 
(
	[NombreUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categoria] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[CorrelativoVenta] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Menu] ADD  DEFAULT ((0)) FOR [IdMenuPadre]
GO
ALTER TABLE [dbo].[MenuRol] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((1)) FOR [ResetearClave]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Venta] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Venta] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD FOREIGN KEY([IdMedida])
REFERENCES [dbo].[Medida] ([IdMedida])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([IdVenta])
GO
ALTER TABLE [dbo].[MenuRol]  WITH CHECK ADD FOREIGN KEY([IdMenu])
REFERENCES [dbo].[Menu] ([IdMenu])
GO
ALTER TABLE [dbo].[MenuRol]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([IdUsuarioRegistro])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
/****** Object:  StoredProcedure [dbo].[sp_actualizarClave]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_actualizarClave](
@IdUsuario int,
@NuevaClave varchar(100),
@Resetear bit
)
as
begin
	update Usuario
	set Clave = @NuevaClave , ResetearClave = @Resetear
	where IdUsuario = @IdUsuario
end

GO
/****** Object:  StoredProcedure [dbo].[sp_CrearCategoria]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CrearCategoria](
    @Nombre varchar(50),
@IdMedida int,
@MsjError varchar(100) output -- Mensaje de Error
)
as
begin
	set @MsjError = ''

	if(exists(select * from Categoria where Nombre = @Nombre))
	begin
		set @MsjError = 'El nombre de categoria ya existe'
		return
	end

	insert into Categoria(Nombre,IdMedida)
	values(@Nombre,@IdMedida)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_CrearProducto]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CrearProducto](  
@IdCategoria int,
@Codigo varchar(50),
@Descripcion varchar(150),
@PrecioCompra decimal (10,2),
@PrecioVenta decimal (10,2),
@Cantidad int,
@MsjError varchar(100) output -- Mensaje de Error  
)  
as  
begin  
 set @MsjError = ''  
  
 if(exists(select * from Producto where Descripcion = @Descripcion))  
 begin  
  set @MsjError = 'La descripcion del producto ya existe'  
  return  
 end  
  
 insert into Producto(IdCategoria,Codigo,Descripcion,PrecioCompra,PrecioVenta,Cantidad)  
 values(@IdCategoria,@Codigo,@Descripcion,@PrecioCompra,@PrecioVenta,@Cantidad)  
end
GO
/****** Object:  StoredProcedure [dbo].[sp_CrearUsuario]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CrearUsuario](  
    @IdRol int,
    @NombreCompleto varchar(50),
    @Correo varchar(50),
    @NombreUsuario varchar(50),
    @Clave varchar(64),  -- Ajustado a 64 caracteres
    @MsjError varchar(100) output  
)  
AS  
BEGIN  
    SET @MsjError = ''  

    IF EXISTS (SELECT * FROM Usuario WHERE Correo = @Correo)  
    BEGIN  
        SET @MsjError = 'El correo ya existe'  
        RETURN  
    END  

    IF EXISTS (SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario)  
    BEGIN  
        SET @MsjError = 'El nombre de usuario ya existe'  
        RETURN  
    END  

    INSERT INTO Usuario(IdRol, NombreCompleto, Correo, NombreUsuario, Clave)  
    VALUES (@IdRol, @NombreCompleto, @Correo, @NombreUsuario, @Clave)  
END

GO
/****** Object:  StoredProcedure [dbo].[sp_EditarCategoria]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EditarCategoria](
@IdCategoria int,
@Nombre varchar(50),
@IdMedida int,
@Activo int,
@MsjError varchar(100) output -- Mensaje de Error
)
as
begin
	set @MsjError = ''

	if(exists(select * from Categoria where Nombre = @Nombre and IdCategoria != @IdCategoria))
	begin
		set @MsjError = 'El nombre de categoria ya existe'
		return
	end

	insert into Categoria(Nombre,IdMedida)
	values(@Nombre,@IdMedida)

	update Categoria set 
	Nombre = @Nombre,
	IdMedida = @IdMedida,
	Activo = @Activo
	where IdCategoria = @IdCategoria
end
GO
/****** Object:  StoredProcedure [dbo].[sp_editarNegocio]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_editarNegocio]
@RazonSocial NVARCHAR(100),
@RUT NVARCHAR(50),
@Direccion NVARCHAR(200),
@Celular NVARCHAR(20),
@Correo NVARCHAR(100),
@SimboloMoneda NVARCHAR(10),
@NombreLogo NVARCHAR(255),  -- Asegurar que está incluido
@UrlLogo NVARCHAR(500)      -- Asegurar que está incluido
AS
BEGIN
    UPDATE Negocio
    SET RazonSocial = @RazonSocial,
        RUT = @RUT,
        Direccion = @Direccion,
        Celular = @Celular,
        Correo = @Correo,
        SimboloMoneda = @SimboloMoneda,
        NombreLogo = @NombreLogo,  -- Guardando imagen en la base de datos
        UrlLogo = @UrlLogo
    WHERE IdNegocio = 1; -- Asegúrate de actualizar correctamente
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarProducto]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EditarProducto]( 
@IdProducto int,
@IdCategoria int,
@Codigo varchar(50),
@Descripcion varchar(150),
@PrecioCompra decimal (10,2),
@PrecioVenta decimal (10,2),
@Cantidad int,
@Activo int,
@MsjError varchar(100) output -- Mensaje de Error  
)  
as  
begin  
 set @MsjError = ''  
  
 if(exists(select * from Producto where Descripcion = @Descripcion and IdProducto != @IdProducto))  
 begin  
  set @MsjError = 'El descripcion del producto ya existe'  
  return  
 end    
  
 update Producto set   
 IdCategoria = @IdCategoria,
 Codigo = @Codigo,
 Descripcion = @Descripcion,
 PrecioCompra = @PrecioCompra,
 PrecioVenta = @PrecioVenta,
 Cantidad = @Cantidad,
 Activo = @Activo  
 where IdProducto = @IdProducto  
end
GO
/****** Object:  StoredProcedure [dbo].[sp_editarUsuario]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_editarUsuario](  
@IdUsuario int,
@IdRol int,
@Activo int,
@NombreUsuario varchar (50),
@NombreCompleto varchar (50),
@Correo varchar (100),
@MsjError varchar(100) output -- Mensaje de Error  
)  
as  
begin  
 set @MsjError = ''  
  
 if(exists(select * from Usuario where Correo = @Correo
 and IdUsuario != @IdUsuario
 ))  
 begin  
  set @MsjError = 'El Correo ya existe'  
  return  
 end  

 if(exists(select * from Usuario where NombreUsuario = @NombreUsuario
  and IdUsuario != @IdUsuario
 ))  
 begin  
  set @MsjError = 'El nombre de usuario ya existe'  
  return  
 end  
  
  update Usuario set IdRol = @IdRol, NombreCompleto = @NombreCompleto, Correo = @Correo, NombreUsuario = @NombreUsuario, Activo = @Activo where IdUsuario = @IdUsuario

end
GO
/****** Object:  StoredProcedure [dbo].[sp_listaCategoria]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_listaCategoria]
(
@Buscar varchar(50) = ''
)
as
begin
	select c.IdCategoria,c.Nombre,m.IdMedida, m.Nombre[NombreMedida],c.Activo from Categoria c inner join Medida m on m.IdMedida = c.IdMedida where CONCAT(c.Nombre,m.Nombre,iif(c.activo=1, 'SI','NO')) like '%' + @Buscar + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listaMedida]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_listaMedida]
as
begin
	select IdMedida,Nombre,Abreviatura,Equivalente,Valor from Medida
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listaProducto]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Listar Productos
create procedure [dbo].[sp_listaProducto]
(  
@Buscar varchar(50) = ''  
)  
as  
begin  
 select p.IdProducto, c.IdCategoria, c.Nombre[NombreCategoria], p.Codigo, p.Descripcion, p.PrecioCompra, p.PrecioVenta, p.Cantidad, p.Activo from Producto p inner join Categoria c on c.IdCategoria = p.IdCategoria where CONCAT(p.Codigo,p.Descripcion,c.Nombre, IIF(p.Activo = 1,'SI','NO')) like '%' + @Buscar + '%'  
end  
GO
/****** Object:  StoredProcedure [dbo].[sp_listaRol]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_listaRol]
as 
begin
	select IdRol,Nombre from Rol
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listaUsuario]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_listaUsuario]
(  
@Buscar varchar(50) = ''  
)  
as  
begin  
 select u.IdUsuario, r.IdRol, r.Nombre[NombreRol], u.NombreCompleto, u.Correo, u.NombreUsuario, u.Activo from Usuario u inner join Rol r on r.IdRol = u.IdRol where CONCAT(r.Nombre,u.NombreCompleto, u.Correo, u.NombreUsuario,iif(u.activo=1, 'SI','NO')) like '%' + @Buscar + '%'  
end  
GO
/****** Object:  StoredProcedure [dbo].[sp_listaVenta]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_listaVenta](
@FechaInicio varchar(10),
@FechaFin varchar(10),
@Buscar varchar(50) = ''
)as
begin
	set dateformat dmy
	
	select
	v.NumeroVenta,
	u.NombreUsuario,
	v.NombreCliente,
	v.PrecioTotal,
	v.PagoCon,
	v.Cambio,
	CONVERT(char(10),v.FechaRegistro,103)[FechaRegistro]
	from
	Venta v
	inner join Usuario u on u.IdUsuario = v.IdUsuarioRegistro
	where
	CONVERT(date,v.FechaRegistro) between CONVERT(date,@FechaInicio) and CONVERT(date,@FechaFin)
	and CONCAT(v.NumeroVenta,u.NombreUsuario,v.NombreCliente) like '%' + @Buscar + '%'

end
GO
/****** Object:  StoredProcedure [dbo].[sp_login]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_login](
    @NombreUsuario NVARCHAR(50),  -- Aumentamos el tamaño y usamos NVARCHAR si la tabla lo tiene así
    @Clave NVARCHAR(100)          -- Ajustamos a NVARCHAR para evitar problemas de comparación
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        u.IdUsuario,
        u.NombreCompleto,
        r.IdRol,
        r.Nombre AS NombreRol,  -- Corrección de alias
        u.Correo,
        u.NombreUsuario,
        u.ResetearClave,
        u.Activo
    FROM Usuario u
    INNER JOIN Rol r ON r.IdRol = u.IdRol
    WHERE u.NombreUsuario = @NombreUsuario 
      AND u.Clave = @Clave;  -- Validar si Clave está cifrada en la BD
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerDetalleVenta]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ObtenerDetalleVenta](
@NumeroVenta varchar(10)
)
as
begin

	select 
	p.Descripcion,
	m.Abreviatura,
	m.Valor,
	dv.Cantidad,
	dv.PrecioVenta,
	dv.PrecioTotal
	from DetalleVenta dv
	inner join Venta v on v.IdVenta = dv.IdVenta
	inner join Producto p on p.IdProducto = dv.IdProducto
	inner join Categoria c on c.IdCategoria = p.IdCategoria
	inner join Medida m on m.IdMedida = c.IdMedida
	where v.NumeroVenta = @NumeroVenta
end
GO
/****** Object:  StoredProcedure [dbo].[sp_obtenerMenus]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_obtenerMenus](
@IdRol int
)
as
begin
	select 
	m.NombreMenu,
	m.IdMenuPadre,
	mr.Activo
	from MenuRol mr
	inner join Menu m on m.IdMenu = mr.IdMenu
	where mr.IdRol = @IdRol
end
GO
/****** Object:  StoredProcedure [dbo].[sp_obtenerNegocio]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_obtenerNegocio] 
as
begin

	select RazonSocial, RUT, Direccion,Celular,Correo,SimboloMoneda,NombreLogo,UrlLogo
	from Negocio where IdNegocio = 1

end
GO
/****** Object:  StoredProcedure [dbo].[sp_obtenerProducto]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_obtenerProducto]
(
@Codigo varchar(50)
)
as
begin
	
	select
	p.IdProducto,
	c.Nombre[NombreCategoria],
	m.Equivalente,
	m.Valor,
	p.Codigo,
	p.Descripcion,
	p.PrecioVenta,
	p.Cantidad
	from Producto p
	inner join Categoria c on c.IdCategoria = p.IdCategoria
	inner join Medida m on m.IdMedida = c.IdMedida
	where
	p.Cantidad > 0 and
	p.Activo = 1 and
	p.Codigo = @Codigo

end
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerVenta]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ObtenerVenta](
@NumeroVenta varchar(10)
)
as
begin
	select 
	v.IdVenta,
	v.NumeroVenta,
	u.NombreUsuario,
	v.NombreCliente,
	v.PrecioTotal,
	v.PagoCon,
	v.Cambio,
	convert(char(10), v.FechaRegistro,103)[FechaRegistro]
	from Venta v
	inner join Usuario u on u.IdUsuario = v.IdUsuarioRegistro
	where v.NumeroVenta = @NumeroVenta

end
GO
/****** Object:  StoredProcedure [dbo].[sp_registrarVenta]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_registrarVenta](
@VentaXml xml,
@NumeroVenta varchar(10) output
)
as
begin

	declare @idVenta int

	declare @venta table (
	IdUsuarioRegistro int,
	NombreCliente varchar(60),
	PrecioTotal decimal(10,2),
	PagoCon decimal(10,2),
	Cambio decimal(10,2)
	)

	declare @detalleventa table (
	IdProducto int,
	Cantidad int,
	PrecioVenta decimal(10,2),
	PrecioTotal decimal(10,2)
	)

	begin try

		begin transaction

			insert into @venta(IdUsuarioRegistro,NombreCliente,PrecioTotal,PagoCon,Cambio)
			select
			x.value('IdUsuarioRegistro[1]','INT') as IdUsuarioRegistro,
			x.value('NombreCliente[1]','varchar(60)') as NombreCliente,
			x.value('PrecioTotal[1]', 'decimal(10,2)') as PrecioTotal,
			x.value('PagoCon[1]', 'decimal(10,2)') as PagoCon,
			x.value('Cambio[1]', 'decimal(10,2)') as Cambio
			from
			@VentaXml.nodes('Venta') as T(x)

			insert into @detalleventa(IdProducto,Cantidad,PrecioVenta,PrecioTotal)
			select
			x.value('IdProducto[1]', 'int') as IdProducto,
			x.value('Cantidad[1]', 'int') as Cantidad,
			x.value('PrecioVenta[1]', 'decimal(10,2)') as PrecioVenta,
			x.value('PrecioTotal[1]', 'decimal(10,2)') as PrecioTotal
			from
			@VentaXml.nodes('Venta/DetalleVenta/Item') as T(x)

			update CorrelativoVenta set
			Numero = Numero + 1,
			@NumeroVenta = Concat(Serie,'-', right('000000' + cast(Numero + 1 as varchar),6))
			where Activo = 1

			insert into Venta(NumeroVenta,IdUsuarioRegistro,NombreCliente,PrecioTotal,PagoCon,Cambio)
			select @NumeroVenta,IdUsuarioRegistro,NombreCliente,PrecioTotal,PagoCon,Cambio from @venta

			set @idVenta = scope_identity()

			insert into DetalleVenta(IdVenta,IdProducto,Cantidad,PrecioVenta,PrecioTotal)
			select @idVenta, IdProducto,Cantidad,PrecioVenta,PrecioTotal from @detalleventa

			update p set 
			p.Cantidad = p.cantidad - dv.cantidad
			from Producto p 
			inner join @detalleventa dv on dv.IdProducto = p.IdProducto


		commit transaction
	end try
	begin catch
		rollback transaction
		set @NumeroVenta = ''
	end catch
end
GO
/****** Object:  StoredProcedure [dbo].[sp_reporteVenta]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_reporteVenta](
@FechaInicio varchar(10),
@FechaFin varchar(10)
)
as
begin
	
	set dateformat dmy

	select
	v.NumeroVenta,
	u.NombreUsuario,
	convert(char(10),v.fechaRegistro,103)[FechaRegistro],
	p.Descripcion[Producto],
	p.PrecioCompra,
	dv.PrecioVenta,
	dv.Cantidad,
	dv.PrecioTotal
	from Venta v
	inner join Usuario u on u.IdUsuario = v.IdUsuarioRegistro
	inner join DetalleVenta dv on dv.IdVenta = v.IdVenta
	inner join Producto p on p.IdProducto = dv.IdProducto
	where
	CONVERT(date,v.fecharegistro) between convert(date,@FechaInicio) and convert(date,@FechaFin)
	
end
GO
/****** Object:  StoredProcedure [dbo].[sp_verificarCorreo]    Script Date: 12/3/2025 14:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_verificarCorreo](
@Correo varchar(50),
@IdUsuario int output
)
as
begin
	if(exists(select * from Usuario where Correo = @Correo))
		set @IdUsuario = (select IdUsuario from Usuario where Correo = @Correo)
	else
		set @IdUsuario = 0
end
GO
USE [master]
GO
ALTER DATABASE [DBTienda] SET  READ_WRITE 
GO
