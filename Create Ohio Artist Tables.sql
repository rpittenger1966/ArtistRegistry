use [ArtistRegistry]
go


-- DROP SCHEMA  VOICE 

IF NOT EXISTS ( SELECT  *
                FROM    sys.schemas
                WHERE   name = N'oar' ) 
    EXEC('CREATE SCHEMA [oar] AUTHORIZATION [dbo]');
GO

IF OBJECT_ID('oar.ArtistDetails', 'U') IS NOT NULL
  DROP TABLE [oar].[ArtistDetails];

IF OBJECT_ID('oar.ArtistEntry', 'U') IS NOT NULL
  DROP TABLE [oar].[ArtistEntry];

--IF OBJECT_ID('oar.FirstLetter', 'U') IS NOT NULL
--  DROP TABLE [oar].[FirstLetter];


--CREATE TABLE [oar].[FirstLetter] (
--	[FirstLetterId] varchar(1) NOT NULL,
--	[Url] varchar(200) NULL,
--	[PageCount] int NULL,
--	[LastUpdated] datetime NULL,

--	CONSTRAINT PK_FirstLetter PRIMARY KEY CLUSTERED ([FirstLetterId])
--);


CREATE TABLE [oar].[ArtistEntry] (
	[FirstLetterId] varchar(1) NOT NULL,
	[Slug] varchar(50) NOT NULL,
	[Url] varchar(200) NULL,
	[ContentFileName] varchar(200) NULL,
	[ArtistId] int null,
	[LastUpdated] datetime NULL,

	CONSTRAINT PK_ArtistEntry PRIMARY KEY CLUSTERED ([FirstLetterId],[Slug])
);


CREATE TABLE [oar].[ArtistDetails] (
	[FirstLetterId] varchar(1) NOT NULL,
	[Slug] varchar(50) NOT NULL,
	[FullName] varchar(100) NULL,
	[GivenName] varchar(40) NULL,
	[FamilyName] varchar(40) NULL,
	[Url] varchar(200) NULL,
	[ContentFileName] varchar(200) NULL,
	[LastUpdated] datetime NULL,

	CONSTRAINT PK_ArtistDetails PRIMARY KEY CLUSTERED ([FirstLetterId],[Slug])
);


INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('A');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('B');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('C');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('D');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('E');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('F');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('G');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('H');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('I');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('J');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('K');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('L');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('M');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('N');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('O');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('P');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('Q');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('R');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('S');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('T');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('U');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('V');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('W');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('X');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('Y');
INSERT INTO [oar].[FirstLetter] ([FirstLetterId]) VALUES ('Z');


