/*CREATE FUNCTION UDF_Calcula_Desconto (@final decimal(5,2));
RETURNS decimal   
AS
BEGIN
declare @totalint int, @desconto int, decimal(5,2);
set @totalint = (select (IsNull(produto.custo,0)*gasta.quantidade)+(IsNull(produto.custo_de_limp,0)*gasta.quantidade) as  total from ClinicGest.Produto as produto join ClinicGest.ProdutoIntervencao as gasta on produto.codigo_produto=gasta.codigo_produto where gasta.numero_intervencao = @intervencao);
set @desconto = (select (seg.codigo_seguro) , (pacienteseguro.cod_seguro) as descontar from ClinicGest.Seguro as seg join Clinicgest.TemSeguro as pacienteseguro on seg.codigo_seguro=pacienteseguro.cod_seguro where pacienteseguro.cod_seguro=@segurofat);
set @final = @totalint - @desconto;
RETURNS @final;

END*/

-- needs some work