CREATE PROCEDURE [dbo].[SPDeleteSkills]
	@SkillsID int
AS
	DELETE FROM Skills WHERE SkillsId = @SkillsId
