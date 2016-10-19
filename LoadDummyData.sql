USE [LocalDev_Webservice]
GO

TRUNCATE TABLE [LocalDev_Webservice].[Person].[Person]
TRUNCATE TABLE [LocalDev_Webservice].[Person].[Anstalld]
TRUNCATE TABLE [LocalDev_Webservice].[Person].[Konsult]

TRUNCATE TABLE [LocalDev_Webservice].[Person].[PersonAnstalld]
TRUNCATE TABLE [LocalDev_Webservice].[Person].[PersonKonsult]

TRUNCATE TABLE [LocalDev_Webservice].[Person].[Avtal]
TRUNCATE TABLE [LocalDev_Webservice].[Person].[AnstalldAvtal]

TRUNCATE TABLE [LocalDev_Webservice].[Adress].[Adress]
TRUNCATE TABLE [LocalDev_Webservice].[Adress].[GatuAdress]
TRUNCATE TABLE [LocalDev_Webservice].[Adress].[Mail]
TRUNCATE TABLE [LocalDev_Webservice].[Adress].[Telefon]
TRUNCATE TABLE [LocalDev_Webservice].[Adress].[PersonAdress]

/*
TRUNCATE TABLE [LocalDev_Webservice].[Adress].[AdressTyp]
TRUNCATE TABLE [LocalDev_Webservice].[Adress].[AdressVariant]
*/


/**
 * Personer
**/

INSERT INTO [Person].[Person]([Id],[ForNamn],[MellanNamn],[EfterNamn],[PersonNummer],[SkapadDatum],[UppdateradAv])
VALUES(1,'Kalle','Ove','Nilsson','8012123456', GETUTCDATE() ,'DBO')

INSERT INTO [Person].[Person]([Id],[ForNamn],[MellanNamn],[EfterNamn],[PersonNummer],[SkapadDatum],[UppdateradAv])
VALUES(2,'Marie','Eva','Persson','7012123456', GETUTCDATE() ,'DBO')

INSERT INTO [Person].[Person]([Id],[ForNamn],[MellanNamn],[EfterNamn],[PersonNummer],[SkapadDatum],[UppdateradAv])
VALUES(3,'Anders','Ola','Svensson','7512123456', GETUTCDATE() ,'DBO')

INSERT INTO [Person].[Person]([Id],[ForNamn],[MellanNamn],[EfterNamn],[PersonNummer],[SkapadDatum],[UppdateradAv])
VALUES(4,'Per','','Andersson','8512123456', GETUTCDATE() ,'DBO')

INSERT INTO [Person].[Person]([Id],[ForNamn],[MellanNamn],[EfterNamn],[PersonNummer],[SkapadDatum],[UppdateradAv])
VALUES(5,'Olle','Sven','Andersson','5512123456', GETUTCDATE() ,'DBO')

INSERT INTO [Person].[Person]([Id],[ForNamn],[MellanNamn],[EfterNamn],[PersonNummer],[SkapadDatum],[UppdateradAv])
VALUES(6,'Anna','Maria','Nilsson','6512123456', GETUTCDATE() ,'DBO')

/**
 * Anställda
**/
INSERT INTO [Person].[Anstalld]([Id],[Typ],[Alias],[UppdateradAv],[SkapadDatum])
VALUES(1,1,'KNI','DBO',GETUTCDATE())

INSERT INTO [Person].[PersonAnstalld]([Id],[PersonFKID],[AnstalldFKID],[UpdateradAv],[SkapadDatum])
VALUES(1,1,1,'DBO', GETUTCDATE())

INSERT INTO [Person].[Anstalld]([Id],[Typ],[Alias],[UppdateradAv],[SkapadDatum])
VALUES(2,1,'MPE','DBO',GETUTCDATE())

INSERT INTO [Person].[PersonAnstalld]([Id],[PersonFKID],[AnstalldFKID],[UpdateradAv],[SkapadDatum])
VALUES(2,2,2,'DBO', GETUTCDATE())

INSERT INTO [Person].[Anstalld]([Id],[Typ],[Alias],[UppdateradAv],[SkapadDatum])
VALUES(3,2,'ASE','DBO',GETUTCDATE())

INSERT INTO [Person].[PersonAnstalld]([Id],[PersonFKID],[AnstalldFKID],[UpdateradAv],[SkapadDatum])
VALUES(3,3,3,'DBO', GETUTCDATE())

INSERT INTO [Person].[Anstalld]([Id],[Typ],[Alias],[UppdateradAv],[SkapadDatum])
VALUES(4,1,'PAN','DBO',GETUTCDATE())

INSERT INTO [Person].[PersonAnstalld]([Id],[PersonFKID],[AnstalldFKID],[UpdateradAv],[SkapadDatum])
VALUES(4,4,4,'DBO', GETUTCDATE())

/**
 * Konsulter
**/
INSERT INTO [Person].[Konsult]([Id],[Alias],[UppdateradAv],[SkapadDatum])
VALUES(1,'TOSV','DBO',GETUTCDATE())

INSERT INTO [Person].[PersonKonsult]([Id],[PersonFKID],[KonsultFKID],[UpdateradAv],[SkapadDatum])
VALUES(1, 5,1,'DBO',GETUTCDATE())

