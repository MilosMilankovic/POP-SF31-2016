
--TIP NAMESTAJA--

INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES ('Krevet', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES ('Ugaona garnitura', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES ('Kauc', 0);

--NAMESTAJ--

INSERT INTO Namestaj (TipNamestajaId, Naziv, JedinicnaCena, KolicinaUMagacinu, Sifra, Obrisan)
VALUES (1, 'Francuski krevet', 123.5, 22,'Fr1kr', 0);

INSERT INTO Namestaj (TipNamestajaId, Naziv, JedinicnaCena, KolicinaUMagacinu,Sifra, Obrisan)
VALUES (2, 'Sofija ugaona', 223.9, 12,'So2ug',0);

INSERT INTO Namestaj (TipNamestajaId, Naziv, JedinicnaCena, KolicinaUMagacinu,Sifra, Obrisan)
VALUES (3, 'Ivan kauc', 723.5, 2,'Iv3ka', 0);

--KORISNik--

INSERT INTO Korisnik(Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan) 
VALUES ('Milos', 'Milankovic', 'Milos123', 'milos', 'Administrator', 0)

INSERT INTO Korisnik(Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan) 
VALUES ('Drasko', 'Draskovic', 'Drasko123', 'drasko', 'Prodavac', 0)

--Dodatna USLUGA--

INSERT INTO DodatnaUsluga(Naziv, Cena, Obrisan)
VALUES('Montaza', 3500, 0)

INSERT INTO DodatnaUsluga(Naziv, Cena, Obrisan)
VALUES('Prevoz', 1500, 0)



--SALON--

INSERT INTO Salon(Naziv, Adresa, Telefon, Email, AdresaSajta, Pib, MaticniBroj, ZiroRacun)
Values('Lenovo','Danila Kis', '2031-231', 'wae@gmail.com', 'www.lenovo.com', 2314, 321456421, '432-3526-32');


--AKCIJA--

INSERT INTO Akcija(Naziv, DatumPocetka, DatumKraja, Obrisan)
Values ('Prolecna', '2017-01-12', '2018-01-02', 0);

INSERT INTO Akcija(Naziv, DatumPocetka, DatumKraja, Obrisan)
Values ('Zimska', '2018-01-01', '2018-03-01', 0);

---NA AKCIJI---

INSERT INTO NaAkciji(IdAkcija, IdNamestaj, Popust)
VALUES (1, 1, 10);

INSERT INTO NaAkciji(IdAkcija, IdNamestaj, Popust)
VALUES (1, 3, 15);

INSERT INTO NaAkciji(IdAkcija, IdNamestaj, Popust)
VALUES (2, 2, 20);