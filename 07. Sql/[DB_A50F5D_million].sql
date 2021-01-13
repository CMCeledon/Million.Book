USE [DB_A50F5D_million]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 16/11/2020 17:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[idAutor] [bigint] NOT NULL,
	[nombre] [varchar](45) NOT NULL,
	[apellido] [varchar](45) NOT NULL,
 CONSTRAINT [PK_autores] PRIMARY KEY CLUSTERED 
(
	[idAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AutorLibro]    Script Date: 16/11/2020 17:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutorLibro](
	[idAutor] [bigint] NULL,
	[idLibro] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Editorial]    Script Date: 16/11/2020 17:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Editorial](
	[idEditorial] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[sede] [nvarchar](50) NULL,
 CONSTRAINT [PK_Editorial] PRIMARY KEY CLUSTERED 
(
	[idEditorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExceptionControl]    Script Date: 16/11/2020 17:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExceptionControl](
	[ExceptionId] [bigint] IDENTITY(1,1) NOT NULL,
	[ExceptionMessage] [nvarchar](max) NULL,
	[ControllerName] [nvarchar](150) NULL,
	[ActionName] [nvarchar](150) NULL,
	[ExceptionStackTrack] [nvarchar](max) NULL,
	[ExceptionLogTime] [datetime] NOT NULL,
	[IdUsuario] [nvarchar](150) NULL,
 CONSTRAINT [PK_ExceptionControl] PRIMARY KEY CLUSTERED 
(
	[ExceptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 16/11/2020 17:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[idLibro] [bigint] IDENTITY(1,1) NOT NULL,
	[isbn] [int] NOT NULL,
	[idEditorial] [bigint] NOT NULL,
	[titulo] [nvarchar](50) NOT NULL,
	[sinopsis] [text] NOT NULL,
	[numeroPagina] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[idLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Editorial] ON 
GO
INSERT [dbo].[Editorial] ([idEditorial], [nombre], [sede]) VALUES (1, N'carlos nuevo', N'Inser')
GO
INSERT [dbo].[Editorial] ([idEditorial], [nombre], [sede]) VALUES (2, N'Nuevo Registro', N'101501')
GO
SET IDENTITY_INSERT [dbo].[Editorial] OFF
GO
SET IDENTITY_INSERT [dbo].[Libro] ON 
GO
INSERT [dbo].[Libro] ([idLibro], [isbn], [idEditorial], [titulo], [sinopsis], [numeroPagina]) VALUES (1, 323232, 1, N'233232', N'23232', N'3232')
GO
INSERT [dbo].[Libro] ([idLibro], [isbn], [idEditorial], [titulo], [sinopsis], [numeroPagina]) VALUES (2, 7878, 1, N'788778', N'787887', N'877887')
GO
SET IDENTITY_INSERT [dbo].[Libro] OFF
GO
/****** Object:  Index [UQ__Libro__Unico]    Script Date: 16/11/2020 17:58:28 ******/
ALTER TABLE [dbo].[Libro] ADD  CONSTRAINT [UQ__Libro__Unico] UNIQUE NONCLUSTERED 
(
	[isbn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AutorLibro]  WITH CHECK ADD  CONSTRAINT [FK_AutorLibro_Autor] FOREIGN KEY([idAutor])
REFERENCES [dbo].[Autor] ([idAutor])
GO
ALTER TABLE [dbo].[AutorLibro] CHECK CONSTRAINT [FK_AutorLibro_Autor]
GO
ALTER TABLE [dbo].[AutorLibro]  WITH CHECK ADD  CONSTRAINT [FK_AutorLibro_Libro] FOREIGN KEY([idLibro])
REFERENCES [dbo].[Libro] ([idLibro])
GO
ALTER TABLE [dbo].[AutorLibro] CHECK CONSTRAINT [FK_AutorLibro_Libro]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarEditorialesByDapper]    Script Date: 16/11/2020 17:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarEditorialesByDapper]
AS
BEGIN
	SELECT [idEditorial], [nombre], [sede] 
	FROM Editorial WITH (NOLOCK)
END
GO
