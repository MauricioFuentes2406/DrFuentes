CREATE TABLE [dbo].[ClienteAlergias] (
    [IdCLiente] INT NOT NULL,
    [IdAlergia] INT NOT NULL,
    CONSTRAINT [PK_ClienteAlergias] PRIMARY KEY CLUSTERED ([IdCLiente] ASC, [IdAlergia] ASC),
    CONSTRAINT [FK_ClienteAlergias_Alergias] FOREIGN KEY ([IdAlergia]) REFERENCES [dbo].[TipoAlergias] ([idAlergia]),
    CONSTRAINT [FK_ClienteAlergias_Cliente] FOREIGN KEY ([IdCLiente]) REFERENCES [dbo].[Cliente] ([IdCliente])
);

