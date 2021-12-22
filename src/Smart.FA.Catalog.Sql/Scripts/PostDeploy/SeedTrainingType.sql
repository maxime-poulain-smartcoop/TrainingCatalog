-- Actual SQL merge script that inserts or updates should be used instead of simple inserts

IF (NOT EXISTS(SELECT * FROM [dbo].[TrainingType] WHERE Id <= 4))
BEGIN
    INSERT INTO [dbo].[TrainingType]([Id], [LabelKey], [DescriptionKey])  VALUES
        (1, 'Est professionnelle / professionnalisisante', ''), -- Actual translation keys should be used here.
        (2, 'Est un enseignement de matière scolaires / assimilées', ''),
        (3, 'Rentre dans le cadre de l''éducation permanente', ''),
        (4, 'Est un cours de langue', '');
END
