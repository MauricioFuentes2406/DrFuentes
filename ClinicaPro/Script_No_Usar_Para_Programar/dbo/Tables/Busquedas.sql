CREATE TABLE [dbo].[Busquedas] (
    [IdItem]                INT         NOT NULL,
    [Nombre]                NCHAR (70)  NOT NULL,
    [Síntoma]               NCHAR (500) NULL,
    [Tratamiento]           NCHAR (500) NULL,
    [EnfermedadRelacionada] NCHAR (500) NULL,
    [DescripcionAdicional]  NCHAR (200) NULL,
    CONSTRAINT [PK_Busquedas] PRIMARY KEY CLUSTERED ([IdItem] ASC),
    CONSTRAINT [UQ__Busqueda__75E3EFCFEF0D172E] UNIQUE NONCLUSTERED ([Nombre] ASC)
);


GO
CREATE NONCLUSTERED INDEX [Busquedas_Nombre]
    ON [dbo].[Busquedas]([Nombre] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Durante Consulta , Buscar informacion sombre sintoma , medicina o enfermedad', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Busquedas';

