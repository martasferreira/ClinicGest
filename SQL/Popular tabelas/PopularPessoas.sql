use p4g9

insert into ClinicGest.Pessoa (cc,nome,telefone,telemovel,email,endereco,codigopostal,nacionalidade,sexo,data_nasc) values
	('112219322zy4','Pedro Fernandes',234351594,917628379,'pedroafernandes@ua.pt','R. Direita 1408','','Portugues','m','1980-10-22'), -- medico staff
	('146332843yz3','Marta Ferreira',234321094,962634454,'martaferreira@ua.pt','R. das margaridas 23 2 dir','','Portugues','m','1975-04-10'), -- medico staff
	('202291164xz2','Ana Catarina',234333028,916504200,'anacatarina@nowhere.com','R. do vale 5','','Portugues','m','1989-07-17'), -- Enfermeiro staff
	('905003943ux4','João Tostas',234534221,934567338,'jtostas@nowhere.com','R. de viseu 35 4 esq dir','','Portugues','m','1991-01-28'), -- Enfermeiro staff
	('138699867cc5','Mariana Teixeira',212342234,934324322,'pedroafernandes@ua.pt','R. Direita 38','','Portugues','m','1972-12-31'), -- paciente
	('149968011xy5','Paola Pastrani',234321094,918832422,'paolapastrani@universitadepalermo.it','R. de Alcohete 27','','Italiana','m','2000-10-01'), -- paciente
	('189655973zy4','Joana Pereira',256711584,964342325,'jpereira@nowhere.com','Av. 31 de Fevereiro 45','','Portugues','m','1953-09-08') --paciente

insert into ClinicGest.Staff (cc_staff,salario) values
	('112219322zy4',3000),
	('146332843yz3',3000),
	('202291164xz2',2000),
	('905003943ux4',1900)

insert into ClinicGest.Paciente (cc_pac) values
	('138699867cc5'),
	('149968011xy5'),
	('189655973zy4')

insert into ClinicGest.Enfermeiro (codigo_emp)
select codigo_staff from ClinicGest.Staff
where cc_staff in ('112219322zy4','146332843yz3')
	
insert into ClinicGest.Medico (especialidade, codigo_emp) values
	('Geral',(select codigo_staff from ClinicGest.Staff where cc_staff = '202291164xz2')),
	('Ortopedia', (select codigo_staff from ClinicGest.Staff where cc_staff = '905003943ux4'))
