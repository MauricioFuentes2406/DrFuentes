CREATE TABLE [dbo].[ConsultaAparatoDigestivo] (
    [IdConsulta]    INT         NOT NULL,
    [Dolor]         BIT         NOT NULL,
    [FaltaApetito]  BIT         NOT NULL,
    [Nauseas]       BIT         NOT NULL,
    [Vomito]        TINYINT     NOT NULL,
    [Diarrea]       BIT         NOT NULL,
    [Estreñimiento] BIT         NOT NULL,
    [Pirosis]       BIT         NOT NULL,
    [Colicos]       BIT         NOT NULL,
    [Distencion]    BIT         NOT NULL,
    [Detalles]      NCHAR (400) NULL,
    CONSTRAINT [PK_ConsultaAparatoDigestivo] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_ConsultaAparatoDigestivo_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Alimenticio,Rojo,ETC', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ConsultaAparatoDigestivo', @level2type = N'COLUMN', @level2name = N'Vomito';

