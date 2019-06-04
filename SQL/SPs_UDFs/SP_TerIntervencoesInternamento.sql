CREATE PROC SP_TerIntervencoesInternamento @internamento int
AS
SELECT * FROM ClinicGest.Intervencao WHERE num_internamento = @internamento

GO