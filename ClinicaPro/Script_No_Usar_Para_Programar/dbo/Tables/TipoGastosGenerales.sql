CREATE TABLE [dbo].[TipoGastosGenerales] (
    [idTipoGasto] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]      NVARCHAR (15) NULL,
    CONSTRAINT [PK_TipoGastosGenerales] PRIMARY KEY CLUSTERED ([idTipoGasto] ASC)
);

