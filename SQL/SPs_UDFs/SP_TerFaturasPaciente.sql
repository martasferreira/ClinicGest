CREATE PROC SP_TerFaturasPaciente @paciente int
AS
SELECT * FROM ClinicGest.Fatura as Fatura Join  ClinicGest.Paciente as Paciente on Fatura.fatura_paciente = Paciente.codigo_pac Join ClinicGest.Pessoa as Pessoa on  Paciente.cc_pac = Pessoa.cc where codigo_pac = @paciente

GO