use TiendaDAI012020

create table cliente(
	correo varchar(100) primary key,
	passwd varchar(50),
	nombre varchar(150))

create table categoria(
	cCategoria int primary key,
	nombre varchar(100))

create table producto(
	cProd int primary key,
	nombre varchar(100),
	precio real,
	cCategoria int references categoria)

create table venta(
	folio int primary key,
	fecha datetime,
	cantidad int)

create table cliProdVenta(
	correo varchar(100) references cliente,
	cProd int references producto,
	folio int references venta,
	primary key(folio,correo))
	
create table administrador(
	correo varchar(100) primary key,
	passwd varchar(50),
	nombre varchar(100))

--Datos
insert into cliente values('felipe@itam.mx','felipito','Felipe')
insert into cliente values('ana@itam.mx','anita','Ana Lidia')
insert into cliente values('fernando@itam.mx','nandito','Fernando')

insert into categoria values (1,'Bebidas')
insert into categoria values (2,'Comida')

insert into producto values (1,'Americano',30,1)
insert into producto values (2,'Capuccino',50,1)
insert into producto values (3,'Sandwich de jamón',50,2)
insert into producto values (4,'Panqué de elote',30,2)

insert into administrador values ('pedro@itam.mx','peter','Pedro')