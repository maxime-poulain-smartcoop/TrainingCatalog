-- Actual SQL merge script that inserts or updates should be used instead of simple inserts

IF (NOT EXISTS(SELECT * FROM [dbo].[AudienceType] WHERE Id <= 2))
BEGIN
    INSERT INTO [dbo].AudienceType ([Id], [LabelKey], [DescriptionKey]) values (1, 'Individuel', ''); -- Actual translation keys should be used here.
    INSERT INTO [dbo].AudienceType ([Id], [LabelKey], [DescriptionKey]) values (2, 'Collectif', '');
END
