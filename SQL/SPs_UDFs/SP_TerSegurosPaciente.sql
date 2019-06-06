CREATE PROC SP_TerSegurosPaciente @paciente int
AS
Select * from ClinicGest.TemSeguro as temseguro join ClinicGest.Seguro as seguro on temseguro.cod_seguro = seguro.codigo_seguro where  cod_paciente = @paciente

GO