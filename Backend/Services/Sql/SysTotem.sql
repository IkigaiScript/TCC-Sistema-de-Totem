create database tcdb;
use tcdb;


CREATE TABLE tb_filme (
	`id_filme`        INT PRIMARY KEY AUTO_INCREMENT,
    `nm_filme`        VARCHAR(100) UNIQUE NOT NULL,
    `ds_genero`       VARCHAR(255) NOT NULL,
    `ds_sinopse`      TEXT NOT NULL,
    `ds_imagem`       VARCHAR(255), -- NOT NULL
    `nr_classificacao` INT NOT NULL,
	`nr_duracao`      INT NOT NULL,
    `bt_breve`        BOOL NOT NULL,
    `bt_estreia`      BOOL NOT NULL
);

CREATE TABLE tb_ator (
	`id_ator`			INT PRIMARY KEY AUTO_INCREMENT,
    `id_filme`   		INT NOT NULL,
    `nm_ator`			VARCHAR(100) NOT NULL,
    `dt_nascimento`		DATETIME NOT NULL,
    FOREIGN KEY (`id_filme`) REFERENCES tb_filme (`id_filme`) ON DELETE CASCADE
);
   
CREATE TABLE tb_diretor (
	`id_diretor`			INT PRIMARY KEY AUTO_INCREMENT,
    `id_filme`   			INT NOT NULL,
    `nm_diretor` 			VARCHAR(100) NOT NULL,
    `dt_nascimento`		   DATETIME NOT NULL,
    FOREIGN KEY (id_filme) REFERENCES tb_filme (id_filme) ON DELETE CASCADE
);
   
CREATE TABLE tb_trailer (
	`id_trailer`			INT PRIMARY KEY AUTO_INCREMENT,
    `id_filme`   			INT NOT NULL,
    `nm_trailer` 			VARCHAR(100) NOT NULL,
    `nr_duracao`			INT NOT NULL,
    `bt_dublado`		    BOOL NOT NULL,
    FOREIGN KEY (`id_filme`) REFERENCES tb_filme (`id_filme`) ON DELETE CASCADE
);

CREATE TABLE tb_cupom_desconto (
	`id_cupom_desconto`	    INT PRIMARY KEY AUTO_INCREMENT,
    `nm_cupom`      		VARCHAR(100) NOT NULL,
    `ds_codigo`				VARCHAR(100) NOT  NULL,
 	`vl_desconto`			DECIMAL(10,2) NOT NULL,
    `vl_min_gasto`		    DECIMAL(10,2) NOT NULL
);

CREATE TABLE tb_login (
	`id_login`			INT PRIMARY KEY AUTO_INCREMENT,
	`ds_email`			VARCHAR(255) NOT NULL,
    `ds_senha`			VARCHAR(255) NOT NULL,
	`nr_nivel`			INT NOT NULL
);

CREATE TABLE tb_sessao (
	`id_sessao`			INT PRIMARY KEY AUTO_INCREMENT,
    `id_filme`   		INT NOT NULL,
    `ds_tipo_sala` 		VARCHAR(255) NOT NULL,
    `nr_sala` 			INT NOT NULL,
    `vl_ingresso` 		DECIMAL(10,2) NOT NULL, 
    `dt_horario`    	DATETIME NOT NULL,
    FOREIGN KEY (`id_filme`) REFERENCES tb_filme (`id_filme`) ON DELETE CASCADE
);

CREATE TABLE tb_pedido (
	`id_pedido`				INT PRIMARY KEY AUTO_INCREMENT,
    `id_cupom_desconto`   	INT,
    `id_login`   			INT NOT NULL,
    `nm_titular`			VARCHAR(100),
    `ds_forma_pagamento`	VARCHAR(255),
    `ds_status`				VARCHAR(255),
    `vl_total`				DECIMAL(10,2),
    `dt_horario`			DATETIME NOT NULL,
    FOREIGN KEY (`id_cupom_desconto`) REFERENCES tb_cupom_desconto (`id_cupom_desconto`) ON DELETE CASCADE,
    FOREIGN KEY (`id_login`) 	REFERENCES tb_login (`id_login`) ON DELETE CASCADE
);

