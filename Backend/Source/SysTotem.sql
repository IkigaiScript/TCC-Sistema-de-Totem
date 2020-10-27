create database tcdb;
use tcdb;

CREATE TABLE tb_filme (
	id_filme			INT PRIMARY KEY AUTO_INCREMENT,
    nm_filme			VARCHAR(100) UNIQUE,
    ds_genero			VARCHAR(255),
    ds_sinopse			VARCHAR(255),
    ds_imagem           VARCHAR(255),
    nr_classficacao     INT,
	nr_duracao			INT,
    bt_breve 			BOOL,
    bt_estreia			BOOL
);

CREATE TABLE tb_ator (
	id_ator				INT PRIMARY KEY AUTO_INCREMENT,
    id_filme   			INT,
    nm_ator 			VARCHAR(100),
    dt_nascimento		DATETIME,
    FOREIGN KEY (id_filme) REFERENCES tb_filme (id_filme) ON DELETE CASCADE
);
   
CREATE TABLE tb_diretor (
	id_diretor			INT PRIMARY KEY AUTO_INCREMENT,
    id_filme   			INT,
    nm_diretor 			VARCHAR(100),
    dt_nascimento		DATETIME,
    FOREIGN KEY (id_filme) REFERENCES tb_filme (id_filme) ON DELETE CASCADE
);
   
CREATE TABLE tb_trailer (
	id_trailer			INT PRIMARY KEY AUTO_INCREMENT,
    id_filme   			INT,
    nm_trailer 			VARCHAR(100),
    nr_duracao			INT,
    bt_dublado			BOOL,
    FOREIGN KEY (id_filme) REFERENCES tb_filme (id_filme) ON DELETE CASCADE
);

CREATE TABLE tb_cupom_desconto (
	id_cupom_desconto	INT PRIMARY KEY AUTO_INCREMENT,
    nm_cupom      		VARCHAR(100),
    ds_codigo			VARCHAR(4) UNIQUE,
	vl_desconto			DECIMAL(10,2),
    vl_min_gasto		DECIMAL(10,2)
);

CREATE TABLE tb_login (
	id_login			INT PRIMARY KEY AUTO_INCREMENT,
	ds_email			VARCHAR(255),
    ds_senha			VARCHAR(255)
);

CREATE TABLE tb_sessao (
	id_sessao			INT PRIMARY KEY AUTO_INCREMENT,
    id_filme   			INT,
    ds_tipo_sala 		VARCHAR(255),
    nr_sala  			INT,
    vl_ingresso 		DECIMAL(10,2),
    dt_horario    		DATETIME,
    FOREIGN KEY (id_filme) REFERENCES tb_filme (id_filme) ON DELETE CASCADE
);

CREATE TABLE tb_pedido (
	id_pedido				INT PRIMARY KEY AUTO_INCREMENT,
    id_cupom_desconto   	INT,
    id_login   				INT,
    nm_titular				VARCHAR(100),
    ds_forma_pagamento		VARCHAR(255),
    ds_status				VARCHAR(255),
    vl_total				DECIMAL(10,2),
    vl_troco				DECIMAL(10,2),
    FOREIGN KEY (id_cupom_desconto) REFERENCES tb_cupom_desconto (id_cupom_desconto) ON DELETE CASCADE,
    FOREIGN KEY (id_login) 	REFERENCES tb_login (id_login) ON DELETE CASCADE
);
   
CREATE TABLE tb_ingresso (
	id_ingresso			INT PRIMARY KEY AUTO_INCREMENT,
    id_pedido   		INT,
    id_sessao   		INT,
    ds_fileira			VARCHAR(1),
    nr_poltrona		 	INT,
    bt_meia_entrada		BOOL,
    FOREIGN KEY (id_pedido) REFERENCES tb_pedido (id_pedido) ON DELETE CASCADE,
    FOREIGN KEY (id_sessao) REFERENCES tb_sessao (id_sessao) ON DELETE CASCADE
); 
      
