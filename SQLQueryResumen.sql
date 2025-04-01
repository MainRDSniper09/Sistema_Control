
use DBTienda

create table Medida(
IdMedida int primary key identity(1,1),
Nombre varchar(50) not null,
Abreviatura varchar(4) not null,--und - kg
Equivalente varchar(4) not null,--und - g
Valor int not null --1, 1000
)

go

create table Categoria(
IdCategoria int primary key identity(1,1),
Nombre varchar(50) not null,
IdMedida int references Medida(IdMedida),
Activo bit default 1
)
go

create table Producto(
IdProducto int primary key identity(1,1),
IdCategoria int references Categoria(IdCategoria),
Codigo varchar(50) not null,
Descripcion varchar(150) not null,
PrecioCompra decimal(10,2) not null,
PrecioVenta decimal(10,2) not null,
Cantidad int not null,
Activo bit default 1
)
go

create table Rol(
IdRol int primary key identity(1,1),
Nombre varchar(50) not null,
)
go
create table Usuario(
IdUsuario  int primary key identity(1,1),
IdRol int references Rol(IdRol),
NombreCompleto varchar(50) not null,
Correo varchar(50) not null,
NombreUsuario varchar(50) not null unique,
Clave varchar(100) not null,
ResetearClave bit default 1,
Activo bit default 1
)
go
create table CorrelativoVenta(
Serie varchar(3) not null, --001
Numero int not null, --1,2,3 --- 000001
Activo bit default 1,
primary key(Serie,Numero)
)
go
create table Venta(
IdVenta int primary key identity(1,1),
NumeroVenta varchar(10), --001-000005
IdUsuarioRegistro int references Usuario(IdUsuario),
NombreCliente varchar(60),
PrecioTotal decimal(10,2) not null,
PagoCon decimal(10,2),
Cambio decimal(10,2),
FechaRegistro datetime default getdate(),
Activo bit default 1
)

go
create table DetalleVenta(
IdDetalleVenta int primary key identity(1,1),
IdVenta int references Venta(IdVenta),
IdProducto int references Producto(IdProducto),
Cantidad int,
PrecioVenta decimal(10,2),
PrecioTotal decimal(10,2)
)
go
create table Negocio(
IdNegocio int primary key identity(1,1),
RazonSocial varchar(100),
RUT varchar(20),
Direccion varchar(100),
Celular varchar(10),
Correo varchar(30),
SimboloMoneda varchar(5),
NombreLogo varchar(100),
UrlLogo varchar(200)
)

go

create table Menu(
IdMenu int primary key identity(1,1),
NombreMenu varchar(50) not null,
IdMenuPadre int default 0 not null
)
go
create table MenuRol(
IdMenuRol int primary key identity(1,1),
IdMenu int references Menu(IdMenu),
IdRol int references Rol(IdRol),
Activo bit default 1
)


select * from Medida

select * from Categoria

insert into Categoria(Nombre,IdMedida)
values('Accesorios',1)


insert into Medida(Nombre,Abreviatura,Equivalente,Valor) 
values
('Unidad','ud','ud',1),
('Kilogramo','kg','g',1000)


--
create procedure sp_listaMedida
as
begin
	select IdMedida,Nombre,Abreviatura,Equivalente,Valor from Medida
end


create procedure sp_listaCategoria
(
@Buscar varchar(50) = ''
)
as
begin
	select
	c.IdCategoria,
	c.Nombre,
	m.IdMedida,
	m.Nombre[NombreMedida],
	c.Activo
	from
	Categoria c
	inner join Medida m on m.IdMedida = c.IdMedida
	where concat(c.Nombre,m.Nombre,iif(c.activo =1 ,'SI','NO')) 
	like '%' + @Buscar + '%'
end