INSERT INTO [Person].[Konsult]([Id],[Alias],[UppdateradAv],[SkapadDatum])
VALUES(2,'TANI','DBO',GETUTCDATE())

INSERT INTO [Person].[PersonKonsult]([Id],[PersonFKID],[KonsultFKID],[UpdateradAv],[SkapadDatum])
VALUES(2, 6,2,'DBO',GETUTCDATE())

INSERT INTO [Person].[Konsult]([Id],[Alias],[UppdateradAv],[SkapadDatum])
VALUES(3,'TKNI','DBO',GETUTCDATE())

INSERT INTO [Person].[PersonKonsult]([Id],[PersonFKID],[KonsultFKID],[UpdateradAv],[SkapadDatum])
VALUES(3, 1,3,'DBO',GETUTCDATE())

/**
 * Avtal
**/
INSERT INTO [Person].[Avtal]([Id],[AvtalsKod],[AvtalsText],[ArbetsTidVecka],[Befkod],[BefText],[Aktiv],[Ansvarig],[Chef],[UppdateradAv],[AnstallningsDatum],[SkapadDatum])
VALUES(1,'E03','Vård och omsorg',40,01,'Underläkare','J','N',0,'DBO',GETUTCDATE(),GETUTCDATE() )

INSERT INTO [Person].[AnstalldAvtal]([Id],[AnstalldFKID],[AvtalFKID])
VALUES(1,1,1)

INSERT INTO [Person].[Avtal]([Id],[AvtalsKod],[AvtalsText],[ArbetsTidVecka],[Befkod],[BefText],[Aktiv],[Ansvarig],[Chef],[UppdateradAv],[AnstallningsDatum],[SkapadDatum])
VALUES(2,'T01','Unionen, CF, tjänstemän. Månadslön',40,01,'Läkare','J','N',0,'DBO',GETUTCDATE(),GETUTCDATE() )

INSERT INTO [Person].[AnstalldAvtal]([Id],[AnstalldFKID],[AvtalFKID])
VALUES(2,1,1)

INSERT INTO [Person].[Avtal]([Id],[AvtalsKod],[AvtalsText],[ArbetsTidVecka],[Befkod],[BefText],[Aktiv],[Ansvarig],[Chef],[UppdateradAv],[AnstallningsDatum],[SkapadDatum])
VALUES(3,'T01','Unionen, CF, tjänstemän. Månadslön',40,01,'Undersköterska','J','N',0,'DBO',GETUTCDATE(),GETUTCDATE() )

INSERT INTO [Person].[AnstalldAvtal]([Id],[AnstalldFKID],[AvtalFKID])
VALUES(3,2,3)


/**
 * Adress
**/
/*Hem*/
INSERT INTO [Adress].[Adress]([Id],[AdressTypFKID],[AdressVariantFKID],[SkapadDatum],[UpdateradAv])
VALUES(1,1,1,GETUTCDATE(),'DBO')
INSERT INTO [Adress].[GatuAdress]([Id],[AdressFKID],[AdressRad1],[Postnummer],[Stad],[Land],[SkapadDatum],[UpdateradAv])
VALUES(1,1,'Storvägen 11',84019,'Färila','Sverige',GETUTCDATE(),'DBO')
/*Jobb*/
INSERT INTO [Adress].[Adress]([Id],[AdressTypFKID],[AdressVariantFKID],[SkapadDatum],[UpdateradAv])
VALUES(2,1,2,GETUTCDATE(),'DBO')
INSERT INTO [Adress].[GatuAdress]([Id],[AdressFKID],[AdressRad1],[Postnummer],[Stad],[Land],[SkapadDatum],[UpdateradAv])
VALUES(2,2,'Drottningvägen 23',82240,'Järvsö','Sverige',GETUTCDATE(),'DBO')

/*Mail Arbete*/
INSERT INTO [Adress].[Adress]([Id],[AdressTypFKID],[AdressVariantFKID],[SkapadDatum],[UpdateradAv])
VALUES(3,2,7,GETUTCDATE(),'DBO')
INSERT INTO [Adress].[Mail]([Id],[AdressFKID],[MailAdress],[SkapadDatum],[UpdateradAv])
VALUES(1,3,'jarvsobacken@ptj.se',GETUTCDATE(),'DBO')

/*Mail Private*/
INSERT INTO [Adress].[Adress]([Id],[AdressTypFKID],[AdressVariantFKID],[SkapadDatum],[UpdateradAv])
VALUES(4,2,8,GETUTCDATE(),'DBO')
INSERT INTO [Adress].[Mail]([Id],[AdressFKID],[MailAdress],[SkapadDatum],[UpdateradAv])
VALUES(2,4,'kalle.ove@gmail.com',GETUTCDATE(),'DBO')

/*Tele Private*/
INSERT INTO [Adress].[Adress]([Id],[AdressTypFKID],[AdressVariantFKID],[SkapadDatum],[UpdateradAv])
VALUES(5,3,9,GETUTCDATE(),'DBO')
INSERT INTO [Adress].[Telefon]([Id],[AdressFKID],[TelefonNummer],[SkapadDatum],[UpdateradAv])
VALUES(1,5,065112345,GETUTCDATE(),'DBO')

