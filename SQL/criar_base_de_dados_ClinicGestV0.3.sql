use p4g9;


GO

create table ClinicGest.Pessoa(
    cc              varchar(12) not null,
    nome            varchar(50) not null,
    telefone        varchar(14), -- atenção a programação defensiva para evitar problemas de segurança ou fiabilidade de dados
    telemovel       varchar(14), -- atenção a programação defensiva para evitar problemas de segurança ou fiabilidade de dados
    email           varchar(100),
    endereco        varchar(150),
    codigopostal    int,
    nacionalidade   varchar(30),
    sexo            char,
    data_nasc       date,
    primary key (cc)
) 

create table ClinicGest.Paciente(
    codigo_pac      int not null,
    cc_pac          varchar(12) not null, 
    primary key     (codigo_pac),
    foreign key (cc_pac) references ClinicGest.Pessoa(cc),
)

create table ClinicGest.Staff(
    codigo_staff    int not null,
    cc_staff        varchar(12),
    salario         int,
    primary key (codigo_staff)
)

create table ClinicGest.Medico(
    codigo_emp      int not null,
    codigo_med      varchar(10) not null,
    especialidade   varchar(20),
--    medico_responsavel     varchar(10) not null, -- versão v0.2
--    medico_trabalha        varchar(10),
    primary key (codigo_med),
    foreign key (codigo_emp) references ClinicGest.Staff(codigo_staff),
--    foreign key (medico_responsavel) references ClinicGest.Servico(codigo_servico) -- versão v0.2
)

create table ClinicGest.Enfermeiro(
    codigo_emp      int not null,
    codigo_enf      varchar(10) not null,
    primary key (codigo_enf),
    foreign key (codigo_emp) references ClinicGest.Staff(codigo_staff)  
)

create table ClinicGest.Produto(
    codigo_produto  int not null,
    tipo_produto    varchar(11),
    custo           int,
    custo_de_limp   decimal(4,2),
primary key (codigo_produto)
)


create table ClinicGest.Servico(
    codigo_servico         int not null,
    nome                   varchar(30) not null,
    custo                  int not null,
--    medico_responsavel     varchar(10) not null,      minha versao v0.1
--    medico_trabalha        varchar(10),               minha versao v0.1
    enfermeiro_responsavel varchar(10)not null,
    enfermeiro_trabalha    varchar(10)not null,
    primary key (codigo_servico),
--    foreign key (medico_responsavel) references ClinicGest.Medico(codigo_med),
--    foreign key (medico_trabalha) references ClinicGest.Medico(codigo_med),
    foreign key (enfermeiro_responsavel) references ClinicGest.Enfermeiro(codigo_enf),
    foreign key (enfermeiro_trabalha) references ClinicGest.Enfermeiro(codigo_enf),
)


create table ClinicGest.Internamento(
    num_internamento            int not null,
    internamento_servico        int not null,
--    internamento_intervencao    int not null,
--    duracao                     int not null, --em dias sera relevante colocar derivado de data_inicio e data_fim
    data_entrada                date not null,
    data_saida                 date not null,
    patologia                   varchar(30) not null,
    primary key (num_internamento),
    foreign key (internamento_servico) references ClinicGest.Servico(codigo_servico),
 --   foreign key (internamento_intervencao) references ClinicGest.Intervencao(num_intervencao)
)


create table ClinicGest.Intervencao(
    num_intervencao int  not null,
    int_paciente    int  not null,
    int_medico      varchar (10),
    int_enf         varchar (10),
    int_internamento int,
    primary key (num_intervencao),
    foreign key (int_paciente) references ClinicGest.Paciente(codigo_pac),
    foreign key (int_medico) references ClinicGest.Medico(codigo_med),
    foreign key (int_enf) references ClinicGest.Enfermeiro(codigo_enf),
    foreign key (int_internamento) references ClinicGest.Internamento(num_internamento),
)

create table ClinicGest.Receitamedica (
    num_receita                 int not null,
    receita_paciente            int not null,
    receita_medico              varchar(10) not null,
    receita_intervencao         int not null,
    primary key (num_receita),
    foreign key (receita_intervencao) references ClinicGest.Intervencao(num_intervencao),
    foreign key (receita_medico) references ClinicGest.Medico(codigo_med),
    foreign key (receita_paciente) references ClinicGest.Paciente(codigo_pac),
)

create table ClinicGest.Seguro (
    codigo_seguro               int not null,
    entidade                    varchar(30) not null,
    desconto                    int not null,
    primary key (codigo_seguro)
)

create table ClinicGest.Fatura (
    num_fatura                  int not null,
    fatura_paciente             int not null,
    fatura_internamento         int,
    fatura_intervencao          int not null,
    custo                       int not null, -- falar com professor
    pago                        date, -- falar com professor (new view subtrair as anteriores)
    primary key (num_fatura),
    foreign key (fatura_paciente) references ClinicGest.Paciente(codigo_pac),
    foreign key (fatura_internamento) references ClinicGest.Internamento(num_internamento),
    foreign key (fatura_intervencao) references ClinicGest.Intervencao(num_intervencao)
    )

create table ClinicGest.Medicamento (
    codigo_medicamento          int not null,
    nome                        varchar(30) not null,
    preco_unitario              int,
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

