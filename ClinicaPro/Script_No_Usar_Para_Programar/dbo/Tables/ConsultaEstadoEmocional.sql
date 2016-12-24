CREATE TABLE [dbo].[ConsultaEstadoEmocional] (
    [IdConsulta]      INT                  NOT NULL,
    [Depresion]       BIT                  NOT NULL,
    [Nervioso]        BIT                  NOT NULL,
    [Tensión]         BIT                  NOT NULL,
    [Irritabilidad]   BIT                  NOT NULL,
    [AlteracionSueño] BIT                  NOT NULL,
    [Alucinaciones]   BIT                  NOT NULL,
    [Otro]            VARCHAR (100) SPARSE NULL,
    CONSTRAINT [PK_ConsultaEstadoEmocional] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_ConsultaEstadoEmocional_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);

