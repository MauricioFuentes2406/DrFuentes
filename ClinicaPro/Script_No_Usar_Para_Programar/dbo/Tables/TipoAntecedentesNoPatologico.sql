CREATE TABLE [dbo].[TipoAntecedentesNoPatologico] (
    [IdTipoAntecedenteNoPatologico] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]                        NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_AntecedentoNoPatologico] PRIMARY KEY CLUSTERED ([IdTipoAntecedenteNoPatologico] ASC)
);

