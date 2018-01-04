CREATE TABLE TipNamestaja (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(80),
	Obrisan BIT
)
GO

CREATE TABLE Namestaj (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	TipNamestajaId INT,
	Naziv VARCHAR(100),
	JedinicnaCena NUMERIC(9,2),
	KolicinaUMagacinu INT,
	Sifra varchar(50),
	Obrisan BIT,
	FOREIGN KEY (TipNamestajaId) REFERENCES TipNamestaja(Id)
)
GO

CREATE TABLE Korisnik
(
	
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Ime VARCHAR(15) not null, 
	Prezime VARCHAR(15) not null,
	KorisnickoIme VARCHAR(20) not null,
	Lozinka VARCHAR(20) not null,
	Tipkorisnika VARCHAR(15) not null,
	Obrisan BIT not null,

)
GO

CREATE TABLE DodatnaUsluga
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(20) not null,
	Cena NUMERIC(9,2),
	Obrisan BIT not null
)

CREATE TABLE Salon
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(20) not null,
	Adresa varchar(20) not null,
	Telefon varchar(20) not null,
	Email varchar(20) not null,
	AdresaSajta varchar(20) not null,
	Pib int,
	MaticniBroj int,
	ZiroRacun varchar(20) not null

)

CREATE TABLE Akcija
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(20) not null,
	DatumPocetka datetime,
	DatumKraja datetime,
	Obrisan BIT

)

CREATE TABLE NaAkciji
(
	IdAkcija INT foreign key references Akcija(Id),
	IdNamestaj INT foreign key references Namestaj(Id),
	Popust Numeric(9, 2)

)