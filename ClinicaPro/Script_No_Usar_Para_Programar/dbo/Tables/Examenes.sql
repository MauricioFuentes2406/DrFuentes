CREATE TABLE [dbo].[Examenes] (
    [idExamenes]            INT             NOT NULL,
    [idCliente]             INT             NULL,
    [FechaConsulta]         INT             NULL,
    [idTipoExamen]          INT             NULL,
    [Resultado]             VARBINARY (MAX) NULL,
    [FechaEntragaResultado] DATE            NULL,
    [EstadoPagado]          INT             NULL,
    [EstadoExamen]          INT             NULL,
    CONSTRAINT [PK_Examenes] PRIMARY KEY CLUSTERED ([idExamenes] ASC),
    CONSTRAINT [FK_Examenes_Cliente] FOREIGN KEY ([idCliente]) REFERENCES [dbo].[Cliente] ([IdCliente]),
    CONSTRAINT [FK_Examenes_TipoExamenes] FOREIGN KEY ([idTipoExamen]) REFERENCES [dbo].[TipoExamenes] ([idTipoExamen])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Enviado,Pendiente,Recibido , No Aplica', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Examenes', @level2type = N'COLUMN', @level2name = N'EstadoExamen';

