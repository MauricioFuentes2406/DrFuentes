CREATE TABLE [dbo].[ConsultaServicios] (
    [IdConsulta] INT NOT NULL,
    [IdServicio] INT NOT NULL,
    CONSTRAINT [PK_ServiciosConsultas] PRIMARY KEY CLUSTERED ([IdConsulta] ASC, [IdServicio] ASC),
    CONSTRAINT [FK_ConsultaServicios_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta]),
    CONSTRAINT [FK_ServiciosConsultas_GeneralTipoServicio] FOREIGN KEY ([IdServicio]) REFERENCES [dbo].[GeneralTipoServicio] ([idServicio])
);

