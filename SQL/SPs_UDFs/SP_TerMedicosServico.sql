CREATE PROC SP_TerMedicosServico @servico int
AS
Select * from ClinicGest.Medicoemservico as medicoemservico join ClinicGest.Medico as Medico on medicoemservico.codigo_med = Medico.codigo_med join clinicGest.Staff as Staff on Staff.codigo_staff = Medico.codigo_staff join ClinicGest.Pessoa as pessoa on Staff.cc_staff = pessoa.cc where codigo_servico = @servico

GO