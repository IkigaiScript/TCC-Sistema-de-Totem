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
    ds_codigo			VARCHAR(4),
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
    nr_poltona		 	INT,
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
   
CREATE TABLE tb_nota_fiscal(
    id_nota_fisical			INT PRIMARY KEY AUTO_INCREMENT,
    id_pedido   			INT,
    ds_email 				VARCHAR(255),
    ds_cpf					VARCHAR(255),
    FOREIGN KEY (id_pedido) REFERENCES tb_pedido (id_pedido) ON DELETE CASCADE
);
   
CREATE TABLE tb_cartao(
    id_cartao				INT PRIMARY KEY AUTO_INCREMENT,
    id_pedido   			INT,
	nr_cartao				INT,
    vl_gasto				DECIMAL(10,2),
    FOREIGN KEY (id_pedido) REFERENCES tb_pedido (id_pedido) ON DELETE CASCADE
);

show tables;

insert into tb_filme (nm_filme,ds_genero,ds_sinopse,ds_imagem,nr_classficacao,nr_duracao,bt_breve,bt_estreia) values ('Esquadrão 6','Ação','Lorem ipsum dolor sit amet,  ut varius turpis facilisis ultricies. Donec quis','paisagem.jpg',12,148,false,true);

insert into tb_filme (nm_filme,ds_genero,ds_sinopse,ds_imagem,nr_classficacao,nr_duracao,bt_breve,bt_estreia) values ('Homem aranha','Aventura','Lorem ipsum dolor sit','paisagem.jpg',14,167,false,false);

insert into tb_filme (nm_filme,ds_genero,ds_sinopse,ds_imagem,nr_classficacao,nr_duracao,bt_breve,bt_estreia) values ('Velozes e furiosos 9','Ação','Lorem ipsum dolor sit','paisagem.jpg',14,156,true,false);

insert into tb_filme (nm_filme,ds_genero,ds_sinopse,ds_imagem,nr_classficacao,nr_duracao,bt_breve,bt_estreia) values ('Cemiterio maldito','Terror','Lorem ipsum dolor sit','paisagem.jpg',16,128,false,true);

insert into tb_filme (nm_filme,ds_genero,ds_sinopse,ds_imagem,nr_classficacao,nr_duracao,bt_breve,bt_estreia) values ('O Albergue 3','Terro','Lorem ipsum dolor sit','paisagem.jpg',14,140,false,false);

insert into tb_filme (nm_filme,ds_genero,ds_sinopse,ds_imagem,nr_classficacao,nr_duracao,bt_breve,bt_estreia) values ('A babá: rainha da morte','Aventura','Lorem ipsum dolor sit','paisagem.jpg',16,143,false,false);

insert into tb_filme (nm_filme,ds_genero,ds_sinopse,ds_imagem,nr_classficacao,nr_duracao,bt_breve,bt_estreia) values ('Parker','Suspense','Lorem ipsum dolor sit','paisagem.jpg',14,181,false,true);

insert into tb_filme (nm_filme,ds_genero,ds_sinopse,ds_imagem,nr_classficacao,nr_duracao,bt_breve,bt_estreia) values ('Massacre da serra eletrica','Fantasia','Lorem ipsum dolor sit','paisagem.jpg',18,174,false,false);

insert into tb_filme (nm_filme,ds_genero,ds_sinopse,ds_imagem,nr_classficacao,nr_duracao,bt_breve,bt_estreia) values ('Deus do egito','Aventura','Lorem ipsum dolor sit','paisagem.jpg',12,126,false,false);

insert into tb_filme (nm_filme,ds_genero,ds_sinopse,ds_imagem,nr_classficacao,nr_duracao,bt_breve,bt_estreia) values ('Goosebumps 2: Monstros e Arrepios','Comedia','Lorem ipsum dolor sit','paisagem.jpg',10,103,true,false);

insert into tb_filme (nm_filme,ds_genero,ds_sinopse,ds_imagem,nr_classficacao,nr_duracao,bt_breve,bt_estreia) values ('Bird box','Ficçao cientifica','Lorem ipsum dolor sit','paisagem.jpg',16,124,false,true);

insert into tb_filme (nm_filme,ds_genero,ds_sinopse,ds_imagem,nr_classficacao,nr_duracao,bt_breve,bt_estreia) values ('O poço','Suspense','Lorem ipsum dolor sit','paisagem.jpg',14,134,false,true);

