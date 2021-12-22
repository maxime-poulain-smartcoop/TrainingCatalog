CREATE TABLE [dbo].[TrainingType]
(
	[Id]                        INT            NOT NULL PRIMARY KEY,
    [LabelKey]                  VARCHAR(150)   NOT NULL,
    [DescriptionKey]            VARCHAR(250)   NULL,
    [CreatedAt]                 DATETIME2(0)   NOT NULL DEFAULT(GETUTCDATE()),
    [ModifiedAt]                DATETIME2(0)   NULL,
    [DeletedAt]                 DATETIME2(0)   NULL
)