CREATE TABLE tb_cliente (
	id_cliente				INT PRIMARY KEY AUTO_INCREMENT,
    id_login   				INT,
    nm_cliente   			VARCHAR(100),
    ds_cpf					VARCHAR(14),
    ds_cep					VARCHAR(9),
    ds_rg					VARCHAR(12),
    ds_celular    			VARCHAR(14),
    bt_condicao_especial	BOOL,
    bt_vip					BOOL,
    FOREIGN KEY (id_login) REFERENCES tb_login (id_login) ON DELETE CASCADE
);
    
CREATE TABLE tb_snack_bar (
	id_snack_bar		INT PRIMARY KEY AUTO_INCREMENT,
    nm_produto			VARCHAR(100),
    ds_tipo_produto		VARCHAR(255),
    ds_marca			VARCHAR(255),
    ds_sabor           	VARCHAR(255),
    ds_peso          	VARCHAR(255),
    ds_imagem           VARCHAR(255),
    nr_qtd_estoque     	INT,
	vl_preco			DECIMAL(10,2)
);   

CREATE TABLE tb_pedido_snack_bar (
	id_pedido_snack_bar		INT PRIMARY KEY AUTO_INCREMENT,
    id_pedido   			INT,
    id_snack_bar   			INT,
    nr_qtd_snack_bar 		INT,
    FOREIGN KEY (id_snack_bar) REFERENCES tb_snack_bar (id_snack_bar) ON DELETE CASCADE,
    FOREIGN KEY (id_pedido) REFERENCES tb_pedido (id_pedido) ON DELETE CASCADE
);
   
CREATE TABLE tb_combo (
	id_combo			INT PRIMARY KEY AUTO_INCREMENT,
    nm_combo 			VARCHAR(100),
    ds_first_item 		VARCHAR(255),
    ds_secondary_item 	VARCHAR(255),
    ds_third_item 		VARCHAR(255),
    vl_preco 			DECIMAL(10,2),
    ds_imagem 			VARCHAR(255)
);

CREATE TABLE tb_pedido_combo (
	id_pedido_combo		INT PRIMARY KEY AUTO_INCREMENT,
    id_pedido   		INT,
    id_combo   			INT,
    nr_qtd_combo		INT,
    FOREIGN KEY (id_pedido) REFERENCES tb_pedido (id_pedido) ON DELETE CASCADE,
    FOREIGN KEY (id_combo)  REFERENCES tb_combo (id_combo) ON DELETE CASCADE
);
   
CREATE TABLE tb_nota_fiscal (
    id_nota_fisical			INT PRIMARY KEY AUTO_INCREMENT,
    id_pedido   			INT,
    ds_email 				VARCHAR(255),
    ds_cpf					VARCHAR(255),
    FOREIGN KEY (id_pedido) REFERENCES tb_pedido (id_pedido) ON DELETE CASCADE
);
   
CREATE TABLE tb_cartao (
    id_cartao				INT PRIMARY KEY AUTO_INCREMENT,
    id_pedido   			INT,
	nr_cartao				INT,
    vl_gasto				DECIMAL(10,2),
    FOREIGN KEY (id_pedido) REFERENCES tb_pedido (id_pedido) ON DELETE CASCADE
);

show tables;

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(1, 2, '3D', '2020-10-10-10-10-10', 27.00);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(2, 3, 'XD', '2020-10-17-21-50', 12.50);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(3, 4, 'XD', '2020-10-19-15-00', 24.50);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(4, 1, 'XD', '2020-10-18-11-50', 27.00);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(5, 5, 'XD', '2020-10-18-17-20', 22.50);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(6, 3, 'XD', '2020-10-18-18-30', 20.00);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(7, 2, '3D', '2020-10-18-00-00', 30.00);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(8, 5, 'XD', '2020-10-18-15-30', 23.70);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(9, 3, 'XD', '2020-10-19-16-40', 12.50);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(10, 1, '3D', '2020-10-19-11-30', 19.00);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(11, 4, 'XD', '2020-10-18-21-55', 21.50);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(12, 2, '3D', '2020-10-19-13-45', 27.00);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(13, 3, 'XD', '2020-10-19-18-50', 22.50);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(14, 1, '3D', '2020-10-19-00-00', 30.00);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(15, 5, 'XD', '2020-10-20-19-20', 12.50);

insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (1,'Will Smith','1968-09-25');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (2,'Bred pitt','1963-12-18');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (3,'Tom Hanks','1956-07-9');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (4,'Leonardo DiCprio','1974-11-11');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (5,'Harrison Ford','1942-07-13');

insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (6,'Johnny Depp','1963-06-09');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (7,'Julia Roberts','1967-10-28');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (8,'Robert Pattinso','1986-05-13');

insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (9,'Tom Cruise','1962-07-12');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (10,'Jim Carrey','1962-01-17');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (11,'Natalie Portman','1981-06-09');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (12,'Matt Damon','1970-10-08');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (13,'Sylvester Stallone','1946-06-06');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (14,'Nicolas Cage','1964-01-07');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (15,'Robert De Niro','1943-08-17');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (1,'Quentin Tarantino','1963-03-27');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (2,'Quentin Tarantino','1963-03-27');
    
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (3,'Quentin Tarantino','1963-03-27');
    
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (4,'Quentin Tarantino','1963-03-27');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (5,'Quentin Tarantino','1963-03-27');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (6,'Martin Scorsese','1942-11-17');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (7,'Martin Scorsese','1942-11-17');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (8,'Martin Scorsese','1942-11-17');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (9,'Martin Scorsese','1942-11-17');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (10,'Martin Scorsese','1942-11-17');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (11,'Woody Allen','1935-12-01');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (12,'Woody Allen','1935-12-01');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (13,'Woody Allen','1935-12-01');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (14,'Woody Allen','1935-12-01');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (15,'Woody Allen','1935-12-01');

insert into tb_pedido (id_login) values (1);

insert into tb_pedido (id_login) values (2);

-- insert into tb_pedido (id_login) values (3);

-- insert into tb_pedido (id_login) values (4);

-- insert into tb_pedido (id_login) values (5);

-- insert into tb_pedido_snack_bar (id_pedido,id_snack_bar,nr_qtd_snack_bar) values (1,2,3);

-- insert into tb_pedido_snack_bar(id_pedido,id_snack_bar,nr_qtd_snack_bar) values (1,3,4);

-- insert into tb_pedido_snack_bar (id_pedido,id_snack_bar,nr_qtd_snack_bar) values (1,5,2);

-- insert into tb_pedido_snack_bar (id_pedido,id_snack_bar,nr_qtd_snack_bar) values (3,2,3);

-- insert into tb_pedido_snack_bar(id_pedido,id_snack_bar,nr_qtd_snack_bar) values (3,3,4);

-- insert into tb_pedido_snack_bar (id_pedido,id_snack_bar,nr_qtd_snack_bar) values (3,5,2);

-- insert into tb_pedido_snack_bar (id_pedido,id_snack_bar,nr_qtd_snack_bar) values (4,2,3);

-- insert into tb_pedido_snack_bar(id_pedido,id_snack_bar,nr_qtd_snack_bar) values (4,3,4);

-- insert into tb_pedido_snack_bar (id_pedido,id_snack_bar,nr_qtd_snack_bar) values (4,5,2);

-- insert into tb_pedido_snack_bar(id_pedido,id_snack_bar,nr_qtd_snack_bar) values (5,3,4);

-- insert into tb_pedido_snack_bar (id_pedido,id_snack_bar,nr_qtd_snack_bar) values (5,5,9);

select * from tb_cupom_desconto;
select * from tb_login;
select * from tb_cartao;
select * from tb_pedido_snack_bar;
select * from tb_pedido;
select * from tb_snack_bar;