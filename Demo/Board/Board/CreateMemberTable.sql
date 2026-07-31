Drop Table [dbo].[Member]

CREATE TABLE [dbo].[Member]
(
	[Id]		INT				NOT NULL	PRIMARY KEY	IDENTITY, 
    [UserId]	NVARCHAR(20)	NOT NULL, 
    [Password]	NVARCHAR(50)	NOT NULL, 
    [Name]		NVARCHAR(50)	NOT NULL, 
    [Email]		NVARCHAR(50)	NULL
)
GO

INSERT [dbo].[Member](UserId, [Password], [Name], Email) VALUES (N'honggildong', N'honggildong', N'홍길동', N'hong@naver.com')
INSERT [dbo].[Member](UserId, [Password], [Name], Email) VALUES (N'kimyusin', N'kimyusin', N'김유신', N'kim@naver.com')
INSERT [dbo].[Member](UserId, [Password], [Name], Email) VALUES (N'iljimae', N'iljimae', N'일지매', N'il@naver.com')
INSERT [dbo].[Member](UserId, [Password], [Name], Email) VALUES (N'honguigab', N'honguigab', N'홍위갑', N'hong@naver.com')
INSERT [dbo].[Member](UserId, [Password], [Name], Email) VALUES (N'parkmunsu', N'parkmunsu', N'박문수', N'park@naver.com')
INSERT [dbo].[Member](UserId, [Password], [Name], Email) VALUES (N'kimjaepark', N'kimjaepark', N'김재박', N'kim@naver.com')
INSERT [dbo].[Member](UserId, [Password], [Name], Email) VALUES (N'leesoonsin', N'leesoonsin', N'이순신', N'lee@naver.com')

SELECT * FROM MEMBER