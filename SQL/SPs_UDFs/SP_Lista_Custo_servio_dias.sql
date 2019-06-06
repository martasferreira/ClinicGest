CREATE PROC SP_Lista_Custo_servio_dias
AS
select DATEDIFF(DAY,internamento.data_entrada,internamento.data_saida)*servico.custo as total from ClinicGest.Fatura as fatura join ClinicGest.Internamento as internamento on fatura.fatura_internamento = internamento.num_internamento 
     join CLinicGest.Servico as servico on internamento.codigo_servico = servico.codigo_servico

GO