CREATE PROCEDURE sp_crearCategoria(
@Nombre varchar(50),
@IdMedida int,
@MsjError varchar(100) output
)
as
begin
	set @MsjError = ''

	if(exists(select * from Categoria where Nombre = @Nombre))
	begin
		set @MsjError = 'El nombre de categoria ya existe'
		return
	end

	insert into Categoria(Nombre,IdMedida)
	values(@Nombre,@IdMedida)

end




CREATE PROCEDURE sp_editarCategoria(
@IdCategoria int,
@Nombre varchar(50),
@IdMedida int,
@Activo int,
@MsjError varchar(100) output
)
as
begin
	set @MsjError = ''

	if(exists(select * from Categoria where Nombre = @Nombre
	and IdCategoria != @IdCategoria
	))
	begin
		set @MsjError = 'El nombre de categoria ya existe'
		return
	end

	update Categoria set
	Nombre = @Nombre,
	IdMedida = @IdMedida,
	Activo = @Activo
	where IdCategoria = @IdCategoria

end



 select * from Negocio

 insert into Negocio(RazonSocial,RUT,Direccion,Celular,Correo,SimboloMoneda,NombreLogo,UrlLogo)
 values ('barretosanchez','100100100','av.esperanza 123','900800700','ce@gmail.com','S/.','','')


 CREATE PROCEDURE sp_obtenerNegocio
 as
 begin
	 select RazonSocial,RUC,Direccion,Celular,Correo,SimboloMoneda,NombreLogo,UrlLogo
	 from Negocio where IdNegocio = 1
 end

 exec sp_obtenerNegocio


 create procedure sp_editarNegocio
 (
@RazonSocial varchar(100),
@RUT varchar(20),
@Direccion varchar(100),
@Celular varchar(10),
@Correo varchar(30),
@SimboloMoneda varchar(5),
@NombreLogo varchar(100),
@UrlLogo varchar(200)
 )
 as
 begin
	update Negocio set
	RazonSocial = @RazonSocial,
	RUT = @RUT,
	Direccion = @Direccion,
	Celular = @Celular,
	Correo = @Correo,
	SimboloMoneda = @SimboloMoneda,
	NombreLogo = @NombreLogo,
	UrlLogo = @UrlLogo
	where IdNegocio = 1
 end


 select * from Producto



  
create procedure sp_listaProducto
(  
@Buscar varchar(50) = ''  
)  
as  
begin  
 
 select
 p.IdProducto,
 c.IdCategoria,
 c.Nombre[NombreCategoria],
 p.Codigo,
 p.Descripcion,
 p.PrecioCompra,
 p.PrecioVenta,
 p.Cantidad,
 p.Activo
 from Producto p
 inner join Categoria c on c.IdCategoria = p.IdCategoria
 where 
 CONCAT(p.Codigo,p.Descripcion,c.Nombre,iif(p.activo =1,'SI','NO'))
 like '%' + @Buscar + '%'  
end  



  
CREATE PROCEDURE sp_crearProducto(  
@IdCategoria int,
@Codigo varchar(50),
@Descripcion varchar(150),
@PrecioCompra decimal(10,2),
@PrecioVenta decimal(10,2),
@Cantidad int,
@MsjError varchar(100) output  
)  
as  
begin  
 set @MsjError = ''  
  
 if(exists(select * from Producto where Descripcion = @Descripcion))  
 begin  
  set @MsjError = 'La descripcion del producto ya existe'  
  return  
 end  
  
 insert into Producto(IdCategoria,Codigo,Descripcion,PrecioCompra,PrecioVenta,Cantidad)  
 values(@IdCategoria,@Codigo,@Descripcion,@PrecioCompra,@PrecioVenta,@Cantidad)  
  
end


  
  
