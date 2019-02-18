/*
SQLyog Enterprise - MySQL GUI v7.14 
MySQL - 5.6.25 : Database - db_penjadwalan_pelabuhan
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_penjadwalan_pelabuhan` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `db_penjadwalan_pelabuhan`;

/*Table structure for table `detailjetty` */

DROP TABLE IF EXISTS `detailjetty`;

CREATE TABLE `detailjetty` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idpelabuhan` int(11) DEFAULT NULL,
  `idproduk` int(11) DEFAULT NULL,
  `idjetty` int(11) DEFAULT NULL,
  `kap` int(11) DEFAULT NULL,
  `occ` int(11) DEFAULT NULL,
  `jalurpipa` int(11) DEFAULT NULL,
  `diameterpipa` int(11) DEFAULT NULL,
  `satuandiameter` int(11) DEFAULT NULL,
  `utilisasi` text,
  `maxload` int(11) DEFAULT NULL,
  `kedalamanair` int(11) DEFAULT NULL,
  `flowratemax` int(11) DEFAULT NULL,
  `ket` text,
  PRIMARY KEY (`id`),
  KEY `FK_detailjetty` (`idjetty`),
  CONSTRAINT `FK_detailjetty` FOREIGN KEY (`idjetty`) REFERENCES `listjetty` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

/*Data for the table `detailjetty` */

insert  into `detailjetty`(`id`,`idpelabuhan`,`idproduk`,`idjetty`,`kap`,`occ`,`jalurpipa`,`diameterpipa`,`satuandiameter`,`utilisasi`,`maxload`,`kedalamanair`,`flowratemax`,`ket`) values (1,1,2,1,6500,62,1,8,1,'Discharge, Back Loading',NULL,12,NULL,'as'),(2,1,1,1,6500,62,2,8,1,'asas',NULL,12,NULL,'as'),(3,1,1,2,17000,92,1,10,1,'Dis',NULL,19,NULL,'a'),(4,1,2,2,17000,92,1,10,1,'as',NULL,17,NULL,' '),(5,2,1,1,10000,0,1,8,3,' ',NULL,12,NULL,' '),(6,2,2,1,10000,1,1,1,3,' ',NULL,12,NULL,' '),(7,2,1,2,3000,89,1,6,3,' ',NULL,12,NULL,' '),(8,2,2,2,3000,1,1,1,3,' ',NULL,12,NULL,' '),(9,4,1,1,6500,50,1,1,3,' ',NULL,12,NULL,' '),(10,4,2,1,6500,1,1,8,3,' ',NULL,12,NULL,' ');

/*Table structure for table `detailshipment` */

DROP TABLE IF EXISTS `detailshipment`;

CREATE TABLE `detailshipment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idshipment` int(11) DEFAULT NULL,
  `idproduk` int(11) DEFAULT NULL,
  `jumlah` int(11) DEFAULT NULL,
  `idsatuan` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_detailshipment` (`idproduk`),
  KEY `FK_detailshipment1` (`idsatuan`),
  CONSTRAINT `FK_detailshipment` FOREIGN KEY (`idproduk`) REFERENCES `produk` (`id`),
  CONSTRAINT `FK_detailshipment1` FOREIGN KEY (`idsatuan`) REFERENCES `listsatuan` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `detailshipment` */

insert  into `detailshipment`(`id`,`idshipment`,`idproduk`,`jumlah`,`idsatuan`) values (1,1,1,8000,1),(2,2,1,8000,1),(3,3,1,8000,1);

/*Table structure for table `estimasiwaktu` */

DROP TABLE IF EXISTS `estimasiwaktu`;

