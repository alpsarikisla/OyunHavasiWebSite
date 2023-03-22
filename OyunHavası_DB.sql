CREATE DATABASE oyunhavasi_DB
GO
USE oyunhavasi_DB
GO
CREATE TABLE YoneticiTurleri
(
	ID int IDENTITY(1,1),
	Isim nvarchar(20),
	CONSTRAINT pk_YoneticiTurleri PRIMARY KEY(ID)
)
GO
INSERT INTO YoneticiTurleri(Isim) VALUES('Admin')
INSERT INTO YoneticiTurleri(Isim) VALUES('Yazar')
GO
CREATE TABLE Yoneticiler
(
	ID int IDENTITY(1,1),
	YoneticiTur_ID int,
	Isim nvarchar(50),
	Soyisim nvarchar(50),
	KullaniciAdi nvarchar(20),
	Mail nvarchar(120),
	Sifre nvarchar(12),
	Durum bit,
	CONSTRAINT pk_Yoneticiler PRIMARY KEY(ID),
	CONSTRAINT fk_YoneticiYoneticiTur FOREIGN KEY(YoneticiTur_ID)
	REFERENCES YoneticiTurleri(ID)
)
GO
Insert INTO Yoneticiler(YoneticiTur_ID,Isim,Soyisim,KullaniciAdi,Mail,Sifre,Durum)
VALUES(1,'John', 'Doe','JoDo', 'jodo26@hotmail.com','1234', 1)
GO
CREATE TABLE Kategoriler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(20),
	CONSTRAINT pk_Kategoriler PRIMARY KEY(ID)
)
GO
CREATE TABLE Uyeler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50),
	Soyisim nvarchar(50),
	KullaniciAdi nvarchar(20),
	Mail nvarchar(120),
	Sifre nvarchar(12),
	UyelikTarihi Date,
	Durum bit,
	CONSTRAINT pk_Uyeler PRIMARY KEY(ID)
)
GO
CREATE TABLE Makaleler
(
	ID int IDENTITY(1,1),
	Kategori_ID int,
	Yazar_ID int,
	Baslik nvarchar(200),
	Ozet nvarchar(1000),
	Icerik ntext,
	KapakResim nvarchar(50),
	GoruntulemeSayi int,
	BegeniSayi int,
	EklemeTarihi Date,
	YayinDurumu bit,
	Silinmis bit,
	CONSTRAINT pk_Makaleler PRIMARY KEY(ID),
	CONSTRAINT fk_MakaleKategori FOREIGN KEY(Kategori_ID)
	REFERENCES Kategoriler(ID),
	CONSTRAINT fk_MakaleYonetici FOREIGN KEY(Yazar_ID)
	REFERENCES Yoneticiler(ID)
)
GO
CREATE TABLE Yorumlar
(
	ID int IDENTITY(1,1),
	Uye_ID int,
	Makale_ID int,
	Icerik nvarchar(500),
	EklemeTarihi DateTime,
	BegeniSayi int,
	Durum bit,
	CONSTRAINT pk_Yorumlar PRIMARY KEY(ID),
	CONSTRAINT fk_YorumUye FOREIGN KEY(Uye_ID)
	REFERENCES Uyeler(ID),
	CONSTRAINT fk_YorumMakale FOREIGN KEY(Makale_ID)
	REFERENCES Makaleler(ID)
)
