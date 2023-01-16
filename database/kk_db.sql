DROP TABLE IF EXISTS administratorius CASCADE;
DROP TABLE IF EXISTS apskritys CASCADE;
DROP TABLE IF EXISTS bukle CASCADE;
DROP TABLE IF EXISTS busena CASCADE;
DROP TABLE IF EXISTS kurjeris CASCADE;
DROP TABLE IF EXISTS marsrutas CASCADE;
DROP TABLE IF EXISTS marsruto_taskas CASCADE;
DROP TABLE IF EXISTS pardavejas CASCADE;
DROP TABLE IF EXISTS pirkejas CASCADE;
DROP TABLE IF EXISTS populiarumas CASCADE;
DROP TABLE IF EXISTS pranesimas CASCADE;
DROP TABLE IF EXISTS pranesimo_tipai CASCADE;
DROP TABLE IF EXISTS rezervacija CASCADE;
DROP TABLE IF EXISTS siuntinys CASCADE;
DROP TABLE IF EXISTS statistika CASCADE;
DROP TABLE IF EXISTS uzsakymas CASCADE;
DROP TABLE IF EXISTS vadovelis CASCADE;
DROP TABLE IF EXISTS vartotojas CASCADE;
DROP TABLE IF EXISTS vartotojo_parduodami_vadoveliai CASCADE;


CREATE TABLE vartotojas (
  id SERIAL PRIMARY KEY,
  vardas varchar(100) NOT NULL,
  pavarde varchar(100) NOT NULL,
  miestas varchar(100) NOT NULL,
  adresas varchar(100) NOT NULL,
  el_pastas varchar(100) NOT NULL,
  pasto_kodas INT NOT NULL,
  slapyvardis varchar(100) NOT NULL,
  slaptazodis varchar(100) NOT NULL,
  vartotojo_ivertinimas varchar(1000) NOT NULL
);


INSERT INTO vartotojas (id, vardas, pavarde, miestas, adresas, el_pastas, pasto_kodas, slapyvardis, slaptazodis, vartotojo_ivertinimas) VALUES
(1, 'Vardenis', 'Pavardenis', 'Kaunas', 'Gatvetestas', 'elpastas@gmail.com', 123456, 'slapyvardis', 'slaptazodis', '13'),
(2, 'antras', 'antra', 'vilnius', 'adresas69', 'antras@gmail.com', 123123, 'antrasis', 'slaptazodis', '4'),
(3, 'Simonas', 'Švelnys', 'Kaunas', 'Varnų takas 420', 'simsve3@gmail.com', 0, 'privatecocktail', 'eldenring', '21');

CREATE TABLE administratorius (
  id SERIAL PRIMARY KEY,
  administratorius_nuo date NOT NULL,
  vartotojo_id INT NOT NULL,
  CONSTRAINT fk_vartotojas
    FOREIGN KEY(vartotojo_id) 
      REFERENCES vartotojas(id)
);

INSERT INTO administratorius (id, administratorius_nuo, vartotojo_id) VALUES
(1, '2022-11-03', 3);



CREATE TABLE apskritys (
  apskritis varchar(100) NOT NULL PRIMARY KEY
);


INSERT INTO apskritys (apskritis) VALUES
('Alytaus apskritis'),
('Kauno apskritis'),
('Klaipėdos apskritis'),
('Marijampolės apskritis'),
('Panevėžio apskritis'),
('Šiaulių apskritis'),
('Tauragės apskritis'),
('Telšių apskritis'),
('Utenos apskritis'),
('Vilniaus apskritis');

CREATE TABLE bukle (
  bukle varchar(50) NOT NULL PRIMARY KEY
);


INSERT INTO bukle (bukle) VALUES
('Naudota'),
('Nauja');


CREATE TABLE busena (
  busena varchar(100) NOT NULL PRIMARY KEY
);


INSERT INTO busena (busena) VALUES
('Atšauktas užsakymas'),
('Gautas užsakymas'),
('Užsakymas įvykdytas'),
('Vežamas pirkinys'),
('Vykdomas užsakymas');



CREATE TABLE kurjeris (
  id SERIAL PRIMARY KEY,
  vairuotojo_pazymejimo_galiojimo_data date NOT NULL,
  menesio_darbo_valandos INT NOT NULL,
  maksimalios_menesio_darbo_valandos INT NOT NULL,
  aptarnaujama_apskritis varchar(100)  NOT NULL,
  fk_vartotojas INT NOT NULL,
  CONSTRAINT fk_apskritis
    FOREIGN KEY(aptarnaujama_apskritis) 
        REFERENCES apskritys(apskritis),
  CONSTRAINT fk_vartotojas1
   FOREIGN KEY(fk_vartotojas) 
      REFERENCES vartotojas(id)
);

INSERT INTO kurjeris (id, vairuotojo_pazymejimo_galiojimo_data, menesio_darbo_valandos, maksimalios_menesio_darbo_valandos, aptarnaujama_apskritis, fk_vartotojas) VALUES
(1, '2022-11-24', 10, 20, 'Alytaus apskritis', 1),
(2, '2022-11-07', 20, 30, 'Utenos apskritis', 1);



