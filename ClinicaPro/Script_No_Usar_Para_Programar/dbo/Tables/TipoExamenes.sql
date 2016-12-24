CREATE TABLE [dbo].[TipoExamenes] (
    [idTipoExamen]    INT        NOT NULL,
    [Nombre]          NCHAR (40) NULL,
    [CostoExamen]     NCHAR (40) NULL,
    [DiasDeCultivo]   INT        NULL,
    [isEnviado]       BIT        NULL,
    [ProcentajeEnvio] INT        NULL,
    CONSTRAINT [PK_TipoExamenes] PRIMARY KEY CLUSTERED ([idTipoExamen] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Si envia a Chepe O Ahi', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TipoExamenes', @level2type = N'COLUMN', @level2name = N'isEnviado';

