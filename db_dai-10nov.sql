-- phpMyAdmin SQL Dump
-- version 2.11.7
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Waktu pembuatan: 10. Nopember 2011 jam 07:23
-- Versi Server: 5.0.51
-- Versi PHP: 5.2.6

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `db_dai`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `bahanmentahhistory`
--

CREATE TABLE IF NOT EXISTS `bahanmentahhistory` (
  `KdHistory` int(11) NOT NULL auto_increment,
  `KdBahanMentah` varchar(20) NOT NULL,
  `UserID` varchar(20) default NULL,
  `TanggalHistory` datetime NOT NULL,
  `StockAwal` double NOT NULL default '0',
  `QtyProd_Min` double NOT NULL default '0',
  `QtyPurchase_Plus` double NOT NULL default '0',
  `QtyUpdate_Min` double NOT NULL default '0',
  `QtyUpdate_Plus` double NOT NULL default '0',
  `QtyAdj_Min` double NOT NULL default '0',
  `QtyRetur_Plus` double default '0',
  `QtyRetur_Min` double default '0',
  `QtyAdj_Plus` double NOT NULL default '0',
  `QtyFaktur_Min` double default '0',
  `StatusBahanMentahList` char(1) NOT NULL default '0',
  `StockAkhir` double NOT NULL default '0',
  `HargaAwal` decimal(20,2) NOT NULL default '0.00',
  `HargaAkhir` decimal(20,2) NOT NULL default '0.00',
  `Module` varchar(200) default NULL,
  `RefNumber` varchar(20) default NULL,
  `Keterangan` text,
  `isActive` char(1) NOT NULL default '1',
  `Jenis` enum('Paku','Klem') default NULL,
  PRIMARY KEY  (`KdHistory`),
  KEY `KdBahanMentah` (`KdBahanMentah`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=18 ;

--
-- Dumping data untuk tabel `bahanmentahhistory`
--

INSERT INTO `bahanmentahhistory` (`KdHistory`, `KdBahanMentah`, `UserID`, `TanggalHistory`, `StockAwal`, `QtyProd_Min`, `QtyPurchase_Plus`, `QtyUpdate_Min`, `QtyUpdate_Plus`, `QtyAdj_Min`, `QtyRetur_Plus`, `QtyRetur_Min`, `QtyAdj_Plus`, `QtyFaktur_Min`, `StatusBahanMentahList`, `StockAkhir`, `HargaAwal`, `HargaAkhir`, `Module`, `RefNumber`, `Keterangan`, `isActive`, `Jenis`) VALUES
(1, 'KL11100001', '', '2011-10-09 12:23:06', 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, '0', 20, 30000.00, 0.00, 'Form Klem', '', NULL, '1', 'Klem'),
(2, 'KL11100002', '', '2011-10-09 12:31:52', 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, '0', 50, 20000.00, 0.00, 'Form Klem', '', NULL, '1', 'Klem'),
(3, 'PK11100001', '', '2011-10-09 13:03:15', 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, '0', 20, 30000.00, 0.00, 'Form Paku', '', NULL, '1', 'Paku'),
(4, 'PK11100002', '', '2011-10-09 13:08:44', 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, '0', 30, 30000.00, 0.00, 'Form Paku', '', NULL, '1', 'Paku'),
(5, 'PK11100001', '', '2011-10-28 00:47:06', 20, 0, 0, 0, 0, 0, 0, 0, 0, 2, '0', 18, 30000.00, 67500.00, 'Form Faktur', 'FK0002.27.10.11', NULL, '1', 'Paku'),
(6, 'PK11100002', '', '2011-10-28 00:47:06', 30, 0, 0, 0, 0, 0, 0, 0, 0, 5, '0', 25, 30000.00, 47500.00, 'Form Faktur', 'FK0002.27.10.11', NULL, '1', 'Paku'),
(7, 'PK11100001', '', '2011-10-28 22:09:59', 18, 0, 0, 0, 0, 0, 0, 0, 0, 3, '0', 15, 30000.00, 75000.00, 'Form Faktur', 'FK0001.28.10.11', NULL, '1', 'Paku'),
(8, 'PK11100002', '', '2011-10-28 22:09:59', 25, 0, 0, 0, 0, 0, 0, 0, 0, 5, '0', 20, 30000.00, 50000.00, 'Form Faktur', 'FK0001.28.10.11', NULL, '1', 'Paku'),
(9, 'PK11100001', '', '2011-10-28 22:45:57', 15, 0, 0, 0, 0, 0, 2, 0, 0, 0, '0', 17, 7500000.00, 0.00, 'Form Retur Pembelian Barang', 'RF0001.28.10.11', NULL, '1', ''),
(10, 'PK11100002', '', '2011-10-28 22:45:57', 20, 0, 0, 0, 0, 0, 2, 0, 0, 0, '0', 22, 5000000.00, 0.00, 'Form Retur Pembelian Barang', 'RF0001.28.10.11', NULL, '1', ''),
(11, 'PK11100001', '', '2011-11-03 20:58:00', 17, 0, 0, 0, 0, 0, 0, 0, 0, 2, '0', 15, 30000.00, 75000.00, 'Form Faktur', 'FK0002.03.11.11', NULL, '1', 'Paku'),
(12, 'PK11100002', '', '2011-11-03 20:58:00', 22, 0, 0, 0, 0, 0, 0, 0, 0, 2, '0', 20, 30000.00, 50000.00, 'Form Faktur', 'FK0002.03.11.11', NULL, '1', 'Paku'),
(13, 'PK11100001', '', '2011-11-03 21:11:31', 15, 0, 0, 0, 0, 0, 1, 0, 0, 0, '0', 16, 75000.00, 0.00, 'Form Retur Penjualan', 'RF0002.03.11.11', NULL, '1', ''),
(14, 'PK11100001', '', '2011-11-03 21:56:09', 16, 0, 0, 0, 0, 0, 0, 0, 0, 1, '0', 15, 30000.00, 75000.00, 'Form Faktur', 'FK0004.03.11.11', NULL, '1', 'Paku'),
(15, 'PK11100002', '', '2011-11-03 21:56:09', 20, 0, 0, 0, 0, 0, 0, 0, 0, 2, '0', 18, 30000.00, 50000.00, 'Form Faktur', 'FK0004.03.11.11', NULL, '1', 'Paku'),
(16, 'KL11100001', '', '2011-11-05 00:45:20', 20, 0, 5, 0, 0, 0, 0, 0, 0, 0, '0', 25, 20000.00, 0.00, 'Form Penerimaan Bahan Mentah', 'PB11110001', NULL, '1', 'Klem'),
(17, 'KL11100001', '', '2011-11-05 01:09:22', 25, 0, 0, 0, 0, 0, 0, 2, 0, 0, '0', 23, 30000.00, 20000.00, 'Form Retur', 'RB1111050001', NULL, '1', 'Klem');

-- --------------------------------------------------------

--
-- Struktur dari tabel `baranghistory`
--

CREATE TABLE IF NOT EXISTS `baranghistory` (
  `KdBarangHistory` int(11) NOT NULL auto_increment,
  `KdBarang` varchar(20) NOT NULL,
  `UserID` varchar(20) NOT NULL,
  `TanggalHistory` datetime NOT NULL,
  `StockAwal` double default '0',
  `QtyUpdate_Min` double default '0',
  `QtyUpdate_Plus` double default '0',
  `QtyFaktur_Min` double default '0',
  `QtyRetur_Plus` double default '0',
  `QtyRetur_Min` double default '0',
  `QtyPurchase_Plus` double default '0',
  `QtyProd_Plus` double default '0',
  `QtyAdj_Min` double default '0',
  `QtyAdj_Plus` double default '0',
  `StatusBarangList` char(1) default '0',
  `StockAkhir` double default '0',
  `HargaAwal` decimal(20,2) default '0.00',
  `HargaAkhir` decimal(20,2) default '0.00',
  `Module` varchar(200) default NULL,
  `RefNumber` varchar(20) default NULL,
  `Keterangan` text,
  `isActive` char(1) NOT NULL default '1',
  PRIMARY KEY  (`KdBarangHistory`),
  KEY `KdBarang` (`KdBarang`),
  KEY `UserID` (`UserID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=30 ;

--
-- Dumping data untuk tabel `baranghistory`
--

INSERT INTO `baranghistory` (`KdBarangHistory`, `KdBarang`, `UserID`, `TanggalHistory`, `StockAwal`, `QtyUpdate_Min`, `QtyUpdate_Plus`, `QtyFaktur_Min`, `QtyRetur_Plus`, `QtyRetur_Min`, `QtyPurchase_Plus`, `QtyProd_Plus`, `QtyAdj_Min`, `QtyAdj_Plus`, `StatusBarangList`, `StockAkhir`, `HargaAwal`, `HargaAkhir`, `Module`, `RefNumber`, `Keterangan`, `isActive`) VALUES
(1, 'BG11100001', '', '2011-10-09 13:09:34', 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, '0', 20, 20000.00, 0.00, 'Form Barang', '', NULL, '1'),
(2, 'BG11100002', '', '2011-10-09 13:09:55', 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, '0', 30, 30000.00, 0.00, 'Form Barang', '', NULL, '1'),
(3, 'BG11100001', '', '2011-10-11 10:45:36', 20, 0, 0, 5, 0, 0, 0, 0, 0, 0, '0', 15, 20000.00, 25000.00, 'Form Faktur', 'FK0001.10.10.11/SL11', NULL, '1'),
(4, 'BG11100002', '', '2011-10-11 10:45:36', 30, 0, 0, 5, 0, 0, 0, 0, 0, 0, '0', 25, 30000.00, 35000.00, 'Form Faktur', 'FK0001.10.10.11/SL11', NULL, '1'),
(5, 'BG11100001', '', '2011-10-20 10:38:06', 15, 0, 0, 5, 0, 0, 0, 0, 0, 0, '0', 10, 20000.00, 22500.00, 'Form Faktur', 'FK0001.20.10.11/SL11', NULL, '1'),
(6, 'BG11100002', '', '2011-10-20 10:38:06', 25, 0, 0, 5, 0, 0, 0, 0, 0, 0, '0', 20, 30000.00, 33250.00, 'Form Faktur', 'FK0001.20.10.11/SL11', NULL, '1'),
(7, 'BG11100001', '', '2011-10-28 00:31:58', 10, 0, 0, 5, 0, 0, 0, 0, 0, 0, '0', 5, 20000.00, 25000.00, 'Form Faktur', 'FK0001.27.10.11', NULL, '1'),
(8, 'BG11100002', '', '2011-10-28 00:31:58', 20, 0, 0, 2, 0, 0, 0, 0, 0, 0, '0', 18, 30000.00, 35000.00, 'Form Faktur', 'FK0001.27.10.11', NULL, '1'),
(9, 'BG11100001', '', '2011-10-28 23:33:09', 5, 0, 0, 0, 2, 0, 0, 0, 0, 0, '0', 7, 2500000.00, 0.00, 'Form Retur Penjualan', 'RF0002.28.10.11', NULL, '1'),
(10, 'BG11100002', '', '2011-10-28 23:33:09', 18, 0, 0, 0, 1, 0, 0, 0, 0, 0, '1', 18, 3500000.00, 0.00, 'Form Retur Penjualan', 'RF0002.28.10.11', NULL, '1'),
(11, 'BG11100001', '', '2011-11-03 20:57:39', 7, 0, 0, 2, 0, 0, 0, 0, 0, 0, '0', 5, 20000.00, 25000.00, 'Form Faktur', 'FK0001.03.11.11', NULL, '1'),
(12, 'BG11100002', '', '2011-11-03 20:57:39', 18, 0, 0, 2, 0, 0, 0, 0, 0, 0, '0', 16, 30000.00, 35000.00, 'Form Faktur', 'FK0001.03.11.11', NULL, '1'),
(13, 'BG11100001', '', '2011-11-03 21:11:36', 5, 0, 0, 0, 1, 0, 0, 0, 0, 0, '0', 6, 25000.00, 0.00, 'Form Retur Penjualan', 'RF0001.03.11.11', NULL, '1'),
(14, 'BG11100001', '', '2011-11-03 21:55:50', 6, 0, 0, 1, 0, 0, 0, 0, 0, 0, '0', 5, 20000.00, 25000.00, 'Form Faktur', 'FK0003.03.11.11', NULL, '1'),
(15, 'BG11100002', '', '2011-11-03 21:55:50', 16, 0, 0, 1, 0, 0, 0, 0, 0, 0, '0', 15, 30000.00, 35000.00, 'Form Faktur', 'FK0003.03.11.11', NULL, '1'),
(16, 'BG11110001', '', '2011-11-04 00:17:58', 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, '0', 10, 600000.00, 0.00, 'Form Barang', '', NULL, '1'),
(17, 'BG11110002', '', '2011-11-04 00:18:27', 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, '0', 10, 800000.00, 0.00, 'Form Barang', '', NULL, '1'),
(18, 'BG11110003', '', '2011-11-04 00:19:07', 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, '0', 10, 5000000.00, 0.00, 'Form Barang', '', NULL, '1'),
(19, 'BG11110004', '', '2011-11-04 00:19:40', 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, '0', 10, 2000000.00, 0.00, 'Form Barang', '', NULL, '1'),
(20, 'BG11110005', '', '2011-11-04 00:20:03', 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, '0', 10, 5000000.00, 0.00, 'Form Barang', '', NULL, '1'),
(21, 'BG11110006', '', '2011-11-04 00:20:27', 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, '0', 10, 200000.00, 0.00, 'Form Barang', '', NULL, '1'),
(22, 'BG11110006', '', '2011-11-04 00:28:08', 10, 0, 0, 1, 0, 0, 0, 0, 0, 0, '0', 9, 200000.00, 250000.00, 'Form Faktur', 'FK0001.04.11.11', NULL, '1'),
(23, 'BG11110005', '', '2011-11-04 00:28:12', 10, 0, 0, 1, 0, 0, 0, 0, 0, 0, '0', 9, 5000000.00, 5400000.00, 'Form Faktur', 'FK0002.04.11.11', NULL, '1'),
(24, 'BG11110004', '', '2011-11-04 00:28:17', 10, 0, 0, 1, 0, 0, 0, 0, 0, 0, '0', 9, 2000000.00, 2402500.00, 'Form Faktur', 'FK0003.04.11.11', NULL, '1'),
(25, 'BG11110003', '', '2011-11-04 00:28:22', 10, 0, 0, 2, 0, 0, 0, 0, 0, 0, '0', 8, 5000000.00, 5050000.00, 'Form Faktur', 'FK0004.04.11.11', NULL, '1'),
(26, 'BG11110002', '', '2011-11-04 00:28:27', 10, 0, 0, 2, 0, 0, 0, 0, 0, 0, '0', 8, 800000.00, 900000.00, 'Form Faktur', 'FK0005.04.11.11', NULL, '1'),
(27, 'BG11110001', '', '2011-11-04 00:28:32', 10, 0, 0, 1, 0, 0, 0, 0, 0, 0, '0', 9, 600000.00, 622500.00, 'Form Faktur', 'FK0006.04.11.11', NULL, '1'),
(28, 'BG11100001', 'US11010001', '2011-11-09 21:25:51', 5, 0, 0, 2, 0, 0, 0, 0, 0, 0, '0', 3, 20000.00, 25000.00, 'Form Faktur', 'FK0001.09.11.11', NULL, '1'),
(29, 'BG11100001', 'US11010001', '2011-11-09 21:28:34', 3, 0, 0, 0, 1, 0, 0, 0, 0, 0, '0', 4, 25000.00, 0.00, 'Form Retur Penjualan', 'RF0001.09.11.11', NULL, '1');

-- --------------------------------------------------------

--
-- Struktur dari tabel `msbahanmentah`
--

CREATE TABLE IF NOT EXISTS `msbahanmentah` (
  `KdBahanMentah` varchar(20) NOT NULL,
  `KdSupplier` varchar(20) default NULL,
  `NamaBahanMentah` varchar(200) default NULL,
  `Ukuran` int(11) default NULL,
  `Jenis` enum('Klem','Paku') default NULL,
  `Satuan` enum('Karung','Kardus') default NULL,
  `IsAktif` char(1) default '1',
  `HargaJualKg` decimal(20,2) NOT NULL,
  `HargaJualKarung` decimal(20,2) NOT NULL,
  `KarungToKg` double(20,2) NOT NULL,
  PRIMARY KEY  (`KdBahanMentah`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `msbahanmentah`
--

INSERT INTO `msbahanmentah` (`KdBahanMentah`, `KdSupplier`, `NamaBahanMentah`, `Ukuran`, `Jenis`, `Satuan`, `IsAktif`, `HargaJualKg`, `HargaJualKarung`, `KarungToKg`) VALUES
('KL11100001', NULL, 'Klem mentah -4', 4, 'Klem', 'Karung', '1', 3000.00, 75000.00, 25.00),
('KL11100002', NULL, 'Klem mentah -5', 5, 'Klem', 'Karung', '1', 3000.00, 75000.00, 25.00),
('PK11100001', NULL, 'Paku -4', 4, 'Paku', 'Karung', '1', 3000.00, 75000.00, 25.00),
('PK11100002', NULL, 'Paku -5', 5, 'Paku', 'Karung', '1', 2000.00, 50000.00, 25.00);

-- --------------------------------------------------------

--
-- Struktur dari tabel `msbahanmentahlist`
--

CREATE TABLE IF NOT EXISTS `msbahanmentahlist` (
  `KdBahanMentahList` int(11) NOT NULL auto_increment,
  `KdBahanMentah` varchar(20) default NULL,
  `Harga` decimal(20,2) default NULL,
  `Qty` double default NULL,
  `Jenis` enum('Paku','Klem') default NULL,
  `StatusBahanMentahList` char(1) NOT NULL default '0',
  PRIMARY KEY  (`KdBahanMentahList`),
  KEY `KdBahanMentah` (`KdBahanMentah`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- Dumping data untuk tabel `msbahanmentahlist`
--

INSERT INTO `msbahanmentahlist` (`KdBahanMentahList`, `KdBahanMentah`, `Harga`, `Qty`, `Jenis`, `StatusBahanMentahList`) VALUES
(1, 'KL11100001', 30000.00, 18, 'Klem', '0'),
(2, 'KL11100002', 20000.00, 50, 'Klem', '0'),
(3, 'PK11100001', 30000.00, 12, 'Paku', '0'),
(4, 'PK11100002', 30000.00, 16, 'Paku', '0'),
(5, 'PK11100001', 7500000.00, 2, '', '0'),
(6, 'PK11100002', 5000000.00, 2, '', '0'),
(7, 'PK11100001', 75000.00, 1, '', '0'),
(8, 'KL11100001', 20000.00, 5, 'Klem', '0');

-- --------------------------------------------------------

--
-- Struktur dari tabel `msbarang`
--

CREATE TABLE IF NOT EXISTS `msbarang` (
  `KdBarang` varchar(20) NOT NULL,
  `KdMerk` varchar(20) NOT NULL,
  `NamaBarang` varchar(200) NOT NULL,
  `Ukuran` int(11) default NULL,
  `Satuan` varchar(20) default 'pack',
  `IsAktif` char(1) default NULL,
  `Note` text,
  `HargaList` decimal(20,2) NOT NULL,
  PRIMARY KEY  (`KdBarang`),
  KEY `KdMerk` (`KdMerk`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `msbarang`
--

INSERT INTO `msbarang` (`KdBarang`, `KdMerk`, `NamaBarang`, `Ukuran`, `Satuan`, `IsAktif`, `Note`, `HargaList`) VALUES
('BG11100001', 'MR001', 'Klem -ukuran4', 4, 'Pack', '1', NULL, 25000.00),
('BG11100002', 'MR002', 'Klem -ukuran5', 5, 'Pack', '1', NULL, 35000.00),
('BG11110001', 'MR001 ', 'Klem -ukuran6', 6, 'Pack', '1', NULL, 622500.00),
('BG11110002', 'MR002', 'Klem -ukuran7', 7, 'Pack', '1', NULL, 900000.00),
('BG11110003', 'MR001', 'Klem -ukuran8', 8, 'Pack', '1', NULL, 5050000.00),
('BG11110004', 'MR002', 'Klem -ukuran9', 9, 'Pack', '1', NULL, 2402000.00),
('BG11110005', 'MR001', 'Klem -ukuran10', 10, 'Pack', '1', NULL, 5400000.00),
('BG11110006', 'MR002', 'Klem -ukuran12', 12, 'Pack', '1', NULL, 250000.00);

-- --------------------------------------------------------

--
-- Struktur dari tabel `msbaranglist`
--

CREATE TABLE IF NOT EXISTS `msbaranglist` (
  `KdList` int(11) NOT NULL auto_increment,
  `KdBarang` varchar(20) NOT NULL,
  `Harga` decimal(20,2) NOT NULL,
  `Qty` double NOT NULL,
  `StatusBarangList` char(1) NOT NULL default '0',
  `StatusBarang` char(1) NOT NULL default '0',
  PRIMARY KEY  (`KdList`),
  KEY `KdBarang` (`KdBarang`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=13 ;

--
-- Dumping data untuk tabel `msbaranglist`
--

INSERT INTO `msbaranglist` (`KdList`, `KdBarang`, `Harga`, `Qty`, `StatusBarangList`, `StatusBarang`) VALUES
(2, 'BG11100002', 30000.00, 15, '0', '0'),
(3, 'BG11100001', 2500000.00, 2, '0', '0'),
(4, 'BG11100002', 3500000.00, 1, '1', '0'),
(5, 'BG11100001', 25000.00, 1, '0', '0'),
(6, 'BG11110001', 600000.00, 9, '0', '0'),
(7, 'BG11110002', 800000.00, 8, '0', '0'),
(8, 'BG11110003', 5000000.00, 8, '0', '0'),
(9, 'BG11110004', 2000000.00, 9, '0', '0'),
(10, 'BG11110005', 5000000.00, 9, '0', '0'),
(11, 'BG11110006', 200000.00, 9, '0', '0'),
(12, 'BG11100001', 25000.00, 1, '0', '0');

-- --------------------------------------------------------

--
-- Struktur dari tabel `mskaryawan`
--

CREATE TABLE IF NOT EXISTS `mskaryawan` (
  `KdKaryawan` varchar(20) NOT NULL,
  `NamaKaryawan` varchar(200) default NULL,
  `Alamat` text,
  `NoTelp` varchar(20) default NULL,
  `NoHP` varchar(20) default NULL,
  `JenisKaryawan` varchar(70) default NULL,
  PRIMARY KEY  (`KdKaryawan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `mskaryawan`
--

INSERT INTO `mskaryawan` (`KdKaryawan`, `NamaKaryawan`, `Alamat`, `NoTelp`, `NoHP`, `JenisKaryawan`) VALUES
('KY11090001', 'k12323', 'aa2323', '-', '22', 'Memantek Klaim'),
('KY11090002', '2322', '23222', '-', '2323', 'Menhitung & memantek Klaim'),
('KY11090003', '23', '23', '-', '23', 'Menhitung Klaim');

-- --------------------------------------------------------

--
-- Struktur dari tabel `msmerk`
--

CREATE TABLE IF NOT EXISTS `msmerk` (
  `kdmerk` varchar(20) NOT NULL,
  `merk` varchar(50) default NULL,
  PRIMARY KEY  (`kdmerk`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `msmerk`
--

INSERT INTO `msmerk` (`kdmerk`, `merk`) VALUES
('MR001', 'Merk1'),
('MR002', 'Merk2');

-- --------------------------------------------------------

--
-- Struktur dari tabel `mssales`
--

CREATE TABLE IF NOT EXISTS `mssales` (
  `KdSales` varchar(20) NOT NULL,
  `NamaSales` varchar(200) default NULL,
  `Alamat` text,
  `NoTelp` varchar(20) default NULL,
  `NoHP` varchar(20) default NULL,
  `Komisi` double default '0',
  PRIMARY KEY  (`KdSales`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `mssales`
--

INSERT INTO `mssales` (`KdSales`, `NamaSales`, `Alamat`, `NoTelp`, `NoHP`, `Komisi`) VALUES
('SL11090001', 'Sales1', 'asa', '5454523', '24234', 11),
('SL11090002', 'q', '234', '-', '', 0),
('SL11110001', 'Musi', 'Jl. Tanngerag', '-', '', 16);

-- --------------------------------------------------------

--
-- Struktur dari tabel `mssupplier`
--

CREATE TABLE IF NOT EXISTS `mssupplier` (
  `KdSupplier` varchar(20) NOT NULL,
  `Nama` varchar(200) default NULL,
  `Alamat` text,
  `Daerah` varchar(100) default NULL,
  `NoTelp` varchar(20) default NULL,
  `NoHP` varchar(20) default NULL,
  `noFax` varchar(20) default NULL,
  PRIMARY KEY  (`KdSupplier`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `mssupplier`
--

INSERT INTO `mssupplier` (`KdSupplier`, `Nama`, `Alamat`, `Daerah`, `NoTelp`, `NoHP`, `noFax`) VALUES
('SP11090001', '2', '123', '2', '2', '', '');

-- --------------------------------------------------------

--
-- Struktur dari tabel `mstoko`
--

CREATE TABLE IF NOT EXISTS `mstoko` (
  `KdToko` varchar(20) NOT NULL,
  `NamaToko` varchar(200) default NULL,
  `NamaOwner` varchar(200) default NULL,
  `AlamatToko` text,
  `Daerah` varchar(200) default NULL,
  `NoTelp` varchar(20) default NULL,
  `NoHP` varchar(20) default NULL,
  `NoFax` varchar(20) default NULL,
  `JatuhTempo` int(11) default NULL,
  `KdSales` varchar(20) NOT NULL,
  PRIMARY KEY  (`KdToko`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `mstoko`
--

INSERT INTO `mstoko` (`KdToko`, `NamaToko`, `NamaOwner`, `AlamatToko`, `Daerah`, `NoTelp`, `NoHP`, `NoFax`, `JatuhTempo`, `KdSales`) VALUES
('TK1109140001', '23', '2', '23', '23', '23', '232', '32', 123, 'SL11090001'),
('TK1111040001', 'Sinar Bintang', 'Sinar Bintang', 'Sinar Bintang', 'Sinar Bintang', '-', '', '', 10, 'SL11110001'),
('TK1111040002', 'Sinar Abadi', 'Sinar Abadi', 'Sinar Abadi', '', '-', '', '', 10, 'SL11110001'),
('TK1111040003', 'Bintang Teranng', 'Bintang Teranng', 'Bintang Teranng', '', '-', '', '', 10, 'SL11110001'),
('TK1111040004', 'Musi Indah', 'Musi Indah', 'Musi Indah', '', '-', '', '', 10, 'SL11110001');

-- --------------------------------------------------------

--
-- Struktur dari tabel `msuser`
--

CREATE TABLE IF NOT EXISTS `msuser` (
  `userid` varchar(20) NOT NULL,
  `username` varchar(50) default NULL,
  `Password` varchar(20) default NULL,
  `NamaLengkap` varchar(50) default NULL,
  `Level` char(1) default '1',
  PRIMARY KEY  (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `msuser`
--

INSERT INTO `msuser` (`userid`, `username`, `Password`, `NamaLengkap`, `Level`) VALUES
('US11010001', 'a', 'a', 'User1', '1');

-- --------------------------------------------------------

--
-- Struktur dari tabel `trdetailpb`
--

CREATE TABLE IF NOT EXISTS `trdetailpb` (
  `No_PB` varchar(20) NOT NULL,
  `kdbahanmentah` varchar(20) NOT NULL,
  `Qty` double NOT NULL,
  `Harga` decimal(20,2) NOT NULL,
  `Disc` float default '0',
  `QtyPenerimaan` double default '0',
  PRIMARY KEY  (`No_PB`,`kdbahanmentah`),
  KEY `KdBarang` (`kdbahanmentah`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `trdetailpb`
--

INSERT INTO `trdetailpb` (`No_PB`, `kdbahanmentah`, `Qty`, `Harga`, `Disc`, `QtyPenerimaan`) VALUES
('PB11110001', 'KL11100001', 5, 20000.00, 0, 5),
('PB11110002', 'PK11100001', 5, 25000.00, 0, 5),
('PB11110002', 'PK11100002', 2, 20000.00, 0, 2);

-- --------------------------------------------------------

--
-- Struktur dari tabel `trdetailpo`
--

CREATE TABLE IF NOT EXISTS `trdetailpo` (
  `no_po` varchar(20) NOT NULL,
  `kdbahanmentah` varchar(20) NOT NULL,
  `jumlah` float NOT NULL,
  `harga` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `trdetailpo`
--

INSERT INTO `trdetailpo` (`no_po`, `kdbahanmentah`, `jumlah`, `harga`) VALUES
('PO11110001', 'KL11100001', 5, 0),
('PO11110002', 'KL11100001', 5, 0),
('PO11110002', 'KL11100002', 5, 0),
('PO11110003', 'PK11100001', 5, 0),
('PO11110003', 'PK11100002', 2, 0),
('PO11110004', 'KL11100001', 10, 0);

-- --------------------------------------------------------

--
-- Struktur dari tabel `trdetailreturbeli`
--

CREATE TABLE IF NOT EXISTS `trdetailreturbeli` (
  `KdReturDetail` int(11) NOT NULL auto_increment,
  `KdRetur` varchar(20) NOT NULL,
  `KdBahanMentah` varchar(20) NOT NULL,
  `Harga` decimal(20,2) NOT NULL,
  `Qty` double NOT NULL,
  `Disc` float(3,2) default '0.00',
  PRIMARY KEY  (`KdReturDetail`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data untuk tabel `trdetailreturbeli`
--

INSERT INTO `trdetailreturbeli` (`KdReturDetail`, `KdRetur`, `KdBahanMentah`, `Harga`, `Qty`, `Disc`) VALUES
(2, 'RB1111050001', 'KL11100001', 20000.00, 2, 0.00);

-- --------------------------------------------------------

--
-- Struktur dari tabel `trfaktur`
--

CREATE TABLE IF NOT EXISTS `trfaktur` (
  `no_increment` bigint(200) NOT NULL auto_increment,
  `KdFaktur` varchar(20) NOT NULL,
  `KdSO` varchar(20) NOT NULL,
  `TanggalFaktur` datetime NOT NULL,
  `KdSales` varchar(20) NOT NULL,
  `KdToko` varchar(20) NOT NULL,
  `GrandTotal` decimal(20,2) NOT NULL,
  `StatusFaktur` char(1) NOT NULL default '0',
  `StatusPayment` char(1) default '0',
  `UserID` varchar(20) NOT NULL,
  `KdSJ` varchar(20) default NULL,
  `TanggalSJ` datetime default NULL,
  `TotalKomisiSales` decimal(20,2) default '0.00',
  `KomisiPersen` double(20,2) NOT NULL,
  `TanggalJT` date default NULL,
  `jenis_faktur` enum('paku','klem') default 'klem',
  `Disc` double default '0',
  `Jumlah` decimal(20,2) default '0.00' COMMENT 'granndtotal sebelum discount',
  PRIMARY KEY  (`no_increment`,`KdFaktur`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=16 ;

--
-- Dumping data untuk tabel `trfaktur`
--

INSERT INTO `trfaktur` (`no_increment`, `KdFaktur`, `KdSO`, `TanggalFaktur`, `KdSales`, `KdToko`, `GrandTotal`, `StatusFaktur`, `StatusPayment`, `UserID`, `KdSJ`, `TanggalSJ`, `TotalKomisiSales`, `KomisiPersen`, `TanggalJT`, `jenis_faktur`, `Disc`, `Jumlah`) VALUES
(1, 'FK0001.03.11.11', 'SO0002.02.11.11', '2011-11-03 00:00:00', 'SL11090001', 'TK1109140001', 108000.00, '2', '0', 'US11010001', NULL, NULL, 0.00, 11.00, '2012-03-05', 'klem', 10, 120000.00),
(2, 'FK0001.04.11.11', 'SO0006.04.11.11', '2011-11-04 00:28:27', 'SL11110001', 'TK1111040004', 225000.00, '1', '1', 'US11010001', NULL, NULL, 0.00, 16.00, '2011-11-14', 'klem', 10, 250000.00),
(3, 'FK0001.27.10.11', 'SO0002.27.10.11', '2011-10-27 00:00:00', 'SL11090001', 'TK1109140001', 195000.00, '2', '0', 'US11010001', NULL, NULL, 21450.00, 11.00, '2012-02-27', 'klem', 0, 0.00),
(4, 'FK0001.28.10.11', 'SO0001.28.10.11', '2011-10-28 00:00:00', 'SL11090001', 'TK1109140001', 475000.00, '2', '0', 'US11010001', NULL, NULL, 52250.00, 11.00, '2012-02-28', 'paku', 0, 0.00),
(5, 'FK0002.03.11.11', 'SO0001.03.11.11', '2011-11-03 00:00:00', 'SL11090001', 'TK1109140001', 237500.00, '2', '0', 'US11010001', NULL, NULL, 0.00, 11.00, '2012-03-05', 'paku', 5, 250000.00),
(6, 'FK0002.04.11.11', 'SO0005.04.11.11', '2011-11-04 00:28:34', 'SL11110001', 'TK1111040003', 5400000.00, '1', '1', 'US11010001', NULL, NULL, 0.00, 16.00, '2011-11-14', 'klem', 0, 5400000.00),
(7, 'FK0002.27.10.11', 'SO0001.27.10.11', '2011-10-27 00:00:00', 'SL11090001', 'TK1109140001', 372500.00, '1', '0', 'US11010001', NULL, NULL, 40975.00, 11.00, '2011-10-27', 'paku', 0, 0.00),
(8, 'FK0003.03.11.11', 'SO0002.03.11.11', '2011-11-03 00:00:00', 'SL11090001', 'TK1109140001', 54000.00, '3', '0', 'US11010001', NULL, NULL, 0.00, 11.00, '2012-03-05', 'klem', 10, 60000.00),
(9, 'FK0003.04.11.11', 'SO0004.04.11.11', '2011-11-04 00:28:38', 'SL11110001', 'TK1111040002', 2402500.00, '1', '1', 'US11010001', NULL, NULL, 0.00, 16.00, '2011-11-14', 'klem', 0, 2402500.00),
(10, 'FK0004.03.11.11', 'SO0003.03.11.11', '2011-11-03 21:56:29', 'SL11090001', 'TK1109140001', 166250.00, '1', '0', 'US11010001', 'SJ0004.03.11.11', '2011-11-06 00:00:00', 0.00, 11.00, '2012-03-05', 'paku', 5, 175000.00),
(11, 'FK0004.04.11.11', 'SO0003.04.11.11', '2011-11-04 00:28:43', 'SL11110001', 'TK1111040003', 10100000.00, '1', '1', 'US11010001', NULL, NULL, 0.00, 16.00, '2011-11-14', 'klem', 0, 10100000.00),
(12, 'FK0005.04.11.11', 'SO0002.04.11.11', '2011-11-04 00:28:48', 'SL11110001', 'TK1111040002', 1800000.00, '1', '1', 'US11010001', NULL, NULL, 0.00, 16.00, '2011-11-14', 'klem', 0, 1800000.00),
(13, 'FK0006.04.11.11', 'SO0001.04.11.11', '2011-11-04 00:28:52', 'SL11110001', 'TK1111040001', 560250.00, '1', '1', 'US11010001', 'SJ0006.04.11.11', '2011-11-06 00:00:00', 0.00, 16.00, '2011-11-14', 'klem', 10, 622500.00),
(14, 'FK0001.09.11.11', 'SO0001.01.11.11', '2011-11-09 21:25:42', 'SL11090001', 'TK1109140001', 50000.00, '1', '0', 'US11010001', NULL, NULL, 0.00, 11.00, '2012-03-11', 'klem', 0, 50000.00),
(15, 'FK0002.09.11.11', 'SO0001.02.11.11', '2011-11-09 21:25:58', 'SL11090001', 'TK1109140001', 144750.00, '0', '0', 'US11010001', NULL, NULL, 0.00, 11.00, '2012-03-11', 'klem', 0, 144750.00);

-- --------------------------------------------------------

--
-- Struktur dari tabel `trfakturdetail`
--

CREATE TABLE IF NOT EXISTS `trfakturdetail` (
  `KdFakturDetail` int(11) NOT NULL auto_increment,
  `KdFaktur` varchar(20) NOT NULL,
  `KdBarang` varchar(20) NOT NULL,
  `Harga` decimal(20,2) NOT NULL,
  `QtyFaktur` double NOT NULL,
  `Qty` double NOT NULL,
  `Disc` double NOT NULL,
  `StatusBarang` char(1) NOT NULL default '0',
  `KomisiSales` decimal(20,2) default '0.00',
  `HargaDisc` decimal(20,2) NOT NULL,
  PRIMARY KEY  (`KdFakturDetail`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=36 ;

--
-- Dumping data untuk tabel `trfakturdetail`
--

INSERT INTO `trfakturdetail` (`KdFakturDetail`, `KdFaktur`, `KdBarang`, `Harga`, `QtyFaktur`, `Qty`, `Disc`, `StatusBarang`, `KomisiSales`, `HargaDisc`) VALUES
(5, 'FK0001.27.10.11', 'BG11100001', 25000.00, 0, 5, 0, '0', 13750.00, 25000.00),
(6, 'FK0001.27.10.11', 'BG11100002', 35000.00, 0, 2, 0, '0', 7700.00, 35000.00),
(7, 'FK0002.27.10.11', 'PK11100001', 75000.00, 0, 2, 10, '0', 14850.00, 67500.00),
(8, 'FK0002.27.10.11', 'PK11100002', 50000.00, 0, 5, 5, '0', 26125.00, 47500.00),
(11, 'FK0001.28.10.11', 'PK11100001', 75000.00, 0, 3, 0, '0', 24750.00, 75000.00),
(12, 'FK0001.28.10.11', 'PK11100002', 50000.00, 0, 5, 0, '0', 27500.00, 50000.00),
(15, 'FK0001.03.11.11', 'BG11100001', 25000.00, 0, 2, 0, '0', 5500.00, 25000.00),
(16, 'FK0001.03.11.11', 'BG11100002', 35000.00, 0, 2, 0, '0', 7700.00, 35000.00),
(19, 'FK0002.03.11.11', 'PK11100001', 75000.00, 0, 2, 0, '0', 16500.00, 75000.00),
(20, 'FK0002.03.11.11', 'PK11100002', 50000.00, 0, 2, 0, '0', 11000.00, 50000.00),
(23, 'FK0003.03.11.11', 'BG11100001', 25000.00, 0, 1, 0, '0', 2750.00, 25000.00),
(24, 'FK0003.03.11.11', 'BG11100002', 35000.00, 0, 1, 0, '0', 3850.00, 35000.00),
(25, 'FK0004.03.11.11', 'PK11100001', 75000.00, 0, 1, 0, '0', 8250.00, 75000.00),
(26, 'FK0004.03.11.11', 'PK11100002', 50000.00, 0, 2, 0, '0', 11000.00, 50000.00),
(27, 'FK0001.04.11.11', 'BG11110006', 250000.00, 0, 1, 0, '0', 40000.00, 250000.00),
(28, 'FK0002.04.11.11', 'BG11110005', 5400000.00, 0, 1, 0, '0', 864000.00, 5400000.00),
(29, 'FK0003.04.11.11', 'BG11110004', 2402500.00, 0, 1, 0, '0', 384400.00, 2402500.00),
(30, 'FK0004.04.11.11', 'BG11110003', 5050000.00, 0, 2, 0, '0', 1616000.00, 5050000.00),
(31, 'FK0005.04.11.11', 'BG11110002', 900000.00, 0, 2, 0, '0', 288000.00, 900000.00),
(32, 'FK0006.04.11.11', 'BG11110001', 622500.00, 0, 1, 0, '0', 99600.00, 622500.00),
(33, 'FK0001.09.11.11', 'BG11100001', 25000.00, 0, 2, 0, '0', 5500.00, 25000.00),
(34, 'FK0002.09.11.11', 'BG11100001', 25000.00, 0, 2, 10, '0', 4950.00, 22500.00),
(35, 'FK0002.09.11.11', 'BG11100002', 35000.00, 0, 3, 5, '0', 10972.50, 33250.00);

-- --------------------------------------------------------

--
-- Struktur dari tabel `trheaderpb`
--

CREATE TABLE IF NOT EXISTS `trheaderpb` (
  `no_increment` bigint(20) NOT NULL auto_increment,
  `No_PB` varchar(20) NOT NULL,
  `No_PO` varchar(20) NOT NULL,
  `userid` varchar(20) NOT NULL,
  `KdSupplier` varchar(20) default NULL,
  `Tanggal_TerimaBarang` datetime NOT NULL,
  `StatusTerimaBarang` char(1) NOT NULL default '0',
  `GrandTotal` double(20,2) NOT NULL default '0.00',
  `StatusPaid` char(1) NOT NULL default '0',
  `jenis_pb` enum('paku','klem') default 'paku',
  `Disc` double default '0',
  `Jumlah` decimal(20,2) default '0.00',
  `StatusPayment` char(1) default '0',
  PRIMARY KEY  (`no_increment`,`No_PB`),
  KEY `userid` (`userid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data untuk tabel `trheaderpb`
--

INSERT INTO `trheaderpb` (`no_increment`, `No_PB`, `No_PO`, `userid`, `KdSupplier`, `Tanggal_TerimaBarang`, `StatusTerimaBarang`, `GrandTotal`, `StatusPaid`, `jenis_pb`, `Disc`, `Jumlah`, `StatusPayment`) VALUES
(6, 'PB11110001', 'PO11110001', 'US11010001', 'SP11090001', '2011-11-04 00:00:00', '2', 90000.00, '1', 'klem', 10, 100000.00, '0'),
(7, 'PB11110002', 'PO11110003', 'US11010001', 'SP11090001', '2011-11-06 13:28:47', '0', 165000.00, '0', 'paku', 0, 165000.00, '0');

-- --------------------------------------------------------

--
-- Struktur dari tabel `trheaderpb_t`
--

CREATE TABLE IF NOT EXISTS `trheaderpb_t` (
  `no_increment` bigint(20) NOT NULL auto_increment,
  `No_PB` varchar(20) NOT NULL,
  PRIMARY KEY  (`no_increment`,`No_PB`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data untuk tabel `trheaderpb_t`
--


-- --------------------------------------------------------

--
-- Struktur dari tabel `trheaderpo`
--

CREATE TABLE IF NOT EXISTS `trheaderpo` (
  `no_increment` bigint(20) NOT NULL auto_increment,
  `No_PO` varchar(20) NOT NULL,
  `userid` varchar(20) NOT NULL,
  `Tanggal_PO` datetime NOT NULL,
  `KdSupplier` varchar(12) NOT NULL,
  `StatusPO` char(1) NOT NULL default '0',
  `GrandTotal` decimal(20,2) NOT NULL default '0.00',
  `jenis_po` enum('paku','klem') default 'paku',
  PRIMARY KEY  (`no_increment`,`No_PO`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data untuk tabel `trheaderpo`
--

INSERT INTO `trheaderpo` (`no_increment`, `No_PO`, `userid`, `Tanggal_PO`, `KdSupplier`, `StatusPO`, `GrandTotal`, `jenis_po`) VALUES
(1, 'PO11110001', 'US11010001', '2011-11-01 23:18:52', 'SP11090001 ', '2', 0.00, 'klem'),
(2, 'PO11110002', 'US11010001', '2011-11-04 00:32:10', 'SP11090001 ', '0', 0.00, 'klem'),
(3, 'PO11110003', 'US11010001', '2011-11-04 00:32:25', 'SP11090001 ', '1', 0.00, 'paku'),
(4, 'PO11110004', 'US11010001', '2011-11-09 20:31:02', 'SP11090001 ', '1', 0.00, 'klem');

-- --------------------------------------------------------

--
-- Struktur dari tabel `trheaderpo_t`
--

CREATE TABLE IF NOT EXISTS `trheaderpo_t` (
  `no_po` varchar(20) NOT NULL,
  PRIMARY KEY  (`no_po`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `trheaderpo_t`
--

INSERT INTO `trheaderpo_t` (`no_po`) VALUES
('PB11110001'),
('PB11110002'),
('PO11090001'),
('PO11090002'),
('PO11090003'),
('PO11090004'),
('PO11090005'),
('PO11090006'),
('PO11090007');

-- --------------------------------------------------------

--
-- Struktur dari tabel `trheaderreturbeli`
--

CREATE TABLE IF NOT EXISTS `trheaderreturbeli` (
  `no_increment` bigint(20) NOT NULL auto_increment,
  `KdRetur` varchar(20) NOT NULL,
  `KdPB` varchar(20) NOT NULL,
  `TanggalRetur` datetime NOT NULL,
  `KdSupplier` varchar(20) NOT NULL,
  `GrandTotal` decimal(20,2) NOT NULL,
  `StatusRetur` char(1) NOT NULL default '0',
  `Note` text NOT NULL,
  `UserID` varchar(20) NOT NULL,
  `No_PO` varchar(20) default NULL,
  `AfterPaid` char(1) default '0',
  `jenis_retur` enum('paku','klem') default 'klem',
  `Disc` double default '0',
  `Jumlah` decimal(20,2) default '0.00',
  PRIMARY KEY  (`no_increment`,`KdRetur`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data untuk tabel `trheaderreturbeli`
--

INSERT INTO `trheaderreturbeli` (`no_increment`, `KdRetur`, `KdPB`, `TanggalRetur`, `KdSupplier`, `GrandTotal`, `StatusRetur`, `Note`, `UserID`, `No_PO`, `AfterPaid`, `jenis_retur`, `Disc`, `Jumlah`) VALUES
(1, 'RB1111050001', 'PB11110001', '2011-11-05 00:00:00', 'SP11090001', 36000.00, '0', '', 'US11010001', NULL, '0', 'klem', 10, 40000.00);

-- --------------------------------------------------------

--
-- Struktur dari tabel `trpurchasepayment`
--

CREATE TABLE IF NOT EXISTS `trpurchasepayment` (
  `no_increment` bigint(20) NOT NULL auto_increment,
  `KdPurchasePayment` varchar(20) NOT NULL,
  `No_PB` varchar(20) NOT NULL,
  `TanggalPurchasePayment` datetime NOT NULL,
  `KdSupplier` varchar(20) NOT NULL,
  `TotalPurchasePayment` decimal(20,2) NOT NULL,
  `StatusPurchasePayment` char(1) NOT NULL default '0',
  `Note` text NOT NULL,
  `UserID` varchar(20) NOT NULL,
  `PaidBy` varchar(20) default 'Cash',
  `No_PO` varchar(20) default NULL,
  `jenis_payment` enum('paku','klem') default 'klem',
  `Jumlah` decimal(20,2) default '0.00',
  `Disc` double default '0',
  PRIMARY KEY  (`no_increment`,`KdPurchasePayment`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data untuk tabel `trpurchasepayment`
--

INSERT INTO `trpurchasepayment` (`no_increment`, `KdPurchasePayment`, `No_PB`, `TanggalPurchasePayment`, `KdSupplier`, `TotalPurchasePayment`, `StatusPurchasePayment`, `Note`, `UserID`, `PaidBy`, `No_PO`, `jenis_payment`, `Jumlah`, `Disc`) VALUES
(4, 'FP1111050001', 'PB11110001', '2011-11-05 00:00:00', 'SP11090001', 54000.00, '1', '', '', 'Transfer', NULL, 'klem', 60000.00, 10);

-- --------------------------------------------------------

--
-- Struktur dari tabel `trpurchasepaymentdetail`
--

CREATE TABLE IF NOT EXISTS `trpurchasepaymentdetail` (
  `KdPurchasePaymentDetail` double NOT NULL auto_increment,
  `KdPurchasePayment` varchar(20) default NULL,
  `KdBahanMentah` varchar(20) default NULL,
  `Harga` decimal(20,2) default NULL,
  `Qty` double default NULL,
  `Disc` double default NULL,
  `StatusBarang` varchar(200) default NULL,
  PRIMARY KEY  (`KdPurchasePaymentDetail`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data untuk tabel `trpurchasepaymentdetail`
--

INSERT INTO `trpurchasepaymentdetail` (`KdPurchasePaymentDetail`, `KdPurchasePayment`, `KdBahanMentah`, `Harga`, `Qty`, `Disc`, `StatusBarang`) VALUES
(4, 'FP1111050001', 'KL11100001', 20000.00, 3, 0, 'Retur');

-- --------------------------------------------------------

--
-- Struktur dari tabel `trretur`
--

CREATE TABLE IF NOT EXISTS `trretur` (
  `no_increment` bigint(20) NOT NULL auto_increment,
  `KdRetur` varchar(20) NOT NULL,
  `KdFaktur` varchar(20) NOT NULL,
  `TanggalRetur` datetime NOT NULL,
  `KdSales` varchar(20) NOT NULL,
  `KdToko` varchar(20) NOT NULL,
  `GrandTotal` decimal(20,2) NOT NULL,
  `StatusRetur` char(1) NOT NULL default '0',
  `Note` text NOT NULL,
  `UserID` varchar(20) NOT NULL,
  `AfterPaid` char(1) default '0',
  `KdSO` varchar(20) default NULL,
  `jenis_retur` enum('paku','klem') default 'klem',
  `Disc` double default '0',
  `Jumlah` decimal(20,2) default '0.00' COMMENT 'granndtotal sebelum discount',
  PRIMARY KEY  (`no_increment`,`KdRetur`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data untuk tabel `trretur`
--

INSERT INTO `trretur` (`no_increment`, `KdRetur`, `KdFaktur`, `TanggalRetur`, `KdSales`, `KdToko`, `GrandTotal`, `StatusRetur`, `Note`, `UserID`, `AfterPaid`, `KdSO`, `jenis_retur`, `Disc`, `Jumlah`) VALUES
(1, 'RF0001.03.11.11', 'FK0001.03.11.11', '2011-11-03 00:00:00', 'SL11090001', 'TK1109140001', 22500.00, '1', '', 'US11010001', '0', NULL, 'klem', 10, 25000.00),
(2, 'RF0001.28.10.11', 'FK0001.28.10.11', '2011-10-28 00:00:00', 'SL11090001', 'TK1109140001', 250000.00, '1', '', 'US11010001', '0', NULL, 'paku', 0, 250000.00),
(3, 'RF0002.03.11.11', 'FK0002.03.11.11', '2011-11-03 00:00:00', 'SL11090001', 'TK1109140001', 71250.00, '1', '', 'US11010001', '0', NULL, 'paku', 5, 72000.00),
(4, 'RF0002.28.10.11', 'FK0001.27.10.11', '2011-10-28 00:00:00', 'SL11090001', 'TK1109140001', 85000.00, '1', '', 'US11010001', '0', NULL, 'klem', 0, 85000.00),
(5, 'RF0003.28.10.11', 'FK0001.27.10.11', '2011-10-28 00:00:00', 'SL11090001', 'TK1109140001', 85000.00, '0', '', 'US11010001', '0', NULL, 'klem', 0, 85000.00),
(6, 'RF0001.09.11.11', 'FK0003.03.11.11', '2011-11-09 00:00:00', 'SL11090001', 'TK1109140001', 22500.00, '1', '', 'US11010001', '0', NULL, 'klem', 10, 25000.00);

-- --------------------------------------------------------

--
-- Struktur dari tabel `trreturdetail`
--

CREATE TABLE IF NOT EXISTS `trreturdetail` (
  `KdReturDetail` int(11) NOT NULL auto_increment,
  `KdRetur` varchar(20) NOT NULL,
  `KdBarang` varchar(20) NOT NULL,
  `Harga` decimal(20,2) NOT NULL,
  `Qty` double NOT NULL,
  `Disc` double NOT NULL,
  `HargaDisc` decimal(20,2) NOT NULL,
  `StatusBarang` varchar(20) NOT NULL,
  PRIMARY KEY  (`KdReturDetail`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=21 ;

--
-- Dumping data untuk tabel `trreturdetail`
--

INSERT INTO `trreturdetail` (`KdReturDetail`, `KdRetur`, `KdBarang`, `Harga`, `Qty`, `Disc`, `HargaDisc`, `StatusBarang`) VALUES
(5, 'RF0001.28.10.11', 'PK11100001', 75000.00, 2, 0, 75000.00, 'Kelebihan Qty'),
(6, 'RF0001.28.10.11', 'PK11100002', 50000.00, 2, 0, 50000.00, 'Salah Pesan'),
(9, 'RF0002.28.10.11', 'BG11100001', 25000.00, 2, 0, 25000.00, 'Kelebihan Qty'),
(10, 'RF0002.28.10.11', 'BG11100002', 35000.00, 1, 0, 35000.00, 'Rusak'),
(13, 'RF0003.28.10.11', 'BG11100001', 25000.00, 2, 0, 25000.00, 'Kelebihan Qty'),
(14, 'RF0003.28.10.11', 'BG11100002', 35000.00, 1, 0, 35000.00, 'Salah Pesan'),
(17, 'RF0002.03.11.11', 'PK11100001', 75000.00, 1, 0, 75000.00, 'Kelebihan Qty'),
(18, 'RF0001.03.11.11', 'BG11100001', 25000.00, 1, 0, 25000.00, 'Kelebihan Qty'),
(20, 'RF0001.09.11.11', 'BG11100001', 25000.00, 1, 0, 25000.00, 'Salah Pesan');

-- --------------------------------------------------------

--
-- Struktur dari tabel `trsalesorder`
--

CREATE TABLE IF NOT EXISTS `trsalesorder` (
  `no_increment` bigint(20) NOT NULL auto_increment,
  `KdSO` varchar(20) NOT NULL,
  `TanggalSO` datetime NOT NULL,
  `KdSales` varchar(20) NOT NULL,
  `KdToko` varchar(20) NOT NULL,
  `GrandTotal` decimal(20,2) NOT NULL,
  `StatusSO` char(1) NOT NULL default '0',
  `UserID` varchar(20) NOT NULL,
  `KomisiSales` double(20,2) default '0.00',
  `jenis_so` enum('paku','klem') default 'klem' COMMENT '0:klem, 1:paku',
  `disc` double default '0',
  `Jumlah` decimal(20,2) default '0.00' COMMENT 'granndtotal sebelum discount',
  PRIMARY KEY  (`no_increment`,`KdSO`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=17 ;

--
-- Dumping data untuk tabel `trsalesorder`
--

INSERT INTO `trsalesorder` (`no_increment`, `KdSO`, `TanggalSO`, `KdSales`, `KdToko`, `GrandTotal`, `StatusSO`, `UserID`, `KomisiSales`, `jenis_so`, `disc`, `Jumlah`) VALUES
(1, 'SO0001.01.11.11', '2011-11-01 00:00:00', 'SL11090001', 'TK1109140001', 50000.00, '2', 'US11010001', 11.00, 'klem', 0, 50000.00),
(2, 'SO0001.02.11.11', '2011-11-02 22:09:45', 'SL11090001', 'TK1109140001', 144750.00, '3', 'US11010001', 11.00, 'klem', 0, 144750.00),
(3, 'SO0001.03.11.11', '2011-11-03 20:32:19', 'SL11090001', 'TK1109140001', 237500.00, '2', 'US11010001', 11.00, 'paku', 5, 250000.00),
(4, 'SO0001.04.11.11', '2011-11-04 00:21:43', 'SL11110001', 'TK1111040001', 560250.00, '2', 'US11010001', 16.00, 'klem', 10, 622500.00),
(5, 'SO0001.27.10.11', '2011-10-27 00:00:00', 'SL11090001', 'TK1109140001', 372500.00, '2', 'US11010001', 11.00, 'paku', 0, 372500.00),
(6, 'SO0001.28.10.11', '2011-10-28 21:09:35', 'SL11090001', 'TK1109140001', 475000.00, '2', 'US11010001', 11.00, 'paku', 0, 475000.00),
(7, 'SO0002.01.11.11', '2011-11-01 21:37:26', 'SL11090001', 'TK1109140001', 100000.00, '3', 'US11010001', 11.00, 'paku', 0, 100000.00),
(8, 'SO0002.02.11.11', '2011-11-02 00:00:00', 'SL11090001', 'TK1109140001', 108000.00, '2', 'US11010001', 11.00, 'klem', 10, 120000.00),
(9, 'SO0002.03.11.11', '2011-11-03 21:45:46', 'SL11090001', 'TK1109140001', 54000.00, '2', 'US11010001', 11.00, 'klem', 10, 60000.00),
(10, 'SO0002.04.11.11', '2011-11-04 00:22:05', 'SL11110001', 'TK1111040002', 1800000.00, '2', 'US11010001', 16.00, 'klem', 0, 1800000.00),
(11, 'SO0002.27.10.11', '2011-10-27 00:00:00', 'SL11090001', 'TK1109140001', 195000.00, '2', 'US11010001', 11.00, 'klem', 0, 195000.00),
(12, 'SO0003.03.11.11', '2011-11-03 00:00:00', 'SL11090001', 'TK1109140001', 166250.00, '2', 'US11010001', 11.00, 'paku', 5, 175000.00),
(13, 'SO0003.04.11.11', '2011-11-04 00:22:22', 'SL11110001', 'TK1111040003', 10100000.00, '2', 'US11010001', 16.00, 'klem', 0, 10100000.00),
(14, 'SO0004.04.11.11', '2011-11-04 00:27:20', 'SL11110001', 'TK1111040002', 2402500.00, '2', 'US11010001', 16.00, 'klem', 0, 2402500.00),
(15, 'SO0005.04.11.11', '2011-11-04 00:27:42', 'SL11110001', 'TK1111040003', 5400000.00, '2', 'US11010001', 16.00, 'klem', 0, 5400000.00),
(16, 'SO0006.04.11.11', '2011-11-04 00:28:02', 'SL11110001', 'TK1111040004', 225000.00, '2', 'US11010001', 16.00, 'klem', 10, 250000.00);

-- --------------------------------------------------------

--
-- Struktur dari tabel `trsalesorderdetail`
--

CREATE TABLE IF NOT EXISTS `trsalesorderdetail` (
  `KdSODetail` int(11) NOT NULL auto_increment,
  `KdSO` varchar(20) NOT NULL,
  `KdBarang` varchar(20) NOT NULL,
  `Harga` decimal(20,2) NOT NULL,
  `Qty` double NOT NULL,
  `Disc` double(10,2) NOT NULL,
  `StatusBarang` char(1) NOT NULL default '0',
  `HargaDisc` decimal(20,2) NOT NULL,
  PRIMARY KEY  (`KdSODetail`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=44 ;

--
-- Dumping data untuk tabel `trsalesorderdetail`
--

INSERT INTO `trsalesorderdetail` (`KdSODetail`, `KdSO`, `KdBarang`, `Harga`, `Qty`, `Disc`, `StatusBarang`, `HargaDisc`) VALUES
(7, 'SO0002.27.10.11', 'BG11100001', 25000.00, 5, 0.00, '2', 25000.00),
(8, 'SO0002.27.10.11', 'BG11100002', 35000.00, 2, 0.00, '2', 35000.00),
(9, 'SO0001.27.10.11', 'PK11100001', 75000.00, 2, 10.00, '2', 67500.00),
(10, 'SO0001.27.10.11', 'PK11100002', 50000.00, 5, 5.00, '2', 47500.00),
(11, 'SO0001.28.10.11', 'PK11100001', 75000.00, 3, 0.00, '2', 75000.00),
(12, 'SO0001.28.10.11', 'PK11100002', 50000.00, 5, 0.00, '2', 50000.00),
(14, 'SO0001.01.11.11', 'BG11100001', 25000.00, 2, 0.00, '2', 25000.00),
(15, 'SO0002.01.11.11', 'PK11100002', 50000.00, 2, 0.00, '0', 50000.00),
(16, 'SO0001.02.11.11', 'BG11100001', 25000.00, 2, 10.00, '0', 22500.00),
(17, 'SO0001.02.11.11', 'BG11100002', 35000.00, 3, 5.00, '0', 33250.00),
(28, 'SO0002.02.11.11', 'BG11100001', 25000.00, 2, 0.00, '2', 25000.00),
(29, 'SO0002.02.11.11', 'BG11100002', 35000.00, 2, 0.00, '2', 35000.00),
(30, 'SO0001.03.11.11', 'PK11100002', 50000.00, 2, 0.00, '2', 50000.00),
(31, 'SO0001.03.11.11', 'PK11100001', 75000.00, 2, 0.00, '2', 75000.00),
(32, 'SO0002.03.11.11', 'BG11100001', 25000.00, 1, 0.00, '2', 25000.00),
(33, 'SO0002.03.11.11', 'BG11100002', 35000.00, 1, 0.00, '2', 35000.00),
(36, 'SO0003.03.11.11', 'PK11100001', 75000.00, 1, 0.00, '2', 75000.00),
(37, 'SO0003.03.11.11', 'PK11100002', 50000.00, 2, 0.00, '2', 50000.00),
(38, 'SO0001.04.11.11', 'BG11110001', 622500.00, 1, 0.00, '2', 622500.00),
(39, 'SO0002.04.11.11', 'BG11110002', 900000.00, 2, 0.00, '2', 900000.00),
(40, 'SO0003.04.11.11', 'BG11110003', 5050000.00, 2, 0.00, '2', 5050000.00),
(41, 'SO0004.04.11.11', 'BG11110004', 2402500.00, 1, 0.00, '2', 2402500.00),
(42, 'SO0005.04.11.11', 'BG11110005', 5400000.00, 1, 0.00, '2', 5400000.00),
(43, 'SO0006.04.11.11', 'BG11110006', 250000.00, 1, 0.00, '2', 250000.00);

-- --------------------------------------------------------

--
-- Struktur dari tabel `trsalesorderdetailpending`
--

CREATE TABLE IF NOT EXISTS `trsalesorderdetailpending` (
  `KdSODetail` int(11) NOT NULL auto_increment,
  `KdSO` varchar(20) NOT NULL,
  `KdBarang` varchar(20) NOT NULL,
  `Harga` decimal(20,2) NOT NULL,
  `Qty` double NOT NULL,
  `Disc` double(10,2) NOT NULL,
  `StatusBarang` char(1) NOT NULL default '0',
  `HargaDisc` decimal(20,2) NOT NULL,
  PRIMARY KEY  (`KdSODetail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data untuk tabel `trsalesorderdetailpending`
--


-- --------------------------------------------------------

--
-- Struktur dari tabel `trsalespayment`
--

CREATE TABLE IF NOT EXISTS `trsalespayment` (
  `no_increment` bigint(20) NOT NULL auto_increment,
  `KdSalesPayment` varchar(20) NOT NULL,
  `KdFaktur` varchar(20) default NULL,
  `TanggalSalesPayment` datetime NOT NULL,
  `KdSales` varchar(20) NOT NULL,
  `KdToko` varchar(20) NOT NULL,
  `TotalSalesPayment` decimal(20,2) NOT NULL,
  `StatusSalesPayment` char(1) NOT NULL default '0',
  `Note` text NOT NULL,
  `UserID` varchar(20) NOT NULL,
  `PaidBy` char(1) default '1' COMMENT '1:LewatSales, 2:Langusng',
  `KdSO` varchar(20) default NULL,
  `flag_payment` char(1) default '0' COMMENT '0:perToko, 1:PerTanggal',
  `jenis_payment` enum('paku','klem') default 'paku',
  PRIMARY KEY  (`no_increment`,`KdSalesPayment`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data untuk tabel `trsalespayment`
--

INSERT INTO `trsalespayment` (`no_increment`, `KdSalesPayment`, `KdFaktur`, `TanggalSalesPayment`, `KdSales`, `KdToko`, `TotalSalesPayment`, `StatusSalesPayment`, `Note`, `UserID`, `PaidBy`, `KdSO`, `flag_payment`, `jenis_payment`) VALUES
(1, 'PF0001.09.11.11/SL11', 'FK0002.03.11.11', '2011-11-09 21:48:47', 'SL11090001', 'TK1109140001', 0.00, '0', '', 'US11010001', '1', NULL, '0', 'paku');

-- --------------------------------------------------------

--
-- Struktur dari tabel `trsalespaymentbydate`
--

CREATE TABLE IF NOT EXISTS `trsalespaymentbydate` (
  `no_increment` bigint(20) NOT NULL auto_increment,
  `KdSalesPayment` varchar(20) NOT NULL,
  `TanggalPayment` datetime default NULL,
  `DariTanggal` datetime default NULL,
  `SampaiTanggal` datetime NOT NULL,
  `KdSales` varchar(20) NOT NULL,
  `TotalSalesPayment` decimal(20,2) NOT NULL,
  `StatusSalesPayment` char(1) NOT NULL default '0',
  `Note` text NOT NULL,
  `UserID` varchar(20) NOT NULL,
  `flag_payment` char(1) default '0' COMMENT '0:perToko, 1:PerTanggal',
  `komisi_sales` double default '0',
  PRIMARY KEY  (`no_increment`,`KdSalesPayment`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data untuk tabel `trsalespaymentbydate`
--

INSERT INTO `trsalespaymentbydate` (`no_increment`, `KdSalesPayment`, `TanggalPayment`, `DariTanggal`, `SampaiTanggal`, `KdSales`, `TotalSalesPayment`, `StatusSalesPayment`, `Note`, `UserID`, `flag_payment`, `komisi_sales`) VALUES
(1, 'PF0001.04.11.11', '2011-11-04 00:31:17', '2011-11-04 00:31:17', '2011-12-04 00:31:17', 'SL11110001', 17157360.00, '1', '', '', '1', 16);

-- --------------------------------------------------------

--
-- Struktur dari tabel `trsalespaymentbydatedetail`
--

CREATE TABLE IF NOT EXISTS `trsalespaymentbydatedetail` (
  `KdSalesPaymentDetail` double NOT NULL auto_increment,
  `KdSalesPayment` varchar(20) default NULL,
  `KdFaktur` varchar(20) default NULL,
  `GrandtotalFaktur` decimal(20,2) default '0.00',
  `PaidBy` char(1) default '0' COMMENT '0:Lewat Sales, 1:Langsung ke om acu',
  PRIMARY KEY  (`KdSalesPaymentDetail`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=26 ;

--
-- Dumping data untuk tabel `trsalespaymentbydatedetail`
--

INSERT INTO `trsalespaymentbydatedetail` (`KdSalesPaymentDetail`, `KdSalesPayment`, `KdFaktur`, `GrandtotalFaktur`, `PaidBy`) VALUES
(20, 'PF0001.04.11.11', 'FK0006.04.11.11', 560.00, '0'),
(21, 'PF0001.04.11.11', 'FK0003.04.11.11', 2.00, '0'),
(22, 'PF0001.04.11.11', 'FK0005.04.11.11', 1.00, '0'),
(23, 'PF0001.04.11.11', 'FK0002.04.11.11', 5.00, '0'),
(24, 'PF0001.04.11.11', 'FK0004.04.11.11', 10.00, '0'),
(25, 'PF0001.04.11.11', 'FK0001.04.11.11', 225.00, '0');

-- --------------------------------------------------------

--
-- Struktur dari tabel `trsalespaymentdetail`
--

CREATE TABLE IF NOT EXISTS `trsalespaymentdetail` (
  `KdSalesPaymentDetail` double NOT NULL auto_increment,
  `KdSalesPayment` varchar(20) default NULL,
  `KdBarang` varchar(20) default NULL,
  `Harga` decimal(20,2) default NULL,
  `Qty` double default NULL,
  `Disc` double default NULL,
  `StatusBarang` varchar(200) default NULL,
  `HargaDisc` decimal(20,2) default '0.00',
  PRIMARY KEY  (`KdSalesPaymentDetail`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data untuk tabel `trsalespaymentdetail`
--

INSERT INTO `trsalespaymentdetail` (`KdSalesPaymentDetail`, `KdSalesPayment`, `KdBarang`, `Harga`, `Qty`, `Disc`, `StatusBarang`, `HargaDisc`) VALUES
(1, 'PF0001.09.11.11/SL11', 'PK11100001', 75000.00, 1, 0, 'Retur', 75000.00),
(2, 'PF0001.09.11.11/SL11', 'PK11100002', 50000.00, 2, 0, 'Normal', 50000.00);

-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcetaklaplrus11010001`
--
CREATE TABLE IF NOT EXISTS `viewcetaklaplrus11010001` (
`No Faktur` varchar(20)
,`Tgl Faktur` varchar(72)
,`NamaToko` varchar(200)
,`Total Laba/Rugi` double
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcetaklappembayaranpiutangus11010001`
--
CREATE TABLE IF NOT EXISTS `viewcetaklappembayaranpiutangus11010001` (
`No Pembayaran` varchar(20)
,`Tgl Pembayaran` varchar(10)
,`Nama Toko` varchar(200)
,`No Faktur` varchar(20)
,`Total Pembayaran` decimal(20,2)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcetaklappembayaranutangus11010001`
--
CREATE TABLE IF NOT EXISTS `viewcetaklappembayaranutangus11010001` (
`No Pembayaran` varchar(20)
,`Tgl Pembayaran` varchar(10)
,`Nama Supplier` varchar(200)
,`No Penerimaan Barang` varchar(20)
,`No Pemesanan` varchar(20)
,`Total Pembayaran` decimal(20,2)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcetaklappenjualanus11010001`
--
CREATE TABLE IF NOT EXISTS `viewcetaklappenjualanus11010001` (
`No Faktur` varchar(20)
,`Tgl Faktur` varchar(10)
,`No Pemesanan` varchar(20)
,`Tgl Pemesanan` varchar(10)
,`NamaToko` varchar(200)
,`Kode Barang` varchar(20)
,`NamaBarang` varchar(200)
,`Merk` varchar(50)
,`Qty` double
,`Harga` decimal(20,2)
,`Disc (%)` double
,`Total` double
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcetaklappous11010001`
--
CREATE TABLE IF NOT EXISTS `viewcetaklappous11010001` (
`No Pemesanan` varchar(20)
,`Tgl Pemesanan` varchar(10)
,`Supplier` varchar(200)
,`Part No.` varchar(20)
,`NamaBarang` varchar(200)
,`Qty` float
,`Status PO` varchar(15)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcetaklaprbus11010001`
--
CREATE TABLE IF NOT EXISTS `viewcetaklaprbus11010001` (
`Tgl Retur` varchar(10)
,`Supplier` varchar(200)
,`Part No.` varchar(20)
,`NamaBarang` varchar(200)
,`Qty` double
,`Harga` varchar(28)
,`Total` double
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcetaklaprjus11010001`
--
CREATE TABLE IF NOT EXISTS `viewcetaklaprjus11010001` (
`No Retur` varchar(20)
,`Tgl Retur` varchar(10)
,`NamaToko` varchar(200)
,`Part No.` varchar(20)
,`NamaBarang` varchar(200)
,`Merk` varchar(50)
,`Qty` double
,`Harga` decimal(20,2)
,`Disc` double
,`Total` double
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcetaklapsous11010001`
--
CREATE TABLE IF NOT EXISTS `viewcetaklapsous11010001` (
`No Pemesanan` varchar(20)
,`Tgl SO` varchar(10)
,`NamaToko` varchar(200)
,`Part No.` varchar(20)
,`NamaBarang` varchar(200)
,`Qty` double
,`Harga` varchar(28)
,`Disc (%)` double(10,2)
,`Total` double
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcetakpbus11010001`
--
CREATE TABLE IF NOT EXISTS `viewcetakpbus11010001` (
`No_PB` varchar(20)
,`Tanggal_TerimaBarang` datetime
,`NO_PO` varchar(20)
,`Tanggal_PO` datetime
,`kdbahanmentah` varchar(20)
,`NamaBahanMentah` varchar(200)
,`Harga` decimal(20,2)
,`Qty` double
,`Nama` varchar(200)
,`Alamat` text
,`Daerah` varchar(100)
,`NoTelp` varchar(20)
,`NoHP` varchar(20)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcetakpous11010001`
--
CREATE TABLE IF NOT EXISTS `viewcetakpous11010001` (
`NO_PO` varchar(20)
,`Tanggal_PO` datetime
,`KdBahanMentah` varchar(20)
,`NamaBahanMentah` varchar(200)
,`Harga` float
,`Jumlah` float
,`Ukuran` int(11)
,`satuan` enum('Karung','Kardus')
,`Nama` varchar(200)
,`Alamat` text
,`Daerah` varchar(100)
,`NoTelp` varchar(20)
,`NoHP` varchar(20)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcetaksalespaymentbydate`
--
CREATE TABLE IF NOT EXISTS `viewcetaksalespaymentbydate` (
`KdFaktur` varchar(20)
,`Tanggal` varchar(10)
,`KdSO` varchar(20)
,`KdToko` varchar(20)
,`NamaToko` varchar(200)
,`GrandTotal` decimal(20,2)
,`KomisiPersen` double(20,2)
,`TotalKomisiSales` decimal(20,2)
,`PaidBy` varchar(1)
,`disc_faktur` double
,`Jumlah` decimal(20,2)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcetaktrfakturus11010001`
--
CREATE TABLE IF NOT EXISTS `viewcetaktrfakturus11010001` (
`KdSo` varchar(20)
,`TanggalSO` datetime
,`NamaToko` varchar(200)
,`No Faktur` varchar(20)
,`Tgl Faktur` datetime
,`KdBarang` varchar(20)
,`NamaBarang` varchar(200)
,`harga` decimal(20,2)
,`qty` double
,`disc` double
,`HargaDisc` decimal(20,2)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcetaktrreturbelius11010001`
--
CREATE TABLE IF NOT EXISTS `viewcetaktrreturbelius11010001` (
`KdRetur` varchar(20)
,`TanggalRetur` datetime
,`No Penerimaan` varchar(20)
,`Nama` varchar(200)
,`Grandtotal` decimal(20,2)
,`KDBarang` varchar(20)
,`NamaBarang` varchar(200)
,`harga` decimal(20,2)
,`disc` float(3,2)
,`qty` double
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcetaktrreturjualus11010001`
--
CREATE TABLE IF NOT EXISTS `viewcetaktrreturjualus11010001` (
`KdRetur` varchar(20)
,`TanggalRetur` datetime
,`KdSO` varchar(20)
,`NamaSales` varchar(200)
,`NamaToko` varchar(200)
,`Grandtotal` decimal(20,2)
,`KDBarang` varchar(20)
,`NamaBarang` varchar(200)
,`harga` decimal(20,2)
,`qty` double
,`disc` double
,`HargaDisc` decimal(20,2)
,`KdFaktur` varchar(20)
,`StatusBarang` varchar(20)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcetaktrsous11010001`
--
CREATE TABLE IF NOT EXISTS `viewcetaktrsous11010001` (
`KdSO` varchar(20)
,`TanggalSO` datetime
,`GrandTotal` decimal(20,2)
,`StatusSO` char(1)
,`KdBarang` varchar(20)
,`NamaBarang` varchar(200)
,`Harga` decimal(20,2)
,`Qty` double
,`Disc` double(10,2)
,`Statusbarang` char(1)
,`NamaSales` varchar(200)
,`Alamat` text
,`NoTelpSales` varchar(20)
,`NoHPSales` varchar(20)
,`NamaToko` varchar(200)
,`AlamatToko` text
,`Daerah` varchar(200)
,`NoTelpCustomer` varchar(20)
,`NoHPCustomer` varchar(20)
);
-- --------------------------------------------------------

--
-- Struktur dari tabel `v_salespayment_bydate`
--

CREATE TABLE IF NOT EXISTS `v_salespayment_bydate` (
  `id` int(11) NOT NULL auto_increment,
  `KdFaktur` varchar(50) default NULL,
  `TglFaktur` varchar(50) default NULL,
  `KdSO` varchar(50) default NULL,
  `NamaToko` varchar(100) default NULL,
  `Jumlah` double default NULL,
  `Disc` double default NULL,
  `TotalFaktur` double default NULL,
  `Pembayaran` varchar(20) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data untuk tabel `v_salespayment_bydate`
--

INSERT INTO `v_salespayment_bydate` (`id`, `KdFaktur`, `TglFaktur`, `KdSO`, `NamaToko`, `Jumlah`, `Disc`, `TotalFaktur`, `Pembayaran`) VALUES
(1, 'FK0001.04.11.11', '11/04/2011', 'SO0006.04.11.11', 'Musi Indah', 250000, 10, 225000, 'Tidak'),
(2, 'FK0002.04.11.11', '11/04/2011', 'SO0005.04.11.11', 'Bintang Teranng', 5400000, 0, 5400000, 'Tidak'),
(3, 'FK0003.04.11.11', '11/04/2011', 'SO0004.04.11.11', 'Sinar Abadi', 2402500, 0, 2402500, 'Tidak'),
(4, 'FK0004.04.11.11', '11/04/2011', 'SO0003.04.11.11', 'Bintang Teranng', 10100000, 0, 10100000, 'Tidak'),
(5, 'FK0005.04.11.11', '11/04/2011', 'SO0002.04.11.11', 'Sinar Abadi', 1800000, 0, 1800000, 'Tidak'),
(6, 'FK0006.04.11.11', '11/04/2011', 'SO0001.04.11.11', 'Sinar Bintang', 622500, 10, 560250, 'Tidak');

-- --------------------------------------------------------

--
-- Struktur dari tabel `v_total_pb`
--

CREATE TABLE IF NOT EXISTS `v_total_pb` (
  `id` int(11) NOT NULL auto_increment,
  `NO_PO` varchar(20) default NULL,
  `NO_PB` varchar(20) default NULL,
  `Tgl_Terima_Barang` varchar(30) default NULL,
  `Supplier` varchar(60) default NULL,
  `Part_No` varchar(20) default NULL,
  `NamaBarang` varchar(50) default NULL,
  `Merk` varchar(50) default NULL,
  `Subkategori` varchar(50) default NULL,
  `Qty` int(11) default NULL,
  `Harga` int(11) default NULL,
  `Total` int(11) default NULL,
  `Pembayaran` varchar(20) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data untuk tabel `v_total_pb`
--

INSERT INTO `v_total_pb` (`id`, `NO_PO`, `NO_PB`, `Tgl_Terima_Barang`, `Supplier`, `Part_No`, `NamaBarang`, `Merk`, `Subkategori`, `Qty`, `Harga`, `Total`, `Pembayaran`) VALUES
(1, 'PO11110001', 'PB11110001', '04-11-2011', '2', 'KL11100001', 'Klem mentah -4', '', '', 5, 20000, 100000, 'Lunas');

-- --------------------------------------------------------

--
-- Structure for view `viewcetaklaplrus11010001`
--
DROP TABLE IF EXISTS `viewcetaklaplrus11010001`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_dai`.`viewcetaklaplrus11010001` AS (select `bgh`.`RefNumber` AS `No Faktur`,date_format(`ho`.`TanggalFaktur`,_latin1'%d %M %Y') AS `Tgl Faktur`,`c`.`NamaToko` AS `NamaToko`,sum((((`df`.`Harga` - ((`df`.`Harga` * `df`.`Disc`) / 100)) - `bgh`.`HargaAwal`) * (`df`.`Qty` - ifnull((select ifnull(`dr`.`Qty`,0) AS `ifnull(qty,0)` from (`db_dai`.`trretur` `r` join `db_dai`.`trreturdetail` `dr` on((`dr`.`KdRetur` = `r`.`KdRetur`))) where ((`r`.`KdFaktur` = `bgh`.`RefNumber`) and (`dr`.`KdBarang` = `df`.`KdBarang`))),0)))) AS `Total Laba/Rugi` from (((`db_dai`.`trfakturdetail` `df` join `db_dai`.`baranghistory` `bgh` on((`bgh`.`KdBarang` = `df`.`KdBarang`))) join `db_dai`.`trfaktur` `ho` on((`ho`.`KdFaktur` = `bgh`.`RefNumber`))) join `db_dai`.`mstoko` `c` on((`c`.`KdToko` = `ho`.`KdToko`))) where ((`bgh`.`Module` = _latin1'Form Faktur') and `bgh`.`RefNumber` in (select `db_dai`.`trfaktur`.`KdFaktur` AS `kdfaktur` from `db_dai`.`trfaktur` where ((date_format(`db_dai`.`trfaktur`.`TanggalFaktur`,_latin1'%Y-%m-%d') >= _utf8'2011-01-11') and (date_format(`db_dai`.`trfaktur`.`TanggalFaktur`,_latin1'%Y-%m-%d') <= _utf8'2011-11-09') and (`db_dai`.`trfaktur`.`StatusFaktur` <> 0) and (`db_dai`.`trfaktur`.`StatusPayment` = 1)))) group by `bgh`.`RefNumber` order by `bgh`.`RefNumber`);

-- --------------------------------------------------------

--
-- Structure for view `viewcetaklappembayaranpiutangus11010001`
--
DROP TABLE IF EXISTS `viewcetaklappembayaranpiutangus11010001`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_dai`.`viewcetaklappembayaranpiutangus11010001` AS (select `ho`.`KdSalesPayment` AS `No Pembayaran`,date_format(`ho`.`TanggalSalesPayment`,_latin1'%d/%m/%Y') AS `Tgl Pembayaran`,`c`.`NamaToko` AS `Nama Toko`,`ho`.`KdFaktur` AS `No Faktur`,`ho`.`TotalSalesPayment` AS `Total Pembayaran` from (`db_dai`.`trsalespayment` `ho` join `db_dai`.`mstoko` `c` on((`c`.`KdToko` = `ho`.`KdToko`))) where ((date_format(`ho`.`TanggalSalesPayment`,_latin1'%Y-%m-%d') >= _utf8'2011-01-11') and (date_format(`ho`.`TanggalSalesPayment`,_latin1'%Y-%m-%d') <= _utf8'2011-11-08') and (`ho`.`StatusSalesPayment` = 1)));

-- --------------------------------------------------------

--
-- Structure for view `viewcetaklappembayaranutangus11010001`
--
DROP TABLE IF EXISTS `viewcetaklappembayaranutangus11010001`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_dai`.`viewcetaklappembayaranutangus11010001` AS (select `ho`.`KdPurchasePayment` AS `No Pembayaran`,date_format(`ho`.`TanggalPurchasePayment`,_latin1'%d/%m/%Y') AS `Tgl Pembayaran`,`c`.`Nama` AS `Nama Supplier`,`ho`.`No_PB` AS `No Penerimaan Barang`,`hpb`.`No_PO` AS `No Pemesanan`,`ho`.`TotalPurchasePayment` AS `Total Pembayaran` from ((`db_dai`.`trpurchasepayment` `ho` join `db_dai`.`mssupplier` `c` on((`c`.`KdSupplier` = `ho`.`KdSupplier`))) join `db_dai`.`trheaderpb` `hpb` on((`hpb`.`No_PB` = `ho`.`No_PB`))) where ((date_format(`ho`.`TanggalPurchasePayment`,_latin1'%Y-%m-%d') >= _utf8'2011-01-11') and (date_format(`ho`.`TanggalPurchasePayment`,_latin1'%Y-%m-%d') <= _utf8'2011-11-09') and (`ho`.`StatusPurchasePayment` = 1)));

-- --------------------------------------------------------

--
-- Structure for view `viewcetaklappenjualanus11010001`
--
DROP TABLE IF EXISTS `viewcetaklappenjualanus11010001`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_dai`.`viewcetaklappenjualanus11010001` AS (select `hr`.`KdFaktur` AS `No Faktur`,date_format(`hr`.`TanggalFaktur`,_latin1'%d-%m-%Y') AS `Tgl Faktur`,`hr`.`KdSO` AS `No Pemesanan`,date_format(`so`.`TanggalSO`,_latin1'%d-%m-%Y') AS `Tgl Pemesanan`,`c`.`NamaToko` AS `NamaToko`,`mp`.`KdBarang` AS `Kode Barang`,`mp`.`NamaBarang` AS `NamaBarang`,`db_dai`.`msmerk`.`merk` AS `Merk`,`dr`.`Qty` AS `Qty`,`dr`.`HargaDisc` AS `Harga`,`dr`.`Disc` AS `Disc (%)`,sum((`dr`.`Qty` * `dr`.`HargaDisc`)) AS `Total` from (((((`db_dai`.`trfaktur` `hr` join `db_dai`.`mstoko` `c` on((`c`.`KdToko` = `hr`.`KdToko`))) join `db_dai`.`trfakturdetail` `dr` on((`dr`.`KdFaktur` = `hr`.`KdFaktur`))) join `db_dai`.`msbarang` `mp` on((`mp`.`KdBarang` = `dr`.`KdBarang`))) join `db_dai`.`msmerk` on((`db_dai`.`msmerk`.`kdmerk` = `mp`.`KdMerk`))) join `db_dai`.`trsalesorder` `so` on((`so`.`KdSO` = `hr`.`KdSO`))) where ((date_format(`hr`.`TanggalFaktur`,_latin1'%Y-%m-%d') >= _utf8'2011-01-11') and (date_format(`hr`.`TanggalFaktur`,_latin1'%Y-%m-%d') <= _utf8'2011-11-07') and (`hr`.`StatusFaktur` <> 0) and (`hr`.`jenis_faktur` = _latin1'klem')) group by `hr`.`KdFaktur`,date_format(`hr`.`TanggalFaktur`,_latin1'%d-%m-%Y'),`hr`.`KdSO`,`so`.`TanggalSO`,`c`.`NamaToko`,`dr`.`KdBarang`,`mp`.`NamaBarang`,`db_dai`.`msmerk`.`merk`,`dr`.`Qty`,`dr`.`Harga`,`dr`.`Disc`);

-- --------------------------------------------------------

--
-- Structure for view `viewcetaklappous11010001`
--
DROP TABLE IF EXISTS `viewcetaklappous11010001`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_dai`.`viewcetaklappous11010001` AS (select `ho`.`No_PO` AS `No Pemesanan`,date_format(`ho`.`Tanggal_PO`,_latin1'%d-%m-%Y') AS `Tgl Pemesanan`,`c`.`Nama` AS `Supplier`,`mp`.`KdBahanMentah` AS `Part No.`,`mp`.`NamaBahanMentah` AS `NamaBarang`,`do`.`jumlah` AS `Qty`,(case when (`ho`.`StatusPO` = 0) then _latin1'New' when (`ho`.`StatusPO` = 1) then _latin1'Confirm' when (`ho`.`StatusPO` = 2) then _latin1'Barang Diterima' end) AS `Status PO` from (((`db_dai`.`trheaderpo` `ho` join `db_dai`.`trdetailpo` `do` on((`ho`.`No_PO` = `do`.`no_po`))) join `db_dai`.`msbahanmentah` `mp` on((`mp`.`KdBahanMentah` = `do`.`kdbahanmentah`))) join `db_dai`.`mssupplier` `c` on((`c`.`KdSupplier` = `ho`.`KdSupplier`))) where ((date_format(`ho`.`Tanggal_PO`,_latin1'%Y-%m-%d') >= _utf8'2011-01-11') and (date_format(`ho`.`Tanggal_PO`,_latin1'%Y-%m-%d') <= _utf8'2011-11-08') and (`ho`.`StatusPO` <> 0)));

-- --------------------------------------------------------

--
-- Structure for view `viewcetaklaprbus11010001`
--
DROP TABLE IF EXISTS `viewcetaklaprbus11010001`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_dai`.`viewcetaklaprbus11010001` AS (select date_format(`hr`.`TanggalRetur`,_latin1'%d-%m-%Y') AS `Tgl Retur`,`c`.`Nama` AS `Supplier`,`mp`.`KdBahanMentah` AS `Part No.`,`mp`.`NamaBahanMentah` AS `NamaBarang`,`dr`.`Qty` AS `Qty`,format(`dr`.`Harga`,0) AS `Harga`,sum((`dr`.`Qty` * `dr`.`Harga`)) AS `Total` from ((((`db_dai`.`trheaderpb` `pb` join `db_dai`.`mssupplier` `c` on((`c`.`KdSupplier` = `pb`.`KdSupplier`))) join `db_dai`.`trheaderreturbeli` `hr` on((`hr`.`KdPB` = `pb`.`No_PB`))) join `db_dai`.`trdetailreturbeli` `dr` on((`dr`.`KdRetur` = `hr`.`KdRetur`))) join `db_dai`.`msbahanmentah` `mp` on((`mp`.`KdBahanMentah` = `dr`.`KdBahanMentah`))) where ((date_format(`hr`.`TanggalRetur`,_latin1'%Y-%m-%d') >= _utf8'2011-01-11') and (date_format(`hr`.`TanggalRetur`,_latin1'%Y-%m-%d') <= _utf8'2011-11-08') and (`hr`.`StatusRetur` <> 0)) group by date_format(`hr`.`TanggalRetur`,_latin1'%d-%m-%Y'),`c`.`Nama`,`dr`.`KdBahanMentah`,`mp`.`NamaBahanMentah`,`dr`.`Qty`,`dr`.`Harga`);

-- --------------------------------------------------------

--
-- Structure for view `viewcetaklaprjus11010001`
--
DROP TABLE IF EXISTS `viewcetaklaprjus11010001`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_dai`.`viewcetaklaprjus11010001` AS (select `dr`.`KdRetur` AS `No Retur`,date_format(`hr`.`TanggalRetur`,_latin1'%d-%m-%Y') AS `Tgl Retur`,`c`.`NamaToko` AS `NamaToko`,`mp`.`KdBarang` AS `Part No.`,`mp`.`NamaBarang` AS `NamaBarang`,`db_dai`.`msmerk`.`merk` AS `Merk`,`dr`.`Qty` AS `Qty`,`dr`.`HargaDisc` AS `Harga`,`dr`.`Disc` AS `Disc`,sum((`dr`.`Qty` * `dr`.`HargaDisc`)) AS `Total` from (((((`db_dai`.`trfaktur` `ho` join `db_dai`.`mstoko` `c` on((`c`.`KdToko` = `ho`.`KdToko`))) join `db_dai`.`trretur` `hr` on((`hr`.`KdFaktur` = `ho`.`KdFaktur`))) join `db_dai`.`trreturdetail` `dr` on((`dr`.`KdRetur` = `hr`.`KdRetur`))) join `db_dai`.`msbarang` `mp` on((`mp`.`KdBarang` = `dr`.`KdBarang`))) join `db_dai`.`msmerk` on((`db_dai`.`msmerk`.`kdmerk` = `mp`.`KdMerk`))) where ((date_format(`hr`.`TanggalRetur`,_latin1'%Y-%m-%d') >= _utf8'2011-01-11') and (date_format(`hr`.`TanggalRetur`,_latin1'%Y-%m-%d') <= _utf8'2011-11-07') and (`hr`.`StatusRetur` <> 0) and (`hr`.`jenis_retur` = _latin1'klem')) group by `dr`.`KdRetur`,date_format(`hr`.`TanggalRetur`,_latin1'%d-%m-%Y'),`c`.`NamaToko`,`dr`.`KdBarang`,`mp`.`NamaBarang`,`db_dai`.`msmerk`.`merk`,`dr`.`Qty`,`dr`.`Harga`,`dr`.`Disc`);

-- --------------------------------------------------------

--
-- Structure for view `viewcetaklapsous11010001`
--
DROP TABLE IF EXISTS `viewcetaklapsous11010001`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_dai`.`viewcetaklapsous11010001` AS (select `hr`.`KdSO` AS `No Pemesanan`,date_format(`hr`.`TanggalSO`,_latin1'%d-%m-%Y') AS `Tgl SO`,`c`.`NamaToko` AS `NamaToko`,`mp`.`KdBahanMentah` AS `Part No.`,`mp`.`NamaBahanMentah` AS `NamaBarang`,`dr`.`Qty` AS `Qty`,format(`dr`.`HargaDisc`,0) AS `Harga`,`dr`.`Disc` AS `Disc (%)`,sum((`dr`.`Qty` * `dr`.`HargaDisc`)) AS `Total` from (((`db_dai`.`trsalesorder` `hr` join `db_dai`.`mstoko` `c` on((`c`.`KdToko` = `hr`.`KdToko`))) join `db_dai`.`trsalesorderdetail` `dr` on((`dr`.`KdSO` = `hr`.`KdSO`))) join `db_dai`.`msbahanmentah` `mp` on((`mp`.`KdBahanMentah` = `dr`.`KdBarang`))) where ((date_format(`hr`.`TanggalSO`,_latin1'%Y-%m-%d') >= _utf8'2011-01-11') and (date_format(`hr`.`TanggalSO`,_latin1'%Y-%m-%d') <= _utf8'2011-11-09') and (`hr`.`StatusSO` <> 0) and (`hr`.`jenis_so` = _latin1'paku')) group by `hr`.`KdSO`,date_format(`hr`.`TanggalSO`,_latin1'%d-%m-%Y'),`c`.`NamaToko`,`dr`.`KdBarang`,`mp`.`NamaBahanMentah`,`dr`.`Qty`,`dr`.`Harga`,`dr`.`Disc`);

-- --------------------------------------------------------

--
-- Structure for view `viewcetakpbus11010001`
--
DROP TABLE IF EXISTS `viewcetakpbus11010001`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_dai`.`viewcetakpbus11010001` AS (select `pb`.`No_PB` AS `No_PB`,`pb`.`Tanggal_TerimaBarang` AS `Tanggal_TerimaBarang`,`po`.`No_PO` AS `NO_PO`,`po`.`Tanggal_PO` AS `Tanggal_PO`,`pod`.`kdbahanmentah` AS `kdbahanmentah`,`mb`.`NamaBahanMentah` AS `NamaBahanMentah`,`pod`.`Harga` AS `Harga`,`pod`.`Qty` AS `Qty`,`ms`.`Nama` AS `Nama`,`ms`.`Alamat` AS `Alamat`,`ms`.`Daerah` AS `Daerah`,`ms`.`NoTelp` AS `NoTelp`,`ms`.`NoHP` AS `NoHP` from ((((`db_dai`.`trheaderpo` `PO` join `db_dai`.`trheaderpb` `pb` on((`pb`.`No_PO` = `po`.`No_PO`))) join `db_dai`.`trdetailpb` `POD` on((`pb`.`No_PB` = `pod`.`No_PB`))) join `db_dai`.`mssupplier` `MS` on((`ms`.`KdSupplier` = `po`.`KdSupplier`))) join `db_dai`.`msbahanmentah` `MB` on((`mb`.`KdBahanMentah` = `pod`.`kdbahanmentah`))) where (`pb`.`No_PB` = _latin1'PB11110001'));

-- --------------------------------------------------------

--
-- Structure for view `viewcetakpous11010001`
--
DROP TABLE IF EXISTS `viewcetakpous11010001`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_dai`.`viewcetakpous11010001` AS (select `po`.`No_PO` AS `NO_PO`,`po`.`Tanggal_PO` AS `Tanggal_PO`,`mb`.`KdBahanMentah` AS `KdBahanMentah`,`mb`.`NamaBahanMentah` AS `NamaBahanMentah`,`pod`.`harga` AS `Harga`,`pod`.`jumlah` AS `Jumlah`,`mb`.`Ukuran` AS `Ukuran`,`mb`.`Satuan` AS `satuan`,`ms`.`Nama` AS `Nama`,`ms`.`Alamat` AS `Alamat`,`ms`.`Daerah` AS `Daerah`,`ms`.`NoTelp` AS `NoTelp`,`ms`.`NoHP` AS `NoHP` from (((`db_dai`.`trheaderpo` `PO` join `db_dai`.`trdetailpo` `POD` on((`pod`.`no_po` = `po`.`No_PO`))) join `db_dai`.`mssupplier` `MS` on((`ms`.`KdSupplier` = `po`.`KdSupplier`))) join `db_dai`.`msbahanmentah` `MB` on((`pod`.`kdbahanmentah` = `mb`.`KdBahanMentah`))) where (`po`.`No_PO` = _latin1'PO11110001'));

-- --------------------------------------------------------

--
-- Structure for view `viewcetaksalespaymentbydate`
--
DROP TABLE IF EXISTS `viewcetaksalespaymentbydate`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_dai`.`viewcetaksalespaymentbydate` AS (select `faktur`.`KdFaktur` AS `KdFaktur`,date_format(`faktur`.`TanggalFaktur`,_latin1'%m/%d/%Y') AS `Tanggal`,`faktur`.`KdSO` AS `KdSO`,`mt`.`KdToko` AS `KdToko`,`mt`.`NamaToko` AS `NamaToko`,`faktur`.`GrandTotal` AS `GrandTotal`,`faktur`.`KomisiPersen` AS `KomisiPersen`,`faktur`.`TotalKomisiSales` AS `TotalKomisiSales`,ifnull(`pd`.`PaidBy`,0) AS `PaidBy`,`faktur`.`Disc` AS `disc_faktur`,`faktur`.`Jumlah` AS `Jumlah` from ((((`db_dai`.`trfaktur` `faktur` join `db_dai`.`mssales` `MS` on((`ms`.`KdSales` = `faktur`.`KdSales`))) join `db_dai`.`mstoko` `MT` on((`mt`.`KdToko` = `faktur`.`KdToko`))) join `db_dai`.`trsalespaymentbydatedetail` `pd` on((`pd`.`KdFaktur` = `faktur`.`KdFaktur`))) join `db_dai`.`trsalespaymentbydate` `payment` on((`pd`.`KdSalesPayment` = `payment`.`KdSalesPayment`))) where ((`faktur`.`KdSales` = _latin1'SL11110001') and (`payment`.`KdSalesPayment` = _latin1'PF0001.04.11.11') and (date_format(`payment`.`DariTanggal`,_latin1'%Y/%m/%d') >= _utf8'2011/11/04') and (date_format(`payment`.`SampaiTanggal`,_latin1'%Y/%m/%d') <= _utf8'2011/12/04')));

-- --------------------------------------------------------

--
-- Structure for view `viewcetaktrfakturus11010001`
--
DROP TABLE IF EXISTS `viewcetaktrfakturus11010001`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_dai`.`viewcetaktrfakturus11010001` AS (select `so`.`KdSO` AS `KdSo`,`so`.`TanggalSO` AS `TanggalSO`,`c`.`NamaToko` AS `NamaToko`,`ho`.`KdFaktur` AS `No Faktur`,`ho`.`TanggalFaktur` AS `Tgl Faktur`,`mp`.`KdBarang` AS `KdBarang`,`mp`.`NamaBarang` AS `NamaBarang`,`do`.`Harga` AS `harga`,`do`.`Qty` AS `qty`,`do`.`Disc` AS `disc`,`do`.`HargaDisc` AS `HargaDisc` from ((((`db_dai`.`trsalesorder` `so` join `db_dai`.`trfaktur` `ho` on((`so`.`KdSO` = `ho`.`KdSO`))) join `db_dai`.`trfakturdetail` `do` on((`ho`.`KdFaktur` = `do`.`KdFaktur`))) join `db_dai`.`msbarang` `mp` on((`mp`.`KdBarang` = `do`.`KdBarang`))) join `db_dai`.`mstoko` `c` on((`c`.`KdToko` = `ho`.`KdToko`))) where (`ho`.`KdFaktur` = _latin1'FK0002.09.11.11'));

-- --------------------------------------------------------

--
-- Structure for view `viewcetaktrreturbelius11010001`
--
DROP TABLE IF EXISTS `viewcetaktrreturbelius11010001`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_dai`.`viewcetaktrreturbelius11010001` AS (select `retur`.`KdRetur` AS `KdRetur`,`retur`.`TanggalRetur` AS `TanggalRetur`,`retur`.`KdPB` AS `No Penerimaan`,`mt`.`Nama` AS `Nama`,`retur`.`GrandTotal` AS `Grandtotal`,`mp`.`KdBahanMentah` AS `KDBarang`,`mp`.`NamaBahanMentah` AS `NamaBarang`,`rd`.`Harga` AS `harga`,`rd`.`Disc` AS `disc`,`rd`.`Qty` AS `qty` from (((((`db_dai`.`trheaderreturbeli` `retur` join `db_dai`.`trheaderpb` `pb` on((`pb`.`No_PB` = `retur`.`KdPB`))) join `db_dai`.`trdetailreturbeli` `rd` on((`rd`.`KdRetur` = `retur`.`KdRetur`))) join `db_dai`.`msbahanmentah` `mp` on((`mp`.`KdBahanMentah` = `rd`.`KdBahanMentah`))) join `db_dai`.`mssupplier` `mt` on((`mt`.`KdSupplier` = `pb`.`KdSupplier`))) join `db_dai`.`msuser` `mu` on((`mu`.`userid` = `retur`.`UserID`))) where (`retur`.`KdRetur` = _latin1'RB1111050001'));

-- --------------------------------------------------------

--
-- Structure for view `viewcetaktrreturjualus11010001`
--
DROP TABLE IF EXISTS `viewcetaktrreturjualus11010001`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_dai`.`viewcetaktrreturjualus11010001` AS (select `retur`.`KdRetur` AS `KdRetur`,`retur`.`TanggalRetur` AS `TanggalRetur`,`retur`.`KdSO` AS `KdSO`,`ms`.`NamaSales` AS `NamaSales`,`mt`.`NamaToko` AS `NamaToko`,`retur`.`GrandTotal` AS `Grandtotal`,`mp`.`KdBarang` AS `KDBarang`,`mp`.`NamaBarang` AS `NamaBarang`,`rd`.`Harga` AS `harga`,`rd`.`Qty` AS `qty`,`rd`.`Disc` AS `disc`,`rd`.`HargaDisc` AS `HargaDisc`,`retur`.`KdFaktur` AS `KdFaktur`,`rd`.`StatusBarang` AS `StatusBarang` from (((((`db_dai`.`trretur` `retur` join `db_dai`.`trreturdetail` `rd` on((`rd`.`KdRetur` = `retur`.`KdRetur`))) join `db_dai`.`msbarang` `mp` on((`mp`.`KdBarang` = `rd`.`KdBarang`))) join `db_dai`.`mssales` `ms` on((`ms`.`KdSales` = `retur`.`KdSales`))) join `db_dai`.`mstoko` `mt` on((`mt`.`KdToko` = `retur`.`KdToko`))) join `db_dai`.`msuser` `mu` on((`mu`.`userid` = `retur`.`UserID`))) where (`retur`.`KdRetur` = _latin1'RF0003.28.10.11'));

-- --------------------------------------------------------

--
-- Structure for view `viewcetaktrsous11010001`
--
DROP TABLE IF EXISTS `viewcetaktrsous11010001`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_dai`.`viewcetaktrsous11010001` AS (select `so`.`KdSO` AS `KdSO`,`so`.`TanggalSO` AS `TanggalSO`,`so`.`GrandTotal` AS `GrandTotal`,`so`.`StatusSO` AS `StatusSO`,`sod`.`KdBarang` AS `KdBarang`,`mb`.`NamaBarang` AS `NamaBarang`,`sod`.`HargaDisc` AS `Harga`,`sod`.`Qty` AS `Qty`,`sod`.`Disc` AS `Disc`,`sod`.`StatusBarang` AS `Statusbarang`,`ms`.`NamaSales` AS `NamaSales`,`ms`.`Alamat` AS `Alamat`,`ms`.`NoTelp` AS `NoTelpSales`,`ms`.`NoHP` AS `NoHPSales`,`mt`.`NamaToko` AS `NamaToko`,`mt`.`AlamatToko` AS `AlamatToko`,`mt`.`Daerah` AS `Daerah`,`mt`.`NoTelp` AS `NoTelpCustomer`,`mt`.`NoHP` AS `NoHPCustomer` from (((((`db_dai`.`trsalesorder` `SO` join `db_dai`.`trsalesorderdetail` `SOD` on((`sod`.`KdSO` = `so`.`KdSO`))) join `db_dai`.`mssales` `MS` on((`ms`.`KdSales` = `so`.`KdSales`))) join `db_dai`.`mstoko` `MT` on((`mt`.`KdToko` = `so`.`KdToko`))) join `db_dai`.`msbarang` `MB` on((`mb`.`KdBarang` = `sod`.`KdBarang`))) join `db_dai`.`msmerk` on((`db_dai`.`msmerk`.`kdmerk` = `mb`.`KdMerk`))) where (`so`.`KdSO` = _latin1'SO0006.04.11.11'));
