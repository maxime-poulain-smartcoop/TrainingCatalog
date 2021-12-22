CREATE TABLE [dbo].[Address]
(
	[Id]         INT          NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Place]      NVARCHAR(50) NOT NULL,
    [TrainingId] INT          NOT NULL,
    [CreatedAt]  DATETIME2(0) NOT NULL DEFAULT(GETUTCDATE()),
    [ModifiedAt] DATETIME2(0) NULL,
    [DeletedAt]  DATETIME2(0) NULL,

    CONSTRAINT [FK_Address_Training] FOREIGN KEY ([TrainingId]) REFERENCES [Training]([Id])
)

GO

CREATE UNIQUE INDEX [IX_Address_TrainingId] ON [dbo].[Address] ([TrainingId])
