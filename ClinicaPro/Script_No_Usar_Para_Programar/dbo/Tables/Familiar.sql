CREATE TABLE [dbo].[Familiar] (
    [IdFamiliar] TINYINT    IDENTITY (1, 1) NOT NULL,
    [Nombre]     NCHAR (25) NOT NULL,
    CONSTRAINT [PK_Familiar] PRIMARY KEY CLUSTERED ([IdFamiliar] ASC),
    CONSTRAINT [UQ_Nombre_Familiar] UNIQUE NONCLUSTERED ([Nombre] ASC)
);

