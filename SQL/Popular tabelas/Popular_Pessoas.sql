use p4g9


insert into ClinicGest.Pessoa (cc,nome,telefone,telemovel,email,endereco,codigopostal,nacionalidade,sexo,data_nasc) values
	('112219322zy4','Pedro Fernandes',234351594,917628379,'pedroafernandes@ua.pt','R. Direita 1408','','Portugues','m','1980-10-22'), -- Medico staff
	('146332843yz3','Marta Ferreira',234321094,962634454,'martaferreira@ua.pt','R. das margaridas 23 2 dir','','Portugues','m','1975-04-10'), -- Medico staff
	('202291164xz2','Ana Catarina',234333028,916504200,'anacatarina@nowhere.com','R. do vale 5','','Portugues','m','1989-07-17'), -- Enfermeiro staff
	('905003943ux4','João Tostas',234534221,934567338,'jtostas@nowhere.com','R. de viseu 35 4 esq dir','','Portugues','m','1991-01-28'), -- Enfermeiro staff
	('138699867cc5','Mariana Teixeira',212342234,934324322,'pedroafernandes@ua.pt','R. Direita 38','','Portugues','m','1972-12-31'), -- paciente
	('149968011xy5','Paola Pastrani',234321094,918832422,'paolapastrani@universitadepalermo.it','R. de Alcohete 27','','Italiana','m','2000-10-01'), -- Paciente
	('189655973zy4','Joana Pereira',256711584,964342325,'jpereira@nowhere.com','Av. 31 de Fevereiro 45','','Portugues','m','1953-09-08'), -- Paciente
	('211313341ew4','Micaek Jonas',231322178,917726311,'mjonas@nowhere.com','Av. ladonenhum 44 1 esq','','Lituano','m','1983-04-22'), -- Medico
	('265333212sd5','João Gaspa',231323478,915790311,'jgaspar@hotmail.com','R. nenhures 22 3 esq','','Brasileiro','m','1994-01-22'), -- Medico
	('233445442et5','Fabio Fernandes',234367594,913675942,'fabiofernandes@hotmail.com','R. Essquerda 108','','Portugues','m','1986-11-22'),  -- Enfermeiro
    ('233443342ef1','Francisco Silva',232367594,911776543,'franciscos19@hotmail.com','R. Essquerda 108','','Portugues','m','2000-07-12'), -- Enfermeiro
    ('233443342rt4','Rita Silva',232367594,911776543,'rita.silva00@hotmail.com','R. Essquerda 108','','Portugues','f','2000-12-12'), -- Enfermeiro
    ('243445642zz7','Monica Fagundes',234553675,914563673,'nursemfagundes@nurses.gov.uk','R. dos lirios 54','','portugues','f','1987-09-09'), --Enfermeiro
    ('230965642zz7','Steven Fagundes',234553675,914563673,'nursefagundes@nurses.gov.uk','R. dos lirios 54','','Ingles','f','1984-04-09'), -- Enfermeiro
	('11277562zy4','Dilan Nunes',234322294,917222379,'thedilan@ua.pt','R. da estação 169 3 esq','','Portugues','m','1999-05-29'), -- Paciente
	('11274442uy4','Miguel Carvalhosa',234324556,967222379,'miguelfalo@nowhere.pt','R. da amália 9 2 esq','','Portugues','m','2005-01-29'), -- Paciente
	('11274345uy4','Diogo Veiga',222327856,917275379,'didiveiga@netcom.pt','R. estevão souza 5 5 dir','','Portugues','m','1997-01-23'), -- Paciente
    ('19844345tr7','Rosa Duarte',222437889,945273479,'rosinha@ratman.pt','R. da república 23 6 A','','Portugues','f','1965-09-13'), -- Paciente
    ('14544345fr9','Deolinda Gomes',211456888,943473779,'deogomes@deogratias.vc','R. de st antónio 13','','Portugues','f','1940-05-13'), -- Paciente
    ('19866345tr9','Joaquim Silva',212445889,914473900,'santossilva80@defmin.gov','R. engenheiro jose costa 4','','Portugues','m','1986-05-29'), -- Paciente
    ('19333345zr7','Salgueiro Maia',242337500,925443398,'salgmaia@democrat.pt','R. da democracia 25','','Portugues','f','1974-04-25'), -- Paciente
    ('298453445tb7','Jose Chamas',244457689,946673456,'zezecam@futball.pt','R. von hoff 4 3 esq','','Portugues','m','1974-03-25'), -- Paciente
    ('19844545tg1','António Santos',232337859,945276969,'antonio@deogratias.vc','R. sta luzia 12','','Italiano','m','1939-05-24'), -- Paciente
    ('13444345er7','Ana Matos',222437842,945222479,'anamatos@fogo.pt','R. dos incendios 23 6 A','','Portugues','f','1965-09-13'), -- Paciente
	('13544745ey8','Florinda Gomes',225537689,945274569,'flogomes@google.pt','R. praça da alegria 4 C','','Portugues','f','1975-03-16'), -- Paciente
	('13446645nm7','Ramiro Costa',234456889,945273470,'ramirocosta@minsaude.gov.pt','R. dos leões 5','','Portugues','m','1985-09-13'), -- Medico
	('33245685fg6','Barbara Almeida',235987889,945273534,'barbalmeida@minsaude.gov.pt','R. filipa bastos 5 1 esq','','Frances','f','1972-08-05'), -- Medico
	('23646645gm7','Abdu Yosef',237456580,949274470,'abduyosef@minsaude.gov.pt','R. alibaba 14','','Israelita','m','1990-09-13'), -- Enfermeiro
	('15449645zm6','Carmindo Lopes',224456789,945553470,'carmindo85@panquecas.fr','R. 27 de Maio 8 3 dir','','Portugues','m','1985-09-25'), -- Paciente
	('13546745fr9','Jean Pierre',234446000,945200456,'jeanpierre@franciu.fr','R. torre eifel 20','','Frances','m','1930-09-13'), -- Paciente
	('11436645pt7','Afonso Terceiro',234114389,945271143,'afonso3@egitanea.pt','R. torre dos ferreiros 5 4 dir','','Portugues','m','1965-02-26'), -- Paciente
	('55646645pt7','Maria Josefa',234009889,945273576,'mariaprims@casareal.rp','R. infanta maria 5 3','','Portugues','f','1976-09-13'), -- Medico
	('11596645sp7','Mourinho Casilhas',234456837,945273437,'mourinho@fcp.pt','R. benfica 37 19','','Portugues','m','1980-09-13'), -- Enfermeiro
	('18066645ru1','Anastasia Nikolaevna',234551901,956811918,'anastacia@czar.gov.ru','R. czarina maria 4 5','','Russo','f','1998-07-17'), -- Medico
	('19516645en7','Winston Churchill',237751940,952731945,'whstchurch@minhealth.gov.en','R. downing 10','','Ingles','m','1965-01-24'), -- Enfermeiro
	('13441814fr0','Napoleon Francisco',231251811,945271932,'napoleon2@grandarmee.fr','R. de viena 6 12','','Frances','m','1932-07-22'), -- Medico
	('13963245at5','Sofia Maria',201031868,928061914,'sofia1868@wienn.at','R. von fluffen 9 1 esq','','Austriaco','f','1968-03-01'), -- Enfermeiro
	('19216645bt7','Filipe Mountbatten',220111947,910061921,'philedi@windsor.bt','R. da grécia 2 6 esq','','Ingles','m','1921-06-10'), -- Enfermeiro
	('19456645se3','Gustav Adolfo',211111882,915091973,'gusadolf@swedenmon.se','R. de helsingborg 2 3','','Sueco','m','1950-10-29'), -- Paciente
	('19726645fi7','Frederico Glucsburgo',211031899,914011972,'frednono@finmonark.fi','R. de lungby 11 2 frt','','Filandes','m','1972-01-14'), -- Paciente
	('19826645mn6','Graça Patricia',212111929,914091982,'gracekel@monacolife.mc','R. de monte cristo 25','','Americano','f','1929-11-12'), -- Paciente
	('14562645pt7','Inácio Frederiques',237832889,915271917,'cristoeosenhor@tugaflix,vc','R. dos leões 10','','Portugues','f','1985-09-13'), -- Paciente
	('13229945tu5','Felisberta Contente',234552219,933379512,'felisecont@portocanal.ru','R. porto 8 9','','Portugues','f','1955-01-18'), -- Paciente
	('19806645eg1','Manuel Lopes',239535641,925071940,'manelalb@family.pt','R. de albardo 1 2','','Portugues','m','1940-04-15'), -- Enfermeiro
	('13456445pt7','Ana do Palanque',234451950,945271997,'anamarques@family.pt','R. dos palanques 10','','Portugues','f','1997-08-31'), -- Enfermeiro
	('13121645pt2','Antonio Gonçalves',222455541,945275555,'oinotna69@mindef.gov.pt','R. dr joão 45 3 frt','','Portugues','m','1969-11-16'), -- Enfermeiro
	('36516575ru7','Azimov Perezchenko',238282889,925271983,'azimovrules@haiti.ru','R. azimov krukz 2','','Russa','m','1967-12-04'), -- Enfermeiro
	('11919645cz6','Karmira Potokz',211452016,955271968,'karmi1968@inthesky.cz','R. dos passarinhos 6 9','','Checa','f','1968-11-05') -- Enfermeiro

