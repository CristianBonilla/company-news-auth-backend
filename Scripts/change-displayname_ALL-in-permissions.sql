BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627084051_ChangeDisplayNameALLInPermissions')
BEGIN
    EXEC(N'DELETE FROM [dbo].[News]
    WHERE [Id] = ''0c42bc5e-9c6d-45c9-8bf6-ae3983da4dd4'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627084051_ChangeDisplayNameALLInPermissions')
BEGIN
    EXEC(N'DELETE FROM [dbo].[News]
    WHERE [Id] = ''5aad402e-a2f3-4103-83e1-097e4219a4f8'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627084051_ChangeDisplayNameALLInPermissions')
BEGIN
    EXEC(N'DELETE FROM [dbo].[News]
    WHERE [Id] = ''6c58d694-e913-4b81-a74b-26d3795d48a1'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627084051_ChangeDisplayNameALLInPermissions')
BEGIN
    EXEC(N'DELETE FROM [dbo].[News]
    WHERE [Id] = ''cb7d7cd3-0510-4203-9176-2f6b3b937519'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627084051_ChangeDisplayNameALLInPermissions')
BEGIN
    EXEC(N'DELETE FROM [dbo].[News]
    WHERE [Id] = ''f0660d32-93f8-438b-80db-8df975641bc8'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627084051_ChangeDisplayNameALLInPermissions')
BEGIN
    EXEC(N'DELETE FROM [dbo].[News]
    WHERE [Id] = ''f9b55d06-c802-4e39-b371-dbbf097ca9cb'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627084051_ChangeDisplayNameALLInPermissions')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Title') AND [object_id] = OBJECT_ID(N'[dbo].[News]'))
        SET IDENTITY_INSERT [dbo].[News] ON;
    EXEC(N'INSERT INTO [dbo].[News] ([Id], [Description], [Title])
    VALUES (''3f1e5227-b380-4df1-bdd6-fd30c9ef6649'', N''Figuran ejecutivas de D1, Cencosud, Cerrejón y Comparta. Tres de ellas asumieron en los últimos dos años'', N''Solo hay 4 mujeres en los CEO de las 100 empresas más grandes''),
    (''eac51bda-51f6-4bd7-8cbd-33d75729c881'', N''El préstamo, incluye recursos para la construcción del Parque Solar San Fernando (Meta) por cerca de US$35 millones'', N''Crédito de Scotiabank Colpatria por US$100 millones a AES Colombia''),
    (''7647ea63-46b0-4c71-b9db-29f1c972eac7'', N''Se trata de Shopify, que brindará soporte y apoyo a comerciantes que no usan directamente su plataforma'', N''Google y Facebook firman asociación con empresa de pago en línea''),
    (''78451362-86fc-4662-9fd6-711b9565628e'', N''Los delincuentes envían cartas a las viviendas de sus víctimas haciéndose pasar por la compañía Ledger. En el documento piden a las personas compartir su información en un nuevo dispositivo para supuestamente mantener los datos seguros'', N''Bitcóin: hackers tienen nuevo método para robar criptomonedas''),
    (''c2c9f618-53a0-49ce-8e0f-b1366e659937'', N''Habi, la startup con sede en Colombia, anunció este miércoles que recaudó 100 millones de dólares en la ronda de financiación de serie B por parte de SoftBank Latin American Fund, junto con inversores de Inspired Capital, Tiger Global, Homebrew y 8VC'', N''''''Startup'''' Habi recauda 100 millones de dólares en ronda de inversión''),
    (''fc634a41-70da-4d63-ad07-eea34b883fe8'', N''Después de un año de ausencia por la pandemia, finalmente el Electronic Entertainment Expo (E3) volvió con varias novedades para los amantes de los videojuegos, aunque no cumplió todas las expectativas en materia de los anuncios que se tenían presupuestados'', N''E3: los mejores anuncios que dejó el evento en su edición virtual'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Title') AND [object_id] = OBJECT_ID(N'[dbo].[News]'))
        SET IDENTITY_INSERT [dbo].[News] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627084051_ChangeDisplayNameALLInPermissions')
BEGIN
    EXEC(N'UPDATE [dbo].[Permission] SET [DisplayName] = ''Todo''
    WHERE [Id] = ''4f39c31e-ca99-4782-b585-ae847185a292'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627084051_ChangeDisplayNameALLInPermissions')
BEGIN
    EXEC(N'UPDATE [dbo].[Permission] SET [DisplayName] = ''Todo''
    WHERE [Id] = ''e5472dd9-f0c1-4233-be69-cb59425a8407'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627084051_ChangeDisplayNameALLInPermissions')
BEGIN
    EXEC(N'UPDATE [dbo].[Permission] SET [DisplayName] = ''Todo''
    WHERE [Id] = ''d3683aa7-defb-48ea-8459-b17a34a0c363'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627084051_ChangeDisplayNameALLInPermissions')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210627084051_ChangeDisplayNameALLInPermissions', N'5.0.7');
END;
GO

COMMIT;
GO