CREATE TABLE `estimasiwaktu` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idkapal` int(11) DEFAULT NULL,
  `idpelabuhan` int(11) DEFAULT NULL,
  `idlistket` int(11) DEFAULT NULL,
  `estimasiwaktu` time DEFAULT NULL,
  `status` enum('0','1') DEFAULT '1' COMMENT '0=ubah2 1=fixed',
  PRIMARY KEY (`id`),
  KEY `FK_estimasiwaktu` (`idlistket`),
  KEY `FK_estimasiwaktu1` (`idpelabuhan`),
  KEY `FK_estimasiwaktu2` (`idkapal`),
  CONSTRAINT `FK_estimasiwaktu` FOREIGN KEY (`idlistket`) REFERENCES `listketerangan` (`id`),
  CONSTRAINT `FK_estimasiwaktu1` FOREIGN KEY (`idpelabuhan`) REFERENCES `pelabuhan` (`id`),
  CONSTRAINT `FK_estimasiwaktu2` FOREIGN KEY (`idkapal`) REFERENCES `kapal` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `estimasiwaktu` */

insert  into `estimasiwaktu`(`id`,`idkapal`,`idpelabuhan`,`idlistket`,`estimasiwaktu`,`status`) values (1,1,1,1,'02:00:00','1'),(2,1,1,2,'01:00:00','1'),(3,1,1,3,'00:00:00','0'),(4,1,1,4,'02:00:00','1'),(5,1,1,5,'01:00:00','1'),(6,2,1,1,'02:00:00','1'),(7,2,1,2,'01:00:00','1');

/*Table structure for table `histstok` */

DROP TABLE IF EXISTS `histstok`;

CREATE TABLE `histstok` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tanggal` date DEFAULT NULL,
  `idproduk` int(11) DEFAULT NULL,
  `idpelabuhan` int(11) DEFAULT NULL,
  `pumpable` int(11) DEFAULT NULL,
  `deadstok` int(11) DEFAULT NULL,
  `safestok` int(11) DEFAULT NULL,
  `dot` int(11) DEFAULT NULL,
  `mutasi` int(11) DEFAULT NULL,
  `ullage` int(11) DEFAULT NULL,
  `rencanadischarge` int(11) DEFAULT NULL,
  `waitingullagevolume` int(11) DEFAULT NULL,
  `waitingullageday` int(11) DEFAULT NULL,
  `rencanaloading` int(11) DEFAULT NULL,
  `minimunstok` int(11) DEFAULT NULL COMMENT 'loading*3',
  `waitingcargovolume` int(11) DEFAULT NULL,
  `waitingcargoday` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `histstok` */

/*Table structure for table `kapal` */

DROP TABLE IF EXISTS `kapal`;

CREATE TABLE `kapal` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nama` varchar(100) DEFAULT NULL,
  `idtipe` int(11) DEFAULT NULL,
  `kapasitas` int(11) DEFAULT NULL,
  `satuankapasitas` int(11) DEFAULT NULL,
  `flowrate` int(11) DEFAULT NULL,
  `satuanflowrate` int(11) DEFAULT NULL,
  `jenisangkut` enum('0','1','2') DEFAULT '0' COMMENT '0=cair 1=lpg 2=cair dan lpg',
  PRIMARY KEY (`id`),
  KEY `FK_kapal` (`idtipe`),
  CONSTRAINT `FK_kapal` FOREIGN KEY (`idtipe`) REFERENCES `listtipekapal` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=latin1;

/*Data for the table `kapal` */

insert  into `kapal`(`id`,`nama`,`idtipe`,`kapasitas`,`satuankapasitas`,`flowrate`,`satuanflowrate`,`jenisangkut`) values (1,'SPOB. Jelita Nadia',1,3000,1,200,NULL,'0'),(2,'MT. Stephanie XVIII',1,3000,1,200,NULL,'0'),(3,'MT. Satria Satu   ',1,3000,1,200,NULL,'0'),(4,'OB. Patra 2304 – TB Patra 1204 ',1,3000,1,200,NULL,'1'),(5,'MT. Almira XXII      ',5,1600,1,200,1,'0'),(6,'MT. IRIANI',5,NULL,1,200,NULL,'0'),(7,'MT. PETRO MARINE 2200',5,NULL,1,200,NULL,'0'),(8,'OB. FLAMINGGO 9',2,NULL,1,200,NULL,'0'),(9,'OB. FLAMINGO 8',2,NULL,1,200,NULL,'0'),(10,'OB. OSCO PETRO V',1,NULL,1,200,NULL,'0'),(11,'OB. SEJAHTERA 2016',2,NULL,1,200,NULL,'0'),(12,'OB. SENTANA AGRO',2,NULL,1,200,NULL,'0'),(13,'OB. SENTANA MULIA',2,NULL,1,200,NULL,'0'),(14,'MT. MATINDOK',1,NULL,1,200,NULL,'0'),(15,'SRIKANDI',3,NULL,1,200,NULL,'0'),(16,'SPOB. CITRA S 4001',4,NULL,1,200,NULL,'0'),(17,'MT. MARGARET XI',1,NULL,NULL,200,NULL,'0'),(18,'SHINTA',2,NULL,1,200,NULL,'0'),(19,'MT. BAHARI MAJU I',1,NULL,1,200,NULL,'0'),(20,'Kapal 1',1,4000,1,200,1,'0'),(21,'MT. PEGADEN',8,16000,0,500,0,'0'),(22,'MT. PANGKALAN BRANDAN',8,16000,0,500,0,'0'),(23,'MT. PUNGUT',8,16000,0,300,0,'0'),(24,'MT. BRO COMBO',8,16000,0,500,0,'0'),(25,'MT. GAS KALIMANTAN',5,1700,0,200,0,'1'),(26,'MT. JOHN CAINE',8,16000,0,500,0,'0'),(27,'MT. PALUH TABUHAN',8,16000,0,300,0,'0');

/*Table structure for table `listjetty` */

DROP TABLE IF EXISTS `listjetty`;

CREATE TABLE `listjetty` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nama` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `listjetty` */

