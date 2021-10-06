CREATE PROCEDURE [dbo].[SPLoginClient]
	@Email VARCHAR(150),
	@Passwd NVARCHAR(150)
AS
BEGIN
	SELECT ClientId, LastName, FirstName,Company,Phone,Email
	FROM Client 
	WHERE Email = @Email
	AND Passwd = HASHBYTES('SHA2_512', CONCAT(dbo.Salt(), @Passwd) );
END