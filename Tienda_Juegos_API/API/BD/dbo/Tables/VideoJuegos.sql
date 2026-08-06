CREATE TABLE [dbo].[VideoJuegos] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [Titulo]           NVARCHAR (MAX)  NOT NULL,
    [Plataforma]       NVARCHAR (MAX)  NOT NULL,
    [Genero]           NVARCHAR (MAX)  NOT NULL,
    [Precio]           DECIMAL (18, 2) NOT NULL,
    [Stock]            INT             NOT NULL,
    [FechaLanzamiento] DATETIME2 (7)   NOT NULL,
    CONSTRAINT [PK_VideoJuegos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

