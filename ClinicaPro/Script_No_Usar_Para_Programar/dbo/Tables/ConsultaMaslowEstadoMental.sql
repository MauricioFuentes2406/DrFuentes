CREATE TABLE [dbo].[ConsultaMaslowEstadoMental] (
    [IdConsulta]        INT     NOT NULL,
    [idResultadoMaslow] TINYINT NOT NULL,
    CONSTRAINT [PK_ConsultaMaslow] PRIMARY KEY CLUSTERED ([IdConsulta] ASC, [idResultadoMaslow] ASC),
    CONSTRAINT [FK_ConsultaMaslow_MaslowResultado] FOREIGN KEY ([idResultadoMaslow]) REFERENCES [dbo].[MaslowResultado] ([IdResultadoMaslow]),
    CONSTRAINT [FK_ConsultaMaslowEstadoMental_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);

