CREATE DATABASE KARIYER

create table users(
kid int primary key identity(1,1),
kadi varchar(50) unique,
parola varchar(50),
rol varchar(50)
)

create table il(
il_kodu int primary key identity(1,1),
il_adi varchar(50) unique,
)


create table ilce(
ilce_kodu int primary key identity(1,1),
ilce_adi varchar(50) unique,
il_kodu int not null
)




create table sektor(
sektor_id int primary key identity(1,1),
sektor_adi varchar(50) not null,
sektor_tanimi varchar(50) not null
)

create table mesaj(
mesaj_id int primary key identity(1,1),
name varchar(50) not null,
title varchar(50) not null,
message varchar(50) not null
)



create table isyeri(
is_yeri_id int primary key identity(1,1),
ilce_id int not null,
is_yeri_adi varchar(50) not null,
sektor_id int not null
)




create table departman(
departman_id int primary key identity(1,1),
departman_adi varchar(50) unique,
departman_tanimi varchar(50) not null
)

create table pozisyon(
pozisyon_id int primary key identity(1,1),
pozisyon_adi varchar(50) unique
)


create table egitim(
egitim_id int primary key identity(1,1),
egitim_adi varchar(50) unique,
egitim_tanimi varchar(50) not null
)

create table isi(
is_id int primary key identity(1,1),
pozisyon_id int not null,
departman_id int not null,
egitim_id int not null,
is_yeri_id int not null
)








create table isisci(
is_isci_id int primary key identity(1,1),
is_id int not null,
kid int not null
)




ALTER TABLE isisci
ADD CONSTRAINT FK_is_id
FOREIGN KEY (is_id)  REFERENCES isi(is_id)




ALTER TABLE isisci
ADD CONSTRAINT FK_isci_id2
FOREIGN KEY (kid)  REFERENCES users(kid)

ALTER TABLE isi
ADD CONSTRAINT FK_pozisyon_id
FOREIGN KEY (pozisyon_id) REFERENCES pozisyon(pozisyon_id)

ALTER TABLE ilce
ADD CONSTRAINT FK_il_id
FOREIGN KEY (il_kodu) REFERENCES il(il_kodu);

ALTER TABLE isi
ADD CONSTRAINT FK_departman_id
FOREIGN KEY (departman_id) REFERENCES departman(departman_id)

ALTER TABLE isyeri
ADD CONSTRAINT FK_ilce_id2
FOREIGN KEY (ilce_id) REFERENCES ilce(ilce_kodu)

ALTER TABLE isyeri
ADD CONSTRAINT FK_sektor_id
FOREIGN KEY (sektor_id) REFERENCES sektor(sektor_id)

ALTER TABLE isi
ADD CONSTRAINT FK_egitim_id
FOREIGN KEY (egitim_id) REFERENCES egitim(egitim_id)




ALTER TABLE isi
ADD CONSTRAINT FK_is_yeri_id2
FOREIGN KEY (is_yeri_id) REFERENCES isyeri(is_yeri_id)