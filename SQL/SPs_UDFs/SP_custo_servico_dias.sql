CREATE proc SP_custo_de_internamento (@param_internamento int)
as
select DATEDIFF(DAY,internamento.data_entrada,internamento.data_saida)*servico.custo as total from ClinicGest.Internamento as internamento join CLinicGest.Servico as servico on internamento.codigo_servico = servico.codigo_servico where internamento.num_internamento = @param_internamento

go
