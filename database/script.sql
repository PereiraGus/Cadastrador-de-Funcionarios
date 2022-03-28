create database db_lia;
use db_lia;

create table tb_liaUsuario
(
IdUsu int primary key auto_increment,
NomeUsu varchar(50) not null,
Cargo varchar (50) not null,
DtNasc date
);

insert into tb_liaUsuario(NomeUsu, Cargo, DtNasc)
values ('Mike Briam', 'Corredor', '1999/06/11'),
		('Filha da Mãe da Brenda', 'Revolucionária', '2004/07/13');
select * from tb_liaUsuario;

Delimiter ££
create procedure insereUsu(¬NomeUsu varchar(50), ¬Cargo varchar(50), ¬DataNasc date)
begin
insert into tb_liaUsuario (NomeUsu, Cargo, DtNasc)
values (NomeUsu, Cargo, DataNasc);
end; ££

call insereUsu('Sub Zero', 'Kriomante', '1980/11/23');

insert into tb_liaUsuario values (default,'Teste','Testador',CONVERT(DATETIME,'{2}', 103));

if exists
update tb_liaUsuario set NomeUsu =  'Back Street Boys', Cargo = 'Cringe', DtNasc = str_to_date('11/06/1980 00:00:00', '%d/%m/%Y %T') where IdUsu = 8;