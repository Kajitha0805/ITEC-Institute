CREATE DATABASE ITECH_DB;

use ITECH_DB;
 
CREATE TABLE Course(
	CourseId nvarchar(50)PRIMARY KEY NOT NULL,
	CourseName nvarchar(50) NOT NULL,
	Duration nvarchar(50) NOT NULL,
	Fee decimal(20, 2) NOT NULL,
	Instructor nvarchar(50) NOT NULL,
	Syllabus nvarchar(100) NOT NULL,
	);

create table Student(
NicNo nvarchar(50) primary key not null,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
CourseId nvarchar(50) ,
foreign key(CourseId)references Course(CourseId),
Batch nvarchar(20)not null,
Date date not null,
MobileNo nvarchar(20)not null,
Email nvarchar(30)not null,
Address nvarchar(60)not null,
RegFee decimal(20,2)not null,
AdditionalFee decimal(20,2)not null,
);
select * from Course

select * from Student

create table FollowUp(
Name nvarchar(50) not null,
Moblie nvarchar(20) not null,
CourseId nvarchar(50) ,
foreign key(CourseId)references Course(CourseId),
Date date not null,
Email nvarchar(30)not null,
Address nvarchar(50) not null,
Description nvarchar(50)not null
);

select * from FollowUp

create table UploadModule(
Title nvarchar(50) not null,
CourseId nvarchar(50) ,
foreign key(CourseId)references Course(CourseId),
Batch nvarchar(50) not null,
Date date not null,
Uplode varbinary (max),
Description nvarchar(50) not null,

);

create table Batch(
BatchId uniqueidentifier primary key,
BatchName nvarchar(50) not null
);


create table Batch(
BatchName nvarchar(50) not null
);

create table Expense(
Title nvarchar(50) not null,
Date date not null,
Price decimal not null,
Receipt  varbinary (max),
Description nvarchar(50) not null
);

select * from Expense

select * from Batch

