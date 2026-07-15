USE NETBoard;
GO

CREATE PROCEDURE dbo.UP_SelectAllBoards
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id, name, email, title, content, password, iDate, readCount 
    FROM Board 
    ORDER BY id DESC;
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
    SET NOCOUNT ON;
    INSERT INTO Board (name, email, title, content, password)
    VALUES (@name, @email, @title, @content, @password);
END;
GO

CREATE PROCEDURE dbo.UP_UpdateBoard
    @id INT,
    @title NVARCHAR(100),
    @content NVARCHAR(MAX),
    @password NVARCHAR(20),
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Board WHERE id = @id AND password = @password)
    BEGIN
        UPDATE Board 
        SET title = @title, 
            content = @content 
        WHERE id = @id AND password = @password;
        
        SET @Result = 1;
    END
    ELSE
    BEGIN
        SET @Result = 0;
    END;
END;
GO

CREATE PROCEDURE dbo.UP_DeleteBoard
    @id INT,
    @password NVARCHAR(20),
    @Result INT OUTPUT -- 1: 성공, 0: 실패(비밀번호 불일치)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Board WHERE id = @id AND password = @password)
    BEGIN
        DELETE FROM Board WHERE id = @id AND password = @password;
        SET @Result = 1;
    END
    ELSE
    BEGIN
        SET @Result = 0;
    END;
END;
GO