CREATE TABLE tb_ingresso (
	`id_ingresso`			INT PRIMARY KEY AUTO_INCREMENT,
    `id_pedido`   		    INT NOT NULL,
    `id_sessao`   		    INT NOT NULL,
    `ds_fileira`			VARCHAR(1) NOT NULL,
    `nr_poltrona`		 	INT NOT NULL,
    `bt_meia_entrada`		BOOL NOT NULL,
    FOREIGN KEY (`id_pedido`) REFERENCES tb_pedido (`id_pedido`) ON DELETE CASCADE,
    FOREIGN KEY (`id_sessao`) REFERENCES tb_sessao (`id_sessao`) ON DELETE CASCADE
); 

CREATE TABLE tb_cliente (
	`id_cliente`				INT PRIMARY KEY AUTO_INCREMENT,
    `id_login`   				INT NOT NULL,
    `nm_cliente`   		    	VARCHAR(100) NOT NULL,
    `ds_cpf`					VARCHAR(14) NOT NULL,
    `ds_cep`					VARCHAR(9) NOT NULL,
    `ds_rg`				    	VARCHAR(12) NOT NULL,
    `ds_celular`    			VARCHAR(14) NOT NULL,
    `bt_condicao_especial`	    BOOL NOT NULL,
    `bt_vip`					BOOL NOT NULL,
    FOREIGN KEY (`id_login`) REFERENCES tb_login (`id_login`) ON DELETE CASCADE
);
    
CREATE TABLE tb_snack_bar (
	`id_snack_bar`	    	INT PRIMARY KEY AUTO_INCREMENT,
    `nm_produto`			VARCHAR(100) NOT NULL,
    `ds_tipo_produto`		VARCHAR(50) NOT NULL,
    `ds_marca`		    	VARCHAR(100) NOT NULL,
    `ds_sabor`           	VARCHAR(100) NOT NULL,
    `ds_peso`           	VARCHAR(15) NOT NULL,
    `ds_imagem`             VARCHAR(255), -- NOT NULL
    `nr_qtd_estoque`     	INT NOT NULL,
	`vl_preco`		    	DECIMAL(10,2) NOT NULL
);   

CREATE TABLE tb_pedido_snack_bar (
	`id_pedido_snack_bar`	INT PRIMARY KEY AUTO_INCREMENT,
    `id_pedido`   			INT NOT NULL,
    `id_snack_bar`   		INT NOT NULL,
    `nr_qtd_snack_bar` 		INT NOT NULL,
    FOREIGN KEY (`id_snack_bar`) REFERENCES tb_snack_bar (`id_snack_bar`) ON DELETE CASCADE,
    FOREIGN KEY (`id_pedido`) REFERENCES tb_pedido (`id_pedido`) ON DELETE CASCADE
);
    
CREATE TABLE tb_combo ( 
	`id_combo`		    	INT PRIMARY KEY AUTO_INCREMENT,
    `nm_combo` 	    		VARCHAR(100) NOT NULL,
    `ds_first_item` 		VARCHAR(255) NOT NULL,
    `ds_secondary_item` 	VARCHAR(255),
    `ds_third_item` 		VARCHAR(255),
    `vl_preco`   			DECIMAL(10,2) NOT NULL,
    `ds_imagem` 			VARCHAR(255)  -- NOT NULL
);

CREATE TABLE tb_pedido_combo (
	`id_pedido_combo`	INT PRIMARY KEY AUTO_INCREMENT,
    `id_pedido`   		INT NOT NULL,
    `id_combo`   		INT NOT NULL, 
    `nr_qtd_combo`		INT NOT NULL,
    FOREIGN KEY (`id_pedido`) REFERENCES tb_pedido (`id_pedido`) ON DELETE CASCADE,
    FOREIGN KEY (`id_combo`)  REFERENCES tb_combo (`id_combo`) ON DELETE CASCADE
);
   
CREATE TABLE tb_nota_fiscal (
    `id_nota_fisical`		INT PRIMARY KEY AUTO_INCREMENT,
    `id_pedido`   			INT NOT NULL,
    `ds_email` 				VARCHAR(255) NOT NULL,
    `ds_cpf`				VARCHAR(14) NOT NULL,
    FOREIGN KEY (`id_pedido`) REFERENCES tb_pedido (`id_pedido`) ON DELETE CASCADE
);
   
CREATE TABLE tb_cartao (
    `id_cartao`				INT PRIMARY KEY AUTO_INCREMENT,
    `id_pedido`   			INT NOT NULL,
	`ds_cartao`			    VARCHAR(100) NOT NULL,
    `vl_gasto`				DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (`id_pedido`) REFERENCES tb_pedido (`id_pedido`) ON DELETE CASCADE
);

