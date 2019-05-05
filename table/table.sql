create table cliente
(
  id       int auto_increment
    primary key,
  nome     varchar(190) not null,
  telefone varchar(12)  null,
  endereco varchar(190) null,
  cpf      varchar(13)  not null,
  constraint cliente_cpf_uindex
    unique (cpf)
);

create table fornecedor
(
  id       int auto_increment
    primary key,
  nome     varchar(150) not null,
  cnpj     varchar(14)  not null,
  telefone varchar(15)  not null,
  constraint nome
    unique (nome)
);

create table madeira
(
  id            int auto_increment
    primary key,
  tipo          varchar(150) not null,
  preco         float        not null,
  fornecedor_id int          not null,
  constraint madeira_tipo_uindex
    unique (tipo),
  constraint fornecedor_fk
    foreign key (fornecedor_id) references fornecedor (id)
      on update cascade on delete cascade
);

create table tinta
(
  id            int auto_increment
    primary key,
  cor           varchar(40) not null,
  fornecedor_id int         not null,
  preco         float       not null,
  constraint tinta_cor_uindex
    unique (cor),
  constraint tinta_fornecedor_id_fk
    foreign key (fornecedor_id) references fornecedor (id)
      on update cascade on delete cascade
);

create table produto
(
  id         int auto_increment
    primary key,
  nome       varchar(140) not null,
  altura     float        not null,
  largura    float        not null,
  espessura  float        not null,
  madeira_id int          not null,
  tinta_id   int          not null,
  quantidade int          not null,
  constraint produto_madeira_id_fk
    foreign key (madeira_id) references madeira (id)
      on update cascade on delete cascade,
  constraint produto_tinta_id_fk
    foreign key (tinta_id) references tinta (id)
      on update cascade on delete cascade
);

create table estoque
(
  id         int auto_increment
    primary key,
  produto_id int not null,
  quantidade int not null,
  constraint estoque_produto_id_fk
    foreign key (produto_id) references produto (id)
      on update cascade on delete cascade
);

create table usuario
(
  id    int auto_increment
    primary key,
  nome  varchar(150)                                                  not null,
  login varchar(150)                                                  not null,
  senha varchar(150)                                                  not null,
  role  enum ('Retailer', 'Stockist', 'Employee', 'Manager', 'Admin') not null,
  constraint usuario_login_uindex
    unique (login)
);

create table venda
(
  id         int auto_increment
    primary key,
  produto_id int not null,
  preco      int not null,
  constraint venda_produto_id_fk
    foreign key (produto_id) references produto (id)
);