CREATE PROCEDURE sp_editarProducto(  
@IdProducto int,  
@IdCategoria int,
@Codigo varchar(50),
@Descripcion varchar(150),
@PrecioCompra decimal(10,2),
@PrecioVenta decimal(10,2),
@Cantidad int,  
@Activo int,  
@MsjError varchar(100) output  
)  
as  
begin  
 set @MsjError = ''  
  
 if(exists(select * from Producto where Descripcion = @Descripcion  
 and IdProducto != @IdProducto  
 ))  
 begin  
  set @MsjError = 'La descripcion del producto ya existe'  
  return  
 end  
  
 update Producto set  
 IdCategoria = @IdCategoria,
 Codigo= @Codigo,
 Descripcion = @Descripcion,
 PrecioCompra = @PrecioCompra,
 PrecioVenta = @PrecioVenta,
 Cantidad = @Cantidad,
 Activo = @Activo  
 where IdProducto = @IdProducto  
  
end


select * from rol
select * from Usuario

insert into Rol(Nombre) values
('Administrador'),
('Ventas')


insert into Usuario(IdRol,NombreCompleto,Correo,NombreUsuario,Clave,ResetearClave) values
(1,'Jhon Jairo Barreto','barretosanchez6@gmail.com','jbarreto',
'13a6d713e45222bdbde557be1d2cad57a062ed24ac93361362c8692bcb84a0d0',0)


--procedimientos rol

create procedure sp_listaRol
as
begin
	select IdRol,Nombre from Rol 
end



--procedimientos usuario



  
create procedure sp_listaUsuario
(  
@Buscar varchar(50) = ''  
)  
as  
begin  
 
 select
 u.IdUsuario,
 r.IdRol,
 r.Nombre[NombreRol],
 u.NombreCompleto,
 u.Correo,
 u.NombreUsuario,
 u.Activo
 from 
 Usuario u
 inner join Rol r on r.IdRol = u.IdRol
 where concat(r.Nombre,u.NombreCompleto,u.Correo,u.NombreUsuario,iif(u.activo =1 ,'SI','NO'))   
 like '%' + @Buscar + '%'  
end  

  
CREATE PROCEDURE sp_crearUsuario(  
@IdRol int,
@NombreCompleto varchar(50),
@Correo varchar(50),
@NombreUsuario varchar(50),
@Clave varchar(100),
@MsjError varchar(100) output  
)  
as  
begin  
 set @MsjError = ''  
  
 if(exists(select * from Usuario where Correo = @Correo))  
 begin  
  set @MsjError = 'El correo ya existe'  
  return  
 end  

  if(exists(select * from Usuario where NombreUsuario = @NombreUsuario))  
 begin  
  set @MsjError = 'El nombre de usuario ya existe'  
  return  
 end  
  
 insert into Usuario(IdRol,NombreCompleto,Correo,NombreUsuario,Clave)  
 values(@IdRol,@NombreCompleto,@Correo,@NombreUsuario,@Clave)  
  
end


CREATE PROCEDURE sp_editarUsuario(
@IdUsuario int,
@IdRol int,
@NombreCompleto varchar(50),
@Correo varchar(50),
@NombreUsuario varchar(50),
@Activo int,
@MsjError varchar(100) output  
)  
as  
begin  
 set @MsjError = ''  
  
 if(exists(select * from Usuario where Correo = @Correo
 and IdUsuario != @IdUsuario
 ))  
 begin  
  set @MsjError = 'El correo ya existe'  
  return  
 end  

  if(exists(select * from Usuario where NombreUsuario = @NombreUsuario
  and IdUsuario != @IdUsuario
  ))  
 begin  
  set @MsjError = 'El nombre de usuario ya existe'  
  return  
 end  
  
  update Usuario set
  IdRol = @IdRol,
  NombreCompleto = @NombreCompleto,
  Correo = @Correo,
  NombreUsuario = @NombreUsuario,
  Activo = @Activo
  where IdUsuario = @IdUsuario

end

select * from CorrelativoVenta

insert into CorrelativoVenta(Serie,Numero,Activo)
values
('001',0,1),
('002',0,0)