insert  into `listjetty`(`id`,`nama`) values (1,'Jetty 1'),(2,'Jetty 2'),(3,'Jetty 3');

/*Table structure for table `listketerangan` */

DROP TABLE IF EXISTS `listketerangan`;

CREATE TABLE `listketerangan` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nama` varchar(60) DEFAULT NULL,
  `status` enum('0','1') DEFAULT '1' COMMENT '0=fluktuatif 1=fixed',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Data for the table `listketerangan` */

insert  into `listketerangan`(`id`,`nama`,`status`) values (1,'Arrival - Berthed','1'),(2,'Berthed - Comm(Load/Discharge)','1'),(3,'Comm(Load/Discharge) - Comp(Load/Discharge)','0'),(4,'Comp(Load/Discharge) - Unberthed','1'),(5,'Unberthed - Departure','1'),(6,'Departure - Tide','1');

/*Table structure for table `listsatuan` */

DROP TABLE IF EXISTS `listsatuan`;

CREATE TABLE `listsatuan` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nama` varchar(50) DEFAULT NULL,
  `simbol` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `listsatuan` */

insert  into `listsatuan`(`id`,`nama`,`simbol`) values (1,'KiloLiter','KL'),(2,'Liter','L'),(3,'Centimeter','Cm'),(4,'Kilogram','Kg'),(5,'Matrik Ton','MT');

/*Table structure for table `liststatus` */

DROP TABLE IF EXISTS `liststatus`;

CREATE TABLE `liststatus` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nama` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `liststatus` */

insert  into `liststatus`(`id`,`nama`) values (1,'ON SCHEDULE'),(2,'DEVIATION'),(3,'MOVE TO PORT ACTIVITY');

/*Table structure for table `listtipekapal` */

DROP TABLE IF EXISTS `listtipekapal`;

CREATE TABLE `listtipekapal` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nama` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

/*Data for the table `listtipekapal` */

insert  into `listtipekapal`(`id`,`nama`) values (1,'OB 1'),(2,'OB 2'),(3,'SPOB 3'),(4,'SPOB 2'),(5,'Bulk Lighter'),(6,'Small 1'),(7,'Small 2'),(8,'GP'),(9,'GP dari Plaju');

/*Table structure for table `listwaiting` */

DROP TABLE IF EXISTS `listwaiting`;

