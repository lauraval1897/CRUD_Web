create table Libreria
(
	Id int identity not null primary key,
	Nombre_Libro varchar(20) not null,
	Autor varchar(50) not null,
	Año_Publicacion int not null,
	Cantidad int not null
);