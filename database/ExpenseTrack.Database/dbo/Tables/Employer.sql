﻿CREATE TABLE dbo.Employer
(
	EmployerId SMALLINT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Employer_Id PRIMARY KEY CLUSTERED,
	EmployerName VARCHAR(50) NOT NULL,
	EmployerDescription VARCHAR(100) NOT NULL
)
