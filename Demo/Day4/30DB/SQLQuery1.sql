use Test

--CREATE TABLE [dbo].[Member]
--(
--	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
--    [UserId] NVARCHAR(20) NOT NULL, 
--    [Password] NVARCHAR(50) NOT NULL, 
--    [Name] NVARCHAR(50) NOT NULL, 
--    [Email] NVARCHAR(50) NULL
--)

SELECT *
  FROM MEMBER

INSERT INTO MEMBER
     ( USERID
     , PASSWORD
     , NAME
     , EMAIL)
VALUES
     ( 'user4'
     , '1111'
     , N'김철수'
     , 'kim@aaa.com')

DELETE
  FROM MEMBER
 WHERE USERID = 'user4'

UPDATE MEMBER
   SET PASSWORD = 1111
 WHERE USERID = 'user1'

 ------

 CREATE PROCEDURE [dbo].[uspDeleteByID]
	@id int
AS
	DELETE
	  FROM MEMBER
	 WHERE ID=@ID
RETURN 0


CREATE PROCEDURE [dbo].[uspSelectALL]
AS
	SELECT *
	  FROM MEMBER
RETURN 0