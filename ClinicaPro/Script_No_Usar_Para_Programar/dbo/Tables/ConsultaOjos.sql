CREATE TABLE [dbo].[ConsultaOjos] (
    [IdConsulta]           INT         NOT NULL,
    [PerdidaAgudezaVisual] NCHAR (100) NULL,
    [Diplopia]             BIT         NOT NULL,
    [FotoFobia]            BIT         NOT NULL,
    [Lentes]               BIT         NOT NULL,
    [Xerolftamia]          BIT         NOT NULL,
    [Epifora]              BIT         NOT NULL,
    [Midriasis]            BIT         NOT NULL,
    CONSTRAINT [PK_ConsultaOjos] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_ConsultaOjos_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Por defecto Control txt "No"', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ConsultaOjos', @level2type = N'COLUMN', @level2name = N'PerdidaAgudezaVisual';