CREATE TABLE `listwaiting` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nama` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

/*Data for the table `listwaiting` */

insert  into `listwaiting`(`id`,`nama`) values (1,'WAITING PREPARATION'),(2,'WAITING JETTY'),(3,'WAITTING ULLAGE'),(4,'WAITTING TIDE'),(5,'WAITING PILOT'),(6,'WAITING SHIP UNREADY'),(7,'WAITING CARGO'),(8,'WAITING CARGO DOCUMENT'),(9,'WAITING WEATHER'),(10,'WAITING SHIP DOCUMENT'),(11,'STANDARD TIME'),(12,'WAITING CALCULATION'),(13,'WAITING DONE');

/*Table structure for table `pelabuhan` */

DROP TABLE IF EXISTS `pelabuhan`;

CREATE TABLE `pelabuhan` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `kode` varchar(10) DEFAULT NULL,
  `nama` varchar(100) DEFAULT NULL,
  `jenisproduk` enum('0','1','2') DEFAULT '0' COMMENT '0=cair 1=LPG 2=semua',
  `baseline` time DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

/*Data for the table `pelabuhan` */

insert  into `pelabuhan`(`id`,`kode`,`nama`,`jenisproduk`,`baseline`) values (1,'F123','Panjang','0','64:00:00'),(2,'F126','Jambi','0','105:00:00'),(3,'F127','Pangkal Balam','0','81:00:00'),(4,'F129','Pulau Baai','0','50:00:00'),(5,NULL,'TG. GEREM','0',NULL),(6,NULL,'TL. KABUNG','0',NULL),(7,NULL,'OTM','0',NULL),(8,NULL,'TG UBAN','0',NULL),(9,NULL,'Sambu','0',NULL),(10,NULL,'Kertapati','0','70:00:00'),(11,'R301','Plaju','0','90:00:00'),(12,'','TELUK SEMANGKA','0','00:00:00');

/*Table structure for table `produk` */

DROP TABLE IF EXISTS `produk`;

CREATE TABLE `produk` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nama` varchar(40) DEFAULT NULL,
  `jenis` enum('0','1') DEFAULT '0' COMMENT '0=cair 1=lpg',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

/*Data for the table `produk` */

insert  into `produk`(`id`,`nama`,`jenis`) values (1,'PREMIUM','0'),(2,'PERTAMAX','0'),(3,'SOLAR','0'),(4,'PERTAMINA DEX','0'),(5,'PERTAMAX TURBO','0'),(6,'MFO','0'),(7,'FAME','0'),(8,'LPG','1'),(9,'Produk A','1');

/*Table structure for table `rute` */

DROP TABLE IF EXISTS `rute`;

CREATE TABLE `rute` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idkapal` int(11) DEFAULT NULL,
  `idasal` int(11) DEFAULT NULL COMMENT 'idpelabuhan asal kapal',
  `idtujuan` int(11) DEFAULT NULL COMMENT 'idpelabuahan tujuan kapal',
  `seatime` time DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_rute` (`idkapal`),
  CONSTRAINT `FK_rute` FOREIGN KEY (`idkapal`) REFERENCES `kapal` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=latin1;

/*Data for the table `rute` */

insert  into `rute`(`id`,`idkapal`,`idasal`,`idtujuan`,`seatime`) values (1,1,4,1,'29:00:00'),(2,1,4,5,'32:00:00'),(3,1,4,6,'12:00:00'),(4,2,4,1,'29:00:00'),(5,2,4,5,'32:00:00'),(6,2,4,6,'12:00:00'),(7,3,4,1,'29:00:00'),(8,3,4,5,'32:00:00'),(9,3,4,6,'12:00:00'),(10,4,4,1,'29:00:00'),(11,4,4,5,'32:00:00'),(12,4,4,6,'12:00:00'),(13,5,4,1,'29:00:00'),(15,5,4,6,'12:00:00'),(16,2,1,3,'48:00:00'),(17,2,3,5,'48:00:00'),(18,2,3,7,'48:00:00'),(19,2,3,8,'96:00:00'),(20,2,3,9,'96:00:00'),(21,2,4,5,'48:00:00'),(22,2,4,7,'48:00:00'),(23,5,4,6,'30:00:00'),(24,1,2,1,'30:00:00'),(25,2,2,1,'30:00:00'),(26,3,2,1,'30:00:00'),(27,1,6,1,'96:00:00'),(28,1,3,1,'24:00:00'),(29,2,9,1,'20:00:00'),(30,1,9,1,'30:00:00'),(31,5,1,3,'48:00:00'),(32,5,3,1,'48:00:00'),(33,5,1,4,'29:00:00'),(34,5,4,5,'32:00:00'),(35,5,6,4,'12:00:00'),(36,5,5,4,'32:00:00'),(37,6,11,3,'36:00:00'),(38,17,5,1,'06:00:00'),(39,26,7,1,'00:00:07'),(40,25,12,1,'00:00:06'),(41,21,7,1,'00:00:07'),(42,1,1,3,'00:00:48');

