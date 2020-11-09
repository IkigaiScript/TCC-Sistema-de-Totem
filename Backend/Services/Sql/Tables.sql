create database tcdb;
use tcdb;

CREATE TABLE tb_filme (
	`id_filme` INT PRIMARY KEY AUTO_INCREMENT,
    `nm_filme` VARCHAR(100) UNIQUE NOT NULL,
    `ds_genero` VARCHAR(255) NOT NULL,
    `ds_sinopse` TEXT NOT NULL,
    `ds_imagem` VARCHAR(255), -- NOT NULL
    `nr_classificacao` INT NOT NULL,
	`nr_duracao` INT NOT NULL,
    `bt_breve` BOOL NOT NULL,
    `bt_estreia` BOOL NOT NULL
);

CREATE TABLE tb_ator (
	`id_ator` INT PRIMARY KEY AUTO_INCREMENT,
    `id_filme` INT NOT NULL,
    `nm_ator` VARCHAR(100) NOT NULL,
    `dt_nascimento` DATETIME NOT NULL,
    FOREIGN KEY (`id_filme`) REFERENCES tb_filme (`id_filme`) ON DELETE CASCADE
);
   
CREATE TABLE tb_diretor (
	`id_diretor` INT PRIMARY KEY AUTO_INCREMENT,
    `id_filme` INT NOT NULL,
    `nm_diretor` VARCHAR(100) NOT NULL,
    `dt_nascimento` DATETIME NOT NULL,
    FOREIGN KEY (id_filme) REFERENCES tb_filme (id_filme) ON DELETE CASCADE
);
   
CREATE TABLE tb_trailer (
	`id_trailer` INT PRIMARY KEY AUTO_INCREMENT,
    `id_filme` INT NOT NULL,
    `nm_trailer` VARCHAR(100) NOT NULL,
    `nr_duracao` INT NOT NULL,
    `bt_dublado` BOOL NOT NULL,
    FOREIGN KEY (`id_filme`) REFERENCES tb_filme (`id_filme`) ON DELETE CASCADE
);

CREATE TABLE tb_cupom_desconto (
	`id_cupom_desconto` INT PRIMARY KEY AUTO_INCREMENT,
    `nm_cupom` VARCHAR(100) NOT NULL,
    `ds_codigo` VARCHAR(100) NOT  NULL,
 	`vl_desconto` DECIMAL(10,2) NOT NULL,
    `vl_min_gasto` DECIMAL(10,2) NOT NULL
);

CREATE TABLE tb_login (
	`id_login` INT PRIMARY KEY AUTO_INCREMENT,
	`ds_email` VARCHAR(255) NOT NULL,
    `ds_senha` VARCHAR(255) NOT NULL
);

CREATE TABLE tb_sessao (
	`id_sessao` INT PRIMARY KEY AUTO_INCREMENT,
    `id_filme` INT NOT NULL,
    `ds_tipo_sala` VARCHAR(255) NOT NULL,
    `nr_sala` INT NOT NULL,
    `vl_ingresso` DECIMAL(10,2) NOT NULL, 
    `dt_horario` DATETIME NOT NULL,
    FOREIGN KEY (`id_filme`) REFERENCES tb_filme (`id_filme`) ON DELETE CASCADE
);

CREATE TABLE tb_pedido (
	`id_pedido` INT PRIMARY KEY AUTO_INCREMENT,
    `id_cupom_desconto` INT,
    `id_login` INT NOT NULL,
    `nm_titular` VARCHAR(100),
    `ds_forma_pagamento` VARCHAR(255),
    `ds_status` VARCHAR(255),
    `vl_total` DECIMAL(10,2),
    FOREIGN KEY (`id_cupom_desconto`) REFERENCES tb_cupom_desconto (`id_cupom_desconto`) ON DELETE CASCADE,
    FOREIGN KEY (`id_login`) REFERENCES tb_login (`id_login`) ON DELETE CASCADE
);
   
