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
    
    -- 상세 조회 시 조회수 증가 처리
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
    SET NOCOUNT ON;
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