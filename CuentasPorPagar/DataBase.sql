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
	RazonSocial nvarchar(75)
)
create table ContactoProveedor(
	Id int primary key identity(1,1),
	Nombre nvarchar(60),
	DUI nvarchar(10),
	Email nvarchar(30),
	Telefono nvarchar(15),
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
	FechaVencimiento date,
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
	TipoPago nvarchar(100), 
	Monto Decimal (15,2), 
	Referencia nvarchar(100),
	ConceptoPago nvarchar(100)
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
Go

GO
CREATE TRIGGER encriptar on Usuarios AFTER INSERT, UPDATE
AS
BEGIN
IF UPDATE(HashPassword) or (select count(*) from inserted) > 0 
	BEGIN
		UPDATE Usuarios SET HashPassword=EncryptByPassPhrase(N'nirePassword', CONVERT(Nvarchar(100),HashPassword)) WHERE Id=(select Id from inserted)
	END
END;
GO

Go

Create procedure LoginUser 
	@User nvarchar(100),
	@password nvarchar(100)
	as 
	begin 
		select * from Usuarios where Usuario=@User and CAST(DECRYPTBYPASSPHRASE(N'nirePassword',HashPassword) AS VARCHAR(8000)) = convert(nvarchar(800),@password)
	end 
	
GO 

Insert into Paises(Nombre) values ('El Salvador');

insert into Departamentos (Nombre, IdPais) values ('Ahuachapán',1);
Insert into Municipios(Nombre,IdDepartamento) values ('Ahuachapán',1)
Insert into Municipios(Nombre,IdDepartamento) values ('Apaneca',1)
Insert into Municipios(Nombre,IdDepartamento) values ('Atiquizaya',1)
Insert into Municipios(Nombre,IdDepartamento) values ('Concepción de Ataco',1)
Insert into Municipios(Nombre,IdDepartamento) values ('El Refugio',1)
Insert into Municipios(Nombre,IdDepartamento) values ('Guaymango',1)
Insert into Municipios(Nombre,IdDepartamento) values ('Jujutla',1)
Insert into Municipios(Nombre,IdDepartamento) values ('San Francisco Menéndez',1)
Insert into Municipios(Nombre,IdDepartamento) values ('San Lorenzo',1)
Insert into Municipios(Nombre,IdDepartamento) values ('San Pedro Puxtla',1)
Insert into Municipios(Nombre,IdDepartamento) values ('Tacuba',1)
Insert into Municipios(Nombre,IdDepartamento) values ('Turín',1)

--------------------------------------------------------------
---------------------------------------------------------------
insert into Departamentos (Nombre, IdPais) values ('Santa Ana',1);
insert into municipios (Nombre, IdDepartamento)values('Candelaria de la Frontera',2)
insert into municipios (Nombre, IdDepartamento)values('Chalchuapa',2)
insert into municipios (Nombre, IdDepartamento)values('Coatepeque',2)
insert into municipios (Nombre, IdDepartamento)values('El Congo',2)
insert into municipios (Nombre, IdDepartamento)values('El Porvenir',2)
insert into municipios (Nombre, IdDepartamento)values('Masahuat',2)
insert into municipios (Nombre, IdDepartamento)values('Metapán',2)
insert into municipios (Nombre, IdDepartamento)values('San Antonio Pajonal',2)
insert into municipios (Nombre, IdDepartamento)values('San Sebastián Salitrillo',2)
insert into municipios (Nombre, IdDepartamento)values('Santa Ana',2)
insert into municipios (Nombre, IdDepartamento)values('Santa Rosa Guachipilín',2)
insert into municipios (Nombre, IdDepartamento)values('Santiago de la Frontera',2)
insert into municipios (Nombre, IdDepartamento)values('Texistepeque',2)
--------------------------------------------------------------
---------------------------------------------------------------
insert into Departamentos (Nombre, IdPais) values ('Sonsonate',1);
insert into municipios (Nombre,IdDepartamento)values('Acajutla',3)
insert into municipios (Nombre,IdDepartamento)values('Armenia',3)
insert into municipios (Nombre,IdDepartamento)values('Caluco',3)
insert into municipios (Nombre,IdDepartamento)values('Cuisnahuat',3)
insert into municipios (Nombre,IdDepartamento)values('Izalco',3)
insert into municipios (Nombre,IdDepartamento)values('Juayúa',3)
insert into municipios (Nombre,IdDepartamento)values('Nahuizalco',3)
insert into municipios (Nombre,IdDepartamento)values('Nahulingo',3)
insert into municipios (Nombre,IdDepartamento)values('Salcoatitán',3)
insert into municipios (Nombre,IdDepartamento)values('San Antonio del Monte',3)
insert into municipios (Nombre,IdDepartamento)values('San Julián',3)
insert into municipios (Nombre,IdDepartamento)values('Santa Catarina Masahuat',3)
insert into municipios (Nombre,IdDepartamento)values('Santa Isabel Ishuatán',3)
insert into municipios (Nombre,IdDepartamento)values('Santo Domingo Guzmán',3)
insert into municipios (Nombre,IdDepartamento)values('Sonsonate',3)
insert into municipios (Nombre,IdDepartamento)values('Sonzacate',3)
--------------------------------------------------------------
---------------------------------------------------------------
insert into Departamentos (Nombre, IdPais) values ('Chalatenango',1);
Insert into municipios (Nombre,IdDepartamento) values ('Agua Caliente',4)
Insert into municipios (Nombre,IdDepartamento) values ('Arcatao',4)
Insert into municipios (Nombre,IdDepartamento) values ('Azacualpa',4)
Insert into municipios (Nombre,IdDepartamento) values ('Chalatenango (ciudad)',4)
Insert into municipios (Nombre,IdDepartamento) values ('Comalapa',4)
Insert into municipios (Nombre,IdDepartamento) values ('Citalá',4)
Insert into municipios (Nombre,IdDepartamento) values ('Concepción Quezaltepeque',4)
Insert into municipios (Nombre,IdDepartamento) values ('Dulce Nombre de María',4)
Insert into municipios (Nombre,IdDepartamento) values ('El Carrizal',4)
Insert into municipios (Nombre,IdDepartamento) values ('El Paraíso',4)
Insert into municipios (Nombre,IdDepartamento) values ('La Laguna',4)
Insert into municipios (Nombre,IdDepartamento) values ('La Palma',4)
Insert into municipios (Nombre,IdDepartamento) values ('La Reina',4)
Insert into municipios (Nombre,IdDepartamento) values ('Las Vueltas',4)
Insert into municipios (Nombre,IdDepartamento) values ('Nueva Concepción',4)
Insert into municipios (Nombre,IdDepartamento) values ('Nueva Trinidad',4)
Insert into municipios (Nombre,IdDepartamento) values ('Nombre de Jesús',4)
Insert into municipios (Nombre,IdDepartamento) values ('Ojos de Agua',4)
Insert into municipios (Nombre,IdDepartamento) values ('Potonico',4)
Insert into municipios (Nombre,IdDepartamento) values ('San Antonio de la Cruz',4)
Insert into municipios (Nombre,IdDepartamento) values ('San Antonio Los Ranchos',4)
Insert into municipios (Nombre,IdDepartamento) values ('San Fernando',4)
Insert into municipios (Nombre,IdDepartamento) values ('San Francisco Lempa',4)
Insert into municipios (Nombre,IdDepartamento) values ('San Francisco Morazán',4)
Insert into municipios (Nombre,IdDepartamento) values ('San Ignacio',4)
Insert into municipios (Nombre,IdDepartamento) values ('San Isidro Labrador',4)
Insert into municipios (Nombre,IdDepartamento) values ('San José Cancasque',4)
Insert into municipios (Nombre,IdDepartamento) values ('San José Las Flores',4)
Insert into municipios (Nombre,IdDepartamento) values ('San Luis del Carmen',4)
Insert into municipios (Nombre,IdDepartamento) values ('San Miguel de Mercedes',4)
Insert into municipios (Nombre,IdDepartamento) values ('San Rafael',4)
Insert into municipios (Nombre,IdDepartamento) values ('Santa Rita',4)
Insert into municipios (Nombre,IdDepartamento) values ('Tejutla',4)
--------------------------------------------------------------
---------------------------------------------------------------
insert into Departamentos (Nombre, IdPais) values ('Cuscatlán',1);
insert into municipios (Nombre, IdDepartamento) values ('Candelaria',5)
insert into municipios (Nombre, IdDepartamento) values ('Cojutepeque',5)
insert into municipios (Nombre, IdDepartamento) values ('El Carmen',5)
insert into municipios (Nombre, IdDepartamento) values ('El Rosario',5)
insert into municipios (Nombre, IdDepartamento) values ('Monte San Juan',5)
insert into municipios (Nombre, IdDepartamento) values ('Oratorio de Concepción',5)
insert into municipios (Nombre, IdDepartamento) values ('San Bartolomé Perulapía',5)
insert into municipios (Nombre, IdDepartamento) values ('San Cristóbal',5)
insert into municipios (Nombre, IdDepartamento) values ('San José Guayabal',5)
insert into municipios (Nombre, IdDepartamento) values ('San Pedro Perulapán',5)
insert into municipios (Nombre, IdDepartamento) values ('San Rafael Cedros',5)
insert into municipios (Nombre, IdDepartamento) values ('San Ramón',5)
insert into municipios (Nombre, IdDepartamento) values ('Santa Cruz Analquito',5)
insert into municipios (Nombre, IdDepartamento) values ('Santa Cruz Michapa',5)
insert into municipios (Nombre, IdDepartamento) values ('Suchitoto',5)
insert into municipios (Nombre, IdDepartamento) values ('Tenancingo',5)
--------------------------------------------------------------
---------------------------------------------------------------
insert into Departamentos (Nombre, IdPais) values ('San Salvador',1);
Insert into municipios (Nombre,IdDepartamento) values('Aguilares',6)
Insert into municipios (Nombre,IdDepartamento) values('Apopa',6)
Insert into municipios (Nombre,IdDepartamento) values('Ayutuxtepeque',6)
Insert into municipios (Nombre,IdDepartamento) values('Cuscatancingo',6)
Insert into municipios (Nombre,IdDepartamento) values('Ciudad Delgado',6)
Insert into municipios (Nombre,IdDepartamento) values('El Paisnal',6)
Insert into municipios (Nombre,IdDepartamento) values('Guazapa',6)
Insert into municipios (Nombre,IdDepartamento) values('Ilopango',6)
Insert into municipios (Nombre,IdDepartamento) values('Mejicanos',6)
Insert into municipios (Nombre,IdDepartamento) values('Nejapa',6)
Insert into municipios (Nombre,IdDepartamento) values('Panchimalco',6)
Insert into municipios (Nombre,IdDepartamento) values('Rosario de Mora',6)
Insert into municipios (Nombre,IdDepartamento) values('San Marcos',6)
Insert into municipios (Nombre,IdDepartamento) values('San Martín',6)
Insert into municipios (Nombre,IdDepartamento) values('San Salvador',6)
Insert into municipios (Nombre,IdDepartamento) values('Santiago Texacuangos',6)
Insert into municipios (Nombre,IdDepartamento) values('Santo Tomás',6)
Insert into municipios (Nombre,IdDepartamento) values('Soyapango',6)
Insert into municipios (Nombre,IdDepartamento) values('Tonacatepeque',6)
--------------------------------------------------------------
---------------------------------------------------------------
insert into Departamentos (Nombre, IdPais) values ('La Libertad',1);
insert into municipios (Nombre,IdDepartamento)values('Antiguo Cuscatlán',7)
insert into municipios (Nombre,IdDepartamento)values('Chiltiupán',7)
insert into municipios (Nombre,IdDepartamento)values('Ciudad Arce',7)
insert into municipios (Nombre,IdDepartamento)values('Colón',7)
insert into municipios (Nombre,IdDepartamento)values('Comasagua',7)
insert into municipios (Nombre,IdDepartamento)values('Huizúcar',7)
insert into municipios (Nombre,IdDepartamento)values('Jayaque',7)
insert into municipios (Nombre,IdDepartamento)values('Jicalapa',7)
insert into municipios (Nombre,IdDepartamento)values('La Libertad',7)
insert into municipios (Nombre,IdDepartamento)values('Nueva San Salvador (Santa Tecla)',7)
insert into municipios (Nombre,IdDepartamento)values('Nuevo Cuscatlán',7)
insert into municipios (Nombre,IdDepartamento)values('San Juan Opico',7)
insert into municipios (Nombre,IdDepartamento)values('Quezaltepeque',7)
insert into municipios (Nombre,IdDepartamento)values('Sacacoyo',7)
insert into municipios (Nombre,IdDepartamento)values('San José Villanueva',7)
insert into municipios (Nombre,IdDepartamento)values('San Matías',7)
insert into municipios (Nombre,IdDepartamento)values('San Pablo Tacachico',7)
insert into municipios (Nombre,IdDepartamento)values('Talnique',7)
insert into municipios (Nombre,IdDepartamento)values('Tamanique',7)
insert into municipios (Nombre,IdDepartamento)values('Teotepeque',7)
insert into municipios (Nombre,IdDepartamento)values('Tepecoyo',7)
insert into municipios (Nombre,IdDepartamento)values('Zaragoza',7)
--------------------------------------------------------------
---------------------------------------------------------------
insert into Departamentos (Nombre, IdPais) values ('San Vicente',1);
insert into municipios (Nombre,IdDepartamento) values('Apastepeque',8)
insert into municipios (Nombre,IdDepartamento) values('Guadalupe',8)
insert into municipios (Nombre,IdDepartamento) values('San Cayetano Istepeque',8)
insert into municipios (Nombre,IdDepartamento) values('San Esteban Catarina',8)
insert into municipios (Nombre,IdDepartamento) values('San Ildefonso',8)
insert into municipios (Nombre,IdDepartamento) values('San Lorenzo',8)
insert into municipios (Nombre,IdDepartamento) values('San Sebastián',8)
insert into municipios (Nombre,IdDepartamento) values('San Vicente',8)
insert into municipios (Nombre,IdDepartamento) values('Santa Clara',8)
insert into municipios (Nombre,IdDepartamento) values('Santo Domingo',8)
insert into municipios (Nombre,IdDepartamento) values('Tecoluca',8)
insert into municipios (Nombre,IdDepartamento) values('Tepetitán',8)
insert into municipios (Nombre,IdDepartamento) values('Verapaz',8)
--------------------------------------------------------------
---------------------------------------------------------------
insert into Departamentos (Nombre, IdPais) values ('Cabañas',1);
insert into municipios (Nombre,IdDepartamento) values('Cinquera',9)
insert into municipios (Nombre,IdDepartamento) values('Dolores',9)
insert into municipios (Nombre,IdDepartamento) values('Guacotecti',9)
insert into municipios (Nombre,IdDepartamento) values('Ilobasco',9)
insert into municipios (Nombre,IdDepartamento) values('Jutiapa',9)
insert into municipios (Nombre,IdDepartamento) values('San Isidro',9)
insert into municipios (Nombre,IdDepartamento) values('Sensuntepeque',9)
insert into municipios (Nombre,IdDepartamento) values('Tejutepeque',9)
insert into municipios (Nombre,IdDepartamento) values('Victoria',9)
--------------------------------------------------------------
---------------------------------------------------------------
insert into Departamentos (Nombre, IdPais) values ('La Paz',1);
insert into municipios (Nombre, IdDepartamento) values ('Cuyultitán',10)
insert into municipios (Nombre, IdDepartamento) values ('El Rosario',10)
insert into municipios (Nombre, IdDepartamento) values ('Jerusalén',10)
insert into municipios (Nombre, IdDepartamento) values ('Mercedes La Ceiba',10)
insert into municipios (Nombre, IdDepartamento) values ('Olocuilta',10)
insert into municipios (Nombre, IdDepartamento) values ('Paraíso de Osorio',10)
insert into municipios (Nombre, IdDepartamento) values ('San Antonio Masahuat',10)
insert into municipios (Nombre, IdDepartamento) values ('San Emigdio',10)
insert into municipios (Nombre, IdDepartamento) values ('San Francisco Chinameca',10)
insert into municipios (Nombre, IdDepartamento) values ('San Juan Nonualco',10)
insert into municipios (Nombre, IdDepartamento) values ('San Juan Talpa',10)
insert into municipios (Nombre, IdDepartamento) values ('San Juan Tepezontes',10)
insert into municipios (Nombre, IdDepartamento) values ('San Luis Talpa',10)
insert into municipios (Nombre, IdDepartamento) values ('San Luis La Herradura',10)
insert into municipios (Nombre, IdDepartamento) values ('San Miguel Tepezontes',10)
insert into municipios (Nombre, IdDepartamento) values ('San Pedro Masahuat',10)
insert into municipios (Nombre, IdDepartamento) values ('San Pedro Nonualco',10)
insert into municipios (Nombre, IdDepartamento) values ('San Rafael Obrajuelo',10)
insert into municipios (Nombre, IdDepartamento) values ('Santa María Ostuma',10)
insert into municipios (Nombre, IdDepartamento) values ('Santiago Nonualco',10)
insert into municipios (Nombre, IdDepartamento) values ('Tapalhuaca',10)
insert into municipios (Nombre, IdDepartamento) values ('Zacatecoluca',10)
--------------------------------------------------------------
---------------------------------------------------------------
insert into Departamentos (Nombre, IdPais) values ('Usulután',1);
insert into municipios (Nombre,IdDepartamento) values('Alegría',11)
insert into municipios (Nombre,IdDepartamento) values('Berlín',11)
insert into municipios (Nombre,IdDepartamento) values('California',11)
insert into municipios (Nombre,IdDepartamento) values('Concepción Batres',11)
insert into municipios (Nombre,IdDepartamento) values('El Triunfo',11)
insert into municipios (Nombre,IdDepartamento) values('Ereguayquín',11)
insert into municipios (Nombre,IdDepartamento) values('Estanzuelas',11)
insert into municipios (Nombre,IdDepartamento) values('Jiquilisco',11)
insert into municipios (Nombre,IdDepartamento) values('Jucuapa',11)
insert into municipios (Nombre,IdDepartamento) values('Jucuarán',11)
insert into municipios (Nombre,IdDepartamento) values('Mercedes Umaña',11)
insert into municipios (Nombre,IdDepartamento) values('Nueva Granada',11)
insert into municipios (Nombre,IdDepartamento) values('Ozatlán',11)
insert into municipios (Nombre,IdDepartamento) values('Puerto El Triunfo',11)
insert into municipios (Nombre,IdDepartamento) values('San Agustín',11)
insert into municipios (Nombre,IdDepartamento) values('San Buenaventura',11)
insert into municipios (Nombre,IdDepartamento) values('San Dionisio',11)
insert into municipios (Nombre,IdDepartamento) values('San Francisco Javier',11)
insert into municipios (Nombre,IdDepartamento) values('Santa Elena',11)
insert into municipios (Nombre,IdDepartamento) values('Santa María',11)
insert into municipios (Nombre,IdDepartamento) values('Santiago de María',11)
insert into municipios (Nombre,IdDepartamento) values('Tecapán',11)
insert into municipios (Nombre,IdDepartamento) values('Usulután',11)
--------------------------------------------------------------
---------------------------------------------------------------
insert into Departamentos (Nombre, IdPais) values ('San Miguel',1);
insert into municipios (Nombre,IdDepartamento) values('Carolina',12)
insert into municipios (Nombre,IdDepartamento) values('Chapeltique',12)
insert into municipios (Nombre,IdDepartamento) values('Chinameca',12)
insert into municipios (Nombre,IdDepartamento) values('Chirilagua',12)
insert into municipios (Nombre,IdDepartamento) values('Ciudad Barrios',12)
insert into municipios (Nombre,IdDepartamento) values('Comacarán',12)
insert into municipios (Nombre,IdDepartamento) values('El Tránsito',12)
insert into municipios (Nombre,IdDepartamento) values('Lolotique',12)
insert into municipios (Nombre,IdDepartamento) values('Moncagua',12)
insert into municipios (Nombre,IdDepartamento) values('Nueva Guadalupe',12)
insert into municipios (Nombre,IdDepartamento) values('Nuevo Edén de San Juan',12)
insert into municipios (Nombre,IdDepartamento) values('Quelepa',12)
insert into municipios (Nombre,IdDepartamento) values('San Antonio del Mosco',12)
insert into municipios (Nombre,IdDepartamento) values('San Gerardo',12)
insert into municipios (Nombre,IdDepartamento) values('San Jorge',12)
insert into municipios (Nombre,IdDepartamento) values('San Luis de la Reina',12)
insert into municipios (Nombre,IdDepartamento) values('San Miguel',12)
insert into municipios (Nombre,IdDepartamento) values('San Rafael Oriente',12)
insert into municipios (Nombre,IdDepartamento) values('Sesori',12)
insert into municipios (Nombre,IdDepartamento) values('Uluazapa',12)
--------------------------------------------------------------
---------------------------------------------------------------
insert into Departamentos (Nombre, IdPais) values ('Morazán',1);
insert into municipios (Nombre, IdDepartamento) values ('Arambala',13)
insert into municipios (Nombre, IdDepartamento) values ('Cacaopera',13)
insert into municipios (Nombre, IdDepartamento) values ('Chilanga',13)
insert into municipios (Nombre, IdDepartamento) values ('Corinto',13)
insert into municipios (Nombre, IdDepartamento) values ('Delicias de Concepción',13)
insert into municipios (Nombre, IdDepartamento) values ('El Divisadero',13)
insert into municipios (Nombre, IdDepartamento) values ('El Rosario',13)
insert into municipios (Nombre, IdDepartamento) values ('Gualococti',13)
insert into municipios (Nombre, IdDepartamento) values ('Guatajiagua',13)
insert into municipios (Nombre, IdDepartamento) values ('Joateca',13)
insert into municipios (Nombre, IdDepartamento) values ('Jocoaitique',13)
insert into municipios (Nombre, IdDepartamento) values ('Jocoro',13)
insert into municipios (Nombre, IdDepartamento) values ('Lolotiquillo',13)
insert into municipios (Nombre, IdDepartamento) values ('Meanguera',13)
insert into municipios (Nombre, IdDepartamento) values ('Osicala',13)
insert into municipios (Nombre, IdDepartamento) values ('Perquín',13)
insert into municipios (Nombre, IdDepartamento) values ('San Carlos',13)
insert into municipios (Nombre, IdDepartamento) values ('San Fernando',13)
insert into municipios (Nombre, IdDepartamento) values ('San Francisco Gotera',13)
insert into municipios (Nombre, IdDepartamento) values ('San Isidro',13)
insert into municipios (Nombre, IdDepartamento) values ('San Simón',13)
insert into municipios (Nombre, IdDepartamento) values ('Sensembra',13)
insert into municipios (Nombre, IdDepartamento) values ('Sociedad',13)
insert into municipios (Nombre, IdDepartamento) values ('Torola',13)
insert into municipios (Nombre, IdDepartamento) values ('Yamabal',13)
insert into municipios (Nombre, IdDepartamento) values ('Yoloaiquín',13)
--------------------------------------------------------------
---------------------------------------------------------------
insert into Departamentos (Nombre, IdPais) values ('La Unión',1);
insert into municipios (Nombre, IdDepartamento) values('Anamorós',14)
insert into municipios (Nombre, IdDepartamento) values('Bolivar',14)
insert into municipios (Nombre, IdDepartamento) values('Concepción de Oriente',14)
insert into municipios (Nombre, IdDepartamento) values('Conchagua',14)
insert into municipios (Nombre, IdDepartamento) values('El Carmen',14)
insert into municipios (Nombre, IdDepartamento) values('El Sauce',14)
insert into municipios (Nombre, IdDepartamento) values('Intipucá',14)
insert into municipios (Nombre, IdDepartamento) values('La Unión',14)
insert into municipios (Nombre, IdDepartamento) values('Lislique',14)
insert into municipios (Nombre, IdDepartamento) values('Meanguera del Golfo',14)
insert into municipios (Nombre, IdDepartamento) values('Nueva Esparta',14)
insert into municipios (Nombre, IdDepartamento) values('Pasaquina',14)
insert into municipios (Nombre, IdDepartamento) values('Polorós',14)
insert into municipios (Nombre, IdDepartamento) values('San Alejo',14)
insert into municipios (Nombre, IdDepartamento) values('San José',14)
insert into municipios (Nombre, IdDepartamento) values('Santa Rosa de Lima',14)
insert into municipios (Nombre, IdDepartamento) values('Yayantique',14)
insert into municipios (Nombre, IdDepartamento) values('Yucuaiquín',14)


-------
---Roles

insert into Roles (Nombre) values ('Admin')
insert into Roles (Nombre) values ('Compras')
insert into Roles (Nombre) values ('Tesoreria')

insert into Usuarios (Direccion,DUI, Email, Habilitado, HashPassword,IdRole,NIT,Nombre,Usuario) values
('asdsd','asdasddasd','sadsad',1,convert(varbinary,'Declicforever'),1,'ASASAS','admin','admin')


insert into PlanPago(Nombre)values('Semanal');
insert into PlanPago(Nombre)values('Quincenal');
insert into PlanPago(Nombre)values('Mensual');
insert into PlanPago(Nombre)values('Trimestral');
go
create procedure sp_obtenerDocumentos 
as
Begin
		select d.Id, d.NumeroDocumento, prvdor.Nombre, '$' + CONVERT(nchar, d.ValorTotal) as 'Valor total', '$'+ convert(Nvarchar,(select sum(p3.Monto) from Pagos p3 where p3.IdDocumento = d.Id)) as 'Monto cancelado',
		'$' + CONVERT(Nvarchar, d.ValorTotal -
		case when (select sum(p4.Monto) from Pagos p4 ) is null then
		0
		else  (select sum(p4.Monto) from Pagos p4 )
		end)
		as 'Valor actual'
		from Documento d 
		inner join Proveedor prvdor on prvdor.Id = d.IdProveedor 
		where d.CantidadPagos >= (select COUNT (*) from Pagos p where p.IdDocumento = d.Id)
		and (d.ValorTotal > (select sum(p1.Monto) from Pagos p1 where p1.IdDocumento = d.Id) or (select sum(p2.Monto) from Pagos p2 where p2.IdDocumento = d.Id) is null)

end


-- Reportes
create procedure ReporteDocumentos
as
begin 
	--Select * from documento
Select NumeroDocumento as 'N# Documento', 
 case 
	when AplicaIVA = 1
	then 'Si'
	when AplicaIVA = 0
	then 
	'No'
	end 
	as 'Incluye IVA',

	ValorTotal as 'Valor documento',
	(
	
	select  convert(Nvarchar,(select sum(p3.Monto) from Pagos p3 where p3.IdDocumento = d.Id)) as 'Monto cancelado'
		
		from Documento d 
		inner join Proveedor prvdor on prvdor.Id = d.IdProveedor 
		where 
	
		 d.Id = Documento.Id

	) as 'Total Pagado', 
	FechaEmision as 'Fecha de emision',
	Concepto, 
	Proveedor.Nombre,
	Paises.Nombre as 'Pais',
	Departamentos.Nombre as 'Departamento',
	Municipios.Nombre as 'Municipio'
from Documento 
inner join Proveedor on Documento.IdProveedor = Proveedor.Id
inner join Paises on Proveedor.IdPais = Paises.Id
inner join Departamentos on Departamentos.Id = Proveedor.IdDepartamento
inner join Municipios on Municipios.Id = Proveedor.IdMunicipio;

end 