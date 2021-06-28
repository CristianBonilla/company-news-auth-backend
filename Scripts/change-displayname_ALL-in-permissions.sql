BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628042008_ChangeDisplayNameALLInPermissions')
BEGIN
    EXEC(N'UPDATE [dbo].[Permission] SET [DisplayName] = ''Todo''
    WHERE [Id] = ''4f39c31e-ca99-4782-b585-ae847185a292'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628042008_ChangeDisplayNameALLInPermissions')
BEGIN
    EXEC(N'UPDATE [dbo].[Permission] SET [DisplayName] = ''Todo''
    WHERE [Id] = ''e5472dd9-f0c1-4233-be69-cb59425a8407'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628042008_ChangeDisplayNameALLInPermissions')
BEGIN
    EXEC(N'UPDATE [dbo].[Permission] SET [DisplayName] = ''Todo''
    WHERE [Id] = ''d3683aa7-defb-48ea-8459-b17a34a0c363'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210628042008_ChangeDisplayNameALLInPermissions')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210628042008_ChangeDisplayNameALLInPermissions', N'5.0.7');
END;
GO

COMMIT;
GO

