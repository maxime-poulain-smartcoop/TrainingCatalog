CREATE TABLE [dbo].[AudienceType]
(
	[Id]             INT          NOT NULL PRIMARY KEY IDENTITY(1,1),
    [LabelKey]       VARCHAR(150) NOT NULL,
    [DescriptionKey] VARCHAR(250) NULL,
    [CreatedAt]      DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
    [ModifiedAt]     DATETIME2(0) NULL,
    [DeletedAt]      DATETIME2(0) NULL
)
