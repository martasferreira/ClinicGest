use p4g9

insert into ClinicGest.Pessoa (cc,nome,telefone,telemovel,email,endereco,codigopostal,nacionalidade,sexo,data_nasc) values
	('113332843yz3','Hugo Almeida','234333428','967755432','hugo.almeida@oli-world.com','R. das flores 23 6 dir','','Portugues','m','19820406'), -- paciente 
	('121291164xz2','Jose Guilherme','234333028','923345890','jose.guilherme@matobra.com','Praceta da alegria 12','Portugues','m','19850422') -- paciente
	
insert into ClinicGest.Paciente (codigo_pac,cc_pac) values
	('101','113332843yz3'),
	('102','121291164xz2')