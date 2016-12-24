CREATE TABLE [dbo].[Seguimiento] (
    [IdSeguimiento]    INT        NOT NULL,
    [IdConsulta]       INT        NOT NULL,
    [FechaSeguimiento] DATE       NULL,
    [Prioridad]        INT        NULL,
    [Descripcion]      NCHAR (50) NULL,
    [Estado]           INT        NULL,
    CONSTRAINT [PK_Seguimiento] PRIMARY KEY CLUSTERED ([IdSeguimiento] ASC, [IdConsulta] ASC),
    CONSTRAINT [FK_Seguimiento_Consulta1] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'va del 1 al 5', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Seguimiento', @level2type = N'COLUMN', @level2name = N'Prioridad';

