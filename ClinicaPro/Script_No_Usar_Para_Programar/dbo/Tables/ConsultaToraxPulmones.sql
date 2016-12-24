CREATE TABLE [dbo].[ConsultaToraxPulmones] (
    [IdConsulta]                        INT     NOT NULL,
    [RespiracionDiafragmaticaAbdominal] TINYINT NOT NULL,
    [ExpasibilidadToraxica]             TINYINT NOT NULL,
    [AscultacionMurmulloVescular]       TINYINT NOT NULL,
    [RuidosAgregados]                   TINYINT NOT NULL,
    [SonoridadPulmunar]                 BIT     NULL,
    CONSTRAINT [PK_ConsultaToraxPulmones] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_ConsultaToraxPulmones_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta]),
    CONSTRAINT [FK_ConsultaToraxPulmones_Consulta.RespuestasGenerales_AscultacionMurmulloVescular] FOREIGN KEY ([AscultacionMurmulloVescular]) REFERENCES [dbo].[Consulta.RespuestasGenerales] ([idRespuestaGeneral]),
    CONSTRAINT [FK_ConsultaToraxPulmones_Consulta.RespuestasGenerales_ExpasibilidadToraxica] FOREIGN KEY ([ExpasibilidadToraxica]) REFERENCES [dbo].[Consulta.RespuestasGenerales] ([idRespuestaGeneral]),
    CONSTRAINT [FK_ConsultaToraxPulmones_Consulta.RespuestasGenerales_RespiracionDiafragmaticaAbdominal] FOREIGN KEY ([RespiracionDiafragmaticaAbdominal]) REFERENCES [dbo].[Consulta.RespuestasGenerales] ([idRespuestaGeneral]),
    CONSTRAINT [FK_ConsultaToraxPulmones_Consulta.RespuestasGenerales_RuidosAgregados] FOREIGN KEY ([RuidosAgregados]) REFERENCES [dbo].[Consulta.RespuestasGenerales] ([idRespuestaGeneral])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'DefectoNormal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ConsultaToraxPulmones', @level2type = N'COLUMN', @level2name = N'SonoridadPulmunar';

