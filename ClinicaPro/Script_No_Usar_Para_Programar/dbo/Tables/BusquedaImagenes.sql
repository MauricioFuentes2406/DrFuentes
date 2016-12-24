CREATE TABLE [dbo].[BusquedaImagenes] (
    [IdItem]           INT             NOT NULL,
    [IdBusquedaImagen] INT             IDENTITY (1, 1) NOT NULL,
    [Imagen]           VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_BusquedaImagenes] PRIMARY KEY CLUSTERED ([IdItem] ASC, [IdBusquedaImagen] ASC),
    CONSTRAINT [FK_BusquedaImagenes_Busquedas] FOREIGN KEY ([IdItem]) REFERENCES [dbo].[Busquedas] ([IdItem])
);