/*Tele Arbete*/
INSERT INTO [Adress].[Adress]([Id],[AdressTypFKID],[AdressVariantFKID],[SkapadDatum],[UpdateradAv])
VALUES(6,3,10,GETUTCDATE(),'DBO')
INSERT INTO [Adress].[Telefon]([Id],[AdressFKID],[TelefonNummer],[SkapadDatum],[UpdateradAv])
VALUES(2,6,070123456,GETUTCDATE(),'DBO')


INSERT INTO [Adress].[PersonAdress]([Id],[PersonFKID],[AdressFKID],[UpdateradAv],[SkapadDatum])
VALUES(1,1,1,'DBO',GETUTCDATE())

INSERT INTO [Adress].[PersonAdress]([Id],[PersonFKID],[AdressFKID],[UpdateradAv],[SkapadDatum])
VALUES(2,1,2,'DBO',GETUTCDATE())

INSERT INTO [Adress].[PersonAdress]([Id],[PersonFKID],[AdressFKID],[UpdateradAv],[SkapadDatum])
VALUES(3,1,3,'DBO',GETUTCDATE())
INSERT INTO [Adress].[PersonAdress]([Id],[PersonFKID],[AdressFKID],[UpdateradAv],[SkapadDatum])
VALUES(4,1,4,'DBO',GETUTCDATE())
INSERT INTO [Adress].[PersonAdress]([Id],[PersonFKID],[AdressFKID],[UpdateradAv],[SkapadDatum])
VALUES(5,1,5,'DBO',GETUTCDATE())
INSERT INTO [Adress].[PersonAdress]([Id],[PersonFKID],[AdressFKID],[UpdateradAv],[SkapadDatum])
VALUES(6,1,6,'DBO',GETUTCDATE())
INSERT INTO [Adress].[PersonAdress]([Id],[PersonFKID],[AdressFKID],[UpdateradAv],[SkapadDatum])
VALUES(7,2,1,'DBO',GETUTCDATE())
INSERT INTO [Adress].[PersonAdress]([Id],[PersonFKID],[AdressFKID],[UpdateradAv],[SkapadDatum])
VALUES(8,2,2,'DBO',GETUTCDATE())
INSERT INTO [Adress].[PersonAdress]([Id],[PersonFKID],[AdressFKID],[UpdateradAv],[SkapadDatum])
VALUES(9,3,2,'DBO',GETUTCDATE())
INSERT INTO [Adress].[PersonAdress]([Id],[PersonFKID],[AdressFKID],[UpdateradAv],[SkapadDatum])
VALUES(10,4,2,'DBO',GETUTCDATE())
INSERT INTO [Adress].[PersonAdress]([Id],[PersonFKID],[AdressFKID],[UpdateradAv],[SkapadDatum])
VALUES(11,5,2,'DBO',GETUTCDATE())





INSERT INTO [Adress].[AdressTyp]([Id],[Typ],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(1,'GatuAdress',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressTyp]([Id],[Typ],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(2,'MailAdress',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressTyp]([Id],[Typ],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(3,'Telefon',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressTyp]([Id],[Typ],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(4,'Facebook',GETUTCDATE(),GETUTCDATE(),'DBO')

INSERT INTO [Adress].[AdressVariant]([Id],[AdressTypFKID],[Variant],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(1,1,'Folkbokföringsadress',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressVariant]([Id],[AdressTypFKID],[Variant],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(2,1,'Adress Arbete',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressVariant]([Id],[AdressTypFKID],[Variant],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(3,1,'LeveransAdress',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressVariant]([Id],[AdressTypFKID],[Variant],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(4,1,'FaktureringsAdress',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressVariant]([Id],[AdressTypFKID],[Variant],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(5,1,'Adressens Adress',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressVariant]([Id],[AdressTypFKID],[Variant],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(6,1,'Tomte Adress',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressVariant]([Id],[AdressTypFKID],[Variant],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(7,2,'MailAdress Arbete',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressVariant]([Id],[AdressTypFKID],[Variant],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(8,2,'Mailadress Privat',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressVariant]([Id],[AdressTypFKID],[Variant],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(9,3,'Mobil Arbete',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressVariant]([Id],[AdressTypFKID],[Variant],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(10,3,'Mobil Privat',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressVariant]([Id],[AdressTypFKID],[Variant],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(11,3,'Telefon Arbete',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressVariant]([Id],[AdressTypFKID],[Variant],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(12,3,'Telefon Privat',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressVariant]([Id],[AdressTypFKID],[Variant],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(13,4,'Facebook Privat',GETUTCDATE(),GETUTCDATE(),'DBO')
INSERT INTO [Adress].[AdressVariant]([Id],[AdressTypFKID],[Variant],[SkapadDatum],[UpdateradDatum],[UpdateradAv])
VALUES(14,4,'Facebook Arbete',GETUTCDATE(),GETUTCDATE(),'DBO')




GO