/*Table structure for table `sandarjetty` */

DROP TABLE IF EXISTS `sandarjetty`;

CREATE TABLE `sandarjetty` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idjetty` int(11) DEFAULT NULL,
  `idkapal` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_sandarjetty` (`idjetty`),
  KEY `FK_sandarjetty1` (`idkapal`),
  CONSTRAINT `FK_sandarjetty` FOREIGN KEY (`idjetty`) REFERENCES `listjetty` (`id`),
  CONSTRAINT `FK_sandarjetty1` FOREIGN KEY (`idkapal`) REFERENCES `kapal` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `sandarjetty` */

insert  into `sandarjetty`(`id`,`idjetty`,`idkapal`) values (1,1,2),(2,1,6);

/*Table structure for table `shipment` */

DROP TABLE IF EXISTS `shipment`;

CREATE TABLE `shipment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `noshipment` varchar(40) DEFAULT NULL,
  `idkapal` int(11) DEFAULT NULL,
  `idasal` int(11) DEFAULT NULL,
  `idtujuan` int(11) DEFAULT NULL,
  `proses` enum('0','1') DEFAULT NULL COMMENT '0=loading 1=discharge',
  `arrival` datetime DEFAULT NULL COMMENT 'waktu kedatangan kapal',
  `berthed` datetime DEFAULT NULL COMMENT 'waktu kapal sandar',
  `comm` datetime DEFAULT NULL COMMENT 'waktu kapal mulai muat/bongkat kargo',
  `comp` datetime DEFAULT NULL COMMENT 'waktu kapal selesai bongkar/muat kargo',
  `unberthed` datetime DEFAULT NULL COMMENT 'waktu kapal angkar jangkar',
  `departure` datetime DEFAULT NULL COMMENT 'waktu kapal berangkat',
  `waiting1` int(11) DEFAULT NULL,
  `waiting2` int(11) DEFAULT NULL,
  `waiting3` int(11) DEFAULT NULL,
  `waiting4` int(11) DEFAULT NULL,
  `waiting5` int(11) DEFAULT NULL,
  `status` enum('proses','done','simulasi') DEFAULT 'simulasi' COMMENT '0=proses 1=done',
  `antrian` int(1) DEFAULT NULL,
  `idjetty` int(1) DEFAULT NULL,
  `idbantuan` int(11) DEFAULT NULL,
  `prosesbantuan` enum('0','1') DEFAULT NULL COMMENT '0=asal 1=tujuan',
  `status_lihat` enum('0','1') NOT NULL DEFAULT '0',
  `idpelabuhanbantuan` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_shipment` (`idkapal`),
  CONSTRAINT `FK_shipment` FOREIGN KEY (`idkapal`) REFERENCES `kapal` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `shipment` */

insert  into `shipment`(`id`,`noshipment`,`idkapal`,`idasal`,`idtujuan`,`proses`,`arrival`,`berthed`,`comm`,`comp`,`unberthed`,`departure`,`waiting1`,`waiting2`,`waiting3`,`waiting4`,`waiting5`,`status`,`antrian`,`idjetty`,`idbantuan`,`prosesbantuan`,`status_lihat`,`idpelabuhanbantuan`) values (1,NULL,1,1,3,'0','2018-11-14 20:29:43','2018-11-16 19:29:43','2018-11-16 20:29:43','2018-11-18 12:29:43','2018-11-18 14:29:43','2018-11-18 15:29:43',NULL,NULL,NULL,NULL,NULL,'simulasi',2,1,1,'0','0',1),(2,NULL,1,1,3,'0','2018-11-19 15:29:43','2018-11-19 17:29:43','2018-11-19 18:29:43','2018-11-21 10:29:43','2018-11-21 12:29:43','2018-11-21 13:29:43',NULL,NULL,NULL,NULL,NULL,'simulasi',1,1,1,'1','0',3),(3,NULL,2,12,1,'1','2018-11-14 20:30:06','2018-11-14 22:30:06','2018-11-14 23:30:06','2018-11-16 15:30:06','2018-11-16 17:30:06','2018-11-16 18:30:06',NULL,NULL,NULL,NULL,NULL,'simulasi',1,1,3,NULL,'0',1);

