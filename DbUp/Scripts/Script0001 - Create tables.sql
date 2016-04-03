CREATE TABLE Users
(
	UserId INT						PRIMARY KEY,
	FirstName NVARCHAR(50)			NOT NULL,
	LastName NVARCHAR(50)			NOT NULL,
	Username NVARCHAR(50)			NOT NULL,
	Email NVARCHAR(50)				NOT NULL,
	UserPassword NVARCHAR(50)		NOT NULL
);

CREATE TABLE Rules
(
	RuleId INT						PRIMARY KEY,
	UserId INT						REFERENCES Users(UserId) NOT NULL,
	Name NVARCHAR(1000)				NOT NULL,
	FieldToMatch NVARCHAR(50)		NOT NULL,
	DegreeOfMatch NVARCHAR(50)		NOT NULL,
	StringToMatch NVARCHAR(1000)	NOT NULL,
);

CREATE TABLE Records
(
	RecordId INT					PRIMARY KEY,
	UserId INT						REFERENCES Users(UserId) NOT NULL,
	Name NVARCHAR(1000)				NOT NULL,
	TaxYear INT						NOT NULL,
	LastModified DATE				NOT NULL,
	TotalExpenses FLOAT				NOT NULL,
	TotalIncome FLOAT				NOT NULL,
	NetTotal FLOAT					NOT NULL
);

CREATE TABLE AssignedRules
(
	AssignedRuleId INT				PRIMARY KEY,
	RecordId INT					REFERENCES Records(RecordId) NOT NULL,
	RuleId INT						REFERENCES Rules(RuleId) NOT NULL,
	IsEnabled BIT					NOT NULL
);

CREATE TABLE Categories
(
	CategoryId INT					PRIMARY KEY,
	RecordId INT					REFERENCES Records(RecordId) NOT NULL,
	ParentCategoryId INT			REFERENCES Categories(CategoryId),
	Name NVARCHAR(1000)				NOT NULL,
	Total FLOAT						NOT NULL,
	IsExpense BIT					NOT NULL,
	CategoryDescription  NVARCHAR(1000)
);

CREATE TABLE Entries
(
	EntryId INT						PRIMARY KEY,
	RecordId INT					REFERENCES Records(RecordId) NOT NULL,
	CategoryId INT					REFERENCES Categories(CategoryId),
	TransactionDate DATE			NOT NULL,
	Amount FLOAT					NOT NULL,
	Location NVARCHAR(1000),
	EntryDescription NVARCHAR(1000),			
	Other NVARCHAR(1000)
);