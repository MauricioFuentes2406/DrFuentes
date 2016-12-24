CREATE TABLE [dbo].[GastosGenerales] (
    [idGastos]       INT           NOT NULL,
    [Nombre]         VARCHAR (50)  NULL,
    [tiposCategoria] INT           NULL,
    [CostoGasto]     INT           NULL,
    [IdTipoUsuario]  INT           NOT NULL,
    [idTipoGasto]    INT           NULL,
    [Descripcion]    NVARCHAR (50) NULL,
    [FechaDeGasto]   DATE          NULL,
    CONSTRAINT [PK_Otrosgastos] PRIMARY KEY CLUSTERED ([idGastos] ASC),
    CONSTRAINT [FK_GastosGenerales_TipoGastosGenerales] FOREIGN KEY ([idTipoGasto]) REFERENCES [dbo].[TipoGastosGenerales] ([idTipoGasto]),
    CONSTRAINT [FK_GastosGenerales_TipoUsuario] FOREIGN KEY ([IdTipoUsuario]) REFERENCES [dbo].[TipoUsuario] ([idTipoUsuairo])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Nombre de Que', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GastosGenerales', @level2type = N'COLUMN', @level2name = N'Nombre';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Inmueble,Seguridad, ETC', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GastosGenerales', @level2type = N'COLUMN', @level2name = N'tiposCategoria';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Unico,Mensual,Trimestral,Bimestral,Anual', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GastosGenerales', @level2type = N'COLUMN', @level2name = N'idTipoGasto';

