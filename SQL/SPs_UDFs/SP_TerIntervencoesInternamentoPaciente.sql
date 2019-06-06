CREATE PROC SP_TerIntervencoesInternamentoPaciente @internamento int
AS
SELECT * FROM ClinicGest.Intervencao WHERE num_internamento = @internamento

GO