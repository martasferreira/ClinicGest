CREATE PROC SP_TerProdutosIntervencao @intervencao int
AS
SELECT * FROM ClinicGest.ProdutoIntervencao gp RIGHT JOIN ClinicGest.Produto p ON gp.codigo_produto = p.codigo_produto WHERE gp.numero_intervencao = @intervencao
			
GO