insert into tb_filme(nm_filme,ds_genero,ds_sinopse,nr_classificacao,nr_duracao,bt_breve,bt_estreia) values ('Bloodshot','Ação/Aventura','Depois de ser morto em combate, o soldado Ray Garrison é trazido de volta à vida com um exército de nanotecnologia em suas veias e poderes sobre-humanos: uma incrível força e a habilidade de se curar instantaneamente. Sem memória, ele está decidido a descobrir a verdade sobre quem realmente é.',14,109,false,true);

insert into tb_filme(nm_filme,ds_genero,ds_sinopse,nr_classificacao,nr_duracao,bt_breve,bt_estreia) values ('Os novos mutantes','Terror/Fantasia','A história de Os Novos Mutantes, uma equipe de heróis mutantes formada pelos primeiros graduados pela escola de Charles Xavier.',14,99,true,false);

insert into tb_filme(nm_filme,ds_genero,ds_sinopse,nr_classificacao,nr_duracao,bt_breve,bt_estreia) values ('40 dias - O milagre da vida','Drama','Tudo que Abby Johnson sempre quis foi ajudar outras mulheres. Como uma das diretoras mais jovens da história da Paternidade Planejada, organização responsável por metade dos abortos realizados nos Estados Unidos, ela acreditava ter feito a escolha certa. Até o dia em que algo que Abby viu fez com que tudo mudasse e ela se tornasse uma das principais vozes do movimento pró-vida dos Estados Unidos.',16,109,false,true);

insert into tb_filme(nm_filme,ds_genero,ds_sinopse,nr_classificacao,nr_duracao,bt_breve,bt_estreia) values ('Possessão - O Último Estágio','Terror/Misterio','Quando Joel se vê sozinho e precisa cuidar de seu filho de 8 anos, coisas estranhas começam a acontecer. O pequeno vive assustado e, para garantir que não há nada de monstruoso pela casa, Joel dá uma máquina fotográfica para o menino, assim, sempre que tivesse medo, a foto captaria o que há de verdade nos cômodos. Apesar de ser cético, as coisas começam a ficar estranhas e dois padres entram em cena. É uma corrida contra o tempo para a alma de um garotinho que culmina com uma revelação sombria e chocante que vai te deixar questionando a profundidade do diabo dentro de todos nós.',12,93,false,true);

insert into tb_filme(nm_filme,ds_genero,ds_sinopse,nr_classificacao,nr_duracao,bt_breve,bt_estreia) values ('AS FACES DO DEMÔNIO','Suspense/Drama/Policial','Em As Faces do Demônio, Gang-Goo (Dong-il Sung) e Myung-Joo (Young-nam Jang) são casados ​​e têm três filhos. Eles se mudam para um novo lar, mas coisas bizarras e aterrorizantes acontecem quando um espírito maligno se transforma em um dos membros da família.',12,110,true,false);

insert into tb_filme(nm_filme,ds_genero,ds_sinopse,nr_classificacao,nr_duracao,bt_breve,bt_estreia) values ('A Ilha da Fantasia','Terror/Thriller','Uma ilha mágica no Oceano Pacífico oferece aos visitantes a possibilidade de realizar sonhos e viver aventuras que parecem impossíveis em outro lugar. Porém, como avisa o anfitrião, Sr. Roarke, realizar desejos pode não acontecer da maneira esperada',16,108,false,true);

insert into tb_filme(nm_filme,ds_genero,ds_sinopse,nr_classificacao,nr_duracao,bt_breve,bt_estreia) values ('Magnatas do Crime','Ação/Crime','Um talentoso graduado estadunidense em Oxford, usando suas habilidades únicas, audácia e propensão à violência, cria um império da maconha usando as propriedades dos aristocratas ingleses empobrecidos. No entanto, quando ele tenta vender seu negócio a um colega bilionário. Daí, uma cadeia de eventos se desenrola, envolvendo chantagem, decepção, caos e assassinato entre bandidos de rua, oligarcas russos, gângsteres e jornalistas.',16,113,true,false);

insert into tb_filme(nm_filme,ds_genero,ds_sinopse,nr_classificacao,nr_duracao,bt_breve,bt_estreia) values ('Como Cães e Gatos 3: Peludos Unidos!','Comédia/Fantasia','Um vilão destrói a trégua de dez anos entre gatos e cães. Agora, uma equipe de agentes com tecnologia avançada deve usar seu instinto animal para restaurar a paz entre as espécies.',0,84,false,true);

