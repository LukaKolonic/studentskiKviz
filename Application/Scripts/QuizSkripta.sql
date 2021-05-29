CREATE DATABASE Quiz;

USE Quiz;

CREATE TABLE [User] (
	[IDUser] int IDENTITY(1,1) NOT NULL,
	[Ime] nvarchar(50) NOT NULL,
	[Prezime] nvarchar(50) NOT NULL,
	[Email] nvarchar(50) NOT NULL,
	[Password] nvarchar(64) NOT NULL,
	CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([IDUser])
)

CREATE TABLE [Quiz] (
	[IDQuiz] int IDENTITY(1,1) NOT NULL,
	[UserID] int NOT NULL,
	CONSTRAINT [PK_Quiz] PRIMARY KEY CLUSTERED ([IDQuiz]),
	CONSTRAINT [FK_Quiz_User] FOREIGN KEY([UserID]) REFERENCES [User](IDUser)
)