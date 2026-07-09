USE [Test]
GO

/****** 개체: Table [dbo].[Table] 스크립트 날짜: 2026-07-09 오후 2:25:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Member] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [UserId]   NVARCHAR (20) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Email]    NVARCHAR (50) NULL
);