insert into ClinicGest.Staff (cc_staff,salario) values
	('112219322zy4',3000),
	('146332843yz3',3000),
	('202291164xz2',2000),
	('905003943ux4',1900),
	('211313341ew4',2300),
	('265333212sd5',4200),
	('233445442et5',1500),
	('233443342ef1',1600),
	('233443342rt4',1800),
	('243445642zz7',2500),
	('230965642zz7',3200),
	('13446645nm7',2700),
	('33245685fg6',2000),
	('23646645gm7',1850),
	('55646645pt7',1600),
	('11596645sp7',1790),
	('18066645ru1',2100),
	('19516645en7',2000),
	('13441814fr0',2300),
	('13963245at5',1900),
	('19216645bt7',1500),
	('19806645eg1',1400),
	('13456445pt7',1600),
	('13121645pt2',1300),
	('36516575ru7',1500),
	('11919645cz6',1700)
	
	
	


insert into ClinicGest.Paciente (cc_pac) values
	('138699867cc5'),
	('149968011xy5'),
	('189655973zy4'), 
	('11277562zy4'),
	('11274442uy4'),
    ('19844345tr7'), 
    ('14544345fr9'), 
    ('19866345tr7'), 
    ('19333345zr7'),
    ('298453445tb7'),
    ('19844545tg7'),
    ('13444345er7')