insert into tb_filme(nm_filme,ds_genero,ds_sinopse,nr_classificacao,nr_duracao,bt_breve,bt_estreia) values ('SCOOBY! O Filme','Mistério/Aventura','SCOOBY! revela como os amigos de longa data, Scooby e Salsicha, se encontram pela primeira vez e como se juntaram aos pequenos detetives Fred, Velma e Daphne para formar a famosa Mistério S/A. Agora, com centenas de casos resolvidos e aventuras compartilhadas, Scooby e sua gangue encaram o maior e mais desafiador mistério de todos os tempos: uma trama que libera o fantasma do cão Cerberus sob o mundo. Enquanto eles se apressam para impedir esse apocãolipse, a gangue descobre que Scooby tem um legado secreto e um destino mais épico do que qualquer um poderia imaginar.',0,94,true,false);

insert into tb_filme(nm_filme,ds_genero,ds_sinopse,nr_classificacao,nr_duracao,bt_breve,bt_estreia) values ('É Doce!','Animação/Infantil','É Doce! apresenta os gnomos Elfie, Buck e Kipp. Enquanto Kipp possui o dom de confeccionar belos móveis e Buck o de fazer velas incomparáveis, Elfie, uma gnomo eloquente e super atrapalhada encontra-se em busca de seguir a tradição dos gnomos: um ofício em que ela seja perfeita. Com isso, ela decide aprender novidades no mundo humano, onde ela e os amigos conhecem Theo, um confeiteiro que está quase perdendo sua loja. Agora, eles unirão forças para salvar o estabelecimento e tornar Elfie em uma grande confeiteira.',0,78,false,true);

insert into tb_filme(nm_filme,ds_genero,ds_sinopse,nr_classificacao,nr_duracao,bt_breve,bt_estreia) values ('BTS Break The Silence: The Movie','Documentario/Musical','Break the Silence: The Movie é um documentário sobre os bastidores da turnê Love yourself: Speak Yourself da boyband sul coreana BTS. Sendo um dos grupos mais conhecidos do gênero k-pop mundialmente, a produção acompanha os melhores momentos ddas viagens entre grandes países ao redor do mundo por 351 dias como Los Angeles, Tóquio e Brasil',10,91,true,false);
 
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

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(1, 2, '3D', '2020-10-19-13-45', 27.00);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(3, 3, 'XD', '2020-10-19-18-50', 22.50);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(4, 1, '3D', '2020-10-19-00-00', 30.00);

insert into tb_sessao(id_filme, nr_sala, ds_tipo_sala, dt_horario, vl_ingresso) values(5, 5, 'XD', '2020-10-20-19-20', 12.50);

insert into tb_snack_bar(nm_produto, ds_tipo_produto, ds_marca, ds_sabor, ds_peso, nr_qtd_estoque, vl_preco) values ("Refrigerante Coca cola grande","Bebida","The Coca-Cola Company","Cola","800ml",100,10.10);

insert into tb_snack_bar(nm_produto, ds_tipo_produto, ds_marca, ds_sabor, ds_peso, nr_qtd_estoque, vl_preco) values ("Refrigerante Fanta garnde","Bebida","The Coca-Cola Company","Laranja","800ml",40,6.4);

insert into tb_snack_bar(nm_produto, ds_tipo_produto, ds_marca, ds_sabor, ds_peso, nr_qtd_estoque, vl_preco) values ("Refrigerante Sprite grande","Bebida","The Coca-Cola Company","Limão","800ml",10,4.5);

insert into tb_snack_bar(nm_produto, ds_tipo_produto, ds_marca, ds_sabor, ds_peso, nr_qtd_estoque, vl_preco) values ("Balde de pipoca medio","Pipoca","Yoki","Tradicional","700g",60,6.4);

insert into tb_snack_bar(nm_produto, ds_tipo_produto, ds_marca, ds_sabor, ds_peso, nr_qtd_estoque, vl_preco) values ("Balde de pipoca com manteiga medio","Pipoca","Yoki","manteiga","700g",120,8.0);

insert into tb_snack_bar(nm_produto, ds_tipo_produto, ds_marca, ds_sabor, ds_peso, nr_qtd_estoque, vl_preco) values ("Balde de pipoca de chocolate medio","Pipoca","Yoki","chocolate","700g",170,8.58);

