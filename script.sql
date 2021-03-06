USE [master]
GO
/****** Object:  Database [edd]    Script Date: 24-02-2017 10:48:55 ******/
CREATE DATABASE [edd]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'edd', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\edd.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'edd_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\edd_log.ldf' , SIZE = 136064KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [edd] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [edd].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [edd] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [edd] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [edd] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [edd] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [edd] SET ARITHABORT OFF 
GO
ALTER DATABASE [edd] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [edd] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [edd] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [edd] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [edd] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [edd] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [edd] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [edd] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [edd] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [edd] SET  DISABLE_BROKER 
GO
ALTER DATABASE [edd] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [edd] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [edd] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [edd] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [edd] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [edd] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [edd] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [edd] SET RECOVERY FULL 
GO
ALTER DATABASE [edd] SET  MULTI_USER 
GO
ALTER DATABASE [edd] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [edd] SET DB_CHAINING OFF 
GO
ALTER DATABASE [edd] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [edd] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [edd] SET DELAYED_DURABILITY = DISABLED 
GO
USE [edd]
GO
/****** Object:  UserDefinedTableType [dbo].[Hierarchy]    Script Date: 24-02-2017 10:48:55 ******/
CREATE TYPE [dbo].[Hierarchy] AS TABLE(
	[element_id] [int] NOT NULL,
	[sequenceNo] [int] NULL,
	[parent_ID] [int] NULL,
	[Object_ID] [int] NULL,
	[NAME] [nvarchar](2000) NULL,
	[StringValue] [nvarchar](max) NOT NULL,
	[ValueType] [varchar](10) NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[element_id] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[tbl_admin]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_admin](
	[admin_usuario] [text] NOT NULL,
	[admin_clave_1] [text] NOT NULL,
	[admin_clave_2] [text] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_cargo_competencia]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_cargo_competencia](
	[cargo_cap_id] [int] NOT NULL,
	[rol_id] [int] NOT NULL,
	[cargo_cap_ncap] [int] NOT NULL,
	[cargo_cap_descripcion] [varchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_categorias]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_categorias](
	[categ_id] [int] NOT NULL,
	[categ_nombre] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_competencias]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_competencias](
	[cap_id] [int] NOT NULL,
	[eval_id] [int] NOT NULL,
	[usuario_id] [int] NOT NULL,
	[usuario_id_alias] [int] NULL,
	[cap_cargo_id] [int] NULL,
	[cap_eval_inicial_consensuada] [int] NULL,
	[cap_eval_inicial_comentario] [text] NULL,
	[cap_eval_inicial_plan_accion] [text] NULL,
	[cap_eval_inicial_jefe] [text] NULL,
	[cap_eval_final_consensuada] [int] NULL,
	[cap_eval_final_comentario] [text] NULL,
	[cap_eval_final_plan_accion] [text] NULL,
	[cap_eval_final_jefe] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_estado_obj]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_estado_obj](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_ad] [int] NULL,
	[estado_obj] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_eval]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_eval](
	[eval_id] [int] NOT NULL,
	[eval_fecha_inicio] [date] NOT NULL,
	[eval_fecha_termino] [date] NOT NULL,
	[eval_estado_evaluacion] [int] NULL,
	[eval_termino_primera_evaluacion] [date] NULL,
	[eval_termino_segunda_evaluacion] [date] NULL,
	[eval_avisos] [int] NULL,
	[eval_mensaje_bienvenida] [text] NULL,
	[eval_instructivo_autoevaluacion] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_eval_usuario]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_eval_usuario](
	[evalusr_eval_id] [int] IDENTITY(1,1) NOT NULL,
	[evalusr_usuario_id] [int] NULL,
	[evalusr_estado_evaluacion] [int] NULL,
	[evalusr_fecha_primera_evaluacion] [text] NULL,
	[evalusr_comentario_primera_evaluacion] [text] NULL,
	[evalusr_fecha_segunda_evaluacion] [text] NULL,
	[evalusr_comentario_segunda_evaluacion] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_log]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_log](
	[log_id] [bigint] IDENTITY(1,1) NOT NULL,
	[log_jefe] [int] NULL,
	[log_trabajador] [int] NULL,
	[log_fecha] [datetime] NULL,
	[log_actividad] [varchar](50) NULL,
	[log_estado] [varchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_obj]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_obj](
	[obj_id] [int] IDENTITY(1,1) NOT NULL,
	[obj_ad] [int] NOT NULL,
	[obj_eval] [int] NULL,
	[obj_num] [int] NULL,
	[obj_tabla1] [nvarchar](max) NULL,
	[obj_tabla2] [nvarchar](max) NULL,
	[obj_tabla3] [nvarchar](max) NULL,
	[obj_tabla4] [nvarchar](max) NULL,
	[obj_tabla5] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_obj] PRIMARY KEY CLUSTERED 
