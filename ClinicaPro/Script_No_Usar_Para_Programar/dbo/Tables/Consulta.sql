CREATE TABLE [dbo].[Consulta] (
    [IdConsulta]           INT           NOT NULL,
    [IdCliente]            INT           NOT NULL,
    [FechaConsulta]        DATE          NOT NULL,
    [Diagnostico]          VARCHAR (400) NOT NULL,
    [CobroFinalDeConsulta] INT           NOT NULL,
    [Descuento]            INT           NULL,
    [PlanTratamiento]      VARCHAR (700) NOT NULL,
    [AntecentePatologico]  VARCHAR (200) NULL,
    [AntecenteQuirurgico]  VARCHAR (200) NULL,
    [MotivoConsulta]       VARCHAR (200) NULL,
    [DiagnosticoEstado]    BIT           NULL,
    [PadecimientoActual]   VARCHAR (500) NULL,
    CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_Consulta_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([IdCliente])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Amarrilo,Palido,Azul Griacasea,Normal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Consulta';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Conclusion de la Consulta', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Consulta', @level2type = N'COLUMN', @level2name = N'Diagnostico';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Diagnostico Confirmado,o Rechazado', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Consulta', @level2type = N'COLUMN', @level2name = N'DiagnosticoEstado';

