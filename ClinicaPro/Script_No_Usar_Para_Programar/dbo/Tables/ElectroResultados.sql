CREATE TABLE [dbo].[ElectroResultados] (
    [idConsulta]       INT             NOT NULL,
    [idCliente]        INT             NOT NULL,
    [ElectroResultado] VARBINARY (MAX) NULL,
    CONSTRAINT [PK_ElectroResultados] PRIMARY KEY CLUSTERED ([idConsulta] ASC, [idCliente] ASC) ON [electroCardio],
    CONSTRAINT [FK_ElectroResultados_Cliente] FOREIGN KEY ([idCliente]) REFERENCES [dbo].[Cliente] ([IdCliente]),
    CONSTRAINT [FK_ElectroResultados_Consulta] FOREIGN KEY ([idConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
) TEXTIMAGE_ON [electroCardio];

