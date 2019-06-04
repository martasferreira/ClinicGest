CREATE PROC SP_Custo_Total_de_Produtos
AS
select  (IsNull(produto.custo,0)*gasta.quantidade)+(IsNull(produto.custo_de_limp,0)*gasta.quantidade) as  total from ClinicGest.Produto as produto join ClinicGest.ProdutoIntervencao as gasta on produto.codigo_produto=gasta.codigo_produto

GO


