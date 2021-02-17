CREATE DATABASE CeuEscuro;
USE CeuEscuro;

CREATE TABLE [dbo].[TipoUsuario]
(
    [IdTipoUsuario] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [DescricaoTipoUsuario] NVARCHAR(13) NOT NULL 

);

CREATE TABLE [dbo].[Usuario] (
    [IdUsuario] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [NomeUsuario] NVARCHAR (50) NOT NULL,
    [CpfUsuario] NVARCHAR (14) UNIQUE NOT NULL,
    [SenhaUsuario] NVARCHAR (6) NOT NULL,
    [DataNascUsuario] NVARCHAR (10) NOT NULL,
	[UrlImgUsuario] NVARCHAR (MAX) NOT NULL,
    [TipoUsuario]INT NOT NULL,
	
   FOREIGN KEY (TipoUsuario) REFERENCES TipoUsuario(IdTipoUsuario)
);

--INSERT
INSERT INTO Usuario VALUES('Cerjio','111.111.111-01','111111','20/02/2001','~/Imagens/img1.jpg',1);
INSERT INTO Usuario VALUES('Marsia','111.111.111-02','222222','20/02/2002','~/Imagens/img2.jpg',2);
INSERT INTO Usuario VALUES('Jandiro','111.111.111-03','333333','20/02/2003','~/Imagens/img3.jpg',2);
INSERT INTO Usuario VALUES('Heleno','111.111.111-04','444444','20/02/2004','~/Imagens/img4.jpg',2);

--INSERT
INSERT INTO TipoUsuario VALUES('Administrador');
INSERT INTO TipoUsuario VALUES('Outros');

SELECT * FROM Usuario;
SELECT * FROM TipoUsuario;