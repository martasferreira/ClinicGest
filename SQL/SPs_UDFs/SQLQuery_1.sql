--insert into ClinicGest.Fatura(fatura_paciente,fatura_internamento,codigo_seguro,custo,data_pagamento) values
--    (1,1,1,200,null)
/*
    select * from ClinicGest.Fatura as fatura join ClinicGest.Internamento as internamento on fatura.fatura_internamento = internamento.num_internamento 
     join CLinicGest.Servico as servico on internamento.codigo_servico = servico.codigo_servico
     --   join ClinicGest.intervencao as Intervencao on internamento.num_internamento = intervencao.num_internamento  join ClinicGest.ProdutoIntervencao as gastador on intervencao.num_internamento = gastador.numero_intervencao join ClinicGest.Produto as produto on gastador.codigo_produto = produto.codigo_produto

*/

 select DATEDIFF(DAY,internamento.data_entrada,internamento.data_saida)*servico.custo as total from ClinicGest.Fatura as fatura join ClinicGest.Internamento as internamento on fatura.fatura_internamento = internamento.num_internamento 
     join CLinicGest.Servico as servico on internamento.codigo_servico = servico.codigo_servico

--SELECT DATEDIFF(DAY, (data_entrada),(data_saida)) AS DateDiff from ClinicGest.Internamento

-- select * from ClinicGest.Internamento