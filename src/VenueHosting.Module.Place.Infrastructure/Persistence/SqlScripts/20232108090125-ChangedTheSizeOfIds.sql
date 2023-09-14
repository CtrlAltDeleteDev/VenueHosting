USE VenuePlace

ALTER TABLE Facilities DROP CONSTRAINT PK_Facility
ALTER TABLE Facilities DROP CONSTRAINT FK_Place
GO
ALTER TABLE Facilities ALTER COLUMN FacilityId VARCHAR(36) NOT NULL
ALTER TABLE Facilities ALTER COLUMN PlaceId VARCHAR(36) NOT NULL
GO
ALTER TABLE Facilities ADD CONSTRAINT PK_Facility PRIMARY KEY (FacilityId)
GO

ALTER TABLE Places DROP CONSTRAINT PK_Place
ALTER TABLE Places DROP CONSTRAINT FK_Place_Owner
GO
ALTER TABLE Places ALTER COLUMN PlaceId VARCHAR(36) NOT NULL
ALTER TABLE Places ALTER COLUMN Status VARCHAR(10) NOT NULL
ALTER TABLE Places ALTER COLUMN OwnerId VARCHAR(36) NOT NULL
GO
ALTER TABLE Places ADD CONSTRAINT PK_Place PRIMARY KEY (PlaceId)
GO

ALTER TABLE Owners DROP CONSTRAINT PK_Owner
ALTER TABLE Owners ALTER COLUMN OwnerId VARCHAR(36) NOT NULL
ALTER TABLE Owners ALTER COLUMN UserId VARCHAR(36) NOT NULL
ALTER TABLE Owners ADD CONSTRAINT PK_Owner PRIMARY KEY (OwnerId)
GO

ALTER TABLE Places ADD CONSTRAINT FK_Place_Owner FOREIGN KEY (OwnerId) REFERENCES Owners (OwnerId)
ALTER TABLE Facilities ADD CONSTRAINT FK_Facility_Place FOREIGN KEY (PlaceId) REFERENCES Places (PlaceId)
GO

USE VenuePlace
IF (EXISTS (SELECT * FROM Places WHERE PlaceId = '1'))
    BEGIN
        SELECT 1;
    END
ELSE
    BEGIN
        SELECT 0;
    END