
CREATE PROCEDURE dbo.UP_SelectAllBoards
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id, name, email, title, content, password, iDate, readCount 
    FROM Board;
END;