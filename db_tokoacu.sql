-- phpMyAdmin SQL Dump
-- version 2.11.7
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Waktu pembuatan: 30. September 2011 jam 22:56
-- Versi Server: 5.0.51
-- Versi PHP: 5.2.6

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `db_tokoacu`
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
  `QtyAdj_Plus` double NOT NULL default '0',
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
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data untuk tabel `bahanmentahhistory`
--

INSERT INTO `bahanmentahhistory` (`KdHistory`, `KdBahanMentah`, `UserID`, `TanggalHistory`, `StockAwal`, `QtyProd_Min`, `QtyPurchase_Plus`, `QtyUpdate_Min`, `QtyUpdate_Plus`, `QtyAdj_Min`, `QtyAdj_Plus`, `StockAkhir`, `HargaAwal`, `HargaAkhir`, `Module`, `RefNumber`, `Keterangan`, `isActive`, `Jenis`) VALUES
(1, 'BM11090001', '', '2011-09-29 19:33:27', 0, 0, 0, 0, 5, 0, 0, 5, 2000.00, 0.00, 'Form Klem', '', NULL, '1', 'Klem'),
(2, 'BM11090002', '', '2011-09-29 19:35:43', 0, 0, 0, 0, 5000, 0, 0, 5000, 232323.00, 0.00, 'Form Klem', '', NULL, '1', 'Klem'),
(3, 'BM11090003', '', '2011-09-29 19:36:29', 0, 0, 0, 0, 7, 0, 0, 7, 25000.00, 0.00, 'Form Klem', '', NULL, '1', 'Klem'),
(4, 'PK11090001', '', '2011-09-29 23:10:52', 0, 0, 0, 0, 200, 0, 0, 200, 5000.00, 0.00, 'Form Klem', '', NULL, '1', 'Paku');

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
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data untuk tabel `baranghistory`
--


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
  PRIMARY KEY  (`KdBahanMentah`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `msbahanmentah`
--

INSERT INTO `msbahanmentah` (`KdBahanMentah`, `KdSupplier`, `NamaBahanMentah`, `Ukuran`, `Jenis`, `Satuan`, `IsAktif`) VALUES
('BM11090001', NULL, 'Klem mentah -4', 4, 'Klem', 'Karung', '1'),
('BM11090002', NULL, 'Klem mentah -5', 5, 'Klem', 'Karung', '1'),
('BM11090003', NULL, 'Klem mentah -6', 6, 'Klem', 'Karung', '1'),
('PK11090001', NULL, 'Paku -16', 16, 'Paku', 'Kardus', '1');

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
  PRIMARY KEY  (`KdBahanMentahList`),
  KEY `KdBahanMentah` (`KdBahanMentah`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data untuk tabel `msbahanmentahlist`
--

INSERT INTO `msbahanmentahlist` (`KdBahanMentahList`, `KdBahanMentah`, `Harga`, `Qty`, `Jenis`) VALUES
(1, 'BM11090001', 2000.00, 5, 'Klem'),
(2, 'BM11090002', 232323.00, 5000, 'Klem'),
(3, 'BM11090003', 25000.00, 7, 'Klem'),
(4, 'PK11090001', 5000.00, 200, 'Paku');

-- --------------------------------------------------------

--
-- Struktur dari tabel `msbarang`
--

CREATE TABLE IF NOT EXISTS `msbarang` (
  `KdBarang` varchar(20) NOT NULL,
  `KdMerk` varchar(20) NOT NULL,
  `KdSupplier` varchar(20) NOT NULL,
  `NamaBarang` varchar(200) NOT NULL,
  `Ukuran` int(11) default NULL,
  `Satuan` varchar(20) default 'pack',
  `IsAktif` char(1) default NULL,
  `Note` text,
  PRIMARY KEY  (`KdBarang`),
  KEY `KdMerk` (`KdMerk`),
  KEY `KdSupplier` (`KdSupplier`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `msbarang`
--


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
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Dumping data untuk tabel `msbaranglist`
--


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
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

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
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

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
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `mssales`
--

INSERT INTO `mssales` (`KdSales`, `NamaSales`, `Alamat`, `NoTelp`, `NoHP`, `Komisi`) VALUES
('SL11090001', 'Sales1', 'asa', '5454523', '24234', 11),
('SL11090002', 'q', '234', '-', '', 0);

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
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

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
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `mstoko`
--

INSERT INTO `mstoko` (`KdToko`, `NamaToko`, `NamaOwner`, `AlamatToko`, `Daerah`, `NoTelp`, `NoHP`, `NoFax`, `JatuhTempo`, `KdSales`) VALUES
('TK1109140001', '23', '2', '23', '23', '23', '232', '32', 123, 'SL11090001');

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
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `msuser`
--

INSERT INTO `msuser` (`userid`, `username`, `Password`, `NamaLengkap`, `Level`) VALUES
('', 'a', 'a', 'User1', '1');

-- --------------------------------------------------------

--
-- Struktur dari tabel `trdetailpb`
--

CREATE TABLE IF NOT EXISTS `trdetailpb` (
  `No_PB` varchar(20) NOT NULL,
  `KdBarang` varchar(20) NOT NULL,
  `Qty` double NOT NULL,
  `Harga` decimal(20,2) NOT NULL,
  `Disc` float default '0',
  PRIMARY KEY  (`No_PB`,`KdBarang`),
  KEY `KdBarang` (`KdBarang`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `trdetailpb`
--


-- --------------------------------------------------------

--
-- Struktur dari tabel `trdetailpo`
--

CREATE TABLE IF NOT EXISTS `trdetailpo` (
  `no_po` varchar(20) NOT NULL,
  `kdbahanmentah` varchar(20) NOT NULL,
  `jumlah` float NOT NULL,
  `harga` float NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `trdetailpo`
--


-- --------------------------------------------------------

--
-- Struktur dari tabel `trheaderpb`
--

CREATE TABLE IF NOT EXISTS `trheaderpb` (
  `No_PB` varchar(20) NOT NULL,
  `No_PO` varchar(20) NOT NULL,
  `userid` varchar(20) NOT NULL,
  `KdSupplier` varchar(20) default NULL,
  `Tanggal_TerimaBarang` datetime NOT NULL,
  `StatusTerimaBarang` char(1) NOT NULL default '0',
  `GrandTotal` double(20,2) NOT NULL default '0.00',
  `StatusPaid` char(1) NOT NULL default '0',
  PRIMARY KEY  (`No_PB`),
  KEY `userid` (`userid`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `trheaderpb`
--


-- --------------------------------------------------------

--
-- Struktur dari tabel `trheaderpb_t`
--

CREATE TABLE IF NOT EXISTS `trheaderpb_t` (
  `No_PB` varchar(20) NOT NULL,
  PRIMARY KEY  (`No_PB`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `trheaderpb_t`
--


-- --------------------------------------------------------

--
-- Struktur dari tabel `trheaderpo`
--

CREATE TABLE IF NOT EXISTS `trheaderpo` (
  `No_PO` varchar(20) NOT NULL,
  `userid` varchar(20) NOT NULL,
  `Tanggal_PO` datetime NOT NULL,
  `KdSupplier` varchar(12) NOT NULL,
  `StatusPO` char(1) NOT NULL default '0',
  `GrandTotal` decimal(20,2) NOT NULL default '0.00',
  `Jenis` enum('Paku','Klem') default NULL,
  PRIMARY KEY  (`No_PO`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `trheaderpo`
--


-- --------------------------------------------------------

--
-- Struktur dari tabel `trheaderpo_t`
--

CREATE TABLE IF NOT EXISTS `trheaderpo_t` (
  `no_po` varchar(20) NOT NULL,
  PRIMARY KEY  (`no_po`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `trheaderpo_t`
--

INSERT INTO `trheaderpo_t` (`no_po`) VALUES
('PO11090001'),
('PO11090002'),
('PO11090003'),
('PO11090004'),
('PO11090005'),
('PO11090006'),
('PO11090007');