CREATE TABLE marsrutas (
  id SERIAL PRIMARY KEY,
  numatoma_trukme INT NOT NULL,
  numatomas_atstumas INT NOT NULL,
  siuntiniu_skaicius INT NOT NULL,
  transporto_priemones_id INT NOT NULL,
  fk_kurjeris INT NOT NULL,
  CONSTRAINT fk_kurjeris1
   FOREIGN KEY(fk_kurjeris) 
      REFERENCES kurjeris(id)
);

INSERT INTO marsrutas (id, numatoma_trukme, numatomas_atstumas, siuntiniu_skaicius, transporto_priemones_id, fk_kurjeris) VALUES
(1, 50, 500, 12, 1, 1),
(2, 200, 1000, 100, 2, 1);

-- --------------------------------------------------------

CREATE TABLE marsruto_taskas (
  id SERIAL PRIMARY KEY,
  koordinates varchar(100) NOT NULL,
  adresas varchar(100) NOT NULL,
  ar_ivykdyta boolean NOT NULL,
  fk_marsrutas INT NOT NULL,
  CONSTRAINT fk_marsrutas1
   FOREIGN KEY(fk_marsrutas) 
      REFERENCES marsrutas(id)
);

INSERT INTO marsruto_taskas (id, koordinates, adresas, ar_ivykdyta, fk_marsrutas) VALUES
(1, '2.000,2.000', 'gatve1', 't', 1),
(2, '1.000,1.000', 'gatve2', 'f', 2);

CREATE TABLE pardavejas (
  id SERIAL PRIMARY KEY,
  Banko_saskaitos_numeris INT NULL,
  fk_vartotojas INT NOT NULL,
  CONSTRAINT fk_vartotojas2
   FOREIGN KEY(fk_vartotojas)
      REFERENCES vartotojas(id)
);

INSERT INTO pardavejas (id, Banko_saskaitos_numeris, fk_vartotojas) VALUES
(1, 1122334455, 2),
(2, 55443322, 1);

CREATE TABLE statistika (
  id SERIAL PRIMARY KEY,
  sudaryta timestamp  NOT NULL,
  data_nuo timestamp  NOT NULL,
  data_iki timestamp  NOT NULL
);


INSERT INTO statistika (id, sudaryta, data_nuo, data_iki) VALUES
(1, '2022-11-01', '2022-11-01', '2022-11-01'),
(2, '2022-11-04', '2022-11-04', '2022-11-04');

CREATE TABLE pirkejas (
  id SERIAL PRIMARY KEY,
  mokejimo_metodas text NOT NULL,
  fk_vartotojas INT NOT NULL,
  CONSTRAINT fk_vartotojas3
   FOREIGN KEY(fk_vartotojas) 
      REFERENCES vartotojas(id)
);

INSERT INTO pirkejas (id, mokejimo_metodas, fk_vartotojas) VALUES
(1, 'Kortele', 1),
(2, 'Per internetinį banką', 3);

CREATE TABLE uzsakymas(
  id SERIAL PRIMARY KEY,
  data date NOT NULL,
  fk_pirkejas INT NOT NULL,
  CONSTRAINT fk_pirkejas2
   FOREIGN KEY(fk_pirkejas) 
      REFERENCES pirkejas(id)
);

INSERT INTO uzsakymas (id, data, fk_pirkejas) VALUES
(0,'2000-01-01',1),
(1, '2022-11-01', 1),
(2, '2022-11-02', 2);



CREATE TABLE populiarumas (
  id SERIAL PRIMARY KEY,
  pop_skaicius INT NOT NULL,
  isbn text NOT NULL
  --fk_vadovelis INT NOT NULL,
  --CONSTRAINT fk_vadovelis
   --FOREIGN KEY(fk_vadovelis) 
      --REFERENCES vadovelis(id)
);

INSERT INTO populiarumas (id, pop_skaicius, isbn) VALUES
(1, 1, '111111111'),
(2, 1, '222222222'),
(3, 1, '333333333');



CREATE TABLE pranesimo_tipai (
  tipas varchar(100) NOT NULL PRIMARY KEY
);

INSERT INTO pranesimo_tipai (tipas) VALUES
('Maršruto pakitimo'),
('Siuntinio būsenos pakitimas'),
('Siuntinio vėlavimo'),
('Žinutė');

CREATE TABLE pranesimas (
  id SERIAL PRIMARY KEY,
  pranesimo_turinys text NOT NULL,
  issiuntimo_data date NOT NULL,
  tipas varchar(100) NOT NULL,
  fk_vartotojas INT NOT NULL,
  CONSTRAINT fk_tipas
   FOREIGN KEY(tipas) 
      REFERENCES pranesimo_tipai(tipas),
  CONSTRAINT fk_vartotojas4
   FOREIGN KEY(fk_vartotojas) 
      REFERENCES vartotojas(id)
);

