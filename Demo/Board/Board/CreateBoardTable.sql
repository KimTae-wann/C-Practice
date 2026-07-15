--게시판 생성 
Create Database NETBoard
go

use NETBoard
go

--테이블 생성
--Drop Table Board
Create Table Board
(
	id			int				identity	not null, 
	name		nvarchar(10)					not null,
	email		nvarchar(20)					not null,
	title		nvarchar(100)				not null,
	content		nvarchar(max)				not null,
	password	nvarchar(20)					not null,
	iDate		datetime					not null	default (getdate()),
	readCount	int							not null	default (0),
	Constraint PK_Board_id  Primary Key (id)
)
go



Insert Board(name, email, title, content, password, ReadCount) 
Values(N'홍길동', N'hong@naver.com', N'새해에는 이런 과정이 오픈됩니다.', N'WPF과정이 새롭게 오픈됩니다.', '1234', 0)
Insert Board(name, email, title, content, password, ReadCount) 
Values(N'김유신',N'kim@naver.com', N'아이폰이 출시되면서 생긴 변화들', N'모바일 과정도 오픈이 많이되고 개발자가 대접받는 시대가...', '1234', 0)
Insert Board(name, email, title, content, password, ReadCount) 
Values(N'일지매', N'il@naver.com', N'새로운 노트북이 출시되었습니다.', N'다중 터치를 지원하는 노트북들이 쏟아져 나오네요', '1234', 0)
Insert Board(name, email, title, content, password, ReadCount) 
Values(N'홍위갑', N'hong@naver.com', N'SQL Server 2022의 새로운 특징들', N'다양한 관리 툴들과 압축 백업을 지원', '1234', 0)
Insert Board(name, email, title, content, password, ReadCount) 
Values(N'홍길동', N'hong@naver.com', N'.NET 6.0이 출시됩니다.', N'비주얼스튜디오 2022에서는 .NET 6.0이 지원됩니다.', '1234', 0)
Insert Board(name, email, title, content, password, ReadCount) 
Values(N'홍길동', N'hong@naver.com', N'ASP.NET Core영상이 올라왔습니다.', N'많은 기능들이 추가된 것 같지는 않습니다.', '1234', 0)
Insert Board(name, email, title, content, password, ReadCount) 
Values(N'홍길동', N'hong@naver.com', N'비주얼스튜디오 2022 출시', N'새로운 기능들이 대거 추가되었습니다. ', '1234', 0)
Insert Board(name, email, title, content, password, ReadCount) 
Values(N'홍길동', N'hong@naver.com', N'비주얼스튜디오 2019의 특징', N'현재 현업에서 가장 많이 사용하는 개발툴입니다.', '1234', 0)
Insert Board(name, email, title, content, password, ReadCount) 
Values(N'홍길동', N'hong@naver.com', N'비주얼스튜디오 2017의 특징', N'.NET Framework 4.7을 지원하는 많이 안정화된 버전입니다.', '1234', 0)
Insert Board(name, email, title, content, password, ReadCount) 
Values(N'박문수', N'hong@naver.com', N'비주얼스튜디오 2015의 특징', N'.NET Framewoek 4.6을 지원하던 버전입니다.', '1234', 0)
Insert Board(name, email, title, content, password, ReadCount) 
Values(N'김재박', N'hong@naver.com', N'비주얼스튜디오 2002의 특징', N'초기 .NET Framework을 지원하는 버전입니다.', '1234', 0)
Insert Board(name, email, title, content, password, ReadCount) 
Values(N'이순신', N'hong@naver.com', N'보급형 DSLR 캐논 550', N'캐논 550은 저렴하지만 일반 사진과 HD 동영상 촬영이 가능합니다.', '1234', 0)
Insert Board(name, email, title, content, password, ReadCount) 
Values(N'일지매', N'hong@naver.com', N'아이폰이 출시되었습니다.', N'드디어 우리나라에서도 아이폰을 사용할 수 있습니다', '1234', 0)


Select * From Board 