insert into tb_snack_bar(nm_produto, ds_tipo_produto, ds_marca, ds_sabor, ds_peso, nr_qtd_estoque, vl_preco) values ("Bala de gelatina","Doce","Fini","Ice gream","250g",16,3.4);

insert into tb_snack_bar(nm_produto, ds_tipo_produto, ds_marca, ds_sabor, ds_peso, nr_qtd_estoque, vl_preco) values ("Bala de gelatina","Doce","Fini","Mix de uva","250g",30,4.2);

insert into tb_snack_bar(nm_produto, ds_tipo_produto, ds_marca, ds_sabor, ds_peso, nr_qtd_estoque, vl_preco) values ("Bala de gelatina","Doce","Fini","Banana","250g",20,3.10);

insert into tb_snack_bar(nm_produto, ds_tipo_produto, ds_marca, ds_sabor, ds_peso, nr_qtd_estoque, vl_preco) values ("Salgadinho","Lanche","Doritos","Wasabi","300g",29,4.90);

insert into tb_snack_bar(nm_produto, ds_tipo_produto, ds_marca, ds_sabor, ds_peso, nr_qtd_estoque, vl_preco) values ("Salgadinho","Lanche","Ruffles","Lemon","300g",10,4.70);

insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (1,'Blue hunt','1968-09-25');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (1,'Alice braga','1963-12-18');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (1,'Henry zaga','1956-07-9');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (1,'Maisies williams','1974-11-11');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (1,'Carlie heaton','1942-07-13');

insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (8,'Frank welker','1963-06-09');

insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (8,'Will forte','1967-10-28');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (8,'Zac efron','1986-05-13');

insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (4,'Michael peña','1962-07-12');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (4,'Maggie q.','1962-01-17');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (4,'Lucy hale','1981-06-09');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (6,'Melissa raunch','1970-10-08');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (6,'George lópez','1946-06-06');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (6,'Noel jonshansen','1964-01-07');
  
insert into tb_ator(id_filme,nm_ator,dt_nascimento) values (6,'Sarah giles','1943-08-17');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (6,'Sean mcnamara','1963-03-27');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (4,'Jeff wadlow','1973-02-27');
    
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (8,'Quentin Tarantino','1978-10-23');
    
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (9,'Quentin Tarantino','1983-01-19');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (5,'Elisa beth','1976-05-07');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (10,'Martin Scorsese','1942-11-17');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (2,'Martin Scorsese','1946-10-16');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (2,'Martin Scorsese','1962-01-17');
  
insert into tb_diretor(id_filme,nm_diretor,dt_nascimento) values (9,'Woody Allen','1935-12-01');
  
insert into tb_combo(nm_combo,ds_first_item,ds_secondary_item,vl_preco) values ('Combo balde doce','1 baldinho de pipoca caramelo','2 bebida media',15.80);

insert into tb_combo(nm_combo,ds_first_item,ds_secondary_item,ds_third_item,vl_preco) values ('combo kitkat','1 pipoca media', '1 bebida media', '1 kitkat',12.30);

insert into tb_combo(nm_combo,ds_first_item,ds_secondary_item,ds_third_item,vl_preco) values ('combo M&Ms','1 pipoca com M&Ms','1 bebida','1 baldinho de plastico exclusivo',13.90);

insert into tb_combo(nm_combo,ds_first_item,ds_secondary_item,vl_preco) values ('combo mega','1 pipoca salgada grande','1 bebida grande',16.20);

insert into tb_combo(nm_combo,ds_first_item,ds_secondary_item,vl_preco) values ('combo balde','1 balde pipoca, salgada ou manteiga','2 bebidas media',11.50);

				-- NOTA FISCAL TESTE --
                
insert into tb_login (ds_email,ds_senha,nr_nivel) values ('totem1@cinetotem.com','',0);

insert into tb_login (ds_email,ds_senha,nr_nivel) values ('support@cinetotoem.com','suporte tecnico',1);

insert into tb_login (ds_email,ds_senha,nr_nivel) values ('kauafreita@gmail.com','kuazinho marcus',0);

insert into tb_login (ds_email,ds_senha,nr_nivel) values ('kauafreita@gmail.com','q91w2376r',0);

insert into tb_login (ds_email,ds_senha,nr_nivel) values ('kauafreita@gmail.com','q82735r211-q',0);

