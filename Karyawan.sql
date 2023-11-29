-- Membuat Database
CREATE DATABASE STA;

-- Menggunakan Database yang baru dibuat
USE STA;

-- Membuat Tabel
CREATE TABLE DataKaryawan (
    IDKaryawan VARCHAR(30) PRIMARY KEY,
    NmKaryawan VARCHAR(30),
    TglMasukKerja DATETIME,
    Usia INT
);
