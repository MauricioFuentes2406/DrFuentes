CREATE TABLE [dbo].[ConsultaEstadoViviendaMateriales] (
    [IdMaterial] TINYINT    NOT NULL,
    [Nombre]     NCHAR (30) NULL,
    CONSTRAINT [PK_ConsultaEstadoViviendaMateriales] PRIMARY KEY CLUSTERED ([IdMaterial] ASC),
    CONSTRAINT [IX_ConsultaEstadoViviendaMateriales_UniqueNombre] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

