/*
SQLyog Ultimate v8.32 
MySQL - 5.1.41 : Database - db_tokoacu
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_tokoacu` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `db_tokoacu`;

/*Table structure for table `bahanmentahhistory` */

DROP TABLE IF EXISTS `bahanmentahhistory`;

CREATE TABLE `bahanmentahhistory` (
  `KdHistory` int(11) NOT NULL AUTO_INCREMENT,
  `KdBahanMentah` varchar(20) NOT NULL,
  `UserID` varchar(20) DEFAULT NULL,
  `TanggalHistory` datetime NOT NULL,
  `StockAwal` double NOT NULL DEFAULT '0',
  `QtyProd_Min` double NOT NULL DEFAULT '0',
  `QtyPurchase_Plus` double NOT NULL DEFAULT '0',
  `QtyUpdate_Min` double NOT NULL DEFAULT '0',
  `QtyUpdate_Plus` double NOT NULL DEFAULT '0',
  `QtyAdj_Min` double NOT NULL DEFAULT '0',
  `QtyRetur_Plus` double DEFAULT '0',
  `QtyRetur_Min` double DEFAULT '0',
  `QtyAdj_Plus` double NOT NULL DEFAULT '0',
  `QtyFaktur_Min` double DEFAULT '0',
  `StatusBahanMentahList` char(1) NOT NULL DEFAULT '0',
  `StockAkhir` double NOT NULL DEFAULT '0',
  `HargaAwal` decimal(20,2) NOT NULL DEFAULT '0.00',
  `HargaAkhir` decimal(20,2) NOT NULL DEFAULT '0.00',
  `Module` varchar(200) DEFAULT NULL,
  `RefNumber` varchar(20) DEFAULT NULL,
  `Keterangan` text,
  `isActive` char(1) NOT NULL DEFAULT '1',
  `Jenis` enum('Paku','Klem') DEFAULT NULL,
  PRIMARY KEY (`KdHistory`),
  KEY `KdBahanMentah` (`KdBahanMentah`)
) ENGINE=InnoDB AUTO_INCREMENT=99 DEFAULT CHARSET=latin1;

/*Data for the table `bahanmentahhistory` */

insert  into `bahanmentahhistory`(`KdHistory`,`KdBahanMentah`,`UserID`,`TanggalHistory`,`StockAwal`,`QtyProd_Min`,`QtyPurchase_Plus`,`QtyUpdate_Min`,`QtyUpdate_Plus`,`QtyAdj_Min`,`QtyRetur_Plus`,`QtyRetur_Min`,`QtyAdj_Plus`,`QtyFaktur_Min`,`StatusBahanMentahList`,`StockAkhir`,`HargaAwal`,`HargaAkhir`,`Module`,`RefNumber`,`Keterangan`,`isActive`,`Jenis`) values (45,'KL11100001','','2012-01-03 14:00:50',0,0,0,0,0,0,0,0,10,0,'0',10,'0.00','0.00','Form Adjusment','AJ1201030001',NULL,'1','Klem'),(46,'KL11100002','','2012-01-03 14:01:13',0,0,0,0,0,0,0,0,5,0,'0',5,'0.00','0.00','Form Adjusment','AJ1201030002',NULL,'1','Klem'),(47,'KL12010001','','2012-01-03 14:01:21',0,0,0,0,0,0,0,0,5,0,'0',5,'0.00','0.00','Form Adjusment','AJ1201030003',NULL,'1','Klem'),(48,'PK11100001','','2012-01-03 14:23:45',0,0,0,0,0,0,0,0,10,0,'0',10,'0.00','0.00','Form Adjusment','AJ1201030004',NULL,'1','Paku'),(49,'PK11120001','','2012-01-03 14:23:56',0,0,0,0,0,0,0,0,10,0,'0',10,'0.00','0.00','Form Adjusment','AJ1201030005',NULL,'1','Paku'),(50,'PK11100002','','2012-01-03 14:24:16',0,0,0,0,0,0,0,0,10,0,'0',10,'0.00','0.00','Form Adjusment','AJ1201030006',NULL,'1','Paku'),(51,'PK11110001','','2012-01-03 14:24:29',0,0,0,0,0,0,0,0,10,0,'0',10,'0.00','0.00','Form Adjusment','AJ1201030007',NULL,'1','Paku'),(52,'KL11100001','','2012-01-03 14:26:22',10,2,0,0,0,0,0,0,0,0,'0',8,'0.00','0.00','Form Pantek Klem','PK12010001',NULL,'1','Klem'),(53,'PK11100001','','2012-01-03 14:26:22',10,2,0,0,0,0,0,0,0,0,'0',8,'0.00','0.00','Form Pantek Klem','PK12010001',NULL,'1','Paku'),(54,'KL11100001','','2012-01-03 14:26:56',8,1,0,0,0,0,0,0,0,0,'0',7,'0.00','0.00','Form Pantek Klem','PK12010002',NULL,'1','Klem'),(55,'PK11100001','','2012-01-03 14:26:56',8,2,0,0,0,0,0,0,0,0,'0',6,'0.00','0.00','Form Pantek Klem','PK12010002',NULL,'1','Paku'),(56,'KL11100001','','2012-01-21 19:55:56',7,0,5,0,0,0,0,0,0,0,'0',12,'30000.00','0.00','Form Penerimaan Bahan Mentah','PB12010002',NULL,'1','Klem'),(57,'KL11100001','','2012-01-21 19:56:18',12,0,2,0,0,0,0,0,0,0,'0',14,'20000.00','0.00','Form Penerimaan Bahan Mentah','PB12010003',NULL,'1','Klem'),(58,'KL11100002','','2012-01-21 19:56:18',5,0,5,0,0,0,0,0,0,0,'0',10,'30000.00','0.00','Form Penerimaan Bahan Mentah','PB12010003',NULL,'1','Klem'),(59,'KL12010001','','2012-01-21 19:56:18',5,0,3,0,0,0,0,0,0,0,'0',8,'10000.00','0.00','Form Penerimaan Bahan Mentah','PB12010003',NULL,'1','Klem'),(60,'KL11100001','','2012-01-21 20:11:57',14,0,14,0,0,0,0,0,0,0,'0',28,'30000.00','0.00','Form Penerimaan Bahan Mentah','PB12010001',NULL,'1','Klem'),(61,'KL11100002','','2012-01-21 20:11:57',10,0,2,0,0,0,0,0,0,0,'0',12,'20000.00','0.00','Form Penerimaan Bahan Mentah','PB12010001',NULL,'1','Klem'),(62,'KL11100001','','2012-01-21 20:19:18',28,0,3,0,0,0,0,0,0,0,'0',31,'90000.00','0.00','Form Penerimaan Bahan Mentah','PB12010004',NULL,'1','Klem'),(63,'PK11100002','','2012-01-21 20:26:35',10,0,2,0,0,0,0,0,0,0,'0',12,'20000.00','0.00','Form Penerimaan Bahan Mentah','PB12010006',NULL,'1','Paku'),(64,'PK11110001','','2012-01-21 20:26:35',10,0,2,0,0,0,0,0,0,0,'0',12,'30000.00','0.00','Form Penerimaan Bahan Mentah','PB12010006',NULL,'1','Paku'),(65,'PK11120001','','2012-01-21 20:26:35',10,0,7,0,0,0,0,0,0,0,'0',17,'0.00','0.00','Form Penerimaan Bahan Mentah','PB12010006',NULL,'1','Paku'),(66,'PK11100001','','2012-01-21 20:26:35',6,0,4,0,0,0,0,0,0,0,'0',10,'0.00','0.00','Form Penerimaan Bahan Mentah','PB12010006',NULL,'1','Paku'),(67,'PK11120001','','2012-01-21 20:50:25',17,0,2,0,0,0,0,0,0,0,'0',19,'2000.00','0.00','Form Penerimaan Bahan Mentah','PB12010008',NULL,'1','Paku'),(68,'KL11100001','','2012-01-21 22:01:36',31,0,0,0,0,0,0,1,0,0,'0',30,'0.00','20000.00','Form Retur','RB1201210002',NULL,'1','Klem'),(69,'KL11100002','','2012-01-21 22:01:36',12,0,0,0,0,0,0,4,0,0,'0',8,'0.00','30000.00','Form Retur','RB1201210002',NULL,'1','Klem'),(70,'KL12010001','','2012-01-21 22:01:36',8,0,0,0,0,0,0,2,0,0,'0',6,'0.00','10000.00','Form Retur','RB1201210002',NULL,'1','Klem'),(71,'PK11120001','','2012-01-22 11:43:56',19,0,0,0,0,0,0,2,0,0,'0',17,'0.00','2000.00','Form Retur','RB1201220002',NULL,'1','Paku'),(72,'PK11100001','','2012-01-22 11:55:10',10,0,0,0,0,0,0,4,0,0,'0',6,'0.00','0.00','Form Retur','RB1201220003',NULL,'1','Paku'),(73,'PK11100002','','2012-01-22 11:55:10',12,0,0,0,0,0,0,2,0,0,'0',10,'0.00','20000.00','Form Retur','RB1201220003',NULL,'1','Paku'),(74,'KL11100001','','2012-01-22 14:19:56',30,0,0,0,0,0,0,1,0,0,'0',29,'0.00','20000.00','Form Retur','RB1201210003',NULL,'1','Klem'),(75,'KL11100002','','2012-01-22 14:19:56',8,0,0,0,0,0,0,1,0,0,'0',7,'0.00','30000.00','Form Retur','RB1201210003',NULL,'1','Klem'),(76,'KL12010001','','2012-01-22 14:19:56',6,0,0,0,0,0,0,1,0,0,'0',5,'0.00','10000.00','Form Retur','RB1201210003',NULL,'1','Klem'),(77,'KL11100001','','2012-01-22 14:23:21',29,0,0,0,0,0,0,1,0,0,'0',28,'0.00','20000.00','Form Retur','RB1201210003',NULL,'1','Klem'),(78,'KL11100002','','2012-01-22 14:23:21',7,0,0,0,0,0,0,1,0,0,'0',6,'30000.00','30000.00','Form Retur','RB1201210003',NULL,'1','Klem'),(79,'KL12010001','','2012-01-22 14:23:21',5,0,0,0,0,0,0,1,0,0,'0',4,'0.00','10000.00','Form Retur','RB1201210003',NULL,'1','Klem'),(80,'KL11100001','','2012-01-22 14:36:27',28,0,0,0,0,0,0,1,0,0,'0',27,'0.00','20000.00','Form Retur','RB1201210003',NULL,'1','Klem'),(81,'KL11100002','','2012-01-22 14:36:27',6,0,0,0,0,0,0,1,0,0,'0',5,'30000.00','30000.00','Form Retur','RB1201210003',NULL,'1','Klem'),(82,'KL12010001','','2012-01-22 14:36:27',4,0,0,0,0,0,0,1,0,0,'0',3,'0.00','10000.00','Form Retur','RB1201210003',NULL,'1','Klem'),(83,'KL11100001','','2012-01-22 14:40:19',27,0,0,0,0,0,0,1,0,0,'0',26,'0.00','20000.00','Form Retur','RB1201210003',NULL,'1','Klem'),(84,'KL11100002','','2012-01-22 14:40:19',5,0,0,0,0,0,0,1,0,0,'0',4,'30000.00','30000.00','Form Retur','RB1201210003',NULL,'1','Klem'),(85,'KL12010001','','2012-01-22 14:40:19',3,0,0,0,0,0,0,1,0,0,'0',2,'10000.00','10000.00','Form Retur','RB1201210003',NULL,'1','Klem'),(86,'KL11100001','','2012-01-22 14:47:41',26,0,0,0,0,0,0,1,0,0,'0',25,'0.00','90000.00','Form Retur','RB1201210001',NULL,'1','Klem'),(87,'PK11110001','','2012-01-27 09:33:47',12,0,0,0,0,0,0,0,0,2,'0',10,'0.00','250000.00','Form Faktur','FK0002.27.01.12',NULL,'1','Paku'),(88,'PK11120001','','2012-01-27 09:33:47',17,0,0,0,0,0,0,0,0,2,'0',15,'0.00','3196125.00','Form Faktur','FK0002.27.01.12',NULL,'1','Paku'),(89,'PK11100001','','2012-01-27 12:03:12',6,0,0,0,0,0,0,0,0,2,'0',4,'0.00','300000.00','Form Faktur','FK0003.27.01.12',NULL,'1','Paku'),(90,'PK11100002','','2012-01-27 12:03:12',10,0,0,0,0,0,0,0,0,3,'0',7,'0.00','200000.00','Form Faktur','FK0003.27.01.12',NULL,'1','Paku'),(91,'KL11100001','','2012-01-27 13:21:26',25,1,0,0,0,0,0,0,0,0,'0',24,'0.00','0.00','Form Pantek Klem','PK12010003',NULL,'1','Klem'),(92,'KL11100001','','2012-01-27 13:21:26',24,1,0,0,0,0,0,0,0,0,'0',23,'30000.00','0.00','Form Pantek Klem','PK12010003',NULL,'1','Klem'),(93,'PK11100001','','2012-01-27 13:21:26',4,2,0,0,0,0,0,0,0,0,'0',2,'0.00','0.00','Form Pantek Klem','PK12010003',NULL,'1','Paku'),(94,'KL11100002','','2012-01-27 13:21:26',4,2,0,0,0,0,0,0,0,0,'0',2,'30000.00','0.00','Form Pantek Klem','PK12010003',NULL,'1','Klem'),(95,'KL11100002','','2012-01-27 13:21:26',2,1,0,0,0,0,0,0,0,0,'0',1,'20000.00','0.00','Form Pantek Klem','PK12010003',NULL,'1','Klem'),(96,'PK11120001','','2012-01-27 13:21:26',15,3,0,0,0,0,0,0,0,0,'0',12,'0.00','0.00','Form Pantek Klem','PK12010003',NULL,'1','Paku'),(97,'KL11100001','','2012-01-29 14:33:46',23,0,1,0,0,0,0,0,0,0,'0',24,'2000.00','0.00','Form Penerimaan Bahan Mentah','PO12010007',NULL,'1','Klem'),(98,'KL12010001','','2012-01-29 14:33:46',2,0,1,0,0,0,0,0,0,0,'0',3,'3000.00','0.00','Form Penerimaan Bahan Mentah','PO12010007',NULL,'1','Klem');

