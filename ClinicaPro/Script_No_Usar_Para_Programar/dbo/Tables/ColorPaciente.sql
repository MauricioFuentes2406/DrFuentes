CREATE TABLE [dbo].[ColorPaciente] (
    [idColorPaciente]  INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]           NVARCHAR (30)  NOT NULL,
    [TextoInformativo] NVARCHAR (250) NOT NULL,
    CONSTRAINT [PK_ColorPaciente] PRIMARY KEY CLUSTERED ([idColorPaciente] ASC),
    CONSTRAINT [IX_ColorPaciente_Unique] UNIQUE NONCLUSTERED ([idColorPaciente] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Color Palido,amarrillo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ColorPaciente', @level2type = N'COLUMN', @level2name = N'idColorPaciente';

