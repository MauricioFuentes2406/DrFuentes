CREATE TABLE [dbo].[AntecedentesNoPatologicos] (
    [IdConsulta]           INT         NOT NULL,
    [Tabaquismo_UltimaVez] TINYINT     NULL,
    [Alcohol_UltimaVez]    TINYINT     NULL,
    [Droga_UltimaVez]      TINYINT     NULL,
    [DrograNombres]        NCHAR (200) NULL,
    [Vacunas__UltimaVez]   TINYINT     NULL,
    [VacunasNombres]       NCHAR (200) NULL,
    CONSTRAINT [PK_AntecedentesNoPatologicos] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_AntecedentesNoPatologicos_EscalaTiempoAlcohol] FOREIGN KEY ([Alcohol_UltimaVez]) REFERENCES [dbo].[EscalaTiempo] ([idEscalaTiempo]),
    CONSTRAINT [FK_AntecedentesNoPatologicos_EscalaTiempoDroga] FOREIGN KEY ([Droga_UltimaVez]) REFERENCES [dbo].[EscalaTiempo] ([idEscalaTiempo]),
    CONSTRAINT [FK_AntecedentesNoPatologicos_EscalaTiempoTabaquismo] FOREIGN KEY ([Tabaquismo_UltimaVez]) REFERENCES [dbo].[EscalaTiempo] ([idEscalaTiempo]),
    CONSTRAINT [PK_AntecedentesNoPatologicos_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);

