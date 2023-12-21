Create Database Recruitment 

Create table Users(
[Name] varchar(50) not null,
[Email] varchar(50) not null,
[Address] varchar(150),
[Phone] varchar(20),
[UserType] varchar(20) not null,
[Money] decimal(7,2) default(0)
)