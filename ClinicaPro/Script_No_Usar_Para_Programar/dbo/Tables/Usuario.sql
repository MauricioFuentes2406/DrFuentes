CREATE TABLE [dbo].[Usuario] (
    [IdUsuario]     INT          NOT NULL,
    [Username]      VARCHAR (50) NOT NULL,
    [Password]      VARCHAR (50) NOT NULL,
    [Estado]        INT          NOT NULL,
    [IdTipoUsuario] INT          NULL,
    [Nombre]        VARCHAR (50) NULL,
    [Telefono]      INT          NULL,
    [Apellido1]     VARCHAR (50) NULL,
    [Apellido2]     VARCHAR (50) NULL,
    [FraseRecordar] VARCHAR (50) NULL,
    [Email]         VARCHAR (50) NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([IdUsuario] ASC),
    CONSTRAINT [FK_Usuario_TipoUsuario] FOREIGN KEY ([IdTipoUsuario]) REFERENCES [dbo].[TipoUsuario] ([idTipoUsuairo])
);

