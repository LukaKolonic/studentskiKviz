Create database kviz

go

create table Korisnik(
idKorisnik int primary key identity,
ime nvarchar(50) not null,
prezime nvarchar(50) not null,
email nvarchar(50) constraint uq unique,

)
go
create table kviz(
Idkviz int primary key identity,
naziv nvarchar(50) not null,
korisnikid int foreign key references Korisnik(idKorisnik)
)
go
create table pitanje(
Idpitanje int primary key identity,
tekst nvarchar(150) not null,
kvizid int foreign key references kviz(Idkviz)
)
go
create table odgovor(
Idodgovor int primary key identity,
tekst nvarchar(40) not null,
tocan bit, 
pitanjeid int foreign key references pitanje(Idpitanje)
)