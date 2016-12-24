CREATE TABLE [dbo].[TipoAlergias] (
    [idAlergia]      INT          NOT NULL,
    [TipoAlergia]    VARCHAR (50) NULL,
    [Especificacion] VARCHAR (50) NULL,
    CONSTRAINT [PK_Alergias] PRIMARY KEY CLUSTERED ([idAlergia] ASC)
);

