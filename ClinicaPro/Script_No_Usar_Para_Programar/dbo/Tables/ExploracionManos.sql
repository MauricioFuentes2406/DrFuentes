CREATE TABLE [dbo].[ExploracionManos] (
    [idExploracionManos] INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]             NVARCHAR (50)  NOT NULL,
    [TextoInformativo]   NVARCHAR (250) NOT NULL,
    CONSTRAINT [PK_ExploracionManos] PRIMARY KEY CLUSTERED ([idExploracionManos] ASC)
);