/*Table structure for table `baranghistory` */

DROP TABLE IF EXISTS `baranghistory`;

CREATE TABLE `baranghistory` (
  `KdBarangHistory` int(11) NOT NULL AUTO_INCREMENT,
  `KdBarang` varchar(20) NOT NULL,
  `UserID` varchar(20) NOT NULL,
  `TanggalHistory` datetime NOT NULL,
  `StockAwal` double DEFAULT '0',
  `QtyUpdate_Min` double DEFAULT '0',
  `QtyUpdate_Plus` double DEFAULT '0',
  `QtyFaktur_Min` double DEFAULT '0',
  `QtyRetur_Plus` double DEFAULT '0',
  `QtyRetur_Min` double DEFAULT '0',
  `QtyPurchase_Plus` double DEFAULT '0',
  `QtyProd_Plus` double DEFAULT '0',
  `QtyAdj_Min` double DEFAULT '0',
  `QtyAdj_Plus` double DEFAULT '0',
  `StatusBarangList` char(1) DEFAULT '0',
  `StockAkhir` double DEFAULT '0',
  `HargaAwal` decimal(20,2) DEFAULT '0.00',
  `HargaAkhir` decimal(20,2) DEFAULT '0.00',
  `Module` varchar(200) DEFAULT NULL,
  `RefNumber` varchar(20) DEFAULT NULL,
  `Keterangan` text,
  `isActive` char(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`KdBarangHistory`),
  KEY `KdBarang` (`KdBarang`),
  KEY `UserID` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

/*Data for the table `baranghistory` */

insert  into `baranghistory`(`KdBarangHistory`,`KdBarang`,`UserID`,`TanggalHistory`,`StockAwal`,`QtyUpdate_Min`,`QtyUpdate_Plus`,`QtyFaktur_Min`,`QtyRetur_Plus`,`QtyRetur_Min`,`QtyPurchase_Plus`,`QtyProd_Plus`,`QtyAdj_Min`,`QtyAdj_Plus`,`StatusBarangList`,`StockAkhir`,`HargaAwal`,`HargaAkhir`,`Module`,`RefNumber`,`Keterangan`,`isActive`) values (1,'BG11110005','','2012-01-17 21:26:57',0,0,0,0,0,0,0,20,0,0,'0',20,'30000.00','0.00','Form Produksi Hitung Klem','HD12010001',NULL,'1'),(2,'BG11110006','','2012-01-17 21:26:57',0,0,0,0,0,0,0,200,0,0,'0',200,'40000.00','0.00','Form Produksi Hitung Klem','HD12010001',NULL,'1'),(3,'BG11120001','','2012-01-17 21:26:57',0,0,0,0,0,0,0,20,0,0,'0',20,'50000.00','0.00','Form Produksi Hitung Klem','HD12010001',NULL,'1'),(4,'BG11110005','','2012-01-17 21:27:39',20,0,0,0,0,0,0,200,0,0,'0',220,'50000.00','0.00','Form Produksi Hitung Klem','HD12010002',NULL,'1'),(5,'BG11110005','','2012-01-27 09:03:52',220,0,0,2,0,0,0,0,0,0,'0',218,'30000.00','5400000.00','Form Faktur','FK0001.22.01.12',NULL,'1'),(6,'BG11120001','','2012-01-27 09:03:52',20,0,0,2,0,0,0,0,0,0,'0',18,'50000.00','7904250.00','Form Faktur','FK0001.22.01.12',NULL,'1'),(7,'BG11110006','','2012-01-27 09:10:36',200,0,0,1,0,0,0,0,0,0,'0',199,'40000.00','5103000.00','Form Faktur','FK0001.27.01.12',NULL,'1'),(8,'BG11120001','','2012-01-27 09:10:36',18,0,0,1,0,0,0,0,0,0,'0',17,'50000.00','7904250.00','Form Faktur','FK0001.27.01.12',NULL,'1'),(9,'BG11110006','','2012-01-27 23:41:53',199,0,0,0,0,0,0,100,0,0,'0',299,'30000.00','0.00','Form Produksi Hitung Klem','HD12010003',NULL,'1'),(10,'BG11120001','','2012-01-27 23:41:53',17,0,0,0,0,0,0,50,0,0,'0',67,'3000.00','0.00','Form Produksi Hitung Klem','HD12010003',NULL,'1'),(11,'BG12010001','','2012-01-29 12:06:38',0,0,5,0,0,0,0,0,0,0,'0',5,'2000.00','0.00','Form Barang','',NULL,'1'),(12,'BG12010002','','2012-01-29 12:41:05',0,0,2,0,0,0,0,0,0,0,'0',2,'2000.00','0.00','Form Barang','',NULL,'1');

/*Table structure for table `msbahanmentah` */

DROP TABLE IF EXISTS `msbahanmentah`;

CREATE TABLE `msbahanmentah` (
  `KdBahanMentah` varchar(20) NOT NULL,
  `KdSupplier` varchar(20) DEFAULT NULL,
  `NamaBahanMentah` varchar(200) DEFAULT NULL,
  `Ukuran` varchar(20) DEFAULT NULL,
  `Jenis` enum('Klem','Paku') DEFAULT NULL,
  `Satuan` enum('Karung','Kg') DEFAULT NULL,
  `IsAktif` char(1) DEFAULT '1',
  `HargaJualKg` decimal(20,2) NOT NULL,
  `HargaJualKarung` decimal(20,2) NOT NULL,
  `KarungToKg` double(20,2) NOT NULL,
  PRIMARY KEY (`KdBahanMentah`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `msbahanmentah` */

insert  into `msbahanmentah`(`KdBahanMentah`,`KdSupplier`,`NamaBahanMentah`,`Ukuran`,`Jenis`,`Satuan`,`IsAktif`,`HargaJualKg`,`HargaJualKarung`,`KarungToKg`) values ('KL11100001',NULL,'Klem mentah -4','4','Klem','Karung','1','3000.00','75000.00',25.00),('KL11100002',NULL,'Klem mentah -5','5','Klem','Karung','1','3000.00','75000.00',25.00),('KL12010001',NULL,'Klem mentah -6','6','Klem','Karung','1','55000.00','1375000.00',25.00),('PK11100001',NULL,'- Paku -50 m/m','50 m/m','Paku','Kg','1','300000.00','7500000.00',30.00),('PK11100002',NULL,'- Paku -30 m/m','30 m/m','Paku','Kg','1','200000.00','5000000.00',30.00),('PK11110001',NULL,'- Paku -16 m/m','16 m/m','Paku','Kg','1','250000.00','6250000.00',30.00),('PK11120001',NULL,'- Paku -16 m/m','16 m/m','Paku','Kg','1','3196125.00','79903125.00',30.00);

/*Table structure for table `msbahanmentahlist` */

DROP TABLE IF EXISTS `msbahanmentahlist`;

CREATE TABLE `msbahanmentahlist` (
  `KdBahanMentahList` int(11) NOT NULL AUTO_INCREMENT,
  `KdBahanMentah` varchar(20) DEFAULT NULL,
  `Harga` decimal(20,2) DEFAULT NULL,
  `Qty` double DEFAULT NULL,
  `Jenis` enum('Paku','Klem') DEFAULT NULL,
  `StatusBahanMentahList` char(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`KdBahanMentahList`),
  KEY `KdBahanMentah` (`KdBahanMentah`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=latin1;

/*Data for the table `msbahanmentahlist` */

insert  into `msbahanmentahlist`(`KdBahanMentahList`,`KdBahanMentah`,`Harga`,`Qty`,`Jenis`,`StatusBahanMentahList`) values (27,'PK11120001','0.00',3,'Paku','0'),(28,'PK11100002','0.00',5,'Paku','0'),(29,'PK11110001','0.00',8,'Paku','0'),(30,'KL11100001','30000.00',4,'Klem','0'),(31,'KL11100001','20000.00',2,'Klem','0'),(33,'KL12010001','10000.00',2,'Klem','0'),(34,'KL11100001','30000.00',14,'Klem','0'),(35,'KL11100002','20000.00',1,'Klem','0'),(36,'KL11100001','90000.00',3,'Klem','0'),(37,'PK11100002','20000.00',2,'Paku','0'),(38,'PK11110001','30000.00',2,'Paku','0'),(39,'PK11120001','0.00',7,'Paku','0'),(40,'PK11100001','0.00',2,'Paku','0'),(41,'PK11120001','2000.00',2,'Paku','0'),(42,'KL11100001','2000.00',1,'Klem','0'),(43,'KL12010001','3000.00',1,'Klem','0');

/*Table structure for table `msbarang` */

DROP TABLE IF EXISTS `msbarang`;

CREATE TABLE `msbarang` (
  `KdBarang` varchar(20) NOT NULL,
  `KdMerk` varchar(20) NOT NULL,
  `NamaBarang` varchar(200) NOT NULL,
  `Ukuran` int(11) DEFAULT NULL,
  `Satuan` varchar(20) DEFAULT 'pack',
  `IsAktif` char(1) DEFAULT NULL,
  `Note` text,
  `HargaList` decimal(20,2) NOT NULL,
  PRIMARY KEY (`KdBarang`),
  KEY `KdMerk` (`KdMerk`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `msbarang` */

insert  into `msbarang`(`KdBarang`,`KdMerk`,`NamaBarang`,`Ukuran`,`Satuan`,`IsAktif`,`Note`,`HargaList`) values ('BG11100001','MR001 ','Klem -ukuran4',4,'Pack','1',NULL,'6000000.00'),('BG11100002','MR002 ','Klem -ukuran5',5,'Pack','1',NULL,'2486250.00'),('BG11110001','MR001 ','Klem -ukuran6',6,'Pack','1',NULL,'1676250.00'),('BG11110002','MR002 ','Klem -ukuran7',7,'Pack','1',NULL,'4338000.00'),('BG11110003','MR001 ','Klem -ukuran8',8,'Pack','1',NULL,'2857500.00'),('BG11110004','MR002 ','Klem -ukuran9',9,'Pack','1',NULL,'3503250.00'),('BG11110005','MR001','Klem -ukuran10',10,'Pack','1',NULL,'5400000.00'),('BG11110006','MR002 ','Klem -ukuran12',12,'Pack','1',NULL,'5103000.00'),('BG11120001','MR001 ','Klem -ukuran14',14,'Pack','1',NULL,'7904250.00'),('BG11120002','MR001','Klem -ukuran17',17,'Pack','1',NULL,'1620000.00'),('BG11120003','MR001','Klem -ukuran19',19,'Pack','1',NULL,'2569500.00'),('BG11120004','MR001','Klem -ukuran22',22,'Pack','1',NULL,'2763000.00'),('BG11120005','MR001','Klem -ukuran29',29,'Pack','1',NULL,'5343750.00'),('BG12010001','MR003','Klem -ukuran5',5,'Pack','1',NULL,'2000.00'),('BG12010002','MR002','Intan50 -ukuran4',4,'Pack','1',NULL,'2000.00');

/*Table structure for table `msbaranglist` */

DROP TABLE IF EXISTS `msbaranglist`;

CREATE TABLE `msbaranglist` (
  `KdList` int(11) NOT NULL AUTO_INCREMENT,
  `KdBarang` varchar(20) NOT NULL,
  `Harga` decimal(20,2) NOT NULL,
  `Qty` double NOT NULL,
  `StatusBarangList` char(1) NOT NULL DEFAULT '0',
  `StatusBarang` char(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`KdList`),
  KEY `KdBarang` (`KdBarang`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Data for the table `msbaranglist` */

insert  into `msbaranglist`(`KdList`,`KdBarang`,`Harga`,`Qty`,`StatusBarangList`,`StatusBarang`) values (1,'BG11110005','30000.00',18,'0','0'),(2,'BG11110006','40000.00',199,'0','0'),(3,'BG11120001','50000.00',17,'0','0'),(4,'BG11110005','50000.00',200,'0','0'),(5,'BG11110006','30000.00',100,'0','0'),(6,'BG11120001','3000.00',50,'0','0'),(7,'BG12010001','2000.00',5,'0','0'),(8,'BG12010002','2000.00',2,'0','0');

/*Table structure for table `msformula` */

DROP TABLE IF EXISTS `msformula`;

CREATE TABLE `msformula` (
  `QtyKlemMentah` int(11) NOT NULL,
  `QtyPaku` int(11) NOT NULL,
  `QtyKlemJadi` int(11) NOT NULL,
  `UkuranKlemMentah` int(2) NOT NULL,
  `UkuranPaku` varchar(50) NOT NULL,
  `Tipe` enum('hitung','pantek') NOT NULL DEFAULT 'pantek',
  PRIMARY KEY (`UkuranKlemMentah`,`UkuranPaku`,`Tipe`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `msformula` */

insert  into `msformula`(`QtyKlemMentah`,`QtyPaku`,`QtyKlemJadi`,`UkuranKlemMentah`,`UkuranPaku`,`Tipe`) values (22,0,22,5,'16 m/m','hitung'),(2,3,2,4,'16 m/m','pantek');

/*Table structure for table `mskaryawan` */

DROP TABLE IF EXISTS `mskaryawan`;

CREATE TABLE `mskaryawan` (
  `KdKaryawan` varchar(20) NOT NULL,
  `NamaKaryawan` varchar(200) DEFAULT NULL,
  `Alamat` text,
  `NoTelp` varchar(20) DEFAULT NULL,
  `NoHP` varchar(20) DEFAULT NULL,
  `JenisKaryawan` varchar(70) DEFAULT NULL,
  PRIMARY KEY (`KdKaryawan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mskaryawan` */

insert  into `mskaryawan`(`KdKaryawan`,`NamaKaryawan`,`Alamat`,`NoTelp`,`NoHP`,`JenisKaryawan`) values ('KY11090001','Eti','Jl. Cengkareng','-','22','Memantek Klem'),('KY11090002','Endang','Jl. Cengkareng','-','2323','Memantek Klem'),('KY11090003','Rasman','Jl. Cengkareng','-','23','Memantek Klem');

/*Table structure for table `msklempantek` */

DROP TABLE IF EXISTS `msklempantek`;

CREATE TABLE `msklempantek` (
  `KdKlemPantek` int(11) NOT NULL AUTO_INCREMENT,
  `KdBahanMentah` varchar(20) DEFAULT NULL,
  `Harga` decimal(20,2) DEFAULT NULL,
  `Qty` double DEFAULT NULL,
  PRIMARY KEY (`KdKlemPantek`),
  KEY `KdBahanMentah` (`KdBahanMentah`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `msklempantek` */

/*Table structure for table `msmerk` */

DROP TABLE IF EXISTS `msmerk`;

CREATE TABLE `msmerk` (
  `kdmerk` varchar(20) NOT NULL,
  `merk` varchar(50) DEFAULT NULL,
  `isi` int(11) DEFAULT '0',
  `prioritas` char(1) DEFAULT '0',
  PRIMARY KEY (`kdmerk`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `msmerk` */

insert  into `msmerk`(`kdmerk`,`merk`,`isi`,`prioritas`) values ('MR001','Y60',60,'0'),('MR002','Intan50',50,'0'),('MR003','Onaga',50,'0');

/*Table structure for table `mssales` */

DROP TABLE IF EXISTS `mssales`;

CREATE TABLE `mssales` (
  `KdSales` varchar(20) NOT NULL,
  `NamaSales` varchar(200) DEFAULT NULL,
  `Alamat` text,
  `NoTelp` varchar(20) DEFAULT NULL,
  `NoHP` varchar(20) DEFAULT NULL,
  `Komisi` double DEFAULT '0',
  PRIMARY KEY (`KdSales`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mssales` */

insert  into `mssales`(`KdSales`,`NamaSales`,`Alamat`,`NoTelp`,`NoHP`,`Komisi`) values ('SL11090001','Sales1','asa','5454523','24234',11),('SL11090002','q','234','-','',0),('SL11110001','Musi','Jl. Tanngerag','-','',16),('SL11120001','Weni','Jl. Taman','-','',0),('SL11120002','Kiangiok','Kiangiok','-','',16);

/*Table structure for table `mssupplier` */

DROP TABLE IF EXISTS `mssupplier`;

CREATE TABLE `mssupplier` (
  `KdSupplier` varchar(20) NOT NULL,
  `Nama` varchar(200) DEFAULT NULL,
  `Alamat` text,
  `Daerah` varchar(100) DEFAULT NULL,
  `NoTelp` varchar(20) DEFAULT NULL,
  `NoHP` varchar(20) DEFAULT NULL,
  `noFax` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`KdSupplier`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mssupplier` */

insert  into `mssupplier`(`KdSupplier`,`Nama`,`Alamat`,`Daerah`,`NoTelp`,`NoHP`,`noFax`) values ('SP11090001','2','123','2','2','',''),('SP11120001','PT Phasedev','JL. Slipi','Slipi','-','','');

/*Table structure for table `mstoko` */

DROP TABLE IF EXISTS `mstoko`;

CREATE TABLE `mstoko` (
  `KdToko` varchar(20) NOT NULL,
  `NamaToko` varchar(200) DEFAULT NULL,
  `NamaOwner` varchar(200) DEFAULT NULL,
  `AlamatToko` text,
  `Daerah` varchar(200) DEFAULT NULL,
  `NoTelp` varchar(20) DEFAULT NULL,
  `NoHP` varchar(20) DEFAULT NULL,
  `NoFax` varchar(20) DEFAULT NULL,
  `JatuhTempo` int(11) DEFAULT NULL,
  PRIMARY KEY (`KdToko`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `mstoko` */

insert  into `mstoko`(`KdToko`,`NamaToko`,`NamaOwner`,`AlamatToko`,`Daerah`,`NoTelp`,`NoHP`,`NoFax`,`JatuhTempo`) values ('TK1109140001','23','2','23','23','23','232','32',123),('TK1111040001','Sinar Bintang','Sinar Bintang','Sinar Bintang','Sinar Bintang','-','','',10),('TK1111040002','Sinar Abadi','Sinar Abadi','Sinar Abadi','','-','','',10),('TK1111040003','Bintang Teranng','Bintang Teranng','Bintang Teranng','','-','','',10),('TK1111040004','Musi Indah','Musi Indah','Musi Indah','','-','','',10),('TK1112020001','Kiangkok','Kiangkok','Kiangkok','','-','','',10),('TK1112020002','Prima Abadi','Prima Abadi','Prima Abadi','','-','','',10),('TK1112020003','Surya Teknik','Surya Teknik','Surya Teknik','','-','','',10),('TK1112020004','Primasari','Primasari','Primasari','','-','','',10),('TK1112020005','Sinar Makmur','Sinar Makmur','Sinar Makmur','','-','','',10),('TK1112020006','Panca.L','Panca.L','Panca.L','','-','','',10),('TK1112020007','Masa Jaya','Masa Jaya','Masa Jaya','','-','','',10),('TK1112020008','Neon','Neon','Neon','','-','','',10);

/*Table structure for table `msuser` */

DROP TABLE IF EXISTS `msuser`;

CREATE TABLE `msuser` (
  `userid` varchar(20) NOT NULL,
  `username` varchar(50) DEFAULT NULL,
  `Password` varchar(20) DEFAULT NULL,
  `NamaLengkap` varchar(50) DEFAULT NULL,
  `Level` char(1) DEFAULT '1',
  PRIMARY KEY (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `msuser` */

insert  into `msuser`(`userid`,`username`,`Password`,`NamaLengkap`,`Level`) values ('','a','a','User1','1');

/*Table structure for table `tradjusment` */

DROP TABLE IF EXISTS `tradjusment`;

CREATE TABLE `tradjusment` (
  `KdAdj` varchar(20) NOT NULL,
  `TanggalAdj` datetime DEFAULT NULL,
  `KdBarang` varchar(20) DEFAULT NULL,
  `Type` char(1) DEFAULT NULL,
  `Harga` decimal(20,2) DEFAULT NULL,
  `Qty` double DEFAULT NULL,
  `Note` text,
  `LevelID` char(1) NOT NULL DEFAULT '0',
  `HargaList` decimal(20,2) DEFAULT '0.00',
  `jenis_adj` enum('paku','klem_mentah','klem_jadi') DEFAULT 'klem_jadi',
  PRIMARY KEY (`KdAdj`),
  KEY `KdBarang` (`KdBarang`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tradjusment` */

insert  into `tradjusment`(`KdAdj`,`TanggalAdj`,`KdBarang`,`Type`,`Harga`,`Qty`,`Note`,`LevelID`,`HargaList`,`jenis_adj`) values ('AJ1201030001','2012-01-03 14:00:50','KL11100001','+','25000.00',10,'','0','0.00','klem_mentah'),('AJ1201030002','2012-01-03 14:01:13','KL11100002','+','30000.00',5,'','0','0.00','klem_mentah'),('AJ1201030003','2012-01-03 14:01:21','KL12010001','+','35000.00',5,'','0','0.00','klem_mentah'),('AJ1201030004','2012-01-03 14:23:45','PK11100001','+','2500.00',10,'','0','0.00','paku'),('AJ1201030005','2012-01-03 14:23:56','PK11120001','+','3500.00',10,'','0','0.00','paku'),('AJ1201030006','2012-01-03 14:24:16','PK11100002','+','3700.00',10,'','0','0.00','paku'),('AJ1201030007','2012-01-03 14:24:29','PK11110001','+','4000.00',10,'','0','0.00','paku');

/*Table structure for table `trdetailpb` */

DROP TABLE IF EXISTS `trdetailpb`;

CREATE TABLE `trdetailpb` (
  `No_PB` varchar(20) NOT NULL,
  `kdbahanmentah` varchar(20) NOT NULL,
  `Qty` double NOT NULL,
  `Qty_real` double DEFAULT NULL,
  `Harga` decimal(20,2) NOT NULL,
  `Disc` float DEFAULT '0',
  `QtyPenerimaan` double DEFAULT '0',
  PRIMARY KEY (`No_PB`,`kdbahanmentah`),
  KEY `KdBarang` (`kdbahanmentah`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trdetailpb` */

insert  into `trdetailpb`(`No_PB`,`kdbahanmentah`,`Qty`,`Qty_real`,`Harga`,`Disc`,`QtyPenerimaan`) values ('PB12010001','KL11100001',420,14,'30000.00',0,450),('PB12010001','KL11100002',60,2,'20000.00',0,60),('PB12010002','KL11100001',150,5,'30000.00',0,600),('PB12010003','KL11100001',60,2,'20000.00',0,60),('PB12010003','KL11100002',150,5,'30000.00',0,150),('PB12010003','KL12010001',90,3,'10000.00',0,90),('PB12010004','KL11100001',90,3,'90000.00',0,150),('PB12010005','PK11100001',50,2,'20000.00',0,50),('PB12010005','PK11120001',50,2,'30000.00',0,100),('PB12010006','PK11100001',100,4,'0.00',0,100),('PB12010006','PK11100002',50,2,'20000.00',0,50),('PB12010006','PK11110001',50,2,'30000.00',0,100),('PB12010006','PK11120001',175,7,'0.00',0,175),('PB12010007','PK11100001',25,1,'2000.00',0,50),('PB12010007','PK11100002',25,1,'2000.00',0,50),('PB12010007','PK11110001',50,2,'2000.00',0,50),('PB12010008','PK11120001',50,2,'2000.00',0,100),('PO12010007','KL11100001',25,1,'2000.00',0,1),('PO12010007','KL12010001',25,1,'3000.00',0,1);

/*Table structure for table `trdetailpo` */

DROP TABLE IF EXISTS `trdetailpo`;

CREATE TABLE `trdetailpo` (
  `no_po` varchar(20) NOT NULL,
  `kdbahanmentah` varchar(20) NOT NULL,
  `jumlah` float NOT NULL,
  `jumlah_real` float DEFAULT NULL,
  `harga` decimal(20,2) NOT NULL DEFAULT '0.00'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trdetailpo` */

insert  into `trdetailpo`(`no_po`,`kdbahanmentah`,`jumlah`,`jumlah_real`,`harga`) values ('PO12010003','KL11100001',720,24,'0.00'),('PO12010003','KL11100002',60,2,'0.00'),('PO12010002','KL11100002',120,4,'0.00'),('PO12010002','KL12010001',60,2,'0.00'),('PO12010001','KL11100001',60,2,'0.00'),('PO12010001','KL11100002',150,5,'0.00'),('PO12010001','KL12010001',90,3,'0.00'),('PO12010005','PK11100001',50,2,'0.00'),('PO12010005','PK11120001',100,4,'0.00'),('PO12010004','PK11100002',50,2,'0.00'),('PO12010004','PK11110001',100,4,'0.00'),('PO12010004','PK11120001',175,7,'0.00'),('PO12010004','PK11100001',100,4,'0.00'),('PO12010006','PK11100001',50,2,'0.00'),('PO12010006','PK11100002',50,2,'0.00'),('PO12010006','PK11110001',50,2,'0.00'),('PO12010007','KL11100001',25,1,'2000.00'),('PO12010007','KL12010001',25,1,'3000.00');

/*Table structure for table `trdetailreturbeli` */

DROP TABLE IF EXISTS `trdetailreturbeli`;

CREATE TABLE `trdetailreturbeli` (
  `KdReturDetail` int(11) NOT NULL AUTO_INCREMENT,
  `KdRetur` varchar(20) NOT NULL,
  `KdBahanMentah` varchar(20) NOT NULL,
  `Harga` decimal(20,2) NOT NULL,
  `Qty` double NOT NULL,
  `Disc` float(3,2) DEFAULT '0.00',
  `Qty_real` double DEFAULT NULL,
  PRIMARY KEY (`KdReturDetail`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=latin1;

/*Data for the table `trdetailreturbeli` */

insert  into `trdetailreturbeli`(`KdReturDetail`,`KdRetur`,`KdBahanMentah`,`Harga`,`Qty`,`Disc`,`Qty_real`) values (2,'RB1201210002','KL11100001','20000.00',30,0.00,1),(3,'RB1201210002','KL11100002','30000.00',120,0.00,4),(4,'RB1201210002','KL12010001','10000.00',60,0.00,2),(8,'RB1201220001','PK11100001','0.00',50,0.00,2),(9,'RB1201220001','PK11120001','0.00',125,0.00,5),(10,'RB1201220002','PK11120001','2000.00',50,0.00,2),(15,'RB1201220003','PK11100001','0.00',100,0.00,4),(16,'RB1201220003','PK11100002','20000.00',50,0.00,2),(17,'RB1201220004','PK11120001','0.00',175,0.00,7),(27,'RB1201210003','KL11100001','20000.00',30,0.00,1),(28,'RB1201210003','KL11100002','30000.00',30,0.00,1),(29,'RB1201210003','KL12010001','10000.00',30,0.00,1),(30,'RB1201210001','KL11100001','90000.00',30,0.00,1);

/*Table structure for table `trfaktur` */

DROP TABLE IF EXISTS `trfaktur`;

CREATE TABLE `trfaktur` (
  `no_increment` bigint(200) NOT NULL AUTO_INCREMENT,
  `KdFaktur` varchar(20) NOT NULL,
  `KdSO` varchar(20) NOT NULL,
  `TanggalFaktur` datetime NOT NULL,
  `KdSales` varchar(20) NOT NULL,
  `KdToko` varchar(20) NOT NULL,
  `GrandTotal` decimal(20,2) NOT NULL,
  `StatusFaktur` char(1) NOT NULL DEFAULT '0',
  `StatusPayment` char(1) DEFAULT '0',
  `UserID` varchar(20) NOT NULL,
  `KdSJ` varchar(20) DEFAULT NULL,
  `TanggalSJ` datetime DEFAULT NULL,
  `TotalKomisiSales` decimal(20,2) DEFAULT '0.00',
  `KomisiPersen` double(20,2) NOT NULL,
  `TanggalJT` date DEFAULT NULL,
  `jenis_faktur` enum('paku','klem') DEFAULT 'klem',
  `Disc` double DEFAULT '0',
  `Jumlah` decimal(20,2) DEFAULT '0.00' COMMENT 'granndtotal sebelum discount',
  PRIMARY KEY (`no_increment`,`KdFaktur`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `trfaktur` */

insert  into `trfaktur`(`no_increment`,`KdFaktur`,`KdSO`,`TanggalFaktur`,`KdSales`,`KdToko`,`GrandTotal`,`StatusFaktur`,`StatusPayment`,`UserID`,`KdSJ`,`TanggalSJ`,`TotalKomisiSales`,`KomisiPersen`,`TanggalJT`,`jenis_faktur`,`Disc`,`Jumlah`) values (1,'FK0001.22.01.12','SO0004.22.01.12','2012-01-22 00:00:00','SL11120002','TK1111040003','26608500.00','1','1','',NULL,NULL,'0.00',0.00,'2012-02-01','klem',0,'26608500.00'),(2,'FK0001.27.01.12','SO0002.22.01.12','2012-01-27 00:00:00','SL11120002','TK1111040003','11706525.00','1','0','',NULL,NULL,'0.00',0.00,'2012-02-06','klem',10,'13007250.00'),(3,'FK0002.27.01.12','SO0006.22.01.12','2012-01-27 09:33:55','SL11120002','TK1111040003','6892250.00','1','0','',NULL,NULL,'0.00',0.00,'2012-02-06','paku',0,'6892250.00'),(4,'FK0003.27.01.12','SO0007.22.01.12','2012-01-27 12:03:31','SL11120002','TK1111040003','1080000.00','1','0','',NULL,NULL,'0.00',0.00,'2012-02-06','paku',10,'1200000.00');

/*Table structure for table `trfakturdetail` */

DROP TABLE IF EXISTS `trfakturdetail`;

CREATE TABLE `trfakturdetail` (
  `KdFakturDetail` int(11) NOT NULL AUTO_INCREMENT,
  `KdFaktur` varchar(20) NOT NULL,
  `KdBarang` varchar(20) NOT NULL,
  `Harga` decimal(20,2) NOT NULL,
  `QtyFaktur` double NOT NULL,
  `Qty` double NOT NULL,
  `Disc` double NOT NULL,
  `StatusBarang` char(1) NOT NULL DEFAULT '0',
  `KomisiSales` decimal(20,2) DEFAULT '0.00',
  `HargaDisc` decimal(20,2) NOT NULL,
  PRIMARY KEY (`KdFakturDetail`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

/*Data for the table `trfakturdetail` */

insert  into `trfakturdetail`(`KdFakturDetail`,`KdFaktur`,`KdBarang`,`Harga`,`QtyFaktur`,`Qty`,`Disc`,`StatusBarang`,`KomisiSales`,`HargaDisc`) values (3,'FK0001.25.01.12','BG11110005','5400000.00',0,5,0,'0','0.00','5400000.00'),(4,'FK0001.25.01.12','BG11120001','7904250.00',0,3,0,'0','0.00','7904250.00'),(5,'FK0001.22.01.12','BG11110005','5500000.00',0,2,0,'0','0.00','5400000.00'),(6,'FK0001.22.01.12','BG11120001','7904250.00',0,2,0,'0','0.00','7904250.00'),(9,'FK0001.27.01.12','BG11110006','5103000.00',0,1,0,'0','0.00','5103000.00'),(10,'FK0001.27.01.12','BG11120001','7904250.00',0,1,0,'0','0.00','7904250.00'),(11,'FK0002.27.01.12','PK11110001','250000.00',0,2,0,'0','0.00','250000.00'),(12,'FK0002.27.01.12','PK11120001','3196125.00',0,2,0,'0','0.00','3196125.00'),(13,'FK0003.27.01.12','PK11100001','300000.00',0,2,0,'0','0.00','300000.00'),(14,'FK0003.27.01.12','PK11100002','200000.00',0,3,0,'0','0.00','200000.00');

/*Table structure for table `trheaderpb` */

DROP TABLE IF EXISTS `trheaderpb`;

CREATE TABLE `trheaderpb` (
  `no_increment` bigint(20) NOT NULL AUTO_INCREMENT,
  `No_PB` varchar(20) NOT NULL,
  `No_PO` varchar(20) NOT NULL,
  `userid` varchar(20) NOT NULL,
  `KdSupplier` varchar(20) DEFAULT NULL,
  `Tanggal_TerimaBarang` datetime NOT NULL,
  `StatusTerimaBarang` char(1) NOT NULL DEFAULT '0',
  `GrandTotal` double(20,2) NOT NULL DEFAULT '0.00',
  `StatusPaid` char(1) NOT NULL DEFAULT '0',
  `jenis_pb` enum('paku','klem') DEFAULT 'paku',
  `Disc` double DEFAULT '0',
  `Jumlah` decimal(20,2) DEFAULT '0.00',
  `StatusPayment` char(1) DEFAULT '0',
  PRIMARY KEY (`no_increment`,`No_PB`),
  KEY `userid` (`userid`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

/*Data for the table `trheaderpb` */

insert  into `trheaderpb`(`no_increment`,`No_PB`,`No_PO`,`userid`,`KdSupplier`,`Tanggal_TerimaBarang`,`StatusTerimaBarang`,`GrandTotal`,`StatusPaid`,`jenis_pb`,`Disc`,`Jumlah`,`StatusPayment`) values (1,'PB12010001','PO12010003','','SP11120001','2012-01-21 00:00:00','1',12420000.00,'1','klem',10,'13800000.00','0'),(2,'PB12010002','PO12010003','','SP11120001','2012-01-21 19:56:06','1',4500000.00,'0','klem',0,'4500000.00','0'),(3,'PB12010003','PO12010001','','SP11120001','2012-01-21 19:56:25','3',5940000.00,'0','klem',10,'6600000.00','0'),(4,'PB12010004','PO12010003','','SP11120001','2012-01-21 00:00:00','2',8100000.00,'0','klem',0,'8100000.00','0'),(6,'PB12010005','PO12010005','','SP11120001','2012-01-21 20:24:16','0',2250000.00,'0','paku',10,'2500000.00','0'),(7,'PB12010006','PO12010004','','SP11120001','2012-01-21 20:24:46','1',2250000.00,'0','paku',10,'2500000.00','0'),(8,'PB12010007','PO12010006','','SP11120001','2012-01-21 20:49:43','0',200000.00,'0','paku',0,'200000.00','0'),(9,'PB12010008','PO12010005','','SP11120001','2012-01-21 20:50:40','3',90000.00,'0','paku',10,'100000.00','0'),(12,'PO12010007','PO12010007','','SP11120001','2012-01-29 00:00:00','1',4500.00,'0','klem',10,'5000.00','0');

/*Table structure for table `trheaderpb_t` */

DROP TABLE IF EXISTS `trheaderpb_t`;

CREATE TABLE `trheaderpb_t` (
  `no_increment` bigint(20) NOT NULL AUTO_INCREMENT,
  `No_PB` varchar(20) NOT NULL,
  PRIMARY KEY (`no_increment`,`No_PB`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trheaderpb_t` */

/*Table structure for table `trheaderpo` */

DROP TABLE IF EXISTS `trheaderpo`;

CREATE TABLE `trheaderpo` (
  `no_increment` bigint(20) NOT NULL AUTO_INCREMENT,
  `No_PO` varchar(20) NOT NULL,
  `userid` varchar(20) NOT NULL,
  `Tanggal_PO` datetime NOT NULL,
  `KdSupplier` varchar(12) NOT NULL,
  `StatusPO` char(1) NOT NULL DEFAULT '0',
  `GrandTotal` decimal(20,2) NOT NULL DEFAULT '0.00',
  `jenis_po` enum('paku','klem','klem_jadi') DEFAULT 'paku',
  `disc` float NOT NULL DEFAULT '0',
  PRIMARY KEY (`no_increment`,`No_PO`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

/*Data for the table `trheaderpo` */

insert  into `trheaderpo`(`no_increment`,`No_PO`,`userid`,`Tanggal_PO`,`KdSupplier`,`StatusPO`,`GrandTotal`,`jenis_po`,`disc`) values (1,'PO12010001','','2012-01-21 00:00:00','SP11120001','2','0.00','klem',0),(2,'PO12010002','','2012-01-21 00:00:00','SP11120001','0','0.00','klem',0),(3,'PO12010003','','2012-01-21 15:29:39','SP11120001 ','1','0.00','klem',0),(5,'PO12010004','','2012-01-21 00:00:00','SP11120001','1','0.00','paku',0),(6,'PO12010005','','2012-01-21 17:45:12','SP11120001 ','0','0.00','paku',0),(7,'PO12010006','','2012-01-21 20:49:08','SP11120001 ','1','0.00','paku',0),(10,'PO12010007','','2012-01-29 00:00:00','SP11120001','2','0.00','klem',10);

/*Table structure for table `trheaderpo_t` */

DROP TABLE IF EXISTS `trheaderpo_t`;

CREATE TABLE `trheaderpo_t` (
  `no_increment` int(11) NOT NULL AUTO_INCREMENT,
  `no_po` varchar(20) NOT NULL,
  PRIMARY KEY (`no_increment`,`no_po`)
) ENGINE=InnoDB AUTO_INCREMENT=73 DEFAULT CHARSET=latin1;

/*Data for the table `trheaderpo_t` */

insert  into `trheaderpo_t`(`no_increment`,`no_po`) values (1,''),(2,''),(3,''),(4,''),(5,''),(6,''),(7,''),(8,''),(9,''),(10,''),(11,''),(12,''),(13,''),(14,''),(15,''),(16,''),(17,''),(18,''),(19,''),(20,''),(21,''),(22,''),(23,''),(24,''),(25,''),(26,''),(27,''),(28,''),(29,''),(30,''),(31,''),(32,''),(33,''),(34,''),(35,''),(36,''),(37,''),(38,''),(39,''),(40,''),(41,''),(42,''),(43,''),(44,''),(45,''),(46,''),(47,''),(48,''),(49,''),(50,''),(51,''),(52,''),(53,''),(54,''),(55,''),(56,''),(57,''),(58,''),(59,''),(60,''),(61,''),(62,''),(63,''),(64,''),(65,''),(66,''),(67,''),(68,''),(69,''),(70,''),(71,''),(72,'');

/*Table structure for table `trheaderreturbeli` */

DROP TABLE IF EXISTS `trheaderreturbeli`;

CREATE TABLE `trheaderreturbeli` (
  `no_increment` bigint(20) NOT NULL AUTO_INCREMENT,
  `KdRetur` varchar(20) NOT NULL,
  `KdPB` varchar(20) NOT NULL,
  `TanggalRetur` datetime NOT NULL,
  `KdSupplier` varchar(20) NOT NULL,
  `GrandTotal` decimal(20,2) NOT NULL,
  `StatusRetur` char(1) NOT NULL DEFAULT '0',
  `Note` text NOT NULL,
  `UserID` varchar(20) NOT NULL,
  `No_PO` varchar(20) DEFAULT NULL,
  `AfterPaid` char(1) DEFAULT '0',
  `jenis_retur` enum('paku','klem') DEFAULT 'klem',
  `Disc` double DEFAULT '0',
  `Jumlah` decimal(20,2) DEFAULT '0.00',
  PRIMARY KEY (`no_increment`,`KdRetur`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Data for the table `trheaderreturbeli` */

insert  into `trheaderreturbeli`(`no_increment`,`KdRetur`,`KdPB`,`TanggalRetur`,`KdSupplier`,`GrandTotal`,`StatusRetur`,`Note`,`UserID`,`No_PO`,`AfterPaid`,`jenis_retur`,`Disc`,`Jumlah`) values (1,'RB1201210001','PB12010004','2012-01-21 00:00:00','SP11120001','2700000.00','1','','',NULL,'0','klem',0,'2700000.00'),(2,'RB1201210002','PB12010003','2012-01-21 22:01:43','SP11120001','4320000.00','1','','',NULL,'0','klem',10,'4800000.00'),(3,'RB1201210003','PB12010003','2012-01-21 00:00:00','SP11120001','1620000.00','1','','',NULL,'0','klem',10,'1800000.00'),(5,'RB1201220002','PB12010008','2012-01-22 11:44:05','SP11120001','90000.00','1','','',NULL,'0','paku',10,'100000.00'),(7,'RB1201220003','PB12010006','2012-01-22 11:59:20','SP11120001','900000.00','0','','',NULL,'0','paku',10,'1000000.00'),(8,'RB1201220004','PB12010006','2012-01-22 11:59:42','SP11120001','0.00','0','','',NULL,'0','paku',10,'0.00');

/*Table structure for table `trhitung` */

DROP TABLE IF EXISTS `trhitung`;

CREATE TABLE `trhitung` (
  `no_increment` int(11) NOT NULL AUTO_INCREMENT,
  `KdHitung` varchar(25) NOT NULL,
  `TanggalHitung` datetime DEFAULT NULL,
  `KdKaryawan` varchar(25) DEFAULT NULL,
  `KdUser` varchar(25) DEFAULT NULL,
  `StatusHitung` char(1) DEFAULT '0',
  `StatusPayment` char(1) DEFAULT '0',
  `TelahDihitung` char(1) DEFAULT '0',
  PRIMARY KEY (`no_increment`,`KdHitung`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `trhitung` */

insert  into `trhitung`(`no_increment`,`KdHitung`,`TanggalHitung`,`KdKaryawan`,`KdUser`,`StatusHitung`,`StatusPayment`,`TelahDihitung`) values (4,'PH12010001','2012-01-11 00:00:00','KY11090002','','1','0','0'),(5,'PH12010002','2012-01-17 21:08:31','KY11090002','','1','0','0'),(7,'PH12010003','2012-01-27 00:00:00','KY11090002','','1','0','0');

/*Table structure for table `trhitung_diterima` */

DROP TABLE IF EXISTS `trhitung_diterima`;

CREATE TABLE `trhitung_diterima` (
  `no_increment` int(11) NOT NULL AUTO_INCREMENT,
  `KdHitungDiterima` varchar(25) NOT NULL,
  `KdHitung` varchar(25) DEFAULT NULL,
  `TanggalHitungDiterima` datetime DEFAULT NULL,
  `KdKaryawan` varchar(25) DEFAULT NULL,
  `KdUser` varchar(25) DEFAULT NULL,
  `StatusHitungDiterima` char(1) DEFAULT '0',
  `StatusPaymentDiterima` char(1) DEFAULT '0',
  PRIMARY KEY (`no_increment`,`KdHitungDiterima`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Data for the table `trhitung_diterima` */

insert  into `trhitung_diterima`(`no_increment`,`KdHitungDiterima`,`KdHitung`,`TanggalHitungDiterima`,`KdKaryawan`,`KdUser`,`StatusHitungDiterima`,`StatusPaymentDiterima`) values (6,'HD12010001','PH12010001','2012-01-17 00:00:00','KY11090002','KY11090002','1','0'),(7,'HD12010002','PH12010002','2012-01-17 00:00:00','KY11090002','KY11090002','1','0'),(8,'HD12010003','PH12010003','2012-01-27 00:00:00','KY11090002','KY11090002','1','1');

/*Table structure for table `trhitung_diterima_t` */

DROP TABLE IF EXISTS `trhitung_diterima_t`;

CREATE TABLE `trhitung_diterima_t` (
  `no_increment` int(11) NOT NULL AUTO_INCREMENT,
  `KdHitungDiterima` varchar(25) NOT NULL,
  PRIMARY KEY (`no_increment`,`KdHitungDiterima`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trhitung_diterima_t` */

/*Table structure for table `trhitung_t` */

DROP TABLE IF EXISTS `trhitung_t`;

CREATE TABLE `trhitung_t` (
  `no_increment` int(11) NOT NULL AUTO_INCREMENT,
  `KdHitung` varchar(25) NOT NULL,
  PRIMARY KEY (`no_increment`,`KdHitung`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trhitung_t` */

/*Table structure for table `trhitungdetail` */

DROP TABLE IF EXISTS `trhitungdetail`;

CREATE TABLE `trhitungdetail` (
  `KdHitungDetail` int(11) NOT NULL AUTO_INCREMENT,
  `KdHitung` varchar(25) NOT NULL,
  `KdKlemHitung` varchar(20) NOT NULL,
  `QtyKlemHitung` double NOT NULL,
  `StatusKlemMentah` char(1) DEFAULT '0',
  PRIMARY KEY (`KdHitungDetail`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

/*Data for the table `trhitungdetail` */

insert  into `trhitungdetail`(`KdHitungDetail`,`KdHitung`,`KdKlemHitung`,`QtyKlemHitung`,`StatusKlemMentah`) values (3,'PH12010001','KL11100001',1,'0'),(4,'PH12010002','KL11100001',1,'0'),(9,'PH12010003','KL11100002',1,'0');

/*Table structure for table `trhitungdetail_diterima` */

DROP TABLE IF EXISTS `trhitungdetail_diterima`;

CREATE TABLE `trhitungdetail_diterima` (
  `KdHitungDiterimaDetail` int(11) NOT NULL AUTO_INCREMENT,
  `KdHitungDiterima` varchar(25) NOT NULL,
  `KdKlemJadi` varchar(20) NOT NULL,
  `HargaModalKlemJadi` decimal(20,0) NOT NULL DEFAULT '0',
  `QtyKlemJadi` int(11) NOT NULL,
  `QtyKlemPrioritas` int(11) DEFAULT NULL,
  PRIMARY KEY (`KdHitungDiterimaDetail`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

/*Data for the table `trhitungdetail_diterima` */

insert  into `trhitungdetail_diterima`(`KdHitungDiterimaDetail`,`KdHitungDiterima`,`KdKlemJadi`,`HargaModalKlemJadi`,`QtyKlemJadi`,`QtyKlemPrioritas`) values (7,'HD12010001','BG11110005','30000',20,NULL),(8,'HD12010001','BG11110006','40000',200,NULL),(9,'HD12010001','BG11120001','50000',20,NULL),(11,'HD12010002','BG11110005','50000',200,NULL),(14,'HD12010003','BG11110006','30000',100,83),(15,'HD12010003','BG11120001','3000',50,50);

/*Table structure for table `trhitungdetail_hasil` */

DROP TABLE IF EXISTS `trhitungdetail_hasil`;

CREATE TABLE `trhitungdetail_hasil` (
  `KdHitungDetailHasil` int(11) NOT NULL AUTO_INCREMENT,
  `KdHitung` varchar(25) NOT NULL,
  `KdKlemJadi` varchar(20) NOT NULL,
  `QtyKlemJadi` double NOT NULL,
  `StatusKlemMentah` char(1) DEFAULT '0',
  PRIMARY KEY (`KdHitungDetailHasil`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

/*Data for the table `trhitungdetail_hasil` */

insert  into `trhitungdetail_hasil`(`KdHitungDetailHasil`,`KdHitung`,`KdKlemJadi`,`QtyKlemJadi`,`StatusKlemMentah`) values (5,'PH12010001','BG11110005',20,'0'),(6,'PH12010001','BG11110006',0,'0'),(7,'PH12010001','BG11120001',20,'0'),(8,'PH12010002','BG11110005',200,'0'),(16,'PH12010003','BG11110006',15,'0'),(17,'PH12010003','BG11120001',10,'0');

/*Table structure for table `trpantek` */

DROP TABLE IF EXISTS `trpantek`;

CREATE TABLE `trpantek` (
  `no_increment` int(11) NOT NULL AUTO_INCREMENT,
  `KdPantek` varchar(25) NOT NULL,
  `TanggalPantek` datetime DEFAULT NULL,
  `KdKaryawan` varchar(25) DEFAULT NULL,
  `KdUser` varchar(25) DEFAULT NULL,
  `StatusPantek` char(1) DEFAULT '0',
  `StatusPayment` char(1) DEFAULT '0',
  PRIMARY KEY (`no_increment`,`KdPantek`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trpantek` */

/*Table structure for table `trpantek_diterima` */

DROP TABLE IF EXISTS `trpantek_diterima`;

CREATE TABLE `trpantek_diterima` (
  `no_increment` int(11) NOT NULL AUTO_INCREMENT,
  `KdPantekDiterima` varchar(25) NOT NULL,
  `KdPantek` varchar(25) NOT NULL,
  `TanggalPantekDiterima` datetime DEFAULT NULL,
  `KdKaryawan` varchar(25) DEFAULT NULL,
  `KdUser` varchar(25) DEFAULT NULL,
  `StatusPantekDiterima` char(1) DEFAULT '0',
  `StatusPaymentDiterima` char(1) DEFAULT '0',
  PRIMARY KEY (`no_increment`,`KdPantekDiterima`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `trpantek_diterima` */

insert  into `trpantek_diterima`(`no_increment`,`KdPantekDiterima`,`KdPantek`,`TanggalPantekDiterima`,`KdKaryawan`,`KdUser`,`StatusPantekDiterima`,`StatusPaymentDiterima`) values (2,'PK12010002','PK12010001','2012-01-04 00:00:00','KY11090001','','1','0'),(3,'PK12010003','PK12010003','2012-01-27 13:35:28','KY11090002','','1','1');

/*Table structure for table `trpantek_diterima_detail` */

DROP TABLE IF EXISTS `trpantek_diterima_detail`;

CREATE TABLE `trpantek_diterima_detail` (
  `KdPantekDiterimaDetail` int(11) NOT NULL AUTO_INCREMENT,
  `KdPantekDiterima` varchar(25) NOT NULL,
  `KdKlemMentah` varchar(20) NOT NULL,
  `QtyKlemMentah` double NOT NULL,
  `KdPaku` varchar(20) NOT NULL,
  `QtyPaku` double NOT NULL,
  `QtyKlemMentahDiterima` double NOT NULL,
  PRIMARY KEY (`KdPantekDiterimaDetail`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `trpantek_diterima_detail` */

insert  into `trpantek_diterima_detail`(`KdPantekDiterimaDetail`,`KdPantekDiterima`,`KdKlemMentah`,`QtyKlemMentah`,`KdPaku`,`QtyPaku`,`QtyKlemMentahDiterima`) values (1,'PK12010001','KL11100001',1,'PK11100001',2,1),(3,'PK12010002','KL11100001',2,'PK11100001',2,2),(4,'PK12010003','KL11100001',2,'PK11100001',2,2),(5,'PK12010003','KL11100002',3,'PK11120001',3,3);

/*Table structure for table `trpantek_diterima_t` */

DROP TABLE IF EXISTS `trpantek_diterima_t`;

CREATE TABLE `trpantek_diterima_t` (
  `no_increment` int(11) NOT NULL AUTO_INCREMENT,
  `KdPantekDiterima` varchar(25) NOT NULL,
  PRIMARY KEY (`no_increment`,`KdPantekDiterima`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trpantek_diterima_t` */

/*Table structure for table `trpantek_t` */

DROP TABLE IF EXISTS `trpantek_t`;

CREATE TABLE `trpantek_t` (
  `no_increment` int(11) NOT NULL AUTO_INCREMENT,
  `KdPantek` varchar(25) NOT NULL,
  PRIMARY KEY (`no_increment`,`KdPantek`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trpantek_t` */

/*Table structure for table `trpantekdetail` */

DROP TABLE IF EXISTS `trpantekdetail`;

CREATE TABLE `trpantekdetail` (
  `KdPantekDetail` int(11) NOT NULL AUTO_INCREMENT,
  `KdPantek` varchar(25) NOT NULL,
  `KdKlemMentah` varchar(20) NOT NULL,
  `QtyKlemMentah` double NOT NULL,
  `KdPaku` varchar(20) NOT NULL,
  `QtyPaku` double NOT NULL,
  `StatusKlemMentah` char(1) DEFAULT '0',
  PRIMARY KEY (`KdPantekDetail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trpantekdetail` */

/*Table structure for table `trpenggajian` */

DROP TABLE IF EXISTS `trpenggajian`;

CREATE TABLE `trpenggajian` (
  `no_increment` int(11) NOT NULL AUTO_INCREMENT,
  `KdPenggajian` varchar(20) NOT NULL,
  `TanggalPenggajian` datetime DEFAULT NULL,
  `TanggalAwal` date DEFAULT NULL,
  `TanggalAkhir` date DEFAULT NULL,
  `KdUser` varchar(25) DEFAULT NULL,
  `StatusPenggajian` char(1) DEFAULT '0',
  `StatusPayment` char(1) DEFAULT '0',
  PRIMARY KEY (`no_increment`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `trpenggajian` */

insert  into `trpenggajian`(`no_increment`,`KdPenggajian`,`TanggalPenggajian`,`TanggalAwal`,`TanggalAkhir`,`KdUser`,`StatusPenggajian`,`StatusPayment`) values (5,'PG12010001','2012-01-28 00:00:00','2012-01-27','2012-01-28','','1','0');

/*Table structure for table `trpenggajian_t` */

DROP TABLE IF EXISTS `trpenggajian_t`;

CREATE TABLE `trpenggajian_t` (
  `no_increment` int(11) NOT NULL AUTO_INCREMENT,
  `KdPenggajian` varchar(25) NOT NULL,
  PRIMARY KEY (`no_increment`,`KdPenggajian`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trpenggajian_t` */

/*Table structure for table `trpenggajiandetail` */

DROP TABLE IF EXISTS `trpenggajiandetail`;

CREATE TABLE `trpenggajiandetail` (
  `KdPenggajianDetail` int(11) NOT NULL AUTO_INCREMENT,
  `KdPenggajian` varchar(20) NOT NULL,
  `KdReferensi` varchar(200) NOT NULL,
  `KdKaryawan` varchar(20) NOT NULL,
  `TanggalPengerjaan` text NOT NULL,
  `KdBarang` varchar(20) NOT NULL,
  `Qty` int(20) NOT NULL DEFAULT '0',
  `GajiPerQty` decimal(10,0) NOT NULL DEFAULT '0',
  PRIMARY KEY (`KdPenggajianDetail`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=latin1;

/*Data for the table `trpenggajiandetail` */

insert  into `trpenggajiandetail`(`KdPenggajianDetail`,`KdPenggajian`,`KdReferensi`,`KdKaryawan`,`TanggalPengerjaan`,`KdBarang`,`Qty`,`GajiPerQty`) values (24,'PG12010001','PK12010003','KY11090002','27','KL11100001',2,'200'),(25,'PG12010001','PK12010003','KY11090002','27','KL11100002',3,'100'),(26,'PG12010001','HD12010003','KY11090002','27','BG11110006',100,'200'),(27,'PG12010001','HD12010003','KY11090002','27','BG11120001',50,'100');

/*Table structure for table `trpurchasepayment` */

DROP TABLE IF EXISTS `trpurchasepayment`;

CREATE TABLE `trpurchasepayment` (
  `no_increment` bigint(20) NOT NULL AUTO_INCREMENT,
  `KdPurchasePayment` varchar(20) NOT NULL,
  `No_PB` varchar(20) NOT NULL,
  `TanggalPurchasePayment` datetime NOT NULL,
  `KdSupplier` varchar(20) NOT NULL,
  `TotalPurchasePayment` decimal(20,2) NOT NULL,
  `StatusPurchasePayment` char(1) NOT NULL DEFAULT '0',
  `Note` text NOT NULL,
  `UserID` varchar(20) NOT NULL,
  `PaidBy` varchar(20) DEFAULT 'Cash',
  `No_PO` varchar(20) DEFAULT NULL,
  `jenis_payment` enum('paku','klem') DEFAULT 'klem',
  `Jumlah` decimal(20,2) DEFAULT '0.00',
  `Disc` double DEFAULT '0',
  PRIMARY KEY (`no_increment`,`KdPurchasePayment`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `trpurchasepayment` */

insert  into `trpurchasepayment`(`no_increment`,`KdPurchasePayment`,`No_PB`,`TanggalPurchasePayment`,`KdSupplier`,`TotalPurchasePayment`,`StatusPurchasePayment`,`Note`,`UserID`,`PaidBy`,`No_PO`,`jenis_payment`,`Jumlah`,`Disc`) values (2,'FP1201220002','PB12010001','2012-01-22 00:00:00','SP11120001','12420000.00','1','','','Cheque',NULL,'klem','13800000.00',10),(3,'FP1201220003','PB12010006','2012-01-22 15:22:07','SP11120001','1350000.00','0','','','Transfer',NULL,'paku','1500000.00',10);

/*Table structure for table `trpurchasepaymentdetail` */

DROP TABLE IF EXISTS `trpurchasepaymentdetail`;

CREATE TABLE `trpurchasepaymentdetail` (
  `KdPurchasePaymentDetail` double NOT NULL AUTO_INCREMENT,
  `KdPurchasePayment` varchar(20) DEFAULT NULL,
  `KdBahanMentah` varchar(20) DEFAULT NULL,
  `Harga` decimal(20,2) DEFAULT NULL,
  `Qty` double DEFAULT NULL,
  `Disc` double DEFAULT NULL,
  `StatusBarang` varchar(200) DEFAULT NULL,
  `Qty_real` double DEFAULT NULL,
  PRIMARY KEY (`KdPurchasePaymentDetail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trpurchasepaymentdetail` */

insert  into `trpurchasepaymentdetail`(`KdPurchasePaymentDetail`,`KdPurchasePayment`,`KdBahanMentah`,`Harga`,`Qty`,`Disc`,`StatusBarang`,`Qty_real`) values (1,'FP1201220001','KL11100001','30000.00',150,0,'Normal',5),(4,'FP1201220002','KL11100001','30000.00',420,0,'Normal',14),(5,'FP1201220002','KL11100002','20000.00',60,0,'Normal',2),(6,'FP1201220003','PK11110001','30000.00',50,0,'Normal',2);

/*Table structure for table `trretur` */

DROP TABLE IF EXISTS `trretur`;

CREATE TABLE `trretur` (
  `no_increment` bigint(20) NOT NULL AUTO_INCREMENT,
  `KdRetur` varchar(20) NOT NULL,
  `KdFaktur` varchar(20) NOT NULL,
  `TanggalRetur` datetime NOT NULL,
  `KdSales` varchar(20) NOT NULL,
  `KdToko` varchar(20) NOT NULL,
  `GrandTotal` decimal(20,2) NOT NULL,
  `StatusRetur` char(1) NOT NULL DEFAULT '0',
  `Note` text NOT NULL,
  `UserID` varchar(20) NOT NULL,
  `AfterPaid` char(1) DEFAULT '0',
  `KdSO` varchar(20) DEFAULT NULL,
  `jenis_retur` enum('paku','klem') DEFAULT 'klem',
  `Disc` double DEFAULT '0',
  `Jumlah` decimal(20,2) DEFAULT '0.00' COMMENT 'granndtotal sebelum discount',
  PRIMARY KEY (`no_increment`,`KdRetur`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `trretur` */

insert  into `trretur`(`no_increment`,`KdRetur`,`KdFaktur`,`TanggalRetur`,`KdSales`,`KdToko`,`GrandTotal`,`StatusRetur`,`Note`,`UserID`,`AfterPaid`,`KdSO`,`jenis_retur`,`Disc`,`Jumlah`) values (1,'RF0001.27.01.12','FK0001.22.01.12','2012-01-27 09:04:19','SL11120002','TK1111040003','13304250.00','0','','','0',NULL,'klem',0,'13304250.00'),(2,'RF0002.27.01.12','FK0001.27.01.12','2012-01-27 09:11:07','SL11120002','TK1111040003','11706525.00','0','','','0',NULL,'klem',10,'13007250.00'),(3,'RF0003.27.01.12','FK0002.27.01.12','2012-01-27 09:42:13','SL11120002','TK1111040003','3446125.00','0','','','0',NULL,'paku',0,'3446125.00');

/*Table structure for table `trreturdetail` */

DROP TABLE IF EXISTS `trreturdetail`;

CREATE TABLE `trreturdetail` (
  `KdReturDetail` int(11) NOT NULL AUTO_INCREMENT,
  `KdRetur` varchar(20) NOT NULL,
  `KdBarang` varchar(20) NOT NULL,
  `Harga` decimal(20,2) NOT NULL,
  `Qty` double NOT NULL,
  `Disc` double NOT NULL,
  `HargaDisc` decimal(20,2) NOT NULL,
  `StatusBarang` varchar(20) NOT NULL,
  PRIMARY KEY (`KdReturDetail`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Data for the table `trreturdetail` */

insert  into `trreturdetail`(`KdReturDetail`,`KdRetur`,`KdBarang`,`Harga`,`Qty`,`Disc`,`HargaDisc`,`StatusBarang`) values (1,'RF0001.27.01.12','BG11110005','5500000.00',1,0,'5400000.00','Salah Pesan'),(2,'RF0001.27.01.12','BG11120001','7904250.00',1,0,'7904250.00','Salah Pesan'),(3,'RF0002.27.01.12','BG11110006','5103000.00',1,0,'5103000.00','Salah Pesan'),(4,'RF0002.27.01.12','BG11120001','7904250.00',1,0,'7904250.00','Salah Pesan'),(5,'RF0003.27.01.12','PK11110001','250000.00',1,0,'250000.00','Salah Pesan'),(6,'RF0003.27.01.12','PK11120001','3196125.00',1,0,'3196125.00','Kelebihan Qty');

/*Table structure for table `trsalesorder` */

DROP TABLE IF EXISTS `trsalesorder`;

CREATE TABLE `trsalesorder` (
  `no_increment` bigint(20) NOT NULL AUTO_INCREMENT,
  `KdSO` varchar(20) NOT NULL,
  `TanggalSO` datetime NOT NULL,
  `KdSales` varchar(20) NOT NULL,
  `KdToko` varchar(20) NOT NULL,
  `GrandTotal` decimal(20,2) NOT NULL,
  `StatusSO` char(1) NOT NULL DEFAULT '0',
  `UserID` varchar(20) NOT NULL,
  `KomisiSales` double(20,2) DEFAULT '0.00',
  `jenis_so` enum('paku','klem') DEFAULT 'klem' COMMENT '0:klem, 1:paku',
  `disc` double DEFAULT '0',
  `Jumlah` decimal(20,2) DEFAULT '0.00' COMMENT 'granndtotal sebelum discount',
  PRIMARY KEY (`no_increment`,`KdSO`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `trsalesorder` */

insert  into `trsalesorder`(`no_increment`,`KdSO`,`TanggalSO`,`KdSales`,`KdToko`,`GrandTotal`,`StatusSO`,`UserID`,`KomisiSales`,`jenis_so`,`disc`,`Jumlah`) values (2,'SO0002.22.01.12','2012-01-22 17:48:57','SL11120002','TK1111040003','37191150.00','2','',0.00,'klem',10,'41323500.00'),(3,'SO0003.22.01.12','2012-01-22 00:00:00','SL11120002','TK1111040003','53015000.00','0','',0.00,'klem',0,'53015000.00'),(4,'SO0004.22.01.12','2012-01-22 18:24:05','SL11120002','TK1111040003','66521250.00','2','',0.00,'klem',0,'66521250.00'),(6,'SO0006.22.01.12','2012-01-22 18:27:38','SL11120002','TK1111040003','6892250.00','2','',0.00,'paku',0,'6892250.00'),(7,'SO0007.22.01.12','2012-01-22 00:00:00','SL11120002','TK1111040003','1080000.00','2','',0.00,'paku',10,'1200000.00');

/*Table structure for table `trsalesorderdetail` */

DROP TABLE IF EXISTS `trsalesorderdetail`;

CREATE TABLE `trsalesorderdetail` (
  `KdSODetail` int(11) NOT NULL AUTO_INCREMENT,
  `KdSO` varchar(20) NOT NULL,
  `KdBarang` varchar(20) NOT NULL,
  `Harga` decimal(20,2) NOT NULL,
  `Qty` double NOT NULL,
  `Disc` double(10,2) NOT NULL,
  `StatusBarang` char(1) NOT NULL DEFAULT '0',
  `HargaDisc` decimal(20,2) NOT NULL,
  PRIMARY KEY (`KdSODetail`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

/*Data for the table `trsalesorderdetail` */

insert  into `trsalesorderdetail`(`KdSODetail`,`KdSO`,`KdBarang`,`Harga`,`Qty`,`Disc`,`StatusBarang`,`HargaDisc`) values (1,'SO0001.22.01.12','BG11110005','5400000.00',5,0.00,'0','5400000.00'),(2,'SO0001.22.01.12','BG11120001','7904250.00',5,0.00,'0','7904250.00'),(3,'SO0002.22.01.12','BG11110006','5103000.00',5,0.00,'2','5103000.00'),(4,'SO0002.22.01.12','BG11120001','7904250.00',2,0.00,'2','7904250.00'),(7,'SO0003.22.01.12','BG11110005','5500000.00',5,0.00,'0','5500000.00'),(8,'SO0003.22.01.12','BG11110006','5103000.00',5,0.00,'0','5103000.00'),(9,'SO0004.22.01.12','BG11120001','7904250.00',5,0.00,'2','7904250.00'),(10,'SO0004.22.01.12','BG11110005','5400000.00',5,0.00,'2','5400000.00'),(11,'SO0005.22.01.12','PK11100002','300000.00',3,0.00,'0','300000.00'),(12,'SO0005.22.01.12','PK11100001','300000.00',2,0.00,'0','300000.00'),(13,'SO0006.22.01.12','PK11110001','250000.00',2,0.00,'2','250000.00'),(14,'SO0006.22.01.12','PK11120001','3196125.00',2,0.00,'2','3196125.00'),(17,'SO0007.22.01.12','PK11100001','300000.00',2,0.00,'2','300000.00'),(18,'SO0007.22.01.12','PK11100002','200000.00',3,0.00,'2','200000.00');

/*Table structure for table `trsalesorderdetailpending` */

DROP TABLE IF EXISTS `trsalesorderdetailpending`;

CREATE TABLE `trsalesorderdetailpending` (
  `KdSODetail` int(11) NOT NULL AUTO_INCREMENT,
  `KdSO` varchar(20) NOT NULL,
  `KdBarang` varchar(20) NOT NULL,
  `Harga` decimal(20,2) NOT NULL,
  `Qty` double NOT NULL,
  `Disc` double(10,2) NOT NULL,
  `StatusBarang` char(1) NOT NULL DEFAULT '0',
  `HargaDisc` decimal(20,2) NOT NULL,
  PRIMARY KEY (`KdSODetail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trsalesorderdetailpending` */

/*Table structure for table `trsalespayment` */

DROP TABLE IF EXISTS `trsalespayment`;

CREATE TABLE `trsalespayment` (
  `no_increment` bigint(20) NOT NULL AUTO_INCREMENT,
  `KdSalesPayment` varchar(20) NOT NULL,
  `KdFaktur` varchar(20) DEFAULT NULL,
  `TanggalSalesPayment` datetime NOT NULL,
  `KdSales` varchar(20) NOT NULL,
  `KdToko` varchar(20) NOT NULL,
  `TotalSalesPayment` decimal(20,2) NOT NULL,
  `StatusSalesPayment` char(1) NOT NULL DEFAULT '0',
  `Note` text NOT NULL,
  `UserID` varchar(20) NOT NULL,
  `PaidBy` char(1) DEFAULT '1' COMMENT '1:LewatSales, 2:Langusng',
  `KdSO` varchar(20) DEFAULT NULL,
  `flag_payment` char(1) DEFAULT '0' COMMENT '0:perToko, 1:PerTanggal',
  `jenis_payment` enum('paku','klem') DEFAULT 'paku',
  `disc_payment` float DEFAULT '0',
  `komisi_sales` decimal(20,2) DEFAULT '0.00',
  PRIMARY KEY (`no_increment`,`KdSalesPayment`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `trsalespayment` */

insert  into `trsalespayment`(`no_increment`,`KdSalesPayment`,`KdFaktur`,`TanggalSalesPayment`,`KdSales`,`KdToko`,`TotalSalesPayment`,`StatusSalesPayment`,`Note`,`UserID`,`PaidBy`,`KdSO`,`flag_payment`,`jenis_payment`,`disc_payment`,`komisi_sales`) values (1,'PF0001.27.01.12/SL11','FK0001.22.01.12','2012-01-27 00:00:00','SL11120002','TK1111040003','13000000.00','0','','','2',NULL,'0','klem',0,'2080000.00'),(3,'PF0002.27.01.12/SL11','FK0001.22.01.12','2012-01-27 11:53:29','SL11120002','TK1111040003','304250.00','1','','','2',NULL,'0','klem',0,'48680.00'),(4,'PF0003.27.01.12/SL11','FK0002.27.01.12','2012-01-27 12:01:42','SL11120002','TK1111040003','446125.00','0','','','2',NULL,'0','paku',0,'0.00'),(5,'PF0004.27.01.12/SL11','FK0003.27.01.12','2012-01-27 12:03:44','SL11120002','TK1111040003','80000.00','0','','','2',NULL,'0','paku',10,'0.00');

/*Table structure for table `trsalespaymentbydate` */

DROP TABLE IF EXISTS `trsalespaymentbydate`;

CREATE TABLE `trsalespaymentbydate` (
  `no_increment` bigint(20) NOT NULL AUTO_INCREMENT,
  `KdSalesPayment` varchar(20) NOT NULL,
  `TanggalPayment` datetime DEFAULT NULL,
  `DariTanggal` datetime DEFAULT NULL,
  `SampaiTanggal` datetime NOT NULL,
  `KdSales` varchar(20) NOT NULL,
  `TotalSalesPayment` decimal(20,2) NOT NULL,
  `StatusSalesPayment` char(1) NOT NULL DEFAULT '0',
  `Note` text NOT NULL,
  `UserID` varchar(20) NOT NULL,
  `flag_payment` char(1) DEFAULT '0' COMMENT '0:perToko, 1:PerTanggal',
  `komisi_sales` double DEFAULT '0',
  `DiscPembayaran` double DEFAULT '0',
  PRIMARY KEY (`no_increment`,`KdSalesPayment`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `trsalespaymentbydate` */

insert  into `trsalespaymentbydate`(`no_increment`,`KdSalesPayment`,`TanggalPayment`,`DariTanggal`,`SampaiTanggal`,`KdSales`,`TotalSalesPayment`,`StatusSalesPayment`,`Note`,`UserID`,`flag_payment`,`komisi_sales`,`DiscPembayaran`) values (1,'PF0005.27.01.12','2012-01-27 12:46:26','2012-01-27 12:46:26','2012-02-27 12:46:26','SL11120002','7675373.00','0','','','1',0,10);

/*Table structure for table `trsalespaymentbydatedetail` */

DROP TABLE IF EXISTS `trsalespaymentbydatedetail`;

CREATE TABLE `trsalespaymentbydatedetail` (
  `KdSalesPaymentDetail` double NOT NULL AUTO_INCREMENT,
  `KdSalesPayment` varchar(20) DEFAULT NULL,
  `KdFaktur` varchar(20) DEFAULT NULL,
  `GrandtotalFaktur` decimal(20,2) DEFAULT '0.00',
  `PaidBy` char(1) DEFAULT '0' COMMENT '0:Lewat Sales, 1:Langsung ke om acu',
  PRIMARY KEY (`KdSalesPaymentDetail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trsalespaymentbydatedetail` */

insert  into `trsalespaymentbydatedetail`(`KdSalesPaymentDetail`,`KdSalesPayment`,`KdFaktur`,`GrandtotalFaktur`,`PaidBy`) values (1,'PF0005.27.01.12','FK0001.27.01.12','11.00','0'),(2,'PF0005.27.01.12','FK0002.27.01.12','6.00','1'),(3,'PF0005.27.01.12','FK0003.27.01.12','1.00','1');

/*Table structure for table `trsalespaymentdetail` */

DROP TABLE IF EXISTS `trsalespaymentdetail`;

CREATE TABLE `trsalespaymentdetail` (
  `KdSalesPaymentDetail` double NOT NULL AUTO_INCREMENT,
  `KdSalesPayment` varchar(20) DEFAULT NULL,
  `KdBarang` varchar(20) DEFAULT NULL,
  `Harga` decimal(20,2) DEFAULT NULL,
  `Qty` double DEFAULT NULL,
  `Disc` double DEFAULT NULL,
  `StatusBarang` varchar(200) DEFAULT NULL,
  `HargaDisc` decimal(20,2) DEFAULT '0.00',
  PRIMARY KEY (`KdSalesPaymentDetail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `trsalespaymentdetail` */

insert  into `trsalespaymentdetail`(`KdSalesPaymentDetail`,`KdSalesPayment`,`KdBarang`,`Harga`,`Qty`,`Disc`,`StatusBarang`,`HargaDisc`) values (5,'PF0002.27.01.12/SL11','BG11110005','5500000.00',1,0,'Retur','5400000.00'),(6,'PF0002.27.01.12/SL11','BG11120001','7904250.00',1,0,'Retur','7904250.00'),(9,'PF0003.27.01.12/SL11','PK11110001','250000.00',1,0,'Retur','250000.00'),(10,'PF0003.27.01.12/SL11','PK11120001','3196125.00',1,0,'Retur','3196125.00'),(11,'PF0004.27.01.12/SL11','PK11100001','300000.00',2,0,'Normal','300000.00'),(12,'PF0004.27.01.12/SL11','PK11100002','200000.00',3,0,'Normal','200000.00'),(21,'PF0001.27.01.12/SL11','BG11110005','5500000.00',1,0,'Retur','5400000.00'),(22,'PF0001.27.01.12/SL11','BG11120001','7904250.00',1,0,'Retur','7904250.00');

/*Table structure for table `viewcetaktrreturbeli` */

DROP TABLE IF EXISTS `viewcetaktrreturbeli`;

/*!50001 DROP VIEW IF EXISTS `viewcetaktrreturbeli` */;
/*!50001 DROP TABLE IF EXISTS `viewcetaktrreturbeli` */;

/*!50001 CREATE TABLE  `viewcetaktrreturbeli`(
 `KdRetur` varchar(20) ,
 `TanggalRetur` datetime ,
 `No Penerimaan` varchar(20) ,
 `Nama` varchar(200) ,
 `Grandtotal` decimal(20,2) ,
 `KDBarang` varchar(20) ,
 `NamaBarang` varchar(200) ,
 `harga` decimal(20,2) ,
 `disc` float(3,2) ,
 `qty` double 
)*/;

/*View structure for view viewcetaktrreturbeli */

/*!50001 DROP TABLE IF EXISTS `viewcetaktrreturbeli` */;
/*!50001 DROP VIEW IF EXISTS `viewcetaktrreturbeli` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `viewcetaktrreturbeli` AS (select `retur`.`KdRetur` AS `KdRetur`,`retur`.`TanggalRetur` AS `TanggalRetur`,`retur`.`KdPB` AS `No Penerimaan`,`mt`.`Nama` AS `Nama`,`retur`.`GrandTotal` AS `Grandtotal`,`mp`.`KdBahanMentah` AS `KDBarang`,`mp`.`NamaBahanMentah` AS `NamaBarang`,`rd`.`Harga` AS `harga`,`rd`.`Disc` AS `disc`,`rd`.`Qty` AS `qty` from (((((`trheaderreturbeli` `retur` join `trheaderpb` `pb` on((`pb`.`No_PB` = `retur`.`KdPB`))) join `trdetailreturbeli` `rd` on((`rd`.`KdRetur` = `retur`.`KdRetur`))) join `msbahanmentah` `mp` on((`mp`.`KdBahanMentah` = `rd`.`KdBahanMentah`))) join `mssupplier` `mt` on((`mt`.`KdSupplier` = `pb`.`KdSupplier`))) join `msuser` `mu` on((`mu`.`userid` = `retur`.`UserID`))) where (`retur`.`KdRetur` = 'RB1201210001')) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
