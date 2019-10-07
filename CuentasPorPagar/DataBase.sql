use master
create database CuentasPorPagar;
Go
Use CuentasPorPagar
Go

create table Roles(
	Id int primary key identity(1,1),
	Nombre nvarchar(20)
)
create table Paises(
	Id int primary key identity(1,1),
	Nombre nvarchar(30)
)
create table Departamentos(
	Id int primary key identity(1,1),
	Nombre nvarchar(30),
	IdPais int
)
create table Municipios(
	Id int primary key identity(1,1),
	Nombre nvarchar(60),
	IdDepartamento int
)
create table Usuarios(
	Id int primary key identity(1,1),
	Nombre nvarchar(60),
	NIT nvarchar(17),
	DUI nvarchar(10),
	Email nvarchar(30),
	Direccion nvarchar(100),
	Usuario nvarchar(10) unique,
	HashPassword varbinary(500),
	Habilitado bit,
	IdRole int
)
create table Proveedor(
	Id int primary key identity(1,1),
	Nombre nvarchar(60),
	IdPais int,
	IdDepartamento int,
	IdMunicipio int,
	Direccion nvarchar(200),
	NumeroRegistro nvarchar(25),
	NIT nvarchar(17),
	RazonSocial nvarchar(15)
)
create table ContactoProveedor(
	Id int primary key identity(1,1),
	Nombre nvarchar(60),
	DUI nvarchar(10),
	Email nvarchar(30),
	Cargo nvarchar(17),
	IdProveedor int
)
create table PlanPago(
	Id int primary key identity(1,1),
	Nombre nvarchar(20)
) 
create table Documento(
	Id int primary key identity(1,1),
	NumeroDocumento nvarchar(60),
	Tipo int,
	AplicaIVA bit,
	FechaPago date,
	CantidadPagos int,
	ValorTotal decimal(15,2),
	FechaEmision date,
	IdPlan int,
	Plazo nvarchar(10),
	Concepto nvarchar(250),
	IdProveedor int,
	IdUsuario int	
)
create table Pagos(
	Id int primary key identity(1,1),
	IdDocumento int,
	FechaPago date,
	IdUsuario int,
	TipoPago int
)
Go
-- Creación de Foreigns Keys
alter table Departamentos
add constraint FK_departamento_pais
foreign key (IdPais)
references Paises(Id);

alter table Municipios
add constraint FK_municipio_departamento
foreign key (IdDepartamento)
references Departamentos(Id);

alter table Usuarios
add constraint FK_usuarios_roles
foreign key (IdRole)
references Roles(Id);

alter table ContactoProveedor
add constraint FK_contactos_proveedor
foreign key (IdProveedor)
references Proveedor(Id);

alter table Documento
add constraint FK_documento_plan
foreign key(IdPlan)
references PlanPago(Id);

alter table Documento
add constraint FK_documento_proveedor
foreign key(IdProveedor)
references Proveedor(Id);

alter table Documento
add constraint FK_documento_usuario
foreign key(IdUsuario)
references Usuarios(Id);

--Trigger y Otros procedimientos

-- Encriptar clave al momento de insertar
GO
CREATE TRIGGER encriptar on Usuarios AFTER INSERT
AS
BEGIN
UPDATE Usuarios SET HashPassword=EncryptByPassPhrase(N'nirePassword', CONVERT(Nvarchar(100),HashPassword)) WHERE Id=(select Id from inserted)
END;
GO


Create procedure LoginUser 
	@User nvarchar(100),
	@password nvarchar(100)
	as 
	begin 
		select * from Usuarios where Usuario=@User and DECRYPTBYPASSPHRASE(N'nirePassword',HashPassword) = CONVERT(varchar(100),@password)
	end 