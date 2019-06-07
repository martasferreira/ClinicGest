CREATE PROC SP_SubmitMedico
    @cc              varchar(12),
    @nome            varchar(50),
    @telefone        varchar(14),
    @telemovel       varchar(14),
    @email           varchar(100),
    @endereco        varchar(150),
    @codigopostal    int,
    @nacionalidade   varchar(30),
    @sexo            char,
    @data_nasc       date
AS
INSERT INTO ClinicGest.Pessoa (cc, nome,telefone, telemovel, email, endereco, codigopostal, nacionalidade, sexo, data_nasc ) VALUES 
            (@cc, @nome, @telefone, @telemovel, @email, @endereco, @codigopostal, @nacionalidade, @sexo, @data_nasc )
INSERT INTO ClinicGest.Paciente (cc_pac) VALUES (@cc)
SELECT SCOPE_IDENTITY()
GO

INSERT ClinicGest.Staff (cc_staff,salario) VALUES (@cc, @salario)
INSERT ClinicGest.Medico (codigo_staff, especialidade) VALUES
((SELECT codigo_staff FROM ClinicGest.Staff WHERE cc_staff = @cc), @especialidade);" &
            "SELECT SCOPE_IDENTITY()"