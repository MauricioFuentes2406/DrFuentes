CREATE TABLE [dbo].[ConsultaEstadoVivienda] (
    [IdConsulta]         INT         NOT NULL,
    [IsPropia]           BIT         NOT NULL,
    [Piso]               TINYINT     NOT NULL,
    [Cielorraso]         BIT         NOT NULL,
    [Paredes_Material]   TINYINT     NOT NULL,
    [ServiciosBasicos]   NCHAR (20)  NOT NULL,
    [SanitariosCantidad] TINYINT     NOT NULL,
    [AguaPotable]        BIT         NOT NULL,
    [TieneMascota]       BIT         NOT NULL,
    [DetalleExtra]       NCHAR (100) NULL,
    CONSTRAINT [PK_ConsultaEstadoVivienda] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_ConsultaEstadoVivienda_ConsultaEstadoViviendaMateriales_Paredes_Material] FOREIGN KEY ([Paredes_Material]) REFERENCES [dbo].[ConsultaEstadoViviendaMateriales] ([IdMaterial]),
    CONSTRAINT [FK_ConsultaEstadoVivienda_ConsultaEstadoViviendaMateriales_Piso] FOREIGN KEY ([Piso]) REFERENCES [dbo].[ConsultaEstadoViviendaMateriales] ([IdMaterial]),
    CONSTRAINT [PK_ConsultaEstadoVivienda_ConsultaEstadoViviendaMateriales] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Por Defecto "Todos"', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ConsultaEstadoVivienda', @level2type = N'COLUMN', @level2name = N'ServiciosBasicos';

