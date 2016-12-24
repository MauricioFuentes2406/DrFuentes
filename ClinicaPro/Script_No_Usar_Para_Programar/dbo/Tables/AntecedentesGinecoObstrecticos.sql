CREATE TABLE [dbo].[AntecedentesGinecoObstrecticos] (
    [idConsulta]  INT     NOT NULL,
    [FUM]         DATE    NULL,
    [Gestaciones] TINYINT NULL,
    [Partos]      TINYINT NULL,
    [Abortos]     TINYINT NULL,
    [Cecareas]    TINYINT NULL,
    [FUPAC]       DATE    NULL,
    CONSTRAINT [PK_AntecedentesGinecoObstrecticos] PRIMARY KEY CLUSTERED ([idConsulta] ASC),
    CONSTRAINT [FK_AntecedentesGinecoObstrecticos_Consulta1] FOREIGN KEY ([idConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);

