CREATE TABLE [dbo].[ConsultaReflejos] (
    [IdConsulta]              INT                NOT NULL,
    [R_ValoracionGeneral]     NCHAR (10)         NULL,
    [R_Orbicular_De_Los_Ojos] BIT                NULL,
    [R_Carneano]              BIT                NULL,
    [R_Mentoniano]            BIT                NULL,
    [R_Bicipital]             BIT                NULL,
    [R_Tricipital]            BIT                NULL,
    [R_Radial]                BIT                NULL,
    [R_Adominales]            BIT                NULL,
    [R_Patelar]               BIT                NULL,
    [Observacion]             NCHAR (300) SPARSE NULL,
    CONSTRAINT [PK_ConsultaReflejos] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_ConsultaReflejos_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Bien,Ma,.Masomenos', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ConsultaReflejos', @level2type = N'COLUMN', @level2name = N'R_ValoracionGeneral';

