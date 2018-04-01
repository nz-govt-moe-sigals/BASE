﻿DECLARE @CurrentMigration [nvarchar](max)

IF object_id('[dbo].[__MigrationHistory]') IS NOT NULL
    SELECT @CurrentMigration =
        (SELECT TOP (1) 
        [Project1].[MigrationId] AS [MigrationId]
        FROM ( SELECT 
        [Extent1].[MigrationId] AS [MigrationId]
        FROM [dbo].[__MigrationHistory] AS [Extent1]
        WHERE [Extent1].[ContextKey] = N'App.Core.Infrastructure.Db.Migrations.Configuration'
        )  AS [Project1]
        ORDER BY [Project1].[MigrationId] DESC)

IF @CurrentMigration IS NULL
    SET @CurrentMigration = '0'

IF @CurrentMigration < '201708180252005_Entities.Example'
BEGIN
    CREATE TABLE [dbo].[Examples] (
        [Id] [uniqueidentifier] NOT NULL,
        [Owner] [nvarchar](max),
        [PublicText] [nvarchar](max),
        [SensitiveText] [nvarchar](max),
        [PrivateText] [nvarchar](max),
        CONSTRAINT [PK_dbo.Examples] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[Tenants] (
        [Id] [uniqueidentifier] NOT NULL,
        [Enabled] [bit] NOT NULL,
        [Key] [nvarchar](max),
        [DisplayName] [nvarchar](max),
        CONSTRAINT [PK_dbo.Tenants] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[TenantClaims] (
        [Id] [uniqueidentifier] NOT NULL,
        [OwnerFK] [uniqueidentifier] NOT NULL,
        [RecordState] [int] NOT NULL,
        [Authority] [nvarchar](max),
        [AuthoritySignature] [nvarchar](max),
        [Key] [nvarchar](max),
        [Value] [nvarchar](max),
        [Tenant_Id] [uniqueidentifier],
        CONSTRAINT [PK_dbo.TenantClaims] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_Tenant_Id] ON [dbo].[TenantClaims]([Tenant_Id])
    CREATE TABLE [dbo].[TenantProperties] (
        [Id] [uniqueidentifier] NOT NULL,
        [OwnerFK] [uniqueidentifier] NOT NULL,
        [RecordState] [int] NOT NULL,
        [Key] [nvarchar](max),
        [Value] [nvarchar](max),
        [Tenant_Id] [uniqueidentifier],
        CONSTRAINT [PK_dbo.TenantProperties] PRIMARY KEY ([Id])
    )
    CREATE INDEX [IX_Tenant_Id] ON [dbo].[TenantProperties]([Tenant_Id])
    ALTER TABLE [dbo].[TenantClaims] ADD CONSTRAINT [FK_dbo.TenantClaims_dbo.Tenants_Tenant_Id] FOREIGN KEY ([Tenant_Id]) REFERENCES [dbo].[Tenants] ([Id])
    ALTER TABLE [dbo].[TenantProperties] ADD CONSTRAINT [FK_dbo.TenantProperties_dbo.Tenants_Tenant_Id] FOREIGN KEY ([Tenant_Id]) REFERENCES [dbo].[Tenants] ([Id])
    CREATE TABLE [dbo].[__MigrationHistory] (
        [MigrationId] [nvarchar](150) NOT NULL,
        [ContextKey] [nvarchar](300) NOT NULL,
        [Model] [varbinary](max) NOT NULL,
        [ProductVersion] [nvarchar](32) NOT NULL,
        CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
    )
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201708180252005_Entities.Example', N'App.Core.Infrastructure.Db.Migrations.Configuration',  0x1F8B0800000000000400ED5BDB6EE336107D2FD07F10F4D416592BC9B6401BD8BBC83AC9C2D87512C4C9A26F0B5AA26DA214A58A546AA3E897F5A19FD45FE850178AA2245BF225CD5E90178B97C399E1198A339AFCFBF73FFDD74B9F5A8F38E2246003FBA4776C5B98B98147D87C60C762F6E267FBF5AB6FBFE95F7AFED2FA908F7B29C7C14CC607F64288F0CC71B8BBC03EE23D9FB851C08399E8B981EF202F704E8F8F7F714E4E1C0C1036605956FF2E6682F8387980C761C05C1C8A18D171E061CAB376E89924A8D635F2310F918B07F67918F68641847B23368B101751EC8A181E2FA6D0CC045E0ADB3AA7048164134C67B685180B041220F7D903C71311056C3E09A101D1FB558861DC0C518E337DCE8AE16D553B3E95AA39C5C41CCA8DB908FC8E80272F335B39E6F4AD2C6E2B5B82352FC1EA6225B54E2C3AB02F97C80F29E86EAE7536A4911CA7D97BB24011F67AE90EF5122882E1470A716419038F145B8054F2EFC81AC6546ED580E15844881E59B7F19412F71D5EDD07BF61366031A5BABC2031F4951AA0E9360A421C89D51D9E655A8C3CDB72CAF31C73A29AA6CD49157C1B13F87D0D6BA329C58A0DCEDAE9377F301CE508C0297017DB1AA3E57BCCE66231B0E1A76D5D9125F6F2960CF68111F02E9804C4DDB84A6A9FFB84D3075E6A8219870D7DC44FB2DA6D441E9138C45A7DA720F95AEADF638698D885F929C21746FC4B26072B8C37414031629D6140CA8393EC82F090A2957CD8FF5AD7E891CC13C218AB0E29223EB7AD3B4C936EBE2061FA2ACA08F3311F711505FE5D401517B38E8F93208E5C297250D77B8FA23916EDE5C91E81B0EB64D24755E42A3A9B64D346D4C9D7D129134D77F7CC04E60B73CFE4BD74F56E278C3BEC06913701A3177E23A992B6DF4AEB710197449C0DE9087F1E8B4510C1BE1FFC00502B4DC89C21B9C5075FF229CEB50F88C6FBD6A4A387E612EDEEA439D2573F7D6E7EFAF95139F63522375969C4AF289A1751616782D703EF8DDFA0BA8723BA0253A5628C9878796AD07E8CFD298EF263D095F77ADB4A8C3DB08F2B9B521E1DB90B18EEA9F1A7EBC78F31BCEF8BD12FD78F7E8BA2299A17C2FCB87EF805A65868E83F55B73ADD54BDF19CF3C025C966950EADFCE2555EEF9279D6DA5B58E15879C830867D2221EC0CB00CECD9EB9D54B46842CD6F4715D4ECCE5386FEC1545753AD95C6DAB56E837C7577BCFD685E7337AC2017EF93ED0C907ABCCCFF20C20A2A87A174B88BA94A0C559CF981E3CC9F79769698DA48E00916E58409DC928B4326D344E5522A062943A41AD721E4566E059047110D28199F5A41E997FF06B862830C446D434C5815E868636A2321F30DBDC92595169A319DB62039072B20B9B4E64DA0AC617BED75AB365AA0C9415BBAE87696A8F1C80A902E7D6B8BE4AF5EE5884522D74933B979C6D76948F9F6C7280CE1D5A6A580B3166B92E67F872F26DD13A17E8AE1B8BC261FAAA4552B8920829794D10B4B83A45724E2E202093445F27630F4FCCAB0CAB1D3E083F972C6C952DDBEDC23F309F2B73AE13624C3D5B164C01686BD025D7DCC44A236D688D03833C9CB238AA29A3BF130A0B1CF9AEED5EB666729551D206B6A8FA1274C7520BDBD3D9A9113D5018DAE0E12EA99CF92887A4715AFEF18DB65D2C4A9F0C4F05A9377AD58999F2A7B2665F6A6EBCEC9A68987A1A44A76EA10AAB13D4E124AE9184943FBF9A54CA68E53EA7866A4697CB9EF8139E9ED665BFA34CC3EE0B12623FDCAC1261BDBE394A27D1DABD4D11E4F4BC3E9685AF316585AA2AD1654EB7F3AEFC9920C3A42D6F4CC3C66ED65700F5EA32EF1DB3A4E33C097E53B9F1323CB97F93A5AAA386E0BCAA9B91D4E6219B01806AB8D03ABA66A45C10CAB8E89D2566AE9AE5265A1D49652751607ECEC9124E333E232B3AB1296AD743583B86DA9A18789DBD0439FDFEDCC69DE8F6A9CFC5C98520DBC3F17B654227F73883AC65406C088F4FB59D4BDB902AC1286A7436C0B947F249E0CC1272B2EB0DF93037A93DFE990122C136BF98031626486B948D3EAF6E9F1C9A95134F67C0AB81CCE3DDAAE8AEBC93F7DC58CFC1E63B0284834233254DFA58C8A3DA2C85DA0E83B1F2DBFD7A1B62B95DA09AEB61C6A3701AB254F1DF0BA96357D7A54300A8BA644ECF2C572A7ADAA291C3ADC56D55C813E89FD32BE60EF8C57F3359BB0EE1CA85497ECC484E60A929D60F745D4D2E7F39D90B4577FD37E56BE9D8D98879703FBCF04E2CC1AFDFA51A11C593711BC67CFAC63EBAFBD7A4BFD6DF0ABC36CEF305FB9B8918BBB1514ECEB437AF64577ABCA0180033FC091B420A2704987980CAEE9955C025C52984B4244CB1A54A39436DE250DAA00CD9E0B1C622677B446C736CBAD8DCD14B8E1ED9B6C70C0028B7DB1A0F810BF6D11C5A7C28535D9CAFF9B0EF5E526D5CFC30DB95FF39F6F9A4B49D2C876607BD300363C3DB78A129456C51D6BEA4CEAD01BCA08D615A16CAA41695EA6A1E4626D95CAAA458D4AF38A6BCA1A9EA292A5A6D0A245C146C9CA95ECE9B32D58D94E59739BEB528107A948A9E69FE084D0FE4F118E290E51808290393586DDD2D9A0C68CD82CC8C53524CA8718B79E3116C88383E31C8C3B43AE54D6C59C2715B159F5E3A53FC5DE88DDC4228C05A88CFD292D19431E75EBD64FCA6ECA32F76FC2E43F42F6A102884940057CC3DEC48416559B57D57B6813843C43DF62684FF7128E6481E72B85741DB0964099F9D4D17F8FE1D004307EC32648AB86ED20DB03C7EFF11CB9AB3C8DD80CB27923CA66EF5F10348F90CF338C623E3C02873D7FF9EA3F665E8ADFAE3B0000 , N'6.1.3-40302')
END

IF @CurrentMigration < '201708212148393_Entities.Tenant.IsDefault'
BEGIN
    ALTER TABLE [dbo].[Tenants] ADD [IsDefault] [bit] NOT NULL DEFAULT 0
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201708212148393_Entities.Tenant.IsDefault', N'App.Core.Infrastructure.Db.Migrations.Configuration',  0x1F8B0800000000000400ED5BDB6EE336107D2FD07F10F4D416592BC9B6401BD8BBC83AC9C2D87512C4C9A26F0B5AA26DA114A58A546AA3E897F5A19FD45FE850178AA22E96643BCD5E90178B97C399E19911399AFCFBF73FC3D76B8F188F3864AE4F47E6C9E0D83430B57DC7A5CB9119F1C58B9FCDD7AFBEFD6678E9786BE34336EEA5180733291B992BCE8333CB62F60A7B880D3CD70E7DE62FF8C0F63D0B39BE757A7CFC8B75726261803001CB30867711E5AE87E307781CFBD4C6018F1099FA0E262C6D879E598C6A5C230FB300D978649E07C160EC877830A18B10311E46368FE0F1620ECD94E335378D73E222906C86C9C23410A53E471CE43E7B6078C6439F2E6701342072BF09308C5B20C270AACF593EBCAD6AC7A742352B9F9841D911E3BED711F0E4656A2B4B9FDECBE2A6B42558F312ACCE3742EBD8A223F3728DBC8080EEFA5A6763128A718ABD672B14626790ECD020867231FC48208E0C6DE091640B904AFC1D19E38888AD1A511CF1109123E3369A13D77E8737F7FE6F988E6844882A2F480C7D850668BA0DFD00877C738717A91613C734ACE23C4B9F28A729731205DF462EFCBE86B5D19C60C906AB71FACD1F14871902700ADCC534A668FD1ED3255F8D4CF8691A57EE1A3B594B0AFB405DF02E9804C4DDBA4A629FFB98D3075E6A8629830D7DC44FB2DA6DE83E227E88B586564EF246EADF638A28DF85F909C21746FC4B2A064B8C37BE4F30A29D6126EC022F109865572050F7E06CBD705940D0463CEC7FAD6BF4E82E63E669AB8E09723D661A7798C4DD6CE506C93B2D65DEC76CC455E87B773E91A44E3B3ECEFC28B485C87E55EF3D0A9798B797277D04E637C9A48E2AC99577D6C9A68CA892AFA377C79AEEEEE231CC17E6E7F10BEEEADD4E1877D8F643670646CFFD46502569BF15D6631C4E9B381DD211FE3CE22B3F847D3F7800902BCDDC2545628B0FBEE453C4B50F8844FBD6A4A3876612EDEEA419D2573F7D6E7EFAF95139F21422D75969C2AE085AE6D7CBCE04AF06DE1BBF417507876403A64AC49850FEF254A3FD147B731C6661D0161704D3888D3D328F4B9B521C1DDA2B18EEC8F1A7CDE3A718DEF7F9E897CDA3DFA2708E96B9303F360FBFC0047305FDA7F256279BAA369E33E6DB6EBC5985A0951DBC8AEB5D52C7683C85E58E95DD3DA6B04F6E003B032C037B0E0627252DEA50B3D35109353DF314A17FD0D555546BA5B172ACDB225FD5196F3F9A579C0D4BC8F9FBA49F01128F178924E4D29CCA41201CEE622E334C25677E6038F56796C6125D1B013CC3BC98798153721E64524D6452A664902244A271154266E55600D92DA20625E5532B28F5F05F03976F9086A86C880E2B2F3ACA98CA9B90FE86DEE692520BC598565B908C8325904C5AFD2450D4B0BDF6AA556B2D50E7A02D5DB49F252A3CB204A44ADFDA22D9AB573A629E11B6929470963AB66A72C7C3290A0278B529B9E4B4C5982589E4F18B59F78CAA97605836AB48AC4A69E54ADC0FE125A5F5C2D220E9951B327E81389A23713A183B5E695829ECD4F860B69C1659CADB9779643641FC96116E4B565D86250D3637EC15E8EA61CA63B5B14284DA9971821F1114569C89C73E893C5A77AE6E9A9DE6665580B4A93D869A795581D4F6F6685A725505D4BA3A48A8A6500B22AA1D65BCA1A56D974E13ABC413CD6B75DEB562651655F64CCAF44DD79D9375130F43499935552164637B1C256D5A10266F6E8F155FCB5494B8A1FDFC425654C529743C3302D61E14F6C0C2E4A4D4978A35B30F182245D6A0142445637B9C42E640C52A74B4C753527A2A9AD2DC034B49DA55822AFD4FE73D69C24245489B9E99C7341E2CF7E035F242D0D771EA01BE2CDFF99C1859BC1854D152DE097B504ECEED1089C5E5473358E59DB26CAA56144CB1AA98286C2597EE2A557A2DEB29556771C0CE8E1B678F264C648965F2B395AEFA85B02F35D42B671F7AA8F3BBC59CFAFD28DFB99F0B53CA97F8CF852DA52C823E448631994DD0B206C3F406BFBD2CAD74A54F86980628FFE83AE23A3FDB308EBD81183098FD4EC6C4C52249970D9822EA2E30E3498ADE3C3D3E39D52AD99E4F5599C59843DA95963DF967B488BABF47182C0A122D5C71EDDFA5B68B3EA2D05EA1F03B0FADBF57A1FAD56FED045759A3B59B80E53AAC0E785D6BAD3E3D2A68D54E7397EF5EE9D40744F984BAD37E5754321D6EBF2BCE519FC4A66B9FD477C6ABF8BCEED2EE1C2895BBECC484FA92969D60F745D4C2F7FC9D9094F343DD7E963EE64DA883D723F3CF18E2CC98FCFA51A21C193721BCACCF8C63E3AFBD7A4BF591F2ABC3F47798AF5CDCCAC5DD2A1CF6F5653FFDC4DCAB9401E0C00F70282C88089CF4E1620767FD5242024E3AD47603448A1A94AF3A6DBC4B185402EA3D1738C054EC68858E6D966BBCE04970CDDBB7D9E080151FFB62415E19D0B7AAE353E14243CAF3FFA64375FD4BF97B754D0259FFB7A2FADA96E47A3C329DB90F1B9EC4ADBC26A655B54943E14B157A4D5D435355CCB6A298FA656A6A401ACB66362D8A66EA576CA8B3788AD29A8ACA8F161524052B9752B0CFB682A69FB2FA3657E5130F5222534E62418450FE0313C214835B80841089398AED426C90632674E167E26A126543B453CF1473E440E03807E32E902D94B5316371896E5A8E79E9CDB133A137110F220E2A636F4E0AC610A1AE69FDB80EA828F3F02688FF45651F2A80982EA8806FE89BC8257919E955F91C5A072162E85B0CEDC95E4248E678B99148D73E6D09949A4F86FE7B0C4113C0D80D9D21A53CB7836C0F0CBFC74B646FB25C643DC8F68D289A7D78E1A265883C9662E4F3E11138EC78EB57FF01962A910E883C0000 , N'6.1.3-40302')
END

IF @CurrentMigration < '201708220413455_Entities.DataToken'
BEGIN
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201708220413455_Entities.DataToken', N'App.Core.Infrastructure.Db.Migrations.Configuration',  0x1F8B0800000000000400ED5BDB6EE336107D2FD07F10F4D416592BC9B6401BD8BBC83AC9C2D87512C4C9A26F0B5AA26DA114A58A546AA3E897F5A19FD45FE850178AA22E96643BCD5E90178B97C399E19911399AFCFBF73FC3D76B8F188F3864AE4F47E6C9E0D83430B57DC7A5CB9119F1C58B9FCDD7AFBEFD6678E9786BE34336EEA5180733291B992BCE8333CB62F60A7B880D3CD70E7DE62FF8C0F63D0B39BE757A7CFC8B75726261803001CB30867711E5AE87E307781CFBD4C6018F1099FA0E262C6D879E598C6A5C230FB300D978649E07C160EC877830A18B10311E46368FE0F1620ECD94E335378D73E222906C86C9C23410A53E471CE43E7B6078C6439F2E6701342072BF09308C5B20C270AACF593EBCAD6AC7A742352B9F9841D911E3BED711F0E4656A2B4B9FDECBE2A6B42558F312ACCE3742EBD8A223F3728DBC8080EEFA5A6763128A718ABD672B14626790ECD020867231FC48208E0C6DE091640B904AFC1D19E38888AD1A511CF1109123E3369A13D77E8737F7FE6F988E6844882A2F480C7D850668BA0DFD00877C738717A91613C734ACE23C4B9F28A729731205DF462EFCBE86B5D19C60C906AB71FACD1F14871902700ADCC534A668FD1ED3255F8D4CF8691A57EE1A3B594B0AFB405DF02E9804C4DDBA4A629FFB98D3075E6A8629830D7DC44FB2DA6DE83E227E88B586564EF246EADF638A28DF85F909C21746FC4B2A064B8C37BE4F30A29D6126EC022F109865572050F7E06CBD705940D0463CEC7FAD6BF4E82E63E669AB8E09723D661A7798C4DD6CE506C93B2D65DEC76CC455E87B773E91A44E3B3ECEFC28B485C87E55EF3D0A9798B797277D04E637C9A48E2AC99577D6C9A68CA892AFA377C79AEEEEE231CC17E6E7F10BEEEADD4E1877D8F643670646CFFD46502569BF15D6631C4E9B381DD211FE3CE22B3F847D3F7800902BCDDC2545628B0FBEE453C4B50F8844FBD6A4A3876612EDEEA419D2573F7D6E7EFAF95139F21422D75969C2AE085AE6D7CBCE04AF06DE1BBF417507876403A64AC49850FEF254A3FD147B731C6661D0161704D3888D3D328F4B9B521C1DDA2B18EEC8F1A7CDE3A718DEF7F9E897CDA3DFA2708E96B9303F360FBFC0047305FDA7F256279BAA369E33E6DB6EBC5985A0951DBC8AEB5D52C7683C85E58E95DD3DA6B04F6E003B032C037B0E0627252DEA50B3D35109353DF314A17FD0D555546BA5B172ACDB225FD5196F3F9A579C0D4BC8F9FBA49F01128F178924E4D29CCA41201CEE622E334C25677E6038F56796C6125D1B013CC3BC98798153721E64524D6452A664902244A271154266E55600D92DA20625E5532B28F5F05F03976F9086A86C880E2B2F3ACA98CA9B90FE86DEE692520BC598565B908C8325904C5AFD2450D4B0BDF6AA556B2D50E7A02D5DB49F252A3CB204A44ADFDA22D9AB573A629E11B6929470963AB66A72C7C3290A0278B529B9E4B4C5982589E4F18B59F78CAA97605836AB48AC4A69E54ADC0FE125A5F5C2D220E9951B327E81389A23713A183B5E695829ECD4F860B69C1659CADB9779643641FC96116E4B565D86250D3637EC15E8EA61CA63B5B14284DA9971821F1114569C89C73E893C5A77AE6E9A9DE6665580B4A93D869A795581D4F6F6685A725505D4BA3A48A8A6500B22AA1D65BCA1A56D974E13ABC413CD6B75DEB562651655F64CCAF44DD79D9375130F43499935552164637B1C256D5A10266F6E8F155FCB5494B8A1FDFC425654C529743C3302D61E14F6C0C2E4A4D4978A35B30F182245D6A0142445637B9C42E640C52A74B4C753527A2A9AD2DC034B49DA55822AFD4FE73D69C24245489B9E99C7341E2CF7E035F242D0D771EA01BE2CDFF99C1859BC1854D152DE097B504ECEED1089C5E5473358E59DB26CAA56144CB1AA98286C2597EE2A557A2DEB29556771C0CE8E1B678F264C648965F2B395AEFA85B02F35D42B671F7AA8F3BBC59CFAFD28DFB99F0B53CA97F8CF852DA52C823E448631994DD0B206C3F406BFBD2CAD74A54F86980628FFE83AE23A3FDB308EBD81183098FD4EC6C4C52249970D9822EA2E30E3498ADE3C3D3E39D52AD99E4F5599C59843DA95963DF967B488BABF47182C0A122D5C71EDDFA5B68B3EA2D05EA1F03B0FADBF57A1FAD56FED045759A3B59B80E53AAC0E785D6BAD3E3D2A68D54E7397EF5EE9D40744F984BAD37E5754321D6EBF2BCE519FC4A66B9FD477C6ABF8BCEED2EE1C2895BBECC484FA92969D60F745D4C2F7FC9D9094F343DD7E963EE64DA883D723F3CF18E2CC98FCFA51A21C193721BCACCF8C63E3AFBD7A4BF591F2ABC3F47798AF5CDCCAC5DD2A1CF6F5653FFDC4DCAB9401E0C00F70282C88089CF4E1620767FD5242024E3AD47603448A1A94AF3A6DBC4B185402EA3D1738C054EC68858E6D966BBCE04970CDDBB7D9E080151FFB62415E19D0B7AAE353E14243CAF3FFA64375FD4BF97B754D0259FFB7A2FADA96E47A3C329DB90F1B9EC4ADBC26A655B54943E14B157A4D5D435355CCB6A298FA656A6A401ACB66362D8A66EA576CA8B3788AD29A8ACA8F161524052B9752B0CFB682A69FB2FA3657E5130F5222534E62418450FE0313C214835B80841089398AED426C90632674E167E26A126543B453CF1473E440E03807E32E902D94B5316371896E5A8E79E9CDB133A137110F220E2A636F4E0AC610A1AE69FDB80EA828F3F02688FF45651F2A80982EA8806FE89BC8257919E955F91C5A072162E85B0CEDC95E4248E678B99148D73E6D09949A4F86FE7B0C4113C0D80D9D21A53CB7836C0F0CBFC74B646FB25C643DC8F68D289A7D78E1A265883C9662E4F3E11138EC78EB57FF01962A910E883C0000 , N'6.1.3-40302')
END

IF @CurrentMigration < '201708230109510_Entities.DataToken.2'
BEGIN
    ALTER TABLE [dbo].[Tenants] ALTER COLUMN [IsDefault] [bit] NULL
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201708230109510_Entities.DataToken.2', N'App.Core.Infrastructure.Db.Migrations.Configuration',  0x1F8B0800000000000400ED5BDB6EE336107D2FD07F10F4D416592BC9B6401BD8BBC83AC9C2D8CD0571B2E8DB829668872845A92295DA28FA657DE827F5173AD485A2A88B255FD2EC0579B178399C199E1991A3C9BF7FFF337CBDF4A9F588234E0236B28F0687B685991B78842D46762CE62F7EB65FBFFAF69BE1B9E72FAD0FF9B897721CCC647C643F08119E380E771FB08FF8C0276E14F0602E066EE03BC80B9CE3C3C35F9CA3230703840D589635BC8D99203E4E1EE0711C3017872246F432F030E5593BF44C1354EB0AF99887C8C523FB340C07E320C283099B47888B2876450C8F67336866022F856D9D528240B229A673DB428C05020990FBE49EE3A98802B69886D080E8DD2AC4306E8E28C7993E27C5F0AEAA1D1E4BD59C62620EE5C65C047E4FC0A39799AD1C73FA4616B7952DC19AE76075B1925A27161DD9E74BE487147437D73A19D3488ED3EC3D7D4011F606E90E0D122882E1470A716019030F145B8054F2EFC01AC7546ED588E15844881E5837F18C12F71D5EDD05BF61366231A5BABC2031F4951AA0E9260A421C89D52D9E675A4C3CDB72CAF31C73A29AA6CD49157C1B13F87D056BA319C58A0D4EEBF4EB3F188E7204E014B88B6D5DA2E57BCC16E26164C34FDBBA204BECE52D19EC3D23E05D300988BB7695D43E7709A7F7BCD414330E1BFA889F64B59B883C22B18FB5864E41F256EADF618698D886F929C21746FC7326072B8C3741403162BD6126FC0CCF1198A502D43E0FB4DB3B39CF080F295AC987DDAF75851EC922219AB1EA9822E273DBBAC534E9E60F244C5F6119D13EE6232EA2C0BF0DA8E270D6F1711AC4912B450EEA7AEF50B4C0A2BB3CD92310BD4D267D5445AEA2B349366D449D7C3D9D39D1747B8F4E60BE30B74EDE6717EFB6C2B8C56E107953307AE137922A69FB8DB41E1770B8C4D9909EF0A7B1780822D8F7BD0700B5D2942C18925BBCF7259F22AE7D4034DEB5263D3D3497687B27CD91BEFAE973F3D3CF8FCAB1AF11B9C94A137E41D1A2B84DF626783DF0CEF80DAA7B38A22B30552AC6848997C706ED2FB13FC3511E065D791FB0ADC4D823FBB0B229E5D191FB00C33D35FEB87DFC2586F77D31FA65FBE8B7289AA14521CC8FEDC3CF30C54243FFA9BAD5E9A6EA8DA79C072E4936AB14B4F2835779BD73E659ADA7B0C2B1F2ABC625EC13096167806560CFC1E0A8A245136A7E3AAAA066679E32F40FA6BA9A6A9D34D68E756BE4AB3BE3ED46F39AB36105B9789F6C6680D4E365DE08115650390CA5C39DCD5442A9E2CCF71C67FECCB358626A2381A75894132D704A2E824CA689CAC1540C52864835AE43C8ADDC0920BF4534A0647CEA04A51FFE1BE08A0D3210B50D3161D545471B537B1332DFD0EB5C5269A119D3E90A9273B002924B6B9E04CA1A76D75EB76AA3059A1CB4A38B6E66891A8FAC00E9D277B648FEEA558E5824809D34039C678A9D8654F1F0128521BCDAB4D471D6624DD3BCF1F8C5B47F02D54F311C97D7E45195B46A251144F092327A616990F482445C9C218166489E0EC69E5F1956093B0D3E982F674496EAF6E51E994F90BF55845B93445761C9802D0C7B01BAFA9889446DAC11A1716692CF4714453567E27140639F359DABDB6667A9581D206BEA8EA1275A7520BDBD3B9A914BD5018DAE1E12EA19D392887A47156FE818DB65D2C4A9F0C4F05A93779D589947951D93327BD3F5E764D3C4FD505225497508D5D81D47CB929684299ABB6325D7321D2569E83EBF9415D5714A1DCF8C808D07851DB0303D296D4AC586D97B0C91326B500992B2B13B4E2973A063953ABAE369293D1D4D6BDE004B4BDAD5826AFD4FE73D59C24247C89A9E99C7B41E2C77E035EA42B0A9E334037C59BEF33931B27C31A8A3A5BA136E403935B7472496971FC360B577CAAAA93A5130C3AA63A2B4955ABAAF54D9B56C43A97A8B0376F648923D9A70992556C9CF4EBA9A17C24DA9A15F3937A1873EBF5FCC69DE8FEA9DFBB930A57A89FF5CD852C9229843541853D904236B30CC6EF0EBABD02A57FA74886D81F28FC493D7F9E98A0BEC0FE480C1F4773AA604CB245D3EE0123132C75CA4297AFBF8F0E8D8285C7B3E45640EE71EED5649F6E49FD162467E8F315814249A1379EDDFA6948B3DA2C87D40D1773E5A7EAF436D56AEB5155C6D49D6760256CBAE7AE0F52DADFAF4A8601437CD88D8BEB0C900E9590CB0D576D71432ED6FBB6B8E519FC49E1B5FD4B7C6ABF9BA4E587F1E55AA5DB662427345CB56B0BB226AE973FE5648DAF1A1693F2BDFF226CCC3CB91FD670271624D7EFDA8500EACEB08DED527D6A1F5D74EBDA5FE44F9D561367798AF5C5CCBC5ED0A1C76F5613FFBC2BC512503C0811FE0485A105138E8C3BD0E8EFA957C041C74984B4244CB1A546F3A5DBC4B1A54019A3D6738C44CEE688D8E5D966BBDDF2970C3DBD7D9608F051FBB62415118B06951C7A7C285968CE7FF4D87FAF297EAE7EA86FCB1F94F44CDA52DE9ED78647BB300363C8D5B45494CA7629396BA973AF486B286B6A298753531CDCB349480B456CDAC3AD4CC34AFD85266F114953535851F1D0A484A56AE64609F6D01CD66CA9ADB5C974EDC4B854C3587051142FB7F4B08531C6E010A42E6E518764BB1418D99B079908B6B48940F314E3D9758200F02C72918778E5CA9AC8B394F2A74B36ACC737F86BD09BB8E45180B5019FB335A32860C756DEB276540659987D761F21F2ABB5001C424A002BE666F62428B2AD28BEA39B40942C6D0B718DAD3BD84902CF062A590AE02D61128339F0AFD7718822680F16B36455A756E0FD9EE397E8F17C85DE5A9C86690F51B5136FBF08CA045847C9E6114F3E11138ECF9CB57FF01A7007993763C0000 , N'6.1.3-40302')
END

IF @CurrentMigration < '201708231103395_Entities.DataToken.3'
BEGIN
    ALTER TABLE [dbo].[Tenants] ADD [HostName] [nvarchar](max)
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201708231103395_Entities.DataToken.3', N'App.Core.Infrastructure.Db.Migrations.Configuration',  0x1F8B0800000000000400ED5BDB6EE336107D2FD07F10F4D416592B971668037B17593BD91ABB4E823859F46D414BB42D94A2B42295DA28FA657DE827F5173AD485A2A88B255FD2EC0579B1A9E1E1CCF0CC881C4FFEFDFB9FFEAB95478C471C32D7A703F3A4776C1A98DABEE3D2C5C08CF8FCC5CFE6AB97DF7ED3BF74BC95F13E933B13723093B281B9E43C38B72C662FB18758CF73EDD067FE9CF76CDFB390E35BA7C7C7BF58272716060813B00CA37F1751EE7A38FE025F873EB571C0234426BE83094BC7E1C9344635AE918759806C3C302F82A037F443DC1BD37988180F239B47F075348361CAF18A9BC60571116836C5646E1A88529F230E7A9F3F303CE5A14F17D3000610B95F0718E4E688309CDA739E8BB735EDF8549866E51333283B62DCF73A029E9CA5BEB2F4E95B79DC94BE046F5E82D7F95A581D7B74605EAE901710B05D5FEB7C484221A7F87BBA4421767AC90EF5622817C38704E2C8D0048F245B8054E2EFC81846446CD580E28887881C19B7D18CB8F65BBCBEF77FC774402342547D416378561880A1DBD00F70C8D777789E5A31764CC32ACEB3F489729A322731F04DE4C2E76B581BCD08966CB01AA7DFFC4171982100A7205C4C638256EF305DF0E5C0848FA671E5AEB0938DA4B00FD485E8824940DC8DAB24FEB98F397DE0A5A69832D8D047FC24ABDD86EE23E28758AB6FE5246FA4FE3DA688F25D989F207C61C4BFA4425862BCF67D8211ED0C3366233C47E0961250F33CB0EEE0E4FCD5675C7C3AF84223970504AD0FB3D6357A741731A3B5558704B91E338D3B4CE2C76CE906C9BB3265F4874CE22AF4BD3B9FC860491F7C98FA51680B95FDAAA7F7285C60DE5E9FF42B4454934EAA5449AFFC619D6E8A44957E1DB3466CE9EEA92386F9C2F247FCE2BC7ABB13C61DB6FDD09982D3F3B8115449C66F85F71887532C4E453AC25F447CE987B0EF074F0072A5A9BBA0486CF1C1977C8A04FA1E9168DF96748CD04CA3DD833443FA1AA7CF2D4E3F3F2A479E42E43A2F8DD915418BFCDADA99E0D5C07BE33798EEE090ACC155891A63CACF4E35DA4FB037C36196066D71F1308DD8D903F3B8B42945E9D05E82B823E54F9BE52718DEF7B9F459B3F41B14CED02257E6C766F11126982BE83F95B73AD95475F08231DF76E3CD2A24ADECE0555CEF923A46E3292C0FACEC4E33817D7203D8196019F8B3D73B295951879A9D8E4AA8E999A708FD836EAE625A2B8B9563DD06FDAACE78FBB1BCE26C5842CEDF27DB3920897851A0422ECDA91C0422E0463359B92A05F303C3693CB33497E8D608E029E6C58A0E9C92F324935A228B3D25871421128BAB10322FB702C86E113528299F5A41A987FF1AB87C8334446543745879D151642A6F42FA1B7A53484A2B14675A6D41320E9640326DF59340D1C2F6D6AB5EADF5405D80B60CD1ED3C511191252055FBD61EC95EBD3210F34AB395949AB392B4555393EE4F5010C0AB4DA951A723C63429500F5F4CBB576ABD04C3B25945C1566A2B57E27E082F29ED292C0D9A5EB921E323C4D10C89D3C1D0F14A62A5B4531383D9725A66296F5F1691D904F15966B80DD57A999634D8DCB15760AB87298FCDC60A116A67C63F1C2082C28A33F1D0279147EBCED54DB3D39AAF0A900EB5C7502BBA2A903ADE1E4D2BDAAA80DAA30E1AAAA5D9828AEA83325EDFD2B64BA78955E28916B53AEF5AB132CB2A7B2665FAA6EBCEC9BA8987A1A4ACC6AA1072B03D8E528E2D28930FB7C78AAF652A4A3CD07E7E5E7E5541F2D1F64885FAAA0A5678F0CCA85C7BE4D8039F9333D7B6A4AE997DC0642BEA0FA5742B06DBE3146A102A56E1417B3CA538A8A229C35B6029E5BF4A50E5F9D3C5615AFA5011D2A16716318D47D43D448DBC5A6C1B38F5005F56EC7C4E8C2C5E31AA68296F975B504ECEED9089C5354A7358E5EDB4ECAA56144CB1AA98287C2597EEAA557AC1DB52ABCEEA809F1D37AE438D99A837CB326A2B5BF5ABE5B6D4502FAFDBD0439DDF2DE7D4EF47F9F6FE5C98522E077C2E6C29D523741199C6645D42AB3FF4D35AC0E6C6B952712011310D30FED175446160BA661C7B3D21D09B7E2443E26251EECB042688BA73CC7852EC374F8F4F4EB55EBBE7D3F76631E69076CD6F4FFE835C44DD8F11068F82467357141076E93EA38F28B49728FCCE43ABEF55A8ED3ACC7682ABEC22DB4DC172A75807BCAEDD609F1E15B47EAC99CB77EFC5D2403AB615ECB4DD7AEFD54E6015FD5587E34EC599EC932090F643FFCE78153FFABBB43B294B4D383B31A1BED16627D87DB1BED065B013927216A9DBCFD24F8C63EAE0D5C0FC33863837C6BF7D902847C64D082FFE73E3D8F86BAFD1527D3CFD1A30DB07CC572E6EE4E26E7D17FBEA37487FF8DEAAC102E0200E70283C8808DC1AE09208F7865271034E4DD47603448A1694AF4D6DA24B385402EA4F4638C054EC68858D6D966BBC2C4A702DDA37F9E0807D28FB6241DEAFB06DAFC9A7C28586F2E9FF4D87EAAE9CF2AFE835C568FD9FA8EA3B6E92ABF6C074663E6C7892B7F24E9D563D300DED3855E835DD164DBD3A9B5A75EA97A9E94C696CE659B768E5A95FB1A1FBE3291A7E2AFA515AF4B514BC5C2AE73EDBBE9EED8CD5B7B9AA367990C69D72410C3284F2FFA690A618DC02248428F2516C1772839419D3B99FA9AB69948968A79E09E6C881C47101CE9D235B186B63C6E2C6E1B449F4D29B61674C6F221E441C4CC6DE8C149C21525DD3FA71775251E7FE4D10FFE3CC3E4C00355D3001DFD0D7914BF2E6D6ABF239B40E42E4D03718C693BD8494CCF1622D91AE7DDA1228759F4CFDF718922680B11B3A454AD37007DD1E187E8717C85E6775CD7A90CD1B51747B7FE4A245883C9662E4F3E12B70D8F1562FFF038C4F7220763D0000 , N'6.1.3-40302')
END

IF @CurrentMigration < '201708281038225_Entities.1'
BEGIN
    IF object_id(N'[dbo].[FK_dbo.TenantClaims_dbo.Tenants_Tenant_Id]', N'F') IS NOT NULL
        ALTER TABLE [dbo].[TenantClaims] DROP CONSTRAINT [FK_dbo.TenantClaims_dbo.Tenants_Tenant_Id]
    IF object_id(N'[dbo].[FK_dbo.TenantProperties_dbo.Tenants_Tenant_Id]', N'F') IS NOT NULL
        ALTER TABLE [dbo].[TenantProperties] DROP CONSTRAINT [FK_dbo.TenantProperties_dbo.Tenants_Tenant_Id]
    IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_Tenant_Id' AND object_id = object_id(N'[dbo].[TenantClaims]', N'U'))
        DROP INDEX [IX_Tenant_Id] ON [dbo].[TenantClaims]
    IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_Tenant_Id' AND object_id = object_id(N'[dbo].[TenantProperties]', N'U'))
        DROP INDEX [IX_Tenant_Id] ON [dbo].[TenantProperties]
    DECLARE @var0 nvarchar(128)
    SELECT @var0 = name
    FROM sys.default_constraints
    WHERE parent_object_id = object_id(N'dbo.TenantClaims')
    AND col_name(parent_object_id, parent_column_id) = 'OwnerFK';
    IF @var0 IS NOT NULL
        EXECUTE('ALTER TABLE [dbo].[TenantClaims] DROP CONSTRAINT [' + @var0 + ']')
    ALTER TABLE [dbo].[TenantClaims] DROP COLUMN [OwnerFK]
    DECLARE @var1 nvarchar(128)
    SELECT @var1 = name
    FROM sys.default_constraints
    WHERE parent_object_id = object_id(N'dbo.TenantProperties')
    AND col_name(parent_object_id, parent_column_id) = 'OwnerFK';
    IF @var1 IS NOT NULL
        EXECUTE('ALTER TABLE [dbo].[TenantProperties] DROP CONSTRAINT [' + @var1 + ']')
    ALTER TABLE [dbo].[TenantProperties] DROP COLUMN [OwnerFK]
    EXECUTE sp_rename @objname = N'dbo.TenantClaims.Tenant_Id', @newname = N'OwnerFK', @objtype = N'COLUMN'
    EXECUTE sp_rename @objname = N'dbo.TenantProperties.Tenant_Id', @newname = N'OwnerFK', @objtype = N'COLUMN'
    CREATE TABLE [dbo].[DataTokens] (
        [Id] [uniqueidentifier] NOT NULL,
        [Value] [nvarchar](2048) NOT NULL,
        CONSTRAINT [PK_dbo.DataTokens] PRIMARY KEY ([Id])
    )
    ALTER TABLE [dbo].[Examples] ALTER COLUMN [Owner] [nvarchar](max) NOT NULL
    ALTER TABLE [dbo].[Examples] ALTER COLUMN [PublicText] [nvarchar](max) NOT NULL
    ALTER TABLE [dbo].[Tenants] ALTER COLUMN [Key] [nvarchar](50) NOT NULL
    ALTER TABLE [dbo].[Tenants] ALTER COLUMN [HostName] [nvarchar](50) NULL
    ALTER TABLE [dbo].[Tenants] ALTER COLUMN [DisplayName] [nvarchar](50) NOT NULL
    ALTER TABLE [dbo].[TenantClaims] ALTER COLUMN [Authority] [nvarchar](50) NOT NULL
    ALTER TABLE [dbo].[TenantClaims] ALTER COLUMN [AuthoritySignature] [nvarchar](1024) NOT NULL
    ALTER TABLE [dbo].[TenantClaims] ALTER COLUMN [Key] [nvarchar](50) NOT NULL
    ALTER TABLE [dbo].[TenantClaims] ALTER COLUMN [Value] [nvarchar](1024) NULL
    ALTER TABLE [dbo].[TenantClaims] ALTER COLUMN [OwnerFK] [uniqueidentifier] NOT NULL
    ALTER TABLE [dbo].[TenantProperties] ALTER COLUMN [Key] [nvarchar](50) NOT NULL
    ALTER TABLE [dbo].[TenantProperties] ALTER COLUMN [Value] [nvarchar](1024) NULL
    ALTER TABLE [dbo].[TenantProperties] ALTER COLUMN [OwnerFK] [uniqueidentifier] NOT NULL
    CREATE UNIQUE INDEX [IX_Tenant_IsDefault] ON [dbo].[Tenants]([IsDefault])
    CREATE UNIQUE INDEX [IX_Tenant_Key] ON [dbo].[Tenants]([Key])
    CREATE UNIQUE INDEX [IX_Tenant_HostName] ON [dbo].[Tenants]([HostName])
    CREATE INDEX [IX_OwnerFK] ON [dbo].[TenantClaims]([OwnerFK])
    CREATE INDEX [IX_OwnerFK] ON [dbo].[TenantProperties]([OwnerFK])
    ALTER TABLE [dbo].[TenantClaims] ADD CONSTRAINT [FK_dbo.TenantClaims_dbo.Tenants_OwnerFK] FOREIGN KEY ([OwnerFK]) REFERENCES [dbo].[Tenants] ([Id]) ON DELETE CASCADE
    ALTER TABLE [dbo].[TenantProperties] ADD CONSTRAINT [FK_dbo.TenantProperties_dbo.Tenants_OwnerFK] FOREIGN KEY ([OwnerFK]) REFERENCES [dbo].[Tenants] ([Id]) ON DELETE CASCADE
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201708281038225_Entities.1', N'App.Core.Infrastructure.Db.Migrations.Configuration',  0x1F8B0800000000000400ED5CDB6EE346127D5F60FF81E0D366E198B26702248694C091ED5921F17860D941DE062DB2243742361976D32B61B15F96877C527E21D5BC36D9244552922F18C32F525F4E55D7AD2F55F25F7FFC39FE61EDB9C623849CFA6C629E1C8F4C0398ED3B94AD266624965F7F6BFEF0FD3FFF31BE74BCB5F14B36EE9D1C8733199F980F42046796C5ED07F0083FF6A81DFADC5F8A63DBF72CE2F8D6E968F49D757262014298886518E3DB8809EA41FC05BF4E7D66432022E25EFB0EB83C6DC79E798C6A7C241EF080D83031CF83E078EA87703C63CB90701146B688F0EBC5029B9980B5308D739712E46C0EEED2340863BE2002F93EBBE73017A1CF56F3001B887BB70900C72D89CB215DCF5931BCEBD246A7726956313183B2232E7CAF27E0C9BB54565675FA20899BB92C519A972875B191AB8E253A312FD7C40B5C5C7B95D6D9D40DE53845DEF3071282739C68E83886A2801F128823A332F028B716342AF977644C2357AA6AC2201221718F8C4FD1C2A5F64FB0B9F37F03366191EBAAFC22C7D8576AC0A64FA11F402836B7B04C5731734CC32ACFB3AA13F369CA9C64811F228A9F3F226DB27021B70645167381CBFA000C4222C0F94484801095F9D167A011AE90B9F92FCECA28A1EDA15B99C63559FF0C6C251E26267E348D2BBA06276B49C9DF338A5E8893D0C0A186BD76B28960EF6267786ADA73601C4DE311F6447ECB4A43FA885A3900ADB155B84BAB13DD01234CECE24309C29B0BD592B9641234A7F5A3EFBB40586FB39CF10B5812149F06D43E0FA5D06258DF8C0EE142FFF1B9909F7627DC4EE782F2C0259BFD90DAB6C68FE491AE626BA870317509F5B869DC821B77F3071A249B77EA189FB31157A1EFDDFA6EEE7369C7E7B91F85B65C825FD77B47C21588EEFCA45FD131DB785247697C159D4DBC2923EAF8EB197CE295EE1E816298B730544B26DEC9AF7EDA42AB1DE3166C3F74E6C84CE16FD2A492F64F52CA5CE0F11BD2213DE1CF23F1E087681F4F1EB072CA73BA62449A460B0B27A3D3F78760E23922F52FC48DF6B2D61D9C3F636977FFCF90DE42C06B0D015F9E0F5C1041628BDBC5FC739037CB1FA4E2D3D1FB6F7737AD669D479EA2F1265799F12B97AC8AF79CDEE6500FBC379340593810BA1B145EC2C68C8977A7154BB9066F0161B6ADDAF21E6D1AB1F827E64853537974683FE070271F7FDA3EFE1AF0DC598C7ED73EFA030917645530F3BE7DF805B82014F46F7455274A551BCF39F76D1A2BABB4C365178032BD4BE618ADB78122BA6657F46BD4130D503368651898CCAA53DEB0846F434A5E3ED84D09B789A3FB07B2EF74E3263BDD6BDCA467F6324BFFD628617C8010987CAE9CE23D04CD8B32A10713CA6C1A10B74D2095491D63905C6C0E5FEDB98000D0A899685B7A17BAF9D6AA13CF695434B04D30634B31A74E56A65CE9B6E8B6EE7EF7BCD656739FD4382A0E8A87343A5D364F6778BA145E9AF1253B9CCC54E08C22740781DC602E16790A43DBBCEE39A4FB174F37D3AA4548E03988F2D33E378D62534DAD217FF5B7DA2112A1D6216416DE09207BBD694049E3602728F5D1A501AE30F22D88F999AF0E4B3955566014BD56B9CBDFA99431B50F595533DBB693E5AC2B3AD16C75DB06A48164DC56834D7985DD57AF2AA751024D31B663941D26899AE0A801A9DC7796487662CDFDB9C85C5A49EA324B715A0D39CEF13509023C112A39CFB4C5982709CFE9D7F3FE993F2FC1B06C5E9300CCB9CD29E1CD00CF76955E248D9C5ED1900BE90E0B220FD553C7D38669D1ABC1F132729500A5AB2F73C66C82FC9C07CA2DD9DF3CBAE9913F85BBC2B57A72EB882F448A2134CE8C13D1C42561CDED6BEABB91C79A37B1E6D9696E5005489BBA63A8893E15486DEF8E5649DDA98095AE1E1CAA09BA128B6A878E37B62AEAD2F666CD4EB44353D9EE3A59651655F66C94E986D9DF269B261EC624F35C9B0A913776C751926D25668AE6EE58F193968A1237749F5F24D35490A2B53B52295DA682953A5E9829371E39F660CFC9D16DA85137CC3E60B095677C2DDCD61DFC9B714AEFB72A56A9A33B9E92B351D194E601584A16A61654E97F3A3F4CDF105584B4E985794CEB11750F5E93DF50863A4E33C097E53B5F80452A97D43DDB6271C3ED6F862D730F63812F4653DA85AF3A24A79E5FFC2A17BC717AD9DA5EE9AADDBE9221A681C279A48EBC79CD375C8017EBF278FEBB3B7529C867996CC0356174095C244908F37474725A298E7D3985AA16E78E5B7359ADA9567DF2DC5AC4E8EF1150F90E489754DED07AA6484B65A0EC9184F60309FFE591F5577B28EDDC0DAFB65CB311726049660FBCBE6597AFCF18B44AC405AD7BF09D3107D613F37FF1AC3363F6EBE7F4352B9F7F64CCF87DCCCD9971878234FEDF575595DACA9891E115079996FB2C06A7D72DA352B4B063FDE410C6328C5EDC0D2CBA2CF8EBB3EE413582AFCF5D2A55373A5E079DA61847C64D88DBE299312ABBCAB0EABA615AEBE841BB4196EA356A4193A29C7E96DB5CE5D789C4D0FA28CAB645A5A105736FCE30D4195E8DCD1ED69E1A2E42AFC294B6CB3BA9EA1A24A9DD2A799EBB9A224D493F43C9CED3D54A34BDDDBEF6DA9CE7B69DA2FEE079EA6F9ECE825ADE315F628D8D9ECC6E7881ABBC36B4D4CF240F3213D359F8A8EE24481675379D2A5A5A8A6BEAD01B8A1EDA2A6FB615DE3493692810692DCDD97428CC69A6D85284D158BED35EBD53474BADFC7986EA9E9AE2930E452C255D6A59B4175BC4336CB15563AA4B7E1CA44A477F9CC538A4FCB3020C851C2F3F3984FCD7050CEC5204CAC7CCD8D2CFD8AD70940DA99CC9AE411007ADF31C85BB24B65CAC0D9CC7E5F66921F5A5B70067C66E22114402970CDEC22D094306D436FA71295299E7F14D10FFC8711F4B4036292E016ED88F11758B02F0AB9AC36303848CD4E9EF14A42E85FCBDC26A9323E93F5868024AC5976F307780A119C1F80D9B13A5B0BE076FF71C7E8615B137D91B7B33C8764594C53EBEA06415128FA718C57CFC8A36EC78EBEFFF061E327F0BB3430000 , N'6.1.3-40302')
END
