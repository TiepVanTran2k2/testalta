CREATE DATABASE QuanLyHocVien;

USE QuanLyHocVien;

CREATE TABLE HocVien
(
    MaHV INT PRIMARY KEY IDENTITY(1,1),
    TenHV VARCHAR(255),
    Lop VARCHAR(3)
);

CREATE TABLE MonHoc
(
    MaMH INT PRIMARY KEY IDENTITY(1,1),
    TenMH VARCHAR(255)
);

CREATE TABLE BangDiem
(
    MaHP INT PRIMARY KEY IDENTITY(1,1),
    MaHV INT,
    MaMH INT,
    Diem FLOAT,
    HeSo INT,
    NamHoc INT,
    FOREIGN KEY (MaHV) REFERENCES HocVien(MaHV),
    FOREIGN KEY (MaMH) REFERENCES MonHoc(MaMH)
);

-- Danh sách học viên trong năm 2023
SELECT
    H.MaHV AS MaHV,
    H.TenHV AS TenHV,
    M.TenMH AS TenMH,
    SUM(BD.Diem * BD.HeSo) / NULLIF(SUM(BD.HeSo), 0) AS DiemTBMon
FROM
    HocVien H
INNER JOIN
    BangDiem BD ON H.MaHV = BD.MaHV
INNER JOIN
    MonHoc M ON BD.MaMH = M.MaMH
WHERE
    BD.NamHoc = 2023
GROUP BY
    H.MaHV, H.TenHV, M.TenMH
HAVING
    SUM(BD.Diem * BD.HeSo) / NULLIF(SUM(BD.HeSo), 0) < 5.0
ORDER BY
    H.MaHV, M.TenMH;

-- Câu c: 
WITH DiemTBNH_CTE AS (
    SELECT
        H.MaHV AS MaHV,
        H.TenHV AS TenHV,
        BD.NamHoc AS NamHoc,
        SUM(BD.Diem * BD.HeSo) AS TongDiem,
        SUM(BD.HeSo) AS TongHeSo
    FROM
        HocVien H
    INNER JOIN
        BangDiem BD ON H.MaHV = BD.MaHV
    INNER JOIN
        MonHoc MH ON BD.MaMH = MH.MaMH
    WHERE
        H.Lop = '7A1'
        AND BD.NamHoc = 2023
    GROUP BY
        H.MaHV, H.TenHV, BD.NamHoc
)
SELECT TOP 1
    MaHV,
    TenHV,
    NamHoc,
    CASE
        WHEN TongHeSo = 0 THEN 0
        ELSE TongDiem / TongHeSo
    END AS DiemTBNH
FROM
    DiemTBNH_CTE
ORDER BY
    DiemTBNH DESC;
