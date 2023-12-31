USE [Education]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/12/2023 6:15:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursos]    Script Date: 8/12/2023 6:15:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursos](
	[CursoId] [uniqueidentifier] NOT NULL,
	[Titulo] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
	[FechaPublicacion] [datetime2](7) NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[Precio] [decimal](14, 2) NOT NULL,
 CONSTRAINT [PK_Cursos] PRIMARY KEY CLUSTERED 
(
	[CursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231202030609_Inicial', N'6.0.0')
GO
INSERT [dbo].[Cursos] ([CursoId], [Titulo], [Descripcion], [FechaPublicacion], [FechaCreacion], [Precio]) VALUES (N'cd96547a-abf1-40ce-b1c4-30c697b8bf81', N'EF-core', N'este es mi primer guardadito', CAST(N'2023-12-02T04:22:27.5480000' AS DateTime2), CAST(N'2023-12-01T23:45:11.2358112' AS DateTime2), CAST(5000.00 AS Decimal(14, 2)))
INSERT [dbo].[Cursos] ([CursoId], [Titulo], [Descripcion], [FechaPublicacion], [FechaCreacion], [Precio]) VALUES (N'dd344afa-cb41-4469-aa83-a04e7cf9e93e', N'EF-core 6.0', N'este es mi Segundo guardadito', CAST(N'2023-12-01T04:22:27.5480000' AS DateTime2), CAST(N'2023-12-01T23:46:19.1312000' AS DateTime2), CAST(6000.00 AS Decimal(14, 2)))
INSERT [dbo].[Cursos] ([CursoId], [Titulo], [Descripcion], [FechaPublicacion], [FechaCreacion], [Precio]) VALUES (N'3b49c270-9835-463d-b94d-ba6fc4c71ff7', N'C# desde cero hasta avanzado', N'Curso de C# Basico', CAST(N'2025-12-01T22:06:09.0325107' AS DateTime2), CAST(N'2023-12-01T22:06:09.0325093' AS DateTime2), CAST(56.00 AS Decimal(14, 2)))
INSERT [dbo].[Cursos] ([CursoId], [Titulo], [Descripcion], [FechaPublicacion], [FechaCreacion], [Precio]) VALUES (N'b28110a1-6d00-441e-bd72-bb52696ff08e', N'Master en Java Spring desde las raices', N'Curso de Java', CAST(N'2025-12-01T22:06:09.0325193' AS DateTime2), CAST(N'2023-12-01T22:06:09.0325192' AS DateTime2), CAST(25.00 AS Decimal(14, 2)))
INSERT [dbo].[Cursos] ([CursoId], [Titulo], [Descripcion], [FechaPublicacion], [FechaCreacion], [Precio]) VALUES (N'0d26ba72-1972-4d42-99a9-ce4afd96ba99', N'Master en UNIT Test con CQRS ', N'Curso de Unit Test para NET Core', CAST(N'2025-12-01T22:06:09.0325207' AS DateTime2), CAST(N'2023-12-01T22:06:09.0325206' AS DateTime2), CAST(100.00 AS Decimal(14, 2)))
GO
