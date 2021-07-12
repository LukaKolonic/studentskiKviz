CREATE DATABASE Quiz;
GO
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
	[Naziv] nvarchar(50) NOT NULL,
	CONSTRAINT [PK_Quiz] PRIMARY KEY CLUSTERED ([IDQuiz]),
	CONSTRAINT [FK_Quiz_User] FOREIGN KEY([UserID]) REFERENCES [User](IDUser)
)

CREATE TABLE [Pitanje] (
	[IDPitanje] int IDENTITY(1,1) NOT NULL,
	[QuizID] int NOT NULL,
	[Tekst] nvarchar(1024) NOT NULL,
	CONSTRAINT [PK_Pitanje] PRIMARY KEY CLUSTERED ([IDPitanje]),
	CONSTRAINT [FK_Pitanje_Quiz] FOREIGN KEY([QuizID]) REFERENCES [Quiz](IDQuiz)
)

CREATE TABLE [Odgovor] (
	[IDOdgovor] int IDENTITY(1,1) NOT NULL,
	[PitanjeID] int NOT NULL,
	[Tekst] nvarchar(1024) NOT NULL,
	[Correct] bit NOT NULL,
	CONSTRAINT [PK_Odgovor] PRIMARY KEY CLUSTERED ([IDOdgovor]),
	CONSTRAINT [FK_Odgovor_Pitanje] FOREIGN KEY([PitanjeID]) REFERENCES [Pitanje](IDPitanje)
)

CREATE TABLE [PlayedQuiz] (
	[IDPlayedQuiz] int IDENTITY(1,1) NOT NULL,
	[QuizID] int NOT NULL,
	[GeneratedQuizID] int NOT NULL,
	[BrojPitanja] int NOT NULL,
	CONSTRAINT [PK_ActiveQuiz] PRIMARY KEY CLUSTERED ([IDPlayedQuiz]),
	CONSTRAINT [FK_PlayedQuiz_Quiz] FOREIGN KEY([QuizID]) REFERENCES [Quiz](IDQuiz)
)

CREATE TABLE [Player] (
	[IDPlayer] int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(32) NOT NULL,
	[PlayedQuizID] int NOT NULL,
	[Points] int NOT NULL,
	CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED ([IDPlayer]),
	CONSTRAINT [FK_Player_PlayedQuiz] FOREIGN KEY([PlayedQuizID]) REFERENCES [PlayedQuiz](IDPlayedQuiz)
)