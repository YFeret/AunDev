CREATE PROCEDURE [dbo].[SPLoginDev]
	@Email VARCHAR(150),
	@Passwd NVARCHAR(150)
AS
BEGIN
	SELECT DevId,Lastname,Firstname,BirthDate,Phone,Email
	FROM Dev
	WHERE Email = @Email
	AND Passwd = HASHBYTES('SHA2_512', CONCAT(dbo.Salt(), @Passwd) );
END
