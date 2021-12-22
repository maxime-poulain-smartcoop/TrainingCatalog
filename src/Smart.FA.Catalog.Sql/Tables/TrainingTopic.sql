CREATE TABLE [dbo].[TrainingTopic]
(
	[TrainingId] INT NOT NULL,
    [TopicId]    INT NOT NULL,
    CONSTRAINT [FK_TrainingTopic_Training] FOREIGN KEY ([TrainingId]) REFERENCES [Training]([Id]),
    CONSTRAINT [FK_TrainingTopic_Topic]    FOREIGN KEY ([TopicId])    REFERENCES [Topic]([Id]),
    CONSTRAINT [PK_TrainingTopic]           PRIMARY KEY ([TrainingId],[TopicId]),
)

GO

CREATE INDEX [IX_TrainingTopic_TrainingId_TrainingId] ON [dbo].[TrainingTopic] ([TrainingId])
GO

CREATE INDEX [IX_TrainingTopic_TrainingId_TopicId] ON [dbo].[TrainingTopic] ([TopicId])
