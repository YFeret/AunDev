CREATE PROCEDURE [dbo].[SPAddDev]
	@Lastname VARCHAR(50),
	@Firstname VARCHAR(50),
	@BirthDate DATETIME2(0),
	@Phone VARCHAR(50),
	@Email VARCHAR(150),
	@Passwd NVARCHAR(150)
AS
	DECLARE @HashPasswd VARBINARY(64)
	SET @HashPasswd = HASHBYTES('SHA2-512',CONCAT(dbo.Salt(),@Passwd))

	INSERT INTO Client VALUES (@Lastname,@Firstname,@BirthDate,@Phone,@Email,@HashPasswd)
