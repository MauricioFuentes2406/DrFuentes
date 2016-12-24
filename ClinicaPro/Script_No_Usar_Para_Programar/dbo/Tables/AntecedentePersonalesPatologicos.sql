CREATE TABLE [dbo].[AntecedentePersonalesPatologicos] (
    [IdConsulta]       INT               NOT NULL,
    [Parotiditis]      TINYINT           NULL,
    [Sarampion]        TINYINT           NULL,
    [Rubeola]          TINYINT           NULL,
    [Varicela]         TINYINT           NULL,
    [Fiebre_Reumatica] TINYINT           NULL,
    [Bronquitis]       TINYINT           NULL,
    [Paludismo]        TINYINT           NULL,
    [Otro]             NCHAR (90) SPARSE NULL,
    CONSTRAINT [PK_AntecedentePersonalesPatologicos] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_AntecedentePersonalesPatologicos_Bronquitis] FOREIGN KEY ([Bronquitis]) REFERENCES [dbo].[Consulta.RespuestasGenerales] ([idRespuestaGeneral]),
    CONSTRAINT [FK_AntecedentePersonalesPatologicos_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta]),
    CONSTRAINT [FK_AntecedentePersonalesPatologicos_Fiebre_Reumatica] FOREIGN KEY ([Fiebre_Reumatica]) REFERENCES [dbo].[Consulta.RespuestasGenerales] ([idRespuestaGeneral]),
    CONSTRAINT [FK_AntecedentePersonalesPatologicos_Paludismo] FOREIGN KEY ([Paludismo]) REFERENCES [dbo].[Consulta.RespuestasGenerales] ([idRespuestaGeneral]),
    CONSTRAINT [FK_AntecedentePersonalesPatologicos_Parotiditis] FOREIGN KEY ([Parotiditis]) REFERENCES [dbo].[Consulta.RespuestasGenerales] ([idRespuestaGeneral]),
    CONSTRAINT [FK_AntecedentePersonalesPatologicos_Rubeola] FOREIGN KEY ([Rubeola]) REFERENCES [dbo].[Consulta.RespuestasGenerales] ([idRespuestaGeneral]),
    CONSTRAINT [FK_AntecedentePersonalesPatologicos_Sarampion] FOREIGN KEY ([Sarampion]) REFERENCES [dbo].[Consulta.RespuestasGenerales] ([idRespuestaGeneral]),
    CONSTRAINT [FK_AntecedentePersonalesPatologicos_Varicela] FOREIGN KEY ([Varicela]) REFERENCES [dbo].[Consulta.RespuestasGenerales] ([idRespuestaGeneral])
);

