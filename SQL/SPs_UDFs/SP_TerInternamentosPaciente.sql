Create proc SP_TerInternamentosPaciente @paciente int
as
select num_internamento, servico.codigo_servico as codigoServico, servico.nome as nomeServico, pessoa.nome as nomePessoa, custo, data_entrada, data_saida, patologia
 from ClinicGest.Internamento as internamento join ClinicGest.Servico as servico on internamento.codigo_servico = servico.codigo_servico
 join ClinicGest.Paciente as paciente on internamento.codigo_pac = paciente.codigo_pac 
 join ClinicGest.Pessoa as pessoa on pessoa.cc = paciente.cc_pac
 where internamento.codigo_pac = @paciente