insert into ClinicGest.Enfermeiro (codigo_staff)
select codigo_staff from ClinicGest.Staff
where cc_staff in ('112219322zy4','146332843yz3','233445442et5','233443342ef1','230965642zz7','233443342rt4','243445642zz7','23646645gm7','11596645sp7','19516645en7','13963245at5','19216645bt7','19806645eg1','13456445pt7','13121645pt2','36516575ru7','11919645cz6')
	

insert into ClinicGest.Medico (especialidade, codigo_staff) values
	('Geral',(select codigo_staff from ClinicGest.Staff where cc_staff = '202291164xz2')),
	('Ortopedia', (select codigo_staff from ClinicGest.Staff where cc_staff = '905003943ux4')),
	('Geral',(select codigo_staff from ClinicGest.Staff where cc_staff = '211313341ew4')),
	('Cirurgia',(select codigo_staff from ClinicGest.Staff where cc_staff = '265333212sd5')),
	('Geral',(select codigo_staff from ClinicGest.Staff where cc_staff = '13446645nm7')),
	('Geral',(select codigo_staff from ClinicGest.Staff where cc_staff = '33245685fg6')),
	('Geral',(select codigo_staff from ClinicGest.Staff where cc_staff = '55646645pt7')),
	('Interno',(select codigo_staff from ClinicGest.Staff where cc_staff = '19806645eg1')),
	('Geral',(select codigo_staff from ClinicGest.Staff where cc_staff = '13441814fr0'))	

