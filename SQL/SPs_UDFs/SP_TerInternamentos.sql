CREATE PROC SP_TerInternamentos
AS
SELECT Servico.codigo_servico as codigoServico, Servico.nome as nomeServico,Pessoa.nome as nomePessoa, num_internamento, custo, data_entrada, data_saida, patologia FROM ClinicGest.Internamento AS internamento JOIN ClinicGest.Servico AS servico ON internamento.codigo_servico = servico.codigo_servico JOIN ClinicGest.Paciente as paciente on internamento.codigo_pac = paciente.codigo_pac JOIN ClinicGest.Pessoa as pessoa on paciente.cc_pac = pessoa.cc

GO