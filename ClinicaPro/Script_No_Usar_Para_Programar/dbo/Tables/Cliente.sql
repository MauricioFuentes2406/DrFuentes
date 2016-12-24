CREATE TABLE [dbo].[Cliente] (
    [IdCliente]    INT        NOT NULL,
    [Nombre]       NCHAR (50) NOT NULL,
    [Cedula]       NCHAR (11) NOT NULL,
    [Edad]         TINYINT    NOT NULL,
    [Sexo]         BIT        NOT NULL,
    [isExtranjero] BIT        NOT NULL,
    [Celular]      INT        NOT NULL,
    [Estado]       TINYINT    NULL,
    [Apellido2]    NCHAR (25) NOT NULL,
    [Apellido1]    NCHAR (25) NOT NULL,
    [TipoSangre]   NCHAR (3)  NULL,
    [Email]        NCHAR (40) NULL,
    [Ciudad]       NCHAR (30) NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([IdCliente] ASC)
);


GO
CREATE NONCLUSTERED INDEX [Index_Cliente_NombreAPellidos]
    ON [dbo].[Cliente]([Nombre] ASC, [Apellido2] ASC, [Apellido1] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Formato "#-####-####"  numero,rayita,cuatro numeros,rayita,cuator numeros', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Cliente';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Deudor,Valorar Cerar', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Cliente', @level2type = N'COLUMN', @level2name = N'Estado';

