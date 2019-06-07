CREATE PROC SP_TerReceitaMedicaMedico @medico int
AS
SELECT * from ClinicGest.Receitamedica as receita where receita.receita_medico = @medico

GO

