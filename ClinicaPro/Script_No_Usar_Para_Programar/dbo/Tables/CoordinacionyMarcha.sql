CREATE TABLE [dbo].[CoordinacionyMarcha] (
    [IdConsulta]    INT        NOT NULL,
    [Dedo_Nariz]    NCHAR (10) NOT NULL,
    [Talon_Rodilla] NCHAR (10) NOT NULL,
    [Romberg]       NCHAR (10) NOT NULL,
    CONSTRAINT [PK_CoordinacionyMarcha] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_CoordinacionyMarcha_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);

