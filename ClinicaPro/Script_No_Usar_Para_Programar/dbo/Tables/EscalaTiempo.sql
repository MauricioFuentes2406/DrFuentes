CREATE TABLE [dbo].[EscalaTiempo] (
    [idEscalaTiempo] TINYINT    IDENTITY (1, 1) NOT NULL,
    [Nombre]         NCHAR (25) NOT NULL,
    CONSTRAINT [PK_EscalaTiempo] PRIMARY KEY CLUSTERED ([idEscalaTiempo] ASC),
    CONSTRAINT [IX_EscalaTiempo_Unique] UNIQUE NONCLUSTERED ([Nombre] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario Escoge, si Años,Meses,Dias,Semanas,Horas etc , 0 igual NO', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EscalaTiempo';

