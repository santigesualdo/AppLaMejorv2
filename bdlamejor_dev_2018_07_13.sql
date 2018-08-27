-- MySQL dump 10.13  Distrib 5.7.21, for Win32 (AMD64)
--
-- Host: localhost    Database: bdlamejor_dev
-- ------------------------------------------------------
-- Server version	5.7.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `backup`
--

DROP TABLE IF EXISTS `backup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `backup` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(255) COLLATE latin1_spanish_ci DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `backup`
--

LOCK TABLES `backup` WRITE;
/*!40000 ALTER TABLE `backup` DISABLE KEYS */;
INSERT INTO `backup` VALUES (1,'bdlamejor_dev_2018_07_13.sql','2018-07-13 11:55:23');
/*!40000 ALTER TABLE `backup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `banco`
--

DROP TABLE IF EXISTS `banco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `banco` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `banco`
--

LOCK TABLES `banco` WRITE;
/*!40000 ALTER TABLE `banco` DISABLE KEYS */;
INSERT INTO `banco` VALUES (1,'Macro'),(2,'Santander'),(3,'Santa Fe'),(4,'Nación'),(5,'Cuenta Corriente');
/*!40000 ALTER TABLE `banco` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cliente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cod_cliente` varchar(4) NOT NULL,
  `razon_social` varchar(100) NOT NULL,
  `domicilio` varchar(50) NOT NULL,
  `localidad` varchar(30) NOT NULL,
  `civa` varchar(3) NOT NULL,
  `id_tipo_cliente` int(11) NOT NULL,
  `nombre_local` varchar(50) NOT NULL,
  `cuit` varchar(15) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `nombre_responsable` varchar(50) DEFAULT NULL,
  `fecha_desde` date DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_tipo_cliente` (`id_tipo_cliente`),
  CONSTRAINT `fk_tipo_cliente` FOREIGN KEY (`id_tipo_cliente`) REFERENCES `clientetipo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'ZR','JUAN CARLOS MARECO','BLAS PARERA 10290','SANTA FE','R.I',1,'J.M','3424274573','20-31669513-3','JUAN CARLOS MARECO','2017-11-22','2018-07-09 00:00:00',1),(2,'MR','MR.ZANUTIGH MARIANO GERMAN','BV. PELEGRINI 3065','SANTA FE','R.I',1,'SANTA ANA','3424463794','20-24995216-9','ZANUTIGH MARIANO GERMAN','2017-11-23',NULL,1),(3,'N','N.GUTIERREZ NERINA GUADALUPE','MARCIAL CANDIOTI 3285','SANTO TOME','R.I',1,'SUPER JUACO','342-156311029','30-71423952-6','GUTIERREZ NERINA GUADALUPE','2017-11-23',NULL,1),(4,'BOSS','BOSSA EDGARDO OMAR','PTE FRONDIZZI 245- ','SUNCHALES','R.I',1,' ','20-20320603-9','3493-498525','BOSSA EDGARDO OMAR','2017-11-23',NULL,1),(5,'E','HEINEN NORMA ESTELA','AUSTRIA Y RUTA 110','SAUCE VIEJO','R.I',1,'SAN CAYETANO','27-13708517-3','342-4995649','HEINEN NORMA ESTELA','2017-11-23',NULL,1),(6,'LP','LÓPEZ JESABEL GUADALUPE ','MARCO CANDIOTI 1.756','CANDIOTI','MON',1,'CARNES LÓPEZ','27-33468480-1','342-156988763','LÓPEZ JESABEL GUADALUPE','2017-11-23',NULL,1),(7,'ALL','ALLIONE ALBERTO ROQUE','RUTA 11 Km 427 S/N','CORONDA','MON',1,'CARNES ALLIONE','20-21650528-0','342-5023223','ALLIONE ALBERTO ROQUE','2017-11-23',NULL,1),(8,'M2','RANIERI MIGUEL ANTONIO','ZONA RURAL 0','MONTE VERA','R.I',1,'CARNES RANIERI','20-22763018-4','342-155210956','RAINERI MIGUEL ANTONIO','2017-11-23',NULL,1),(9,'GALL','CANALIS MARIA ROSA','TACUARI 8154','SANTA FE','R.I',1,'LA GALLEGA','27-05947629-2','342-469190/ 342-1569','CANALIS MARIA ROSA','2017-11-23',NULL,1),(10,'EZ','MUÑOZ MILENA BETIANA','FACUNDO ZUVIRIA 5724','SANTA FE','R.I',1,'CARNES ENRIQUEZ','27-37685347-6','342-155194480','MUÑOZ MILENA BETIANA','2017-11-23',NULL,1),(11,'RM','RM.ROMANO MARIO ALBERTO','PADRE QUIROGA 2350','SANTA FE','R.I',1,'CARNES ROMANO','342-155150517','20-17619634-4','ROMANO MARIO ALBERTO','2017-11-23',NULL,1),(12,'BL','BELLOMO MATIAS AUGUSTO','SANTIAGO DE CHILE 2.408','SANTA FE','R.I',1,'CARNES BELLOMO','20-27719403-2','342-154769177','BELLOMO MATIAS AUGUSTO','2017-11-23',NULL,1),(13,'CL','PISATTI CECILIA','','','',1,'CARNES PASATTI','342-155036481','','PISATTI CECILIA','2017-11-23','2018-01-19 00:00:00',1),(14,'AD','CARLOS','LAS FLORES','SANTA FE','MON',1,'CARLOS','-','-','CARLOS','2018-06-04','2018-07-09 00:00:00',1),(15,'JJ','JUAN','J','SANTA FE','CF',1,'JUAN','-','123','JUAN','2018-07-03','2018-07-09 00:00:00',1),(16,'GT','LA TROPA','','SANTA FE','MON',1,'','','','','2018-07-09',NULL,1),(17,'ML','MELANIA AGUILERA','ARISTÓBULO DEL VALLE 5301','SANTA FE','R.I',1,'','','4-560173','','2018-07-09',NULL,1),(18,'MZ','MARIANO GOMÉZ','RIVADAVIA 2692- ESPERANZA','SANTA FE','R.I',1,'EL PRESTIGIO','20-31016003-3','0343-5126233','','2018-07-09',NULL,1),(19,'JP','JP.JORGE PORTILLO','B° SAN LORENZO','SANTA FE','',1,'','342-155331122','','','2018-07-09',NULL,1),(20,'L','L.HÉCTOR OJEDA','AV. SANAT FE Y TT LOZA','SANTA FE','',1,'','','342-155391865','','2018-07-09',NULL,1),(21,'N2','N2','','','',1,'','','','','2018-07-09',NULL,1),(22,'TM','TATY.RAMÓN MIRANDA','','SANTA FE','',1,'','342-155027178','','','2018-07-09',NULL,1),(23,'RS','RS.LORENA SILVETTI','GORRITI 4942','','',1,'','342-154278991','','','2018-07-09',NULL,1),(24,'BS','BS.JULIO BURRELLA','B° SAN JOSÉ','','',1,'','342-154893335','','','2018-07-09',NULL,1),(25,'Z','Z.EDUARDO','GORRITI','SANTA FE','',1,'','342-155768368','','','2018-07-09',NULL,1),(26,'MX','MX.MAXIMILIANO ALBORNOZ','B° EL POZO','SANTA FE','',1,'','342-342-1559869','','','2018-07-09',NULL,1),(27,'AF','AF.CARNICERÍA LA MEJOR','AV. FREYRE 2899','SANTA FE','R.I',1,'LA MEJOR','342-4565357','20-33216689-2','AGUILERA DIEGO','2018-07-09',NULL,1),(28,'D','D.DIEGO COLMÁN','GUEMES','RECREO','',1,'','342-155504071','','','2018-07-09',NULL,1),(29,'DM','DM.DAMIAN','PADRE GENESIO Y MITRE','SANTA FE','',1,'','342-154226','','','2018-07-09',NULL,1),(30,'CA','CA.CACHO GAITAN','DON GUANELLA- B° LAS FLORES','SANTA FE','',1,'','342-154784897','','','2018-07-09',NULL,1),(31,'R','R.HUGO PAIVA','QUIROGA- RECREO','RECREO','',1,'','342-155097591','','','2018-07-09',NULL,1),(32,'JM','JOSÉ MAIDANA','GORRITI- ZN B° LOYOLA','SANTA FE','',1,'','','342-154423903','','2018-07-09',NULL,1),(33,'AL','MANUEL LÓPEZ','ALTO VERDE','SANTA FE','',1,'','','','','2018-07-09',NULL,1),(34,'LP 3','LP3.SUPER CHINO','MONTE VERA','SANTA FE','',1,'','','','','2018-07-09',NULL,1),(35,'LP 2','LÓPEZ CRISTÍAN','SAN MARTÍN 6249','MONTE VERA','',1,'','','342-156988763','','2018-07-09',NULL,1),(36,'LG','LUIS GONZLÉZ','','SANTA FE','',1,'','','342-154637415','','2018-07-09',NULL,1),(37,'NK','NK.NICOLÁS','NEUQUEN 6900','SANTA FE','',1,'','342-155277955','','','2018-07-09',NULL,1),(38,'DA 1',' DA 1 IVÁN','B° SAN LORENZO','SANTA FE','',1,'','342-4592850/ 15','','','2018-07-09',NULL,1),(39,'L 5','L5.FERNANDO \"EL TORO NEGRO\"','','SANTO TOME','',1,'','342-155510464','','','2018-07-09',NULL,1),(40,'LT','LA TERNURA','ARISTÓBULO DEL VALLE','SANTA FE','',1,'','','342-155150435','','2018-07-09',NULL,1),(41,'N 3','N3.MANUEL','SANTO TOMÉ','SANTA FE','',1,'','','','','2018-07-09',NULL,1),(42,'N 2','N2','SANTO TOMÉ','SANTA FE','',1,'','','','','2018-07-09',NULL,1),(43,'JU','JU.JULIO CONTE','12 DE INFANTERIA 4300','SANTA FE','',1,'','','','','2018-07-09',NULL,1),(44,'LP 4','LP 4','M. CANDIOTTI 1756','CANDIOTTI','',1,'','','','','2018-07-09',NULL,1),(45,'ED','ED.EDUARDO','CENTENARIO','SANTA FE','',1,'','','','','2018-07-09',NULL,1),(46,'PYC','MARIO PAN Y CALI','SAUCE VIEJO','SAUCE VIEJO','',1,'','','','','2018-07-09',NULL,1),(47,'ZR','ZR.JUAN CARLOS MARECO','AV. BLAS PARERA 10.290','SANTA FE','R.I',1,'','342-154274573','20-31669513-3','','2018-07-09',NULL,1),(48,'AD','AD. CARLOS','12 DE INFANTERIA- B° LAS FLORES','SANTA FE','',1,'','','342-155675118','','2018-07-09',NULL,1),(49,'S','SILVIA ACOSTA','EVA PERÓN 3949','SANTA FE','RI',1,'-','342-154327131','-','-','2018-07-09',NULL,1);
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientecuenta`
--

DROP TABLE IF EXISTS `clientecuenta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clientecuenta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cbu` varchar(40) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `id_cliente` int(11) DEFAULT NULL,
  `fecha_updated` datetime DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  `id_banco` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_banco` (`id_banco`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientecuenta`
--

LOCK TABLES `clientecuenta` WRITE;
/*!40000 ALTER TABLE `clientecuenta` DISABLE KEYS */;
INSERT INTO `clientecuenta` VALUES (1,'-','EFECTIVO',1,NULL,1,NULL,5),(2,'-','EFECTIVO',2,NULL,1,NULL,5),(3,'-','EFECTIVO',3,NULL,1,NULL,5),(4,'-','EFECTIVO',4,NULL,1,NULL,5),(5,'-','EFECTIVO',5,NULL,1,NULL,5),(6,'-','EFECTIVO',6,NULL,1,NULL,5),(7,'-','EFECTIVO',7,NULL,1,NULL,5),(8,'-','EFECTIVO',8,NULL,1,NULL,5),(9,'-','EFECTIVO',9,NULL,1,NULL,5),(10,'-','EFECTIVO',10,NULL,1,NULL,5),(11,'-','EFECTIVO',11,NULL,1,NULL,5),(12,'-','EFECTIVO',12,NULL,1,NULL,5),(13,'-','EFECTIVO',13,NULL,1,NULL,5),(14,'-','EFECTIVO',14,'2018-06-04 10:50:50',1,NULL,5),(15,'EFECTIVO','EFECTIVO',15,'2018-07-03 09:46:40',1,NULL,5),(16,'1234','CHEQUE',15,'2018-07-06 18:33:32',1,NULL,1),(17,'-','CUENTA CORRIENTE',14,'2018-07-09 09:49:56',1,NULL,5),(18,'0000','CUENTA CORRIENTE',16,'2018-07-09 09:51:19',1,NULL,5),(19,'0000','CUENTA CORRIENTE',17,'2018-07-09 09:53:32',1,NULL,5),(20,'0000','CUENTA CORRIENTE',19,'2018-07-09 09:54:04',1,NULL,5),(21,'0000','CUENTA CORRIENTE',20,'2018-07-09 09:56:41',1,NULL,5),(22,'0000','CUENTA CORRIENTE',21,'2018-07-09 10:03:11',1,NULL,5),(23,'0000','CUENTA CORRIENTE',22,'2018-07-09 10:04:00',1,NULL,5),(24,'0000','CUENTA CORRIENTE',23,'2018-07-09 10:08:22',1,NULL,5),(25,'0000','CUENTA CORRIENTE',24,'2018-07-09 10:12:38',1,NULL,5),(26,'0000','CUENTA CORRIENTE',25,'2018-07-09 10:20:35',1,NULL,5),(27,'0000','CUENTA CORRIENTE',26,'2018-07-09 10:26:48',1,NULL,5),(28,'-','CUENTA CORRIENTE',27,'2018-07-09 10:27:55',1,NULL,5),(29,'0000','CUENTA CORRIENTE',28,'2018-07-09 10:30:21',1,NULL,5),(30,'0000','CUENTA CORRIENTE',29,'2018-07-09 10:38:19',1,NULL,5),(31,'0000','CUENTA CORRIENTE',30,'2018-07-09 10:39:01',1,NULL,5),(32,'0000','CUENTA CORRIENTE',31,'2018-07-09 10:39:58',1,NULL,5),(33,'0000','CUENTA CORRIENTE',32,'2018-07-09 10:41:07',1,NULL,5),(34,'0000','CUENTA CORRIENTE',33,'2018-07-09 10:43:12',1,NULL,5),(35,'0000','CUENTA CORRIENTE',34,'2018-07-09 10:43:45',1,NULL,5),(36,'0000','CUENTA CORRIENTE',35,'2018-07-09 10:44:38',1,NULL,5),(37,'0000','CUENTA CORRIENTE',36,'2018-07-09 10:45:10',1,NULL,5),(38,'0000','CUENTA CORRIENTE',37,'2018-07-09 10:46:15',1,NULL,5),(39,'0000','CUENTA CORRIENTE',38,'2018-07-09 10:47:04',1,NULL,5),(40,'0000','CUENTA CORRIENTE',39,'2018-07-09 10:54:53',1,NULL,5),(41,'0000','CUENTA CORRIENTE',40,'2018-07-09 10:56:36',1,NULL,5),(42,'0000','CUENTA CORRIENTE',43,'2018-07-09 11:27:21',1,NULL,5),(43,'0000','CUENTA CORRIENTE',44,'2018-07-09 11:28:13',1,NULL,5),(44,'0000','CUENTA CORRIENTE',45,'2018-07-09 11:28:49',1,NULL,5),(45,'0000','CUENTA CORRIENTE',46,'2018-07-09 11:29:42',1,NULL,5),(46,'0000','CHEQUE',47,'2018-07-09 11:39:07',1,NULL,2),(47,'0000','CUENTA CORRIENTE',48,'2018-07-09 11:40:12',1,NULL,5),(48,'0000','CUENTA CORRIENTE',49,'2018-07-09 12:00:02',1,NULL,5),(49,'0000','CUENTA CORRIENTE',41,'2018-07-09 12:54:28',1,NULL,5),(50,'0000','CUENTA CORRIENTE',41,'2018-07-09 12:55:05',1,NULL,5),(51,'0000','CUENTA CORRIENTE',20,'2018-07-10 08:14:10',1,NULL,5);
/*!40000 ALTER TABLE `clientecuenta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientecuentamovimiento`
--

DROP TABLE IF EXISTS `clientecuentamovimiento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clientecuentamovimiento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_operacion` int(11) DEFAULT NULL,
  `id_cuenta` int(11) NOT NULL,
  `id_movimiento_tipo` int(11) NOT NULL COMMENT '1 - DEBE| 2 - HABER',
  `monto` double NOT NULL,
  `fecha` datetime NOT NULL,
  `cobrado` char(1) NOT NULL DEFAULT 'N',
  `usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientecuentamovimiento`
--

LOCK TABLES `clientecuentamovimiento` WRITE;
/*!40000 ALTER TABLE `clientecuentamovimiento` DISABLE KEYS */;
INSERT INTO `clientecuentamovimiento` VALUES (1,1,59,2,2541,'2018-01-24 12:03:10','N',1),(2,1,59,1,2541,'2018-01-24 12:03:13','N',1),(3,0,65,1,123,'2018-01-25 09:21:45','N',1),(4,0,65,2,153,'2018-01-25 10:28:35','N',1),(6,0,65,2,88,'2018-01-25 10:32:50','N',1),(7,2,65,1,88,'2018-01-25 10:32:52','N',1),(8,3,65,2,1958,'2018-01-25 10:39:11','N',1),(9,3,65,1,1958,'2018-01-25 10:39:15','N',1),(10,4,65,2,1400,'2018-01-25 10:48:09','N',1),(11,4,65,1,1306,'2018-01-25 10:48:13','N',1),(12,5,65,2,3828,'2018-01-25 11:45:52','N',1),(13,5,65,1,3828,'2018-01-25 11:45:54','N',1),(14,6,53,2,13000,'2018-01-29 12:45:53','N',1),(15,6,53,1,12782,'2018-01-29 12:45:55','N',1),(16,7,64,2,1500,'2018-03-01 10:34:50','N',1),(17,7,64,1,1590,'2018-03-01 10:34:53','N',1),(18,8,65,2,2500,'2018-03-02 09:51:45','N',1),(19,8,65,1,2640,'2018-03-02 09:51:48','N',1),(20,9,60,2,90,'2018-03-02 10:13:54','N',1),(21,9,60,1,89,'2018-03-02 10:13:56','N',1),(22,10,56,2,80,'2018-03-02 10:41:14','N',1),(23,10,56,1,77,'2018-03-02 10:41:17','N',1),(24,11,54,2,5500,'2018-03-02 12:23:36','N',1),(25,11,54,1,5123,'2018-03-02 12:23:40','N',1),(26,12,53,2,16000,'2018-03-02 12:43:06','N',1),(27,12,56,2,30000,'2018-03-02 12:44:05','N',1),(28,12,56,1,35310,'2018-03-02 12:44:07','N',1),(29,13,64,2,90000,'2018-03-02 12:45:14','N',1),(30,13,59,2,7872,'2018-03-02 12:45:39','N',1),(31,13,59,1,7872,'2018-03-02 12:45:42','N',1),(32,14,65,2,88,'2018-03-02 13:05:34','N',1),(33,14,65,1,88,'2018-03-02 13:05:37','N',1),(34,15,0,1,4303,'2018-04-07 18:53:57','N',1),(35,16,0,1,169.5,'2018-04-13 20:11:47','N',1),(36,23,55,1,50,'2018-04-17 20:33:40','N',1),(37,24,55,2,50,'2018-04-17 20:34:13','N',1),(38,24,55,1,6000,'2018-04-17 20:49:19','N',1),(39,25,53,1,4850,'2018-04-21 22:56:39','N',1),(40,28,57,1,578.73,'2018-04-27 20:30:49','N',1),(41,30,55,1,2581.25,'2018-05-02 18:59:03','N',1),(42,31,60,1,5248,'2018-05-05 15:21:37','N',1),(43,34,53,1,258.36,'2018-05-05 16:23:21','N',1),(44,37,54,1,326.25,'2018-05-05 16:26:27','N',1),(45,38,48,1,8960,'2018-07-10 15:10:01','N',1),(46,39,6,1,2754,'2018-07-10 15:56:33','N',1);
/*!40000 ALTER TABLE `clientecuentamovimiento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientetipo`
--

DROP TABLE IF EXISTS `clientetipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clientetipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientetipo`
--

LOCK TABLES `clientetipo` WRITE;
/*!40000 ALTER TABLE `clientetipo` DISABLE KEYS */;
INSERT INTO `clientetipo` VALUES (1,'Mayorista'),(2,'Minorista');
/*!40000 ALTER TABLE `clientetipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `compra`
--

DROP TABLE IF EXISTS `compra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `compra` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_proveedor` int(11) DEFAULT NULL,
  `id_operacion` int(11) NOT NULL,
  `fecha` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `monto_total` decimal(10,3) NOT NULL,
  `monto_pagado` decimal(10,3) DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_prov` (`id_proveedor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compra`
--

LOCK TABLES `compra` WRITE;
/*!40000 ALTER TABLE `compra` DISABLE KEYS */;
/*!40000 ALTER TABLE `compra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `compradetalle`
--

DROP TABLE IF EXISTS `compradetalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `compradetalle` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_compra` int(11) NOT NULL,
  `id_garron` int(11) DEFAULT NULL,
  `id_producto` int(11) DEFAULT NULL,
  `monto` decimal(10,3) NOT NULL,
  `peso` decimal(10,3) NOT NULL,
  `peso_faltaentregar` decimal(10,3) NOT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_entrega` (`id_compra`),
  KEY `id_producto` (`id_producto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compradetalle`
--

LOCK TABLES `compradetalle` WRITE;
/*!40000 ALTER TABLE `compradetalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `compradetalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `compraestado`
--

DROP TABLE IF EXISTS `compraestado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `compraestado` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compraestado`
--

LOCK TABLES `compraestado` WRITE;
/*!40000 ALTER TABLE `compraestado` DISABLE KEYS */;
/*!40000 ALTER TABLE `compraestado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `garron`
--

DROP TABLE IF EXISTS `garron`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `garron` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `numero` varchar(5) DEFAULT NULL,
  `id_tipo_garron` int(11) DEFAULT NULL,
  `id_tipo_estado` int(11) DEFAULT NULL,
  `fecha_entrada` datetime DEFAULT NULL,
  `peso` decimal(10,3) DEFAULT NULL,
  `mes` varchar(2) DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  `observacion` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=73 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `garron`
--

LOCK TABLES `garron` WRITE;
/*!40000 ALTER TABLE `garron` DISABLE KEYS */;
INSERT INTO `garron` VALUES (1,'230',1,1,'2018-03-29 22:25:35',75.421,'10',1,NULL,NULL),(2,'231',1,2,'2018-03-29 22:25:35',76.496,'10',1,NULL,NULL),(3,'254',4,1,'2018-03-29 22:25:35',75.854,'11',1,NULL,NULL),(4,'745',1,1,'2018-03-29 22:25:35',78.520,'11',1,NULL,NULL),(5,'123',1,1,'2018-03-29 22:25:35',78.245,'11',1,NULL,NULL),(6,'66',1,1,'2018-03-29 22:25:35',98.245,'11',1,NULL,NULL),(7,'542',1,1,'2018-03-29 22:25:35',65.250,'11',1,NULL,NULL),(8,'321',1,1,'2018-03-29 22:25:35',88.250,'11',1,NULL,NULL),(9,'11',1,1,'2018-03-29 22:25:35',98.250,'11',1,NULL,NULL),(10,'111',1,1,'2018-03-29 22:25:35',78.525,'11',1,NULL,NULL),(11,'652',1,1,'2018-03-29 22:25:35',88.000,'12',1,NULL,NULL),(12,'111',1,1,'2018-03-29 22:25:35',11.000,'11',1,NULL,NULL),(13,'425',1,1,'2018-03-29 22:25:35',142.250,'11',1,NULL,NULL),(14,'458',1,1,'2018-03-29 22:25:35',14.256,'11',1,NULL,NULL),(15,'11',1,1,'2018-03-29 22:25:35',25.000,'3',1,NULL,NULL),(16,'222',1,1,'2018-03-29 22:25:35',256.000,'11',1,NULL,NULL),(17,'333',1,1,'2018-03-29 22:25:35',245.000,'12',1,NULL,NULL),(19,'22',1,1,'2018-01-25 19:38:55',200.000,'11',1,NULL,NULL),(20,'11',3,1,'2018-02-02 19:53:16',255.000,'1',1,NULL,NULL),(21,'222',1,1,'2018-03-08 09:06:36',124.000,'32',1,NULL,NULL),(22,'223',1,1,'2018-03-12 11:38:31',84.000,'11',1,NULL,NULL),(23,'223',1,1,'2018-03-12 11:38:31',84.000,'11',1,NULL,NULL),(24,'222',1,1,'2018-03-12 16:50:13',534.000,'11',1,NULL,NULL),(25,'558',2,1,'2018-03-17 11:08:13',624.000,'3',1,NULL,NULL),(26,'421',3,2,'2018-03-29 22:25:35',2.580,'4',1,NULL,NULL),(27,'333',6,2,'2018-03-17 11:18:04',13.470,'3',1,NULL,NULL),(28,'332',5,1,'2018-03-17 11:18:26',66.580,'2',1,'2018-05-05 16:26:27',NULL),(29,'342',1,1,'2018-03-19 17:32:45',234.000,'1',1,NULL,NULL),(30,'213',3,1,'2018-03-19 17:33:04',543.000,'11',1,'2018-04-27 20:30:28',NULL),(31,'12',6,2,'2018-03-19 17:33:29',34595.000,'12',1,NULL,NULL),(32,'22',2,1,'2018-03-19 19:06:00',147.250,'5',1,NULL,NULL),(33,'22',2,1,'2018-03-19 19:08:07',123.650,'22',1,NULL,NULL),(34,'22',1,1,'2018-03-19 19:11:28',44.254,'11',1,NULL,NULL),(35,'22',2,1,'2018-03-19 19:13:58',22.000,'22',1,NULL,NULL),(36,'123',1,2,'2018-03-29 22:25:35',2.000,'12',1,'2018-05-02 18:58:34',NULL),(37,'22',1,2,'2018-03-29 22:25:35',0.550,'12',1,NULL,NULL),(38,'22',1,2,'2018-03-19 19:55:00',0.000,'1',1,NULL,NULL),(39,'22',1,1,'2018-03-19 20:05:15',321.000,'23',1,NULL,NULL),(40,'11',3,1,'2018-03-19 20:24:00',12.000,'11',1,'2018-04-27 20:28:56',NULL),(41,'22',1,1,'2018-03-19 20:42:57',112.250,'11',1,NULL,NULL),(42,'22',1,1,'2018-03-19 20:47:26',11.000,'2',1,NULL,NULL),(43,'22',1,2,'2018-03-29 22:25:35',1.750,'11',1,NULL,NULL),(44,'22',2,2,'2018-03-29 22:25:35',-24.500,'1',1,NULL,NULL),(45,'22',1,1,'2018-03-19 21:48:44',254.000,'11',1,NULL,NULL),(46,'55',1,1,'2018-03-19 21:51:54',12.000,'2',1,NULL,NULL),(47,'22',1,1,'2018-03-19 22:27:57',55.000,'3',1,NULL,NULL),(48,'22',1,2,'2018-03-29 22:25:35',1.250,'1',1,NULL,NULL),(49,'22',3,1,'2018-03-19 22:36:03',12.000,'12',1,NULL,NULL),(50,'22',1,1,'2018-03-19 22:37:38',125.000,'11',1,NULL,NULL),(51,'22',1,1,'2018-03-19 22:40:38',22.000,'1',1,NULL,NULL),(52,'22',1,1,'2018-03-19 22:43:07',125.000,'11',1,NULL,NULL),(53,'22',1,1,'2018-03-19 22:45:57',1524.250,'1',1,NULL,NULL),(54,'22',1,1,'2018-03-19 22:48:37',22.000,'1',1,NULL,NULL),(55,'33',1,2,'2018-03-29 22:25:35',0.750,'1',1,NULL,NULL),(56,'22',1,1,'2018-03-19 22:53:36',1.000,'1',1,NULL,NULL),(57,'22',1,1,'2018-03-19 22:59:44',52.000,'11',1,NULL,NULL),(58,'12',2,1,'2018-03-19 23:02:59',11.000,'1',1,NULL,NULL),(59,'22',1,1,'2018-03-21 17:45:42',12.000,'1',1,NULL,NULL),(60,'2',1,1,'2018-03-21 17:59:46',11.000,'12',1,NULL,NULL),(61,'12',1,1,'2018-03-21 18:01:06',12.000,'1',1,NULL,NULL),(62,'1',1,2,'2018-03-21 18:03:07',77.000,'1',1,NULL,NULL),(63,'235',1,1,'2018-03-21 19:51:41',123.000,'3',1,NULL,''),(64,'236',3,1,'2018-03-21 19:51:53',123.000,'3',1,NULL,'incompleto'),(65,'237',5,2,'2018-03-29 22:25:35',191.640,'3',1,NULL,''),(66,'235',4,1,'2018-03-22 17:05:01',245.000,'11',1,'2018-05-05 16:23:21','garron recortado'),(67,'235',4,1,'2018-04-05 16:53:40',256.250,'11',1,NULL,''),(68,'236',3,1,'2018-04-05 16:54:12',122.000,'1',1,NULL,''),(69,'222',2,1,'2018-04-09 18:16:05',361.250,'11',1,NULL,''),(70,'333',1,1,'2018-04-09 18:16:22',233.000,'10',1,NULL,''),(71,'111',2,1,'2018-04-09 18:38:50',14.000,'11',1,'2018-05-05 15:21:37',''),(72,'2',3,1,'2018-04-09 19:08:39',112.000,'11',1,NULL,'');
/*!40000 ALTER TABLE `garron` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `garrondeposte`
--

DROP TABLE IF EXISTS `garrondeposte`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `garrondeposte` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_garron` int(11) NOT NULL,
  `id_producto` int(11) NOT NULL,
  `peso` decimal(10,3) NOT NULL,
  `fecha` datetime NOT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `garrondeposte`
--

LOCK TABLES `garrondeposte` WRITE;
/*!40000 ALTER TABLE `garrondeposte` DISABLE KEYS */;
INSERT INTO `garrondeposte` VALUES (1,2,6,10.256,'2018-03-29 20:33:39',NULL,NULL),(2,2,7,18.620,'2018-03-29 20:33:39',NULL,NULL),(3,2,8,20.680,'2018-03-29 20:33:39',NULL,NULL),(5,43,24,235.000,'2018-03-29 20:33:39',1,NULL),(7,26,14,18.000,'2018-03-29 20:33:39',1,NULL),(9,36,10,7.000,'2018-03-29 20:33:39',1,NULL),(11,44,7,0.500,'2018-03-29 20:33:39',1,NULL),(12,44,13,0.250,'2018-03-29 20:33:39',1,NULL),(14,44,7,0.500,'2018-03-29 20:33:39',1,NULL),(15,44,13,0.250,'2018-03-29 20:33:39',1,NULL),(16,37,6,0.200,'2018-03-29 20:33:39',1,NULL),(17,37,10,1.250,'2018-03-29 20:33:39',1,NULL),(18,65,15,125.000,'2018-03-29 20:45:35',1,NULL),(19,48,27,10.000,'2018-03-29 20:48:23',1,NULL),(20,55,4,2.000,'2018-03-29 20:53:09',1,NULL),(21,55,2,7.000,'2018-03-29 20:53:09',1,NULL),(22,55,4,1.500,'2018-03-29 22:23:37',1,NULL),(23,27,3,25.280,'2018-04-11 17:57:29',1,NULL),(24,27,10,28.250,'2018-04-11 17:57:29',1,NULL),(25,27,23,125.250,'2018-04-11 18:29:33',1,NULL),(26,37,2,5.000,'2018-04-13 20:02:03',1,NULL),(27,37,4,4.000,'2018-04-13 20:02:03',1,NULL),(28,65,1,25.360,'2018-04-13 20:08:07',1,NULL),(29,65,8,14.250,'2018-04-13 20:08:08',1,NULL),(30,27,4,20.360,'2018-04-13 20:09:31',1,NULL),(31,27,9,10.240,'2018-04-13 20:09:31',1,NULL),(32,38,5,5.360,'2018-04-13 20:11:31',1,NULL),(33,38,10,6.360,'2018-04-13 20:11:31',1,NULL),(34,62,23,48.000,'2018-04-17 20:35:56',1,NULL),(35,31,23,50.000,'2018-04-17 20:46:59',1,NULL),(36,38,26,0.280,'2018-04-17 20:54:25',1,NULL);
/*!40000 ALTER TABLE `garrondeposte` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `garronestado`
--

DROP TABLE IF EXISTS `garronestado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `garronestado` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `garronestado`
--

LOCK TABLES `garronestado` WRITE;
/*!40000 ALTER TABLE `garronestado` DISABLE KEYS */;
INSERT INTO `garronestado` VALUES (1,'COMPLETO'),(2,'DEPOSTE PARCIAL'),(3,'DEPOSTADO');
/*!40000 ALTER TABLE `garronestado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `garrontipo`
--

DROP TABLE IF EXISTS `garrontipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `garrontipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `garrontipo`
--

LOCK TABLES `garrontipo` WRITE;
/*!40000 ALTER TABLE `garrontipo` DISABLE KEYS */;
INSERT INTO `garrontipo` VALUES (1,'TERNERA'),(2,'NOVILLITO'),(3,'NOVILLO'),(4,'VAQUILLONA'),(5,'VACA'),(6,'TORO');
/*!40000 ALTER TABLE `garrontipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modulo`
--

DROP TABLE IF EXISTS `modulo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modulo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modulo`
--

LOCK TABLES `modulo` WRITE;
/*!40000 ALTER TABLE `modulo` DISABLE KEYS */;
INSERT INTO `modulo` VALUES (1,'Clientes'),(2,'Proveedores'),(3,'Caja'),(4,'Caja'),(5,'Ventas'),(6,'Carga Nueva Compra'),(7,'Movimiento Cuentas Clientes'),(8,'Gestion Usuarios'),(9,'Productos'),(10,'Carga Nueva Compra'),(11,'Movimiento Cuentas Proveedores'),(12,'Carga Garron'),(13,'Caja Mayorista'),(14,'Ubicacion de Productos'),(15,'Deposte'),(16,'Ubicacion'),(17,'Reportes'),(18,'Compras con Productos a Entregar'),(19,'Backups');
/*!40000 ALTER TABLE `modulo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movimientomercaderia`
--

DROP TABLE IF EXISTS `movimientomercaderia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `movimientomercaderia` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` datetime NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP,
  `id_ubicacion_origen` int(11) NOT NULL,
  `id_ubicacion_destino` int(11) NOT NULL,
  `peso` decimal(10,3) NOT NULL,
  `id_producto` int(11) DEFAULT NULL,
  `id_garron` int(11) DEFAULT NULL,
  `usuario` int(5) DEFAULT NULL,
  `fecha_baja` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=93 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movimientomercaderia`
--

LOCK TABLES `movimientomercaderia` WRITE;
/*!40000 ALTER TABLE `movimientomercaderia` DISABLE KEYS */;
INSERT INTO `movimientomercaderia` VALUES (1,'2018-03-26 18:34:13',1,2,20.000,5,NULL,1,NULL),(4,'2018-03-14 19:30:54',4,3,10.000,34,NULL,1,NULL),(5,'2018-03-14 19:31:00',4,3,10.000,34,NULL,1,NULL),(7,'2018-03-14 19:42:08',4,2,9.880,34,NULL,1,NULL),(8,'2018-03-14 19:42:13',4,2,9.880,34,NULL,1,NULL),(9,'2018-03-14 19:42:16',4,3,534.000,NULL,24,1,NULL),(11,'2018-03-14 19:42:54',4,2,9.880,34,NULL,1,NULL),(12,'2018-03-14 19:42:54',4,2,9.880,34,NULL,1,NULL),(13,'2018-03-14 19:42:54',4,3,534.000,NULL,24,1,NULL),(15,'2018-03-14 19:43:10',4,2,9.880,34,NULL,1,NULL),(16,'2018-03-14 19:43:12',4,2,9.880,34,NULL,1,NULL),(17,'2018-03-14 19:43:16',4,3,534.000,NULL,24,1,NULL),(19,'2018-03-14 19:43:55',4,2,9.880,34,NULL,1,NULL),(20,'2018-03-14 19:43:55',4,2,9.880,34,NULL,1,NULL),(21,'2018-03-14 19:43:55',4,3,534.000,NULL,24,1,NULL),(23,'2018-03-14 19:46:09',4,3,9.880,34,NULL,1,NULL),(24,'2018-03-14 19:46:09',4,3,9.880,34,NULL,1,NULL),(25,'2018-03-14 19:46:09',4,2,534.000,NULL,24,1,NULL),(27,'2018-03-14 19:48:38',4,2,9.880,34,NULL,1,NULL),(28,'2018-03-14 19:48:38',4,2,9.880,34,NULL,1,NULL),(29,'2018-03-15 19:28:36',4,3,9.800,34,NULL,1,NULL),(30,'2018-03-15 19:28:36',4,2,12.000,7,NULL,1,NULL),(31,'2018-03-15 19:28:36',4,3,534.000,NULL,24,1,NULL),(32,'2018-03-15 19:43:52',4,3,0.200,34,NULL,1,NULL),(33,'2018-03-15 19:46:39',4,3,0.200,34,NULL,1,NULL),(34,'2018-03-15 19:49:29',3,4,5.980,34,NULL,1,NULL),(35,'2018-03-15 19:50:26',3,4,5.980,34,NULL,1,NULL),(36,'2018-03-15 19:50:57',4,3,5.980,34,NULL,1,NULL),(37,'2018-03-15 19:52:58',4,2,15.800,9,NULL,1,NULL),(38,'2018-03-15 19:53:56',4,2,15.800,9,NULL,1,NULL),(39,'2018-03-15 20:08:17',2,4,15.800,9,NULL,1,NULL),(40,'2018-03-16 18:30:02',4,2,18.200,9,NULL,1,NULL),(41,'2018-03-16 18:30:31',4,2,18.200,9,NULL,1,NULL),(42,'2018-03-16 19:47:16',2,4,18.200,9,NULL,1,NULL),(43,'2018-03-16 19:48:39',4,2,18.200,9,NULL,1,NULL),(44,'2018-03-16 19:59:34',2,3,18.200,9,NULL,1,NULL),(45,'2018-03-16 20:00:20',3,4,0.480,9,NULL,1,NULL),(46,'2018-03-16 20:01:09',3,1,12.000,9,NULL,1,NULL),(47,'2018-03-16 20:02:20',3,1,5.720,9,NULL,1,NULL),(48,'2018-03-16 20:04:29',2,3,7.570,7,NULL,1,NULL),(49,'2018-03-16 20:43:04',4,1,14.600,9,NULL,1,NULL),(50,'2018-03-16 20:43:04',1,3,12.500,9,NULL,1,NULL),(51,'2018-03-16 20:43:04',4,2,84.000,NULL,23,1,NULL),(52,'2018-03-16 21:08:21',4,2,2.100,9,NULL,1,NULL),(53,'2018-03-16 21:08:21',4,3,3.820,9,NULL,1,NULL),(54,'2018-03-16 21:16:03',3,1,1.570,7,NULL,1,NULL),(55,'2018-03-16 21:16:03',3,2,2.500,7,NULL,1,NULL),(56,'2018-03-16 21:16:03',3,4,3.500,7,NULL,1,NULL),(57,'2018-03-16 21:16:20',3,4,534.000,NULL,24,1,NULL),(58,'2018-03-16 21:51:27',4,2,1.980,34,NULL,1,NULL),(59,'2018-03-16 21:51:27',4,3,2.400,34,NULL,1,NULL),(60,'2018-03-16 21:51:27',4,1,1.600,34,NULL,1,NULL),(61,'2018-03-17 12:37:26',4,2,66.580,NULL,28,1,NULL),(62,'2018-03-19 17:36:16',4,2,34645.000,NULL,31,1,NULL),(63,'2018-03-19 19:18:22',4,2,11.000,NULL,36,1,NULL),(64,'2018-03-19 19:33:47',4,2,11.000,NULL,37,1,NULL),(65,'2018-03-19 19:59:28',4,2,12.000,NULL,38,1,NULL),(66,'2018-03-19 22:39:12',4,1,52.000,6,NULL,1,NULL),(67,'2018-03-19 22:39:26',4,3,74.000,8,NULL,1,NULL),(68,'2018-03-19 22:41:15',4,3,22.000,9,NULL,1,NULL),(69,'2018-03-19 22:47:24',4,3,14.000,8,NULL,1,NULL),(70,'2018-03-19 22:47:32',4,1,154.000,10,NULL,1,NULL),(71,'2018-03-19 22:49:44',4,3,22.000,NULL,54,1,NULL),(72,'2018-03-19 23:04:06',4,1,52.000,16,NULL,1,NULL),(73,'2018-03-19 23:04:08',4,3,145.000,14,NULL,1,NULL),(74,'2018-03-21 18:04:12',4,3,25.000,34,NULL,1,NULL),(75,'2018-03-21 18:04:24',4,2,125.000,NULL,62,1,NULL),(76,'2018-03-21 19:58:57',4,1,24.000,21,NULL,1,NULL),(77,'2018-03-21 19:58:57',4,1,25.000,23,NULL,1,NULL),(78,'2018-03-21 19:58:57',4,3,123.000,NULL,63,1,NULL),(79,'2018-03-21 19:58:57',4,3,123.000,NULL,64,1,NULL),(80,'2018-03-21 19:58:57',4,2,356.250,NULL,65,1,NULL),(81,'2018-03-22 17:07:45',4,3,20.000,12,NULL,1,NULL),(82,'2018-03-22 17:07:45',4,2,245.000,NULL,66,1,NULL),(83,'2018-04-05 16:56:57',4,1,26.000,44,NULL,1,NULL),(84,'2018-04-05 16:57:03',4,3,29.630,49,NULL,1,NULL),(85,'2018-04-05 16:57:09',4,1,63.000,46,NULL,1,NULL),(86,'2018-04-05 16:57:12',4,3,256.250,NULL,67,1,NULL),(87,'2018-04-05 16:57:15',4,2,122.000,NULL,68,1,NULL),(88,'2018-04-05 17:01:04',2,1,1.200,9,NULL,1,NULL),(89,'2018-04-09 18:39:56',4,2,14.000,NULL,71,1,NULL),(90,'2018-04-10 17:45:27',1,2,2.000,2,NULL,1,NULL),(91,'2018-04-10 17:46:09',2,3,1.250,4,NULL,1,NULL),(92,'2018-04-24 23:28:10',4,2,13.000,44,NULL,1,NULL);
/*!40000 ALTER TABLE `movimientomercaderia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movimientotipo`
--

DROP TABLE IF EXISTS `movimientotipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `movimientotipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movimientotipo`
--

LOCK TABLES `movimientotipo` WRITE;
/*!40000 ALTER TABLE `movimientotipo` DISABLE KEYS */;
INSERT INTO `movimientotipo` VALUES (1,'DEBE'),(2,'PAGO');
/*!40000 ALTER TABLE `movimientotipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `operacion`
--

DROP TABLE IF EXISTS `operacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `operacion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Id_tipo_operacion` int(11) NOT NULL,
  `id_cliente` int(11) NOT NULL,
  `fecha` datetime DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_cl` (`id_cliente`),
  KEY `fk_to` (`Id_tipo_operacion`),
  CONSTRAINT `fk_to` FOREIGN KEY (`Id_tipo_operacion`) REFERENCES `operaciontipo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operacion`
--

LOCK TABLES `operacion` WRITE;
/*!40000 ALTER TABLE `operacion` DISABLE KEYS */;
INSERT INTO `operacion` VALUES (1,1,35,'2018-01-24 12:03:13',1),(2,1,41,'2018-01-25 10:32:52',1),(3,1,41,'2018-01-25 10:39:15',1),(4,1,41,'2018-01-25 10:48:13',1),(5,1,41,'2018-01-25 11:45:54',1),(6,1,29,'2018-01-29 12:45:55',1),(7,1,40,'2018-03-01 10:34:53',1),(8,1,41,'2018-03-02 09:51:48',1),(9,1,36,'2018-03-02 10:13:56',1),(10,1,32,'2018-03-02 10:41:17',1),(11,1,30,'2018-03-02 12:23:40',1),(12,1,32,'2018-03-02 12:44:07',1),(13,1,35,'2018-03-02 12:45:42',1),(14,1,41,'2018-03-02 13:05:37',1),(15,1,0,'2018-04-07 18:53:57',1),(16,1,0,'2018-04-13 20:11:46',1),(17,1,0,'2018-04-17 19:03:49',1),(18,1,0,'2018-04-17 19:10:57',1),(19,1,0,'2018-04-17 19:22:16',1),(20,1,0,'2018-04-17 19:28:41',1),(21,1,0,'2018-04-17 19:29:46',1),(22,1,31,'2018-04-17 20:31:27',1),(23,1,31,'2018-04-17 20:33:37',1),(24,1,31,'2018-04-17 20:49:19',1),(25,1,29,'2018-04-21 22:56:39',1),(26,1,36,'2018-04-27 20:27:16',1),(27,1,36,'2018-04-27 20:28:50',1),(28,1,33,'2018-04-27 20:30:24',1),(29,1,35,'2018-05-02 18:44:20',1),(30,1,31,'2018-05-02 18:57:44',1),(31,1,36,'2018-05-05 15:21:24',1),(32,1,30,'2018-05-05 16:19:17',1),(33,1,29,'2018-05-05 16:20:48',1),(34,1,29,'2018-05-05 16:22:57',1),(35,1,33,'2018-05-05 16:23:38',1),(36,1,31,'2018-05-05 16:24:40',1),(37,1,30,'2018-05-05 16:26:22',1),(38,1,49,'2018-07-10 15:10:01',1),(39,1,6,'2018-07-10 15:56:32',1);
/*!40000 ALTER TABLE `operacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `operacionproveedor`
--

DROP TABLE IF EXISTS `operacionproveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `operacionproveedor` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Id_tipo_operacion` int(11) NOT NULL,
  `id_proveedor` int(11) NOT NULL,
  `fecha` datetime DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_pl` (`id_proveedor`),
  KEY `fk_top` (`Id_tipo_operacion`),
  CONSTRAINT `fk_top` FOREIGN KEY (`Id_tipo_operacion`) REFERENCES `operaciontipo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operacionproveedor`
--

LOCK TABLES `operacionproveedor` WRITE;
/*!40000 ALTER TABLE `operacionproveedor` DISABLE KEYS */;
INSERT INTO `operacionproveedor` VALUES (4,3,1,'2018-04-08 22:37:58',1),(5,3,1,'2018-04-08 22:39:06',1),(6,3,1,'2018-04-09 18:08:23',1),(7,3,2,'2018-04-09 18:29:07',1),(8,3,2,'2018-04-09 18:39:42',1),(9,3,1,'2018-04-09 19:09:29',1),(10,3,1,'2018-04-19 17:59:27',1),(11,3,2,'2018-04-19 18:04:11',1);
/*!40000 ALTER TABLE `operacionproveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `operaciontipo`
--

DROP TABLE IF EXISTS `operaciontipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `operaciontipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operaciontipo`
--

LOCK TABLES `operaciontipo` WRITE;
/*!40000 ALTER TABLE `operaciontipo` DISABLE KEYS */;
INSERT INTO `operaciontipo` VALUES (1,'Venta mayorista'),(2,'Movimiento Cuenta'),(3,'Compra proveedor');
/*!40000 ALTER TABLE `operaciontipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parametros`
--

DROP TABLE IF EXISTS `parametros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parametros` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `value` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parametros`
--

LOCK TABLES `parametros` WRITE;
/*!40000 ALTER TABLE `parametros` DISABLE KEYS */;
INSERT INTO `parametros` VALUES (1,'QENDRA_PATH','C:\\Program Files (x86)\\SYSTEL\\Qendra.exe'),(2,'FILE_PRECIOS_SAVE','G:\\Escritorio\\balanza\\');
/*!40000 ALTER TABLE `parametros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `preciohistorico`
--

DROP TABLE IF EXISTS `preciohistorico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `preciohistorico` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_producto` int(11) NOT NULL,
  `desde` date NOT NULL,
  `hasta` date DEFAULT NULL,
  `precio` decimal(10,3) NOT NULL,
  `id_usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=187 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `preciohistorico`
--

LOCK TABLES `preciohistorico` WRITE;
/*!40000 ALTER TABLE `preciohistorico` DISABLE KEYS */;
INSERT INTO `preciohistorico` VALUES (1,5,'2017-10-23','2018-01-10',115.800,1,NULL),(2,6,'2017-10-23',NULL,85.900,1,NULL),(3,7,'2017-10-23','2018-01-10',28.500,1,NULL),(4,8,'2017-10-23','2018-01-10',115.000,1,NULL),(5,9,'2017-10-23','2018-01-10',98.000,1,NULL),(6,10,'2017-10-23',NULL,90.000,1,NULL),(7,11,'2017-10-23','2018-01-10',90.000,1,NULL),(8,12,'2017-10-23','2018-01-10',90.000,1,NULL),(9,13,'2017-10-23','2018-01-23',90.000,1,'2018-01-24 18:33:22'),(10,14,'2017-10-23','2018-01-10',80.000,1,NULL),(11,15,'2017-10-23','2018-01-17',90.000,1,'2018-01-18 20:50:51'),(12,16,'2017-10-23','2018-01-10',100.000,1,NULL),(13,17,'2017-10-23','2018-01-17',135.000,1,'2018-01-18 20:32:29'),(14,18,'2017-10-23','2018-01-10',50.000,1,NULL),(15,19,'2017-10-23','2018-01-10',89.000,1,NULL),(16,20,'2017-10-23','2018-01-10',10.000,1,NULL),(17,21,'2017-10-23','2018-01-17',145.000,1,'2018-01-18 20:33:08'),(18,22,'2017-10-23',NULL,140.000,1,NULL),(19,23,'2017-10-23',NULL,135.000,1,NULL),(20,24,'2017-10-23',NULL,140.000,1,NULL),(21,25,'2017-10-23',NULL,125.000,1,NULL),(22,26,'2017-10-23',NULL,135.000,1,NULL),(23,27,'2017-10-23',NULL,160.000,1,NULL),(24,28,'2017-10-23',NULL,92.000,1,NULL),(25,29,'2017-10-23',NULL,125.000,1,NULL),(26,30,'2017-10-23',NULL,99.000,1,NULL),(27,31,'2017-10-23',NULL,125.000,1,NULL),(28,32,'2017-10-23','2018-01-17',170.000,1,'2018-01-18 20:27:33'),(29,33,'2017-10-23',NULL,170.000,1,NULL),(30,34,'2017-10-23',NULL,180.000,1,NULL),(31,35,'2017-10-23',NULL,145.000,1,NULL),(32,36,'2017-10-23',NULL,180.000,1,NULL),(33,37,'2017-10-23',NULL,145.000,1,NULL),(34,38,'2017-10-23',NULL,145.000,1,NULL),(35,39,'2017-10-23','2018-01-10',145.000,1,NULL),(36,40,'2017-10-23',NULL,145.000,1,NULL),(37,41,'2017-10-23',NULL,140.000,1,NULL),(38,42,'2017-10-23',NULL,140.000,1,NULL),(39,43,'2017-10-23',NULL,135.000,1,NULL),(40,44,'2017-10-23',NULL,140.000,1,NULL),(42,5,'2017-10-01','2017-10-22',92.640,1,NULL),(43,6,'2017-10-01','2017-10-22',68.720,1,NULL),(44,7,'2017-10-01','2017-10-22',35.260,1,NULL),(45,8,'2017-10-01','2017-10-22',92.000,1,NULL),(46,9,'2017-10-01','2017-10-22',78.400,1,NULL),(47,10,'2017-10-01','2017-10-22',72.000,1,NULL),(48,11,'2017-10-01','2017-10-22',72.000,1,NULL),(49,12,'2017-10-01','2017-10-22',72.000,1,NULL),(50,13,'2017-10-01','2017-10-22',64.000,1,NULL),(51,14,'2017-10-01','2017-10-22',64.000,1,NULL),(52,15,'2017-10-01','2017-10-22',72.000,1,NULL),(53,16,'2017-10-01','2017-10-22',80.000,1,NULL),(54,17,'2017-10-01','2017-10-22',108.000,1,NULL),(55,18,'2017-10-01','2017-10-22',40.000,1,NULL),(56,19,'2017-10-01','2017-10-22',71.200,1,NULL),(57,20,'2017-10-01','2017-10-22',8.000,1,NULL),(58,21,'2017-10-01','2017-10-22',116.000,1,NULL),(59,22,'2017-10-01','2017-10-22',112.000,1,NULL),(60,23,'2017-10-01','2017-10-22',108.000,1,NULL),(61,24,'2017-10-01','2017-10-22',112.000,1,NULL),(62,25,'2017-10-01','2017-10-22',100.000,1,NULL),(63,26,'2017-10-01','2017-10-22',108.000,1,NULL),(64,27,'2017-10-01','2017-10-22',128.000,1,NULL),(65,28,'2017-10-01','2017-10-22',73.600,1,NULL),(66,29,'2017-10-01','2017-10-22',100.000,1,NULL),(67,30,'2017-10-01','2017-10-22',79.200,1,NULL),(68,31,'2017-10-01','2017-10-22',100.000,1,NULL),(69,32,'2017-10-01','2017-10-22',136.000,1,NULL),(70,33,'2017-10-01','2017-10-22',136.000,1,NULL),(71,34,'2017-10-01','2017-10-22',144.000,1,NULL),(72,35,'2017-10-01','2017-10-22',116.000,1,NULL),(73,36,'2017-10-01','2017-10-22',144.000,1,NULL),(74,37,'2017-10-01','2017-10-22',116.000,1,NULL),(75,38,'2017-10-01','2017-10-22',116.000,1,NULL),(76,39,'2017-10-01','2017-10-22',116.000,1,NULL),(77,40,'2017-10-01','2017-10-22',116.000,1,NULL),(78,41,'2017-10-01','2017-10-22',112.000,1,NULL),(79,42,'2017-10-01','2017-10-22',112.000,1,NULL),(80,43,'2017-10-01','2017-10-22',108.000,1,NULL),(81,44,'2017-10-01','2017-10-22',112.000,1,NULL),(83,9,'2018-01-11',NULL,105.000,1,NULL),(84,11,'2018-01-11','2018-01-23',105.000,1,'2018-01-24 18:05:13'),(86,12,'2018-01-11','2018-01-17',99.000,1,'2018-01-18 20:34:14'),(87,14,'2018-01-11','2018-01-17',89.000,1,'2018-01-18 20:19:21'),(88,18,'2018-01-11',NULL,56.000,1,NULL),(89,19,'2018-01-11','2018-01-23',98.000,1,'2018-01-24 18:35:45'),(90,39,'2018-01-11',NULL,160.000,1,NULL),(92,20,'2018-01-11','2018-01-17',42.000,1,'2018-01-18 20:34:44'),(93,7,'2018-01-11',NULL,37.335,1,NULL),(94,16,'2018-01-11','2018-01-14',125.520,1,NULL),(95,8,'2018-01-11','2018-01-14',127.650,1,NULL),(96,5,'2018-01-11','2018-01-17',130.622,1,'2018-01-18 20:17:23'),(97,52,'2018-01-11',NULL,528.450,1,NULL),(98,55,'2018-01-11',NULL,658.250,1,NULL),(99,8,'2018-01-15',NULL,162.360,1,NULL),(100,16,'2018-01-15','2018-01-17',150.624,1,'2018-01-18 20:49:14'),(101,63,'2018-01-15',NULL,0.389,1,NULL),(102,50,'2018-01-15',NULL,0.871,1,NULL),(103,49,'2018-01-15',NULL,16.608,1,NULL),(104,76,'2018-01-15',NULL,18.298,1,NULL),(105,56,'2018-01-15',NULL,22.916,1,NULL),(106,64,'2018-01-15',NULL,23.365,1,NULL),(107,68,'2018-01-15',NULL,45.531,1,NULL),(108,69,'2018-01-15',NULL,45.574,1,NULL),(109,78,'2018-01-15',NULL,50.293,1,NULL),(110,62,'2018-01-15',NULL,59.526,1,NULL),(111,59,'2018-01-15',NULL,60.978,1,NULL),(112,73,'2018-01-15',NULL,63.535,1,NULL),(113,70,'2018-01-15',NULL,91.278,1,NULL),(114,77,'2018-01-15',NULL,101.037,1,NULL),(115,58,'2018-01-15','2018-01-17',105.052,1,'2018-01-18 20:39:05'),(116,66,'2018-01-15',NULL,108.201,1,NULL),(117,65,'2018-01-15',NULL,115.659,1,NULL),(118,71,'2018-01-15','2018-01-23',119.669,1,'2018-01-24 18:08:29'),(119,72,'2018-01-15',NULL,124.508,1,NULL),(120,75,'2018-01-15',NULL,130.150,1,NULL),(121,74,'2018-01-15',NULL,144.151,1,NULL),(122,51,'2018-01-15',NULL,154.531,1,NULL),(123,57,'2018-01-15',NULL,154.760,1,NULL),(124,61,'2018-01-15',NULL,165.747,1,NULL),(125,53,'2018-01-15',NULL,170.040,1,NULL),(126,54,'2018-01-15','2018-01-26',186.607,1,'2018-01-27 01:32:03'),(127,60,'2018-01-15',NULL,189.736,1,NULL),(128,67,'2018-01-15',NULL,194.027,1,NULL),(129,5,'2018-01-18','2018-05-07',156.746,1,'2018-05-08 19:44:51'),(130,14,'2018-01-18',NULL,289.000,1,NULL),(131,32,'2018-01-18',NULL,184.260,1,NULL),(132,17,'2018-01-18',NULL,148.287,1,NULL),(133,21,'2018-01-18',NULL,174.300,1,NULL),(134,12,'2018-01-18','2018-01-23',200.000,1,'2018-01-24 18:36:18'),(135,20,'2018-01-18',NULL,98.000,1,NULL),(136,58,'2018-01-18',NULL,201.000,1,NULL),(137,16,'2018-01-18',NULL,250.000,1,NULL),(138,15,'2018-01-18',NULL,112.117,1,NULL),(139,11,'2018-01-24',NULL,208.600,1,NULL),(140,71,'2018-01-24',NULL,25.300,1,NULL),(141,13,'2018-01-24',NULL,180.000,1,NULL),(142,19,'2018-01-24',NULL,196.000,1,NULL),(143,12,'2018-01-24',NULL,450.000,1,'2018-01-24 18:37:07'),(144,54,'2018-01-27',NULL,214.598,1,NULL),(145,1,'2018-04-03','2018-04-03',256.250,1,'2018-04-04 19:06:48'),(146,2,'2018-04-03',NULL,328.250,1,NULL),(147,3,'2018-04-03','2018-04-03',129.740,1,'2018-04-04 19:03:03'),(148,4,'2018-04-03',NULL,75.590,1,NULL),(149,45,'2018-04-03',NULL,116.230,1,NULL),(150,46,'2018-04-03',NULL,250.280,1,NULL),(151,47,'2018-04-03',NULL,37.920,1,NULL),(152,48,'2018-04-03',NULL,40.125,1,NULL),(153,79,'2018-04-03',NULL,275.670,1,NULL),(154,80,'2018-04-03',NULL,216.650,1,NULL),(155,81,'2018-04-03',NULL,156.250,1,NULL),(156,82,'2018-04-03',NULL,232.290,1,NULL),(157,83,'2018-04-03',NULL,190.730,1,NULL),(158,84,'2018-04-03',NULL,156.790,1,NULL),(159,85,'2018-04-03',NULL,111.760,1,NULL),(160,86,'2018-04-03',NULL,189.410,1,NULL),(161,87,'2018-04-03',NULL,109.790,1,NULL),(162,88,'2018-04-03',NULL,282.740,1,NULL),(163,89,'2018-04-03',NULL,180.340,1,NULL),(164,90,'2018-04-03',NULL,154.460,1,NULL),(165,91,'2018-04-03',NULL,131.270,1,NULL),(166,92,'2018-04-03',NULL,294.010,1,NULL),(167,93,'2018-04-03',NULL,172.230,1,NULL),(168,94,'2018-04-03',NULL,281.140,1,NULL),(169,95,'2018-04-03',NULL,186.010,1,NULL),(170,96,'2018-04-03',NULL,187.630,1,NULL),(171,97,'2018-04-03',NULL,280.120,1,NULL),(172,98,'2018-04-03',NULL,134.700,1,NULL),(173,99,'2018-04-03',NULL,135.180,1,NULL),(174,100,'2018-04-03',NULL,171.780,1,NULL),(175,101,'2018-04-03',NULL,152.390,1,NULL),(176,102,'2018-04-03',NULL,146.600,1,NULL),(177,103,'2018-04-03',NULL,175.840,1,NULL),(178,104,'2018-04-03',NULL,138.390,1,NULL),(179,105,'2018-04-03',NULL,265.440,1,NULL),(180,106,'2018-04-03',NULL,209.050,1,NULL),(181,107,'2018-04-03',NULL,148.920,1,NULL),(182,3,'2018-04-04',NULL,179.740,1,NULL),(183,1,'2018-04-04','2018-04-10',280.280,1,'2018-04-11 17:26:15'),(184,1,'2018-04-11',NULL,281.210,1,NULL),(185,5,'2018-05-08',NULL,180.000,1,NULL),(186,108,'2018-05-09',NULL,200.000,1,NULL);
/*!40000 ALTER TABLE `preciohistorico` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto`
--

DROP TABLE IF EXISTS `producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `producto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_producto_tipo` int(11) NOT NULL,
  `id_codigo_barra` varchar(6) DEFAULT NULL,
  `precio` decimal(10,3) NOT NULL DEFAULT '0.000',
  `cantidad` decimal(10,2) NOT NULL,
  `descripcion_breve` varchar(60) NOT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_precio` (`precio`)
) ENGINE=InnoDB AUTO_INCREMENT=510 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` VALUES (1,2,'11750',281.210,50.00,'TRIPA',1,NULL),(2,2,'11760',328.250,50.00,'CHINCHULÍN',1,NULL),(3,2,'11770',179.740,50.00,'RIÑON',1,NULL),(4,2,'11780',75.590,50.00,'CORAZÓN',1,NULL),(5,2,'11790',180.000,50.00,'ENTRAÑA',1,NULL),(6,2,'11800',112.700,50.00,'RABO',1,NULL),(7,2,'11810',111.020,50.00,'MONDONGO',1,NULL),(8,2,'11820',26.480,50.00,'HÍGADO',1,NULL),(9,2,'11830',147.850,50.00,'MOLLEJAS',1,NULL),(10,2,'11850',124.760,50.00,'LENGUA',1,NULL),(11,2,'11860',147.950,50.00,'QUIJADA',1,NULL),(12,2,'11870',111.750,50.00,'DUOS',1,NULL),(13,2,'11880',76.250,50.00,'CARRE ',1,NULL),(14,2,'11890',64.160,50.00,'PECHITO',1,NULL),(15,2,'11900',57.160,50.00,'JAMON ENTERO',1,NULL),(16,2,'11910',143.550,50.00,'CHURRASQUITO',1,NULL),(17,2,'11920',153.140,50.00,'PALETA ENTERA',1,NULL),(18,2,'11930',82.180,50.00,'PAPADA',1,NULL),(19,2,'11940',103.810,50.00,'TOCINO',1,NULL),(20,2,'11950',116.780,50.00,'MATAMBRITOS',1,NULL),(21,2,'11960',114.800,50.00,'BONDIOLA',1,NULL),(22,3,NULL,97.230,-93.00,'1/2 RESES',1,NULL),(23,3,NULL,47.830,89.00,'1/4 RUEDA',1,NULL),(24,3,NULL,59.850,4.74,'1/4 PISTOLA',1,NULL),(25,3,NULL,73.830,50.00,' 1/4 DELANTERO ',1,NULL),(26,3,NULL,103.910,-19.72,'BARRAS',1,NULL),(27,3,NULL,130.530,50.00,'MOCHITOS',1,NULL),(28,3,NULL,134.400,50.00,'MANTAS',1,NULL),(29,3,NULL,106.050,2.00,'RECORTE',1,NULL),(30,3,NULL,56.560,50.00,'PARRILLERO',1,NULL),(31,3,NULL,98.580,50.00,'JUEGOS DE ACHURAS',1,NULL),(32,3,NULL,85.370,50.00,'RECORTE DE 1',1,NULL),(33,3,NULL,49.460,50.00,'RECORTE DE 2°',1,NULL),(34,1,'10990',48.950,50.00,'CHORIZO ESPECIAL',1,NULL),(35,1,'11000',53.330,130.00,'CHORIZO PARRILLERO',1,NULL),(36,1,'11010',125.560,50.00,'CHORIZO DE CERDO',1,NULL),(37,1,'11020',31.580,75.00,'CHORIZO COLORADO',1,NULL),(38,1,'11030',41.820,50.00,'SALCHICHA PARRILL.',1,NULL),(39,1,'11040',144.400,50.00,'MORCILLA',1,NULL),(40,1,'11050',72.380,50.00,'MORCILLA',1,NULL),(41,1,'11060',54.580,50.00,'SALCHICHAS SNACK',1,NULL),(42,1,'11070',38.680,50.00,'PATE',1,NULL),(43,1,'11080',107.300,50.00,'QUESO DE CERDO',1,NULL),(44,1,'11100',30.120,103.00,'PICADA COMUN',1,NULL),(45,1,'11110',116.230,50.00,'PICADA INTERMEDIA',1,NULL),(46,1,'11120',250.280,460.00,'PICADA ESPECIAL',1,NULL),(47,1,'11130',37.920,50.00,'PUCHERO COMUN',1,NULL),(48,1,'11140',40.125,62.00,'PUCHERO ESPECIAL',1,NULL),(49,1,'11150',41.230,50.00,'CANINO',1,NULL),(50,1,'11160',92.220,50.00,'MATAMBRE',1,NULL),(51,1,'11170',111.710,75.00,'VACIO',1,NULL),(52,1,'11180',106.860,50.00,'ALA DE PECHO',1,NULL),(53,1,'11190',133.860,50.00,'COSTILLA',1,NULL),(54,1,'11200',30.180,50.00,'MARUCHA',1,NULL),(55,1,'11210',112.810,50.00,'TAPA DE NALGA',1,NULL),(56,1,'11220',47.510,50.00,'CORTE MALVINA',1,NULL),(57,1,'11230',39.460,50.00,'FALDA',1,NULL),(58,1,'11240',136.620,50.00,'COSTELETAS',1,NULL),(59,1,'11250',105.710,50.00,'AGUJA',1,NULL),(60,1,'11260',57.700,50.00,'BRAZUELO',1,NULL),(61,1,'11270',36.160,50.00,'BIFE ANCHO/ANGOSTO',1,NULL),(62,1,'11280',114.390,50.00,'ENTRECOT',1,NULL),(63,1,'11290',87.570,50.00,'ROAST BEEF',1,NULL),(64,1,'11300',114.240,50.00,'NALGAS',1,NULL),(65,1,'11310',43.250,50.00,'LOMO',1,NULL),(66,1,'11320',36.660,50.00,'PECETO',1,NULL),(67,1,'11330',61.650,50.00,'CUADRIL',1,NULL),(68,1,'11340',123.510,50.00,'PALOMITA',1,NULL),(69,1,'11350',130.630,50.00,'JAMON CUADRADO',1,NULL),(70,1,'11360',46.800,50.00,'CABEZA DE LOMO',1,NULL),(71,1,'11370',108.510,50.00,'PULPA BRAZUELO',1,NULL),(72,1,'11380',149.570,50.00,'PULPA PALETA',1,NULL),(73,1,'11390',25.880,50.00,'TORTUGUITA',1,NULL),(74,1,'11400',142.610,50.00,'MILANESAS DE CARNE',1,NULL),(75,1,'11410',55.910,50.00,'MILANESAS DE POLLO',1,NULL),(76,1,'11420',63.670,50.00,'HAMBURGUESAS',1,NULL),(77,1,'11430',38.150,50.00,'ALBONDIGAS',1,NULL),(78,1,'11440',125.670,50.00,'COSTELETAS',1,NULL),(79,1,'11450',138.760,50.00,'BONDIOLA',1,NULL),(80,1,'11460',83.870,50.00,'MATAMBRITO',1,NULL),(81,1,'11470',69.460,50.00,'COSTILLA/PECHITO',1,NULL),(82,1,'11480',28.950,50.00,'PULPAS',1,NULL),(83,1,'11490',37.080,50.00,'MARUCHA',1,NULL),(84,1,'11500',141.580,50.00,'CARACU',1,NULL),(85,1,'11510',69.250,50.00,'PAT./HUE./CUE.',1,NULL),(86,1,'11520',79.810,50.00,'MILANESAS',1,NULL),(87,1,'11530',77.840,50.00,'HAMBURGUESAS',1,NULL),(88,1,'11540',78.480,50.00,'PATAMUSLO',1,NULL),(89,1,'11550',122.900,50.00,'TROZADO',1,NULL),(90,1,'11560',89.560,50.00,'PECHUGA',1,NULL),(91,1,'11570',41.960,50.00,'FILET',1,NULL),(92,1,'11580',135.130,50.00,'BROCHET',1,NULL),(93,1,'11590',130.990,50.00,'BONDIOLA',1,NULL),(94,1,'11600',108.720,50.00,'PALETA',1,NULL),(95,1,'11610',61.440,50.00,'JAMON COCIDO',1,NULL),(96,1,'11620',110.730,50.00,'JAMON CRUDO',1,NULL),(97,1,'11630',102.460,50.00,'SALAME MILAN',1,NULL),(98,1,'11640',34.330,50.00,'SALAMIN',1,NULL),(99,1,'11650',117.640,50.00,'QUESO BARRA',1,NULL),(100,1,'11660',61.960,50.00,'CREMOSO',1,NULL),(101,1,'11670',129.930,50.00,'CASCARA COLORADA',1,NULL),(102,1,'11680',53.510,50.00,'QUESO CRE',1,NULL),(103,1,'11690',51.580,50.00,'QUESO TREEMBLAY',1,NULL),(104,1,'11700',54.320,50.00,'QUESO PROVOLETA',1,NULL),(105,1,'11710',126.280,50.00,'QUESO SARDO',1,NULL),(106,1,'11720',78.640,50.00,'MORTADELA',1,NULL),(107,1,'11730',122.700,50.00,'MORTADELA',1,NULL),(109,4,NULL,15.000,0.00,'9 de julio agridul',1,NULL),(110,4,NULL,15.000,0.00,'9 de julio azucara',1,NULL),(111,4,NULL,15.000,0.00,'9 de julio clásica',1,NULL),(112,4,NULL,40.000,0.00,'9 de julio marmola',1,NULL),(113,4,NULL,25.000,0.00,'9 de julio vainill',1,NULL),(114,4,NULL,1.000,0.00,'Aceite Cañuelas Gi',1,NULL),(115,4,NULL,100.000,0.00,'Aceite de oliva ex',1,NULL),(116,4,NULL,45.000,0.00,'Aceite Natura 900m',1,NULL),(117,4,NULL,14.000,0.00,'Alicante Comino mo',1,NULL),(118,4,NULL,13.500,0.00,'Alicante condiment',1,NULL),(119,4,NULL,18.000,0.00,'Alicante Condiment',1,NULL),(120,4,NULL,18.000,0.00,'Alicante Condiment',1,NULL),(121,4,NULL,16.000,0.00,'Alicante Condiment',1,NULL),(122,4,NULL,18.000,0.00,'Alicante condiment',1,NULL),(123,4,NULL,18.000,0.00,'Alicante especias ',1,NULL),(124,4,NULL,1.000,0.00,'Alicante Laurel tr',1,NULL),(125,4,NULL,26.000,0.00,'Alicante orégano 2',1,NULL),(126,4,NULL,26.000,0.00,'Alicante Perejil d',1,NULL),(127,4,NULL,30.000,0.00,'Alicante pimienta ',1,NULL),(128,4,NULL,22.000,0.00,'Alicante pimienta ',1,NULL),(129,4,NULL,28.000,0.00,'Alicante pollo a l',1,NULL),(130,4,NULL,1.000,0.00,'Alicante Provenzal',1,NULL),(131,4,NULL,8.000,0.00,'Alicante sabor en ',1,NULL),(132,4,NULL,8.000,0.00,'Alicante sabor en ',1,NULL),(133,4,NULL,8.000,0.00,'Alicante sabor en ',1,NULL),(134,4,NULL,55.000,0.00,'Ananás umaná 567g',1,NULL),(135,4,NULL,1.000,0.00,'Arvejas Inalpa',1,NULL),(136,4,NULL,12.000,0.00,'Arvejas San Remo',1,NULL),(137,4,NULL,25.000,0.00,'Azucar comun tipo ',1,NULL),(138,4,NULL,20.000,0.00,'Cacao el Quilla cl',1,NULL),(139,4,NULL,1.000,0.00,'Carbon de leña dur',1,NULL),(140,4,NULL,1.000,0.00,'Carbon vegetal 5kg',1,NULL),(141,4,NULL,260.000,0.00,'Champagne Chandon ',1,NULL),(142,4,NULL,1.000,0.00,'Champagne Santa Ju',1,NULL),(143,4,NULL,192.000,0.00,'Chandon demi sec',1,NULL),(144,4,NULL,1.000,0.00,'Chandon extra brut',1,NULL),(145,4,NULL,12.000,0.00,'Chef queso rallado',1,NULL),(146,4,NULL,33.000,0.00,'Chips Delicias de ',1,NULL),(147,4,NULL,23.000,0.00,'Choclo amarillo Cr',1,NULL),(148,4,NULL,25.000,0.00,'Choclo amarillo In',1,NULL),(149,4,NULL,12.000,0.00,'Comino Aromas y sa',1,NULL),(150,4,NULL,1.000,0.00,'Dulce de leche La ',1,NULL),(151,4,NULL,1.000,0.00,'Edulcorante Si die',1,NULL),(152,4,NULL,130.000,0.00,'Fernet Branca ment',1,NULL),(153,4,NULL,96.000,0.00,'Fresita',1,NULL),(154,4,NULL,29.000,0.00,'galletas criollita',1,NULL),(155,4,NULL,1.000,0.00,'Galletas Festiva m',1,NULL),(156,4,NULL,25.000,0.00,'galletas mediatard',1,NULL),(157,4,NULL,30.000,0.00,'Galletas Toddy clá',1,NULL),(158,4,NULL,20.000,0.00,'Galletas Toddy clá',1,NULL),(159,4,NULL,30.000,0.00,'Galletas Toddy dul',1,NULL),(160,4,NULL,35.000,0.00,'galletas traviata ',1,NULL),(161,4,NULL,30.000,0.00,'galletitas diversi',1,NULL),(162,4,NULL,20.000,0.00,'Galletitas Kesbun ',1,NULL),(163,4,NULL,32.000,0.00,'Harina Pureza Espe',1,NULL),(164,4,NULL,23.000,0.00,'Harina Pureza Leud',1,NULL),(165,4,NULL,26.000,0.00,'Isamay aceitunas v',1,NULL),(166,4,NULL,17.000,0.00,'Jardinera Inalpa 3',1,NULL),(167,4,NULL,120.000,0.00,'JBJ Pavita y verdu',1,NULL),(168,4,NULL,8.000,0.00,'Knorr caldo de gal',1,NULL),(169,4,NULL,20.000,0.00,'Knorr sabor en sob',1,NULL),(170,4,NULL,20.000,0.00,'Knorr sopa crema V',1,NULL),(171,4,NULL,32.000,0.00,'Leche descremada I',1,NULL),(172,4,NULL,32.000,0.00,'Leche entera Ilola',1,NULL),(173,4,NULL,1.000,0.00,'Lentejas Secas rem',1,NULL),(174,4,NULL,22.000,0.00,'mate cocido taragü',1,NULL),(175,4,NULL,12.000,0.00,'Mayonesa CadaDía l',1,NULL),(176,4,NULL,30.000,0.00,'Mayonesa Natura 23',1,NULL),(177,4,NULL,15.000,0.00,'Mayonesa Natura ch',1,NULL),(178,4,NULL,1.000,0.00,'Merceir extra brut',1,NULL),(179,4,NULL,42.000,0.00,'Mora duraznos',1,NULL),(180,4,NULL,25.000,0.00,'paseo chatitas 140',1,NULL),(181,4,NULL,1.000,0.00,'Paté de foie Palad',1,NULL),(182,4,NULL,1.000,0.00,'Picadillo de carne',1,NULL),(183,4,NULL,19.500,0.00,'polenta presto pro',1,NULL),(184,4,NULL,23.000,0.00,'Porotos Inca 202g',1,NULL),(185,4,NULL,42.000,0.00,'Producto de tomate',1,NULL),(186,4,NULL,13.000,0.00,'Puré de tomate Mor',1,NULL),(187,4,NULL,15.000,0.00,'Puré de tomates De',1,NULL),(188,4,NULL,25.000,0.00,'Puré de tomates De',1,NULL),(189,4,NULL,20.000,0.00,'Queso rallado La p',1,NULL),(190,4,NULL,20.000,0.00,'Sal fina Dos ancla',1,NULL),(191,4,NULL,26.000,0.00,'Salsa lista Knor p',1,NULL),(192,4,NULL,26.000,0.00,'Salsa lista Knor p',1,NULL),(193,4,NULL,12.000,0.00,'Savora original 60',1,NULL),(194,4,NULL,1.000,0.00,'Sidra Real 910ml',1,NULL),(195,4,NULL,25.000,0.00,'Sol mayor rollos d',1,NULL),(196,4,NULL,1.000,0.00,'Tahití salsa de aj',1,NULL),(197,4,NULL,1.000,0.00,'Tang limonada dulc',1,NULL),(198,4,NULL,1.000,0.00,'Tang multifruta',1,NULL),(199,4,NULL,1.000,0.00,'Tang naranja',1,NULL),(200,4,NULL,1.000,0.00,'té de boldo La vir',1,NULL),(201,4,NULL,28.000,0.00,'té de manzanilla L',1,NULL),(202,4,NULL,1.000,0.00,'té de tilo La virg',1,NULL),(203,4,NULL,18.000,0.00,'té La virginia 25 ',1,NULL),(204,4,NULL,18.000,0.00,'Tomate entero pela',1,NULL),(205,4,NULL,40.000,0.00,'Twistos horneados ',1,NULL),(206,4,NULL,40.000,0.00,'Twistos horneados ',1,NULL),(207,4,NULL,38.000,0.00,'Vanoli aceitunas r',1,NULL),(208,4,NULL,48.000,0.00,'Vanoli Ajíes en vi',1,NULL),(209,4,NULL,39.000,0.00,'Vanoli lupines en ',1,NULL),(210,4,NULL,43.000,0.00,'Vanoli pepinillos ',1,NULL),(211,4,NULL,37.000,0.00,'Vanoli pickles mix',1,NULL),(212,4,NULL,20.000,0.00,'video cabello de a',1,NULL),(213,4,NULL,47.000,0.00,'videos secos juan ',1,NULL),(214,4,NULL,17.000,0.00,'Vinagre de frtuta ',1,NULL),(215,4,NULL,145.000,0.00,'Vino Alma Mora Fin',1,NULL),(216,4,NULL,1.000,0.00,'Vino Colon Malbec ',1,NULL),(217,4,NULL,95.000,0.00,'Vino Colon torreon',1,NULL),(218,4,NULL,125.000,0.00,'Vino Dadá Finca La',1,NULL),(219,4,NULL,1.000,0.00,'Vino Don Valentin ',1,NULL),(220,4,NULL,1.000,0.00,'Vino Finca Las mor',1,NULL),(221,4,NULL,115.000,0.00,'Vino Finca Las mor',1,NULL),(222,4,NULL,90.000,0.00,'Vino Intenso Malbe',1,NULL),(223,4,NULL,140.000,0.00,'Vino Malbec Santa ',1,NULL),(224,4,NULL,1.000,0.00,'Vino Michel Torino',1,NULL),(225,4,NULL,50.000,0.00,'Vino Norton 1895 C',1,NULL),(226,4,NULL,85.000,0.00,'Vino Norton 1895 C',1,NULL),(227,4,NULL,98.000,0.00,'Vino Norton 1895 C',1,NULL),(228,4,NULL,45.000,0.00,'Vino Santa Ana',1,NULL),(229,4,NULL,75.000,0.00,'Vino Santa Ana Clá',1,NULL),(230,4,NULL,105.000,0.00,'Vino Santa Julia C',1,NULL),(231,4,NULL,105.000,0.00,'Vino Santa Julia M',1,NULL),(232,4,NULL,1.000,0.00,'Vino tinto Element',1,NULL),(233,4,NULL,53.000,0.00,'Vino tinto Michel ',1,NULL),(234,4,NULL,91.000,0.00,'Vino Valderrobles ',1,NULL),(235,4,NULL,1.000,0.00,'Vodka Bols Frutill',1,NULL),(236,4,NULL,8.000,0.00,'Wilde caldo de ver',1,NULL),(237,4,NULL,45.000,0.00,'yerba mate Aguanta',1,NULL),(238,4,NULL,37.000,0.00,'yerba mate CBSé hi',1,NULL),(239,4,NULL,43.000,0.00,'yerba mate Rosamon',1,NULL),(240,4,NULL,0.000,6.00,'9 DE JULIO AGRIDULCES BIZCOCHOS 200G',1,NULL),(241,4,NULL,0.000,99.00,'9 DE JULIO AZUCARADOS BIZCOCHOS 200G',1,NULL),(242,4,NULL,0.000,2.00,'9 DE JULIO CLÁSICAS BIZCOCHO 200G',1,NULL),(243,4,NULL,0.000,99.00,'9 DE JULIO MARMOLADO MINI BUDIN 210G',1,NULL),(244,4,NULL,0.000,2.00,'9 DE JULIO VAINILLA MINI MADGALENAS 140G',1,NULL),(245,4,NULL,0.000,12.00,'ACEITE CAÑUELAS GIRASOL ',1,NULL),(246,4,NULL,0.000,2.00,'ACEITE DE OLIVA EXTRA VIRGEN OLIVA',1,NULL),(247,4,NULL,0.000,99.00,'ACEITE NATURA 900ML',1,NULL),(248,4,NULL,0.000,12.00,'ALICANTE COMINO MOLIDO 25G',1,NULL),(249,4,NULL,0.000,6.00,'ALICANTE CONDIMENTO PARA ARROZ 25G',1,NULL),(250,4,NULL,0.000,2.00,'ALICANTE CONDIMENTO PARA AVES 25G',1,NULL),(251,4,NULL,0.000,99.00,'ALICANTE CONDIMENTO PARA EMPANADAS Y RELLENOS 25G',1,NULL),(252,4,NULL,0.000,99.00,'ALICANTE CONDIMENTO PARA PESCADOS 25G',1,NULL),(253,4,NULL,0.000,3.00,'ALICANTE CONDIMENTO PARA PIZZA 25G',1,NULL),(254,4,NULL,0.000,99.00,'ALICANTE ESPECIAS SURTIDAS MOLIDAS 25G',1,NULL),(255,4,NULL,0.000,3.00,'ALICANTE LAUREL TRITURADO 25G',1,NULL),(256,4,NULL,0.000,3.00,'ALICANTE ORÉGANO 25G',1,NULL),(257,4,NULL,0.000,2.00,'ALICANTE PEREJIL DESHIDRATADO 25G',1,NULL),(258,4,NULL,0.000,3.00,'ALICANTE PIMIENTA BLANCA MOLIDA 25G',1,NULL),(259,4,NULL,0.000,1.00,'ALICANTE PIMIENTA NEGRA MOLIDA 25G',1,NULL),(260,4,NULL,0.000,1.00,'ALICANTE POLLO A LAS FINAS HIERBAS BOLSA',1,NULL),(261,4,NULL,0.000,5.00,'ALICANTE PROVENZAL AJO Y PEREJIL DESHIDRATADO 25G',1,NULL),(262,4,NULL,0.000,1.00,'ALICANTE SABOR EN POLVO CARNE',1,NULL),(263,4,NULL,0.000,5.00,'ALICANTE SABOR EN POLVO 4 CUATRO QUESOS',1,NULL),(264,4,NULL,0.000,4.00,'ALICANTE SABOR EN POLVO PUERRO',1,NULL),(265,4,NULL,0.000,1.00,'ANANÁS CUMANÁ 567G',1,NULL),(266,4,NULL,0.000,4.00,'ARVEJAS INALPA',1,NULL),(267,4,NULL,0.000,14.00,'ARVEJAS SAN REMO',1,NULL),(268,4,NULL,0.000,4.00,'AZUCAR COMUN TIPO A CASTELITA',1,NULL),(269,4,NULL,0.000,27.00,'CACAO EL QUILLA CLÁSICO 200G',1,NULL),(270,4,NULL,0.000,99.00,'CARBON DE LEÑA DURA ALTA CALORÍA EL TIZON SALTA 3K',1,NULL),(271,4,NULL,0.000,11.00,'CARBON VEGETAL 5KG',1,NULL),(272,4,NULL,0.000,3.00,'CHAMPAGNE CHANDON DELICE',1,NULL),(273,4,NULL,0.000,1.00,'CHAMPAGNE SANTA JULIA',1,NULL),(274,4,NULL,0.000,4.00,'CHANDON DEMI SEC',1,NULL),(275,4,NULL,0.000,1.00,'CHANDON EXTRA BRUT CHAMPAGNE',1,NULL),(276,4,NULL,0.000,14.00,'CHEF QUESO RALLADO 100G',1,NULL),(277,4,NULL,0.000,99.00,'CHIPS DELICIAS DE LA NONNA 400G',1,NULL),(278,4,NULL,0.000,2.00,'CHOCLO AMARILLO CREMA INALPA',1,NULL),(279,4,NULL,0.000,2.00,'CHOCLO AMARILLO INALPA',1,NULL),(280,4,NULL,0.000,5.00,'COMINO AROMAS Y SABORES 25G',1,NULL),(281,4,NULL,0.000,2.00,'DULCE DE LECHE LA PAULINA 250G',1,NULL),(282,4,NULL,0.000,2.00,'EDULCORANTE SI DIET',1,NULL),(283,4,NULL,0.000,9.00,'FERNET BRANCA MENTA 450CC',1,NULL),(284,4,NULL,0.000,3.00,'FRESITA',1,NULL),(285,4,NULL,0.000,14.00,'GALLETAS CRIOLLITAS ORIGINAL PACK FAMILIAR X3',1,NULL),(286,4,NULL,0.000,99.00,'GALLETAS FESTIVA MAX SURTIDAS',1,NULL),(287,4,NULL,0.000,99.00,'GALLETAS MEDIATARDE CLÁSICAS PACK FAMILIAR X3',1,NULL),(288,4,NULL,0.000,99.00,'GALLETAS TODDY CLÁSICAS 150G',1,NULL),(289,4,NULL,0.000,99.00,'GALLETAS TODDY CLÁSICAS 75G',1,NULL),(290,4,NULL,0.000,99.00,'GALLETAS TODDY DULCE DE LECHE 150G',1,NULL),(291,4,NULL,0.000,11.00,'GALLETAS TRAVIATA PACK FAMILIAR X3',1,NULL),(292,4,NULL,0.000,3.00,'GALLETITAS DIVERSION ',1,NULL),(293,4,NULL,0.000,99.00,'GALLETITAS KESBUN PIZZA ESPECIAL DE FUGAZZETA 100G',1,NULL),(294,4,NULL,0.000,1.00,'HARINA PUREZA ESPECIAL PARA PIZZAS CASERAS 1KG',1,NULL),(295,4,NULL,0.000,4.00,'HARINA PUREZA LEUDANTE ULTRA REFINADA 1KG',1,NULL),(296,4,NULL,0.000,3.00,'ISAMAY ACEITUNAS VERDES EN SALMUERA',1,NULL),(297,4,NULL,0.000,1.00,'JARDINERA INALPA 350G',1,NULL),(298,4,NULL,0.000,1.00,'JBJ PAVITA Y VERDURAS AL ESCABECHE 300G',1,NULL),(299,4,NULL,0.000,22.00,'KNORR CALDO DE GALLINA CAJA CHICA VERDE',1,NULL),(300,4,NULL,0.000,5.00,'KNORR SABOR EN SOBRECITOS PROVENZAL',1,NULL),(301,4,NULL,0.000,1.00,'KNORR SOPA CREMA VERDURAS 60G',1,NULL),(302,4,NULL,0.000,99.00,'LECHE DESCREMADA ILOLAY 1LT',1,NULL),(303,4,NULL,0.000,99.00,'LECHE ENTERA ILOLAY 1LT',1,NULL),(304,4,NULL,0.000,23.00,'LENTEJAS SECAS REMOJADAS SAN REMO 350G',1,NULL),(305,4,NULL,0.000,2.00,'MATE COCIDO TARAGÜÍ TARAGUI 25 SAQUITOS DE 3G',1,NULL),(306,4,NULL,0.000,19.00,'MAYONESA CADADÍA LIVIANA 118G',1,NULL),(307,4,NULL,0.000,8.00,'MAYONESA NATURA 237G',1,NULL),(308,4,NULL,0.000,13.00,'MAYONESA NATURA CHICA 118G',1,NULL),(309,4,NULL,0.000,99.00,'MERCEIR EXTRA BRUT CHAMPAGNE',1,NULL),(310,4,NULL,0.000,99.00,'MORA DURAZNOS',1,NULL),(311,4,NULL,0.000,3.00,'PASEO CHATITAS 140G',1,NULL),(312,4,NULL,0.000,3.00,'PATÉ DE FOIE PALADINI',1,NULL),(313,4,NULL,0.000,2.00,'PICADILLO DE CARNE PALADINI',1,NULL),(314,4,NULL,0.000,3.00,'POLENTA PRESTO PRONTA ARCOR 500G',1,NULL),(315,4,NULL,0.000,10.00,'POROTOS INCA 202G',1,NULL),(316,4,NULL,0.000,2.00,'ISAMAY DE TOMATE TRITURADO 950CC',1,NULL),(317,4,NULL,0.000,99.00,'PURÉ DE TOMATE MORA 520G',1,NULL),(318,4,NULL,0.000,8.00,'PURÉ DE TOMATES DE LA HUERTA BAGGIO 210G',1,NULL),(319,4,NULL,0.000,5.00,'PURÉ DE TOMATES DE LA HUERTA BAGGIO 530G',1,NULL),(320,4,NULL,0.000,6.00,'QUESO RALLADO LA PAULINA TRADICIONAL 40G',1,NULL),(321,4,NULL,0.000,5.00,'SAL FINA DOS ANCLAS 500G',1,NULL),(322,4,NULL,0.000,2.00,'SALSA LISTA KNOR PIZZA',1,NULL),(323,4,NULL,0.000,3.00,'SALSA LISTA KNOR POMAROLA',1,NULL),(324,4,NULL,0.000,7.00,'SAVORA ORIGINAL 60G',1,NULL),(325,4,NULL,0.000,11.00,'SIDRA REAL 910ML',1,NULL),(326,4,NULL,0.000,4.00,'SOL MAYOR ROLLOS DE COCINA X3',1,NULL),(327,4,NULL,0.000,1.00,'TAHITÍ SALSA DE AJÍ SUAVE 285G',1,NULL),(328,4,NULL,0.000,9.00,'TANG LIMONADA DULCE',1,NULL),(329,4,NULL,0.000,20.00,'TANG MULTIFRUTA',1,NULL),(330,4,NULL,0.000,4.00,'TANG NARANJA',1,NULL),(331,4,NULL,0.000,1.00,'TÉ DE BOLDO LA VIRGINIA 25 SAQUITOS',1,NULL),(332,4,NULL,0.000,2.00,'TÉ DE MANZANILLA LA VIRGINIA 25 SAQUITOS',1,NULL),(333,4,NULL,0.000,1.00,'TÉ DE TILO LA VIRGINIA 25 SAQUITOS',1,NULL),(334,4,NULL,0.000,2.00,'TÉ LA VIRGINIA 25 SAQUITOS',1,NULL),(335,4,NULL,0.000,99.00,'TOMATE ENTERO PELADO MORA',1,NULL),(336,4,NULL,0.000,4.00,'TWISTOS HORNEADOS MINITOSTADITAS CUATRO QUESOS 45G',1,NULL),(337,4,NULL,0.000,3.00,'TWISTOS HORNEADOS MINITOSTADITAS JAMÓN IBÉRICO 45G',1,NULL),(338,4,NULL,0.000,1.00,'VANOLI ACEITUNAS RELLENAS 200G',1,NULL),(339,4,NULL,0.000,1.00,'VANOLI AJÍES EN VINAGRE 130G',1,NULL),(340,4,NULL,0.000,2.00,'VANOLI LUPINES EN SALMUERA 220G',1,NULL),(341,4,NULL,0.000,1.00,'VANOLI PEPINILLOS EN VINAGRE 200G',1,NULL),(342,4,NULL,0.000,1.00,'VANOLI PICKLES MIXTOS EN VINAGRE 200G',1,NULL),(343,4,NULL,0.000,1.00,'FIDEOS KNORR CABELLO DE ANGEL 500G',1,NULL),(344,4,NULL,0.000,1.00,'FIDEOS JUAN CARLOS COLOMBIA CINTA FINA 500G',1,NULL),(345,4,NULL,0.000,99.00,'VINAGRE DE FRTUTA DE MANZANA HALCONES',1,NULL),(346,4,NULL,0.000,2.00,'VINO ALMA MORA FINCA LAS MORAS',1,NULL),(347,4,NULL,0.000,2.00,'VINO COLON MALBEC 2016',1,NULL),(348,4,NULL,0.000,3.00,'VINO COLON TORREONTES 2016',1,NULL),(349,4,NULL,0.000,2.00,'VINO DADÁ FINCA LAS MORAS VINTAGE 2017',1,NULL),(350,4,NULL,0.000,3.00,'VINO DON VALENTIN LACRADO ROBLES CABERNET SAUVIGNON',1,NULL),(351,4,NULL,0.000,3.00,'VINO FINCA LAS MORAS CABERNET 2015',1,NULL),(352,4,NULL,0.000,5.00,'VINO FINCA LAS MORAS SYRAH',1,NULL),(353,4,NULL,0.000,1.00,'VINO INTENSO MALBEC',1,NULL),(354,4,NULL,0.000,99.00,'VINO MALBEC SANTA JULIA',1,NULL),(355,4,NULL,0.000,1.00,'VINO MICHEL TORINO TRADICIONAL',1,NULL),(356,4,NULL,0.000,12.00,'VINO NORTON 1895 CLÁSICO',1,NULL),(357,4,NULL,0.000,4.00,'VINO NORTON 1895 CLÁSICO CHICO',1,NULL),(358,4,NULL,0.000,99.00,'VINO NORTON 1895 CLÁSICO',1,NULL),(359,4,NULL,0.000,5.00,'VINO SANTA ANA',1,NULL),(360,4,NULL,0.000,1.00,'VINO SANTA ANA CLÁSICO',1,NULL),(361,4,NULL,0.000,1.00,'VINO SANTA JULIA CABERNET SAUVIGNON',1,NULL),(362,4,NULL,0.000,5.00,'VINO SANTA JULIA MALBEC ',1,NULL),(363,4,NULL,0.000,4.00,'VINO ELEMENTOS TORRONTES',1,NULL),(364,4,NULL,0.000,8.00,'VINO MICHEL TORINO TINTO',1,NULL),(365,4,NULL,0.000,4.00,'VINO VALDERROBLES MAGNUN',1,NULL),(366,4,NULL,0.000,1.00,'VODKA BOLS FRUTILLA',1,NULL),(367,4,NULL,0.000,99.00,'WILDE CALDO DE VERDURAS',1,NULL),(368,4,NULL,0.000,5.00,'YERBA MATE AGUANTADORA TRADICIONAL 500G',1,NULL),(369,4,NULL,0.000,5.00,'YERBA MATE CBSÉ HIERBAS SERRANAS 500G',1,NULL),(370,4,NULL,0.000,4.00,'YERBA MATE ROSAMONTE CON PALO 500G',1,NULL),(371,4,NULL,0.000,16.00,'ALICANTE SABOR EN POLVO VERDURA',1,NULL),(372,4,NULL,0.000,3.00,'ALICANTE SABOR EN POLVO HONGOS',1,NULL),(373,4,NULL,0.000,4.00,'ALICANTE SABOR EN POLVO HIERBAS FINAS',1,NULL),(374,4,NULL,0.000,12.00,'ALICANTE SABOR EN POLVO ALBAHACA',1,NULL),(375,4,NULL,0.000,1.00,'BLEM NARANJA',1,NULL),(376,4,NULL,0.000,5.00,'FIDEOS JUAN CARLOS COLOMBIA CINTA GRUESA 500G',1,NULL),(377,4,NULL,0.000,5.00,'FIDEOS KNORR TIRABUZON 500G',1,NULL),(378,4,NULL,0.000,4.00,'FIDEOS KNORR MOSTACHOL 500G',1,NULL),(379,4,NULL,0.000,5.00,'FIDEOS KNORR TALLARINES 500G',1,NULL),(380,4,NULL,0.000,1.00,'9 DE JULIO MADGALENAS VAINILLA 210G',1,NULL),(381,4,NULL,0.000,1.00,'9 DE JULIO MADGALENAS VAINILLA CON DULCE DE LECHE 210G',1,NULL),(382,4,NULL,0.000,1.00,'ADEREZO TIPO MOSTAZA',1,NULL),(383,4,NULL,0.000,5.00,'ALICANTE CONDIMENTO PARA PREPARAR CHIMICHURRI 25G',1,NULL),(384,4,NULL,0.000,2.00,'ALICANTE CONDIMENTO PARA MILANESAS Y SUPREMAS 25G',1,NULL),(385,4,NULL,0.000,2.00,'ALICANTE CONDIMENTO AJI TRITURADO 25G',1,NULL),(386,4,NULL,0.000,4.00,'ALICANTE CONDIMENTO HIERBAS 25G',1,NULL),(387,4,NULL,0.000,1.00,'ALICANTE CONDIMENTO PIMENTON DULCE 25G',1,NULL),(388,4,NULL,0.000,5.00,'CAFÉ LA VIRGINIA CLASICO EN SOBRES',1,NULL),(389,4,NULL,0.000,15.00,'CAFÉ LA VIRGINIA CLASICO EN SAQUITOS',1,NULL),(390,4,NULL,0.000,10.00,'ARROZ TRIMACER LARGO FINO 500G',1,NULL),(391,4,NULL,0.000,7.00,'MERMELADA LA CAMPAGNOLA FRUTILLA',1,NULL),(392,4,NULL,0.000,2.00,'MERMELADA LA CAMPAGNOLA DURAZNO',1,NULL),(393,4,NULL,0.000,3.00,'CABALLA LA CAMPAGNOLA',1,NULL),(394,4,NULL,0.000,3.00,'LAYS CLASICAS 105G',1,NULL),(395,4,NULL,0.000,2.00,'LAYS QUESO Y CEBOLLA 105G',1,NULL),(396,4,NULL,0.000,3.00,'DORITOS QUESO 105G',1,NULL),(397,4,NULL,0.000,2.00,'LAYS JAMON SERRANO 95G',1,NULL),(398,4,NULL,0.000,3.00,'3D MEGATUBE QUESO 116G',1,NULL),(399,4,NULL,0.000,3.00,'CHEETOS CLASICOS 116G',1,NULL),(400,4,NULL,0.000,4.00,'CHEETOS CLASICOS 66G',1,NULL),(401,4,NULL,0.000,1.00,'3D MEGATUBE QUESO 66G',1,NULL),(402,4,NULL,0.000,2.00,'DORITOS QUESO 60G',1,NULL),(403,4,NULL,0.000,5.00,'LAYS CLASICAS 66G',1,NULL),(404,4,NULL,0.000,4.00,'PEHUAMAR MANI PELADO 90G',1,NULL),(405,4,NULL,0.000,1.00,'PEP PALITOS 40G',1,NULL),(406,4,NULL,0.000,8.00,'SABOR SPECIAL PARRILLADAS Y ASADO 250G',1,NULL),(407,4,NULL,0.000,7.00,'SABOR SPECIAL CARNES ROJAS Y SALSA 250G',1,NULL),(408,4,NULL,0.000,6.00,'SABOR SPECIAL POLLOS ARROZ Y PAELLA 250G',1,NULL),(409,4,NULL,0.000,3.00,'SABOR SPECIAL CERDOS 250G',1,NULL),(410,4,NULL,0.000,6.00,'SABOR SPECIAL PARRILLADAS Y ASADO 400G',1,NULL),(411,4,NULL,0.000,5.00,'SABOR SPECIAL CARNES ROJAS Y SALSA 400G',1,NULL),(412,4,NULL,0.000,3.00,'KESBUN PIZZA ESPECIAL DE JAMON 100G',1,NULL),(413,4,NULL,0.000,3.00,'KESBUN PIZZA ESPECIAL NAPOLITANA 100G',1,NULL),(414,4,NULL,0.000,3.00,'KESBUN PIZZA ESPECIAL FUGAZZETA 100G',1,NULL),(415,4,NULL,0.000,3.00,'TWISTOS SABOR QUESO CREAM 100G',1,NULL),(416,4,NULL,0.000,3.00,'GALLETITAS ZUCOA CACAO 150G',1,NULL),(417,4,NULL,0.000,3.00,'GALLETITAS ZUCOA VAINILLA 150G',1,NULL),(418,4,NULL,0.000,6.00,'CERVEZA QUILMES 1.2 LITROS',1,NULL),(419,4,NULL,0.000,11.00,'CERVEZA QUILMES 340CC LITROS',1,NULL),(420,4,NULL,0.000,6.00,'CERVEZA QUILMES BAJO CERO 1.2 LITROS',1,NULL),(421,4,NULL,0.000,7.00,'CERVEZA QUILMES STOUT 1 LITRO',1,NULL),(422,4,NULL,0.000,1.00,'CERVEZA QUILMES STOUT 473CC LATA',1,NULL),(423,4,NULL,0.000,1.00,'CERVEZA QUILMES CRISTAL 340CC',1,NULL),(424,4,NULL,0.000,11.00,'CERVEZA BRAHMITA 340CC',1,NULL),(425,4,NULL,0.000,6.00,'CERVEZA CORONA 355CC',1,NULL),(426,4,NULL,0.000,1.00,'CERVEZA SKOL 269CC LATA',1,NULL),(427,4,NULL,0.000,3.00,'CERVEZA STELLA ARTOIS 975CC',1,NULL),(428,4,NULL,0.000,7.00,'CERVEZA 1890 1 LITRO',1,NULL),(429,4,NULL,0.000,7.00,'GATORADE MANZANA 500CC',1,NULL),(430,4,NULL,0.000,6.00,'GATORADE FRUTAS TROPICALES 500CC',1,NULL),(431,4,NULL,0.000,11.00,'PEPSI 250CC',1,NULL),(432,4,NULL,0.000,6.00,'PEPSI 1.5 LITROS',1,NULL),(433,4,NULL,0.000,25.00,'PEPSI 500CC',1,NULL),(434,4,NULL,0.000,6.00,'PASO DE LOS TOROS POMELO 1.5 LITROS',1,NULL),(435,4,NULL,0.000,2.00,'PEPSI LIGHT 500CC',1,NULL),(436,4,NULL,0.000,12.00,'PASO DE LOS TOROS POMELO 500CC',1,NULL),(437,4,NULL,0.000,1.00,'7UP 1.5 LITROS',1,NULL),(438,4,NULL,0.000,21.00,'7UP 500CC',1,NULL),(439,4,NULL,0.000,11.00,'7UP 250CC',1,NULL),(440,4,NULL,0.000,1.00,'AGUA MINERAL ECO DE LOS ANDES 1.5 LITROS',1,NULL),(441,4,NULL,0.000,20.00,'AGUA MINERAL ECO DE LOS ANDES 500CC',1,NULL),(442,4,NULL,0.000,4.00,'H2OH! CITRUS 1.5 LITROS',1,NULL),(443,4,NULL,0.000,20.00,'H2OH! CITRUS 500CC',1,NULL),(444,4,NULL,0.000,4.00,'H2OH! NARANCHELO 1.5 LITROS',1,NULL),(445,4,NULL,0.000,9.00,'H2OH! LIMONETO 1.5 LITROS',1,NULL),(446,4,NULL,0.000,2.00,'CERVEZA PATAGONIA 710CC',1,NULL),(447,4,NULL,0.000,11.00,'COCA COLA 200ML',1,NULL),(448,4,NULL,0.000,7.00,'COCA COLA 2.25 LITROS',1,NULL),(449,4,NULL,0.000,1.00,'COCA COLA 500ML',1,NULL),(450,4,NULL,0.000,9.00,'COCA COLA 354ML LATA',1,NULL),(451,4,NULL,0.000,5.00,'COCA COLA SIN AZUCAR 1.5 LITROS',1,NULL),(452,4,NULL,0.000,4.00,'COCA COLA SIN AZUCAR 500ML',1,NULL),(453,4,NULL,0.000,9.00,'COCA COLA 1 LITRO',1,NULL),(454,4,NULL,0.000,5.00,'SPRITE 1.5 LITROS',1,NULL),(455,4,NULL,0.000,8.00,'SPRITE 354ML LATA',1,NULL),(456,4,NULL,0.000,8.00,'SPRITE 200ML',1,NULL),(457,4,NULL,0.000,4.00,'SPRITE 2.25 LITROS',1,NULL),(458,4,NULL,0.000,4.00,'FANTA 1.5 LITROS',1,NULL),(459,4,NULL,0.000,15.00,'FANTA 500ML',1,NULL),(460,4,NULL,0.000,8.00,'FANTA 354ML LATA',1,NULL),(461,4,NULL,0.000,9.00,'SCHWEPPES POMELO 354ML LATA',1,NULL),(462,4,NULL,0.000,7.00,'SCHWEPPES POMELO 1.5 LITROS',1,NULL),(463,4,NULL,0.000,1.00,'SCHWEPPES POMELO ZERO 1.5 LITROS',1,NULL),(464,4,NULL,0.000,2.00,'AGUA MINERAL BONAQUA 500ML',1,NULL),(465,4,NULL,0.000,1.00,'AGUA MINERAL BONAQUA 1.5 LITROS',1,NULL),(466,4,NULL,0.000,2.00,'AGUA MINERAL BONAQUA 2.25 LITROS',1,NULL),(467,4,NULL,0.000,3.00,'AQUARIUS NARANJA 500ML',1,NULL),(468,4,NULL,0.000,3.00,'POWERADE MOUNTAIN BLAST 500ML',1,NULL),(469,4,NULL,0.000,3.00,'POWERADE MANZANA 500ML',1,NULL),(470,4,NULL,0.000,4.00,'CEPITA DEL VALLE MULTIFRUTA 1 LITRO',1,NULL),(471,4,NULL,0.000,6.00,'CEPITA DEL VALLE NARANJA 1 LITRO',1,NULL),(472,4,NULL,0.000,4.00,'CEPITA DEL VALLE DURAZNO 1.5 LITROS',1,NULL),(473,4,NULL,0.000,2.00,'CEPITA DEL VALLE NARANJA 1.5 LITROS',1,NULL),(474,4,NULL,0.000,1.00,'AQUARIUS POMELO 1.5 LITROS',1,NULL),(475,4,NULL,0.000,5.00,'SABOR SPECIAL CHIMICHURRI TIPO CRIOLLO',1,NULL),(476,4,NULL,0.000,1.00,'GALLETITAS SERRANAS X3',1,NULL),(477,4,NULL,0.000,18.00,'JABON EN POLVO DRIVE HORTENSIAS',1,NULL),(478,4,NULL,0.000,13.00,'JABON EN POLVO DRIVE ROSAS',1,NULL),(479,4,NULL,0.000,1.00,'JABON ESPADOL',1,NULL),(480,4,NULL,0.000,1.00,'JABON VERITAS',1,NULL),(481,4,NULL,0.000,8.00,'KNORR CALDO SABOR 4 QUESOS',1,NULL),(482,4,NULL,0.000,3.00,'MYHOGAR ROLLO PAPEL X2',1,NULL),(483,4,NULL,0.000,1.00,'LENTEJAS INALPA',1,NULL),(484,4,NULL,0.000,2.00,'KNORR PURE DE PAPAS',1,NULL),(485,4,NULL,0.000,1.00,'KETCHUP CADADIA 250G',1,NULL),(486,4,NULL,0.000,4.00,'SALSA GOLF CADADIA250G',1,NULL),(487,4,NULL,0.000,10.00,'KNORR CALDO AZAFRAN Y TOMILLO',1,NULL),(488,4,NULL,0.000,18.00,'KNORR CALDO DE VERDURA',1,NULL),(489,4,NULL,0.000,18.00,'KNORR CALDO DE GALLINA AMARILLO',1,NULL),(490,4,NULL,0.000,4.00,'KNORR CALDO MOSTAZA Y VINO',1,NULL),(491,4,NULL,0.000,1.00,'POROTOS GUARDIA VIEJA',1,NULL),(492,4,NULL,0.000,9.00,'TANG DURAZNO',1,NULL),(493,4,NULL,0.000,21.00,'TANG NARANJA MANGO',1,NULL),(494,4,NULL,0.000,5.00,'SAL FINA CELUSAL 500G',1,NULL),(495,4,NULL,0.000,2.00,'VANOLI CEBOLLITAS EN VINAGRE 220G',1,NULL),(496,4,NULL,0.000,21.00,'VELAS MSI',1,NULL),(497,4,NULL,0.000,4.00,'VINAGRE DE ALCOHOL HALCONERO',1,NULL),(498,4,NULL,0.000,4.00,'VINO VALMONT',1,NULL),(499,4,NULL,0.000,5.00,'VINO VALDERROBLES VARIETALES',1,NULL),(500,4,NULL,0.000,2.00,'VINO SANTA JULIA 2013',1,NULL),(501,4,NULL,0.000,1.00,'VODKA NIKOV',1,NULL),(502,4,NULL,0.000,7.00,'YERBA MATE SINCERIDAD 500G',1,NULL),(503,4,NULL,0.000,1.00,'CHAMPAGNE MERCIER EXTRA BRUT',1,NULL),(504,4,NULL,0.000,2.00,'CHAMPAGNE CHANDON BRUT NATURE',1,NULL),(505,4,NULL,0.000,2.00,'BOLSA DE LEÑA',1,NULL),(506,4,NULL,0.000,11.00,'SAVORA ORIGINAL 250G',1,NULL),(507,4,NULL,0.000,4.00,'TWISTOS HORNEADOS MINITOSTADITAS CUATRO QUESOS 112G',1,NULL),(508,4,NULL,0.000,4.00,'TWISTOS HORNEADOS MINITOSTADITAS JAMÓN IBÉRICO 112G',1,NULL),(509,4,NULL,0.000,6.00,'VINO INTENSO CABERNET SAUVIGNON',1,NULL);
/*!40000 ALTER TABLE `producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productotipo`
--

DROP TABLE IF EXISTS `productotipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `productotipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productotipo`
--

LOCK TABLES `productotipo` WRITE;
/*!40000 ALTER TABLE `productotipo` DISABLE KEYS */;
INSERT INTO `productotipo` VALUES (1,'CAJA'),(2,'MINORISTA'),(3,'MAYORISTA'),(4,'KIOSCO');
/*!40000 ALTER TABLE `productotipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productoubicacion`
--

DROP TABLE IF EXISTS `productoubicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `productoubicacion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_producto` int(11) DEFAULT NULL,
  `id_garron` int(11) DEFAULT NULL,
  `id_ubicacion` int(11) NOT NULL,
  `peso` decimal(10,3) NOT NULL,
  `fecha_egreso` datetime DEFAULT NULL,
  `fecha_ingreso` datetime NOT NULL,
  `id_usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UQ_InventarioUbicacion_id_ubicacion` (`id`),
  KEY `id_producto` (`id_producto`),
  KEY `fk_ubi` (`id_ubicacion`)
) ENGINE=InnoDB AUTO_INCREMENT=190 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productoubicacion`
--

LOCK TABLES `productoubicacion` WRITE;
/*!40000 ALTER TABLE `productoubicacion` DISABLE KEYS */;
INSERT INTO `productoubicacion` VALUES (6,34,NULL,3,31.420,NULL,'2018-03-15 19:28:36',1,NULL),(7,7,NULL,2,6.930,NULL,'2018-03-15 19:28:36',1,NULL),(14,9,NULL,1,21.020,NULL,'2018-03-16 20:01:09',1,NULL),(16,9,NULL,3,48.560,NULL,'2018-03-16 20:43:04',1,NULL),(17,NULL,23,2,84.000,NULL,'2018-03-16 20:43:04',1,NULL),(18,9,NULL,2,0.900,NULL,'2018-03-16 21:08:21',1,NULL),(19,7,NULL,1,1.570,NULL,'2018-03-16 21:16:03',1,NULL),(20,NULL,24,4,534.000,NULL,'2018-03-16 21:16:20',1,NULL),(21,34,NULL,2,1.980,NULL,'2018-03-16 21:51:27',1,NULL),(22,34,NULL,1,1.600,NULL,'2018-03-16 21:51:27',1,NULL),(23,NULL,25,4,624.000,NULL,'2018-03-17 11:08:41',1,NULL),(24,NULL,26,4,32.580,NULL,'2018-03-17 11:11:52',1,NULL),(25,NULL,27,4,222.850,NULL,'2018-03-17 11:18:49',1,NULL),(27,NULL,28,2,0.000,'2018-05-05 16:26:27','2018-03-17 12:37:26',1,NULL),(28,NULL,29,4,234.000,NULL,'2018-03-19 17:34:09',1,NULL),(29,NULL,30,4,543.000,NULL,'2018-03-19 17:34:09',1,NULL),(31,NULL,31,2,3464.500,NULL,'2018-03-19 17:36:28',1,NULL),(34,NULL,32,4,147.250,NULL,'2018-03-19 19:07:13',1,NULL),(37,NULL,33,4,123.650,NULL,'2018-03-19 19:09:20',1,NULL),(39,26,NULL,4,0.000,'2018-04-17 20:49:19','2018-03-19 19:12:35',1,NULL),(40,NULL,34,4,44.254,NULL,'2018-03-19 19:12:35',1,NULL),(42,33,NULL,4,50.000,NULL,'2018-03-19 19:14:37',1,NULL),(43,NULL,35,4,22.000,NULL,'2018-03-19 19:14:37',1,NULL),(45,25,NULL,4,50.000,NULL,'2018-03-19 19:16:37',1,NULL),(47,NULL,36,2,0.000,'2018-05-02 18:58:20','2018-03-19 19:18:22',1,NULL),(49,45,NULL,4,50.000,NULL,'2018-03-19 19:31:18',1,NULL),(51,NULL,37,2,11.000,NULL,'2018-03-19 19:34:04',1,NULL),(55,NULL,38,2,12.000,NULL,'2018-03-19 19:59:28',1,NULL),(57,NULL,39,4,321.000,NULL,'2018-03-19 20:05:44',1,NULL),(59,15,NULL,4,22.000,NULL,'2018-03-19 20:24:54',1,NULL),(60,NULL,40,4,12.000,NULL,'2018-03-19 20:24:54',1,NULL),(63,NULL,41,4,112.250,NULL,'2018-03-19 20:45:17',1,NULL),(66,NULL,42,4,11.000,NULL,'2018-03-19 20:48:19',1,NULL),(70,NULL,43,4,251.000,NULL,'2018-03-19 20:55:59',1,NULL),(71,5,NULL,4,43.000,NULL,'2018-03-19 21:00:28',1,NULL),(72,19,NULL,4,31.000,NULL,'2018-03-19 21:00:28',1,NULL),(73,NULL,44,4,25.000,NULL,'2018-03-19 21:00:28',1,NULL),(74,6,NULL,4,52.000,NULL,'2018-03-19 21:49:31',1,NULL),(75,20,NULL,4,85.000,NULL,'2018-03-19 21:49:31',1,NULL),(76,NULL,45,4,254.000,NULL,'2018-03-19 21:49:31',1,NULL),(77,55,NULL,4,25.000,NULL,'2018-03-19 21:52:34',1,NULL),(78,65,NULL,4,85.000,NULL,'2018-03-19 21:52:34',1,NULL),(79,NULL,46,4,12.000,NULL,'2018-03-19 21:52:34',1,NULL),(80,8,NULL,4,36.250,NULL,'2018-03-19 22:28:40',1,NULL),(81,17,NULL,4,52.000,NULL,'2018-03-19 22:28:40',1,NULL),(82,NULL,47,4,55.000,NULL,'2018-03-19 22:28:40',1,NULL),(83,10,NULL,4,25.000,NULL,'2018-03-19 22:34:39',1,NULL),(85,NULL,48,4,11.250,NULL,'2018-03-19 22:34:39',1,NULL),(86,12,NULL,4,22.000,NULL,'2018-03-19 22:36:37',1,NULL),(87,13,NULL,4,23.500,NULL,'2018-03-19 22:36:37',1,NULL),(88,NULL,49,4,12.000,NULL,'2018-03-19 22:36:37',1,NULL),(92,6,NULL,1,52.000,NULL,'2018-03-19 22:39:15',1,NULL),(93,8,NULL,3,88.000,NULL,'2018-03-19 22:39:30',1,NULL),(98,NULL,52,4,125.000,NULL,'2018-03-19 22:43:46',1,NULL),(101,NULL,53,4,1524.250,NULL,'2018-03-19 22:46:45',1,NULL),(102,10,NULL,1,160.360,NULL,'2018-03-19 22:47:38',1,NULL),(104,NULL,54,3,22.000,NULL,'2018-03-19 22:49:46',1,NULL),(105,7,NULL,4,52.000,NULL,'2018-03-19 22:51:03',1,NULL),(106,16,NULL,4,48.000,NULL,'2018-03-19 22:51:03',1,NULL),(107,NULL,55,4,11.250,NULL,'2018-03-19 22:51:03',1,NULL),(109,NULL,56,4,1.000,NULL,'2018-03-19 22:54:31',1,NULL),(111,NULL,57,4,52.000,NULL,'2018-03-19 23:00:05',1,NULL),(113,14,NULL,4,145.000,NULL,'2018-03-19 23:03:41',1,NULL),(114,NULL,58,4,11.000,NULL,'2018-03-19 23:03:41',1,NULL),(115,16,NULL,1,52.000,NULL,'2018-03-19 23:04:07',1,NULL),(116,14,NULL,3,145.000,NULL,'2018-03-19 23:04:09',1,NULL),(118,NULL,59,4,12.000,NULL,'2018-03-21 17:46:09',1,NULL),(120,NULL,60,4,11.000,NULL,'2018-03-21 18:00:09',1,NULL),(121,28,NULL,4,50.000,NULL,'2018-03-21 18:01:29',1,NULL),(122,NULL,61,4,12.000,NULL,'2018-03-21 18:01:29',1,NULL),(125,NULL,62,2,125.000,NULL,'2018-03-21 18:04:27',1,NULL),(126,21,NULL,4,0.000,'2018-03-21 19:58:57','2018-03-21 19:56:59',1,NULL),(128,NULL,63,4,0.000,'2018-03-21 19:58:57','2018-03-21 19:57:08',1,NULL),(129,NULL,64,4,0.000,'2018-03-21 19:58:57','2018-03-21 19:57:10',1,NULL),(130,NULL,65,4,0.000,'2018-03-21 19:58:57','2018-03-21 19:57:12',1,NULL),(131,21,NULL,1,24.000,NULL,'2018-03-21 19:58:57',1,NULL),(132,23,NULL,1,25.000,NULL,'2018-03-21 19:58:57',1,NULL),(133,NULL,63,3,123.000,NULL,'2018-03-21 19:58:57',1,NULL),(134,NULL,64,3,123.000,NULL,'2018-03-21 19:58:57',1,NULL),(135,NULL,65,2,356.250,NULL,'2018-03-21 19:58:57',1,NULL),(137,NULL,66,4,0.000,'2018-03-22 17:07:45','2018-03-22 17:06:45',1,NULL),(138,12,NULL,3,20.000,NULL,'2018-03-22 17:07:45',1,NULL),(139,NULL,66,2,0.000,'2018-05-05 16:23:21','2018-03-22 17:07:45',1,NULL),(140,30,NULL,2,14.250,NULL,'2018-03-29 16:53:32',1,NULL),(141,24,NULL,3,235.000,NULL,'2018-03-29 16:53:43',1,NULL),(142,3,NULL,2,37.280,NULL,'2018-03-29 16:56:07',1,NULL),(143,2,NULL,1,0.000,'2018-04-10 17:45:27','2018-03-29 16:58:40',1,NULL),(144,10,NULL,2,36.500,NULL,'2018-03-29 16:59:30',1,NULL),(145,5,NULL,3,53.360,NULL,'2018-03-29 20:20:51',1,NULL),(146,7,NULL,3,1.000,NULL,'2018-03-29 20:21:11',1,NULL),(147,6,NULL,3,0.200,NULL,'2018-03-29 20:33:39',1,NULL),(148,15,NULL,1,125.000,NULL,'2018-03-29 20:45:21',1,NULL),(149,27,NULL,3,10.000,NULL,'2018-03-29 20:48:23',1,NULL),(150,4,NULL,2,21.110,NULL,'2018-03-29 20:53:09',1,NULL),(151,2,NULL,4,7.000,NULL,'2018-03-29 20:53:09',1,NULL),(152,4,NULL,1,1.500,NULL,'2018-03-29 22:23:37',1,NULL),(153,44,NULL,4,0.000,'2018-04-05 16:56:54','2018-04-05 16:55:16',1,NULL),(154,49,NULL,4,0.000,'2018-04-05 16:57:00','2018-04-05 16:55:16',1,NULL),(155,46,NULL,4,0.000,'2018-04-05 16:57:06','2018-04-05 16:55:16',1,NULL),(156,NULL,67,4,0.000,'2018-04-05 16:57:12','2018-04-05 16:55:16',1,NULL),(157,NULL,68,4,0.000,'2018-04-05 16:57:15','2018-04-05 16:55:16',1,NULL),(158,44,NULL,1,26.000,NULL,'2018-04-05 16:56:57',1,NULL),(159,49,NULL,3,29.630,NULL,'2018-04-05 16:57:03',1,NULL),(160,46,NULL,1,63.000,NULL,'2018-04-05 16:57:09',1,NULL),(161,NULL,67,3,256.250,NULL,'2018-04-05 16:57:12',1,NULL),(162,NULL,68,2,122.000,NULL,'2018-04-05 16:57:15',1,NULL),(163,46,NULL,4,253.250,NULL,'2018-04-09 18:30:03',1,NULL),(164,47,NULL,4,200.000,NULL,'2018-04-09 18:30:05',1,NULL),(165,NULL,69,4,361.250,NULL,'2018-04-09 18:30:10',1,NULL),(166,NULL,70,4,233.000,NULL,'2018-04-09 18:30:13',1,NULL),(167,NULL,71,4,0.000,'2018-04-09 18:39:56','2018-04-09 18:39:45',1,NULL),(168,NULL,71,2,0.000,'2018-05-05 15:21:37','2018-04-09 18:39:56',1,NULL),(169,44,NULL,4,37.360,NULL,'2018-04-09 19:09:29',1,NULL),(170,51,NULL,4,63.000,NULL,'2018-04-09 19:09:29',1,NULL),(171,NULL,72,4,112.000,NULL,'2018-04-09 19:09:29',1,NULL),(172,2,NULL,2,7.000,NULL,'2018-04-10 17:45:27',1,NULL),(173,4,NULL,3,5.250,NULL,'2018-04-10 17:46:09',1,NULL),(174,23,NULL,2,125.250,NULL,'2018-04-11 18:29:33',1,NULL),(175,1,NULL,3,25.360,NULL,'2018-04-13 20:08:07',1,NULL),(176,22,NULL,4,-93.000,NULL,'2018-03-19 19:16:37',1,NULL),(177,23,NULL,4,89.000,NULL,'2018-03-19 19:16:37',1,NULL),(178,24,NULL,4,4.740,NULL,'2018-03-19 19:16:37',1,NULL),(179,27,NULL,4,50.000,NULL,'2018-03-19 19:16:37',1,NULL),(180,29,NULL,4,2.000,NULL,'2018-03-19 19:16:37',1,NULL),(182,26,NULL,4,-19.720,NULL,'2018-04-17 20:54:25',1,NULL),(183,35,NULL,4,50.000,NULL,'2018-04-19 17:59:27',1,NULL),(184,46,NULL,4,20.000,NULL,'2018-04-19 17:59:27',1,NULL),(185,44,NULL,4,15.000,NULL,'2018-04-19 18:04:12',1,NULL),(186,46,NULL,4,350.000,NULL,'2018-04-19 18:04:12',1,NULL),(187,44,NULL,2,13.000,NULL,'2018-04-24 23:28:10',1,NULL),(188,48,NULL,4,12.000,NULL,'2018-04-27 18:25:27',1,NULL),(189,37,NULL,4,25.000,NULL,'2018-04-27 18:25:27',1,NULL);
/*!40000 ALTER TABLE `productoubicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedor`
--

DROP TABLE IF EXISTS `proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `proveedor` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `razon_social` varchar(100) NOT NULL,
  `domicilio` varchar(50) NOT NULL,
  `localidad` varchar(30) NOT NULL,
  `civa` varchar(3) NOT NULL,
  `nombre_local` varchar(50) NOT NULL,
  `cuit` varchar(15) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `nombre_responsable` varchar(50) DEFAULT NULL,
  `fecha_desde` date DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (1,'Friar','santiago del estero 1234','santa fe','RI','Friar S.A.','20-12345678-1','034212345678','Federico Lopez','2017-11-16',NULL,NULL),(2,'Frigar','urquiza 1810','santa fe','CF','LOCAL','20315634231','3239487','HUGO','2017-11-17',NULL,0),(3,'este proveedor','provsad','prov','poa','orpo','ops','por','poasdp','2017-11-24',NULL,0),(4,'CompraProveedor','dire prove 123','santa fe','CF','Local Santiago','20329590934','4258','Santiago','2017-10-16',NULL,1);
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedorcuenta`
--

DROP TABLE IF EXISTS `proveedorcuenta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `proveedorcuenta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cbu` varchar(40) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `id_proveedor` int(11) DEFAULT NULL,
  `fecha_updated` datetime DEFAULT NULL,
  `id_banco` int(11) DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedorcuenta`
--

LOCK TABLES `proveedorcuenta` WRITE;
/*!40000 ALTER TABLE `proveedorcuenta` DISABLE KEYS */;
INSERT INTO `proveedorcuenta` VALUES (1,'1238238923892234','EFECTIVO',1,'2017-11-12 19:53:42',1,1,NULL),(2,'1238238923892236','EFECTIVO',1,'2017-11-12 19:53:39',2,1,NULL),(3,'2222','EFECTIVO',2,'2017-11-12 19:53:29',4,0,NULL),(4,'aaa','EFECTIVO',2,'2017-11-12 19:53:32',3,0,NULL),(5,'52145312','EFECTIVO',3,'2017-11-16 17:36:32',1,0,NULL),(6,'12313','EFECTIVO',3,'2017-11-16 17:51:57',1,0,NULL),(7,'1234','EFECTIVO',4,'2017-11-29 09:17:12',1,0,NULL),(8,'1234','EFECTIVO',4,'2017-11-29 09:18:04',1,0,NULL);
/*!40000 ALTER TABLE `proveedorcuenta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedorcuentamovimiento`
--

DROP TABLE IF EXISTS `proveedorcuentamovimiento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `proveedorcuentamovimiento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_operacion` int(11) NOT NULL DEFAULT '0',
  `id_cuenta` int(11) NOT NULL,
  `id_movimiento_tipo` int(11) NOT NULL COMMENT '1 - DEBE| 2 - HABER',
  `monto` double NOT NULL,
  `fecha` datetime NOT NULL,
  `cobrado` char(1) NOT NULL DEFAULT 'N',
  `usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_movtipo` (`id_movimiento_tipo`),
  CONSTRAINT `proveedorcuentamovimiento_ibfk_2` FOREIGN KEY (`id_movimiento_tipo`) REFERENCES `movimientotipo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedorcuentamovimiento`
--

LOCK TABLES `proveedorcuentamovimiento` WRITE;
/*!40000 ALTER TABLE `proveedorcuentamovimiento` DISABLE KEYS */;
INSERT INTO `proveedorcuentamovimiento` VALUES (1,1,1,1,600,'2017-11-14 17:24:30','N',0),(2,1,1,2,600,'2017-11-15 11:54:13','N',1),(3,1,3,1,500,'2017-11-15 11:55:15','N',1),(4,1,3,2,1000,'2017-11-15 12:00:06','N',1),(5,0,1,1,11,'2018-03-09 12:48:20','N',1),(6,0,1,1,22,'2018-03-09 12:52:13','N',1),(7,16,4,1,12179.97,'2018-04-09 18:29:19','N',1),(8,16,4,2,12179.97,'2018-04-09 18:29:34','S',1),(9,8,4,1,256.36,'2018-04-09 18:39:45','N',1),(10,8,4,2,100,'2018-04-09 18:39:45','S',1),(11,9,1,1,7950.76,'2018-04-09 19:09:29','N',1),(12,9,1,2,7950.76,'2018-04-09 19:09:29','S',1),(13,10,1,1,3751.25,'2018-04-19 17:59:27','N',1),(14,10,1,2,3751.25,'2018-04-19 17:59:27','S',1),(15,11,4,1,2897.74,'2018-04-19 18:04:12','N',1),(16,11,4,2,2897.74,'2018-04-19 18:04:12','S',1);
/*!40000 ALTER TABLE `proveedorcuentamovimiento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ubicacion`
--

DROP TABLE IF EXISTS `ubicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ubicacion` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `entrada` int(1) DEFAULT NULL,
  `salida` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ubicacion`
--

LOCK TABLES `ubicacion` WRITE;
/*!40000 ALTER TABLE `ubicacion` DISABLE KEYS */;
INSERT INTO `ubicacion` VALUES (1,'SALON DE VENTAS',0,1),(2,'CAMARA GRANDE',0,0),(3,'CAMARA CHICA',0,0),(4,'DEPOSITO',1,0);
/*!40000 ALTER TABLE `ubicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(20) CHARACTER SET latin1 NOT NULL,
  `pass` varchar(20) CHARACTER SET latin1 NOT NULL,
  `nombre` varchar(50) CHARACTER SET latin1 DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'a','a','aa'),(2,'prueba','prueba','prueba');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarioingreso`
--

DROP TABLE IF EXISTS `usuarioingreso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuarioingreso` (
  `id` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_use` (`id_usuario`),
  CONSTRAINT `fk_use` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarioingreso`
--

LOCK TABLES `usuarioingreso` WRITE;
/*!40000 ALTER TABLE `usuarioingreso` DISABLE KEYS */;
INSERT INTO `usuarioingreso` VALUES (1,1,'2017-09-02','11:26:00');
/*!40000 ALTER TABLE `usuarioingreso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuariomodulo`
--

DROP TABLE IF EXISTS `usuariomodulo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuariomodulo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_usuario` int(11) NOT NULL,
  `id_modulo` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_mod` (`id_modulo`),
  KEY `fk_us` (`id_usuario`),
  CONSTRAINT `fk_mod` FOREIGN KEY (`id_modulo`) REFERENCES `modulo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_us` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuariomodulo`
--

LOCK TABLES `usuariomodulo` WRITE;
/*!40000 ALTER TABLE `usuariomodulo` DISABLE KEYS */;
INSERT INTO `usuariomodulo` VALUES (1,1,1),(2,1,2),(4,1,4),(5,1,7),(6,1,9),(7,1,10),(8,1,11),(15,2,12),(16,2,1),(17,2,2),(18,2,4),(19,2,9),(20,2,11),(23,1,13),(24,1,6),(25,1,14),(26,1,15),(27,1,16),(28,1,17),(29,1,18),(30,1,5),(33,1,9),(34,1,19);
/*!40000 ALTER TABLE `usuariomodulo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venta`
--

DROP TABLE IF EXISTS `venta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `venta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `monto_total` decimal(10,3) NOT NULL,
  `fecha` datetime NOT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  `id_operacion` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venta`
--

LOCK TABLES `venta` WRITE;
/*!40000 ALTER TABLE `venta` DISABLE KEYS */;
INSERT INTO `venta` VALUES (2,2541.000,'2018-01-24 12:03:13',1,NULL,1),(3,153.000,'2018-01-25 10:28:39',1,NULL,0),(4,88.000,'2018-01-25 10:32:52',1,NULL,0),(5,1958.000,'2018-01-25 10:39:15',1,NULL,3),(6,1306.000,'2018-01-25 10:48:13',1,NULL,4),(7,3828.000,'2018-01-25 11:45:54',1,NULL,5),(8,12782.000,'2018-01-29 12:45:55',1,NULL,6),(9,1590.000,'2018-03-01 10:34:53',1,NULL,7),(10,2640.000,'2018-03-02 09:51:48',1,NULL,8),(11,89.000,'2018-03-02 10:13:56',1,NULL,9),(12,77.000,'2018-03-02 10:41:17',1,NULL,10),(13,5123.000,'2018-03-02 12:23:39',1,NULL,11),(14,35310.000,'2018-03-02 12:44:07',1,NULL,12),(15,7872.000,'2018-03-02 12:45:42',1,NULL,13),(16,88.000,'2018-03-02 13:05:37',1,NULL,14),(17,4303.000,'2018-04-07 18:53:57',1,NULL,0),(18,169.500,'2018-04-13 20:11:46',1,NULL,0),(19,9570.000,'2018-04-17 19:03:56',1,NULL,17),(20,9920.000,'2018-04-17 19:10:59',1,NULL,18),(21,3700.000,'2018-04-17 19:22:17',1,NULL,19),(22,5200.000,'2018-04-17 19:28:41',1,NULL,20),(23,6800.000,'2018-04-17 19:29:46',1,NULL,21),(24,4200.000,'2018-04-17 20:31:27',1,NULL,22),(25,50.000,'2018-04-17 20:33:37',1,NULL,23),(26,6000.000,'2018-04-17 20:49:19',1,NULL,24),(27,4850.000,'2018-04-21 22:56:39',1,NULL,25),(28,2658.250,'2018-04-27 20:27:16',1,NULL,26),(29,1018.250,'2018-04-27 20:28:50',1,NULL,27),(30,578.730,'2018-04-27 20:30:24',1,NULL,28),(31,3524.250,'2018-05-02 18:44:20',1,NULL,29),(32,2581.250,'2018-05-02 18:57:44',1,NULL,30),(33,5248.000,'2018-05-05 15:21:24',1,NULL,31),(34,2514.250,'2018-05-05 16:19:19',1,NULL,32),(35,555.000,'2018-05-05 16:20:49',1,NULL,33),(36,258.360,'2018-05-05 16:22:57',1,NULL,34),(37,12332.000,'2018-05-05 16:23:38',1,NULL,35),(38,3625.250,'2018-05-05 16:24:40',1,NULL,36),(39,326.250,'2018-05-05 16:26:22',1,NULL,37),(40,8960.000,'2018-07-10 15:10:01',1,NULL,38),(41,2754.000,'2018-07-10 15:56:32',1,NULL,39);
/*!40000 ALTER TABLE `venta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ventadetalle`
--

DROP TABLE IF EXISTS `ventadetalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ventadetalle` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_venta` int(11) NOT NULL,
  `id_producto` int(11) DEFAULT NULL,
  `id_garron` int(11) DEFAULT NULL,
  `monto` decimal(10,3) NOT NULL,
  `peso` decimal(10,3) DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_liquidacion` (`id_venta`),
  KEY `fk_produ` (`id_producto`)
) ENGINE=InnoDB AUTO_INCREMENT=235 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ventadetalle`
--

LOCK TABLES `ventadetalle` WRITE;
/*!40000 ALTER TABLE `ventadetalle` DISABLE KEYS */;
INSERT INTO `ventadetalle` VALUES (4,0,1,NULL,105.000,0.000,1,NULL),(5,0,2,NULL,328.000,1.000,1,NULL),(6,0,3,NULL,674.000,3.000,1,NULL),(7,0,3,NULL,674.000,3.000,1,NULL),(8,0,2,NULL,328.000,1.000,1,NULL),(9,0,1,NULL,105.000,0.000,1,NULL),(10,0,3,NULL,674.000,3.000,1,NULL),(11,0,2,NULL,328.000,1.000,1,NULL),(12,0,1,NULL,105.000,0.000,1,NULL),(13,4,3,NULL,674.000,3.000,1,NULL),(14,4,2,NULL,328.000,1.000,1,NULL),(15,4,1,NULL,105.000,0.000,1,NULL),(16,5,1,NULL,105.000,0.000,1,NULL),(17,6,3,NULL,674.525,3.646,1,NULL),(18,6,2,NULL,328.349,1.427,1,NULL),(19,6,1,NULL,105.130,0.725,1,NULL),(20,7,1,NULL,105.130,0.725,1,NULL),(21,7,2,NULL,451.294,1.962,1,NULL),(22,7,3,NULL,553.618,2.992,1,NULL),(23,8,2,NULL,451.294,1.962,1,NULL),(24,8,3,NULL,553.618,2.992,1,NULL),(25,8,2,NULL,748.952,3.256,1,NULL),(26,8,1,NULL,105.130,0.725,1,NULL),(27,9,1,NULL,105.130,0.725,1,NULL),(28,9,1,NULL,105.130,0.725,1,NULL),(29,9,1,NULL,105.130,0.725,1,NULL),(30,9,1,NULL,105.130,0.725,1,NULL),(31,9,1,NULL,105.130,0.725,1,NULL),(32,9,1,NULL,105.130,0.725,1,NULL),(33,10,1,NULL,105.130,0.725,1,NULL),(34,10,1,NULL,105.130,0.725,1,NULL),(35,10,1,NULL,105.130,0.725,1,NULL),(36,10,1,NULL,105.130,0.725,1,NULL),(37,10,1,NULL,105.130,0.725,1,NULL),(38,10,1,NULL,105.130,0.725,1,NULL),(39,10,1,NULL,105.130,0.725,1,NULL),(40,10,1,NULL,105.130,0.725,1,NULL),(41,10,1,NULL,105.130,0.725,1,NULL),(42,10,1,NULL,105.130,0.725,1,NULL),(43,10,1,NULL,105.130,0.725,1,NULL),(44,10,1,NULL,105.130,0.725,1,NULL),(45,11,1,NULL,105.130,0.725,1,NULL),(46,11,1,NULL,105.130,0.725,1,NULL),(47,11,1,NULL,105.130,0.725,1,NULL),(48,11,1,NULL,105.130,0.725,1,NULL),(49,11,1,NULL,105.130,0.725,1,NULL),(50,11,1,NULL,105.130,0.725,1,NULL),(51,11,1,NULL,105.130,0.725,1,NULL),(52,11,1,NULL,105.130,0.725,1,NULL),(53,11,1,NULL,105.130,0.725,1,NULL),(54,11,1,NULL,105.130,0.725,1,NULL),(55,11,1,NULL,105.130,0.725,1,NULL),(56,11,1,NULL,105.130,0.725,1,NULL),(57,11,1,NULL,105.130,0.725,1,NULL),(58,11,1,NULL,105.130,0.725,1,NULL),(59,11,1,NULL,105.130,0.725,1,NULL),(60,11,1,NULL,105.130,0.725,1,NULL),(61,11,1,NULL,105.130,0.725,1,NULL),(62,12,1,NULL,105.130,0.725,1,NULL),(63,12,1,NULL,105.130,0.725,1,NULL),(64,12,1,NULL,105.130,0.725,1,NULL),(65,12,2,NULL,451.294,1.962,1,NULL),(66,12,3,NULL,553.618,2.992,1,NULL),(67,12,2,NULL,748.952,3.256,1,NULL),(68,13,2,NULL,748.952,3.256,1,NULL),(69,13,2,NULL,451.294,1.962,1,NULL),(70,13,3,NULL,553.618,2.992,1,NULL),(71,13,3,NULL,553.618,2.992,1,NULL),(72,14,35,NULL,105.130,0.725,1,NULL),(73,14,35,NULL,105.130,0.725,1,NULL),(74,14,39,NULL,703.127,4.849,1,NULL),(75,14,35,NULL,311.912,2.151,1,NULL),(76,14,23,NULL,748.952,5.547,1,NULL),(77,14,6,NULL,178.621,2.101,1,NULL),(78,15,6,NULL,178.621,2.101,1,NULL),(79,15,6,NULL,178.621,2.101,1,NULL),(80,15,6,NULL,178.621,2.101,1,NULL),(81,15,6,NULL,178.621,2.101,1,NULL),(82,15,6,NULL,178.621,2.101,1,NULL),(83,15,6,NULL,178.621,2.101,1,NULL),(84,15,6,NULL,178.621,2.101,1,NULL),(85,15,6,NULL,178.621,2.101,1,NULL),(86,15,6,NULL,178.621,2.101,1,NULL),(87,15,6,NULL,178.621,2.101,1,NULL),(88,15,6,NULL,178.621,2.101,1,NULL),(89,15,6,NULL,178.621,2.101,1,NULL),(90,15,6,NULL,178.621,2.101,1,NULL),(91,15,6,NULL,451.294,5.309,1,NULL),(92,15,6,NULL,451.294,5.309,1,NULL),(93,15,6,NULL,451.294,5.309,1,NULL),(94,15,6,NULL,451.294,5.309,1,NULL),(95,15,6,NULL,451.294,5.309,1,NULL),(96,15,6,NULL,451.294,5.309,1,NULL),(97,15,6,NULL,451.294,5.309,1,NULL),(98,15,23,NULL,748.952,5.547,1,NULL),(99,15,23,NULL,748.952,5.547,1,NULL),(100,15,23,NULL,748.952,5.547,1,NULL),(101,15,23,NULL,748.952,5.547,1,NULL),(102,15,23,NULL,748.952,5.547,1,NULL),(103,15,23,NULL,748.952,5.547,1,NULL),(104,15,23,NULL,748.952,5.547,1,NULL),(105,15,23,NULL,748.952,5.547,1,NULL),(106,15,23,NULL,748.952,5.547,1,NULL),(107,15,23,NULL,748.952,5.547,1,NULL),(108,15,23,NULL,748.952,5.547,1,NULL),(109,15,23,NULL,748.952,5.547,1,NULL),(110,15,23,NULL,748.952,5.547,1,NULL),(111,15,23,NULL,748.952,5.547,1,NULL),(112,15,23,NULL,748.952,5.547,1,NULL),(113,15,23,NULL,748.952,5.547,1,NULL),(114,15,23,NULL,748.952,5.547,1,NULL),(115,15,23,NULL,748.952,5.547,1,NULL),(116,15,35,NULL,311.912,2.151,1,NULL),(117,15,35,NULL,311.912,2.151,1,NULL),(118,15,35,NULL,311.912,2.151,1,NULL),(119,15,35,NULL,311.912,2.151,1,NULL),(120,15,35,NULL,311.912,2.151,1,NULL),(121,15,35,NULL,311.912,2.151,1,NULL),(122,15,23,NULL,748.952,5.547,1,NULL),(123,15,23,NULL,748.952,5.547,1,NULL),(124,15,23,NULL,748.952,5.547,1,NULL),(125,15,23,NULL,748.952,5.547,1,NULL),(126,15,23,NULL,748.952,5.547,1,NULL),(127,15,23,NULL,748.952,5.547,1,NULL),(128,15,23,NULL,748.952,5.547,1,NULL),(129,15,23,NULL,748.952,5.547,1,NULL),(130,15,23,NULL,748.952,5.547,1,NULL),(131,15,39,NULL,703.127,4.849,1,NULL),(132,15,39,NULL,703.127,4.849,1,NULL),(133,15,39,NULL,703.127,4.849,1,NULL),(134,15,39,NULL,703.127,4.849,1,NULL),(135,15,39,NULL,703.127,4.849,1,NULL),(136,15,39,NULL,703.127,4.849,1,NULL),(137,15,39,NULL,703.127,4.849,1,NULL),(138,15,39,NULL,703.127,4.849,1,NULL),(139,15,39,NULL,703.127,4.849,1,NULL),(140,15,39,NULL,703.127,4.849,1,NULL),(141,15,23,NULL,748.952,5.547,1,NULL),(142,15,23,NULL,748.952,5.547,1,NULL),(143,15,23,NULL,748.952,5.547,1,NULL),(144,15,23,NULL,748.952,5.547,1,NULL),(145,15,23,NULL,748.952,5.547,1,NULL),(146,15,23,NULL,748.952,5.547,1,NULL),(147,15,23,NULL,748.952,5.547,1,NULL),(148,15,23,NULL,748.952,5.547,1,NULL),(149,15,35,NULL,311.912,2.151,1,NULL),(150,15,35,NULL,311.912,2.151,1,NULL),(151,15,35,NULL,311.912,2.151,1,NULL),(152,15,35,NULL,311.912,2.151,1,NULL),(153,15,35,NULL,311.912,2.151,1,NULL),(154,15,35,NULL,311.912,2.151,1,NULL),(155,15,35,NULL,311.912,2.151,1,NULL),(156,15,35,NULL,311.912,2.151,1,NULL),(157,15,35,NULL,311.912,2.151,1,NULL),(158,15,23,NULL,748.952,5.547,1,NULL),(159,15,23,NULL,748.952,5.547,1,NULL),(160,15,23,NULL,748.952,5.547,1,NULL),(161,15,23,NULL,748.952,5.547,1,NULL),(162,15,23,NULL,748.952,5.547,1,NULL),(163,15,23,NULL,748.952,5.547,1,NULL),(164,25,35,NULL,311.912,2.151,1,NULL),(165,25,35,NULL,311.912,2.151,1,NULL),(166,25,35,NULL,311.912,2.151,1,NULL),(167,25,35,NULL,311.912,2.151,1,NULL),(168,25,35,NULL,311.912,2.151,1,NULL),(169,25,35,NULL,311.912,2.151,1,NULL),(170,25,35,NULL,311.912,2.151,1,NULL),(171,25,35,NULL,311.912,2.151,1,NULL),(172,26,24,NULL,207.360,1.481,1,NULL),(173,26,24,NULL,207.360,1.481,1,NULL),(174,26,24,NULL,207.360,1.481,1,NULL),(175,26,24,NULL,207.360,1.481,1,NULL),(176,26,24,NULL,207.360,1.481,1,NULL),(177,26,24,NULL,207.360,1.481,1,NULL),(178,26,24,NULL,207.360,1.481,1,NULL),(179,26,24,NULL,207.360,1.481,1,NULL),(207,18,5,NULL,85.250,5.360,1,NULL),(208,18,10,NULL,84.250,6.360,1,NULL),(209,19,26,NULL,2600.000,25.000,1,NULL),(210,20,26,NULL,2500.000,24.000,1,NULL),(211,20,33,NULL,700.000,14.000,1,NULL),(212,20,28,NULL,6720.000,50.000,1,NULL),(213,21,25,NULL,3700.000,50.000,1,NULL),(214,22,26,NULL,5200.000,50.000,1,NULL),(215,23,28,NULL,6800.000,50.000,1,NULL),(216,24,23,NULL,2200.000,45.000,1,NULL),(217,24,24,NULL,2000.000,48.000,1,NULL),(218,25,23,NULL,50.000,5.000,1,NULL),(219,26,26,NULL,6000.000,50.000,1,NULL),(220,27,22,NULL,4800.000,48.000,1,NULL),(221,27,24,NULL,50.000,35.260,1,NULL),(222,28,NULL,63,258.250,123.000,1,NULL),(223,29,NULL,40,268.250,12.000,1,NULL),(224,30,NULL,30,258.250,543.000,1,NULL),(225,30,29,NULL,320.480,48.000,1,NULL),(226,31,NULL,37,3524.250,0.550,1,NULL),(227,32,NULL,36,2581.250,2.000,1,NULL),(228,33,NULL,71,5248.000,14.000,1,NULL),(229,36,NULL,66,258.360,245.000,1,NULL),(230,39,NULL,28,326.250,66.580,1,NULL),(231,40,22,NULL,8360.000,95.000,1,NULL),(232,40,24,NULL,600.000,10.000,1,NULL),(233,41,23,NULL,550.000,11.000,1,NULL),(234,41,26,NULL,2204.000,20.000,1,NULL);
/*!40000 ALTER TABLE `ventadetalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `vistacompra`
--

DROP TABLE IF EXISTS `vistacompra`;
/*!50001 DROP VIEW IF EXISTS `vistacompra`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistacompra` AS SELECT 
 1 AS `id`,
 1 AS `id_operacion`,
 1 AS `codigo`,
 1 AS `descripcion`,
 1 AS `peso`,
 1 AS `monto`,
 1 AS `monto_total`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `vistacompraseleccionada`
--

DROP TABLE IF EXISTS `vistacompraseleccionada`;
/*!50001 DROP VIEW IF EXISTS `vistacompraseleccionada`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistacompraseleccionada` AS SELECT 
 1 AS `id`,
 1 AS `id_operacion`,
 1 AS `id_proveedor`,
 1 AS `codigo`,
 1 AS `descripcion`,
 1 AS `peso`,
 1 AS `monto`,
 1 AS `monto_total`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `vistalistadomovimientosclientes`
--

DROP TABLE IF EXISTS `vistalistadomovimientosclientes`;
/*!50001 DROP VIEW IF EXISTS `vistalistadomovimientosclientes`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistalistadomovimientosclientes` AS SELECT 
 1 AS `id`,
 1 AS `dia`,
 1 AS `mes`,
 1 AS `año`,
 1 AS `fecha`,
 1 AS `hora`,
 1 AS `razon_social`,
 1 AS `cuit`,
 1 AS `descripcion`,
 1 AS `cuenta`,
 1 AS `id_tipo`,
 1 AS `tipo`,
 1 AS `id_banco`,
 1 AS `operacion`,
 1 AS `monto`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `vistalistadomovimientosproveedores`
--

DROP TABLE IF EXISTS `vistalistadomovimientosproveedores`;
/*!50001 DROP VIEW IF EXISTS `vistalistadomovimientosproveedores`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistalistadomovimientosproveedores` AS SELECT 
 1 AS `id`,
 1 AS `dia`,
 1 AS `mes`,
 1 AS `año`,
 1 AS `fecha`,
 1 AS `hora`,
 1 AS `razon_social`,
 1 AS `cuit`,
 1 AS `descripcion`,
 1 AS `cuenta`,
 1 AS `id_tipo`,
 1 AS `tipo`,
 1 AS `id_banco`,
 1 AS `operacion`,
 1 AS `monto`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `vistalistadoventas`
--

DROP TABLE IF EXISTS `vistalistadoventas`;
/*!50001 DROP VIEW IF EXISTS `vistalistadoventas`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistalistadoventas` AS SELECT 
 1 AS `id`,
 1 AS `dia`,
 1 AS `mes`,
 1 AS `año`,
 1 AS `fecha`,
 1 AS `hora`,
 1 AS `monto`,
 1 AS `operacion`,
 1 AS `cliente`,
 1 AS `cuit`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `vistasaldocliente`
--

DROP TABLE IF EXISTS `vistasaldocliente`;
/*!50001 DROP VIEW IF EXISTS `vistasaldocliente`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistasaldocliente` AS SELECT 
 1 AS `id`,
 1 AS `razon_social`,
 1 AS `saldo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `vistasaldoporidcliente`
--

DROP TABLE IF EXISTS `vistasaldoporidcliente`;
/*!50001 DROP VIEW IF EXISTS `vistasaldoporidcliente`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistasaldoporidcliente` AS SELECT 
 1 AS `id`,
 1 AS `cod_cliente`,
 1 AS `razon_social`,
 1 AS `cuit`,
 1 AS `id_cliente_cuenta`,
 1 AS `descripcion`,
 1 AS `id_banco`,
 1 AS `id_operacion`,
 1 AS `tipo`,
 1 AS `fecha`,
 1 AS `saldo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `vistasaldoporidproveedor`
--

DROP TABLE IF EXISTS `vistasaldoporidproveedor`;
/*!50001 DROP VIEW IF EXISTS `vistasaldoporidproveedor`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistasaldoporidproveedor` AS SELECT 
 1 AS `id`,
 1 AS `razon_social`,
 1 AS `cuit`,
 1 AS `id_proveedor_cuenta`,
 1 AS `descripcion`,
 1 AS `id_banco`,
 1 AS `id_operacion`,
 1 AS `tipo`,
 1 AS `fecha`,
 1 AS `saldo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `vistasaldoproveedor`
--

DROP TABLE IF EXISTS `vistasaldoproveedor`;
/*!50001 DROP VIEW IF EXISTS `vistasaldoproveedor`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistasaldoproveedor` AS SELECT 
 1 AS `id`,
 1 AS `razon_social`,
 1 AS `saldo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `vistaultimacompra`
--

DROP TABLE IF EXISTS `vistaultimacompra`;
/*!50001 DROP VIEW IF EXISTS `vistaultimacompra`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistaultimacompra` AS SELECT 
 1 AS `id`,
 1 AS `razon_social`,
 1 AS `domicilio`,
 1 AS `cuit`,
 1 AS `id_proveedor_cuenta`,
 1 AS `descripcion`,
 1 AS `id_banco`,
 1 AS `id_operacion`,
 1 AS `tipo`,
 1 AS `fecha`,
 1 AS `saldo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `vistaultimaventa`
--

DROP TABLE IF EXISTS `vistaultimaventa`;
/*!50001 DROP VIEW IF EXISTS `vistaultimaventa`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistaultimaventa` AS SELECT 
 1 AS `id`,
 1 AS `cod_cliente`,
 1 AS `razon_social`,
 1 AS `domicilio`,
 1 AS `cuit`,
 1 AS `id_cliente_cuenta`,
 1 AS `descripcion`,
 1 AS `id_banco`,
 1 AS `id_operacion`,
 1 AS `tipo`,
 1 AS `fecha`,
 1 AS `saldo`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `vistaultimaventaporcliente`
--

DROP TABLE IF EXISTS `vistaultimaventaporcliente`;
/*!50001 DROP VIEW IF EXISTS `vistaultimaventaporcliente`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistaultimaventaporcliente` AS SELECT 
 1 AS `id`,
 1 AS `id_operacion`,
 1 AS `id_cliente`,
 1 AS `codigo`,
 1 AS `descripcion`,
 1 AS `peso`,
 1 AS `monto`,
 1 AS `monto_total`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `vistaventa`
--

DROP TABLE IF EXISTS `vistaventa`;
/*!50001 DROP VIEW IF EXISTS `vistaventa`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistaventa` AS SELECT 
 1 AS `id`,
 1 AS `id_cliente`,
 1 AS `id_operacion`,
 1 AS `codigo`,
 1 AS `descripcion`,
 1 AS `peso`,
 1 AS `monto`,
 1 AS `monto_total`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `vistaventaseleccionada`
--

DROP TABLE IF EXISTS `vistaventaseleccionada`;
/*!50001 DROP VIEW IF EXISTS `vistaventaseleccionada`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistaventaseleccionada` AS SELECT 
 1 AS `id`,
 1 AS `id_operacion`,
 1 AS `id_cliente`,
 1 AS `descripcion`,
 1 AS `peso`,
 1 AS `monto`,
 1 AS `monto_total`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `vistaventasumatotal`
--

DROP TABLE IF EXISTS `vistaventasumatotal`;
/*!50001 DROP VIEW IF EXISTS `vistaventasumatotal`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistaventasumatotal` AS SELECT 
 1 AS `id`,
 1 AS `total`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping routines for database 'bdlamejor_dev'
--
/*!50003 DROP PROCEDURE IF EXISTS `ActualizarCliente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ActualizarCliente`(id_ int, cc varchar(4), 
rs varchar(100), 
dom varchar(50),
loc varchar(30),
iva varchar(3),
tc int,
nl varchar(50),
cuit VARCHAR(15),
tel varchar(20),
nr varchar(50),
fd date,
idu int)
UPDATE cliente SET 
cod_cliente = cc,
razon_social = rs,
domicilio = dom,
localidad = loc,
civa = iva,
id_tipo_cliente = tc,
nombre_local = nl,
cuit = cuit,
telefono = tel,
nombre_responsable = nr,
fecha_desde = fd,
usuario = idu
WHERE id = id_ ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `actualizarProveedor` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `actualizarProveedor`(
id_ int,
rs varchar(100), 
dom varchar(50),
loc varchar(30),
iva varchar(3),
nl varchar(50),
cuit VARCHAR(15),
tel varchar(20),
nr varchar(50),
fd date,
idu int)
UPDATE proveedor SET 
razon_social = rs,
domicilio = dom,
localidad = loc,
civa = iva,
nombre_local = nl,
cuit = cuit,
telefono = tel,
nombre_responsable = nr,
fecha_desde = fd,
usuario = idu
WHERE id = id_ ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `borrarCliente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `borrarCliente`(`id_` int, `fecha_` date)
update cliente set fecha_baja = fecha_ where id = id_ ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `borrarProveedor` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `borrarProveedor`(id_ int, fecha_ date)
update proveedor set fecha_baja = fecha_ where id = id_ ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `grabarNuevaClienteCuenta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `grabarNuevaClienteCuenta`(`cbu_` varchar(40),`desc_` varchar(50),`idCliente_` int,`idBanco_` int,`idUsuario_` int)
INSERT INTO clientecuenta 
( cbu, descripcion, id_cliente, id_banco, fecha_updated, usuario, fecha_baja) 
 VALUES (cbu_, desc_,idCliente_,idBanco_,NOW(),idUsuario_,null) ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `grabarNuevaProveedorCuenta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `grabarNuevaProveedorCuenta`(`cbu_` varchar(40),`desc_` varchar(50),`idProveedor_` int,`idBanco_` int,`idUsuario_` int)
INSERT INTO proveedorcuenta 
( cbu, descripcion, id_proveedor, id_banco, fecha_updated, usuario, fecha_baja) 
 VALUES (cbu_, desc_,idProveedor_,idBanco_NOW(),idUsuario_,null) ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `grabarNuevoCliente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `grabarNuevoCliente`(cc varchar(4), rs varchar(100), 
dom varchar(50),
loc varchar(30),
iva varchar(3),
tc int,
nl varchar(50),
cuit VARCHAR(15),
tel varchar(20),
nr varchar(50),
fd date,idu int)
INSERT INTO cliente (
cod_cliente,
razon_social,
domicilio,
localidad,
civa,
id_tipo_cliente,
nombre_local,
cuit,
telefono,
nombre_responsable,
fecha_desde,
usuario) VALUES (
cc,
rs, 
dom,
loc,
iva,
tc,
nl,
cuit,
tel,
nr,
fd,
idu) ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `grabarNuevoProveedor` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `grabarNuevoProveedor`(
rs varchar(100), 
dom varchar(50),
loc varchar(30),
iva varchar(3),
nl varchar(50),
cuit VARCHAR(15),
tel varchar(20),
nr varchar(50),
fd date,
idu int)
INSERT INTO proveedor(
razon_social,
domicilio,
localidad,
civa,
nombre_local,
cuit,
telefono,
nombre_responsable,
fecha_desde.
usuario) VALUES (
rs, 
dom,
loc,
iva,
nl,
cuit,
tel,
nr,
fd,
idu) ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `listarClienteCuentaConSaldo` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarClienteCuentaConSaldo`()
SELECT 
cliente.id, 
cliente.razon_social AS `razon social`, 
cliente.nombre_local AS `nombre local`, 
cast(ct.descripcion as CHAR(50)) AS `Tipo Cliente`, 
cliente.civa AS iva,
cliente.cuit AS cuit,
sum(cuenta.saldo_actual) AS `saldo actual`
FROM cliente 
INNER JOIN clientecuenta cuenta on cliente.id = cuenta.id_cliente 
INNER JOIN banco ON cuenta.id_banco = banco.id 
INNER JOIN clientetipo ct ON ct.id = cliente.id_tipo_cliente 
group by cliente.id order by cliente.id ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `listarCuentasByIdCliente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarCuentasByIdCliente`(Id_ int)
SELECT
cc.id,
b.descripcion,
cc.cbu,
cc.descripcion,
cc.fecha_updated
FROM clientecuenta cc 
INNER JOIN banco b ON b.id = cc.id_banco
WHERE cc.id_cliente = Id_ ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `listarMovimientoTipo` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarMovimientoTipo`()
select * from movimientotipo order by id ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `listarTipoCliente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarTipoCliente`()
select * from clientetipo order by id ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `listarTipoProducto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarTipoProducto`()
select * from productotipo order by id ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerClienteConCuentasPorIdCliente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClienteConCuentasPorIdCliente`(id_ int)
SELECT c.id ,	c.cod_cliente AS CodCliente, 	c.razon_social AS RazonSocial, 	c.domicilio AS Domicilio,
c.localidad AS Localidad,cast(ct.id as CHAR(50)) AS TipoCliente, cu.id AS IdCuenta, 
c.fecha_desde as FechaDesde, c.civa AS IVA, c.cuit AS CUIT,c.nombre_responsable AS NombreResponsable,
c.nombre_local AS NombreLocal,c.telefono AS Telefono FROM	cliente c 
INNER JOIN clientetipo ct ON ct.id = c.id_tipo_cliente 
INNER JOIN clientecuenta cu ON cu.id_cliente = c.id  WHERE c.id = id_
  AND c.fecha_baja is null order by c.id ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerClienteCuentaPorId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClienteCuentaPorId`(`id_` int)
select * from clientecuenta where id = id_ ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerClienteCuentas` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClienteCuentas`()
select * from clientecuenta order by id ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerClientes` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClientes`()
SELECT * FROM cliente ORDER BY razon_social ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerClientesConCuenta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClientesConCuenta`()
SELECT c.id ,	c.cod_cliente AS CodCliente, 	c.razon_social AS RazonSocial, 	c.domicilio AS Domicilio,
c.localidad AS Localidad,cast(ct.id as CHAR(50)) AS TipoCliente, cu.id AS IdCuenta, 
c.fecha_desde as FechaDesde, c.civa AS IVA, c.cuit AS CUIT,c.nombre_responsable AS NombreResponsable,
c.nombre_local AS NombreLocal,c.telefono AS Telefono FROM	cliente c 
INNER JOIN clientetipo ct ON ct.id = c.id_tipo_cliente 
INNER JOIN clientecuenta cu ON cu.id_cliente = c.id  AND c.fecha_baja is null order by c.id ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerClientesData` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClientesData`()
SELECT c.id, c.razon_social AS RazonSocial, c.domicilio AS Domicilio, c.localidad AS Localidad, cast(c.id_tipo_cliente as CHAR(50)) AS TipoCliente,   
c.fecha_desde as FechaDesde, c.civa AS IVA, c.cuit AS CUIT, c.nombre_responsable AS NombreResponsable, c.nombre_local AS NombreLocal, 	c.telefono AS Telefono,
c.fecha_baja AS FechaBaja  FROM cliente c order by c.id ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerClientesPorId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClientesPorId`(id_ int)
SELECT * FROM cliente  WHERE id = id_ ORDER BY razon_social ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerClientesSaldoActual` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClientesSaldoActual`()
SELECT cliente.id, cliente.cod_cliente as CodCliente, cliente.razon_social AS `RazonSocial`, cliente.nombre_local AS `NombreLocal`, cliente.civa AS IVA, cast(cliente.id_tipo_cliente as CHAR(50)) AS TipoCliente,count(cuenta.id) AS CantidadCuentas FROM cliente inner join clientecuenta cuenta on cliente.id = cuenta.id_cliente       INNER JOIN banco ON cuenta.id_banco = banco.id INNER JOIN clientetipo ct ON ct.id = cliente.id_tipo_cliente group by cliente.id order by cliente.id ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerCuentasPorIdCliente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerCuentasPorIdCliente`(`id_` int)
select * from clientecuenta where id_cliente = id_ ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerCuentasPorIdProveedor` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerCuentasPorIdProveedor`(`id_` int)
select * from proveedorcuenta where id_proveedor = id_ ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerMovCuentas` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerMovCuentas`()
SELECT cm.id, cm.id_operacion,gc.id,gc.id_cliente,cm.id_cuenta,cm.id_movimiento_tipo,mt.descripcion, 
 gc.id_banco, round(cm.monto, 2) AS monto, DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_,cm.cobrado, 
 cm.usuario FROM clientecuentamovimiento cm INNER JOIN clientecuenta gc ON cm.id_cuenta = gc.id 
 INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id WHERE gc.id_cliente 
 IS NOT NULL ORDER BY cm.id DESC ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerMovCuentasClientes` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerMovCuentasClientes`()
SELECT cm.id, cm.vob,  gc.id,gc.id_cliente,cm.id_cuenta, cm.id_movimiento_tipo, mt.descripcion, 
gc.id_banco, round(cm.monto, 2) AS monto, DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_,
cm.cobrado, cm.usuario 
 FROM clientecuentamovimiento cm INNER JOIN clientecuenta gc ON cm.id_cuenta = gc.id 
 INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id 
 WHERE gc.id_cliente IS NOT NULL ORDER BY cm.id DESC ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerMovCuentasParseado` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerMovCuentasParseado`(`pInicio_` int,`registros_` int)
SELECT cm.id, cm.id_operacion,gc.id,gc.id_cliente,cm.id_cuenta,cm.id_movimiento_tipo,mt.descripcion, 
 gc.id_banco, round(cm.monto, 2) AS monto, DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_,cm.cobrado, 
 cm.usuario FROM clientecuentamovimiento cm INNER JOIN clientecuenta gc ON cm.id_cuenta = gc.id 
 INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id WHERE gc.id_cliente 
 IS NOT NULL ORDER BY cm.id DESC LIMIT pInicio_, registros_ ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerMovCuentasParseadoEntreFechas` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerMovCuentasParseadoEntreFechas`(`idCliente_` int, `pInicio_` int,`registros_` int, `fDesde_` varchar(20), `fHasta_` varchar(20))
SELECT cm.id, cm.id_operacion,gc.id,gc.id_cliente,cm.id_cuenta,cm.id_movimiento_tipo,mt.descripcion, 
 gc.id_banco, round(cm.monto, 2) AS monto, DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_,cm.cobrado, 
 cm.usuario FROM clientecuentamovimiento cm INNER JOIN clientecuenta gc ON cm.id_cuenta = gc.id 
 INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id 
 INNER JOIN banco ON banco.id = gc.id_banco WHERE gc.id_cliente = idCliente_ 
 AND DATE_FORMAT(cm.fecha, '%Y-%m-%d') BETWEEN fDesde_ AND fHasta_ 
 ORDER BY cm.id DESC LIMIT pInicio_, registros_ ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerProveedorConCuentasPorIdProveedor` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedorConCuentasPorIdProveedor`(`id_` int)
SELECT 
banco.descripcion, 
cuenta.id as id_cuenta, 
cuenta.cbu, 
cuenta.descripcion, 
cuenta.fecha_updated 
FROM proveedor 
inner join proveedorcuenta cuenta on proveedor.id = cuenta.id_proveedor
INNER JOIN banco ON cuenta.id_banco = banco.id  
WHERE proveedor.id = id_ order by cuenta.id ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerProveedorCuentaPorId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedorCuentaPorId`(`id_` int)
select * from proveedorcuenta where id = id_ ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerProveedorCuentas` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedorCuentas`()
select * from proveedorcuenta order by id ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerProveedores` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedores`()
SELECT * FROM proveedor ORDER BY razon_social ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerProveedoresConCuenta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedoresConCuenta`()
SELECT c.id , 
c.razon_social AS RazonSocial, 
	c.domicilio AS Domicilio, 
	c.localidad AS Localidad,
cu.id AS IdCuenta, 
 c.fecha_desde as FechaDesde, 
c.civa AS IVA, 
	c.cuit AS CUIT, 
	c.nombre_responsable AS NombreResponsable,
	c.nombre_local AS NombreLocal,
c.telefono AS Telefono  FROM 	proveedor c 
 INNER JOIN proveedorcuenta cu ON cu.id_proveedor = c.id 
 WHERE  c.fecha_baja is null  order by c.id ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerProveedoresData` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedoresData`()
SELECT c.id, 
c.razon_social AS RazonSocial, 
c.domicilio AS Domicilio, 
c.localidad AS Localidad,  
c.fecha_desde as FechaDesde, 
c.civa AS IVA, 
c.cuit AS CUIT, 
c.nombre_responsable AS NombreResponsable, 
c.nombre_local AS NombreLocal, 	
c.telefono AS Telefono,
c.fecha_baja AS FechaBaja  FROM proveedor c order by c.razon_social ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerProveedoresPorId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedoresPorId`(id_ int)
SELECT * FROM proveedor WHERE id = id_ ORDER BY razon_social ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerProveedoresSaldoActual` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedoresSaldoActual`()
SELECT proveedor.id, 
proveedor.razon_social AS `razon social`,
proveedor.nombre_local AS `nombre local`, 
proveedor.civa AS iva, 
count(cuenta.id) AS cuentas 
FROM proveedor inner join proveedorcuenta cuenta 
on proveedor.id = cuenta.id_proveedor       
INNER JOIN banco ON cuenta.id_banco = banco.id 
group by proveedor.id order by proveedor.id ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerProveedorPorNombre` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedorPorNombre`(`name_` varchar(20))
select id, razon_social AS RazonSocial, domicilio AS Domicilio, localidad AS Localidad, fecha_desde as FechaDesde,
civa AS IVA, cuit AS CUIT, nombre_responsable AS NombreResponsable, nombre_local AS NombreLocal,
telefono AS Telefono, fecha_baja AS FechaBaja FROM proveedor WHERE fecha_baja is NULL
AND razon_social LIKE CONCAT('%',name_,'%') ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerTipoClientePorIdCliente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerTipoClientePorIdCliente`(id_ int)
select id_tipo_cliente from cliente where id = id_ ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerTipoProdutoPorIdProducto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerTipoProdutoPorIdProducto`(id_ int)
select id_producto_tipo from producto where id = id_ ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerTodasCuentasPorCliente` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerTodasCuentasPorCliente`(`id_` int)
SELECT 
banco.descripcion, 
c.id AS id_cuenta, 
c.cbu, 
c.descripcion, 
c.fecha_updated 
FROM cliente
INNER JOIN clientecuenta c ON cliente.id = c.id_cliente
INNER JOIN banco ON c.id_banco = banco.id 
INNER JOIN clientetipo ct ON ct.id = cliente.id_tipo_cliente 
WHERE cliente.id = id_ ORDER BY c.id ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerUsuarioPorNombre` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerUsuarioPorNombre`(name_ VARCHAR(20))
select * from usuario where username like name_ ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `obtenerUsuariosModulos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerUsuariosModulos`(id_ int)
SELECT m.* FROM usuariomodulo um inner join modulo m on m.id = um.id_modulo where um.id_usuario = id_ ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `vistacompra`
--

/*!50001 DROP VIEW IF EXISTS `vistacompra`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistacompra` AS select `v`.`id` AS `id`,`v`.`id_operacion` AS `id_operacion`,`p`.`id_codigo_barra` AS `codigo`,`p`.`descripcion_breve` AS `descripcion`,`vd`.`peso` AS `peso`,`vd`.`monto` AS `monto`,`v`.`monto_total` AS `monto_total` from (((`compra` `v` join `compradetalle` `vd` on((`v`.`id` = `vd`.`id_compra`))) join `producto` `p` on((`vd`.`id_producto` = `p`.`id`))) join `operacionproveedor` `o` on((`v`.`id_operacion` = `o`.`id`))) where (`v`.`id` = 10) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistacompraseleccionada`
--

/*!50001 DROP VIEW IF EXISTS `vistacompraseleccionada`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistacompraseleccionada` AS select `v`.`id` AS `id`,`v`.`id_operacion` AS `id_operacion`,`o`.`id_proveedor` AS `id_proveedor`,`p`.`id_codigo_barra` AS `codigo`,(case when isnull(`p`.`id`) then concat('Garron #',`g`.`numero`,' ID:',`g`.`id`) else `p`.`descripcion_breve` end) AS `descripcion`,`vd`.`peso` AS `peso`,`vd`.`monto` AS `monto`,`v`.`monto_total` AS `monto_total` from ((((`compra` `v` join `compradetalle` `vd` on((`v`.`id` = `vd`.`id_compra`))) left join `producto` `p` on(((`vd`.`id_producto` = `p`.`id`) and (`p`.`id` is not null)))) left join `garron` `g` on(((`vd`.`id_garron` = `g`.`id`) and (`g`.`id` is not null)))) join `operacionproveedor` `o` on((`v`.`id_operacion` = `o`.`id`))) where (`v`.`id` = 8) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistalistadomovimientosclientes`
--

/*!50001 DROP VIEW IF EXISTS `vistalistadomovimientosclientes`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistalistadomovimientosclientes` AS select `cm`.`id` AS `id`,dayofmonth(`cm`.`fecha`) AS `dia`,elt(date_format(`cm`.`fecha`,'%m'),'Enero','Febrero','Marzo','Abril','Mayo','Junio','Julio','Agosto','Septiembre','Octubre','Noviembre','Diciembre') AS `mes`,year(`cm`.`fecha`) AS `año`,date_format(`cm`.`fecha`,'%d-%m-%Y') AS `fecha`,date_format(`cm`.`fecha`,'%H:%i') AS `hora`,`c`.`razon_social` AS `razon_social`,`c`.`cuit` AS `cuit`,`gc`.`descripcion` AS `descripcion`,`cm`.`id_cuenta` AS `cuenta`,`cm`.`id_movimiento_tipo` AS `id_tipo`,`mt`.`descripcion` AS `tipo`,`gc`.`id_banco` AS `id_banco`,`cm`.`id_operacion` AS `operacion`,if((`cm`.`id_movimiento_tipo` = 2),`cm`.`monto`,(`cm`.`monto` * -(1))) AS `monto` from (((`clientecuentamovimiento` `cm` join `clientecuenta` `gc` on((`cm`.`id_cuenta` = `gc`.`id`))) join `movimientotipo` `mt` on((`cm`.`id_movimiento_tipo` = `mt`.`id`))) join `cliente` `c` on((`gc`.`id_cliente` = `c`.`id`))) where ((`gc`.`id_cliente` is not null) and (`cm`.`fecha` between '2018-04-01' and ('2018-07-10' + interval 1 day))) order by `cm`.`id` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistalistadomovimientosproveedores`
--

/*!50001 DROP VIEW IF EXISTS `vistalistadomovimientosproveedores`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistalistadomovimientosproveedores` AS select `cm`.`id` AS `id`,dayofmonth(`cm`.`fecha`) AS `dia`,elt(date_format(`cm`.`fecha`,'%m'),'Enero','Febrero','Marzo','Abril','Mayo','Junio','Julio','Agosto','Septiembre','Octubre','Noviembre','Diciembre') AS `mes`,year(`cm`.`fecha`) AS `año`,date_format(`cm`.`fecha`,'%d-%m-%Y') AS `fecha`,date_format(`cm`.`fecha`,'%H:%i') AS `hora`,`c`.`razon_social` AS `razon_social`,`c`.`cuit` AS `cuit`,`gc`.`descripcion` AS `descripcion`,`cm`.`id_cuenta` AS `cuenta`,`cm`.`id_movimiento_tipo` AS `id_tipo`,`mt`.`descripcion` AS `tipo`,`gc`.`id_banco` AS `id_banco`,`cm`.`id_operacion` AS `operacion`,if((`cm`.`id_movimiento_tipo` = 2),`cm`.`monto`,(`cm`.`monto` * -(1))) AS `monto` from (((`proveedorcuentamovimiento` `cm` join `proveedorcuenta` `gc` on((`cm`.`id_cuenta` = `gc`.`id`))) join `movimientotipo` `mt` on((`cm`.`id_movimiento_tipo` = `mt`.`id`))) join `proveedor` `c` on((`gc`.`id_proveedor` = `c`.`id`))) where ((`gc`.`id_proveedor` is not null) and (`cm`.`fecha` between '2000-04-01' and ('2018-04-20' + interval 1 day))) order by `cm`.`id` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistalistadoventas`
--

/*!50001 DROP VIEW IF EXISTS `vistalistadoventas`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistalistadoventas` AS select `v`.`id` AS `id`,dayofmonth(`v`.`fecha`) AS `dia`,elt(date_format(`v`.`fecha`,'%m'),'Enero','Febrero','Marzo','Abril','Mayo','Junio','Julio','Agosto','Septiembre','Octubre','Noviembre','Diciembre') AS `mes`,year(`v`.`fecha`) AS `año`,date_format(`v`.`fecha`,'%d/%m/%Y') AS `fecha`,date_format(`v`.`fecha`,'%H:%i') AS `hora`,`v`.`monto_total` AS `monto`,`v`.`id_operacion` AS `operacion`,`c`.`razon_social` AS `cliente`,`c`.`cuit` AS `cuit` from ((`venta` `v` join `operacion` `o` on((`o`.`id` = `v`.`id_operacion`))) join `cliente` `c` on((`o`.`id_cliente` = `c`.`id`))) where (`v`.`fecha` between '2018-04-01' and ('2018-07-10' + interval 1 day)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistasaldocliente`
--

/*!50001 DROP VIEW IF EXISTS `vistasaldocliente`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistasaldocliente` AS select `vistasaldoporidcliente`.`id` AS `id`,`vistasaldoporidcliente`.`razon_social` AS `razon_social`,(sum(`vistasaldoporidcliente`.`saldo`) * -(1)) AS `saldo` from `vistasaldoporidcliente` group by `vistasaldoporidcliente`.`id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistasaldoporidcliente`
--

/*!50001 DROP VIEW IF EXISTS `vistasaldoporidcliente`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistasaldoporidcliente` AS select `c`.`id` AS `id`,`c`.`cod_cliente` AS `cod_cliente`,`c`.`razon_social` AS `razon_social`,`c`.`cuit` AS `cuit`,`cc`.`id` AS `id_cliente_cuenta`,`cc`.`descripcion` AS `descripcion`,`cc`.`id_banco` AS `id_banco`,`ccm`.`id_operacion` AS `id_operacion`,`mt`.`descripcion` AS `tipo`,`ccm`.`fecha` AS `fecha`,if((`ccm`.`id_movimiento_tipo` = 2),`ccm`.`monto`,(`ccm`.`monto` * -(1))) AS `saldo` from (((`clientecuenta` `cc` join `cliente` `c` on((`cc`.`id_cliente` = `c`.`id`))) join `clientecuentamovimiento` `ccm` on((`ccm`.`id_cuenta` = `cc`.`id`))) join `movimientotipo` `mt` on((`ccm`.`id_movimiento_tipo` = `mt`.`id`))) where (`c`.`id` = 6) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistasaldoporidproveedor`
--

/*!50001 DROP VIEW IF EXISTS `vistasaldoporidproveedor`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistasaldoporidproveedor` AS select `c`.`id` AS `id`,`c`.`razon_social` AS `razon_social`,`c`.`cuit` AS `cuit`,`cc`.`id` AS `id_proveedor_cuenta`,`cc`.`descripcion` AS `descripcion`,`cc`.`id_banco` AS `id_banco`,`ccm`.`id_operacion` AS `id_operacion`,`mt`.`descripcion` AS `tipo`,`ccm`.`fecha` AS `fecha`,if((`ccm`.`id_movimiento_tipo` = 2),`ccm`.`monto`,(`ccm`.`monto` * -(1))) AS `saldo` from (((`proveedorcuenta` `cc` join `proveedor` `c` on((`cc`.`id_proveedor` = `c`.`id`))) join `proveedorcuentamovimiento` `ccm` on((`ccm`.`id_cuenta` = `cc`.`id`))) join `movimientotipo` `mt` on((`ccm`.`id_movimiento_tipo` = `mt`.`id`))) where (`c`.`id` = 2) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistasaldoproveedor`
--

/*!50001 DROP VIEW IF EXISTS `vistasaldoproveedor`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistasaldoproveedor` AS select `vistasaldoporidproveedor`.`id` AS `id`,`vistasaldoporidproveedor`.`razon_social` AS `razon_social`,sum(`vistasaldoporidproveedor`.`saldo`) AS `saldo` from `vistasaldoporidproveedor` group by `vistasaldoporidproveedor`.`id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistaultimacompra`
--

/*!50001 DROP VIEW IF EXISTS `vistaultimacompra`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistaultimacompra` AS select `c`.`id` AS `id`,`c`.`razon_social` AS `razon_social`,`c`.`domicilio` AS `domicilio`,`c`.`cuit` AS `cuit`,`cc`.`id` AS `id_proveedor_cuenta`,`cc`.`descripcion` AS `descripcion`,`cc`.`id_banco` AS `id_banco`,`ccm`.`id_operacion` AS `id_operacion`,`mt`.`descripcion` AS `tipo`,`ccm`.`fecha` AS `fecha`,if((`ccm`.`id_movimiento_tipo` = 2),`ccm`.`monto`,(`ccm`.`monto` * -(1))) AS `saldo` from (((`proveedorcuenta` `cc` join `proveedor` `c` on((`cc`.`id_proveedor` = `c`.`id`))) join `proveedorcuentamovimiento` `ccm` on((`ccm`.`id_cuenta` = `cc`.`id`))) join `movimientotipo` `mt` on((`ccm`.`id_movimiento_tipo` = `mt`.`id`))) where (`ccm`.`id_operacion` = 2) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistaultimaventa`
--

/*!50001 DROP VIEW IF EXISTS `vistaultimaventa`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistaultimaventa` AS select `c`.`id` AS `id`,`c`.`cod_cliente` AS `cod_cliente`,`c`.`razon_social` AS `razon_social`,`c`.`domicilio` AS `domicilio`,`c`.`cuit` AS `cuit`,`cc`.`id` AS `id_cliente_cuenta`,`cc`.`descripcion` AS `descripcion`,`cc`.`id_banco` AS `id_banco`,`ccm`.`id_operacion` AS `id_operacion`,`mt`.`descripcion` AS `tipo`,`ccm`.`fecha` AS `fecha`,if((`ccm`.`id_movimiento_tipo` = 2),`ccm`.`monto`,(`ccm`.`monto` * -(1))) AS `saldo` from (((`clientecuenta` `cc` join `cliente` `c` on((`cc`.`id_cliente` = `c`.`id`))) join `clientecuentamovimiento` `ccm` on((`ccm`.`id_cuenta` = `cc`.`id`))) join `movimientotipo` `mt` on((`ccm`.`id_movimiento_tipo` = `mt`.`id`))) where (`ccm`.`id_operacion` = 39) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistaultimaventaporcliente`
--

/*!50001 DROP VIEW IF EXISTS `vistaultimaventaporcliente`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistaultimaventaporcliente` AS select `v`.`id` AS `id`,`v`.`id_operacion` AS `id_operacion`,`o`.`id_cliente` AS `id_cliente`,`p`.`id_codigo_barra` AS `codigo`,`p`.`descripcion_breve` AS `descripcion`,`vd`.`peso` AS `peso`,`vd`.`monto` AS `monto`,`v`.`monto_total` AS `monto_total` from (((`venta` `v` join `ventadetalle` `vd` on((`v`.`id` = `vd`.`id_venta`))) join `producto` `p` on((`vd`.`id_producto` = `p`.`id`))) join `operacion` `o` on((`v`.`id_operacion` = `o`.`id`))) where (`v`.`id` = (select `v`.`id` AS `id_ultima_venta` from (((`venta` `v` join `ventadetalle` `vd` on((`v`.`id` = `vd`.`id_venta`))) join `producto` `p` on((`vd`.`id_producto` = `p`.`id`))) join `operacion` `o` on((`v`.`id_operacion` = `o`.`id`))) where (`o`.`id_cliente` = 6) order by `v`.`id` desc limit 1)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistaventa`
--

/*!50001 DROP VIEW IF EXISTS `vistaventa`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistaventa` AS select `v`.`id` AS `id`,`o`.`id_cliente` AS `id_cliente`,`v`.`id_operacion` AS `id_operacion`,`p`.`id_codigo_barra` AS `codigo`,(case when isnull(`p`.`id`) then concat('Garron #',`g`.`numero`,' ID:',`g`.`id`) else `p`.`descripcion_breve` end) AS `descripcion`,`vd`.`peso` AS `peso`,`vd`.`monto` AS `monto`,`v`.`monto_total` AS `monto_total` from ((((`venta` `v` join `ventadetalle` `vd` on((`v`.`id` = `vd`.`id_venta`))) left join `producto` `p` on(((`vd`.`id_producto` = `p`.`id`) and (`p`.`id` is not null)))) left join `garron` `g` on(((`vd`.`id_garron` = `g`.`id`) and (`g`.`id` is not null)))) join `operacion` `o` on((`v`.`id_operacion` = `o`.`id`))) where (`v`.`id` = 41) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistaventaseleccionada`
--

/*!50001 DROP VIEW IF EXISTS `vistaventaseleccionada`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistaventaseleccionada` AS select `v`.`id` AS `id`,`v`.`id_operacion` AS `id_operacion`,`o`.`id_cliente` AS `id_cliente`,(case when isnull(`p`.`id`) then concat('Garron #',`g`.`numero`,' ID:',`g`.`id`) else `p`.`descripcion_breve` end) AS `descripcion`,`vd`.`peso` AS `peso`,`vd`.`monto` AS `monto`,`v`.`monto_total` AS `monto_total` from ((((`venta` `v` join `ventadetalle` `vd` on((`v`.`id` = `vd`.`id_venta`))) left join `producto` `p` on(((`vd`.`id_producto` = `p`.`id`) and (`p`.`id` is not null)))) left join `garron` `g` on(((`vd`.`id_garron` = `g`.`id`) and (`g`.`id` is not null)))) join `operacion` `o` on((`v`.`id_operacion` = `o`.`id`))) where (`v`.`id` = 41) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistaventasumatotal`
--

/*!50001 DROP VIEW IF EXISTS `vistaventasumatotal`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistaventasumatotal` AS select `vsc`.`id` AS `id`,(`vvs`.`monto_total` - `vsc`.`saldo`) AS `total` from (`vistaventaseleccionada` `vvs` join `vistasaldocliente` `vsc` on((`vvs`.`id_cliente` = `vsc`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-07-14  0:23:34
