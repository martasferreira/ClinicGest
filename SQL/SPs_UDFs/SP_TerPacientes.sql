CREATE PROC SP_TerPacientes
AS
SELECT * FROM ClinicGest.Pessoa JOIN ClinicGest.Paciente ON Pessoa.cc = Paciente.cc_pac

GO