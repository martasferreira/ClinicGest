use p4g9

insert into ClinicGest.Pessoa (cc,nome,telefone,telemovel,email,endereco,codigopostal,nacionalidade,sexo,data_nasc) values
	('112219322zy4','Pedro Fernandes','234351594','917628379','pedroafernandes@ua.pt','R. Direita 1408 1h','','Portugues','m','19780424'), -- medico staff
	('146332843yz3','Marta Ferreira','234321094','962634454','martaferreira@ua.pt','R. das margaridas 23 2 dir','','Portugues','f','19911125'), -- medico staff
	('202291164xz2','Ana Catarina','234333028','916504200','anacatarina@nowhere.com','R. do vale 5','','Portugues','f','19810115'), -- Enfermeiro staff
	('905003943ux4','João Tostas','234534221','934567338','jtostas@nowhere.com','R. de viseu 35 4 esq dir','','Portugues','m','19760105'), -- Enfermeiro staff
	('138699867cc5','Mariana Teixeira','212342234','934324322','pedroafernandes@ua.pt','R. Direita 38 1h','','Portugues','f',''), -- Enfermeiro staff
	('149968011xy5','Paola Pastrani','234321094','918832422','paolapastrani@universitadepalermo.it','R. de Alcohete 27 7u','','Italiana','f','19950205'), -- Enfermeiro staff
	('189655973zy4','Joana Pereira','256711584','964342325','jpereira@nowhere.com','Av. 31 de Fevereiro 45 1h','','Portugues','f','20010707'), --paciente Y
	('113332843yz3','Hugo Almeida','234333428','967755432','hugo.almeida@oli-world.com','R. das flores 23 6 dir','','Portugues','m','19820406'), -- paciente 
	('121291164xz2','Jose Guilherme','234333028','923345890','jose.guilherme@matobra.com','Praceta da alegria 12','','Portugues','m','19850422'), -- paciente
	('210032943zt2','Tiago Pinho','256534221','','tpinho@nowhere.com','R. CSGO n87 2 dir','','Portugues','m','19990402'), -- paciente
	('228699867cc5','Francisco Pinto','212542234','934446654','francisco.pinto@nowhere.com','R. Direita 188 1 frente','','Portugues','m','19940531') -- paciente
--	(149968011xy5,Paula Pastrani,234321094,pastrani@universitadepalermo.it,R. de Alcohete 27 7u, ,Italiana,m,data_nasc)
--	(202291164xz2,Ana Catarina,234333028,anacatarina@nowhere.com,R. do vale 5, ,Portugues,m,data_nasc)
--	(905003943ux4,João Tostas,234534221,joao.tostas@nowhere.com,R. de viseu 35 4 esq dir, ,Portugues,m,data_nasc)
--	(138699867cc5,Mariana Teixeira,212342234,pedroafernandes@ua.pt,R. Direita 1408 1h, ,Portugues,m,data_nasc)
--	(149968011xy5,Paula Pastrani,234321094,pastrani@universitadepalermo.it,R. de Alcohete 27 7u, ,Italiana,m,data_nasc)

insert into ClinicGest.Staff (codigo_staff,cc_staff,salario) values
	('1','112219322zy4','3000'),
	('2','146332843yz3','3000'),
	('3','202291164xz2','2000'),
	('4','905003943ux4','1900')
--	(5,138699867cc5,1650)
--	(6,149968011xy5,2100)

insert into ClinicGest.Paciente (codigo_pac,cc_pac) values
	('100','189655973zy4'),
	('101','113332843yz3'),
	('102','121291164xz2'),
	('103','210032943zt2'),
	('104','228699867cc5')

insert into ClinicGest.Enfermeiro (codigo_emp,codigo_enf) values
	('1','enferme001')	
	
insert into ClinicGest.Medico (codigo_emp,codigo_med,especialidade) values
	('1','medicocod1','Geral'),
	('2','medicocod2','Ortopedia')
	
insert into ClinicGest.Medicamento (codigo_medicamento,nome,preco_unitario) values
	('1','tolamex','3'),
	('2','farmax','1'),
	('3','beeral','2')
	
insert into ClinicGest.Produto (codigo_produto,tipo_produto,custo,custo_de_limp) values
 ('1','Seringa',1,0),
 ('2','Soro',2,0)
 ('3','tesoura',null,0.10)
	
	
insert into ClinicGest.Servico (codigo_servico,nome,custo,medico_responsavel,medico_trabalha,enfermeiro_responsavel,enfermeiro_trabalha) values
	('1','Medicina Geral 1','50','1','','1','1')
--	('2','Medicina Geral 2','40','2')	
	