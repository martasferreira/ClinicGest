create proc SP_Staff_que_ganha_mais_k (@valor int)
as
select nome,cc,telemovel,salario from ClinicGest.Pessoa as contacto join ClinicGest.staff as staffo on contacto.cc=staffo.cc_staff where staffo.salario >= @valor