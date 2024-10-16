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