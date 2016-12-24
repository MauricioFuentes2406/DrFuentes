CREATE TABLE [dbo].[InsumosPorServicio] (
    [IdServicio] INT NOT NULL,
    [idArticulo] INT NOT NULL,
    CONSTRAINT [PK_InsumosPorServicio] PRIMARY KEY CLUSTERED ([IdServicio] ASC, [idArticulo] ASC),
    CONSTRAINT [FK_InsumosPorServicio_GeneralTipoServicio] FOREIGN KEY ([IdServicio]) REFERENCES [dbo].[GeneralTipoServicio] ([idServicio]),
    CONSTRAINT [FK_InsumosPorServicio_InventarioMedicina] FOREIGN KEY ([idArticulo]) REFERENCES [dbo].[InventarioMedicina] ([IdArticulo])
);