INSERT INTO pranesimas (id, pranesimo_turinys, issiuntimo_data, tipas, fk_vartotojas) VALUES
(1, 'testssssasas', '2022-11-16', 'Siuntinio būsenos pakitimas', 3);

CREATE TABLE rezervacija (
  id SERIAL PRIMARY KEY,
  pradzia date NOT NULL,
  pabaiga date NOT NULL,
  fk_pirkejas INT NOT NULL,
  fk_pardavejas INT NOT NULL,
  CONSTRAINT fk_pirkejas1
   FOREIGN KEY(fk_pirkejas) 
      REFERENCES pirkejas(id),
  CONSTRAINT fk_pardavejas1
   FOREIGN KEY(fk_pardavejas) 
      REFERENCES pardavejas(id)
);

INSERT INTO rezervacija (id, pradzia, pabaiga, fk_pirkejas, fk_pardavejas) VALUES
(1, '2022-11-01', '2022-11-02', 1, 2),
(2, '2022-11-02', '2022-11-24', 2, 1);


CREATE TABLE siuntinys (
  id SERIAL PRIMARY KEY,
  kliento_vardas_pavarde text NOT NULL,
  kliento_el_pastas text NOT NULL,
  kliento_telefono_nr text NOT NULL,
  buvimo_vieta text NOT NULL,
  busena varchar(100) NOT NULL,
  fk_marsruto_taskas INT NOT NULL,
  fk_uzsakymas INT NOT NULL,
  CONSTRAINT fk_busena
   FOREIGN KEY(busena) 
      REFERENCES busena(busena),
  CONSTRAINT fk_marsruto_taskas
   FOREIGN KEY(fk_marsruto_taskas) 
      REFERENCES marsruto_taskas(id),
  CONSTRAINT fk_uzsakymas3
   FOREIGN KEY(fk_uzsakymas) 
      REFERENCES uzsakymas(id)
);

INSERT INTO siuntinys (id, kliento_vardas_pavarde, kliento_el_pastas, kliento_telefono_nr, buvimo_vieta, busena, fk_marsruto_taskas, fk_uzsakymas) VALUES
(1, 'Vardenis Pavardenis', 'pastas@gmail.com', '123456789', 'Kaunas', 'Gautas užsakymas', 2, 1),
(2, 'Antanas Antanavicius', 'antanas@gmail.com', '987654321', 'Vilnius', 'Atšauktas užsakymas', 1, 2);


CREATE TABLE vadovelis (
  id SERIAL PRIMARY KEY,
  pavadinimas text NOT NULL,
  puslapiu_skaicius INT NOT NULL,
  isbn text NOT NULL,
  fk_populiarumas INT NULL,
  aprasymas text NOT NULL,
  leidejas text NOT NULL,
  metai INT NOT NULL,
  kalba text NOT NULL,
  CONSTRAINT fk_populiarumas1
   FOREIGN KEY(fk_populiarumas)
      REFERENCES populiarumas(id)
);

INSERT INTO vadovelis (id, pavadinimas, puslapiu_skaicius, isbn, aprasymas, leidejas, metai, kalba, fk_populiarumas) VALUES
(1, 'Dievu miskas', 500, '111111111', 'Dievų miškas – memuarinė knyga, parašyta 1945 m. lietuvių rašytojo ir poeto Balio Sruogos. Jame atsispindi rašytojo išgyvenimai nacių Štuthofo koncentracijos stovykloje, į kurią B. Sruoga buvo išsiųstas 1943 m. kovą.', 'Obuolys', 2003, 'Lietuvių', 1),
(2, 'Introduction to Algorithms, 3rd Edition', 2000, '222222222', 'Gali sukelti potrauminio streso sutrikimą', 'Dalius Makackas', 2020, 'Anglų', 2),
(3, 'Matematika tau+', 122, '333333333', 'Matematika tau+ 10 klasė', 'Elmundas Žalys', 2010, 'Lietuvių', 3);

CREATE TABLE vartotojo_parduodami_vadoveliai (
  id SERIAL PRIMARY KEY,
  kaina decimal(5,2) NOT NULL,
  bukle varchar(100) NOT NULL,
  fk_pardavejas INT NOT NULL,
  fk_vadovelis INT NOT NULL,
  fk_uzsakymas INT,
  CONSTRAINT fk_bukle
      FOREIGN KEY(bukle)
          REFERENCES bukle(bukle),
  CONSTRAINT fk_pardavejas2
   FOREIGN KEY(fk_pardavejas) 
      REFERENCES pardavejas(id),
  CONSTRAINT fk_vadovelis1
   FOREIGN KEY(fk_vadovelis) 
      REFERENCES vadovelis(id),
  CONSTRAINT fk_uzsakymas2
   FOREIGN KEY(fk_uzsakymas)
      REFERENCES uzsakymas(id)
);

INSERT INTO vartotojo_parduodami_vadoveliai (id, kaina, bukle, fk_pardavejas, fk_vadovelis, fk_uzsakymas) VALUES
(3, '15.00', 'Nauja', 1, 1, 0),
(4, '50.12', 'Naudota', 2, 2, 0);

COMMIT;