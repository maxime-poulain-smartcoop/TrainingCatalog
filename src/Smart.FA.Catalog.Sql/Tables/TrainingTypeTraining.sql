CREATE TABLE [dbo].[TrainingTypeTraining]
(
	[TrainingId]     INT NOT NULL,
    [TrainingTypeId] INT NOT NULL,

    CONSTRAINT [PK_TrainingTypeTraining]              PRIMARY KEY ([TrainingId],[TrainingTypeId]),
    CONSTRAINT [FK_TrainingTypeTraining_Training]     FOREIGN KEY ([TrainingId])     REFERENCES [Training]([Id]),
    CONSTRAINT [FK_TrainingTypeTraining_TrainingType] FOREIGN KEY ([TrainingTypeId]) REFERENCES [TrainingType]([Id]),
)

GO

CREATE INDEX [IX_TrainingTypeTraining_TrainingId] ON [dbo].[TrainingTypeTraining] ([TrainingId])
GO

CREATE INDEX [IX_TrainingTypeTraining_TrainingTypeId] ON [dbo].[TrainingTypeTraining] ([TrainingTypeId])
