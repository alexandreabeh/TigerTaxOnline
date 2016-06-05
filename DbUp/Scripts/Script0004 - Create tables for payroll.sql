CREATE TABLE Employee
(
	EmployeeId INT IDENTITY(1,1)	PRIMARY KEY,
	UserId INT						REFERENCES Users(UserId) NOT NULL,
	FirstName NVARCHAR(50)			NOT NULL,
	LastName NVARCHAR(50)			NOT NULL,
	IsActive BIT					NOT NULL,
	PhoneNumber INT					NULL,
	Notes NVARCHAR(1000)			NULL,
);

CREATE TABLE PayrollCycle
(
	PayrollCycleId INT IDENTITY(1,1) PRIMARY KEY,
	UserId INT						REFERENCES Users(UserId) NOT NULL,	
	Name NVARCHAR(100)				NOT NULL
);

CREATE TABLE PayrollEntry
(
	PayrollEntryId INT IDENTITY(1,1) PRIMARY KEY,
	UserId INT						REFERENCES Users(UserId) NOT NULL,
	EmployeeId INT					REFERENCES Employee(EmployeeId) NOT NULL, 
	DateOfWork DATE					NOT NULL,
	TimeStarted TIME				NULL,
	TimeFinished TIME				NULL,
	HoursWorked FLOAT				NOT NULL,
	BasePayPerHour FLOAT			NOT NULL,
	Bonus FLOAT						NULL,
	TotalPay FLOAT					NOT NULL,
	HasBeenPaid BIT					NOT NULL,
	PayrollCycleId INT				REFERENCES PayrollCycle(PayrollCycleId) NOT NULL,
	Notes NVARCHAR(1000)			NULL
);