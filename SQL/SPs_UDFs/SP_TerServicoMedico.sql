CREATE PROC SP_TerServicoMedico @medico_responsavel int
AS
select * from ClinicGest.Servico as Servicos where Servicos.medico_responsavel = @medico_responsavel
GO