CREATE TABLE [dbo].[ConsultaCuello] (
    [IdConsulta]             INT     NOT NULL,
    [ConfiguracionDelCuello] BIT     NULL,
    [Simetrico]              BIT     NULL,
    [PresionVenosa]          TINYINT NULL,
    [EdemaPerifericoPierna]  BIT     NULL,
    [LesionesPiel]           BIT     NULL,
    [AdenoPatias]            BIT     NULL,
    CONSTRAINT [PK_ConsultaCuello] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_ConsultaCuello_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);

