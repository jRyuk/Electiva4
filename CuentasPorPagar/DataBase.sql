use master
create database CuentasPorPagar;
Go
Use CuentasPorPagar
Go
create table Roles(
	Id int primary key identity(1,1),
	Nombre nvarchar(20)
)