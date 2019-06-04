CREATE PROC SP_TerEnfermeiroServico @servico int
AS
SELECT * from ClinicGest.Pessoa AS pessoa JOIN ClinicGest.Staff AS staff ON pessoa.cc = staff.cc_staff JOIN ClinicGest.Enfermeiro AS enfermeiro ON staff.codigo_staff = enfermeiro.codigo_staff JOIN ClinicGest.Servico as servico on enfermeiro.trabalha_servico = servico.codigo_servico where servico.codigo_servico = @servico


GO