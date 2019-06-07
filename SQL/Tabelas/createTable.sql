use p4g9;

create table ClinicGest.Pessoa(
    cc              varchar(12) not null,
    nome            varchar(50) not null,
    telefone        varchar(14),
    telemovel       varchar(14),
    email           varchar(100),
    endereco        varchar(150),
    codigopostal    int,
    nacionalidade   varchar(30),
    sexo            char,
    data_nasc       date,
    primary key (cc)
) 

create table ClinicGest.Seguro (
    codigo_seguro               int not null  identity(1,1),
    entidade                    varchar(30) not null,
    desconto                    int not null,
    primary key (codigo_seguro)
)

create table ClinicGest.Paciente(
    codigo_pac      int not null identity(1,1), 
    cc_pac          varchar(12) not null,
    codigo_seguro   int,
    primary key     (codigo_pac),
    foreign key (cc_pac) references ClinicGest.Pessoa(cc),
    foreign key (codigo_seguro) references ClinicGest.Seguro(codigo_seguro)
)

create table ClinicGest.Staff(
    codigo_staff    int not null identity(1,1),
    cc_staff        varchar(12),
    salario         int,
    primary key (codigo_staff),
	foreign key (cc_staff) references ClinicGest.Pessoa(cc)
)

create table ClinicGest.Medico(
    codigo_staff      int not null,
    codigo_med      int not null identity(1,1),
    especialidade   varchar(20),
    primary key (codigo_med),
    foreign key (codigo_staff) references ClinicGest.Staff(codigo_staff)
)


create table ClinicGest.Enfermeiro(
    codigo_staff      int not null,
    codigo_enf      int not null identity(1,1),
	trabalha_servico int,
    primary key (codigo_enf),
    foreign key (codigo_staff) references ClinicGest.Staff(codigo_staff),
    foreign key (trabalha_servico) references ClinicGest.Servico(codigo_servico)
)

create table ClinicGest.Produto(
    codigo_produto  int not null  identity(1,1),
    tipo_produto    varchar(11),
    custo           int,
    custo_de_limp   decimal(4,2),
primary key (codigo_produto)
)

create table ClinicGest.Servico(
    codigo_servico         int not null  identity(1,1),
    nome                   varchar(30) not null,
    custo                  int not null,
    medico_responsavel     int,
    enfermeiro_responsavel int,
    primary key (codigo_servico),
    foreign key (medico_responsavel) references ClinicGest.Medico(codigo_med),
    foreign key (enfermeiro_responsavel) references ClinicGest.Enfermeiro(codigo_enf),
)


    
create table ClinicGest.Internamento(
    num_internamento            int not null  identity(1,1),
    codigo_servico        int not null,
    codigo_pac              int not null,
    data_entrada                date not null,
    data_saida                 date,
    patologia                   varchar(100) not null,
    primary key (num_internamento),
    foreign key (codigo_servico) references ClinicGest.Servico(codigo_servico),
    foreign key (codigo_pac) references ClinicGest.Paciente(codigo_pac)
)

create table ClinicGest.intervencao(
    num_intervencao     int not null identity(1,1),
    num_internamento    int not null,
    codigo_staff        int not null,
    primary key (num_intervencao),
    foreign key (num_internamento) references ClinicGest.Internamento(num_internamento),
    foreign key (codigo_staff) references ClinicGest.Staff(codigo_staff)
)

create table ClinicGest.Receitamedica (
    num_receita                 int not null  identity(1,1),
    receita_paciente            int not null,
    receita_medico              int not null,
    receita_internamento         int not null,
    primary key (num_receita),
    foreign key (receita_internamento) references ClinicGest.Internamento(num_internamento),
    foreign key (receita_medico) references ClinicGest.Medico(codigo_med),
    foreign key (receita_paciente) references ClinicGest.Paciente(codigo_pac),
)

create table ClinicGest.Fatura (
    num_fatura                  int not null  identity(1,1),
    fatura_paciente             int not null,
    fatura_internamento         int,
    codigo_seguro               int,
    custo                       int not null,
    data_pagamento              date, 
    primary key (num_fatura),
    foreign key (fatura_paciente) references ClinicGest.Paciente(codigo_pac),
    foreign key (fatura_internamento) references ClinicGest.Internamento(num_internamento),
    )

create table ClinicGest.Medicamento (
    codigo_medicamento          int not null  identity(1,1),
    nome                        varchar(30) not null,
    preco_unitario				decimal(5,2),
    primary key (codigo_medicamento)
)

create table ClinicGest.Aviareceita (
    num_receita         int not null,
    cod_medicamento     int not null,
    primary key (num_receita,cod_medicamento),
    foreign key (num_receita) references ClinicGest.Receitamedica(num_receita),
    foreign key (cod_medicamento) references ClinicGest.Medicamento(codigo_medicamento)
)

create table ClinicGest.Temseguro (
    cod_seguro          int not null,
    cod_paciente        int not null,
    primary key (cod_seguro,cod_paciente),
    foreign key (cod_seguro) references ClinicGest.Seguro(codigo_seguro),
    foreign key (cod_paciente) references ClinicGest.Paciente(codigo_pac)
)

create table ClinicGest.Gastaproduto(
    gasta_prod      int not null,
    gasta_intervencao int not null,
    primary key (gasta_prod,gasta_intervencao),
    foreign key (gasta_prod) references ClinicGest.Produto(codigo_produto),
    foreign key (gasta_intervencao) references ClinicGest.Intervencao(num_intervencao)
 )
 
 create table ClinicGest.Medicoemservico(
 	codigo_med	int not null,
 	codigo_servico int not null,
	primary key (codigo_med,codigo_servico),
	foreign key (codigo_med) references ClinicGest.Medico(codigo_med),
	foreign key (codigo_servico) references ClinicGest.Servico(codigo_servico)
 )

create table ClinicGest.ProdutoIntervencao(
    numero_intervencao int not null,
    codigo_produto     int not null,
    quantidade         int DEFAULT(1),
    primary key (numero_intervencao,codigo_produto),
    foreign key (codigo_produto) references ClinicGest.Produto(codigo_produto),
    foreign key (numero_intervencao) references ClinicGest.Intervencao(num_intervencao),

)