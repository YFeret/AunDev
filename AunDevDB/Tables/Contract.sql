CREATE TABLE [dbo].[Contract]
(
	ContractId INT IDENTITY,
	Summary VARCHAR(50) NOT NULL,
	ContractLength INT NOT NULL,
	[Status] BIT NULL,
	Description VARCHAR(5000) NOT NULL,
	ClientId INT NOT NULL,
	DevId INT NOT NULL,
	CONSTRAINT PK_ContractID PRIMARY KEY (ContractId),
	CONSTRAINT [FK_Contract_ToClient] FOREIGN KEY(ClientId) REFERENCES Client(ClientId),
	CONSTRAINT [FK_Contract_ToDev] FOREIGN KEY(DevId) REFERENCES Dev(DevId), 
    
)
