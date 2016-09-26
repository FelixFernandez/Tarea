create table Personas(
PersonaId int primary key identity(1,1),
Nombre Varchar(30),
Sexo varchar(9)
);


create table PersonasTelefonos(
PersonaTelefonoId int primary key identity(1,1),
PersonaId int,
TipoTelefono varchar(15),
Telenofo varchar(15)
);