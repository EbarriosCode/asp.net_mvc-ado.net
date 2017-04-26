-- procedimiento almacenado que trae los datos principales
create procedure getUsuarios
as
begin
	select U.idUsuario,U.nombre,U.apellido,U.fechaNacimiento,U.idRol,
		   R.idRol,R.nombreRol 
	from Usuarios U
	inner join Roles R on U.idRol = R.idRol
end
drop procedure getUsuarios

-- creacion de las tablas
create table Roles(
	idRol int identity not null primary key,
	nombreRol varchar(50)
);
go

insert into Roles values('Administrador'),('Usuario');
select * from Roles
go


create table Usuarios(
	idUsuario int identity primary key not null,
	nombre varchar(100),
	apellido varchar(100),
	fechaNacimiento datetime,
	idRol int,
	constraint fk_idRol foreign key(idRol) references Roles(idRol)
);
go

insert into Usuarios values('Eduardo','Barrios','1992-08-01',1),('Mario','Castillo','1988-12-11',2);
select * from Usuarios;

