create table users(
	id int identity primary key,
	email varchar(100) not null unique check (email like '%@%.%'),
	nome varchar(100) not null check(nome like '% %'),
	morada varchar(100) not null,
	nif varchar(9) not null check(nif like '_________'),
	password varchar(64) not null,
	sal int,
	estado int not null,
	perfil int not null check (perfil in ('0','1')),
	lnkRecuperar varchar(36),
	data_lnk date,
)

create table produtos(
	id int identity primary key,
	nome varchar(100) not null,
	data_aquisicao date not null default(getdate()),
	preco decimal(6,2) not null,
	tags varchar(500) not null,
	stock int not null default(0),
	estado int not null
)

create table vendas(
	nvenda int identity primary key,
	id_user int references users(id),
	id_produto int references produtos(id),
	data_venda date default(getdate()),
	data_devolve date,
)

create index iproduto_nome on produtos(nome)
create index iproduto_tags on produtos(tags)

drop table vendas
drop table produtos