/*Table structure for table `stok` */

DROP TABLE IF EXISTS `stok`;

CREATE TABLE `stok` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idpelabuhan` int(11) DEFAULT NULL,
  `idproduk` int(11) DEFAULT NULL,
  `pumpable` int(11) DEFAULT NULL,
  `dot` int(11) DEFAULT NULL,
  `safestok` int(11) DEFAULT NULL,
  `deadstok` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

/*Data for the table `stok` */

insert  into `stok`(`id`,`idpelabuhan`,`idproduk`,`pumpable`,`dot`,`safestok`,`deadstok`) values (1,1,1,3355,1106,23765,3630),(2,1,2,544,863,28131,1948),(3,1,4,809,34,2471,178),(4,1,3,4614,1797,28131,1948),(5,2,1,2000,773,4632,143),(6,3,1,2000,495,3068,144),(7,4,1,2000,333,3920,266),(8,2,3,6000,1130,7151,344),(9,3,3,8000,821,10131,289),(10,4,3,7000,415,7516,280);

/*Table structure for table `tb_chat` */

DROP TABLE IF EXISTS `tb_chat`;

CREATE TABLE `tb_chat` (
  `id_chat` int(11) NOT NULL AUTO_INCREMENT,
  `id_user` varchar(255) DEFAULT NULL,
  `tanggal` varchar(255) DEFAULT NULL,
  `isi_chat` text,
  `status` enum('read','unread') DEFAULT 'unread',
  PRIMARY KEY (`id_chat`)
) ENGINE=InnoDB AUTO_INCREMENT=105 DEFAULT CHARSET=latin1;

/*Data for the table `tb_chat` */

insert  into `tb_chat`(`id_chat`,`id_user`,`tanggal`,`isi_chat`,`status`) values (1,'pertamina','2018-11-01 09:39:40','ddd','unread'),(2,'pertamina','2018-11-01 09:39:45','test','unread'),(3,'pertamina','2018-11-01 09:41:18','iaka','unread'),(4,'pertamina','2018-11-01 09:41:19','','unread'),(5,'pertamina','2018-11-01 09:47:58','tes','unread'),(6,'pertamina','2018-11-01 09:48:01','ya','unread'),(7,'pertamina','2018-11-01 09:48:32','','unread'),(8,'pertamina','2018-11-01 09:48:41','','unread'),(9,'pertamina','2018-11-01 09:49:06','test','unread'),(10,'pertamina','2018-11-01 09:49:13','test lagi','unread'),(11,'pertamina','2018-11-01 09:49:27','test lagi ya','unread'),(12,'pertamina','2018-11-01 09:49:28','test lagi ya','unread'),(13,'pertamina','2018-11-01 09:49:34','test lagi ya','unread'),(14,'pertamina','2018-11-01 09:49:35','test lagi ya','unread'),(15,'pertamina','2018-11-01 09:49:35','test lagi ya','unread'),(16,'pertamina','2018-11-01 09:50:17','ok','unread'),(17,'pertamina','2018-11-01 09:50:38','ya','unread'),(18,'pertamina','2018-11-01 09:50:49','d','unread'),(19,'pertamina','2018-11-01 09:50:50','d','unread'),(20,'pertamina','2018-11-01 09:51:08','d','unread'),(21,'pertamina','2018-11-01 09:51:56','yu','unread'),(22,'pertamina','2018-11-01 09:52:04','mas adam','unread'),(23,'pertamina','2018-11-01 09:52:58','ddd','unread'),(24,'pertamina','2018-11-01 09:53:20','ega','unread'),(25,'pertamina','2018-11-01 09:53:28','ya ta','unread'),(26,'pertamina','2018-11-01 09:53:46','ini mas','unread'),(27,'pertamina','2018-11-01 09:55:03','mas arief','unread'),(28,'pertamina','2018-11-01 09:55:13','tes lagi','unread'),(29,'pertamina','2018-11-01 09:56:15','ridho','unread'),(30,'pertamina','2018-11-01 09:56:27','danzen','unread'),(31,'pertamina','2018-11-01 09:56:45','test lagi','unread'),(32,'pertamina','2018-11-03 06:55:37','Saat ini telah melebihi Time Berthed untuk kapal SPOB. Jelita Nadia from Pangkal Balam','unread'),(33,'pertamina','2018-11-03 07:00:50','Saat ini telah melebihi Time Berthed untuk kapal SPOB. Jelita Nadia from Pangkal Balam','unread'),(34,'pertamina','2018-11-03 07:05:50','Saat ini telah melebihi Time Berthed untuk kapal SPOB. Jelita Nadia from Pangkal Balam','unread'),(35,'pertamina','2018-11-03 07:18:41','Saat ini telah melebihi Time Berthed untuk kapal SPOB. Jelita Nadia from Pangkal Balam','unread'),(36,'pertamina','2018-11-03 07:24:32','Saat ini telah melebihi Time Berthed untuk kapal SPOB. Jelita Nadia from Pangkal Balam','unread'),(37,'pertamina','2018-11-03 07:29:32','Saat ini telah melebihi Time Berthed untuk kapal SPOB. Jelita Nadia from Pangkal Balam','unread'),(38,'pertamina','2018-11-03 07:34:32','Saat ini telah melebihi Time Berthed untuk kapal SPOB. Jelita Nadia from Pangkal Balam','unread'),(39,'pertamina','2018-11-03 07:39:32','Saat ini telah melebihi Time Berthed untuk kapal SPOB. Jelita Nadia from Pangkal Balam','unread'),(40,'pertamina','2018-11-03 07:44:32','Saat ini telah melebihi Time Berthed untuk kapal SPOB. Jelita Nadia from Pangkal Balam','unread'),(41,'plannerlpg','2018-11-03 11:44:26','ega','unread'),(42,'','2018-11-03 12:41:53','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 03/11/18 18:25','unread'),(43,'','2018-11-03 12:41:58','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 03/11/18 18:25','unread'),(44,'','2018-11-03 12:42:03','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 03/11/18 18:25','unread'),(45,'','2018-11-03 12:42:08','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 03/11/18 18:25','unread'),(46,'','2018-11-03 12:42:13','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 03/11/18 18:25','unread'),(47,'','2018-11-03 12:42:18','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 03/11/18 18:25','unread'),(48,'','2018-11-03 12:42:23','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 03/11/18 18:25','unread'),(49,'','2018-11-03 12:42:28','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 03/11/18 18:25','unread'),(50,'','2018-11-03 12:42:33','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 03/11/18 18:25','unread'),(51,'','2018-11-03 12:42:38','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 03/11/18 18:25','unread'),(52,'','2018-11-03 12:42:43','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 03/11/18 18:25','unread'),(53,'plannerminyak','2018-11-04 11:37:33','tesss','unread'),(54,'Lmpanjang','2018-11-04 12:02:58','Hallo','unread'),(55,'yudhiirawan','2018-11-04 12:12:22','tes','unread'),(56,'Lmpanjang','2018-11-04 12:35:11','Halo2','unread'),(57,'Lmpanjang','2018-11-04 12:35:22','Yudi online dak','unread'),(58,'Lmpanjang','2018-11-04 13:05:54','Panjang online ','unread'),(59,'Yudhiirawan','2018-11-04 13:06:03','Fatah.. tes','unread'),(60,'Lmpanjang','2018-11-04 13:06:17','Yoo masuk mas','unread'),(61,'Yudhiirawan','2018-11-04 13:07:59','Nanti setelah bisa msk kita input pergerakan kapal terupdate y','unread'),(62,'Lmpanjang','2018-11-04 13:08:42','Oke dimonitor ','unread'),(63,'Ohpanjang','2018-11-04 13:16:04','Tes','unread'),(64,'Lmbangka','2018-11-04 13:33:48','Tes mas fatah','unread'),(65,'Yudhiirawan','2018-11-04 13:44:43','Fatah cobah cek dipanjang','unread'),(66,'Lmpanjang','2018-11-04 13:56:43','Port schedule msh kosong ','unread'),(67,'Lmpanjang','2018-11-04 13:57:12','','unread'),(68,'Lmpanjang','2018-11-04 14:04:57','Patah online gak','unread'),(69,'Lmpanjang','2018-11-04 14:05:32','Tes','unread'),(70,'Lmpanjang','2018-11-04 14:07:04','Online ','unread'),(71,'Lmpanjang','2018-11-04 14:07:27','Proses jetty 1 ya','unread'),(72,'Lmpanjang','2018-11-04 14:50:28','Iy','unread'),(73,'Yudhiirawan','2018-11-04 15:05:56','Tes lmpanjang','unread'),(74,'Yudhiirawan','2018-11-04 15:07:06','Almira jadi loading apa ya fat','unread'),(75,'Yudhiirawan','2018-11-04 15:07:17','Ada dex juga kah','unread'),(76,'lmpanjang','2018-11-04 15:20:52','tes','unread'),(77,'lmpanjang','2018-11-04 15:21:12','sound','unread'),(78,'Yudhiirawan','2018-11-04 15:21:31','Sound','unread'),(79,'lmbangka','2018-11-04 15:37:56','tes','unread'),(80,'','2018-11-05 00:53:28','Limit Waktu Berthed MT. Almira XXII       melebihi 04/11/18 13:42','unread'),(81,'','2018-11-05 02:01:02','Limit Waktu Berthed MT. Almira XXII       melebihi 04/11/18 13:42','unread'),(82,'Yudhiirawan','2018-11-05 02:29:53','Kenapa nih','unread'),(83,'','2018-11-05 05:08:12','Limit Waktu Berthed MT. Almira XXII       melebihi 04/11/18 13:42','unread'),(84,'yudhiirawan','2018-11-05 05:46:23','halo apakah ada yg online','unread'),(85,'yudhiirawan','2018-11-05 05:46:39','mas kamal bisa kasih testimoni di aplikasi ini','unread'),(86,'lmpanjang','2018-11-05 08:19:45','tes','unread'),(87,'lmpanjang','2018-11-05 08:20:13','kapal stephani n jhon caine sdh sandar kah','unread'),(88,'lmpanjang','2018-11-05 08:20:35','halo','unread'),(89,'yudhiirawan','2018-11-05 08:22:04','tes','unread'),(90,'Lmpulaubaai','2018-11-05 10:35:46','Tes','unread'),(91,'yudhiirawan','2018-11-05 16:02:51','tes','unread'),(92,'Lmpanjang','2018-11-05 16:18:44','Halo om yudhi','unread'),(93,'yudhiirawan','2018-11-05 16:19:46','halo dek','unread'),(94,'plannerlpg','2018-11-05 18:08:25','halo pjg siapo msk malem','unread'),(95,'lmpanjang','2018-11-06 05:17:51','HALO2','unread'),(96,'yudhiirawan','2018-11-09 11:34:09','tes','unread'),(97,'lmpanjang','2018-11-09 12:08:38','tes','unread'),(98,'yudhiirawan','2018-11-09 12:14:06','halo2','unread'),(99,'lmpanjang','2018-11-09 12:26:28','tes','unread'),(100,'','2018-11-09 13:07:29','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 09/11/18 17:50','unread'),(101,'','2018-11-09 13:37:32','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 09/11/18 17:50','unread'),(102,'','2018-11-09 14:07:34','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 09/11/18 17:50','unread'),(103,'','2018-11-10 14:16:17','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 09/11/18 11:10','unread'),(104,'','2018-11-10 14:46:17','Limit Waktu Berthed SPOB. Jelita Nadia melebihi 09/11/18 11:10','unread');

/*Table structure for table `userlogin` */

DROP TABLE IF EXISTS `userlogin`;

CREATE TABLE `userlogin` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `namauser` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `akses` enum('planner minyak','planner lpg','planner','atasan','admin kapal','admin') DEFAULT NULL,
  `idpelabuhan` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

/*Data for the table `userlogin` */

insert  into `userlogin`(`id`,`namauser`,`password`,`akses`,`idpelabuhan`) values (2,'yudhiirawan','pertamina','planner minyak',1),(3,'kamalfuad','pertamina','planner minyak',1),(4,'ohpanjang','pertamina','atasan',1),(5,'admin','admin','admin',1),(6,'lmpanjang','pertamina','admin kapal',1),(7,'lmpulaubaai','pertamina','admin kapal',4),(8,'lmbangka','pertamina','admin kapal',3),(9,'plannerlpg','pertamina','planner lpg',1);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
