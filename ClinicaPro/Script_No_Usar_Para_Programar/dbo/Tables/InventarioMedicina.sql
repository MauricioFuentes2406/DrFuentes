CREATE TABLE [dbo].[InventarioMedicina] (
    [IdArticulo]   INT          NOT NULL,
    [idTipoUnidad] INT          NULL,
    [Costo]        INT          NULL,
    [Cantidad]     INT          NULL,
    [Nombre]       VARCHAR (50) NOT NULL,
    [Presentacion] VARCHAR (50) NULL,
    [Estado]       INT          NULL,
    CONSTRAINT [PK_InventarioMedicina] PRIMARY KEY CLUSTERED ([IdArticulo] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Por Acabar?Agotado?Normal?', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'InventarioMedicina', @level2type = N'COLUMN', @level2name = N'Estado';

