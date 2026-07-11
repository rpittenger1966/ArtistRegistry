use [ArtistRegistry]
go


-- DROP SCHEMA  VOICE 

IF NOT EXISTS ( SELECT  *
                FROM    sys.schemas
                WHERE   name = N'oar' ) 
    EXEC('CREATE SCHEMA [oar] AUTHORIZATION [dbo]');
GO

IF OBJECT_ID('oar.FirstLetter', 'U') IS NOT NULL
  DROP TABLE [oar].[FirstLetter];


CREATE TABLE [oar].[FirstLetter] (
	[FirstLetterId] varchar(1) NOT NULL,
	[Url] varchar(200) NULL,
	[PageCount] int NULL,
	[LastUpdated] datetime NULL,

	CONSTRAINT PK_FirstLetter PRIMARY KEY CLUSTERED ([FirstLetterId])
);
