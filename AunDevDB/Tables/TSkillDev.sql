CREATE TABLE [dbo].[TSkillDev]
(
	DevId INT,
	SkillsId INT,
	CONSTRAINT PK_DEVandSKillsID PRIMARY KEY(DevId, SkillsId),
	CONSTRAINT [FK_TSkillDev_ToDev] FOREIGN KEY(DevId) REFERENCES Dev(DevId),
	CONSTRAINT [FK_TSkillDev_ToSkills] FOREIGN KEY(SkillsId) REFERENCES [Skills](SkillsId), 
)
