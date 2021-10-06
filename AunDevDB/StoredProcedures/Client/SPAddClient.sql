CREATE PROCEDURE [dbo].[SPAddClient]
	@Lastname VARCHAR(50),
	@Firstname VARCHAR(50),
	@Company VARCHAR(50),
	@Phone VARCHAR(50),
	@Email VARCHAR(150),
	@Passwd NVARCHAR(150)
AS
	DECLARE @HashPasswd VARBINARY(64)
	SET @HashPasswd = HASHBYTES('SHA2_512',CONCAT(dbo.Salt(),@Passwd))

	INSERT INTO Client VALUES (@Lastname,@Firstname,@Company,@Phone,@Email,@HashPasswd)
