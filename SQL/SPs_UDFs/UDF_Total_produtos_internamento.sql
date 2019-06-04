CREATE FUNCTION UDF_Total_Produtos_internamento (@intervencao int) 
RETURNS int   
AS
Begin
declare @totalint int;
set @totalint = (select (IsNull(produto.custo,0)*gasta.quantidade)+(IsNull(produto.custo_de_limp,0)*gasta.quantidade) as  total from ClinicGest.Produto as produto join ClinicGest.ProdutoIntervencao as gasta on produto.codigo_produto=gasta.codigo_produto where gasta.numero_intervencao = @intervencao)

return @totalint
end