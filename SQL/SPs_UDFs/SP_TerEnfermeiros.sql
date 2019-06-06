 CREATE PROC SP_TerEnfermeiros
 AS
SELECT * from ClinicGest.Pessoa AS pessoa JOIN ClinicGest.Staff AS staff ON pessoa.cc = staff.cc_staff JOIN ClinicGest.Enfermeiro AS enfermeiro ON staff.codigo_staff = enfermeiro.codigo_staff

GO