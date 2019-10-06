use master
create database CuentasPorPagar;
Go
Use CuentasPorPagar
Go
create table Roles(
	Id int primary key identity(1,1),
	Nombre nvarchar(20)
)
drop table Usuarios
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
	IdRol int
)
create table Proveedor(
	Id int primary key identity(1,1),
	Nombre nvarchar(60),
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

alter table Usuarios
add constraint FK_usuarios_roles
foreign key (IdRol)
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