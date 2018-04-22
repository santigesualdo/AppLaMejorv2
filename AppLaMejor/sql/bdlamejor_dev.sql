/*
Navicat MySQL Data Transfer

Source Server         : u570713702_jjdev
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : bdlamejor_dev

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2018-04-19 20:55:03
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for banco
-- ----------------------------
DROP TABLE IF EXISTS `banco`;
CREATE TABLE `banco` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of banco
-- ----------------------------
INSERT INTO `banco` VALUES ('1', 'Macro');
INSERT INTO `banco` VALUES ('2', 'Santander');
INSERT INTO `banco` VALUES ('3', 'Santa Fe');
INSERT INTO `banco` VALUES ('4', 'Nación');
INSERT INTO `banco` VALUES ('5', 'Cuenta Corriente');

-- ----------------------------
-- Table structure for cliente
-- ----------------------------
DROP TABLE IF EXISTS `cliente`;
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
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of cliente
-- ----------------------------
INSERT INTO `cliente` VALUES ('29', 'ZR', 'JUAN CARLOS MARECO', 'BLAS PARERA 10290', 'SANTA FE', 'R.I', '1', 'J.M', '3424274573', '20-31669513-3', 'JUAN CARLOS MARECO', '2017-11-22', null, '1');
INSERT INTO `cliente` VALUES ('30', 'MR', 'ZANUTIGH MARIANO GERMAN', 'BV. PELEGRINI 3065', 'SANTA FE', 'R.I', '1', 'SANTA ANA', '20-24995216-9', '3424463794', 'ZANUTIGH MARIANO GERMAN', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('31', 'N', 'GUTIERREZ NERINA GUADALUPE', 'MARCIAL CANDIOTI 3285 ', 'SANTO TOME', 'R.I', '1', 'SUPER JUACO', '30-71423952-6', '342-156311029', 'GUTIERREZ NERINA GUADALUPE', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('32', 'BOSS', 'BOSSA EDGARDO OMAR', 'PTE FRONDIZZI 245- ', 'SUNCHALES', 'R.I', '1', ' ', '20-20320603-9', '3493-498525', 'BOSSA EDGARDO OMAR', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('33', 'E', 'HEINEN NORMA ESTELA', 'AUSTRIA Y RUTA 110', 'SAUCE VIEJO', 'R.I', '1', 'SAN CAYETANO', '27-13708517-3', '342-4995649', 'HEINEN NORMA ESTELA', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('34', 'LP', 'LÓPEZ JESABEL GUADALUPE ', 'MARCO CANDIOTI 1.756', 'CANDIOTI', 'MON', '1', 'CARNES LÓPEZ', '27-33468480-1', '342-156988763', 'LÓPEZ JESABEL GUADALUPE', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('35', 'ALL', 'ALLIONE ALBERTO ROQUE', 'RUTA 11 Km 427 S/N', 'CORONDA', 'MON', '1', 'CARNES ALLIONE', '20-21650528-0', '342-5023223', 'ALLIONE ALBERTO ROQUE', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('36', 'M2', 'RANIERI MIGUEL ANTONIO', 'ZONA RURAL 0', 'MONTE VERA', 'R.I', '1', 'CARNES RANIERI', '20-22763018-4', '342-155210956', 'RAINERI MIGUEL ANTONIO', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('37', 'GALL', 'CANALIS MARIA ROSA', 'TACUARI 8154', 'SANTA FE', 'R.I', '1', 'LA GALLEGA', '27-05947629-2', '342-469190/ 342-1569', 'CANALIS MARIA ROSA', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('38', 'EZ', 'MUÑOZ MILENA BETIANA', 'FACUNDO ZUVIRIA 5724', 'SANTA FE', 'R.I', '1', 'CARNES ENRIQUEZ', '27-37685347-6', '342-155194480', 'MUÑOZ MILENA BETIANA', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('39', 'RM', 'ROMANO MARIO ALBERTO', 'PADRE QUIROGA 2350', 'SANTA FE', 'R.I', '1', 'CARNES ROMANO', '20-17619634-4', '342-155150517', 'ROMANO MARIO ALBERTO', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('40', 'BL', 'BELLOMO MATIAS AUGUSTO', 'SANTIAGO DE CHILE 2.408', 'SANTA FE', 'R.I', '1', 'CARNES BELLOMO', '20-27719403-2', '342-154769177', 'BELLOMO MATIAS AUGUSTO', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('41', '678', 'PISATTI CECILIA', '-', 'santa fe', 'mon', '1', 'CARNES PASATTI', '-', '342-155036481', 'PISATTI CECILIA', '2017-11-23', null, '1');

-- ----------------------------
-- Table structure for clientecuenta
-- ----------------------------
DROP TABLE IF EXISTS `clientecuenta`;
CREATE TABLE `clientecuenta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cbu` varchar(40) NOT NULL,
  `descripcion` varchar(50) DEFAULT NULL,
  `id_cliente` int(11) DEFAULT NULL,
  `fecha_updated` datetime DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  `id_banco` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_banco` (`id_banco`)
) ENGINE=InnoDB AUTO_INCREMENT=77 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of clientecuenta
-- ----------------------------
INSERT INTO `clientecuenta` VALUES ('53', '-', 'EFECTIVO', '29', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('54', '-', 'EFECTIVO', '30', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('55', '-', 'EFECTIVO', '31', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('56', '-', 'EFECTIVO', '32', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('57', '-', 'EFECTIVO', '33', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('58', '-', 'EFECTIVO', '34', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('59', '-', 'EFECTIVO', '35', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('60', '-', 'EFECTIVO', '36', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('61', '-', 'EFECTIVO', '37', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('62', '-', 'EFECTIVO', '38', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('63', '-', 'EFECTIVO', '39', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('64', '-', 'EFECTIVO', '40', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('65', '-', 'EFECTIVO', '41', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('66', '-', 'EFECTIVO', '42', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('67', '-', 'EFECTIVO', '43', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('68', '-', 'EFECTIVO', '44', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('69', '-', 'EFECTIVO', '45', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('70', '-', 'EFECTIVO', '46', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('71', '-', 'EFECTIVO', '47', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('72', '-', 'EFECTIVO', '48', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('73', '-', 'EFECTIVO', '49', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('74', '-', 'EFECTIVO', '50', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('75', '-', 'EFECTIVO', '51', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('76', '-', 'EFECTIVO', '24', null, '1', null, '5');

-- ----------------------------
-- Table structure for clientecuentamovimiento
-- ----------------------------
DROP TABLE IF EXISTS `clientecuentamovimiento`;
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
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of clientecuentamovimiento
-- ----------------------------
INSERT INTO `clientecuentamovimiento` VALUES ('1', '1', '59', '2', '2541', '2018-01-24 12:03:10', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('2', '1', '59', '1', '2541', '2018-01-24 12:03:13', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('3', '0', '65', '1', '123', '2018-01-25 09:21:45', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('4', '0', '65', '2', '153', '2018-01-25 10:28:35', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('6', '0', '65', '2', '88', '2018-01-25 10:32:50', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('7', '2', '65', '1', '88', '2018-01-25 10:32:52', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('8', '3', '65', '2', '1958', '2018-01-25 10:39:11', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('9', '3', '65', '1', '1958', '2018-01-25 10:39:15', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('10', '4', '65', '2', '1400', '2018-01-25 10:48:09', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('11', '4', '65', '1', '1306', '2018-01-25 10:48:13', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('12', '5', '65', '2', '3828', '2018-01-25 11:45:52', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('13', '5', '65', '1', '3828', '2018-01-25 11:45:54', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('14', '6', '53', '2', '13000', '2018-01-29 12:45:53', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('15', '6', '53', '1', '12782', '2018-01-29 12:45:55', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('16', '7', '64', '2', '1500', '2018-03-01 10:34:50', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('17', '7', '64', '1', '1590', '2018-03-01 10:34:53', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('18', '8', '65', '2', '2500', '2018-03-02 09:51:45', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('19', '8', '65', '1', '2640', '2018-03-02 09:51:48', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('20', '9', '60', '2', '90', '2018-03-02 10:13:54', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('21', '9', '60', '1', '89', '2018-03-02 10:13:56', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('22', '10', '56', '2', '80', '2018-03-02 10:41:14', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('23', '10', '56', '1', '77', '2018-03-02 10:41:17', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('24', '11', '54', '2', '5500', '2018-03-02 12:23:36', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('25', '11', '54', '1', '5123', '2018-03-02 12:23:40', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('26', '12', '53', '2', '16000', '2018-03-02 12:43:06', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('27', '12', '56', '2', '30000', '2018-03-02 12:44:05', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('28', '12', '56', '1', '35310', '2018-03-02 12:44:07', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('29', '13', '64', '2', '90000', '2018-03-02 12:45:14', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('30', '13', '59', '2', '7872', '2018-03-02 12:45:39', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('31', '13', '59', '1', '7872', '2018-03-02 12:45:42', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('32', '14', '65', '2', '88', '2018-03-02 13:05:34', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('33', '14', '65', '1', '88', '2018-03-02 13:05:37', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('34', '15', '0', '1', '4303', '2018-04-07 18:53:57', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('35', '16', '0', '1', '169.5', '2018-04-13 20:11:47', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('36', '23', '55', '1', '50', '2018-04-17 20:33:40', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('37', '24', '55', '2', '50', '2018-04-17 20:34:13', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('38', '24', '55', '1', '6000', '2018-04-17 20:49:19', 'N', '1');

-- ----------------------------
-- Table structure for clientetipo
-- ----------------------------
DROP TABLE IF EXISTS `clientetipo`;
CREATE TABLE `clientetipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of clientetipo
-- ----------------------------
INSERT INTO `clientetipo` VALUES ('1', 'Mayorista');
INSERT INTO `clientetipo` VALUES ('2', 'Minorista');

-- ----------------------------
-- Table structure for compra
-- ----------------------------
DROP TABLE IF EXISTS `compra`;
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of compra
-- ----------------------------
INSERT INTO `compra` VALUES ('1', '1', '0', '2018-04-08 22:38:39', '2500.000', '1531.250', '1', null);
INSERT INTO `compra` VALUES ('2', '1', '0', '2018-04-08 22:39:06', '2500.000', '1531.250', '1', null);
INSERT INTO `compra` VALUES ('3', '1', '16', '2018-04-09 18:08:37', '12069.230', '10000.000', '1', null);
INSERT INTO `compra` VALUES ('4', '2', '16', '2018-04-09 18:29:07', '12179.970', '12179.970', '1', null);
INSERT INTO `compra` VALUES ('5', '2', '8', '2018-04-09 18:39:42', '256.360', '100.000', '1', null);
INSERT INTO `compra` VALUES ('6', '1', '9', '2018-04-09 19:09:29', '7950.760', '7950.760', '1', null);
INSERT INTO `compra` VALUES ('7', '1', '10', '2018-04-19 17:59:27', '3751.250', '3751.250', '1', null);
INSERT INTO `compra` VALUES ('8', '2', '11', '2018-04-19 18:04:12', '2897.740', '2897.740', '1', null);

-- ----------------------------
-- Table structure for compradetalle
-- ----------------------------
DROP TABLE IF EXISTS `compradetalle`;
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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of compradetalle
-- ----------------------------
INSERT INTO `compradetalle` VALUES ('1', '4', '69', null, '2521.360', '361.250', '0.000', '1', null);
INSERT INTO `compradetalle` VALUES ('2', '4', '70', null, '5213.250', '233.000', '0.000', '1', null);
INSERT INTO `compradetalle` VALUES ('3', '4', null, '46', '4200.000', '253.250', '0.000', '1', null);
INSERT INTO `compradetalle` VALUES ('4', '4', null, '47', '245.360', '200.000', '0.000', '1', null);
INSERT INTO `compradetalle` VALUES ('5', '5', '71', null, '256.360', '14.000', '0.000', '1', null);
INSERT INTO `compradetalle` VALUES ('6', '6', '72', null, '2563.250', '112.000', '0.000', '1', null);
INSERT INTO `compradetalle` VALUES ('7', '6', null, '44', '524.260', '25.360', '0.000', '1', null);
INSERT INTO `compradetalle` VALUES ('8', '6', null, '51', '4863.250', '38.000', '0.000', '1', null);
INSERT INTO `compradetalle` VALUES ('9', '7', null, '35', '3400.000', '80.000', '30.000', '1', null);
INSERT INTO `compradetalle` VALUES ('10', '7', null, '46', '351.250', '60.000', '40.000', '1', null);
INSERT INTO `compradetalle` VALUES ('11', '8', null, '44', '350.360', '28.000', '13.000', '1', null);
INSERT INTO `compradetalle` VALUES ('12', '8', null, '46', '2547.380', '350.000', '0.000', '1', null);

-- ----------------------------
-- Table structure for compraestado
-- ----------------------------
DROP TABLE IF EXISTS `compraestado`;
CREATE TABLE `compraestado` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of compraestado
-- ----------------------------

-- ----------------------------
-- Table structure for garron
-- ----------------------------
DROP TABLE IF EXISTS `garron`;
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

-- ----------------------------
-- Records of garron
-- ----------------------------
INSERT INTO `garron` VALUES ('1', '230', '1', '1', '2018-03-29 22:25:35', '75.421', '10', '1', null, null);
INSERT INTO `garron` VALUES ('2', '231', '1', '2', '2018-03-29 22:25:35', '76.496', '10', '1', null, null);
INSERT INTO `garron` VALUES ('3', '254', '4', '1', '2018-03-29 22:25:35', '75.854', '11', '1', null, null);
INSERT INTO `garron` VALUES ('4', '745', '1', '1', '2018-03-29 22:25:35', '78.520', '11', '1', null, null);
INSERT INTO `garron` VALUES ('5', '123', '1', '1', '2018-03-29 22:25:35', '78.245', '11', '1', null, null);
INSERT INTO `garron` VALUES ('6', '66', '1', '1', '2018-03-29 22:25:35', '98.245', '11', '1', null, null);
INSERT INTO `garron` VALUES ('7', '542', '1', '1', '2018-03-29 22:25:35', '65.250', '11', '1', null, null);
INSERT INTO `garron` VALUES ('8', '321', '1', '1', '2018-03-29 22:25:35', '88.250', '11', '1', null, null);
INSERT INTO `garron` VALUES ('9', '11', '1', '1', '2018-03-29 22:25:35', '98.250', '11', '1', null, null);
INSERT INTO `garron` VALUES ('10', '111', '1', '1', '2018-03-29 22:25:35', '78.525', '11', '1', null, null);
INSERT INTO `garron` VALUES ('11', '652', '1', '1', '2018-03-29 22:25:35', '88.000', '12', '1', null, null);
INSERT INTO `garron` VALUES ('12', '111', '1', '1', '2018-03-29 22:25:35', '11.000', '11', '1', null, null);
INSERT INTO `garron` VALUES ('13', '425', '1', '1', '2018-03-29 22:25:35', '142.250', '11', '1', null, null);
INSERT INTO `garron` VALUES ('14', '458', '1', '1', '2018-03-29 22:25:35', '14.256', '11', '1', null, null);
INSERT INTO `garron` VALUES ('15', '11', '1', '1', '2018-03-29 22:25:35', '25.000', '3', '1', null, null);
INSERT INTO `garron` VALUES ('16', '222', '1', '1', '2018-03-29 22:25:35', '256.000', '11', '1', null, null);
INSERT INTO `garron` VALUES ('17', '333', '1', '1', '2018-03-29 22:25:35', '245.000', '12', '1', null, null);
INSERT INTO `garron` VALUES ('19', '22', '1', '1', '2018-01-25 19:38:55', '200.000', '11', '1', null, null);
INSERT INTO `garron` VALUES ('20', '11', '3', '1', '2018-02-02 19:53:16', '255.000', '1', '1', null, null);
INSERT INTO `garron` VALUES ('21', '222', '1', '1', '2018-03-08 09:06:36', '124.000', '32', '1', null, null);
INSERT INTO `garron` VALUES ('22', '223', '1', '1', '2018-03-12 11:38:31', '84.000', '11', '1', null, null);
INSERT INTO `garron` VALUES ('23', '223', '1', '1', '2018-03-12 11:38:31', '84.000', '11', '1', null, null);
INSERT INTO `garron` VALUES ('24', '222', '1', '1', '2018-03-12 16:50:13', '534.000', '11', '1', null, null);
INSERT INTO `garron` VALUES ('25', '558', '2', '1', '2018-03-17 11:08:13', '624.000', '3', '1', null, null);
INSERT INTO `garron` VALUES ('26', '421', '3', '2', '2018-03-29 22:25:35', '2.580', '4', '1', null, null);
INSERT INTO `garron` VALUES ('27', '333', '6', '2', '2018-03-17 11:18:04', '13.470', '3', '1', null, null);
INSERT INTO `garron` VALUES ('28', '332', '5', '1', '2018-03-17 11:18:26', '66.580', '2', '1', null, null);
INSERT INTO `garron` VALUES ('29', '342', '1', '1', '2018-03-19 17:32:45', '234.000', '1', '1', null, null);
INSERT INTO `garron` VALUES ('30', '213', '3', '1', '2018-03-19 17:33:04', '543.000', '11', '1', null, null);
INSERT INTO `garron` VALUES ('31', '12', '6', '2', '2018-03-19 17:33:29', '34595.000', '12', '1', null, null);
INSERT INTO `garron` VALUES ('32', '22', '2', '1', '2018-03-19 19:06:00', '147.250', '5', '1', null, null);
INSERT INTO `garron` VALUES ('33', '22', '2', '1', '2018-03-19 19:08:07', '123.650', '22', '1', null, null);
INSERT INTO `garron` VALUES ('34', '22', '1', '1', '2018-03-19 19:11:28', '44.254', '11', '1', null, null);
INSERT INTO `garron` VALUES ('35', '22', '2', '1', '2018-03-19 19:13:58', '22.000', '22', '1', null, null);
INSERT INTO `garron` VALUES ('36', '123', '1', '2', '2018-03-29 22:25:35', '2.000', '12', '1', null, null);
INSERT INTO `garron` VALUES ('37', '22', '1', '2', '2018-03-29 22:25:35', '0.550', '12', '1', null, null);
INSERT INTO `garron` VALUES ('38', '22', '1', '2', '2018-03-19 19:55:00', '0.000', '1', '1', null, null);
INSERT INTO `garron` VALUES ('39', '22', '1', '1', '2018-03-19 20:05:15', '321.000', '23', '1', null, null);
INSERT INTO `garron` VALUES ('40', '11', '3', '1', '2018-03-19 20:24:00', '12.000', '11', '1', null, null);
INSERT INTO `garron` VALUES ('41', '22', '1', '1', '2018-03-19 20:42:57', '112.250', '11', '1', null, null);
INSERT INTO `garron` VALUES ('42', '22', '1', '1', '2018-03-19 20:47:26', '11.000', '2', '1', null, null);
INSERT INTO `garron` VALUES ('43', '22', '1', '2', '2018-03-29 22:25:35', '1.750', '11', '1', null, null);
INSERT INTO `garron` VALUES ('44', '22', '2', '2', '2018-03-29 22:25:35', '-24.500', '1', '1', null, null);
INSERT INTO `garron` VALUES ('45', '22', '1', '1', '2018-03-19 21:48:44', '254.000', '11', '1', null, null);
INSERT INTO `garron` VALUES ('46', '55', '1', '1', '2018-03-19 21:51:54', '12.000', '2', '1', null, null);
INSERT INTO `garron` VALUES ('47', '22', '1', '1', '2018-03-19 22:27:57', '55.000', '3', '1', null, null);
INSERT INTO `garron` VALUES ('48', '22', '1', '2', '2018-03-29 22:25:35', '1.250', '1', '1', null, null);
INSERT INTO `garron` VALUES ('49', '22', '3', '1', '2018-03-19 22:36:03', '12.000', '12', '1', null, null);
INSERT INTO `garron` VALUES ('50', '22', '1', '1', '2018-03-19 22:37:38', '125.000', '11', '1', null, null);
INSERT INTO `garron` VALUES ('51', '22', '1', '1', '2018-03-19 22:40:38', '22.000', '1', '1', null, null);
INSERT INTO `garron` VALUES ('52', '22', '1', '1', '2018-03-19 22:43:07', '125.000', '11', '1', null, null);
INSERT INTO `garron` VALUES ('53', '22', '1', '1', '2018-03-19 22:45:57', '1524.250', '1', '1', null, null);
INSERT INTO `garron` VALUES ('54', '22', '1', '1', '2018-03-19 22:48:37', '22.000', '1', '1', null, null);
INSERT INTO `garron` VALUES ('55', '33', '1', '2', '2018-03-29 22:25:35', '0.750', '1', '1', null, null);
INSERT INTO `garron` VALUES ('56', '22', '1', '1', '2018-03-19 22:53:36', '1.000', '1', '1', null, null);
INSERT INTO `garron` VALUES ('57', '22', '1', '1', '2018-03-19 22:59:44', '52.000', '11', '1', null, null);
INSERT INTO `garron` VALUES ('58', '12', '2', '1', '2018-03-19 23:02:59', '11.000', '1', '1', null, null);
INSERT INTO `garron` VALUES ('59', '22', '1', '1', '2018-03-21 17:45:42', '12.000', '1', '1', null, null);
INSERT INTO `garron` VALUES ('60', '2', '1', '1', '2018-03-21 17:59:46', '11.000', '12', '1', null, null);
INSERT INTO `garron` VALUES ('61', '12', '1', '1', '2018-03-21 18:01:06', '12.000', '1', '1', null, null);
INSERT INTO `garron` VALUES ('62', '1', '1', '2', '2018-03-21 18:03:07', '77.000', '1', '1', null, null);
INSERT INTO `garron` VALUES ('63', '235', '1', '1', '2018-03-21 19:51:41', '123.000', '3', '1', null, '');
INSERT INTO `garron` VALUES ('64', '236', '3', '1', '2018-03-21 19:51:53', '123.000', '3', '1', null, 'incompleto');
INSERT INTO `garron` VALUES ('65', '237', '5', '2', '2018-03-29 22:25:35', '191.640', '3', '1', null, '');
INSERT INTO `garron` VALUES ('66', '235', '4', '1', '2018-03-22 17:05:01', '245.000', '11', '1', null, 'garron recortado');
INSERT INTO `garron` VALUES ('67', '235', '4', '1', '2018-04-05 16:53:40', '256.250', '11', '1', null, '');
INSERT INTO `garron` VALUES ('68', '236', '3', '1', '2018-04-05 16:54:12', '122.000', '1', '1', null, '');
INSERT INTO `garron` VALUES ('69', '222', '2', '1', '2018-04-09 18:16:05', '361.250', '11', '1', null, '');
INSERT INTO `garron` VALUES ('70', '333', '1', '1', '2018-04-09 18:16:22', '233.000', '10', '1', null, '');
INSERT INTO `garron` VALUES ('71', '111', '2', '1', '2018-04-09 18:38:50', '14.000', '11', '1', null, '');
INSERT INTO `garron` VALUES ('72', '2', '3', '1', '2018-04-09 19:08:39', '112.000', '11', '1', null, '');

-- ----------------------------
-- Table structure for garrondeposte
-- ----------------------------
DROP TABLE IF EXISTS `garrondeposte`;
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

-- ----------------------------
-- Records of garrondeposte
-- ----------------------------
INSERT INTO `garrondeposte` VALUES ('1', '2', '6', '10.256', '2018-03-29 20:33:39', null, null);
INSERT INTO `garrondeposte` VALUES ('2', '2', '7', '18.620', '2018-03-29 20:33:39', null, null);
INSERT INTO `garrondeposte` VALUES ('3', '2', '8', '20.680', '2018-03-29 20:33:39', null, null);
INSERT INTO `garrondeposte` VALUES ('5', '43', '24', '235.000', '2018-03-29 20:33:39', '1', null);
INSERT INTO `garrondeposte` VALUES ('7', '26', '14', '18.000', '2018-03-29 20:33:39', '1', null);
INSERT INTO `garrondeposte` VALUES ('9', '36', '10', '7.000', '2018-03-29 20:33:39', '1', null);
INSERT INTO `garrondeposte` VALUES ('11', '44', '7', '0.500', '2018-03-29 20:33:39', '1', null);
INSERT INTO `garrondeposte` VALUES ('12', '44', '13', '0.250', '2018-03-29 20:33:39', '1', null);
INSERT INTO `garrondeposte` VALUES ('14', '44', '7', '0.500', '2018-03-29 20:33:39', '1', null);
INSERT INTO `garrondeposte` VALUES ('15', '44', '13', '0.250', '2018-03-29 20:33:39', '1', null);
INSERT INTO `garrondeposte` VALUES ('16', '37', '6', '0.200', '2018-03-29 20:33:39', '1', null);
INSERT INTO `garrondeposte` VALUES ('17', '37', '10', '1.250', '2018-03-29 20:33:39', '1', null);
INSERT INTO `garrondeposte` VALUES ('18', '65', '15', '125.000', '2018-03-29 20:45:35', '1', null);
INSERT INTO `garrondeposte` VALUES ('19', '48', '27', '10.000', '2018-03-29 20:48:23', '1', null);
INSERT INTO `garrondeposte` VALUES ('20', '55', '4', '2.000', '2018-03-29 20:53:09', '1', null);
INSERT INTO `garrondeposte` VALUES ('21', '55', '2', '7.000', '2018-03-29 20:53:09', '1', null);
INSERT INTO `garrondeposte` VALUES ('22', '55', '4', '1.500', '2018-03-29 22:23:37', '1', null);
INSERT INTO `garrondeposte` VALUES ('23', '27', '3', '25.280', '2018-04-11 17:57:29', '1', null);
INSERT INTO `garrondeposte` VALUES ('24', '27', '10', '28.250', '2018-04-11 17:57:29', '1', null);
INSERT INTO `garrondeposte` VALUES ('25', '27', '23', '125.250', '2018-04-11 18:29:33', '1', null);
INSERT INTO `garrondeposte` VALUES ('26', '37', '2', '5.000', '2018-04-13 20:02:03', '1', null);
INSERT INTO `garrondeposte` VALUES ('27', '37', '4', '4.000', '2018-04-13 20:02:03', '1', null);
INSERT INTO `garrondeposte` VALUES ('28', '65', '1', '25.360', '2018-04-13 20:08:07', '1', null);
INSERT INTO `garrondeposte` VALUES ('29', '65', '8', '14.250', '2018-04-13 20:08:08', '1', null);
INSERT INTO `garrondeposte` VALUES ('30', '27', '4', '20.360', '2018-04-13 20:09:31', '1', null);
INSERT INTO `garrondeposte` VALUES ('31', '27', '9', '10.240', '2018-04-13 20:09:31', '1', null);
INSERT INTO `garrondeposte` VALUES ('32', '38', '5', '5.360', '2018-04-13 20:11:31', '1', null);
INSERT INTO `garrondeposte` VALUES ('33', '38', '10', '6.360', '2018-04-13 20:11:31', '1', null);
INSERT INTO `garrondeposte` VALUES ('34', '62', '23', '48.000', '2018-04-17 20:35:56', '1', null);
INSERT INTO `garrondeposte` VALUES ('35', '31', '23', '50.000', '2018-04-17 20:46:59', '1', null);
INSERT INTO `garrondeposte` VALUES ('36', '38', '26', '0.280', '2018-04-17 20:54:25', '1', null);

-- ----------------------------
-- Table structure for garronestado
-- ----------------------------
DROP TABLE IF EXISTS `garronestado`;
CREATE TABLE `garronestado` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of garronestado
-- ----------------------------
INSERT INTO `garronestado` VALUES ('1', 'COMPLETO');
INSERT INTO `garronestado` VALUES ('2', 'DEPOSTE PARCIAL');
INSERT INTO `garronestado` VALUES ('3', 'DEPOSTADO');

-- ----------------------------
-- Table structure for garrontipo
-- ----------------------------
DROP TABLE IF EXISTS `garrontipo`;
CREATE TABLE `garrontipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of garrontipo
-- ----------------------------
INSERT INTO `garrontipo` VALUES ('1', 'TERNERA');
INSERT INTO `garrontipo` VALUES ('2', 'NOVILLITO');
INSERT INTO `garrontipo` VALUES ('3', 'NOVILLO');
INSERT INTO `garrontipo` VALUES ('4', 'VAQUILLONA');
INSERT INTO `garrontipo` VALUES ('5', 'VACA');
INSERT INTO `garrontipo` VALUES ('6', 'TORO');

-- ----------------------------
-- Table structure for modulo
-- ----------------------------
DROP TABLE IF EXISTS `modulo`;
CREATE TABLE `modulo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of modulo
-- ----------------------------
INSERT INTO `modulo` VALUES ('1', 'Clientes');
INSERT INTO `modulo` VALUES ('2', 'Proveedores');
INSERT INTO `modulo` VALUES ('3', 'Stock');
INSERT INTO `modulo` VALUES ('4', 'Caja');
INSERT INTO `modulo` VALUES ('5', 'Ventas');
INSERT INTO `modulo` VALUES ('6', 'Carga Nueva Compra');
INSERT INTO `modulo` VALUES ('7', 'Movimiento Cuentas');
INSERT INTO `modulo` VALUES ('8', 'Gestion Usuarios');
INSERT INTO `modulo` VALUES ('9', 'Productos');
INSERT INTO `modulo` VALUES ('10', 'Ventas Caja');
INSERT INTO `modulo` VALUES ('11', 'Movimiento Cuentas Proveedores');
INSERT INTO `modulo` VALUES ('12', 'Carga Garron');
INSERT INTO `modulo` VALUES ('13', 'Caja Mayorista');
INSERT INTO `modulo` VALUES ('14', 'Ubicacion de Productos');
INSERT INTO `modulo` VALUES ('15', 'Deposte');
INSERT INTO `modulo` VALUES ('16', 'Ubicacion');
INSERT INTO `modulo` VALUES ('17', 'Reportes');
INSERT INTO `modulo` VALUES ('18', 'Compras con Productos a Entregar');

-- ----------------------------
-- Table structure for movimientomercaderia
-- ----------------------------
DROP TABLE IF EXISTS `movimientomercaderia`;
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
) ENGINE=InnoDB AUTO_INCREMENT=92 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of movimientomercaderia
-- ----------------------------
INSERT INTO `movimientomercaderia` VALUES ('1', '2018-03-26 18:34:13', '1', '2', '20.000', '5', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('4', '2018-03-14 19:30:54', '4', '3', '10.000', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('5', '2018-03-14 19:31:00', '4', '3', '10.000', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('7', '2018-03-14 19:42:08', '4', '2', '9.880', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('8', '2018-03-14 19:42:13', '4', '2', '9.880', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('9', '2018-03-14 19:42:16', '4', '3', '534.000', null, '24', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('11', '2018-03-14 19:42:54', '4', '2', '9.880', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('12', '2018-03-14 19:42:54', '4', '2', '9.880', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('13', '2018-03-14 19:42:54', '4', '3', '534.000', null, '24', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('15', '2018-03-14 19:43:10', '4', '2', '9.880', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('16', '2018-03-14 19:43:12', '4', '2', '9.880', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('17', '2018-03-14 19:43:16', '4', '3', '534.000', null, '24', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('19', '2018-03-14 19:43:55', '4', '2', '9.880', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('20', '2018-03-14 19:43:55', '4', '2', '9.880', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('21', '2018-03-14 19:43:55', '4', '3', '534.000', null, '24', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('23', '2018-03-14 19:46:09', '4', '3', '9.880', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('24', '2018-03-14 19:46:09', '4', '3', '9.880', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('25', '2018-03-14 19:46:09', '4', '2', '534.000', null, '24', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('27', '2018-03-14 19:48:38', '4', '2', '9.880', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('28', '2018-03-14 19:48:38', '4', '2', '9.880', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('29', '2018-03-15 19:28:36', '4', '3', '9.800', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('30', '2018-03-15 19:28:36', '4', '2', '12.000', '7', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('31', '2018-03-15 19:28:36', '4', '3', '534.000', null, '24', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('32', '2018-03-15 19:43:52', '4', '3', '0.200', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('33', '2018-03-15 19:46:39', '4', '3', '0.200', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('34', '2018-03-15 19:49:29', '3', '4', '5.980', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('35', '2018-03-15 19:50:26', '3', '4', '5.980', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('36', '2018-03-15 19:50:57', '4', '3', '5.980', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('37', '2018-03-15 19:52:58', '4', '2', '15.800', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('38', '2018-03-15 19:53:56', '4', '2', '15.800', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('39', '2018-03-15 20:08:17', '2', '4', '15.800', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('40', '2018-03-16 18:30:02', '4', '2', '18.200', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('41', '2018-03-16 18:30:31', '4', '2', '18.200', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('42', '2018-03-16 19:47:16', '2', '4', '18.200', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('43', '2018-03-16 19:48:39', '4', '2', '18.200', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('44', '2018-03-16 19:59:34', '2', '3', '18.200', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('45', '2018-03-16 20:00:20', '3', '4', '0.480', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('46', '2018-03-16 20:01:09', '3', '1', '12.000', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('47', '2018-03-16 20:02:20', '3', '1', '5.720', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('48', '2018-03-16 20:04:29', '2', '3', '7.570', '7', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('49', '2018-03-16 20:43:04', '4', '1', '14.600', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('50', '2018-03-16 20:43:04', '1', '3', '12.500', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('51', '2018-03-16 20:43:04', '4', '2', '84.000', null, '23', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('52', '2018-03-16 21:08:21', '4', '2', '2.100', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('53', '2018-03-16 21:08:21', '4', '3', '3.820', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('54', '2018-03-16 21:16:03', '3', '1', '1.570', '7', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('55', '2018-03-16 21:16:03', '3', '2', '2.500', '7', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('56', '2018-03-16 21:16:03', '3', '4', '3.500', '7', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('57', '2018-03-16 21:16:20', '3', '4', '534.000', null, '24', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('58', '2018-03-16 21:51:27', '4', '2', '1.980', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('59', '2018-03-16 21:51:27', '4', '3', '2.400', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('60', '2018-03-16 21:51:27', '4', '1', '1.600', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('61', '2018-03-17 12:37:26', '4', '2', '66.580', null, '28', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('62', '2018-03-19 17:36:16', '4', '2', '34645.000', null, '31', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('63', '2018-03-19 19:18:22', '4', '2', '11.000', null, '36', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('64', '2018-03-19 19:33:47', '4', '2', '11.000', null, '37', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('65', '2018-03-19 19:59:28', '4', '2', '12.000', null, '38', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('66', '2018-03-19 22:39:12', '4', '1', '52.000', '6', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('67', '2018-03-19 22:39:26', '4', '3', '74.000', '8', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('68', '2018-03-19 22:41:15', '4', '3', '22.000', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('69', '2018-03-19 22:47:24', '4', '3', '14.000', '8', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('70', '2018-03-19 22:47:32', '4', '1', '154.000', '10', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('71', '2018-03-19 22:49:44', '4', '3', '22.000', null, '54', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('72', '2018-03-19 23:04:06', '4', '1', '52.000', '16', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('73', '2018-03-19 23:04:08', '4', '3', '145.000', '14', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('74', '2018-03-21 18:04:12', '4', '3', '25.000', '34', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('75', '2018-03-21 18:04:24', '4', '2', '125.000', null, '62', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('76', '2018-03-21 19:58:57', '4', '1', '24.000', '21', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('77', '2018-03-21 19:58:57', '4', '1', '25.000', '23', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('78', '2018-03-21 19:58:57', '4', '3', '123.000', null, '63', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('79', '2018-03-21 19:58:57', '4', '3', '123.000', null, '64', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('80', '2018-03-21 19:58:57', '4', '2', '356.250', null, '65', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('81', '2018-03-22 17:07:45', '4', '3', '20.000', '12', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('82', '2018-03-22 17:07:45', '4', '2', '245.000', null, '66', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('83', '2018-04-05 16:56:57', '4', '1', '26.000', '44', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('84', '2018-04-05 16:57:03', '4', '3', '29.630', '49', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('85', '2018-04-05 16:57:09', '4', '1', '63.000', '46', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('86', '2018-04-05 16:57:12', '4', '3', '256.250', null, '67', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('87', '2018-04-05 16:57:15', '4', '2', '122.000', null, '68', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('88', '2018-04-05 17:01:04', '2', '1', '1.200', '9', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('89', '2018-04-09 18:39:56', '4', '2', '14.000', null, '71', '1', null);
INSERT INTO `movimientomercaderia` VALUES ('90', '2018-04-10 17:45:27', '1', '2', '2.000', '2', null, '1', null);
INSERT INTO `movimientomercaderia` VALUES ('91', '2018-04-10 17:46:09', '2', '3', '1.250', '4', null, '1', null);

-- ----------------------------
-- Table structure for movimientotipo
-- ----------------------------
DROP TABLE IF EXISTS `movimientotipo`;
CREATE TABLE `movimientotipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of movimientotipo
-- ----------------------------
INSERT INTO `movimientotipo` VALUES ('1', 'DEBE');
INSERT INTO `movimientotipo` VALUES ('2', 'PAGO');

-- ----------------------------
-- Table structure for operacion
-- ----------------------------
DROP TABLE IF EXISTS `operacion`;
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
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of operacion
-- ----------------------------
INSERT INTO `operacion` VALUES ('1', '1', '35', '2018-01-24 12:03:13', '1');
INSERT INTO `operacion` VALUES ('2', '1', '41', '2018-01-25 10:32:52', '1');
INSERT INTO `operacion` VALUES ('3', '1', '41', '2018-01-25 10:39:15', '1');
INSERT INTO `operacion` VALUES ('4', '1', '41', '2018-01-25 10:48:13', '1');
INSERT INTO `operacion` VALUES ('5', '1', '41', '2018-01-25 11:45:54', '1');
INSERT INTO `operacion` VALUES ('6', '1', '29', '2018-01-29 12:45:55', '1');
INSERT INTO `operacion` VALUES ('7', '1', '40', '2018-03-01 10:34:53', '1');
INSERT INTO `operacion` VALUES ('8', '1', '41', '2018-03-02 09:51:48', '1');
INSERT INTO `operacion` VALUES ('9', '1', '36', '2018-03-02 10:13:56', '1');
INSERT INTO `operacion` VALUES ('10', '1', '32', '2018-03-02 10:41:17', '1');
INSERT INTO `operacion` VALUES ('11', '1', '30', '2018-03-02 12:23:40', '1');
INSERT INTO `operacion` VALUES ('12', '1', '32', '2018-03-02 12:44:07', '1');
INSERT INTO `operacion` VALUES ('13', '1', '35', '2018-03-02 12:45:42', '1');
INSERT INTO `operacion` VALUES ('14', '1', '41', '2018-03-02 13:05:37', '1');
INSERT INTO `operacion` VALUES ('15', '1', '0', '2018-04-07 18:53:57', '1');
INSERT INTO `operacion` VALUES ('16', '1', '0', '2018-04-13 20:11:46', '1');
INSERT INTO `operacion` VALUES ('17', '1', '0', '2018-04-17 19:03:49', '1');
INSERT INTO `operacion` VALUES ('18', '1', '0', '2018-04-17 19:10:57', '1');
INSERT INTO `operacion` VALUES ('19', '1', '0', '2018-04-17 19:22:16', '1');
INSERT INTO `operacion` VALUES ('20', '1', '0', '2018-04-17 19:28:41', '1');
INSERT INTO `operacion` VALUES ('21', '1', '0', '2018-04-17 19:29:46', '1');
INSERT INTO `operacion` VALUES ('22', '1', '31', '2018-04-17 20:31:27', '1');
INSERT INTO `operacion` VALUES ('23', '1', '31', '2018-04-17 20:33:37', '1');
INSERT INTO `operacion` VALUES ('24', '1', '31', '2018-04-17 20:49:19', '1');

-- ----------------------------
-- Table structure for operacionproveedor
-- ----------------------------
DROP TABLE IF EXISTS `operacionproveedor`;
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

-- ----------------------------
-- Records of operacionproveedor
-- ----------------------------
INSERT INTO `operacionproveedor` VALUES ('4', '3', '1', '2018-04-08 22:37:58', '1');
INSERT INTO `operacionproveedor` VALUES ('5', '3', '1', '2018-04-08 22:39:06', '1');
INSERT INTO `operacionproveedor` VALUES ('6', '3', '1', '2018-04-09 18:08:23', '1');
INSERT INTO `operacionproveedor` VALUES ('7', '3', '2', '2018-04-09 18:29:07', '1');
INSERT INTO `operacionproveedor` VALUES ('8', '3', '2', '2018-04-09 18:39:42', '1');
INSERT INTO `operacionproveedor` VALUES ('9', '3', '1', '2018-04-09 19:09:29', '1');
INSERT INTO `operacionproveedor` VALUES ('10', '3', '1', '2018-04-19 17:59:27', '1');
INSERT INTO `operacionproveedor` VALUES ('11', '3', '2', '2018-04-19 18:04:11', '1');

-- ----------------------------
-- Table structure for operaciontipo
-- ----------------------------
DROP TABLE IF EXISTS `operaciontipo`;
CREATE TABLE `operaciontipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of operaciontipo
-- ----------------------------
INSERT INTO `operaciontipo` VALUES ('1', 'Venta mayorista');
INSERT INTO `operaciontipo` VALUES ('2', 'Movimiento Cuenta');
INSERT INTO `operaciontipo` VALUES ('3', 'Compra proveedor');

-- ----------------------------
-- Table structure for parametros
-- ----------------------------
DROP TABLE IF EXISTS `parametros`;
CREATE TABLE `parametros` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `value` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of parametros
-- ----------------------------
INSERT INTO `parametros` VALUES ('1', 'QENDRA_PATH', 'C:\\Program Files (x86)\\SYSTEL\\Qendra.exe');
INSERT INTO `parametros` VALUES ('2', 'FILE_PRECIOS_SAVE', 'G:\\Escritorio\\balanza\\');

-- ----------------------------
-- Table structure for preciohistorico
-- ----------------------------
DROP TABLE IF EXISTS `preciohistorico`;
CREATE TABLE `preciohistorico` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_producto` int(11) NOT NULL,
  `desde` date NOT NULL,
  `hasta` date DEFAULT NULL,
  `precio` decimal(10,3) NOT NULL,
  `id_usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=185 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of preciohistorico
-- ----------------------------
INSERT INTO `preciohistorico` VALUES ('1', '5', '2017-10-23', '2018-01-10', '115.800', '1', null);
INSERT INTO `preciohistorico` VALUES ('2', '6', '2017-10-23', null, '85.900', '1', null);
INSERT INTO `preciohistorico` VALUES ('3', '7', '2017-10-23', '2018-01-10', '28.500', '1', null);
INSERT INTO `preciohistorico` VALUES ('4', '8', '2017-10-23', '2018-01-10', '115.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('5', '9', '2017-10-23', '2018-01-10', '98.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('6', '10', '2017-10-23', null, '90.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('7', '11', '2017-10-23', '2018-01-10', '90.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('8', '12', '2017-10-23', '2018-01-10', '90.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('9', '13', '2017-10-23', '2018-01-23', '90.000', '1', '2018-01-24 18:33:22');
INSERT INTO `preciohistorico` VALUES ('10', '14', '2017-10-23', '2018-01-10', '80.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('11', '15', '2017-10-23', '2018-01-17', '90.000', '1', '2018-01-18 20:50:51');
INSERT INTO `preciohistorico` VALUES ('12', '16', '2017-10-23', '2018-01-10', '100.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('13', '17', '2017-10-23', '2018-01-17', '135.000', '1', '2018-01-18 20:32:29');
INSERT INTO `preciohistorico` VALUES ('14', '18', '2017-10-23', '2018-01-10', '50.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('15', '19', '2017-10-23', '2018-01-10', '89.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('16', '20', '2017-10-23', '2018-01-10', '10.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('17', '21', '2017-10-23', '2018-01-17', '145.000', '1', '2018-01-18 20:33:08');
INSERT INTO `preciohistorico` VALUES ('18', '22', '2017-10-23', null, '140.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('19', '23', '2017-10-23', null, '135.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('20', '24', '2017-10-23', null, '140.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('21', '25', '2017-10-23', null, '125.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('22', '26', '2017-10-23', null, '135.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('23', '27', '2017-10-23', null, '160.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('24', '28', '2017-10-23', null, '92.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('25', '29', '2017-10-23', null, '125.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('26', '30', '2017-10-23', null, '99.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('27', '31', '2017-10-23', null, '125.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('28', '32', '2017-10-23', '2018-01-17', '170.000', '1', '2018-01-18 20:27:33');
INSERT INTO `preciohistorico` VALUES ('29', '33', '2017-10-23', null, '170.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('30', '34', '2017-10-23', null, '180.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('31', '35', '2017-10-23', null, '145.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('32', '36', '2017-10-23', null, '180.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('33', '37', '2017-10-23', null, '145.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('34', '38', '2017-10-23', null, '145.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('35', '39', '2017-10-23', '2018-01-10', '145.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('36', '40', '2017-10-23', null, '145.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('37', '41', '2017-10-23', null, '140.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('38', '42', '2017-10-23', null, '140.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('39', '43', '2017-10-23', null, '135.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('40', '44', '2017-10-23', null, '140.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('42', '5', '2017-10-01', '2017-10-22', '92.640', '1', null);
INSERT INTO `preciohistorico` VALUES ('43', '6', '2017-10-01', '2017-10-22', '68.720', '1', null);
INSERT INTO `preciohistorico` VALUES ('44', '7', '2017-10-01', '2017-10-22', '35.260', '1', null);
INSERT INTO `preciohistorico` VALUES ('45', '8', '2017-10-01', '2017-10-22', '92.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('46', '9', '2017-10-01', '2017-10-22', '78.400', '1', null);
INSERT INTO `preciohistorico` VALUES ('47', '10', '2017-10-01', '2017-10-22', '72.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('48', '11', '2017-10-01', '2017-10-22', '72.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('49', '12', '2017-10-01', '2017-10-22', '72.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('50', '13', '2017-10-01', '2017-10-22', '64.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('51', '14', '2017-10-01', '2017-10-22', '64.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('52', '15', '2017-10-01', '2017-10-22', '72.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('53', '16', '2017-10-01', '2017-10-22', '80.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('54', '17', '2017-10-01', '2017-10-22', '108.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('55', '18', '2017-10-01', '2017-10-22', '40.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('56', '19', '2017-10-01', '2017-10-22', '71.200', '1', null);
INSERT INTO `preciohistorico` VALUES ('57', '20', '2017-10-01', '2017-10-22', '8.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('58', '21', '2017-10-01', '2017-10-22', '116.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('59', '22', '2017-10-01', '2017-10-22', '112.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('60', '23', '2017-10-01', '2017-10-22', '108.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('61', '24', '2017-10-01', '2017-10-22', '112.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('62', '25', '2017-10-01', '2017-10-22', '100.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('63', '26', '2017-10-01', '2017-10-22', '108.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('64', '27', '2017-10-01', '2017-10-22', '128.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('65', '28', '2017-10-01', '2017-10-22', '73.600', '1', null);
INSERT INTO `preciohistorico` VALUES ('66', '29', '2017-10-01', '2017-10-22', '100.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('67', '30', '2017-10-01', '2017-10-22', '79.200', '1', null);
INSERT INTO `preciohistorico` VALUES ('68', '31', '2017-10-01', '2017-10-22', '100.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('69', '32', '2017-10-01', '2017-10-22', '136.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('70', '33', '2017-10-01', '2017-10-22', '136.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('71', '34', '2017-10-01', '2017-10-22', '144.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('72', '35', '2017-10-01', '2017-10-22', '116.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('73', '36', '2017-10-01', '2017-10-22', '144.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('74', '37', '2017-10-01', '2017-10-22', '116.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('75', '38', '2017-10-01', '2017-10-22', '116.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('76', '39', '2017-10-01', '2017-10-22', '116.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('77', '40', '2017-10-01', '2017-10-22', '116.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('78', '41', '2017-10-01', '2017-10-22', '112.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('79', '42', '2017-10-01', '2017-10-22', '112.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('80', '43', '2017-10-01', '2017-10-22', '108.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('81', '44', '2017-10-01', '2017-10-22', '112.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('83', '9', '2018-01-11', null, '105.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('84', '11', '2018-01-11', '2018-01-23', '105.000', '1', '2018-01-24 18:05:13');
INSERT INTO `preciohistorico` VALUES ('86', '12', '2018-01-11', '2018-01-17', '99.000', '1', '2018-01-18 20:34:14');
INSERT INTO `preciohistorico` VALUES ('87', '14', '2018-01-11', '2018-01-17', '89.000', '1', '2018-01-18 20:19:21');
INSERT INTO `preciohistorico` VALUES ('88', '18', '2018-01-11', null, '56.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('89', '19', '2018-01-11', '2018-01-23', '98.000', '1', '2018-01-24 18:35:45');
INSERT INTO `preciohistorico` VALUES ('90', '39', '2018-01-11', null, '160.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('92', '20', '2018-01-11', '2018-01-17', '42.000', '1', '2018-01-18 20:34:44');
INSERT INTO `preciohistorico` VALUES ('93', '7', '2018-01-11', null, '37.335', '1', null);
INSERT INTO `preciohistorico` VALUES ('94', '16', '2018-01-11', '2018-01-14', '125.520', '1', null);
INSERT INTO `preciohistorico` VALUES ('95', '8', '2018-01-11', '2018-01-14', '127.650', '1', null);
INSERT INTO `preciohistorico` VALUES ('96', '5', '2018-01-11', '2018-01-17', '130.622', '1', '2018-01-18 20:17:23');
INSERT INTO `preciohistorico` VALUES ('97', '52', '2018-01-11', null, '528.450', '1', null);
INSERT INTO `preciohistorico` VALUES ('98', '55', '2018-01-11', null, '658.250', '1', null);
INSERT INTO `preciohistorico` VALUES ('99', '8', '2018-01-15', null, '162.360', '1', null);
INSERT INTO `preciohistorico` VALUES ('100', '16', '2018-01-15', '2018-01-17', '150.624', '1', '2018-01-18 20:49:14');
INSERT INTO `preciohistorico` VALUES ('101', '63', '2018-01-15', null, '0.389', '1', null);
INSERT INTO `preciohistorico` VALUES ('102', '50', '2018-01-15', null, '0.871', '1', null);
INSERT INTO `preciohistorico` VALUES ('103', '49', '2018-01-15', null, '16.608', '1', null);
INSERT INTO `preciohistorico` VALUES ('104', '76', '2018-01-15', null, '18.298', '1', null);
INSERT INTO `preciohistorico` VALUES ('105', '56', '2018-01-15', null, '22.916', '1', null);
INSERT INTO `preciohistorico` VALUES ('106', '64', '2018-01-15', null, '23.365', '1', null);
INSERT INTO `preciohistorico` VALUES ('107', '68', '2018-01-15', null, '45.531', '1', null);
INSERT INTO `preciohistorico` VALUES ('108', '69', '2018-01-15', null, '45.574', '1', null);
INSERT INTO `preciohistorico` VALUES ('109', '78', '2018-01-15', null, '50.293', '1', null);
INSERT INTO `preciohistorico` VALUES ('110', '62', '2018-01-15', null, '59.526', '1', null);
INSERT INTO `preciohistorico` VALUES ('111', '59', '2018-01-15', null, '60.978', '1', null);
INSERT INTO `preciohistorico` VALUES ('112', '73', '2018-01-15', null, '63.535', '1', null);
INSERT INTO `preciohistorico` VALUES ('113', '70', '2018-01-15', null, '91.278', '1', null);
INSERT INTO `preciohistorico` VALUES ('114', '77', '2018-01-15', null, '101.037', '1', null);
INSERT INTO `preciohistorico` VALUES ('115', '58', '2018-01-15', '2018-01-17', '105.052', '1', '2018-01-18 20:39:05');
INSERT INTO `preciohistorico` VALUES ('116', '66', '2018-01-15', null, '108.201', '1', null);
INSERT INTO `preciohistorico` VALUES ('117', '65', '2018-01-15', null, '115.659', '1', null);
INSERT INTO `preciohistorico` VALUES ('118', '71', '2018-01-15', '2018-01-23', '119.669', '1', '2018-01-24 18:08:29');
INSERT INTO `preciohistorico` VALUES ('119', '72', '2018-01-15', null, '124.508', '1', null);
INSERT INTO `preciohistorico` VALUES ('120', '75', '2018-01-15', null, '130.150', '1', null);
INSERT INTO `preciohistorico` VALUES ('121', '74', '2018-01-15', null, '144.151', '1', null);
INSERT INTO `preciohistorico` VALUES ('122', '51', '2018-01-15', null, '154.531', '1', null);
INSERT INTO `preciohistorico` VALUES ('123', '57', '2018-01-15', null, '154.760', '1', null);
INSERT INTO `preciohistorico` VALUES ('124', '61', '2018-01-15', null, '165.747', '1', null);
INSERT INTO `preciohistorico` VALUES ('125', '53', '2018-01-15', null, '170.040', '1', null);
INSERT INTO `preciohistorico` VALUES ('126', '54', '2018-01-15', '2018-01-26', '186.607', '1', '2018-01-27 01:32:03');
INSERT INTO `preciohistorico` VALUES ('127', '60', '2018-01-15', null, '189.736', '1', null);
INSERT INTO `preciohistorico` VALUES ('128', '67', '2018-01-15', null, '194.027', '1', null);
INSERT INTO `preciohistorico` VALUES ('129', '5', '2018-01-18', null, '156.746', '1', null);
INSERT INTO `preciohistorico` VALUES ('130', '14', '2018-01-18', null, '289.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('131', '32', '2018-01-18', null, '184.260', '1', null);
INSERT INTO `preciohistorico` VALUES ('132', '17', '2018-01-18', null, '148.287', '1', null);
INSERT INTO `preciohistorico` VALUES ('133', '21', '2018-01-18', null, '174.300', '1', null);
INSERT INTO `preciohistorico` VALUES ('134', '12', '2018-01-18', '2018-01-23', '200.000', '1', '2018-01-24 18:36:18');
INSERT INTO `preciohistorico` VALUES ('135', '20', '2018-01-18', null, '98.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('136', '58', '2018-01-18', null, '201.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('137', '16', '2018-01-18', null, '250.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('138', '15', '2018-01-18', null, '112.117', '1', null);
INSERT INTO `preciohistorico` VALUES ('139', '11', '2018-01-24', null, '208.600', '1', null);
INSERT INTO `preciohistorico` VALUES ('140', '71', '2018-01-24', null, '25.300', '1', null);
INSERT INTO `preciohistorico` VALUES ('141', '13', '2018-01-24', null, '180.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('142', '19', '2018-01-24', null, '196.000', '1', null);
INSERT INTO `preciohistorico` VALUES ('143', '12', '2018-01-24', null, '450.000', '1', '2018-01-24 18:37:07');
INSERT INTO `preciohistorico` VALUES ('144', '54', '2018-01-27', null, '214.598', '1', null);
INSERT INTO `preciohistorico` VALUES ('145', '1', '2018-04-03', '2018-04-03', '256.250', '1', '2018-04-04 19:06:48');
INSERT INTO `preciohistorico` VALUES ('146', '2', '2018-04-03', null, '328.250', '1', null);
INSERT INTO `preciohistorico` VALUES ('147', '3', '2018-04-03', '2018-04-03', '129.740', '1', '2018-04-04 19:03:03');
INSERT INTO `preciohistorico` VALUES ('148', '4', '2018-04-03', null, '75.590', '1', null);
INSERT INTO `preciohistorico` VALUES ('149', '45', '2018-04-03', null, '116.230', '1', null);
INSERT INTO `preciohistorico` VALUES ('150', '46', '2018-04-03', null, '250.280', '1', null);
INSERT INTO `preciohistorico` VALUES ('151', '47', '2018-04-03', null, '37.920', '1', null);
INSERT INTO `preciohistorico` VALUES ('152', '48', '2018-04-03', null, '40.125', '1', null);
INSERT INTO `preciohistorico` VALUES ('153', '79', '2018-04-03', null, '275.670', '1', null);
INSERT INTO `preciohistorico` VALUES ('154', '80', '2018-04-03', null, '216.650', '1', null);
INSERT INTO `preciohistorico` VALUES ('155', '81', '2018-04-03', null, '156.250', '1', null);
INSERT INTO `preciohistorico` VALUES ('156', '82', '2018-04-03', null, '232.290', '1', null);
INSERT INTO `preciohistorico` VALUES ('157', '83', '2018-04-03', null, '190.730', '1', null);
INSERT INTO `preciohistorico` VALUES ('158', '84', '2018-04-03', null, '156.790', '1', null);
INSERT INTO `preciohistorico` VALUES ('159', '85', '2018-04-03', null, '111.760', '1', null);
INSERT INTO `preciohistorico` VALUES ('160', '86', '2018-04-03', null, '189.410', '1', null);
INSERT INTO `preciohistorico` VALUES ('161', '87', '2018-04-03', null, '109.790', '1', null);
INSERT INTO `preciohistorico` VALUES ('162', '88', '2018-04-03', null, '282.740', '1', null);
INSERT INTO `preciohistorico` VALUES ('163', '89', '2018-04-03', null, '180.340', '1', null);
INSERT INTO `preciohistorico` VALUES ('164', '90', '2018-04-03', null, '154.460', '1', null);
INSERT INTO `preciohistorico` VALUES ('165', '91', '2018-04-03', null, '131.270', '1', null);
INSERT INTO `preciohistorico` VALUES ('166', '92', '2018-04-03', null, '294.010', '1', null);
INSERT INTO `preciohistorico` VALUES ('167', '93', '2018-04-03', null, '172.230', '1', null);
INSERT INTO `preciohistorico` VALUES ('168', '94', '2018-04-03', null, '281.140', '1', null);
INSERT INTO `preciohistorico` VALUES ('169', '95', '2018-04-03', null, '186.010', '1', null);
INSERT INTO `preciohistorico` VALUES ('170', '96', '2018-04-03', null, '187.630', '1', null);
INSERT INTO `preciohistorico` VALUES ('171', '97', '2018-04-03', null, '280.120', '1', null);
INSERT INTO `preciohistorico` VALUES ('172', '98', '2018-04-03', null, '134.700', '1', null);
INSERT INTO `preciohistorico` VALUES ('173', '99', '2018-04-03', null, '135.180', '1', null);
INSERT INTO `preciohistorico` VALUES ('174', '100', '2018-04-03', null, '171.780', '1', null);
INSERT INTO `preciohistorico` VALUES ('175', '101', '2018-04-03', null, '152.390', '1', null);
INSERT INTO `preciohistorico` VALUES ('176', '102', '2018-04-03', null, '146.600', '1', null);
INSERT INTO `preciohistorico` VALUES ('177', '103', '2018-04-03', null, '175.840', '1', null);
INSERT INTO `preciohistorico` VALUES ('178', '104', '2018-04-03', null, '138.390', '1', null);
INSERT INTO `preciohistorico` VALUES ('179', '105', '2018-04-03', null, '265.440', '1', null);
INSERT INTO `preciohistorico` VALUES ('180', '106', '2018-04-03', null, '209.050', '1', null);
INSERT INTO `preciohistorico` VALUES ('181', '107', '2018-04-03', null, '148.920', '1', null);
INSERT INTO `preciohistorico` VALUES ('182', '3', '2018-04-04', null, '179.740', '1', null);
INSERT INTO `preciohistorico` VALUES ('183', '1', '2018-04-04', '2018-04-10', '280.280', '1', '2018-04-11 17:26:15');
INSERT INTO `preciohistorico` VALUES ('184', '1', '2018-04-11', null, '281.210', '1', null);

-- ----------------------------
-- Table structure for producto
-- ----------------------------
DROP TABLE IF EXISTS `producto`;
CREATE TABLE `producto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_producto_tipo` int(11) NOT NULL,
  `id_codigo_barra` varchar(6) DEFAULT NULL,
  `precio` decimal(10,3) NOT NULL,
  `cantidad` decimal(10,2) NOT NULL,
  `descripcion_breve` varchar(18) NOT NULL,
  `descripcion_larga` varchar(100) NOT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_precio` (`precio`)
) ENGINE=InnoDB AUTO_INCREMENT=108 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of producto
-- ----------------------------
INSERT INTO `producto` VALUES ('1', '2', '11750', '281.210', '50.00', 'TRIPA', 'TRIPA', '1', null);
INSERT INTO `producto` VALUES ('2', '2', '11760', '328.250', '50.00', 'CHINCHULÍN', 'CHINCHULÍN', '1', null);
INSERT INTO `producto` VALUES ('3', '2', '11770', '179.740', '50.00', 'RIÑON', 'RIÑON', '1', null);
INSERT INTO `producto` VALUES ('4', '2', '11780', '75.590', '50.00', 'CORAZÓN', 'CORAZÓN', '1', null);
INSERT INTO `producto` VALUES ('5', '2', '11790', '91.610', '50.00', 'ENTRAÑA', 'ENTRAÑA', '1', null);
INSERT INTO `producto` VALUES ('6', '2', '11800', '112.700', '50.00', 'RABO', 'RABO', '1', null);
INSERT INTO `producto` VALUES ('7', '2', '11810', '111.020', '50.00', 'MONDONGO', 'MONDONGO', '1', null);
INSERT INTO `producto` VALUES ('8', '2', '11820', '26.480', '50.00', 'HÍGADO', 'HÍGADO', '1', null);
INSERT INTO `producto` VALUES ('9', '2', '11830', '147.850', '50.00', 'MOLLEJAS', 'MOLLEJAS', '1', null);
INSERT INTO `producto` VALUES ('10', '2', '11850', '124.760', '50.00', 'LENGUA', 'LENGUA', '1', null);
INSERT INTO `producto` VALUES ('11', '2', '11860', '147.950', '50.00', 'QUIJADA', 'QUIJADA', '1', null);
INSERT INTO `producto` VALUES ('12', '2', '11870', '111.750', '50.00', 'DUOS', 'DUOS', '1', null);
INSERT INTO `producto` VALUES ('13', '2', '11880', '76.250', '50.00', 'CARRE ', 'CARRE ', '1', null);
INSERT INTO `producto` VALUES ('14', '2', '11890', '64.160', '50.00', 'PECHITO', 'PECHITO', '1', null);
INSERT INTO `producto` VALUES ('15', '2', '11900', '57.160', '50.00', 'JAMON ENTERO', 'JAMON ENTERO', '1', null);
INSERT INTO `producto` VALUES ('16', '2', '11910', '143.550', '50.00', 'CHURRASQUITO', 'CHURRASQUITO', '1', null);
INSERT INTO `producto` VALUES ('17', '2', '11920', '153.140', '50.00', 'PALETA ENTERA', 'PALETA ENTERA', '1', null);
INSERT INTO `producto` VALUES ('18', '2', '11930', '82.180', '50.00', 'PAPADA', 'PAPADA', '1', null);
INSERT INTO `producto` VALUES ('19', '2', '11940', '103.810', '50.00', 'TOCINO', 'TOCINO', '1', null);
INSERT INTO `producto` VALUES ('20', '2', '11950', '116.780', '50.00', 'MATAMBRITOS', 'MATAMBRITOS', '1', null);
INSERT INTO `producto` VALUES ('21', '2', '11960', '114.800', '50.00', 'BONDIOLA', 'BONDIOLA', '1', null);
INSERT INTO `producto` VALUES ('22', '3', null, '97.230', '50.00', '1/2 RESES', '1/2 RESES', '1', null);
INSERT INTO `producto` VALUES ('23', '3', null, '47.830', '100.00', '1/4 RUEDA', '1/4 RUEDA', '1', null);
INSERT INTO `producto` VALUES ('24', '3', null, '59.850', '50.00', '1/4 PISTOLA', '1/4 PISTOLA', '1', null);
INSERT INTO `producto` VALUES ('25', '3', null, '73.830', '50.00', ' 1/4 DELANTERO ', ' 1/4 DELANTERO ', '1', null);
INSERT INTO `producto` VALUES ('26', '3', null, '103.910', '0.28', 'BARRAS', 'BARRAS', '1', null);
INSERT INTO `producto` VALUES ('27', '3', null, '130.530', '50.00', 'MOCHITOS', 'MOCHITOS', '1', null);
INSERT INTO `producto` VALUES ('28', '3', null, '134.400', '50.00', 'MANTAS', 'MANTAS', '1', null);
INSERT INTO `producto` VALUES ('29', '3', null, '106.050', '50.00', 'RECORTE', 'RECORTE', '1', null);
INSERT INTO `producto` VALUES ('30', '3', null, '56.560', '50.00', 'PARRILLERO', 'PARRILLERO', '1', null);
INSERT INTO `producto` VALUES ('31', '3', null, '98.580', '50.00', 'JUEGOS DE ACHURAS', 'JUEGOS DE ACHURAS', '1', null);
INSERT INTO `producto` VALUES ('32', '3', null, '85.370', '50.00', 'RECORTE DE 1', 'RECORTE DE 1', '1', null);
INSERT INTO `producto` VALUES ('33', '3', null, '49.460', '50.00', 'RECORTE DE 2°', 'RECORTE DE 2°', '1', null);
INSERT INTO `producto` VALUES ('34', '1', '10990', '48.950', '50.00', 'CHORIZO ESPECIAL', 'CHORIZO ESPECIAL', '1', null);
INSERT INTO `producto` VALUES ('35', '1', '11000', '53.330', '130.00', 'CHORIZO PARRILLERO', 'CHORIZO PARRILLERO', '1', null);
INSERT INTO `producto` VALUES ('36', '1', '11010', '125.560', '50.00', 'CHORIZO DE CERDO', 'CHORIZO DE CERDO', '1', null);
INSERT INTO `producto` VALUES ('37', '1', '11020', '31.580', '50.00', 'CHORIZO COLORADO', 'CHORIZO COLORADO', '1', null);
INSERT INTO `producto` VALUES ('38', '1', '11030', '41.820', '50.00', 'SALCHICHA PARRILL.', 'SALCHICHA PARRILL.', '1', null);
INSERT INTO `producto` VALUES ('39', '1', '11040', '144.400', '50.00', 'MORCILLA', 'MORCILLA', '1', null);
INSERT INTO `producto` VALUES ('40', '1', '11050', '72.380', '50.00', 'MORCILLA', 'MORCILLA', '1', null);
INSERT INTO `producto` VALUES ('41', '1', '11060', '54.580', '50.00', 'SALCHICHAS SNACK', 'SALCHICHAS SNACK', '1', null);
INSERT INTO `producto` VALUES ('42', '1', '11070', '38.680', '50.00', 'PATE', 'PATE', '1', null);
INSERT INTO `producto` VALUES ('43', '1', '11080', '107.300', '50.00', 'QUESO DE CERDO', 'QUESO DE CERDO', '1', null);
INSERT INTO `producto` VALUES ('44', '1', '11100', '30.120', '78.00', 'PICADA COMUN', 'PICADA COMUN', '1', null);
INSERT INTO `producto` VALUES ('45', '1', '11110', '116.230', '50.00', 'PICADA INTERMEDIA', 'PICADA INTERMEDIA', '1', null);
INSERT INTO `producto` VALUES ('46', '1', '11120', '250.280', '460.00', 'PICADA ESPECIAL', 'PICADA ESPECIAL', '1', null);
INSERT INTO `producto` VALUES ('47', '1', '11130', '37.920', '50.00', 'PUCHERO COMUN', 'PUCHERO COMUN', '1', null);
INSERT INTO `producto` VALUES ('48', '1', '11140', '40.125', '50.00', 'PUCHERO ESPECIAL', 'PUCHERO ESPECIAL', '1', null);
INSERT INTO `producto` VALUES ('49', '1', '11150', '41.230', '50.00', 'CANINO', 'CANINO', '1', null);
INSERT INTO `producto` VALUES ('50', '1', '11160', '92.220', '50.00', 'MATAMBRE', 'MATAMBRE', '1', null);
INSERT INTO `producto` VALUES ('51', '1', '11170', '111.710', '50.00', 'VACIO', 'VACIO', '1', null);
INSERT INTO `producto` VALUES ('52', '1', '11180', '106.860', '50.00', 'ALA DE PECHO', 'ALA DE PECHO', '1', null);
INSERT INTO `producto` VALUES ('53', '1', '11190', '133.860', '50.00', 'COSTILLA', 'COSTILLA', '1', null);
INSERT INTO `producto` VALUES ('54', '1', '11200', '30.180', '50.00', 'MARUCHA', 'MARUCHA', '1', null);
INSERT INTO `producto` VALUES ('55', '1', '11210', '112.810', '50.00', 'TAPA DE NALGA', 'TAPA DE NALGA', '1', null);
INSERT INTO `producto` VALUES ('56', '1', '11220', '47.510', '50.00', 'CORTE MALVINA', 'CORTE MALVINA', '1', null);
INSERT INTO `producto` VALUES ('57', '1', '11230', '39.460', '50.00', 'FALDA', 'FALDA', '1', null);
INSERT INTO `producto` VALUES ('58', '1', '11240', '136.620', '50.00', 'COSTELETAS', 'COSTELETAS', '1', null);
INSERT INTO `producto` VALUES ('59', '1', '11250', '105.710', '50.00', 'AGUJA', 'AGUJA', '1', null);
INSERT INTO `producto` VALUES ('60', '1', '11260', '57.700', '50.00', 'BRAZUELO', 'BRAZUELO', '1', null);
INSERT INTO `producto` VALUES ('61', '1', '11270', '36.160', '50.00', 'BIFE ANCHO/ANGOSTO', 'BIFE ANCHO/ANGOSTO', '1', null);
INSERT INTO `producto` VALUES ('62', '1', '11280', '114.390', '50.00', 'ENTRECOT', 'ENTRECOT', '1', null);
INSERT INTO `producto` VALUES ('63', '1', '11290', '87.570', '50.00', 'ROAST BEEF', 'ROAST BEEF', '1', null);
INSERT INTO `producto` VALUES ('64', '1', '11300', '114.240', '50.00', 'NALGAS', 'NALGAS', '1', null);
INSERT INTO `producto` VALUES ('65', '1', '11310', '43.250', '50.00', 'LOMO', 'LOMO', '1', null);
INSERT INTO `producto` VALUES ('66', '1', '11320', '36.660', '50.00', 'PECETO', 'PECETO', '1', null);
INSERT INTO `producto` VALUES ('67', '1', '11330', '61.650', '50.00', 'CUADRIL', 'CUADRIL', '1', null);
INSERT INTO `producto` VALUES ('68', '1', '11340', '123.510', '50.00', 'PALOMITA', 'PALOMITA', '1', null);
INSERT INTO `producto` VALUES ('69', '1', '11350', '130.630', '50.00', 'JAMON CUADRADO', 'JAMON CUADRADO', '1', null);
INSERT INTO `producto` VALUES ('70', '1', '11360', '46.800', '50.00', 'CABEZA DE LOMO', 'CABEZA DE LOMO', '1', null);
INSERT INTO `producto` VALUES ('71', '1', '11370', '108.510', '50.00', 'PULPA BRAZUELO', 'PULPA BRAZUELO', '1', null);
INSERT INTO `producto` VALUES ('72', '1', '11380', '149.570', '50.00', 'PULPA PALETA', 'PULPA PALETA', '1', null);
INSERT INTO `producto` VALUES ('73', '1', '11390', '25.880', '50.00', 'TORTUGUITA', 'TORTUGUITA', '1', null);
INSERT INTO `producto` VALUES ('74', '1', '11400', '142.610', '50.00', 'MILANESAS DE CARNE', 'MILANESAS DE CARNE', '1', null);
INSERT INTO `producto` VALUES ('75', '1', '11410', '55.910', '50.00', 'MILANESAS DE POLLO', 'MILANESAS DE POLLO', '1', null);
INSERT INTO `producto` VALUES ('76', '1', '11420', '63.670', '50.00', 'HAMBURGUESAS', 'HAMBURGUESAS', '1', null);
INSERT INTO `producto` VALUES ('77', '1', '11430', '38.150', '50.00', 'ALBONDIGAS', 'ALBONDIGAS', '1', null);
INSERT INTO `producto` VALUES ('78', '1', '11440', '125.670', '50.00', 'COSTELETAS', 'COSTELETAS', '1', null);
INSERT INTO `producto` VALUES ('79', '1', '11450', '138.760', '50.00', 'BONDIOLA', 'BONDIOLA', '1', null);
INSERT INTO `producto` VALUES ('80', '1', '11460', '83.870', '50.00', 'MATAMBRITO', 'MATAMBRITO', '1', null);
INSERT INTO `producto` VALUES ('81', '1', '11470', '69.460', '50.00', 'COSTILLA/PECHITO', 'COSTILLA/PECHITO', '1', null);
INSERT INTO `producto` VALUES ('82', '1', '11480', '28.950', '50.00', 'PULPAS', 'PULPAS', '1', null);
INSERT INTO `producto` VALUES ('83', '1', '11490', '37.080', '50.00', 'MARUCHA', 'MARUCHA', '1', null);
INSERT INTO `producto` VALUES ('84', '1', '11500', '141.580', '50.00', 'CARACU', 'CARACU', '1', null);
INSERT INTO `producto` VALUES ('85', '1', '11510', '69.250', '50.00', 'PAT./HUE./CUE.', 'PATITA/HUESITO/CUERITO', '1', null);
INSERT INTO `producto` VALUES ('86', '1', '11520', '79.810', '50.00', 'MILANESAS', 'MILANESAS', '1', null);
INSERT INTO `producto` VALUES ('87', '1', '11530', '77.840', '50.00', 'HAMBURGUESAS', 'HAMBURGUESAS', '1', null);
INSERT INTO `producto` VALUES ('88', '1', '11540', '78.480', '50.00', 'PATAMUSLO', 'PATAMUSLO', '1', null);
INSERT INTO `producto` VALUES ('89', '1', '11550', '122.900', '50.00', 'TROZADO', 'TROZADO', '1', null);
INSERT INTO `producto` VALUES ('90', '1', '11560', '89.560', '50.00', 'PECHUGA', 'PECHUGA', '1', null);
INSERT INTO `producto` VALUES ('91', '1', '11570', '41.960', '50.00', 'FILET', 'FILET', '1', null);
INSERT INTO `producto` VALUES ('92', '1', '11580', '135.130', '50.00', 'BROCHET', 'BROCHET', '1', null);
INSERT INTO `producto` VALUES ('93', '1', '11590', '130.990', '50.00', 'BONDIOLA', 'BONDIOLA', '1', null);
INSERT INTO `producto` VALUES ('94', '1', '11600', '108.720', '50.00', 'PALETA', 'PALETA', '1', null);
INSERT INTO `producto` VALUES ('95', '1', '11610', '61.440', '50.00', 'JAMON COCIDO', 'JAMON COCIDO', '1', null);
INSERT INTO `producto` VALUES ('96', '1', '11620', '110.730', '50.00', 'JAMON CRUDO', 'JAMON CRUDO', '1', null);
INSERT INTO `producto` VALUES ('97', '1', '11630', '102.460', '50.00', 'SALAME MILAN', 'SALAME MILAN', '1', null);
INSERT INTO `producto` VALUES ('98', '1', '11640', '34.330', '50.00', 'SALAMIN', 'SALAMIN', '1', null);
INSERT INTO `producto` VALUES ('99', '1', '11650', '117.640', '50.00', 'QUESO BARRA', 'QUESO BARRA', '1', null);
INSERT INTO `producto` VALUES ('100', '1', '11660', '61.960', '50.00', 'CREMOSO', 'CREMOSO', '1', null);
INSERT INTO `producto` VALUES ('101', '1', '11670', '129.930', '50.00', 'CASCARA COLORADA', 'CASCARA COLORADA', '1', null);
INSERT INTO `producto` VALUES ('102', '1', '11680', '53.510', '50.00', 'QUESO CRE', 'QUESO CRE', '1', null);
INSERT INTO `producto` VALUES ('103', '1', '11690', '51.580', '50.00', 'QUESO TREEMBLAY', 'QUESO TREEMBLAY', '1', null);
INSERT INTO `producto` VALUES ('104', '1', '11700', '54.320', '50.00', 'QUESO PROVOLETA', 'QUESO PROVOLETA', '1', null);
INSERT INTO `producto` VALUES ('105', '1', '11710', '126.280', '50.00', 'QUESO SARDO', 'QUESO SARDO', '1', null);
INSERT INTO `producto` VALUES ('106', '1', '11720', '78.640', '50.00', 'MORTADELA', 'MORTADELA', '1', null);
INSERT INTO `producto` VALUES ('107', '1', '11730', '122.700', '50.00', 'MORTADELA', 'MORTADELA', '1', null);

-- ----------------------------
-- Table structure for productotipo
-- ----------------------------
DROP TABLE IF EXISTS `productotipo`;
CREATE TABLE `productotipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of productotipo
-- ----------------------------
INSERT INTO `productotipo` VALUES ('1', 'VENTAS CAJA');
INSERT INTO `productotipo` VALUES ('2', 'VENTAS MINORISTA');
INSERT INTO `productotipo` VALUES ('3', 'VENTAS MAYORISTA');

-- ----------------------------
-- Table structure for productoubicacion
-- ----------------------------
DROP TABLE IF EXISTS `productoubicacion`;
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
) ENGINE=InnoDB AUTO_INCREMENT=187 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of productoubicacion
-- ----------------------------
INSERT INTO `productoubicacion` VALUES ('6', '34', null, '3', '31.420', null, '2018-03-15 19:28:36', '1', null);
INSERT INTO `productoubicacion` VALUES ('7', '7', null, '2', '6.930', null, '2018-03-15 19:28:36', '1', null);
INSERT INTO `productoubicacion` VALUES ('14', '9', null, '1', '21.020', null, '2018-03-16 20:01:09', '1', null);
INSERT INTO `productoubicacion` VALUES ('16', '9', null, '3', '48.560', null, '2018-03-16 20:43:04', '1', null);
INSERT INTO `productoubicacion` VALUES ('17', null, '23', '2', '84.000', null, '2018-03-16 20:43:04', '1', null);
INSERT INTO `productoubicacion` VALUES ('18', '9', null, '2', '0.900', null, '2018-03-16 21:08:21', '1', null);
INSERT INTO `productoubicacion` VALUES ('19', '7', null, '1', '1.570', null, '2018-03-16 21:16:03', '1', null);
INSERT INTO `productoubicacion` VALUES ('20', null, '24', '4', '534.000', null, '2018-03-16 21:16:20', '1', null);
INSERT INTO `productoubicacion` VALUES ('21', '34', null, '2', '1.980', null, '2018-03-16 21:51:27', '1', null);
INSERT INTO `productoubicacion` VALUES ('22', '34', null, '1', '1.600', null, '2018-03-16 21:51:27', '1', null);
INSERT INTO `productoubicacion` VALUES ('23', null, '25', '4', '624.000', null, '2018-03-17 11:08:41', '1', null);
INSERT INTO `productoubicacion` VALUES ('24', null, '26', '4', '32.580', null, '2018-03-17 11:11:52', '1', null);
INSERT INTO `productoubicacion` VALUES ('25', null, '27', '4', '222.850', null, '2018-03-17 11:18:49', '1', null);
INSERT INTO `productoubicacion` VALUES ('27', null, '28', '2', '66.580', null, '2018-03-17 12:37:26', '1', null);
INSERT INTO `productoubicacion` VALUES ('28', null, '29', '4', '234.000', null, '2018-03-19 17:34:09', '1', null);
INSERT INTO `productoubicacion` VALUES ('29', null, '30', '4', '543.000', null, '2018-03-19 17:34:09', '1', null);
INSERT INTO `productoubicacion` VALUES ('31', null, '31', '2', '3464.500', null, '2018-03-19 17:36:28', '1', null);
INSERT INTO `productoubicacion` VALUES ('34', null, '32', '4', '147.250', null, '2018-03-19 19:07:13', '1', null);
INSERT INTO `productoubicacion` VALUES ('37', null, '33', '4', '123.650', null, '2018-03-19 19:09:20', '1', null);
INSERT INTO `productoubicacion` VALUES ('39', '26', null, '4', '0.000', '2018-04-17 20:49:19', '2018-03-19 19:12:35', '1', null);
INSERT INTO `productoubicacion` VALUES ('40', null, '34', '4', '44.254', null, '2018-03-19 19:12:35', '1', null);
INSERT INTO `productoubicacion` VALUES ('42', '33', null, '4', '50.000', null, '2018-03-19 19:14:37', '1', null);
INSERT INTO `productoubicacion` VALUES ('43', null, '35', '4', '22.000', null, '2018-03-19 19:14:37', '1', null);
INSERT INTO `productoubicacion` VALUES ('45', '25', null, '4', '50.000', null, '2018-03-19 19:16:37', '1', null);
INSERT INTO `productoubicacion` VALUES ('47', null, '36', '2', '11.000', null, '2018-03-19 19:18:22', '1', null);
INSERT INTO `productoubicacion` VALUES ('49', '45', null, '4', '50.000', null, '2018-03-19 19:31:18', '1', null);
INSERT INTO `productoubicacion` VALUES ('51', null, '37', '2', '11.000', null, '2018-03-19 19:34:04', '1', null);
INSERT INTO `productoubicacion` VALUES ('55', null, '38', '2', '12.000', null, '2018-03-19 19:59:28', '1', null);
INSERT INTO `productoubicacion` VALUES ('57', null, '39', '4', '321.000', null, '2018-03-19 20:05:44', '1', null);
INSERT INTO `productoubicacion` VALUES ('59', '15', null, '4', '22.000', null, '2018-03-19 20:24:54', '1', null);
INSERT INTO `productoubicacion` VALUES ('60', null, '40', '4', '12.000', null, '2018-03-19 20:24:54', '1', null);
INSERT INTO `productoubicacion` VALUES ('63', null, '41', '4', '112.250', null, '2018-03-19 20:45:17', '1', null);
INSERT INTO `productoubicacion` VALUES ('66', null, '42', '4', '11.000', null, '2018-03-19 20:48:19', '1', null);
INSERT INTO `productoubicacion` VALUES ('70', null, '43', '4', '251.000', null, '2018-03-19 20:55:59', '1', null);
INSERT INTO `productoubicacion` VALUES ('71', '5', null, '4', '43.000', null, '2018-03-19 21:00:28', '1', null);
INSERT INTO `productoubicacion` VALUES ('72', '19', null, '4', '31.000', null, '2018-03-19 21:00:28', '1', null);
INSERT INTO `productoubicacion` VALUES ('73', null, '44', '4', '25.000', null, '2018-03-19 21:00:28', '1', null);
INSERT INTO `productoubicacion` VALUES ('74', '6', null, '4', '52.000', null, '2018-03-19 21:49:31', '1', null);
INSERT INTO `productoubicacion` VALUES ('75', '20', null, '4', '85.000', null, '2018-03-19 21:49:31', '1', null);
INSERT INTO `productoubicacion` VALUES ('76', null, '45', '4', '254.000', null, '2018-03-19 21:49:31', '1', null);
INSERT INTO `productoubicacion` VALUES ('77', '55', null, '4', '25.000', null, '2018-03-19 21:52:34', '1', null);
INSERT INTO `productoubicacion` VALUES ('78', '65', null, '4', '85.000', null, '2018-03-19 21:52:34', '1', null);
INSERT INTO `productoubicacion` VALUES ('79', null, '46', '4', '12.000', null, '2018-03-19 21:52:34', '1', null);
INSERT INTO `productoubicacion` VALUES ('80', '8', null, '4', '36.250', null, '2018-03-19 22:28:40', '1', null);
INSERT INTO `productoubicacion` VALUES ('81', '17', null, '4', '52.000', null, '2018-03-19 22:28:40', '1', null);
INSERT INTO `productoubicacion` VALUES ('82', null, '47', '4', '55.000', null, '2018-03-19 22:28:40', '1', null);
INSERT INTO `productoubicacion` VALUES ('83', '10', null, '4', '25.000', null, '2018-03-19 22:34:39', '1', null);
INSERT INTO `productoubicacion` VALUES ('85', null, '48', '4', '11.250', null, '2018-03-19 22:34:39', '1', null);
INSERT INTO `productoubicacion` VALUES ('86', '12', null, '4', '22.000', null, '2018-03-19 22:36:37', '1', null);
INSERT INTO `productoubicacion` VALUES ('87', '13', null, '4', '23.500', null, '2018-03-19 22:36:37', '1', null);
INSERT INTO `productoubicacion` VALUES ('88', null, '49', '4', '12.000', null, '2018-03-19 22:36:37', '1', null);
INSERT INTO `productoubicacion` VALUES ('92', '6', null, '1', '52.000', null, '2018-03-19 22:39:15', '1', null);
INSERT INTO `productoubicacion` VALUES ('93', '8', null, '3', '88.000', null, '2018-03-19 22:39:30', '1', null);
INSERT INTO `productoubicacion` VALUES ('98', null, '52', '4', '125.000', null, '2018-03-19 22:43:46', '1', null);
INSERT INTO `productoubicacion` VALUES ('101', null, '53', '4', '1524.250', null, '2018-03-19 22:46:45', '1', null);
INSERT INTO `productoubicacion` VALUES ('102', '10', null, '1', '160.360', null, '2018-03-19 22:47:38', '1', null);
INSERT INTO `productoubicacion` VALUES ('104', null, '54', '3', '22.000', null, '2018-03-19 22:49:46', '1', null);
INSERT INTO `productoubicacion` VALUES ('105', '7', null, '4', '52.000', null, '2018-03-19 22:51:03', '1', null);
INSERT INTO `productoubicacion` VALUES ('106', '16', null, '4', '48.000', null, '2018-03-19 22:51:03', '1', null);
INSERT INTO `productoubicacion` VALUES ('107', null, '55', '4', '11.250', null, '2018-03-19 22:51:03', '1', null);
INSERT INTO `productoubicacion` VALUES ('109', null, '56', '4', '1.000', null, '2018-03-19 22:54:31', '1', null);
INSERT INTO `productoubicacion` VALUES ('111', null, '57', '4', '52.000', null, '2018-03-19 23:00:05', '1', null);
INSERT INTO `productoubicacion` VALUES ('113', '14', null, '4', '145.000', null, '2018-03-19 23:03:41', '1', null);
INSERT INTO `productoubicacion` VALUES ('114', null, '58', '4', '11.000', null, '2018-03-19 23:03:41', '1', null);
INSERT INTO `productoubicacion` VALUES ('115', '16', null, '1', '52.000', null, '2018-03-19 23:04:07', '1', null);
INSERT INTO `productoubicacion` VALUES ('116', '14', null, '3', '145.000', null, '2018-03-19 23:04:09', '1', null);
INSERT INTO `productoubicacion` VALUES ('118', null, '59', '4', '12.000', null, '2018-03-21 17:46:09', '1', null);
INSERT INTO `productoubicacion` VALUES ('120', null, '60', '4', '11.000', null, '2018-03-21 18:00:09', '1', null);
INSERT INTO `productoubicacion` VALUES ('121', '28', null, '4', '50.000', null, '2018-03-21 18:01:29', '1', null);
INSERT INTO `productoubicacion` VALUES ('122', null, '61', '4', '12.000', null, '2018-03-21 18:01:29', '1', null);
INSERT INTO `productoubicacion` VALUES ('125', null, '62', '2', '125.000', null, '2018-03-21 18:04:27', '1', null);
INSERT INTO `productoubicacion` VALUES ('126', '21', null, '4', '0.000', '2018-03-21 19:58:57', '2018-03-21 19:56:59', '1', null);
INSERT INTO `productoubicacion` VALUES ('128', null, '63', '4', '0.000', '2018-03-21 19:58:57', '2018-03-21 19:57:08', '1', null);
INSERT INTO `productoubicacion` VALUES ('129', null, '64', '4', '0.000', '2018-03-21 19:58:57', '2018-03-21 19:57:10', '1', null);
INSERT INTO `productoubicacion` VALUES ('130', null, '65', '4', '0.000', '2018-03-21 19:58:57', '2018-03-21 19:57:12', '1', null);
INSERT INTO `productoubicacion` VALUES ('131', '21', null, '1', '24.000', null, '2018-03-21 19:58:57', '1', null);
INSERT INTO `productoubicacion` VALUES ('132', '23', null, '1', '25.000', null, '2018-03-21 19:58:57', '1', null);
INSERT INTO `productoubicacion` VALUES ('133', null, '63', '3', '123.000', null, '2018-03-21 19:58:57', '1', null);
INSERT INTO `productoubicacion` VALUES ('134', null, '64', '3', '123.000', null, '2018-03-21 19:58:57', '1', null);
INSERT INTO `productoubicacion` VALUES ('135', null, '65', '2', '356.250', null, '2018-03-21 19:58:57', '1', null);
INSERT INTO `productoubicacion` VALUES ('137', null, '66', '4', '0.000', '2018-03-22 17:07:45', '2018-03-22 17:06:45', '1', null);
INSERT INTO `productoubicacion` VALUES ('138', '12', null, '3', '20.000', null, '2018-03-22 17:07:45', '1', null);
INSERT INTO `productoubicacion` VALUES ('139', null, '66', '2', '245.000', null, '2018-03-22 17:07:45', '1', null);
INSERT INTO `productoubicacion` VALUES ('140', '30', null, '2', '14.250', null, '2018-03-29 16:53:32', '1', null);
INSERT INTO `productoubicacion` VALUES ('141', '24', null, '3', '235.000', null, '2018-03-29 16:53:43', '1', null);
INSERT INTO `productoubicacion` VALUES ('142', '3', null, '2', '37.280', null, '2018-03-29 16:56:07', '1', null);
INSERT INTO `productoubicacion` VALUES ('143', '2', null, '1', '0.000', '2018-04-10 17:45:27', '2018-03-29 16:58:40', '1', null);
INSERT INTO `productoubicacion` VALUES ('144', '10', null, '2', '36.500', null, '2018-03-29 16:59:30', '1', null);
INSERT INTO `productoubicacion` VALUES ('145', '5', null, '3', '53.360', null, '2018-03-29 20:20:51', '1', null);
INSERT INTO `productoubicacion` VALUES ('146', '7', null, '3', '1.000', null, '2018-03-29 20:21:11', '1', null);
INSERT INTO `productoubicacion` VALUES ('147', '6', null, '3', '0.200', null, '2018-03-29 20:33:39', '1', null);
INSERT INTO `productoubicacion` VALUES ('148', '15', null, '1', '125.000', null, '2018-03-29 20:45:21', '1', null);
INSERT INTO `productoubicacion` VALUES ('149', '27', null, '3', '10.000', null, '2018-03-29 20:48:23', '1', null);
INSERT INTO `productoubicacion` VALUES ('150', '4', null, '2', '21.110', null, '2018-03-29 20:53:09', '1', null);
INSERT INTO `productoubicacion` VALUES ('151', '2', null, '4', '7.000', null, '2018-03-29 20:53:09', '1', null);
INSERT INTO `productoubicacion` VALUES ('152', '4', null, '1', '1.500', null, '2018-03-29 22:23:37', '1', null);
INSERT INTO `productoubicacion` VALUES ('153', '44', null, '4', '0.000', '2018-04-05 16:56:54', '2018-04-05 16:55:16', '1', null);
INSERT INTO `productoubicacion` VALUES ('154', '49', null, '4', '0.000', '2018-04-05 16:57:00', '2018-04-05 16:55:16', '1', null);
INSERT INTO `productoubicacion` VALUES ('155', '46', null, '4', '0.000', '2018-04-05 16:57:06', '2018-04-05 16:55:16', '1', null);
INSERT INTO `productoubicacion` VALUES ('156', null, '67', '4', '0.000', '2018-04-05 16:57:12', '2018-04-05 16:55:16', '1', null);
INSERT INTO `productoubicacion` VALUES ('157', null, '68', '4', '0.000', '2018-04-05 16:57:15', '2018-04-05 16:55:16', '1', null);
INSERT INTO `productoubicacion` VALUES ('158', '44', null, '1', '26.000', null, '2018-04-05 16:56:57', '1', null);
INSERT INTO `productoubicacion` VALUES ('159', '49', null, '3', '29.630', null, '2018-04-05 16:57:03', '1', null);
INSERT INTO `productoubicacion` VALUES ('160', '46', null, '1', '63.000', null, '2018-04-05 16:57:09', '1', null);
INSERT INTO `productoubicacion` VALUES ('161', null, '67', '3', '256.250', null, '2018-04-05 16:57:12', '1', null);
INSERT INTO `productoubicacion` VALUES ('162', null, '68', '2', '122.000', null, '2018-04-05 16:57:15', '1', null);
INSERT INTO `productoubicacion` VALUES ('163', '46', null, '4', '253.250', null, '2018-04-09 18:30:03', '1', null);
INSERT INTO `productoubicacion` VALUES ('164', '47', null, '4', '200.000', null, '2018-04-09 18:30:05', '1', null);
INSERT INTO `productoubicacion` VALUES ('165', null, '69', '4', '361.250', null, '2018-04-09 18:30:10', '1', null);
INSERT INTO `productoubicacion` VALUES ('166', null, '70', '4', '233.000', null, '2018-04-09 18:30:13', '1', null);
INSERT INTO `productoubicacion` VALUES ('167', null, '71', '4', '0.000', '2018-04-09 18:39:56', '2018-04-09 18:39:45', '1', null);
INSERT INTO `productoubicacion` VALUES ('168', null, '71', '2', '14.000', null, '2018-04-09 18:39:56', '1', null);
INSERT INTO `productoubicacion` VALUES ('169', '44', null, '4', '25.360', null, '2018-04-09 19:09:29', '1', null);
INSERT INTO `productoubicacion` VALUES ('170', '51', null, '4', '38.000', null, '2018-04-09 19:09:29', '1', null);
INSERT INTO `productoubicacion` VALUES ('171', null, '72', '4', '112.000', null, '2018-04-09 19:09:29', '1', null);
INSERT INTO `productoubicacion` VALUES ('172', '2', null, '2', '7.000', null, '2018-04-10 17:45:27', '1', null);
INSERT INTO `productoubicacion` VALUES ('173', '4', null, '3', '5.250', null, '2018-04-10 17:46:09', '1', null);
INSERT INTO `productoubicacion` VALUES ('174', '23', null, '2', '125.250', null, '2018-04-11 18:29:33', '1', null);
INSERT INTO `productoubicacion` VALUES ('175', '1', null, '3', '25.360', null, '2018-04-13 20:08:07', '1', null);
INSERT INTO `productoubicacion` VALUES ('176', '22', null, '4', '50.000', null, '2018-03-19 19:16:37', '1', null);
INSERT INTO `productoubicacion` VALUES ('177', '23', null, '4', '100.000', null, '2018-03-19 19:16:37', '1', null);
INSERT INTO `productoubicacion` VALUES ('178', '24', null, '4', '50.000', null, '2018-03-19 19:16:37', '1', null);
INSERT INTO `productoubicacion` VALUES ('179', '27', null, '4', '50.000', null, '2018-03-19 19:16:37', '1', null);
INSERT INTO `productoubicacion` VALUES ('180', '29', null, '4', '50.000', null, '2018-03-19 19:16:37', '1', null);
INSERT INTO `productoubicacion` VALUES ('182', '26', null, '4', '0.280', null, '2018-04-17 20:54:25', '1', null);
INSERT INTO `productoubicacion` VALUES ('183', '35', null, '4', '50.000', null, '2018-04-19 17:59:27', '1', null);
INSERT INTO `productoubicacion` VALUES ('184', '46', null, '4', '20.000', null, '2018-04-19 17:59:27', '1', null);
INSERT INTO `productoubicacion` VALUES ('185', '44', null, '4', '15.000', null, '2018-04-19 18:04:12', '1', null);
INSERT INTO `productoubicacion` VALUES ('186', '46', null, '4', '350.000', null, '2018-04-19 18:04:12', '1', null);

-- ----------------------------
-- Table structure for proveedor
-- ----------------------------
DROP TABLE IF EXISTS `proveedor`;
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

-- ----------------------------
-- Records of proveedor
-- ----------------------------
INSERT INTO `proveedor` VALUES ('1', 'Friar', 'santiago del estero 1234', 'santa fe', 'RI', 'Friar S.A.', '20-12345678-1', '034212345678', 'Federico Lopez', '2017-11-16', null, null);
INSERT INTO `proveedor` VALUES ('2', 'Frigar', 'urquiza 1810', 'santa fe', 'CF', 'LOCAL', '20315634231', '3239487', 'HUGO', '2017-11-17', null, '0');
INSERT INTO `proveedor` VALUES ('3', 'este proveedor', 'provsad', 'prov', 'poa', 'orpo', 'ops', 'por', 'poasdp', '2017-11-24', null, '0');
INSERT INTO `proveedor` VALUES ('4', 'CompraProveedor', 'dire prove 123', 'santa fe', 'CF', 'Local Santiago', '20329590934', '4258', 'Santiago', '2017-10-16', null, '1');

-- ----------------------------
-- Table structure for proveedorcuenta
-- ----------------------------
DROP TABLE IF EXISTS `proveedorcuenta`;
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

-- ----------------------------
-- Records of proveedorcuenta
-- ----------------------------
INSERT INTO `proveedorcuenta` VALUES ('1', '1238238923892234', 'EFECTIVO', '1', '2017-11-12 19:53:42', '1', '1', null);
INSERT INTO `proveedorcuenta` VALUES ('2', '1238238923892236', 'EFECTIVO', '1', '2017-11-12 19:53:39', '2', '1', null);
INSERT INTO `proveedorcuenta` VALUES ('3', '2222', 'EFECTIVO', '2', '2017-11-12 19:53:29', '4', '0', null);
INSERT INTO `proveedorcuenta` VALUES ('4', 'aaa', 'EFECTIVO', '2', '2017-11-12 19:53:32', '3', '0', null);
INSERT INTO `proveedorcuenta` VALUES ('5', '52145312', 'EFECTIVO', '3', '2017-11-16 17:36:32', '1', '0', null);
INSERT INTO `proveedorcuenta` VALUES ('6', '12313', 'EFECTIVO', '3', '2017-11-16 17:51:57', '1', '0', null);
INSERT INTO `proveedorcuenta` VALUES ('7', '1234', 'EFECTIVO', '4', '2017-11-29 09:17:12', '1', '0', null);
INSERT INTO `proveedorcuenta` VALUES ('8', '1234', 'EFECTIVO', '4', '2017-11-29 09:18:04', '1', '0', null);

-- ----------------------------
-- Table structure for proveedorcuentamovimiento
-- ----------------------------
DROP TABLE IF EXISTS `proveedorcuentamovimiento`;
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

-- ----------------------------
-- Records of proveedorcuentamovimiento
-- ----------------------------
INSERT INTO `proveedorcuentamovimiento` VALUES ('1', '1', '1', '1', '600', '2017-11-14 17:24:30', 'N', '0');
INSERT INTO `proveedorcuentamovimiento` VALUES ('2', '1', '1', '2', '600', '2017-11-15 11:54:13', 'N', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('3', '1', '3', '1', '500', '2017-11-15 11:55:15', 'N', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('4', '1', '3', '2', '1000', '2017-11-15 12:00:06', 'N', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('5', '0', '1', '1', '11', '2018-03-09 12:48:20', 'N', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('6', '0', '1', '1', '22', '2018-03-09 12:52:13', 'N', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('7', '16', '4', '1', '12179.97', '2018-04-09 18:29:19', 'N', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('8', '16', '4', '2', '12179.97', '2018-04-09 18:29:34', 'S', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('9', '8', '4', '1', '256.36', '2018-04-09 18:39:45', 'N', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('10', '8', '4', '2', '100', '2018-04-09 18:39:45', 'S', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('11', '9', '1', '1', '7950.76', '2018-04-09 19:09:29', 'N', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('12', '9', '1', '2', '7950.76', '2018-04-09 19:09:29', 'S', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('13', '10', '1', '1', '3751.25', '2018-04-19 17:59:27', 'N', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('14', '10', '1', '2', '3751.25', '2018-04-19 17:59:27', 'S', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('15', '11', '4', '1', '2897.74', '2018-04-19 18:04:12', 'N', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('16', '11', '4', '2', '2897.74', '2018-04-19 18:04:12', 'S', '1');

-- ----------------------------
-- Table structure for ubicacion
-- ----------------------------
DROP TABLE IF EXISTS `ubicacion`;
CREATE TABLE `ubicacion` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of ubicacion
-- ----------------------------
INSERT INTO `ubicacion` VALUES ('1', 'SALON DE VENTAS');
INSERT INTO `ubicacion` VALUES ('2', 'CAMARA GRANDE');
INSERT INTO `ubicacion` VALUES ('3', 'CAMARA CHICA');
INSERT INTO `ubicacion` VALUES ('4', 'DEPOSITO');

-- ----------------------------
-- Table structure for usuario
-- ----------------------------
DROP TABLE IF EXISTS `usuario`;
CREATE TABLE `usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(20) CHARACTER SET latin1 NOT NULL,
  `pass` varchar(20) CHARACTER SET latin1 NOT NULL,
  `nombre` varchar(50) CHARACTER SET latin1 DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- ----------------------------
-- Records of usuario
-- ----------------------------
INSERT INTO `usuario` VALUES ('1', 'a', 'a', 'aa');
INSERT INTO `usuario` VALUES ('2', 'prueba', 'prueba', 'prueba');

-- ----------------------------
-- Table structure for usuarioingreso
-- ----------------------------
DROP TABLE IF EXISTS `usuarioingreso`;
CREATE TABLE `usuarioingreso` (
  `id` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_use` (`id_usuario`),
  CONSTRAINT `fk_use` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- ----------------------------
-- Records of usuarioingreso
-- ----------------------------
INSERT INTO `usuarioingreso` VALUES ('1', '1', '2017-09-02', '11:26:00');

-- ----------------------------
-- Table structure for usuariomodulo
-- ----------------------------
DROP TABLE IF EXISTS `usuariomodulo`;
CREATE TABLE `usuariomodulo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_usuario` int(11) NOT NULL,
  `id_modulo` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_mod` (`id_modulo`),
  KEY `fk_us` (`id_usuario`),
  CONSTRAINT `fk_mod` FOREIGN KEY (`id_modulo`) REFERENCES `modulo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_us` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of usuariomodulo
-- ----------------------------
INSERT INTO `usuariomodulo` VALUES ('1', '1', '1');
INSERT INTO `usuariomodulo` VALUES ('2', '1', '2');
INSERT INTO `usuariomodulo` VALUES ('3', '1', '3');
INSERT INTO `usuariomodulo` VALUES ('4', '1', '4');
INSERT INTO `usuariomodulo` VALUES ('5', '1', '7');
INSERT INTO `usuariomodulo` VALUES ('6', '1', '9');
INSERT INTO `usuariomodulo` VALUES ('7', '1', '10');
INSERT INTO `usuariomodulo` VALUES ('8', '1', '11');
INSERT INTO `usuariomodulo` VALUES ('15', '2', '12');
INSERT INTO `usuariomodulo` VALUES ('16', '2', '1');
INSERT INTO `usuariomodulo` VALUES ('17', '2', '2');
INSERT INTO `usuariomodulo` VALUES ('18', '2', '4');
INSERT INTO `usuariomodulo` VALUES ('19', '2', '9');
INSERT INTO `usuariomodulo` VALUES ('20', '2', '11');
INSERT INTO `usuariomodulo` VALUES ('21', '2', '12');
INSERT INTO `usuariomodulo` VALUES ('23', '1', '13');
INSERT INTO `usuariomodulo` VALUES ('24', '1', '6');
INSERT INTO `usuariomodulo` VALUES ('25', '1', '14');
INSERT INTO `usuariomodulo` VALUES ('26', '1', '15');
INSERT INTO `usuariomodulo` VALUES ('27', '1', '16');
INSERT INTO `usuariomodulo` VALUES ('28', '1', '17');
INSERT INTO `usuariomodulo` VALUES ('29', '1', '18');

-- ----------------------------
-- Table structure for venta
-- ----------------------------
DROP TABLE IF EXISTS `venta`;
CREATE TABLE `venta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `monto_total` decimal(10,3) NOT NULL,
  `fecha` datetime NOT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  `id_operacion` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of venta
-- ----------------------------
INSERT INTO `venta` VALUES ('2', '2541.000', '2018-01-24 12:03:13', '1', null, '1');
INSERT INTO `venta` VALUES ('3', '153.000', '2018-01-25 10:28:39', '1', null, '0');
INSERT INTO `venta` VALUES ('4', '88.000', '2018-01-25 10:32:52', '1', null, '0');
INSERT INTO `venta` VALUES ('5', '1958.000', '2018-01-25 10:39:15', '1', null, '3');
INSERT INTO `venta` VALUES ('6', '1306.000', '2018-01-25 10:48:13', '1', null, '4');
INSERT INTO `venta` VALUES ('7', '3828.000', '2018-01-25 11:45:54', '1', null, '5');
INSERT INTO `venta` VALUES ('8', '12782.000', '2018-01-29 12:45:55', '1', null, '6');
INSERT INTO `venta` VALUES ('9', '1590.000', '2018-03-01 10:34:53', '1', null, '7');
INSERT INTO `venta` VALUES ('10', '2640.000', '2018-03-02 09:51:48', '1', null, '8');
INSERT INTO `venta` VALUES ('11', '89.000', '2018-03-02 10:13:56', '1', null, '9');
INSERT INTO `venta` VALUES ('12', '77.000', '2018-03-02 10:41:17', '1', null, '10');
INSERT INTO `venta` VALUES ('13', '5123.000', '2018-03-02 12:23:39', '1', null, '11');
INSERT INTO `venta` VALUES ('14', '35310.000', '2018-03-02 12:44:07', '1', null, '12');
INSERT INTO `venta` VALUES ('15', '7872.000', '2018-03-02 12:45:42', '1', null, '13');
INSERT INTO `venta` VALUES ('16', '88.000', '2018-03-02 13:05:37', '1', null, '14');
INSERT INTO `venta` VALUES ('17', '4303.000', '2018-04-07 18:53:57', '1', null, '0');
INSERT INTO `venta` VALUES ('18', '169.500', '2018-04-13 20:11:46', '1', null, '0');
INSERT INTO `venta` VALUES ('19', '9570.000', '2018-04-17 19:03:56', '1', null, '17');
INSERT INTO `venta` VALUES ('20', '9920.000', '2018-04-17 19:10:59', '1', null, '18');
INSERT INTO `venta` VALUES ('21', '3700.000', '2018-04-17 19:22:17', '1', null, '19');
INSERT INTO `venta` VALUES ('22', '5200.000', '2018-04-17 19:28:41', '1', null, '20');
INSERT INTO `venta` VALUES ('23', '6800.000', '2018-04-17 19:29:46', '1', null, '21');
INSERT INTO `venta` VALUES ('24', '4200.000', '2018-04-17 20:31:27', '1', null, '22');
INSERT INTO `venta` VALUES ('25', '50.000', '2018-04-17 20:33:37', '1', null, '23');
INSERT INTO `venta` VALUES ('26', '6000.000', '2018-04-17 20:49:19', '1', null, '24');

-- ----------------------------
-- Table structure for ventadetalle
-- ----------------------------
DROP TABLE IF EXISTS `ventadetalle`;
CREATE TABLE `ventadetalle` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_venta` int(11) NOT NULL,
  `id_producto` int(11) NOT NULL,
  `monto` decimal(10,3) NOT NULL,
  `peso` decimal(10,3) DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_liquidacion` (`id_venta`),
  KEY `fk_produ` (`id_producto`)
) ENGINE=InnoDB AUTO_INCREMENT=220 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of ventadetalle
-- ----------------------------
INSERT INTO `ventadetalle` VALUES ('4', '0', '1', '105.000', '0.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('5', '0', '2', '328.000', '1.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('6', '0', '3', '674.000', '3.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('7', '0', '3', '674.000', '3.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('8', '0', '2', '328.000', '1.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('9', '0', '1', '105.000', '0.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('10', '0', '3', '674.000', '3.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('11', '0', '2', '328.000', '1.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('12', '0', '1', '105.000', '0.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('13', '4', '3', '674.000', '3.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('14', '4', '2', '328.000', '1.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('15', '4', '1', '105.000', '0.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('16', '5', '1', '105.000', '0.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('17', '6', '3', '674.525', '3.646', '1', null);
INSERT INTO `ventadetalle` VALUES ('18', '6', '2', '328.349', '1.427', '1', null);
INSERT INTO `ventadetalle` VALUES ('19', '6', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('20', '7', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('21', '7', '2', '451.294', '1.962', '1', null);
INSERT INTO `ventadetalle` VALUES ('22', '7', '3', '553.618', '2.992', '1', null);
INSERT INTO `ventadetalle` VALUES ('23', '8', '2', '451.294', '1.962', '1', null);
INSERT INTO `ventadetalle` VALUES ('24', '8', '3', '553.618', '2.992', '1', null);
INSERT INTO `ventadetalle` VALUES ('25', '8', '2', '748.952', '3.256', '1', null);
INSERT INTO `ventadetalle` VALUES ('26', '8', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('27', '9', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('28', '9', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('29', '9', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('30', '9', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('31', '9', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('32', '9', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('33', '10', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('34', '10', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('35', '10', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('36', '10', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('37', '10', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('38', '10', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('39', '10', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('40', '10', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('41', '10', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('42', '10', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('43', '10', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('44', '10', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('45', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('46', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('47', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('48', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('49', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('50', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('51', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('52', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('53', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('54', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('55', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('56', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('57', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('58', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('59', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('60', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('61', '11', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('62', '12', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('63', '12', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('64', '12', '1', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('65', '12', '2', '451.294', '1.962', '1', null);
INSERT INTO `ventadetalle` VALUES ('66', '12', '3', '553.618', '2.992', '1', null);
INSERT INTO `ventadetalle` VALUES ('67', '12', '2', '748.952', '3.256', '1', null);
INSERT INTO `ventadetalle` VALUES ('68', '13', '2', '748.952', '3.256', '1', null);
INSERT INTO `ventadetalle` VALUES ('69', '13', '2', '451.294', '1.962', '1', null);
INSERT INTO `ventadetalle` VALUES ('70', '13', '3', '553.618', '2.992', '1', null);
INSERT INTO `ventadetalle` VALUES ('71', '13', '3', '553.618', '2.992', '1', null);
INSERT INTO `ventadetalle` VALUES ('72', '14', '35', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('73', '14', '35', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('74', '14', '39', '703.127', '4.849', '1', null);
INSERT INTO `ventadetalle` VALUES ('75', '14', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('76', '14', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('77', '14', '6', '178.621', '2.101', '1', null);
INSERT INTO `ventadetalle` VALUES ('78', '15', '6', '178.621', '2.101', '1', null);
INSERT INTO `ventadetalle` VALUES ('79', '15', '6', '178.621', '2.101', '1', null);
INSERT INTO `ventadetalle` VALUES ('80', '15', '6', '178.621', '2.101', '1', null);
INSERT INTO `ventadetalle` VALUES ('81', '15', '6', '178.621', '2.101', '1', null);
INSERT INTO `ventadetalle` VALUES ('82', '15', '6', '178.621', '2.101', '1', null);
INSERT INTO `ventadetalle` VALUES ('83', '15', '6', '178.621', '2.101', '1', null);
INSERT INTO `ventadetalle` VALUES ('84', '15', '6', '178.621', '2.101', '1', null);
INSERT INTO `ventadetalle` VALUES ('85', '15', '6', '178.621', '2.101', '1', null);
INSERT INTO `ventadetalle` VALUES ('86', '15', '6', '178.621', '2.101', '1', null);
INSERT INTO `ventadetalle` VALUES ('87', '15', '6', '178.621', '2.101', '1', null);
INSERT INTO `ventadetalle` VALUES ('88', '15', '6', '178.621', '2.101', '1', null);
INSERT INTO `ventadetalle` VALUES ('89', '15', '6', '178.621', '2.101', '1', null);
INSERT INTO `ventadetalle` VALUES ('90', '15', '6', '178.621', '2.101', '1', null);
INSERT INTO `ventadetalle` VALUES ('91', '15', '6', '451.294', '5.309', '1', null);
INSERT INTO `ventadetalle` VALUES ('92', '15', '6', '451.294', '5.309', '1', null);
INSERT INTO `ventadetalle` VALUES ('93', '15', '6', '451.294', '5.309', '1', null);
INSERT INTO `ventadetalle` VALUES ('94', '15', '6', '451.294', '5.309', '1', null);
INSERT INTO `ventadetalle` VALUES ('95', '15', '6', '451.294', '5.309', '1', null);
INSERT INTO `ventadetalle` VALUES ('96', '15', '6', '451.294', '5.309', '1', null);
INSERT INTO `ventadetalle` VALUES ('97', '15', '6', '451.294', '5.309', '1', null);
INSERT INTO `ventadetalle` VALUES ('98', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('99', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('100', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('101', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('102', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('103', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('104', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('105', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('106', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('107', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('108', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('109', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('110', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('111', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('112', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('113', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('114', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('115', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('116', '15', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('117', '15', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('118', '15', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('119', '15', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('120', '15', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('121', '15', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('122', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('123', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('124', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('125', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('126', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('127', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('128', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('129', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('130', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('131', '15', '39', '703.127', '4.849', '1', null);
INSERT INTO `ventadetalle` VALUES ('132', '15', '39', '703.127', '4.849', '1', null);
INSERT INTO `ventadetalle` VALUES ('133', '15', '39', '703.127', '4.849', '1', null);
INSERT INTO `ventadetalle` VALUES ('134', '15', '39', '703.127', '4.849', '1', null);
INSERT INTO `ventadetalle` VALUES ('135', '15', '39', '703.127', '4.849', '1', null);
INSERT INTO `ventadetalle` VALUES ('136', '15', '39', '703.127', '4.849', '1', null);
INSERT INTO `ventadetalle` VALUES ('137', '15', '39', '703.127', '4.849', '1', null);
INSERT INTO `ventadetalle` VALUES ('138', '15', '39', '703.127', '4.849', '1', null);
INSERT INTO `ventadetalle` VALUES ('139', '15', '39', '703.127', '4.849', '1', null);
INSERT INTO `ventadetalle` VALUES ('140', '15', '39', '703.127', '4.849', '1', null);
INSERT INTO `ventadetalle` VALUES ('141', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('142', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('143', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('144', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('145', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('146', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('147', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('148', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('149', '15', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('150', '15', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('151', '15', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('152', '15', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('153', '15', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('154', '15', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('155', '15', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('156', '15', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('157', '15', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('158', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('159', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('160', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('161', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('162', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('163', '15', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('164', '25', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('165', '25', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('166', '25', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('167', '25', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('168', '25', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('169', '25', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('170', '25', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('171', '25', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('172', '26', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('173', '26', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('174', '26', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('175', '26', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('176', '26', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('177', '26', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('178', '26', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('179', '26', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('180', '27', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('181', '27', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('182', '27', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('183', '27', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('184', '27', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('185', '27', '35', '311.912', '2.151', '1', null);
INSERT INTO `ventadetalle` VALUES ('186', '28', '39', '703.127', '4.849', '1', null);
INSERT INTO `ventadetalle` VALUES ('187', '28', '39', '703.127', '4.849', '1', null);
INSERT INTO `ventadetalle` VALUES ('188', '28', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('189', '28', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('190', '28', '5', '632.952', '5.503', '1', null);
INSERT INTO `ventadetalle` VALUES ('191', '28', '5', '632.952', '5.503', '1', null);
INSERT INTO `ventadetalle` VALUES ('192', '29', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('193', '29', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('194', '29', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('195', '29', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('196', '29', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('197', '29', '24', '207.360', '1.481', '1', null);
INSERT INTO `ventadetalle` VALUES ('198', '30', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('199', '30', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('200', '30', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('201', '30', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('202', '30', '23', '748.952', '5.547', '1', null);
INSERT INTO `ventadetalle` VALUES ('203', '31', '35', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('204', '31', '35', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('205', '31', '35', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('206', '31', '35', '105.130', '0.725', '1', null);
INSERT INTO `ventadetalle` VALUES ('207', '18', '5', '85.250', '5.360', '1', null);
INSERT INTO `ventadetalle` VALUES ('208', '18', '10', '84.250', '6.360', '1', null);
INSERT INTO `ventadetalle` VALUES ('209', '19', '26', '2600.000', '25.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('210', '20', '26', '2500.000', '24.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('211', '20', '33', '700.000', '14.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('212', '20', '28', '6720.000', '50.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('213', '21', '25', '3700.000', '50.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('214', '22', '26', '5200.000', '50.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('215', '23', '28', '6800.000', '50.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('216', '24', '23', '2200.000', '45.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('217', '24', '24', '2000.000', '48.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('218', '25', '23', '50.000', '5.000', '1', null);
INSERT INTO `ventadetalle` VALUES ('219', '26', '26', '6000.000', '50.000', '1', null);

-- ----------------------------
-- View structure for vistacompra
-- ----------------------------
DROP VIEW IF EXISTS `vistacompra`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vistacompra` AS select `v`.`id` AS `id`,`v`.`id_operacion` AS `id_operacion`,`p`.`id_codigo_barra` AS `codigo`,`p`.`descripcion_breve` AS `descripcion`,`vd`.`peso` AS `peso`,`vd`.`monto` AS `monto`,`v`.`monto_total` AS `monto_total` from (((`compra` `v` join `compradetalle` `vd` on((`v`.`id` = `vd`.`id_compra`))) join `producto` `p` on((`vd`.`id_producto` = `p`.`id`))) join `operacionproveedor` `o` on((`v`.`id_operacion` = `o`.`id`))) where (`v`.`id` = 10) ;	   

-- ----------------------------
-- View structure for vistacompraseleccionada
-- ----------------------------
DROP VIEW IF EXISTS `vistacompraseleccionada`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vistacompraseleccionada` AS select `v`.`id` AS `id`,`v`.`id_operacion` AS `id_operacion`,`o`.`id_proveedor` AS `id_proveedor`,`p`.`id_codigo_barra` AS `codigo`,`p`.`descripcion_breve` AS `descripcion`,`vd`.`peso` AS `peso`,`vd`.`monto` AS `monto`,`v`.`monto_total` AS `monto_total` from (((`compra` `v` join `compradetalle` `vd` on((`v`.`id` = `vd`.`id_compra`))) join `producto` `p` on((`vd`.`id_producto` = `p`.`id`))) join `operacionproveedor` `o` on((`v`.`id_operacion` = `o`.`id`))) where (`v`.`id` = 11) ;

-- ----------------------------
-- View structure for vistalistadomovimientosclientes
-- ----------------------------
DROP VIEW IF EXISTS `vistalistadomovimientosclientes`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vistalistadomovimientosclientes` AS select `cm`.`id` AS `id`,dayofmonth(`cm`.`fecha`) AS `dia`,elt(date_format(`cm`.`fecha`,'%m'),'Enero','Febrero','Marzo','Abril','Mayo','Junio','Julio','Agosto','Septiembre','Octubre','Noviembre','Diciembre') AS `mes`,year(`cm`.`fecha`) AS `año`,date_format(`cm`.`fecha`,'%d-%m-%Y') AS `fecha`,date_format(`cm`.`fecha`,'%H:%i') AS `hora`,`c`.`razon_social` AS `razon_social`,`c`.`cuit` AS `cuit`,`gc`.`descripcion` AS `descripcion`,`cm`.`id_cuenta` AS `cuenta`,`cm`.`id_movimiento_tipo` AS `id_tipo`,`mt`.`descripcion` AS `tipo`,`gc`.`id_banco` AS `id_banco`,`cm`.`id_operacion` AS `operacion`,if((`cm`.`id_movimiento_tipo` = 2),`cm`.`monto`,(`cm`.`monto` * -(1))) AS `monto` from (((`clientecuentamovimiento` `cm` join `clientecuenta` `gc` on((`cm`.`id_cuenta` = `gc`.`id`))) join `movimientotipo` `mt` on((`cm`.`id_movimiento_tipo` = `mt`.`id`))) join `cliente` `c` on((`gc`.`id_cliente` = `c`.`id`))) where ((`gc`.`id_cliente` is not null) and (`cm`.`fecha` between '2018-04-01' and ('2018-04-21' + interval 1 day))) order by `cm`.`id` desc ;

-- ----------------------------
-- View structure for vistalistadomovimientosproveedores
-- ----------------------------
DROP VIEW IF EXISTS `vistalistadomovimientosproveedores`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vistalistadomovimientosproveedores` AS select `cm`.`id` AS `id`,dayofmonth(`cm`.`fecha`) AS `dia`,elt(date_format(`cm`.`fecha`,'%m'),'Enero','Febrero','Marzo','Abril','Mayo','Junio','Julio','Agosto','Septiembre','Octubre','Noviembre','Diciembre') AS `mes`,year(`cm`.`fecha`) AS `año`,date_format(`cm`.`fecha`,'%d-%m-%Y') AS `fecha`,date_format(`cm`.`fecha`,'%H:%i') AS `hora`,`c`.`razon_social` AS `razon_social`,`c`.`cuit` AS `cuit`,`gc`.`descripcion` AS `descripcion`,`cm`.`id_cuenta` AS `cuenta`,`cm`.`id_movimiento_tipo` AS `id_tipo`,`mt`.`descripcion` AS `tipo`,`gc`.`id_banco` AS `id_banco`,`cm`.`id_operacion` AS `operacion`,if((`cm`.`id_movimiento_tipo` = 2),`cm`.`monto`,(`cm`.`monto` * -(1))) AS `monto` from (((`proveedorcuentamovimiento` `cm` join `proveedorcuenta` `gc` on((`cm`.`id_cuenta` = `gc`.`id`))) join `movimientotipo` `mt` on((`cm`.`id_movimiento_tipo` = `mt`.`id`))) join `proveedor` `c` on((`gc`.`id_proveedor` = `c`.`id`))) where ((`gc`.`id_proveedor` is not null) and (`cm`.`fecha` between '2000-04-01' and ('2018-04-20' + interval 1 day))) order by `cm`.`id` desc ;

-- ----------------------------
-- View structure for vistalistadoventas
-- ----------------------------
DROP VIEW IF EXISTS `vistalistadoventas`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vistalistadoventas` AS select `v`.`id` AS `id`,dayofmonth(`v`.`fecha`) AS `dia`,elt(date_format(`v`.`fecha`,'%m'),'Enero','Febrero','Marzo','Abril','Mayo','Junio','Julio','Agosto','Septiembre','Octubre','Noviembre','Diciembre') AS `mes`,year(`v`.`fecha`) AS `año`,date_format(`v`.`fecha`,'%d/%m/%Y') AS `fecha`,date_format(`v`.`fecha`,'%H:%i') AS `hora`,`v`.`monto_total` AS `monto`,`v`.`id_operacion` AS `operacion`,`c`.`razon_social` AS `cliente`,`c`.`cuit` AS `cuit` from ((`venta` `v` join `operacion` `o` on((`o`.`id` = `v`.`id_operacion`))) join `cliente` `c` on((`o`.`id_cliente` = `c`.`id`))) where (`v`.`fecha` between '2000-04-01' and ('2018-04-19' + interval 1 day)) ;

-- ----------------------------
-- View structure for vistasaldocliente
-- ----------------------------
DROP VIEW IF EXISTS `vistasaldocliente`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vistasaldocliente` AS select `vistasaldoporidcliente`.`id` AS `id`,`vistasaldoporidcliente`.`razon_social` AS `razon_social`,(sum(`vistasaldoporidcliente`.`saldo`) * -(1)) AS `saldo` from `vistasaldoporidcliente` group by `vistasaldoporidcliente`.`id` ;

-- ----------------------------
-- View structure for vistasaldoporidcliente
-- ----------------------------
DROP VIEW IF EXISTS `vistasaldoporidcliente`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vistasaldoporidcliente` AS select `c`.`id` AS `id`,`c`.`cod_cliente` AS `cod_cliente`,`c`.`razon_social` AS `razon_social`,`c`.`cuit` AS `cuit`,`cc`.`id` AS `id_cliente_cuenta`,`cc`.`descripcion` AS `descripcion`,`cc`.`id_banco` AS `id_banco`,`ccm`.`id_operacion` AS `id_operacion`,`mt`.`descripcion` AS `tipo`,`ccm`.`fecha` AS `fecha`,if((`ccm`.`id_movimiento_tipo` = 2),`ccm`.`monto`,(`ccm`.`monto` * -(1))) AS `saldo` from (((`clientecuenta` `cc` join `cliente` `c` on((`cc`.`id_cliente` = `c`.`id`))) join `clientecuentamovimiento` `ccm` on((`ccm`.`id_cuenta` = `cc`.`id`))) join `movimientotipo` `mt` on((`ccm`.`id_movimiento_tipo` = `mt`.`id`))) where (`c`.`id` = 37) ;

-- ----------------------------
-- View structure for vistasaldoporidproveedor
-- ----------------------------
DROP VIEW IF EXISTS `vistasaldoporidproveedor`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vistasaldoporidproveedor` AS select `c`.`id` AS `id`,`c`.`razon_social` AS `razon_social`,`c`.`cuit` AS `cuit`,`cc`.`id` AS `id_proveedor_cuenta`,`cc`.`descripcion` AS `descripcion`,`cc`.`id_banco` AS `id_banco`,`ccm`.`id_operacion` AS `id_operacion`,`mt`.`descripcion` AS `tipo`,`ccm`.`fecha` AS `fecha`,if((`ccm`.`id_movimiento_tipo` = 2),`ccm`.`monto`,(`ccm`.`monto` * -(1))) AS `saldo` from (((`proveedorcuenta` `cc` join `proveedor` `c` on((`cc`.`id_proveedor` = `c`.`id`))) join `proveedorcuentamovimiento` `ccm` on((`ccm`.`id_cuenta` = `cc`.`id`))) join `movimientotipo` `mt` on((`ccm`.`id_movimiento_tipo` = `mt`.`id`))) where (`c`.`id` = 1) ;

-- ----------------------------
-- View structure for vistasaldoproveedor
-- ----------------------------
DROP VIEW IF EXISTS `vistasaldoproveedor`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vistasaldoproveedor` AS select `vistasaldoporidproveedor`.`id` AS `id`,`vistasaldoporidproveedor`.`razon_social` AS `razon_social`,sum(`vistasaldoporidproveedor`.`saldo`) AS `saldo` from `vistasaldoporidproveedor` group by `vistasaldoporidproveedor`.`id` ;

-- ----------------------------
-- View structure for vistaultimacompra
-- ----------------------------
DROP VIEW IF EXISTS `vistaultimacompra`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vistaultimacompra` AS select `c`.`id` AS `id`,`c`.`razon_social` AS `razon_social`,`c`.`domicilio` AS `domicilio`,`c`.`cuit` AS `cuit`,`cc`.`id` AS `id_proveedor_cuenta`,`cc`.`descripcion` AS `descripcion`,`cc`.`id_banco` AS `id_banco`,`ccm`.`id_operacion` AS `id_operacion`,`mt`.`descripcion` AS `tipo`,`ccm`.`fecha` AS `fecha`,if((`ccm`.`id_movimiento_tipo` = 2),`ccm`.`monto`,(`ccm`.`monto` * -(1))) AS `saldo` from (((`proveedorcuenta` `cc` join `proveedor` `c` on((`cc`.`id_proveedor` = `c`.`id`))) join `proveedorcuentamovimiento` `ccm` on((`ccm`.`id_cuenta` = `cc`.`id`))) join `movimientotipo` `mt` on((`ccm`.`id_movimiento_tipo` = `mt`.`id`))) where (`ccm`.`id_operacion` = 1) ;

-- ----------------------------
-- View structure for vistaultimaventa
-- ----------------------------
DROP VIEW IF EXISTS `vistaultimaventa`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vistaultimaventa` AS select `c`.`id` AS `id`,`c`.`cod_cliente` AS `cod_cliente`,`c`.`razon_social` AS `razon_social`,`c`.`domicilio` AS `domicilio`,`c`.`cuit` AS `cuit`,`cc`.`id` AS `id_cliente_cuenta`,`cc`.`descripcion` AS `descripcion`,`cc`.`id_banco` AS `id_banco`,`ccm`.`id_operacion` AS `id_operacion`,`mt`.`descripcion` AS `tipo`,`ccm`.`fecha` AS `fecha`,if((`ccm`.`id_movimiento_tipo` = 2),`ccm`.`monto`,(`ccm`.`monto` * -(1))) AS `saldo` from (((`clientecuenta` `cc` join `cliente` `c` on((`cc`.`id_cliente` = `c`.`id`))) join `clientecuentamovimiento` `ccm` on((`ccm`.`id_cuenta` = `cc`.`id`))) join `movimientotipo` `mt` on((`ccm`.`id_movimiento_tipo` = `mt`.`id`))) where (`ccm`.`id_operacion` = 30) ;

-- ----------------------------
-- View structure for vistaultimaventaporcliente
-- ----------------------------
DROP VIEW IF EXISTS `vistaultimaventaporcliente`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vistaultimaventaporcliente` AS select `v`.`id` AS `id`,`v`.`id_operacion` AS `id_operacion`,`o`.`id_cliente` AS `id_cliente`,`p`.`id_codigo_barra` AS `codigo`,`p`.`descripcion_breve` AS `descripcion`,`vd`.`peso` AS `peso`,`vd`.`monto` AS `monto`,`v`.`monto_total` AS `monto_total` from (((`venta` `v` join `ventadetalle` `vd` on((`v`.`id` = `vd`.`id_venta`))) join `producto` `p` on((`vd`.`id_producto` = `p`.`id`))) join `operacion` `o` on((`v`.`id_operacion` = `o`.`id`))) where (`v`.`id` = (select `v`.`id` AS `id_ultima_venta` from (((`venta` `v` join `ventadetalle` `vd` on((`v`.`id` = `vd`.`id_venta`))) join `producto` `p` on((`vd`.`id_producto` = `p`.`id`))) join `operacion` `o` on((`v`.`id_operacion` = `o`.`id`))) where (`o`.`id_cliente` = 37) order by `v`.`id` desc limit 1)) ;

-- ----------------------------
-- View structure for vistaventa
-- ----------------------------
DROP VIEW IF EXISTS `vistaventa`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vistaventa` AS select `v`.`id` AS `id`,`o`.`id_cliente` AS `id_cliente`,`v`.`id_operacion` AS `id_operacion`,`p`.`id_codigo_barra` AS `codigo`,`p`.`descripcion_breve` AS `descripcion`,`vd`.`peso` AS `peso`,`vd`.`monto` AS `monto`,`v`.`monto_total` AS `monto_total` from (((`venta` `v` join `ventadetalle` `vd` on((`v`.`id` = `vd`.`id_venta`))) join `producto` `p` on((`vd`.`id_producto` = `p`.`id`))) join `operacion` `o` on((`v`.`id_operacion` = `o`.`id`))) where (`v`.`id` = 32) ;

-- ----------------------------
-- View structure for vistaventaseleccionada
-- ----------------------------
DROP VIEW IF EXISTS `vistaventaseleccionada`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vistaventaseleccionada` AS select `v`.`id` AS `id`,`v`.`id_operacion` AS `id_operacion`,`o`.`id_cliente` AS `id_cliente`,`p`.`id_codigo_barra` AS `codigo`,`p`.`descripcion_breve` AS `descripcion`,`vd`.`peso` AS `peso`,`vd`.`monto` AS `monto`,`v`.`monto_total` AS `monto_total` from (((`venta` `v` join `ventadetalle` `vd` on((`v`.`id` = `vd`.`id_venta`))) join `producto` `p` on((`vd`.`id_producto` = `p`.`id`))) join `operacion` `o` on((`v`.`id_operacion` = `o`.`id`))) where (`v`.`id` = 32) ;

-- ----------------------------
-- View structure for vistaventasumatotal
-- ----------------------------
DROP VIEW IF EXISTS `vistaventasumatotal`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vistaventasumatotal` AS select `vsc`.`id` AS `id`,(`vvs`.`monto_total` - `vsc`.`saldo`) AS `total` from (`vistaventaseleccionada` `vvs` join `vistasaldocliente` `vsc` on((`vvs`.`id_cliente` = `vsc`.`id`))) ;

-- ----------------------------
-- Procedure structure for ActualizarCliente
-- ----------------------------
DROP PROCEDURE IF EXISTS `ActualizarCliente`;
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
WHERE id = id_
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for actualizarProveedor
-- ----------------------------
DROP PROCEDURE IF EXISTS `actualizarProveedor`;
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
WHERE id = id_
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for borrarCliente
-- ----------------------------
DROP PROCEDURE IF EXISTS `borrarCliente`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `borrarCliente`(`id_` int, `fecha_` date)
update cliente set fecha_baja = fecha_ where id = id_
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for borrarProveedor
-- ----------------------------
DROP PROCEDURE IF EXISTS `borrarProveedor`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `borrarProveedor`(id_ int, fecha_ date)
update proveedor set fecha_baja = fecha_ where id = id_
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for grabarNuevaClienteCuenta
-- ----------------------------
DROP PROCEDURE IF EXISTS `grabarNuevaClienteCuenta`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `grabarNuevaClienteCuenta`(`cbu_` varchar(40),`desc_` varchar(50),`idCliente_` int,`idBanco_` int,`idUsuario_` int)
INSERT INTO clientecuenta 
( cbu, descripcion, id_cliente, id_banco, fecha_updated, usuario, fecha_baja) 
 VALUES (cbu_, desc_,idCliente_,idBanco_,NOW(),idUsuario_,null)
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for grabarNuevaProveedorCuenta
-- ----------------------------
DROP PROCEDURE IF EXISTS `grabarNuevaProveedorCuenta`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `grabarNuevaProveedorCuenta`(`cbu_` varchar(40),`desc_` varchar(50),`idProveedor_` int,`idBanco_` int,`idUsuario_` int)
INSERT INTO proveedorcuenta 
( cbu, descripcion, id_proveedor, id_banco, fecha_updated, usuario, fecha_baja) 
 VALUES (cbu_, desc_,idProveedor_,idBanco_NOW(),idUsuario_,null)
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for grabarNuevoCliente
-- ----------------------------
DROP PROCEDURE IF EXISTS `grabarNuevoCliente`;
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
idu)
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for grabarNuevoProveedor
-- ----------------------------
DROP PROCEDURE IF EXISTS `grabarNuevoProveedor`;
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
idu)
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for listarClienteCuentaConSaldo
-- ----------------------------
DROP PROCEDURE IF EXISTS `listarClienteCuentaConSaldo`;
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
group by cliente.id order by cliente.id
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for listarCuentasByIdCliente
-- ----------------------------
DROP PROCEDURE IF EXISTS `listarCuentasByIdCliente`;
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
WHERE cc.id_cliente = Id_
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for listarMovimientoTipo
-- ----------------------------
DROP PROCEDURE IF EXISTS `listarMovimientoTipo`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarMovimientoTipo`()
select * from movimientotipo order by id
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for listarTipoCliente
-- ----------------------------
DROP PROCEDURE IF EXISTS `listarTipoCliente`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarTipoCliente`()
select * from clientetipo order by id
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for listarTipoProducto
-- ----------------------------
DROP PROCEDURE IF EXISTS `listarTipoProducto`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarTipoProducto`()
select * from productotipo order by id
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerClienteConCuentasPorIdCliente
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerClienteConCuentasPorIdCliente`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClienteConCuentasPorIdCliente`(id_ int)
SELECT c.id ,	c.cod_cliente AS CodCliente, 	c.razon_social AS RazonSocial, 	c.domicilio AS Domicilio,
c.localidad AS Localidad,cast(ct.id as CHAR(50)) AS TipoCliente, cu.id AS IdCuenta, 
c.fecha_desde as FechaDesde, c.civa AS IVA, c.cuit AS CUIT,c.nombre_responsable AS NombreResponsable,
c.nombre_local AS NombreLocal,c.telefono AS Telefono FROM	cliente c 
INNER JOIN clientetipo ct ON ct.id = c.id_tipo_cliente 
INNER JOIN clientecuenta cu ON cu.id_cliente = c.id  WHERE c.id = id_
  AND c.fecha_baja is null order by c.id
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerClienteCuentaPorId
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerClienteCuentaPorId`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClienteCuentaPorId`(`id_` int)
select * from clientecuenta where id = id_
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerClienteCuentas
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerClienteCuentas`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClienteCuentas`()
select * from clientecuenta order by id
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerClientes
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerClientes`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClientes`()
SELECT * FROM cliente ORDER BY razon_social
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerClientesConCuenta
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerClientesConCuenta`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClientesConCuenta`()
SELECT c.id ,	c.cod_cliente AS CodCliente, 	c.razon_social AS RazonSocial, 	c.domicilio AS Domicilio,
c.localidad AS Localidad,cast(ct.id as CHAR(50)) AS TipoCliente, cu.id AS IdCuenta, 
c.fecha_desde as FechaDesde, c.civa AS IVA, c.cuit AS CUIT,c.nombre_responsable AS NombreResponsable,
c.nombre_local AS NombreLocal,c.telefono AS Telefono FROM	cliente c 
INNER JOIN clientetipo ct ON ct.id = c.id_tipo_cliente 
INNER JOIN clientecuenta cu ON cu.id_cliente = c.id  AND c.fecha_baja is null order by c.id
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerClientesData
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerClientesData`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClientesData`()
SELECT c.id, c.razon_social AS RazonSocial, c.domicilio AS Domicilio, c.localidad AS Localidad, cast(c.id_tipo_cliente as CHAR(50)) AS TipoCliente,   
c.fecha_desde as FechaDesde, c.civa AS IVA, c.cuit AS CUIT, c.nombre_responsable AS NombreResponsable, c.nombre_local AS NombreLocal, 	c.telefono AS Telefono,
c.fecha_baja AS FechaBaja  FROM cliente c order by c.id
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerClientesPorId
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerClientesPorId`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClientesPorId`(id_ int)
SELECT * FROM cliente  WHERE id = id_ ORDER BY razon_social
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerClientesSaldoActual
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerClientesSaldoActual`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClientesSaldoActual`()
SELECT cliente.id, cliente.cod_cliente as CodCliente, cliente.razon_social AS `RazonSocial`, cliente.nombre_local AS `NombreLocal`, cliente.civa AS IVA, cast(cliente.id_tipo_cliente as CHAR(50)) AS TipoCliente,count(cuenta.id) AS CantidadCuentas FROM cliente inner join clientecuenta cuenta on cliente.id = cuenta.id_cliente       INNER JOIN banco ON cuenta.id_banco = banco.id INNER JOIN clientetipo ct ON ct.id = cliente.id_tipo_cliente group by cliente.id order by cliente.id
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerCuentasPorIdCliente
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerCuentasPorIdCliente`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerCuentasPorIdCliente`(`id_` int)
select * from clientecuenta where id_cliente = id_
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerCuentasPorIdProveedor
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerCuentasPorIdProveedor`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerCuentasPorIdProveedor`(`id_` int)
select * from proveedorcuenta where id_proveedor = id_
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerMovCuentas
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerMovCuentas`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerMovCuentas`()
SELECT cm.id, cm.id_operacion,gc.id,gc.id_cliente,cm.id_cuenta,cm.id_movimiento_tipo,mt.descripcion, 
 gc.id_banco, round(cm.monto, 2) AS monto, DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_,cm.cobrado, 
 cm.usuario FROM clientecuentamovimiento cm INNER JOIN clientecuenta gc ON cm.id_cuenta = gc.id 
 INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id WHERE gc.id_cliente 
 IS NOT NULL ORDER BY cm.id DESC
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerMovCuentasClientes
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerMovCuentasClientes`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerMovCuentasClientes`()
SELECT cm.id, cm.vob,  gc.id,gc.id_cliente,cm.id_cuenta, cm.id_movimiento_tipo, mt.descripcion, 
gc.id_banco, round(cm.monto, 2) AS monto, DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_,
cm.cobrado, cm.usuario 
 FROM clientecuentamovimiento cm INNER JOIN clientecuenta gc ON cm.id_cuenta = gc.id 
 INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id 
 WHERE gc.id_cliente IS NOT NULL ORDER BY cm.id DESC
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerMovCuentasParseado
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerMovCuentasParseado`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerMovCuentasParseado`(`pInicio_` int,`registros_` int)
SELECT cm.id, cm.id_operacion,gc.id,gc.id_cliente,cm.id_cuenta,cm.id_movimiento_tipo,mt.descripcion, 
 gc.id_banco, round(cm.monto, 2) AS monto, DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_,cm.cobrado, 
 cm.usuario FROM clientecuentamovimiento cm INNER JOIN clientecuenta gc ON cm.id_cuenta = gc.id 
 INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id WHERE gc.id_cliente 
 IS NOT NULL ORDER BY cm.id DESC LIMIT pInicio_, registros_
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerMovCuentasParseadoEntreFechas
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerMovCuentasParseadoEntreFechas`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerMovCuentasParseadoEntreFechas`(`idCliente_` int, `pInicio_` int,`registros_` int, `fDesde_` varchar(20), `fHasta_` varchar(20))
SELECT cm.id, cm.id_operacion,gc.id,gc.id_cliente,cm.id_cuenta,cm.id_movimiento_tipo,mt.descripcion, 
 gc.id_banco, round(cm.monto, 2) AS monto, DATE_FORMAT(cm.fecha,'%Y-%m-%d') AS fecha_,cm.cobrado, 
 cm.usuario FROM clientecuentamovimiento cm INNER JOIN clientecuenta gc ON cm.id_cuenta = gc.id 
 INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id 
 INNER JOIN banco ON banco.id = gc.id_banco WHERE gc.id_cliente = idCliente_ 
 AND DATE_FORMAT(cm.fecha, '%Y-%m-%d') BETWEEN fDesde_ AND fHasta_ 
 ORDER BY cm.id DESC LIMIT pInicio_, registros_
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerProveedorConCuentasPorIdProveedor
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerProveedorConCuentasPorIdProveedor`;
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
WHERE proveedor.id = id_ order by cuenta.id
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerProveedorCuentaPorId
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerProveedorCuentaPorId`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedorCuentaPorId`(`id_` int)
select * from proveedorcuenta where id = id_
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerProveedorCuentas
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerProveedorCuentas`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedorCuentas`()
select * from proveedorcuenta order by id
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerProveedores
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerProveedores`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedores`()
SELECT * FROM proveedor ORDER BY razon_social
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerProveedoresConCuenta
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerProveedoresConCuenta`;
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
 WHERE  c.fecha_baja is null  order by c.id
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerProveedoresData
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerProveedoresData`;
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
c.fecha_baja AS FechaBaja  FROM proveedor c order by c.id
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerProveedoresPorId
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerProveedoresPorId`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedoresPorId`(id_ int)
SELECT * FROM proveedor WHERE id = id_ ORDER BY razon_social
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerProveedoresSaldoActual
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerProveedoresSaldoActual`;
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
group by proveedor.id order by proveedor.id
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerProveedorPorNombre
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerProveedorPorNombre`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedorPorNombre`(`name_` varchar(20))
select id, razon_social AS RazonSocial, domicilio AS Domicilio, localidad AS Localidad, fecha_desde as FechaDesde,
civa AS IVA, cuit AS CUIT, nombre_responsable AS NombreResponsable, nombre_local AS NombreLocal,
telefono AS Telefono, fecha_baja AS FechaBaja FROM proveedor WHERE fecha_baja is NULL
AND razon_social LIKE CONCAT('%',name_,'%')
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerTipoClientePorIdCliente
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerTipoClientePorIdCliente`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerTipoClientePorIdCliente`(id_ int)
select id_tipo_cliente from cliente where id = id_
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerTipoProdutoPorIdProducto
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerTipoProdutoPorIdProducto`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerTipoProdutoPorIdProducto`(id_ int)
select id_producto_tipo from producto where id = id_
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerTodasCuentasPorCliente
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerTodasCuentasPorCliente`;
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
WHERE cliente.id = id_ ORDER BY c.id
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerUsuarioPorNombre
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerUsuarioPorNombre`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerUsuarioPorNombre`(name_ VARCHAR(20))
select * from usuario where username like name_
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for obtenerUsuariosModulos
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerUsuariosModulos`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerUsuariosModulos`(id_ int)
SELECT m.* FROM usuariomodulo um inner join modulo m on m.id = um.id_modulo where um.id_usuario = id_
;;
DELIMITER ;
