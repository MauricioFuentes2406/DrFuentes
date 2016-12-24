CREATE TABLE [dbo].[EscalaMaslow] (
    [idEscalaMaslow] TINYINT      IDENTITY (1, 1) NOT NULL,
    [IdVariable]     TINYINT      NOT NULL,
    [Respuesta]      VARCHAR (50) NOT NULL,
    [Puntaje]        TINYINT      NOT NULL,
    CONSTRAINT [PK_EscalaMaslow_1] PRIMARY KEY CLUSTERED ([idEscalaMaslow] ASC),
    CONSTRAINT [FK_EscalaMaslow_MaslowVariables] FOREIGN KEY ([IdVariable]) REFERENCES [dbo].[MaslowVariables] ([idVariable])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Evalua el nivel de conciencia de Paciente  , 
Se divide en 3 Varibles que subdivide  varias preguntas ,  lo que se guarda en la  Consulta es puntaje total de todas las preguntas 
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EscalaMaslow';

