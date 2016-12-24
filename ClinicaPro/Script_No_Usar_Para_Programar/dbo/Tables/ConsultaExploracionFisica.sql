CREATE TABLE [dbo].[ConsultaExploracionFisica] (
    [IdConsulta]                INT            NOT NULL,
    [idColorPaciente]           INT            NULL,
    [idExploracionManos]        INT            NULL,
    [Peso]                      DECIMAL (5, 2) NOT NULL,
    [Temperatura]               DECIMAL (5, 2) NULL,
    [Talla]                     DECIMAL (5, 2) NOT NULL,
    [PresionArterialSistolico]  TINYINT        NULL,
    [PresionArterialDiastolico] TINYINT        NULL,
    [FrecuenciaCardiaca]        TINYINT        NULL,
    [FrecuenciaRespiratoria]    TINYINT        NULL,
    [IndiceMasaCorporal]        AS             ([Peso]/([talla]*[talla])),
    CONSTRAINT [PK_ConsultaExploracionFisica] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_ConsultaExploracionFisica_ColorPaciente] FOREIGN KEY ([idColorPaciente]) REFERENCES [dbo].[ColorPaciente] ([idColorPaciente]),
    CONSTRAINT [FK_ConsultaExploracionFisica_ExploracionManos] FOREIGN KEY ([idExploracionManos]) REFERENCES [dbo].[ExploracionManos] ([idExploracionManos]),
    CONSTRAINT [PK_ConsultaExploracionFisica_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Kilogramos', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ConsultaExploracionFisica', @level2type = N'COLUMN', @level2name = N'Peso';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Centigrados', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ConsultaExploracionFisica', @level2type = N'COLUMN', @level2name = N'Temperatura';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'metros', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ConsultaExploracionFisica', @level2type = N'COLUMN', @level2name = N'Talla';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'60 y 85 normal,>90 taquicardia,<60Bradicardia', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ConsultaExploracionFisica', @level2type = N'COLUMN', @level2name = N'PresionArterialSistolico';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Latido por minuto(lat/min)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ConsultaExploracionFisica', @level2type = N'COLUMN', @level2name = N'FrecuenciaCardiaca';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Respiracion por Minuto (resp/min)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ConsultaExploracionFisica', @level2type = N'COLUMN', @level2name = N'FrecuenciaRespiratoria';

