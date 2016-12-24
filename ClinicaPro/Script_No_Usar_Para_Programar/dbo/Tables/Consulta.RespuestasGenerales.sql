CREATE TABLE [dbo].[Consulta.RespuestasGenerales] (
    [idRespuestaGeneral] TINYINT    IDENTITY (1, 1) NOT NULL,
    [Nombre]             NCHAR (30) NULL,
    CONSTRAINT [PK_Consulta.RespuestasGenerales] PRIMARY KEY CLUSTERED ([idRespuestaGeneral] ASC),
    CONSTRAINT [IX_Consulta.RespuestasGeneralesUnique] UNIQUE NONCLUSTERED ([Nombre] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla para cargar comboBox con respuestas generales

Usado en Tablas
 AntecedentesPersonalesPatologicos
ConsultaToraxPulmones

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Consulta.RespuestasGenerales';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Si,No.No Sabe', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Consulta.RespuestasGenerales', @level2type = N'COLUMN', @level2name = N'Nombre';

