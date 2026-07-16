USE NETBoard;
GO

CREATE PROCEDURE dbo.UP_SelectAllBoards
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id, name, email, title, content, password, iDate, readCount 
    FROM Board;
END;
GO

CREATE PROCEDURE dbo.UP_SelectOneBoard
    @id INT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Board SET readCount = readCount + 1 WHERE id = @id;

    SELECT id, name, email, title, content, password, iDate, readCount 
    FROM Board 
    WHERE id = @id;
END;
GO

CREATE PROCEDURE dbo.UP_InsertBoard
    @name NVARCHAR(10),
    @email NVARCHAR(20),
    @title NVARCHAR(100),
    @content NVARCHAR(MAX),
    @password NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT OFF;
    INSERT INTO Board (name, email, title, content, password)
    VALUES (@name, @email, @title, @content, @password);
END;
GO

CREATE PROCEDURE dbo.UP_UpdateBoard
    @id INT,
    @title NVARCHAR(100),
    @content NVARCHAR(MAX),
    @password NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT OFF; 

    UPDATE Board 
    SET title = @title, 
        content = @content 
    WHERE id = @id AND password = @password;
END;
GO

CREATE PROCEDURE dbo.UP_DeleteBoard
    @id INT,
    @password NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT OFF;

    DELETE FROM Board 
    WHERE id = @id AND password = @password;
END;
GO

CREATE PROCEDURE dbo.UP_RegisterMember
    @userId NVARCHAR(20),
    @password NVARCHAR(20),
    @name NVARCHAR(10),
    @email NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Member WHERE userId = @userId)
    BEGIN
        SELECT 0 AS Result;
    END
    ELSE
    BEGIN
        INSERT INTO Member (userId, password, name, email)
        VALUES (@userId, @password, @name, @email);
        SELECT 1 AS Result;
    END;
END;
GO