CREATE TABLE tb_ingresso (
	`id_ingresso` INT PRIMARY KEY AUTO_INCREMENT,
    `id_pedido` INT NOT NULL,
    `id_sessao` INT NOT NULL,
    `ds_fileira` VARCHAR(1) NOT NULL,
    `nr_poltrona` INT NOT NULL,
    `bt_meia_entrada` BOOL NOT NULL,
    FOREIGN KEY (`id_pedido`) REFERENCES tb_pedido (`id_pedido`) ON DELETE CASCADE,
    FOREIGN KEY (`id_sessao`) REFERENCES tb_sessao (`id_sessao`) ON DELETE CASCADE
); 

CREATE TABLE tb_cliente (
	`id_cliente` INT PRIMARY KEY AUTO_INCREMENT,
    `id_login` INT NOT NULL,
    `nm_cliente` VARCHAR(100) NOT NULL,
    `ds_cpf` VARCHAR(14) NOT NULL,
    `ds_cep` VARCHAR(9) NOT NULL,
    `ds_rg` VARCHAR(12) NOT NULL,
    `ds_celular` VARCHAR(14) NOT NULL,
    `bt_condicao_especial` BOOL NOT NULL,
    `bt_vip` BOOL NOT NULL,
    FOREIGN KEY (`id_login`) REFERENCES tb_login (`id_login`) ON DELETE CASCADE
);
    
CREATE TABLE tb_snack_bar (
	`id_snack_bar` INT PRIMARY KEY AUTO_INCREMENT,
    `nm_produto` VARCHAR(100) NOT NULL,
    `ds_tipo_produto` VARCHAR(50) NOT NULL,
    `ds_marca` VARCHAR(100) NOT NULL,
    `ds_sabor` VARCHAR(100) NOT NULL,
    `ds_peso` VARCHAR(15) NOT NULL,
    `ds_imagem` VARCHAR(255), -- NOT NULL
    `nr_qtd_estoque` INT NOT NULL,
	`vl_preco` DECIMAL(10,2) NOT NULL
);   

CREATE TABLE tb_pedido_snack_bar (
	`id_pedido_snack_bar` INT PRIMARY KEY AUTO_INCREMENT,
    `id_pedido` INT NOT NULL,
    `id_snack_bar` INT NOT NULL,
    `nr_qtd_snack_bar` INT NOT NULL,
    FOREIGN KEY (`id_snack_bar`) REFERENCES tb_snack_bar (`id_snack_bar`) ON DELETE CASCADE,
    FOREIGN KEY (`id_pedido`) REFERENCES tb_pedido (`id_pedido`) ON DELETE CASCADE
);
    
CREATE TABLE tb_combo ( 
	`id_combo` INT PRIMARY KEY AUTO_INCREMENT,
    `nm_combo` VARCHAR(100) NOT NULL,
    `ds_first_item` VARCHAR(255) NOT NULL,
    `ds_secondary_item` VARCHAR(255),
    `ds_third_item` VARCHAR(255),
    `vl_preco` DECIMAL(10,2) NOT NULL,
    `ds_imagem` VARCHAR(255)  -- NOT NULL
);

CREATE TABLE tb_pedido_combo (
	`id_pedido_combo` INT PRIMARY KEY AUTO_INCREMENT,
    `id_pedido` INT NOT NULL,
    `id_combo` INT NOT NULL, 
    `nr_qtd_combo` INT NOT NULL,
    FOREIGN KEY (`id_pedido`) REFERENCES tb_pedido (`id_pedido`) ON DELETE CASCADE,
    FOREIGN KEY (`id_combo`)  REFERENCES tb_combo (`id_combo`) ON DELETE CASCADE
);
   
CREATE TABLE tb_nota_fiscal (
    `id_nota_fisical` INT PRIMARY KEY AUTO_INCREMENT,
    `id_pedido` INT NOT NULL,
    `ds_email` VARCHAR(255) NOT NULL,
    `ds_cpf` VARCHAR(14) NOT NULL,
    FOREIGN KEY (`id_pedido`) REFERENCES tb_pedido (`id_pedido`) ON DELETE CASCADE
);
   
CREATE TABLE tb_cartao (
    `id_cartao` INT PRIMARY KEY AUTO_INCREMENT,
    `id_pedido` INT NOT NULL,
	`ds_cartao` VARCHAR(100) NOT NULL,
    `vl_gasto` DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (`id_pedido`) REFERENCES tb_pedido (`id_pedido`) ON DELETE CASCADE
);

show tables;
