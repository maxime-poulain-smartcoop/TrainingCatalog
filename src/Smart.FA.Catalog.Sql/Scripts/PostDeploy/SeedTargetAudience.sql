-- Actual SQL merge script that inserts or updates should be used instead of simple inserts

IF (NOT EXISTS(SELECT * FROM [dbo].[TargetAudience] WHERE Id <= 3))
BEGIN
    INSERT INTO TargetAudience (id, labelKey, [DesriptionKey]) VALUES
    (1, 'Salarié en entreprise', ''), -- Actual translation keys should be used here.
    (2, 'Personne avec curus de formation pro', ''),
    (3, 'Tout public', '');
END
