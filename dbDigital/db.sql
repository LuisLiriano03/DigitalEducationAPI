
create database DBDigitalEducation

use DBDigitalEducation

go

create table Rol(
RolId int primary key identity(1,1),
NameRol varchar(50),
RegistrationDate datetime default getdate()
)

create table Menu(
MenuId int primary key identity(1,1),
NameMenu varchar(50),
Icon varchar(50),
MenuUrl varchar(50)
)

create table MenuRol(
MenuIdRol int primary key identity(1,1),
MenuId int references Menu(MenuId),
RolId int references Rol(RolId)
)

create table UserInformation(
UserInformationId int primary key identity(1,1),
FullName varchar(50),
Age int,
RolId int references Rol(RolId),
Email varchar(100),
UserPassword varchar(200),
IsActive bit default 1,
RegistrationDate datetime default getdate()
)

CREATE TABLE Course (
CourseId int primary key identity(1,1),
CourseName VARCHAR(100),
UserInformationId int references UserInformation(UserInformationId),
RegistrationDate datetime default getdate()
);

CREATE TABLE StudentEnrollment (
EnrollmentId int primary key identity(1,1),
UserInformationId int references UserInformation(UserInformationId),
CourseId int references Course(CourseId),
RegistrationDate datetime default getdate()
);

CREATE TABLE Assignment (
AssignmentId int primary key identity(1,1),
CourseId int references Course(CourseId),
UserInformationId int references UserInformation(UserInformationId),
Title VARCHAR(100),
AssignmentDescription TEXT,
DueDate date
);

CREATE TABLE Grade (
GradeId INT PRIMARY KEY IDENTITY(1,1),
UserInformationId int references UserInformation(UserInformationId),
CourseId int references Course(CourseId),
AssignmentId INT REFERENCES Assignment(AssignmentId),
Score int,
GradeDate datetime default getdate(),
Comment TEXT
);

CREATE TABLE Forum (
ForumId int primary key identity(1,1),
CourseId int references Course(CourseId),
Title VARCHAR(100),
Descriptionforums TEXT,
UserInformationId int references UserInformation(UserInformationId),
RegistrationDate datetime default getdate()
);

CREATE TABLE ForumPost (
ForumPostId int primary key identity(1,1),
ForumId int references forum(ForumId),
UserInformationId int references UserInformation(UserInformationId),
PostText TEXT,
RegistrationDate datetime default getdate()
);

CREATE TABLE Communication (
CommunicationId int primary key identity(1,1),
CourseId int references Course(CourseId),
UserInformationId int references UserInformation(UserInformationId),
MessageCommunicactions TEXT,
RegistrationDate datetime default getdate()
);