(
	[obj_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_organigrama]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_organigrama](
	[org_id] [int] NOT NULL,
	[org_usuario_ad_jefe] [int] NOT NULL,
	[org_usuario_ad_subalterno] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_perfil]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_perfil](
	[cv_id] [int] IDENTITY(1,1) NOT NULL,
	[cv_ad] [int] NOT NULL,
	[cv_datos] [nvarchar](max) NOT NULL,
	[cv_estado] [char](1) NOT NULL,
 CONSTRAINT [PK_tbl_perfil] PRIMARY KEY CLUSTERED 
(
	[cv_ad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_rol]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_rol](
	[rol_id] [int] NOT NULL,
	[rol_nombre] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_usuario]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_usuario](
	[usuario_id] [int] IDENTITY(1,1) NOT NULL,
	[usuario_ad] [int] NOT NULL,
	[usuario_nombre] [varchar](20) NOT NULL,
	[usuario_area] [varchar](50) NOT NULL,
	[usuario_cargo] [varchar](50) NOT NULL,
	[usuario_ad_jefe] [int] NOT NULL,
	[rol_id] [int] NOT NULL,
	[usuario_fecha_creacion] [datetime] NOT NULL,
	[usuario_fecha_ultimo_acceso] [datetime] NOT NULL,
	[usuario_bienvenida] [smallint] NOT NULL,
 CONSTRAINT [PK_tbl_usuario] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[tbl_admin] ([admin_usuario], [admin_clave_1], [admin_clave_2]) VALUES (N'admin', N'abcdef', N'123456')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (1, 5, 1, N'Effective Communicat')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (2, 5, 2, N'Stress Tolerance
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (3, 5, 3, N'Atención al Cliente')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (4, 5, 4, N'Compromiso
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (5, 4, 1, N'Tolerancia al estrés')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (6, 4, 2, N'Iniciativa
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (7, 4, 3, N'Trabajo en equipo
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (8, 4, 4, N'Comunicación efectiv')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (9, 4, 5, N'Auto-motivación
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (10, 4, 6, N'Adaptación al cambio')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (11, 3, 1, N'Capacidad Organizati')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (12, 3, 2, N'Comunicación efectiv')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (13, 3, 3, N'Trabajo en equipo
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (14, 3, 4, N'Delegación
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (15, 3, 5, N'Liderazgo
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (16, 3, 6, N'Trabajo en equipo
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (17, 3, 7, N'Toma de decisiones (')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (25, 2, 1, N'Liderazgo
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (26, 2, 2, N'Delegación
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (27, 2, 3, N'Flexibilidad
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (28, 2, 4, N'Planificación y Orga')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (29, 2, 5, N'Sensibilidad interpe')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (30, 2, 6, N'Capacidad crítica
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (31, 2, 7, N'Pensamiento Estratég')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (36, 1, 1, N'Liderazgo
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (37, 1, 2, N'Delegación
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (38, 1, 3, N'Flexibilidad
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (39, 1, 4, N'Planificación y Orga')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (40, 1, 5, N'Sensibilidad interpe')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (41, 1, 6, N'Capacidad crítica
')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (42, 1, 7, N'Pensamiento Estratég')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (47, 100, 1, N'Effective Communicat')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (48, 100, 2, N'Stress Tolerance')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (49, 100, 3, N'Atención al Cliente')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (50, 100, 4, N'Compromiso')
INSERT [dbo].[tbl_cargo_competencia] ([cargo_cap_id], [rol_id], [cargo_cap_ncap], [cargo_cap_descripcion]) VALUES (51, 100, 5, N'Flexibilidad')
INSERT [dbo].[tbl_categorias] ([categ_id], [categ_nombre]) VALUES (1, N'Costos')
INSERT [dbo].[tbl_categorias] ([categ_id], [categ_nombre]) VALUES (2, N'Desarrollo')
INSERT [dbo].[tbl_categorias] ([categ_id], [categ_nombre]) VALUES (3, N'Investigación')
INSERT [dbo].[tbl_categorias] ([categ_id], [categ_nombre]) VALUES (4, N'Mejora Continua')
INSERT [dbo].[tbl_categorias] ([categ_id], [categ_nombre]) VALUES (5, N'Operacional')
INSERT [dbo].[tbl_categorias] ([categ_id], [categ_nombre]) VALUES (6, N'Producción')
INSERT [dbo].[tbl_categorias] ([categ_id], [categ_nombre]) VALUES (7, N'Salud y Seguridad')
INSERT [dbo].[tbl_categorias] ([categ_id], [categ_nombre]) VALUES (8, N'Otros')
SET IDENTITY_INSERT [dbo].[tbl_estado_obj] ON 

INSERT [dbo].[tbl_estado_obj] ([id], [id_ad], [estado_obj]) VALUES (1, 102, 1)
INSERT [dbo].[tbl_estado_obj] ([id], [id_ad], [estado_obj]) VALUES (2, 101, 0)
SET IDENTITY_INSERT [dbo].[tbl_estado_obj] OFF
INSERT [dbo].[tbl_eval] ([eval_id], [eval_fecha_inicio], [eval_fecha_termino], [eval_estado_evaluacion], [eval_termino_primera_evaluacion], [eval_termino_segunda_evaluacion], [eval_avisos], [eval_mensaje_bienvenida], [eval_instructivo_autoevaluacion]) VALUES (1, CAST(N'2017-01-01' AS Date), CAST(N'2017-12-31' AS Date), 1, CAST(N'2017-02-25' AS Date), CAST(N'2017-02-27' AS Date), NULL, N'<p style="text-align:justify">Te damos la más cordial bienvenida a uno de los procesos fundamentales para nuestra Firma,la Evaluación de Desempeño de nuestros empleados.</p><p  style="text-align:justify">El objetivo primordial de este proceso, es promover el crecimiento, la participación activa, la mejora continua y comunicación efectiva entre las jefaturas y su equipo de trabajo. A su vez, dicho proceso busca fomentar la retroalimentación continua de nuestros empleados para así poder alcanzar desarrollos de carrera con el fin de garantizar el éxito tanto individual como del negocio.</p><p style="text-align:justify">¡Te motivamos a ser parte de este gran desafío!</p><p>Soporte: RRHH</p>', NULL)
SET IDENTITY_INSERT [dbo].[tbl_eval_usuario] ON 

INSERT [dbo].[tbl_eval_usuario] ([evalusr_eval_id], [evalusr_usuario_id], [evalusr_estado_evaluacion], [evalusr_fecha_primera_evaluacion], [evalusr_comentario_primera_evaluacion], [evalusr_fecha_segunda_evaluacion], [evalusr_comentario_segunda_evaluacion]) VALUES (1, 102, 0, N'', N'', N'', N'')
INSERT [dbo].[tbl_eval_usuario] ([evalusr_eval_id], [evalusr_usuario_id], [evalusr_estado_evaluacion], [evalusr_fecha_primera_evaluacion], [evalusr_comentario_primera_evaluacion], [evalusr_fecha_segunda_evaluacion], [evalusr_comentario_segunda_evaluacion]) VALUES (2, 101, 0, N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[tbl_eval_usuario] OFF
SET IDENTITY_INSERT [dbo].[tbl_log] ON 

INSERT [dbo].[tbl_log] ([log_id], [log_jefe], [log_trabajador], [log_fecha], [log_actividad], [log_estado]) VALUES (1, 101, 102, CAST(N'2017-02-22T22:23:54.977' AS DateTime), N'Objetivos Inicial enviado a Jefatura', N'REVISION')
SET IDENTITY_INSERT [dbo].[tbl_log] OFF
SET IDENTITY_INSERT [dbo].[tbl_obj] ON 

INSERT [dbo].[tbl_obj] ([obj_id], [obj_ad], [obj_eval], [obj_num], [obj_tabla1], [obj_tabla2], [obj_tabla3], [obj_tabla4], [obj_tabla5]) VALUES (1, 102, 1, 1, N'{ "categoria": "Personas" , "objetivo": "1" , "logros": "1" }', N'{ "medicion": "1" , "pasos1": "" , "pasos2": "" , "pasos3": "" , "pasos4": "" , "pasos5": "" , "pasos6": "" , "pasos7": "" , "fechapa1": "" , "fechapa2": "" , "fechapa3": "" , "fechapa4": "" , "fechapa5": "" , "fechapa6": "" , "fechapa7": "" , "fechapa11": "" , "fechapa12": "" , "fechapa13": "" , "fechapa14": "" , "fechapa15": "" , "fechapa16": "" , "fechapa17": "" }', N'{ "categoria3": "Segun planificacion" , "fecha31": "22/02/2017" , "fecha32": "23/02/2017" , "terminado3": "11" , "pasos31": "11" , "pasos32": ""}', N'{ "categoria4": "null" , "fecha41": "" , "fecha42": "" , "terminado4": "" , "pasos41": "" , "pasos42": ""}', N'{ "categoria5": "null" , "fecha51": "" , "fecha52": "" , "terminado5": "" , "notafinal5": "null" , "pasos51": "" , "notafinaljefatura5": "null" , "pasos52": ""}')
SET IDENTITY_INSERT [dbo].[tbl_obj] OFF
SET IDENTITY_INSERT [dbo].[tbl_perfil] ON 

INSERT [dbo].[tbl_perfil] ([cv_id], [cv_ad], [cv_datos], [cv_estado]) VALUES (2, 102, N'{ "nombre1": "JORGE" , "nombre2": "LUIS" , "ape1": "GONZALEZ" , "ape2": "ULLOA" , "nacionalidad": "CHILENA" , "cargo": "ADMINISTRADOR" , "area": "CONTABILIDAD" , "gerencia": "ADM. Y" , "expfecini1": "" , "expfecter1": "" , "expcargo1": "" , "trabajaqui1": "null" , "expfecini2": "" , "expfecter2": "" , "expcargo2": "" , "trabajaqui2": "null" , "expfecini3": "" , "expfecter3": "" , "expcargo3": "" , "trabajaqui3": "null" , "expfecini4": "" , "expfecter4": "" , "expcargo4": "" , "trabajaqui4": "null" , "empfecini1": "" , "empfecini2": "" , "empfecini3": "" , "empfecini4": "" , "empfecini5": "" , "empfecini6": "" , "empfecini7": "" , "empfecini8": "" , "empfecini9": "" , "empfecini10": "" , "empfecter1": "" , "empfecter2": "" , "empfecter3": "" , "empfecter4": "" , "empfecter5": "" , "empfecter6": "" , "empfecter7": "" , "empfecter8": "" , "empfecter9": "" , "empfecter10": "" , "empcargo1": "" , "empcargo2": "" , "empcargo3": "" , "empcargo4": "" , "empcargo5": "" , "empcargo6": "" , "empcargo7": "" , "empcargo8": "" , "empcargo9": "" , "empcargo10": "" , "empresa1": "" , "empresa2": "" , "empresa3": "" , "empresa4": "" , "empresa5": "" , "empresa6": "" , "empresa7": "" , "empresa8": "" , "empresa9": "" , "empresa10": "" , "forprograma1": "" , "forprograma2": "" , "forprograma3": "" , "forprograma4": "" , "forprograma5": "" , "forprograma6": "" , "forprograma7": "" , "forprograma8": "" , "forprograma9": "" , "forgrado1": "" , "forgrado2": "" , "forgrado3": "" , "forgrado4": "" , "forgrado5": "" , "forgrado6": "" , "forgrado7": "" , "forgrado8": "" , "forgrado9": "" , "forinstitucion1": "" , "forinstitucion2": "" , "forinstitucion3": "" , "forinstitucion4": "" , "forinstitucion5": "" , "forinstitucion6": "" , "forinstitucion7": "" , "forinstitucion8": "" , "forinstitucion9": "" , "forfecini1": "" , "forfecini2": "" , "forfecini3": "" , "forfecini4": "" , "forfecini5": "" , "forfecini6": "" , "forfecini7": "" , "forfecini8": "" , "forfecini9": "" , "forfecter1": "" , "forfecter2": "" , "forfecter3": "" , "forfecter4": "" , "forfecter5": "" , "forfecter6": "" , "forfecter7": "" , "forfecter8": "" , "forfecter9": "" , "capfecini1": "" , "capfecini2": "" , "capfecini3": "" , "capfecini4": "" , "capfecini5": "" , "capfecini6": "" , "capfecini7": "" , "capfecini8": "" , "capfecter1": "" , "capfecter2": "" , "capfecter3": "" , "capfecter4": "" , "capfecter5": "" , "capfecter6": "" , "capfecter7": "" , "capfecter8": "" , "captitulo1": "" , "captitulo2": "" , "captitulo3": "" , "captitulo4": "" , "captitulo5": "" , "captitulo6": "" , "captitulo7": "" , "captitulo8": "" , "captitestudio1": "" , "captitestudio2": "" , "captitestudio3": "" , "captitestudio4": "" , "captitestudio5": "" , "captitestudio6": "" , "captitestudio7": "" , "captitestudio8": "" , "capinstitucion1": "" , "capinstitucion2": "" , "capinstitucion3": "" , "capinstitucion4": "" , "capinstitucion5": "" , "capinstitucion6": "" , "capinstitucion7": "" , "capinstitucion8": "" , "idiom1": "INGLES" , "idiom2": "" , "idiom3": "" , "idiom4": "" , "idiom5": "" , "nivel1": "BASICO" , "nivel2": "null" , "nivel3": "null" , "nivel4": "null" , "nivel5": "null" , "areapref1": "" , "disp1": "undefined" , "nomprem1": "" , "nomprem2": "" , "nomprem3": "" , "nomprem4": "" , "nomprem5": "" , "nomprem6": "" , "nomprem7": "" , "nomprem8": "" , "nomprem9": "" , "nomprem10": "" , "fecprem1": "" , "fecprem2": "" , "fecprem3": "" , "fecprem4": "" , "fecprem5": "" , "fecprem6": "" , "fecprem7": "" , "fecprem8": "" , "fecprem9": "" , "fecprem10": "" , "orgprem1": "" , "orgprem2": "" , "orgprem3": "" , "orgprem4": "" , "orgprem5": "" , "orgprem6": "" , "orgprem7": "" , "orgprem8": "" , "orgprem9": "" , "orgprem10": "" , "memb1": "" , "memb2": "" , "memb3": "" , "memb4": "" , "memb5": "" , "instmemb1": "" , "instmemb2": "" , "instmemb3": "" , "instmemb4": "" , "instmemb5": "" , "membfecini1": "" , "membfecini2": "" , "membfecini3": "" , "membfecini4": "" , "membfecini5": "" , "membfecter1": "" , "membfecter2": "" , "membfecter3": "" , "membfecter4": "" , "membfecter5": "" }', N'A')
SET IDENTITY_INSERT [dbo].[tbl_perfil] OFF
INSERT [dbo].[tbl_rol] ([rol_id], [rol_nombre]) VALUES (1, N'Gerente             ')
INSERT [dbo].[tbl_rol] ([rol_id], [rol_nombre]) VALUES (2, N'Subgerente          ')
INSERT [dbo].[tbl_rol] ([rol_id], [rol_nombre]) VALUES (3, N'Jefe                ')
INSERT [dbo].[tbl_rol] ([rol_id], [rol_nombre]) VALUES (4, N'Profesional         ')
INSERT [dbo].[tbl_rol] ([rol_id], [rol_nombre]) VALUES (5, N'Administrativo      ')
INSERT [dbo].[tbl_rol] ([rol_id], [rol_nombre]) VALUES (100, N'Rol de Prueba       ')
SET IDENTITY_INSERT [dbo].[tbl_usuario] ON 

INSERT [dbo].[tbl_usuario] ([usuario_id], [usuario_ad], [usuario_nombre], [usuario_area], [usuario_cargo], [usuario_ad_jefe], [rol_id], [usuario_fecha_creacion], [usuario_fecha_ultimo_acceso], [usuario_bienvenida]) VALUES (1, 100, N'Admin1', N'RRHH', N'Rol de Prueba', 0, 0, CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2017-02-24T10:39:46.560' AS DateTime), 4)
INSERT [dbo].[tbl_usuario] ([usuario_id], [usuario_ad], [usuario_nombre], [usuario_area], [usuario_cargo], [usuario_ad_jefe], [rol_id], [usuario_fecha_creacion], [usuario_fecha_ultimo_acceso], [usuario_bienvenida]) VALUES (2, 101, N'Admin1', N'RRHH', N'Rol de Prueba', 100, 0, CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2017-02-24T10:39:46.560' AS DateTime), 4)
INSERT [dbo].[tbl_usuario] ([usuario_id], [usuario_ad], [usuario_nombre], [usuario_area], [usuario_cargo], [usuario_ad_jefe], [rol_id], [usuario_fecha_creacion], [usuario_fecha_ultimo_acceso], [usuario_bienvenida]) VALUES (3, 102, N'Admin1', N'RRHH', N'Rol de Prueba', 101, 0, CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2017-02-24T10:39:46.560' AS DateTime), 16)
INSERT [dbo].[tbl_usuario] ([usuario_id], [usuario_ad], [usuario_nombre], [usuario_area], [usuario_cargo], [usuario_ad_jefe], [rol_id], [usuario_fecha_creacion], [usuario_fecha_ultimo_acceso], [usuario_bienvenida]) VALUES (4, 103, N'Admin1', N'RRHH', N'Rol de Prueba', 101, 0, CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2017-02-24T10:39:46.560' AS DateTime), 12)
INSERT [dbo].[tbl_usuario] ([usuario_id], [usuario_ad], [usuario_nombre], [usuario_area], [usuario_cargo], [usuario_ad_jefe], [rol_id], [usuario_fecha_creacion], [usuario_fecha_ultimo_acceso], [usuario_bienvenida]) VALUES (5, 105, N'Admin1', N'RRHH', N'Rol de Prueba', 100, 0, CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2017-02-24T10:39:46.560' AS DateTime), 0)
INSERT [dbo].[tbl_usuario] ([usuario_id], [usuario_ad], [usuario_nombre], [usuario_area], [usuario_cargo], [usuario_ad_jefe], [rol_id], [usuario_fecha_creacion], [usuario_fecha_ultimo_acceso], [usuario_bienvenida]) VALUES (6, 106, N'Admin1', N'RRHH', N'Rol de Prueba', 101, 0, CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2017-02-24T10:39:46.560' AS DateTime), 18)
INSERT [dbo].[tbl_usuario] ([usuario_id], [usuario_ad], [usuario_nombre], [usuario_area], [usuario_cargo], [usuario_ad_jefe], [rol_id], [usuario_fecha_creacion], [usuario_fecha_ultimo_acceso], [usuario_bienvenida]) VALUES (7, 107, N'Admin1', N'RRHH', N'Rol de Prueba', 101, 0, CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2017-02-24T10:39:46.560' AS DateTime), 14)
INSERT [dbo].[tbl_usuario] ([usuario_id], [usuario_ad], [usuario_nombre], [usuario_area], [usuario_cargo], [usuario_ad_jefe], [rol_id], [usuario_fecha_creacion], [usuario_fecha_ultimo_acceso], [usuario_bienvenida]) VALUES (8, 108, N'Admin1', N'RRHH', N'Rol de Prueba', 101, 0, CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2017-02-24T10:39:46.560' AS DateTime), 20)
INSERT [dbo].[tbl_usuario] ([usuario_id], [usuario_ad], [usuario_nombre], [usuario_area], [usuario_cargo], [usuario_ad_jefe], [rol_id], [usuario_fecha_creacion], [usuario_fecha_ultimo_acceso], [usuario_bienvenida]) VALUES (9, 109, N'Admin1', N'RRHH', N'Rol de Prueba', 101, 0, CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2017-02-24T10:39:46.560' AS DateTime), 20)
INSERT [dbo].[tbl_usuario] ([usuario_id], [usuario_ad], [usuario_nombre], [usuario_area], [usuario_cargo], [usuario_ad_jefe], [rol_id], [usuario_fecha_creacion], [usuario_fecha_ultimo_acceso], [usuario_bienvenida]) VALUES (10, 110, N'Admin1', N'RRHH', N'Rol de Prueba', 101, 0, CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2017-02-24T10:39:46.560' AS DateTime), 20)
INSERT [dbo].[tbl_usuario] ([usuario_id], [usuario_ad], [usuario_nombre], [usuario_area], [usuario_cargo], [usuario_ad_jefe], [rol_id], [usuario_fecha_creacion], [usuario_fecha_ultimo_acceso], [usuario_bienvenida]) VALUES (11, 111, N'Admin1', N'RRHH', N'Rol de Prueba', 101, 0, CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2017-02-24T10:39:46.560' AS DateTime), 20)
INSERT [dbo].[tbl_usuario] ([usuario_id], [usuario_ad], [usuario_nombre], [usuario_area], [usuario_cargo], [usuario_ad_jefe], [rol_id], [usuario_fecha_creacion], [usuario_fecha_ultimo_acceso], [usuario_bienvenida]) VALUES (12, 112, N'Admin1', N'RRHH', N'Rol de Prueba', 101, 0, CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2017-02-24T10:39:46.560' AS DateTime), 20)
INSERT [dbo].[tbl_usuario] ([usuario_id], [usuario_ad], [usuario_nombre], [usuario_area], [usuario_cargo], [usuario_ad_jefe], [rol_id], [usuario_fecha_creacion], [usuario_fecha_ultimo_acceso], [usuario_bienvenida]) VALUES (13, 113, N'Admin1', N'RRHH', N'Rol de Prueba', 101, 0, CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2017-02-24T10:39:46.560' AS DateTime), 19)
INSERT [dbo].[tbl_usuario] ([usuario_id], [usuario_ad], [usuario_nombre], [usuario_area], [usuario_cargo], [usuario_ad_jefe], [rol_id], [usuario_fecha_creacion], [usuario_fecha_ultimo_acceso], [usuario_bienvenida]) VALUES (14, 114, N'Admin1', N'RRHH', N'Rol de Prueba', 101, 0, CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2017-02-24T10:39:46.560' AS DateTime), 20)
INSERT [dbo].[tbl_usuario] ([usuario_id], [usuario_ad], [usuario_nombre], [usuario_area], [usuario_cargo], [usuario_ad_jefe], [rol_id], [usuario_fecha_creacion], [usuario_fecha_ultimo_acceso], [usuario_bienvenida]) VALUES (15, 115, N'Admin1', N'RRHH', N'Rol de Prueba', 101, 0, CAST(N'2016-01-01T00:00:00.000' AS DateTime), CAST(N'2017-02-24T10:39:46.560' AS DateTime), 20)
SET IDENTITY_INSERT [dbo].[tbl_usuario] OFF
ALTER TABLE [dbo].[tbl_usuario] ADD  CONSTRAINT [DF_tbl_usuario_usuario_bienvenida_1]  DEFAULT ((0)) FOR [usuario_bienvenida]
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZA_COMPETENCIAS]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Estado Competencias>
-- =============================================

CREATE PROCEDURE [dbo].[ACTUALIZA_COMPETENCIAS] @id int, @usuario int, @evalid int, @cargo int,
@eval_inicial_consensuada int,
@eval_inicial_plan_accion text,
@eval_inicial_comentario text,
@eval_inicial_jefe text,
@eval_final_consensuada int,
@eval_final_plan_accion text,
@eval_final_comentario text,
@eval_final_jefe text

	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
    SET NOCOUNT ON;
	declare @n int

	select @n=count(*) from tbl_competencias where cap_cargo_id=@cargo and usuario_id=@usuario
	if @n=0
	  insert into tbl_competencias values (@id,@evalid, @usuario, 0, @cargo, @eval_inicial_consensuada, @eval_inicial_comentario,
	  @eval_inicial_plan_accion, @eval_inicial_jefe,
	  @eval_final_consensuada, @eval_final_comentario, @eval_final_plan_accion, @eval_final_jefe)
	else
	update tbl_competencias 
	set cap_eval_inicial_consensuada=@eval_inicial_consensuada,
	cap_eval_inicial_comentario=@eval_inicial_comentario,
	cap_eval_inicial_plan_accion=@eval_inicial_plan_accion,
	cap_eval_inicial_jefe=@eval_inicial_jefe,
	cap_eval_final_consensuada=@eval_final_consensuada,
	cap_eval_final_comentario=@eval_final_comentario,
	cap_eval_final_plan_accion=@eval_final_plan_accion,
	cap_eval_final_jefe=@eval_final_jefe
	where usuario_id=@usuario and cap_cargo_id=@cargo
END
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZA_ESTADO_COMP]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Estado Competencias>
-- =============================================
CREATE PROCEDURE [dbo].[ACTUALIZA_ESTADO_COMP] @ad_usuario int, @estado int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	update tbl_eval_usuario set evalusr_estado_evaluacion=@estado where evalusr_usuario_id=@ad_usuario

END
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZA_ESTADO_OBJ]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Estado Objetivos>
-- =============================================
create PROCEDURE [dbo].[ACTUALIZA_ESTADO_OBJ] @ad_usuario int, @estado int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	update tbl_estado_obj set estado_obj=@estado where id_ad=@ad_usuario

END
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZA_EVAL]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Perfil>
-- =============================================
CREATE PROCEDURE [dbo].[ACTUALIZA_EVAL] @fecuno varchar(10), @fecdos varchar(10)
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update tbl_eval set eval_termino_primera_evaluacion=convert(datetime, @fecuno, 105), eval_termino_segunda_evaluacion=convert(datetime, @fecdos, 105) where eval_estado_evaluacion=1
END
GO
/****** Object:  StoredProcedure [dbo].[GUARDA_LOG]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GUARDA_LOG] 
@trabajador as int,
@actividad as varchar(50),
@estado as varchar(50)
AS
BEGIN
    declare @jefe as int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @jefe=0
	select @jefe=usuario_ad_jefe from tbl_usuario where usuario_ad=@trabajador
    -- Insert statements for procedure here
	insert into tbl_log values ( @jefe, @trabajador, GETDATE(),@actividad, @estado)
END

GO
/****** Object:  StoredProcedure [dbo].[GUARDA_OBJ]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Guarda Objetivos>
-- =============================================
CREATE PROCEDURE [dbo].[GUARDA_OBJ] @cvad int, @ideval int, @numobj int, @tabla1 nvarchar(max), @tabla2 nvarchar(max), @tabla3 nvarchar(max), @tabla4 nvarchar(max), @tabla5 nvarchar(max)

	-- Add the parameters for the stored procedure here
AS
BEGIN
SET NOCOUNT ON;
declare @n int
set @n=0
select @n=count(*) from tbl_obj where obj_ad=@cvad and obj_num=@numobj and obj_eval=@ideval

if @n=0
   insert into tbl_obj (obj_ad, obj_eval, obj_num, obj_tabla1, obj_tabla2, obj_tabla3, obj_tabla4, obj_tabla5 ) values ( @cvad, @ideval, @numobj, @tabla1, @tabla2, @tabla3, @tabla4, @tabla5)
else
   update tbl_obj set obj_tabla1=@tabla1,obj_tabla2=@tabla2,obj_tabla3=@tabla3,obj_tabla4=@tabla4,obj_tabla5=@tabla5 where obj_ad=@cvad and obj_num=@numobj and obj_eval=@ideval
END

GO
/****** Object:  StoredProcedure [dbo].[GUARDA_PERFIL]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Guarda Perfil>
-- =============================================
CREATE PROCEDURE [dbo].[GUARDA_PERFIL] @cvad int, @datosperf nvarchar(max)

	-- Add the parameters for the stored procedure here
AS
BEGIN
SET NOCOUNT ON;
declare @n int
set @n=0
select @n=count(*) from tbl_perfil where cv_ad=@cvad

if @n=0
   insert into tbl_perfil (cv_ad,cv_datos, cv_estado) values ( @cvad, @datosperf,'A' )
else
   update tbl_perfil set cv_datos=@datosperf where cv_ad=@cvad
END



GO
/****** Object:  StoredProcedure [dbo].[GUARDA_USUARIO]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GUARDA_USUARIO] 
@idusuario as int,
@idjefe as int,
@nombre as varchar(50),
@cargo as varchar(50),
@area as varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @nc as int
declare @rol as int

set @rol=0
select @rol=rol_id from tbl_rol where Charindex( rol_nombre, @cargo)>0

set @nc=0
select @nc=count(*) from tbl_usuario where usuario_ad=@idusuario
if @nc=0
   insert into tbl_usuario values(@idusuario,@nombre,@area,@cargo,@idjefe,@rol,GETDATE(),GETDATE(),20)
else
   update tbl_usuario set usuario_nombre=@nombre, usuario_cargo=@cargo,usuario_area=@area, usuario_fecha_ultimo_acceso=GETDATE(),rol_id=@rol 

END

GO
/****** Object:  StoredProcedure [dbo].[HAY_COMP]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Objetivos>
-- =============================================
CREATE PROCEDURE [dbo].[HAY_COMP] @ad_usuario int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT count(*) from tbl_competencias where usuario_id=@ad_usuario
END
GO
/****** Object:  StoredProcedure [dbo].[HAY_OBJ]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Objetivos>
-- =============================================
CREATE PROCEDURE [dbo].[HAY_OBJ] @ad_usuario int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT count(*) from tbl_obj where obj_ad=@ad_usuario
END
GO
/****** Object:  StoredProcedure [dbo].[LEE_BIENVENIDA]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Objetivos>
-- =============================================
CREATE PROCEDURE [dbo].[LEE_BIENVENIDA]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
    SELECT eval_mensaje_bienvenida from tbl_eval where eval_estado_evaluacion=1 
END
GO
/****** Object:  StoredProcedure [dbo].[LEE_CARGO_COMP]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Perfil>
-- =============================================
CREATE PROCEDURE [dbo].[LEE_CARGO_COMP] @ad_usuario int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @usuariocargo int


    -- Insert statements for procedure here
	select @usuariocargo=rol_id from tbl_usuario where usuario_ad=@ad_usuario

	select cargo_cap_ncap, cargo_cap_descripcion from tbl_cargo_competencia where rol_id=@usuariocargo

END

GO
/****** Object:  StoredProcedure [dbo].[LEE_COMPETENCIAS]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Perfil>
-- =============================================
CREATE PROCEDURE [dbo].[LEE_COMPETENCIAS] @ad_usuario int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    select 
	a.cap_cargo_id,
	b.cargo_cap_descripcion,
	a.cap_eval_inicial_consensuada,
    a.cap_eval_inicial_comentario,
    a.cap_eval_inicial_plan_accion,
    a.cap_eval_inicial_jefe,
    a.cap_eval_final_consensuada,
    a.cap_eval_final_comentario,
    a.cap_eval_final_plan_accion,
    a.cap_eval_final_jefe
    from tbl_competencias a, tbl_cargo_competencia b
    where a.usuario_id=@ad_usuario and
    a.cap_cargo_id=b.cargo_cap_id
END

GO
/****** Object:  StoredProcedure [dbo].[LEE_ESTADO_COMP]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Estado Objetivos>
-- =============================================
CREATE PROCEDURE [dbo].[LEE_ESTADO_COMP] @ad_usuario int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @n int

	select @n=count(*) from tbl_eval_usuario where evalusr_usuario_id=@ad_usuario
	if @n = 0
	 insert into tbl_eval_usuario values (@ad_usuario,0,'','','','')

	select evalusr_estado_evaluacion from tbl_eval_usuario where evalusr_usuario_id=@ad_usuario

END

GO
/****** Object:  StoredProcedure [dbo].[LEE_ESTADO_OBJ]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Estado Objetivos>
-- =============================================
CREATE PROCEDURE [dbo].[LEE_ESTADO_OBJ] @ad_usuario int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @n int

	select @n=count(*) from tbl_estado_obj where id_ad=@ad_usuario
    if @n=0
	   insert into tbl_estado_obj values ( @ad_usuario,0);

	select estado_obj from tbl_estado_obj where id_ad=@ad_usuario

END
GO
/****** Object:  StoredProcedure [dbo].[LEE_EVAL]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Perfil>
-- =============================================
CREATE PROCEDURE [dbo].[LEE_EVAL]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from tbl_eval where eval_estado_evaluacion=1
END
GO
/****** Object:  StoredProcedure [dbo].[LEE_JEFATURA]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Objetivos>
-- =============================================
CREATE PROCEDURE [dbo].[LEE_JEFATURA] @ad_usuario int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @adjefe int

	select @adjefe=usuario_ad_jefe from tbl_usuario where usuario_ad=@ad_usuario

	select usuario_nombre from tbl_usuario where usuario_ad=@adjefe

END
GO
/****** Object:  StoredProcedure [dbo].[LEE_LOG]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LEE_LOG] 
	-- Add the parameters for the stored procedure here
@usuario as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @tipo as int;
	set @tipo=0;
	select @tipo=usuario_ad_jefe from tbl_usuario where usuario_ad_jefe=@usuario
	if @tipo=0
	  select a.log_fecha, a.log_actividad,a.log_estado,b.usuario_nombre from tbl_log a, tbl_usuario b where a.log_trabajador=@usuario and b.usuario_ad=a.log_jefe order by a.log_fecha desc;
	else
      select a.log_fecha, a.log_actividad,a.log_estado,b.usuario_nombre from tbl_log a, tbl_usuario b where a.log_jefe=@usuario and b.usuario_ad=a.log_trabajador order by a.log_fecha desc;
END

GO
/****** Object:  StoredProcedure [dbo].[LEE_MSJ]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Objetivos>
-- =============================================
CREATE PROCEDURE [dbo].[LEE_MSJ] @usuario int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @b int
	declare @n int

    -- Insert statements for procedure here
    
	select @b=usuario_bienvenida from tbl_usuario where usuario_ad=@usuario
	
	set @n=@b
	if @n=0
	   set @n=20
	else
	   set @n=@n-1
	update tbl_usuario set usuario_bienvenida=@n where usuario_ad=@usuario

	IF @b=0
       SELECT eval_mensaje_bienvenida from tbl_eval where eval_estado_evaluacion=1 
	ELSE
	   SELECT eval_mensaje_bienvenida from tbl_eval where eval_estado_evaluacion=2

END
GO
/****** Object:  StoredProcedure [dbo].[LEE_OBJ]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Objetivos>
-- =============================================
CREATE PROCEDURE [dbo].[LEE_OBJ] @ad_usuario int, @ideval int, @numobj int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from tbl_obj where obj_ad=@ad_usuario and obj_num=@numobj and obj_eval=@ideval
END
GO
/****** Object:  StoredProcedure [dbo].[LEE_PERFIL]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Perfil>
-- =============================================
CREATE PROCEDURE [dbo].[LEE_PERFIL] @ad_usuario int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from tbl_perfil where cv_ad=@ad_usuario
END

GO
/****** Object:  StoredProcedure [dbo].[LEE_REVISA_COMP]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Perfil>
-- =============================================
CREATE PROCEDURE [dbo].[LEE_REVISA_COMP] @ad_usuario int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	select b.usuario_ad, b.usuario_nombre, a.evalusr_estado_evaluacion from tbl_eval_usuario a, tbl_usuario b where b.usuario_ad=a.evalusr_usuario_id and a.evalusr_usuario_id in (select usuario_ad from tbl_usuario where usuario_ad_jefe=@ad_usuario)

END

GO
/****** Object:  StoredProcedure [dbo].[LEE_REVISA_OBJ]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Perfil>
-- =============================================
CREATE PROCEDURE [dbo].[LEE_REVISA_OBJ] @ad_usuario int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select a.id_ad, b.usuario_nombre,a.estado_obj from tbl_estado_obj a, tbl_usuario b where b.usuario_ad=a.id_ad and a.id_ad in (select usuario_ad from tbl_usuario where usuario_ad_jefe=@ad_usuario)
END

GO
/****** Object:  StoredProcedure [dbo].[LIMPIA_TABLAS]    Script Date: 24-02-2017 10:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Andres Pavez>
-- Create date: <02-07-2016>
-- Description:	<Lee Estado Objetivos>
-- =============================================
CREATE PROCEDURE [dbo].[LIMPIA_TABLAS]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	truncate table tbl_obj
	truncate table tbl_eval_usuario
	truncate table tbl_competencias
	truncate table tbl_estado_obj
	truncate table tbl_log

END

GO
USE [master]
GO
ALTER DATABASE [edd] SET  READ_WRITE 
GO
