CREATE TABLE [dbo].[ConsultaOidos] (
    [IdConsulta] INT NOT NULL,
    [Acusia]     BIT NOT NULL,
    [Hipocusia]  BIT NOT NULL,
    [Hipercusia] BIT NOT NULL,
    [Otalgia]    BIT NOT NULL,
    [Otorrea]    BIT NOT NULL,
    [Tinitus]    BIT NOT NULL,
    CONSTRAINT [PK_ConsultaOidos] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_ConsultaOidos_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);

