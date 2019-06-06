 CREATE PROC SP_TerMedicos
 AS
SELECT * from ClinicGest.Pessoa AS pessoa JOIN ClinicGest.Staff AS staff ON pessoa.cc = staff.cc_staff JOIN ClinicGest.Medico AS medico ON staff.codigo_staff = medico.codigo_staff

GO