insert into tb_filme (nm_filme,ds_genero,ds_sinopse,ds_imagem,nr_classficacao,nr_duracao,bt_breve,bt_estreia) values ('Harry potter e a ordem da Fenix','Fantasia','Lorem ipsum dolor sit','paisagem.jpg',12,178,false,false);

insert into tb_filme (nm_filme,ds_genero,ds_sinopse,ds_imagem,nr_classficacao,nr_duracao,bt_breve,bt_estreia) values ('Hotel transilvania 2','Comedia','Lorem ipsum dolor sit','paisagem.jpg',0,99,false,true);

insert into tb_filme (nm_filme,ds_genero,ds_sinopse,ds_imagem,nr_classficacao,nr_duracao,bt_breve,bt_estreia) values ('Hotel transilvania','Comedia','Lorem ipsum dolor sit','paisagem.jpg',0,102,false,false);

insert into tb_login(ds_email, ds_senha) values('joaofarhat9@gmail.com', '12345678');

insert into tb_login(ds_email, ds_senha) values ('juninho123@gmail.com', '123321');

insert into tb_login(ds_email, ds_senha) values('eduardo47@hotmail.com', '56276587');

insert into tb_login(ds_email, ds_senha) values ('eduar_da89k@gmail.com', 'vintedoquatro2004');

insert into tb_login(ds_email, ds_senha) values ('jotinhatroios@yahoo.com', '1289347');

insert into tb_login(ds_email, ds_senha) values ('charizard28@hotmail.com', 'fireredmelhor');

insert into tb_login(ds_email, ds_senha) values ('antetegmon@gmail,com', 'digimonemelhor');

insert into tb_login(ds_email, ds_senha) values ('chornaina2@gmail.com','nomefeiodagota');

insert into tb_login(ds_email, ds_senha) values ('juliana298@hotmail.com', '7q89437');

insert into tb_login(ds_email, ds_senha) values ('yanzinhobrabo@outlook.com', '12089437');

insert into tb_login(ds_email, ds_senha) values ('4troios@yahoo.com', 'troiamente');

insert into tb_login(ds_email, ds_senha) values ('carlinhos32@hotmail.com', 'carlinhos29739');

insert into tb_login(ds_email, ds_senha) values ('coninho32@outlook.com', '78941273894');

insert into tb_login(ds_email, ds_senha) values ('thominhasbom@gmail.com', '2734687');

insert into tb_login(ds_email, ds_senha) values ('klebinho@gmail.com', '372846');

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

insert into tb_trailer(id_filme, nm_trailer,nr_duracao, bt_dublado) values(1, '', 03, true);

insert into tb_trailer(id_filme, nm_trailer,nr_duracao, bt_dublado) values(2, '' , 04, false);

insert into tb_trailer(id_filme, nm_trailer,nr_duracao, bt_dublado) values(3, '', 06, true);

insert into tb_trailer(id_filme, nm_trailer,nr_duracao, bt_dublado) values(4, '', 03, false);

insert into tb_trailer(id_filme, nm_trailer,nr_duracao, bt_dublado) values(5, '', 05, false);

insert into tb_trailer(id_filme, nm_trailer,nr_duracao, bt_dublado) values(6, '' , 04, true);

insert into tb_trailer(id_filme, nm_trailer,nr_duracao, bt_dublado) values(7, '', 06, false);

insert into tb_trailer(id_filme, nm_trailer,nr_duracao, bt_dublado) values(8, '', 04, false); 

insert into tb_trailer(id_filme, nm_trailer,nr_duracao, bt_dublado) values(9, '', 06, true);

insert into tb_trailer(id_filme, nm_trailer,nr_duracao, bt_dublado) values(10, '', 04, true);

insert into tb_trailer(id_filme, nm_trailer,nr_duracao, bt_dublado) values(11, '', 06, false);

insert into tb_trailer(id_filme, nm_trailer,nr_duracao, bt_dublado) values(12, '', 06, false);

insert into tb_trailer(id_filme, nm_trailer,nr_duracao, bt_dublado) values(13, '', 05, true);

insert into tb_trailer(id_filme, nm_trailer,nr_duracao, bt_dublado) values(14, '', 07, false);

insert into tb_trailer(id_filme, nm_trailer,nr_duracao, bt_dublado) values(15, '', 03, true);

select * from tb_filme;