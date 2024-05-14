use pension

create table raza
	(cRaza int primary key,
	nombre varchar(50))

create table dueno
	(cDueno int primary key,
	nombre varchar(150),
	tel varchar(10),
	direccion varchar(250),
	correo varchar(50),
	password varchar(50))

create table perro 
	(cPerro int primary key,
	nombre varchar(50),
	edad int,
	cRaza int references raza,
	cDueno int references dueno)

create table estancia
	(cEstancia int primary key,
	fechaIni datetime,
	fechaFin datetime,
	cPerro int references perro)

create table administracion
	(cAdministracion int primary key,
	nombre varchar(150),
	correo varchar(150),
	password varchar(150))

insert into dueno values (1,'Jorge','55345678','Calle 1 No. 1','jorge@gmail.com','jorgito')
insert into dueno values (2,'Vanesa','55345676','Calle 2 No. 2','vanesa@gmail.com','vane')
insert into dueno values (3,'Lorena','55345675','Calle 3 No. 3','lorena@gmail.com','lore')
insert into dueno values (4,'Manuel','55345674','Calle 4 No. 4','manuel@gmail.com','mani')
insert into dueno values (5,'Martin','55749632','Calle 5 No. 5','martin@gmail.com','morty')
insert into dueno values (6,'Alumno','88888888','Sin calle','sincorreo@sincorreo.com','sinpassword')

insert into raza values (1,'Labrador')
insert into raza values (2,'Golden retriever')
insert into raza values (3,'Boxer')
insert into raza values (4,'Husky')
insert into raza values (5,'Pastor aleman')

insert into perro values(100,'Bobi',3,5,1)
insert into perro values(200,'Lala',3,4,2)
insert into perro values(300,'Magia',4,3,3)
insert into perro values(400,'Freddy',5,2,4)
insert into perro values(500,'Cora',6,1,2)
insert into perro values(600,'Ross',7,5,1)
insert into perro values(700,'Patan',2,2,5)
insert into perro values(800,'Frida',4,4,5)

insert into estancia values(1000,'2017-05-01','2017-05-10',100)
insert into estancia values(2000,'2017-04-01','2017-04-10',200)
insert into estancia values(3000,'2017-03-01','2017-03-10',300)
insert into estancia values(4000,'2017-02-01','2017-02-10',400)
insert into estancia values(5000,'2017-01-01','2017-01-10',100)
insert into estancia values(6000,'2018-06-07','2018-07-07',300)
insert into estancia values(7000,'2019-11-11','2019-12-12',200)
insert into estancia values(8000,'2020-01-01','2020-02-02',600)
insert into estancia values(9000,'2022-02-02','2022-03-03',800)

insert into administracion values(1,'Fernando','fer@hotmail.com','fer')