create procedure sp_obtenerProducto
(
@Codigo varchar(50)
)
as
begin
	
	select
	p.IdProducto,
	c.Nombre[NombreCategoria],
	m.Equivalente,
	m.Valor,
	p.Codigo,
	p.Descripcion,
	p.PrecioVenta,
	p.Cantidad
	from Producto p
	inner join Categoria c on c.IdCategoria = p.IdCategoria
	inner join Medida m on m.IdMedida = c.IdMedida
	where
	p.Cantidad > 0 and
	p.Activo = 1 and
	p.Codigo = @Codigo

end


create procedure sp_registrarVenta(
@VentaXml xml,
@NumeroVenta varchar(10) output
)
as
begin

	declare @idVenta int

	declare @venta table (
	IdUsuarioRegistro int,
	NombreCliente varchar(60),
	PrecioTotal decimal(10,2),
	PagoCon decimal(10,2),
	Cambio decimal(10,2)
	)

	declare @detalleventa table (
	IdProducto int,
	Cantidad int,
	PrecioVenta decimal(10,2),
	PrecioTotal decimal(10,2)
	)

	begin try

		begin transaction

			insert into @venta(IdUsuarioRegistro,NombreCliente,PrecioTotal,PagoCon,Cambio)
			select
			x.value('IdUsuarioRegistro[1]','INT') as IdUsuarioRegistro,
			x.value('NombreCliente[1]','varchar(60)') as NombreCliente,
			x.value('PrecioTotal[1]', 'decimal(10,2)') as PrecioTotal,
			x.value('PagoCon[1]', 'decimal(10,2)') as PagoCon,
			x.value('Cambio[1]', 'decimal(10,2)') as Cambio
			from
			@VentaXml.nodes('Venta') as T(x)

			insert into @detalleventa(IdProducto,Cantidad,PrecioVenta,PrecioTotal)
			select
			x.value('IdProducto[1]', 'int') as IdProducto,
			x.value('Cantidad[1]', 'int') as Cantidad,
			x.value('PrecioVenta[1]', 'decimal(10,2)') as PrecioVenta,
			x.value('PrecioTotal[1]', 'decimal(10,2)') as PrecioTotal
			from
			@VentaXml.nodes('Venta/DetalleVenta/Item') as T(x)

			update CorrelativoVenta set
			Numero = Numero + 1,
			@NumeroVenta = Concat(Serie,'-', right('000000' + cast(Numero + 1 as varchar),6))
			where Activo = 1

			insert into Venta(NumeroVenta,IdUsuarioRegistro,NombreCliente,PrecioTotal,PagoCon,Cambio)
			select @NumeroVenta,IdUsuarioRegistro,NombreCliente,PrecioTotal,PagoCon,Cambio from @venta

			set @idVenta = scope_identity()

			insert into DetalleVenta(IdVenta,IdProducto,Cantidad,PrecioVenta,PrecioTotal)
			select @idVenta, IdProducto,Cantidad,PrecioVenta,PrecioTotal from @detalleventa

			update p set 
			p.Cantidad = p.cantidad - dv.cantidad
			from Producto p 
			inner join @detalleventa dv on dv.IdProducto = p.IdProducto


		commit transaction
	end try
	begin catch
		rollback transaction
		set @NumeroVenta = ''
	end catch
end

create procedure sp_ObtenerVenta(
@NumeroVenta varchar(10)
)
as
begin
	select 
	v.IdVenta,
	v.NumeroVenta,
	u.NombreUsuario,
	v.NombreCliente,
	v.PrecioTotal,
	v.PagoCon,
	v.Cambio,
	convert(char(10), v.FechaRegistro,103)[FechaRegistro]
	from Venta v
	inner join Usuario u on u.IdUsuario = v.IdUsuarioRegistro
	where v.NumeroVenta = @NumeroVenta

end



