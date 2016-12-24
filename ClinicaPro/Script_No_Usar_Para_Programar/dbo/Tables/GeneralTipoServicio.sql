CREATE TABLE [dbo].[GeneralTipoServicio] (
    [idServicio] INT        NOT NULL,
    [Nombre]     NCHAR (50) NULL,
    [Precio]     INT        NULL,
    [IsEditable] BIT        NULL,
    CONSTRAINT [PK_GeneralTipoServicio] PRIMARY KEY CLUSTERED ([idServicio] ASC),
    CONSTRAINT [IX_GeneralTipoServicio_UniqueNombre] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

