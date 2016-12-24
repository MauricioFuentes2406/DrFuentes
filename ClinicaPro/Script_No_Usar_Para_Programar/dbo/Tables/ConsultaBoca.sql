CREATE TABLE [dbo].[ConsultaBoca] (
    [IdConsulta]        INT NOT NULL,
    [Adoncia]           BIT NOT NULL,
    [Protesis_Dentakes] BIT NOT NULL,
    [Calzas]            BIT NOT NULL,
    [UlcerasOrales]     BIT NOT NULL,
    [LenguaDolorosa]    BIT NOT NULL,
    [Faringitis]        BIT NOT NULL,
    [Amigdalitis]       BIT NOT NULL,
    [Laringitis]        BIT NOT NULL,
    [Ronquera]          BIT NOT NULL,
    [Disfagia]          BIT NULL,
    CONSTRAINT [PK_ConsultaBoca] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_ConsultaBoca_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);