create procedure sp_ObtenerDetalleVenta(
@NumeroVenta varchar(10)
)
as
begin

	select 
	p.Descripcion,
	m.Abreviatura,
	m.Valor,
	dv.Cantidad,
	dv.PrecioVenta,
	dv.PrecioTotal
	from DetalleVenta dv
	inner join Venta v on v.IdVenta = dv.IdVenta
	inner join Producto p on p.IdProducto = dv.IdProducto
	inner join Categoria c on c.IdCategoria = p.IdCategoria
	inner join Medida m on m.IdMedida = c.IdMedida
	where v.NumeroVenta = @NumeroVenta
end


create procedure sp_listaVenta(
@FechaInicio varchar(10),
@FechaFin varchar(10),
@Buscar varchar(50) = ''
)as
begin
	set dateformat dmy
	
	select
	v.NumeroVenta,
	u.NombreUsuario,
	v.NombreCliente,
	v.PrecioTotal,
	v.PagoCon,
	v.Cambio,
	CONVERT(char(10),v.FechaRegistro,103)[FechaRegistro]
	from
	Venta v
	inner join Usuario u on u.IdUsuario = v.IdUsuarioRegistro
	where
	CONVERT(date,v.FechaRegistro) between CONVERT(date,@FechaInicio) and CONVERT(date,@FechaFin)
	and CONCAT(v.NumeroVenta,u.NombreUsuario,v.NombreCliente) like '%' + @Buscar + '%'

end

create procedure sp_reporteVenta(
@FechaInicio varchar(10),
@FechaFin varchar(10)
)
as
begin
	
	set dateformat dmy

	select
	v.NumeroVenta,
	u.NombreUsuario,
	convert(char(10),v.fechaRegistro,103)[FechaRegistro],
	p.Descripcion[Producto],
	p.PrecioCompra,
	dv.PrecioVenta,
	dv.Cantidad,
	dv.PrecioTotal
	from Venta v
	inner join Usuario u on u.IdUsuario = v.IdUsuarioRegistro
	inner join DetalleVenta dv on dv.IdVenta = v.IdVenta
	inner join Producto p on p.IdProducto = dv.IdProducto
	where
	CONVERT(date,v.fecharegistro) between convert(date,@FechaInicio) and convert(date,@FechaFin)
	
end


CREATE PROCEDURE sp_login(
    @NombreUsuario NVARCHAR(50),  
    @Clave NVARCHAR(100)
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        u.IdUsuario,
        u.NombreCompleto,
        r.IdRol,
        r.Nombre AS NombreRol,  
        u.Correo,
        u.NombreUsuario,
        u.ResetearClave,
        u.Activo
    FROM Usuario u
    INNER JOIN Rol r ON r.IdRol = u.IdRol
    WHERE u.NombreUsuario = @NombreUsuario 
      AND u.Clave = @Clave;  
END

--insertar los menus principales
insert into menu(NombreMenu) values
('ventas'),
('inventario'),
('reportes'),
('usuarios'),
('configuracion')

insert into menu(NombreMenu,IdMenuPadre) values
('nuevo',1),
('historial',1)

insert into menu(NombreMenu,IdMenuPadre) values
('productos',2),
('categorias',2)

insert into menu(NombreMenu,IdMenuPadre) values
('ventas',3)

--administrador
insert into MenuRol(IdMenu,IdRol) values
(1,1),
(2,1),
(3,1),
(4,1),
(5,1),
(6,1),
(7,1),
(8,1),
(9,1),
(10,1)



--ventas
insert into MenuRol(IdMenu,IdRol) values
(1,2),
(6,2),
(7,2)



create proc sp_obtenerMenus(
@IdRol int
)
as
begin
	select 
	m.NombreMenu,
	m.IdMenuPadre,
	mr.Activo
	from MenuRol mr
	inner join Menu m on m.IdMenu = mr.IdMenu
	where mr.IdRol = @IdRol
end

