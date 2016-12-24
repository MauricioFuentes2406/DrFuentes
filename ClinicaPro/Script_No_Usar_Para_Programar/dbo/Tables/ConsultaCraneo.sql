CREATE TABLE [dbo].[ConsultaCraneo] (
    [IdConsulta]        INT     NOT NULL,
    [TamañaFormaNormal] BIT     NOT NULL,
    [Simetrico]         BIT     NOT NULL,
    [AlteracionOsea]    BIT     NOT NULL,
    [Cefalea]           BIT     NOT NULL,
    [Sincope]           BIT     NOT NULL,
    [Mareos]            TINYINT NOT NULL,
    [PerdidaConciencia] BIT     NOT NULL,
    [Prurito]           BIT     NOT NULL,
    CONSTRAINT [PK_ConsultaCraneo] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_ConsultaCraneo_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);

