Create proc SP_internamento_entre_datas (@datai date, @dataf date)
as
select cc, nome, patologia from ClinicGest.Internamento as intern join ClinicGest.Paciente as paci on intern.codigo_pac = paci.codigo_pac join ClinicGest.Pessoa as pessoa on paci.cc_pac=pessoa.cc where data_entrada=@datai and data_saida=@datas