insert into tb_login (ds_email,ds_senha,nr_nivel) values ('kauafreita@gmail.com','10108175328',0);

insert into tb_login (ds_email,ds_senha,nr_nivel) values ('joaopaulo@gmail.com','987654321',0);

insert into tb_login (ds_email,ds_senha,nr_nivel) values ('jose@gmail.com','1234',0);

insert into tb_login (ds_email,ds_senha,nr_nivel) values ('maria@gmail.com','1234',0);

insert into tb_login (ds_email,ds_senha,nr_nivel) values ('pietro@gmail.com','1234',0);

insert into tb_login (ds_email,ds_senha,nr_nivel) values ('fernanda@gmail.com','1234',0);

insert into tb_login (ds_email,ds_senha,nr_nivel) values ('agnaldo@gmail.com','1234',0);

insert into tb_cliente (id_login,nm_cliente,ds_cpf,ds_cep,ds_celular,ds_rg,bt_condicao_especial,bt_vip) values (3,'Diego Lima Cavalcanti','737.905.675-15','40265-080','(11)94050-6575','38.861.140-6',false,false);

insert into tb_cliente (id_login,nm_cliente,ds_cpf,ds_cep,ds_celular,ds_rg,bt_condicao_especial,bt_vip) values (4,'Davi Melo Ribeiro','738.015.754-03','04152-030','(11)99865-9137','27.637.913-5',false,true);

insert into tb_cliente (id_login,nm_cliente,ds_cpf,ds_cep,ds_celular,ds_rg,bt_condicao_especial,bt_vip) values (5,'Luan Sousa Cavalcanti','784.825.865-30','14403-352','(11)96502-8840','19.445.044-2',false,false);

insert into tb_cliente (id_login,nm_cliente,ds_cpf,ds_cep,ds_celular,ds_rg,bt_condicao_especial,bt_vip) values (6,'Vinícius Souza Cardoso','892.288.696-07','45606-145','(11)99748-6850','28.746.410-6',false,false);

insert into tb_cliente (id_login,nm_cliente,ds_cpf,ds_cep,ds_celular,ds_rg,bt_condicao_especial,bt_vip) values (7,'Otávio Barros Oliveira','432.947.602-99','03140-010','(11)97416-3582','43.717.287-9',false,false);

insert into tb_cliente (id_login,nm_cliente,ds_cpf,ds_cep,ds_celular,ds_rg,bt_condicao_especial,bt_vip) values (8,'Cauã Cavalcanti Santos','705.560.407-91','86706-630','(11)93769-5806','38.767.985-6',true,false);

insert into tb_cliente (id_login,nm_cliente,ds_cpf,ds_cep,ds_celular,ds_rg,bt_condicao_especial,bt_vip) values (9,'Luis Barros Alves','415.984.162-78','18072-043','(11)90126-5913','14.059.072-9',false,false);

insert into tb_cliente (id_login,nm_cliente,ds_cpf,ds_cep,ds_celular,ds_rg,bt_condicao_especial,bt_vip) values (10,'Kauê Dias Ferreira','771.579.318-34','28238-892','(11)95961-1425','36.514.876-3',false,true);

insert into tb_cliente (id_login,nm_cliente,ds_cpf,ds_cep,ds_celular,ds_rg,bt_condicao_especial,bt_vip) values (11,'Tiago Alves Pereira','718.289.192-2','84061-300','(11)91832-8313','14.890.383-6',false,false);

insert into tb_cliente (id_login,nm_cliente,ds_cpf,ds_cep,ds_celular,ds_rg,bt_condicao_especial,bt_vip) values (12,'Marcos Alves Oliveira','495.297.657-20','21060-550','(11)99429-2624','37.678.430-1',false,false);

select * from tb_pedido;
select * from tb_login;
select * from tb_snack_bar where ds_tipo_produto like '%Bebida%';

insert into tb_pedido_snack_bar (id_pedido,id_snack_bar,nr_qtd_snack_bar) values (2,3,4);

insert into tb_pedido_snack_bar (id_pedido,id_snack_bar,nr_qtd_snack_bar) values (2,2,7);

insert into tb_pedido_snack_bar (id_pedido,id_snack_bar,nr_qtd_snack_bar) values (2,1,1);

insert into tb_pedido_snack_bar (id_pedido,id_snack_bar,nr_qtd_snack_bar) values (2,5,2);
