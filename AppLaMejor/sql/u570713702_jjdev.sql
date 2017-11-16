/*
Navicat MySQL Data Transfer

Source Server         : local host connection
Source Server Version : 50617
Source Host           : localhost:3306
Source Database       : u570713702_jjdev

Target Server Type    : MYSQL
Target Server Version : 50617
File Encoding         : 65001

Date: 2017-11-16 00:57:57
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of banco
-- ----------------------------
INSERT INTO `banco` VALUES ('1', 'Macro');
INSERT INTO `banco` VALUES ('2', 'Santander');
INSERT INTO `banco` VALUES ('3', 'Santa Fe');
INSERT INTO `banco` VALUES ('4', 'Nación');

-- ----------------------------
-- Table structure for cliente
-- ----------------------------
DROP TABLE IF EXISTS `cliente`;
CREATE TABLE `cliente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
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
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of cliente
-- ----------------------------
INSERT INTO `cliente` VALUES ('1', 'WTF', 'asd', 'asd', 'asd', '1', 'asd', 'asd', 'asd', 'asd', '2017-09-05', null, '1');
INSERT INTO `cliente` VALUES ('2', 'Juanjo', 'j de la rosa 1252', 'santa fe', 'CF', '2', 'DESAROLLO SANTA', '', '', '', '2017-09-05', null, '0');
INSERT INTO `cliente` VALUES ('3', 'A.D.U.L.', 'Pje. Martinez 26661', 'Santa Fe', 'CF', '4', 'defaultLocal', '30-55597562-3', '4553992', 'NombreResponsable', '2017-09-05', null, '1');
INSERT INTO `cliente` VALUES ('4', 'A.N.S.E.S.', 'SAN MARTIN N 2533', 'Santa Fe', 'CF', '1', 'defaultLocal', '33-63761744-9', '4156256', 'NombreResponsable', '2017-09-05', null, '1');
INSERT INTO `cliente` VALUES ('5', 'A.PE.L - Asoc.Pers.Legislativo', 'San Jeronimo N  1.791', 'Santa Fe', 'CF', '1', 'defaultLocal', '30-64955281-5', '4598277', 'NombreResponsable', '2017-09-05', null, '1');
INSERT INTO `cliente` VALUES ('6', 'ACANTILADOS S.A. (VALMOTORS)', 'SAN LUIS N 3102', 'Santa Fe', 'CF', '1', 'defaultLocal', '30-70941478-6', '4530606', 'NombreResponsable', '2017-09-06', null, '1');
INSERT INTO `cliente` VALUES ('7', 'ACOSTA MARTÃ–N SEBASTIÂµN', 'Pje. E.del Crespo N 7103/Berutti 5725', 'Santa Fe', 'CF', '2', 'defaultLocal', '30-64955281-5', '4530606', 'NombreResponsable', '2017-09-06', null, '1');
INSERT INTO `cliente` VALUES ('8', 'AdministraciÂ¢n Provincial de Impuestos-A.P.I', 'AVDA.PTE.ILLIA NÂ§ 1.151', 'Santa Fe', 'CF', '2', 'defaultLocal', '30-65520017-3', '4557996', 'NombreResponsable', '2017-09-06', null, '0');
INSERT INTO `cliente` VALUES ('9', 'Agencia Provincial de Seguridad Vial', '25 DE MAYO N  2.208', 'Santa Fe', 'CF', '1', 'defaultLocal', '30-99901844-7', '4574822', 'NombreResponsable', '2017-09-06', null, '1');
INSERT INTO `cliente` VALUES ('10', 'AGOSTINI OSVALDO OMAR', 'AVDA. GORRITI N 3014', 'Santa Fe', 'CF', '2', 'defaultLocal', '20-05261057-6', '4695406', 'NombreResponsable', '2017-09-06', '2001-01-01 00:00:00', '1');
INSERT INTO `cliente` VALUES ('11', 'AICACYP-Ente Cooperador Ley 23.979', 'Moreno N 1420  (p/Facturar)', 'Santa Fe', 'CF', '2', 'defaultLocal', '30-55597562-3', '4574822', 'NombreResponsable', '2017-09-07', null, '1');
INSERT INTO `cliente` VALUES ('12', 'AICACYP-Ente Cooperador Ley 23.979', 'RENAR: Francia N 3550 - Santa Fe', 'Santa Fe', 'CF', '2', 'defaultLocal', '011-4384-7900', '4557996', 'NombreResponsable', '2017-09-07', null, '1');
INSERT INTO `cliente` VALUES ('13', 'ALBERTO J. MACUA S.A.', 'LOPEZ Y PLANES N 4250', 'Santa Fe', 'CF', '2', 'defaultLocal', '30-60541628-0', '4555070', 'NombreResponsable', '2017-09-07', '2001-01-01 00:00:00', '1');
INSERT INTO `cliente` VALUES ('14', 'ALMEIDA JUAN CARLOS F.', 'RUPERTO PEREZ 1944', 'Santa Fe', 'CF', '2', 'defaultLocal', '24-06218372-8', '4553228', 'NombreResponsable', '2017-09-07', null, '1');
INSERT INTO `cliente` VALUES ('15', 'ALONSO EDGARDO JAVIER', 'SAN MARTÃ–N N 3364-Piso 10-Dpto B', 'Santa Fe', 'CF', '2', 'defaultLocal', '20-13925831-3', '4585068', 'NombreResponsable', '2017-09-07', null, '1');
INSERT INTO `cliente` VALUES ('16', 'ALONSO  GRACIELA CRISTINA', 'MARTIN ZAPATA 3870', 'Santa Fe', 'CF', '2', 'defaultLocal', '27-13163585-6', '4537003', 'NombreResponsable', '2017-09-07', '2001-01-01 00:00:00', '1');
INSERT INTO `cliente` VALUES ('17', 'ALLOATTI ROBERTO', 'SAN MARTIN N 2088', 'Santa Fe', 'CF', '2', 'defaultLocal', '30-60541628-0', '4537003', 'NombreResponsable', '2017-09-07', null, '1');
INSERT INTO `cliente` VALUES ('18', 'AMATTI  CLAUDIO', 'SAN MARTIN N 2088', 'Santa Fe', 'CF', '3', 'defaultLocal', '30-60541628-0', '4537003', 'NombreResponsable', '2017-09-10', null, '1');
INSERT INTO `cliente` VALUES ('19', 'AMRAD S. H. de Liponezky Virginia  Victor y Santiago ', 'Salvador del Carril N 968', 'Santa Fe', 'CF', '3', 'defaultLocal', '30-71120617-1', '4537003', 'NombreResponsable', '2017-09-10', null, '1');
INSERT INTO `cliente` VALUES ('20', 'ANGEL BOSCARINO Construcciones S.A.', 'MARCIAL CANDIOTI  N 5180', 'Santa Fe', 'CF', '3', 'defaultLocal', '30-60541628-0', '4538585', 'NombreResponsable', '2017-09-10', null, '1');
INSERT INTO `cliente` VALUES ('21', 'ANSKOHL  RICARDO', 'E. ZEBALLOS 4334', 'Santa Fe', 'CF', '3', 'defaultLocal', '20-06264349-9', '4537003', 'NombreResponsable', '2017-09-10', null, '1');
INSERT INTO `cliente` VALUES ('22', 'ANTONIAZZI HNOS.', 'PIETRANERA n 3350', 'Santa Fe', 'CF', '4', 'defaultLocal', '30-55418898-9', '4592295', 'NombreResponsable', '2017-09-10', null, '1');
INSERT INTO `cliente` VALUES ('23', 'ANTONIAZZI  GERMAN', 'RIVADAVIA N 3396', 'Santa Fe', 'CF', '4', 'defaultLocal', '20-26460065-1', '4500162', 'NombreResponsable', '2017-09-10', null, '1');
INSERT INTO `cliente` VALUES ('24', 'ARCINI MARTÃ–N', '9 DE JULIO N 2722', 'Santa Fe', 'CF', '4', 'defaultLocal', '20-06264349-9', '4537003', 'NombreResponsable', '2017-09-10', null, '1');
INSERT INTO `cliente` VALUES ('25', 'ARCOLEN S.A.', 'SUIPACHA 2695', 'Santa Fe', 'CF', '4', 'defaultLocal', '30-64385640-5', '4561538', 'NombreResponsable', '2017-09-10', null, '1');
INSERT INTO `cliente` VALUES ('26', 'Cliente 1', 'La Rioja 2081', 'Santa Fe', 'CF', '1', 'asd', '203295621342', 'asd', 'sd', '2017-11-09', null, '0');

-- ----------------------------
-- Table structure for clientecuenta
-- ----------------------------
DROP TABLE IF EXISTS `clientecuenta`;
CREATE TABLE `clientecuenta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cbu` varchar(40) NOT NULL,
  `nro_cuenta` varchar(50) NOT NULL,
  `id_cliente` int(11) DEFAULT NULL,
  `fecha_updated` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  `id_banco` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_banco` (`id_banco`),
  CONSTRAINT `fk_banco` FOREIGN KEY (`id_banco`) REFERENCES `banco` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of clientecuenta
-- ----------------------------
INSERT INTO `clientecuenta` VALUES ('1', '1238238923892234', '12-1238238923892234', '1', '2017-11-06 21:07:59', '1', null, '1');
INSERT INTO `clientecuenta` VALUES ('2', '1238238923892236', '12-1238238923893434', '2', '2017-11-06 21:08:00', '1', null, '1');
INSERT INTO `clientecuenta` VALUES ('3', '2222', '22222', '1', '2017-11-06 21:08:00', '0', null, '2');
INSERT INTO `clientecuenta` VALUES ('4', 'aaa', '12312', '6', '2017-11-06 21:08:01', '0', null, '3');
INSERT INTO `clientecuenta` VALUES ('5', '11111111', '11111111', '17', '2017-11-06 21:08:02', '0', null, '4');
INSERT INTO `clientecuenta` VALUES ('6', '22222', '22222', '2', '2017-11-06 21:08:03', '0', null, '1');
INSERT INTO `clientecuenta` VALUES ('7', '4444', '4444', '2', '2017-11-08 22:04:46', '0', null, '2');
INSERT INTO `clientecuenta` VALUES ('8', '555', '555', '3', '2017-11-06 21:08:03', '0', null, '3');
INSERT INTO `clientecuenta` VALUES ('9', '123', '', '14', '2017-11-06 21:08:04', '0', null, '4');
INSERT INTO `clientecuenta` VALUES ('10', '11', '11', '25', '2017-11-06 21:08:05', '0', null, '1');
INSERT INTO `clientecuenta` VALUES ('11', '14524521452', '14552/142', '22', '2017-11-15 23:45:05', '0', null, null);
INSERT INTO `clientecuenta` VALUES ('12', '1233213', '333112', '1', '2017-11-15 23:47:45', '0', null, null);
INSERT INTO `clientecuenta` VALUES ('13', 'aaa122', '123123', '26', '2017-11-16 00:15:28', '0', null, null);
INSERT INTO `clientecuenta` VALUES ('14', 'aa', '22', '4', '2017-11-16 00:17:29', '0', null, null);
INSERT INTO `clientecuenta` VALUES ('15', '142541232', '21452', '4', '2017-11-16 00:43:22', '0', null, null);
INSERT INTO `clientecuenta` VALUES ('16', '0316541561', '13216546', '4', '2017-11-16 00:50:54', '0', null, '2');
INSERT INTO `clientecuenta` VALUES ('17', '13213', '1231', '22', '2017-11-16 00:53:54', '0', null, '2');

-- ----------------------------
-- Table structure for clientecuentamovimiento
-- ----------------------------
DROP TABLE IF EXISTS `clientecuentamovimiento`;
CREATE TABLE `clientecuentamovimiento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `vob` char(1) NOT NULL COMMENT '(V)arias o (B)ancarias',
  `id_cuenta` int(11) NOT NULL,
  `id_movimiento_tipo` int(11) NOT NULL COMMENT '1 - DEBE| 2 - HABER',
  `monto` double NOT NULL,
  `fecha` datetime NOT NULL,
  `cobrado` char(1) NOT NULL DEFAULT 'N',
  `usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=69 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of clientecuentamovimiento
-- ----------------------------
INSERT INTO `clientecuentamovimiento` VALUES ('1', '1', '1', '1', '500.5', '2017-09-14 14:22:14', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('2', '1', '1', '1', '352.8', '2017-09-14 09:21:22', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('4', '1', '2', '1', '100.1', '2017-09-14 10:00:00', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('5', '1', '1', '2', '400.9', '2017-09-14 11:00:00', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('6', '1', '1', '2', '33.3', '2017-09-14 11:00:00', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('7', '1', '1', '2', '33', '2017-09-14 14:13:51', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('8', '1', '1', '2', '100', '2017-09-15 10:49:46', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('9', '1', '1', '2', '6', '2017-09-15 11:00:48', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('10', '1', '1', '2', '80', '2017-09-15 11:08:10', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('11', '1', '1', '2', '2', '2017-09-15 11:09:48', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('12', '1', '1', '2', '1', '2017-09-15 11:11:44', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('13', '1', '1', '2', '7', '2017-09-15 11:17:03', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('14', '1', '1', '2', '10', '2017-09-15 11:24:58', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('15', '1', '1', '2', '11', '2017-09-17 09:23:38', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('16', '1', '1', '2', '77', '2017-09-17 09:48:18', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('19', '1', '1', '1', '7', '0000-00-00 00:00:00', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('20', '1', '1', '1', '1', '2017-09-22 16:02:29', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('21', '1', '1', '1', '20', '2017-09-22 23:05:13', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('22', '1', '2', '1', '7', '2017-09-24 13:41:55', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('23', '1', '2', '1', '5', '2017-09-25 23:39:50', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('24', '1', '2', '1', '4', '2017-09-25 23:41:08', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('25', '1', '2', '1', '3', '2017-09-25 23:42:01', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('26', '1', '2', '1', '30', '2017-09-26 00:07:36', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('27', '1', '2', '1', '5', '2017-09-26 00:43:20', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('28', '1', '2', '1', '2', '2017-09-26 00:46:07', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('29', '1', '2', '1', '2', '2017-09-26 00:47:22', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('30', '1', '2', '1', '2', '2017-09-26 00:47:51', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('31', '1', '2', '2', '100', '2017-09-26 00:51:52', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('33', '1', '2', '1', '4', '2017-09-26 01:03:42', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('34', '1', '2', '1', '150', '2017-09-26 01:04:31', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('35', '1', '2', '2', '133', '2017-09-26 01:05:03', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('36', '1', '2', '1', '10', '2017-09-26 01:17:31', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('37', '1', '2', '1', '11', '2017-09-26 01:40:33', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('38', '1', '2', '1', '5', '2017-09-26 11:41:52', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('39', '1', '2', '1', '339', '2017-09-27 15:33:55', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('40', '1', '2', '2', '61', '2017-09-27 15:34:36', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('41', '1', '2', '1', '3851', '2017-09-27 15:35:03', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('42', '1', '2', '1', '4236', '2017-09-27 15:35:26', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('43', '1', '2', '2', '847210', '2017-09-27 15:36:08', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('44', '1', '2', '1', '900000', '2017-09-27 15:37:44', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('45', '1', '2', '2', '60000', '2017-09-27 15:38:43', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('46', '1', '2', '1', '200', '2017-09-28 14:44:57', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('47', '1', '2', '1', '6210', '2017-09-28 14:45:16', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('48', '1', '2', '1', '12', '2017-09-28 14:57:41', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('49', '1', '2', '1', '4.9', '2017-09-28 15:00:47', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('50', '1', '2', '1', '55.2', '2017-09-28 15:02:56', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('51', '1', '2', '1', '44.2', '2017-09-28 15:15:16', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('52', '1', '1', '2', '200', '2017-09-28 15:19:54', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('53', '1', '2', '2', '12', '2017-09-29 11:10:03', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('54', '1', '2', '2', '12', '2017-09-29 11:13:38', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('55', '1', '2', '2', '700', '2017-09-29 13:55:11', 'N', '1');
INSERT INTO `clientecuentamovimiento` VALUES ('56', '1', '2', '1', '500', '2017-10-02 01:08:47', 'N', '0');
INSERT INTO `clientecuentamovimiento` VALUES ('57', '1', '2', '2', '8000', '2017-11-06 20:52:46', 'N', '0');
INSERT INTO `clientecuentamovimiento` VALUES ('58', '1', '7', '1', '1000', '2017-11-08 22:04:46', 'N', '0');
INSERT INTO `clientecuentamovimiento` VALUES ('59', '1', '7', '1', '22', '2017-11-10 17:44:56', 'N', '0');
INSERT INTO `clientecuentamovimiento` VALUES ('60', '1', '1', '2', '600', '2017-11-10 18:24:57', 'N', '0');
INSERT INTO `clientecuentamovimiento` VALUES ('61', '1', '1', '1', '700', '2017-11-10 19:55:10', 'N', '0');
INSERT INTO `clientecuentamovimiento` VALUES ('62', '1', '1', '2', '222', '2017-11-10 19:56:19', 'N', '0');
INSERT INTO `clientecuentamovimiento` VALUES ('63', '1', '6', '2', '123', '2017-11-10 20:02:10', 'N', '0');
INSERT INTO `clientecuentamovimiento` VALUES ('64', '1', '1', '1', '14785', '2017-11-15 00:26:03', 'N', '0');
INSERT INTO `clientecuentamovimiento` VALUES ('65', '1', '7', '1', '1000', '2017-11-15 10:18:40', 'N', '0');
INSERT INTO `clientecuentamovimiento` VALUES ('66', '1', '2', '2', '1000', '2017-11-15 10:21:38', 'N', '0');
INSERT INTO `clientecuentamovimiento` VALUES ('67', '1', '2', '2', '500', '2017-11-15 10:21:45', 'N', '0');
INSERT INTO `clientecuentamovimiento` VALUES ('68', '1', '1', '1', '1000', '2017-11-16 00:54:50', 'N', '1');

-- ----------------------------
-- Table structure for clientetipo
-- ----------------------------
DROP TABLE IF EXISTS `clientetipo`;
CREATE TABLE `clientetipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of clientetipo
-- ----------------------------
INSERT INTO `clientetipo` VALUES ('1', 'Mayorista');
INSERT INTO `clientetipo` VALUES ('2', 'Minorista');
INSERT INTO `clientetipo` VALUES ('3', 'TipoCliente');
INSERT INTO `clientetipo` VALUES ('4', 'ClienteTipo');

-- ----------------------------
-- Table structure for compra
-- ----------------------------
DROP TABLE IF EXISTS `compra`;
CREATE TABLE `compra` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_proveedor` int(11) NOT NULL,
  `id_compra_producto` int(11) NOT NULL,
  `id_compra_estado` int(11) NOT NULL,
  `monto_total` double(11,2) NOT NULL,
  `fecha` datetime NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_prov` (`id_proveedor`),
  KEY `fk_comprapro` (`id_compra_producto`),
  KEY `fk_compraestado` (`id_compra_estado`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of compra
-- ----------------------------

-- ----------------------------
-- Table structure for compradetalle
-- ----------------------------
DROP TABLE IF EXISTS `compradetalle`;
CREATE TABLE `compradetalle` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_compra` int(11) NOT NULL,
  `id_producto` int(11) NOT NULL,
  `monto` double NOT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_entrega` (`id_compra`),
  KEY `id_producto` (`id_producto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of compradetalle
-- ----------------------------

-- ----------------------------
-- Table structure for compraestado
-- ----------------------------
DROP TABLE IF EXISTS `compraestado`;
CREATE TABLE `compraestado` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of compraestado
-- ----------------------------

-- ----------------------------
-- Table structure for cuenta
-- ----------------------------
DROP TABLE IF EXISTS `cuenta`;
CREATE TABLE `cuenta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cbu` varchar(40) NOT NULL,
  `id_banco` int(11) DEFAULT NULL,
  `nro_cuenta` varchar(50) NOT NULL,
  `saldo_actual` double(10,2) NOT NULL,
  `id_cliente` int(11) DEFAULT NULL,
  `fecha_updated` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of cuenta
-- ----------------------------
INSERT INTO `cuenta` VALUES ('1', '1238238923892234', '1', '12-1238238923892234', '-200.85', '1', '2017-11-12 20:55:11', '1', null);
INSERT INTO `cuenta` VALUES ('2', '1238238923892236', '1', '12-1238238923893434', '500.85', '2', '2017-11-12 20:55:12', '1', null);
INSERT INTO `cuenta` VALUES ('3', '2222', '1', '22222', '252.52', '1', '2017-11-12 20:55:13', '0', null);
INSERT INTO `cuenta` VALUES ('4', 'aaa', '1', '12312', '123243.00', '6', '2017-11-12 20:55:18', '0', null);

-- ----------------------------
-- Table structure for cuentamovimiento
-- ----------------------------
DROP TABLE IF EXISTS `cuentamovimiento`;
CREATE TABLE `cuentamovimiento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `vob` char(1) NOT NULL COMMENT '(V)arias o (B)ancarias',
  `id_cliente_cuenta` int(11) NOT NULL,
  `id_movimiento_tipo` int(11) NOT NULL COMMENT '1 - DEBE| 2 - HABER',
  `monto` double NOT NULL,
  `fecha` datetime NOT NULL,
  `cobrado` char(1) NOT NULL DEFAULT 'N',
  `usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_cuenta_cliente` (`id_cliente_cuenta`),
  KEY `fk_movtipo` (`id_movimiento_tipo`),
  CONSTRAINT `fk_cuenta_c` FOREIGN KEY (`id_cliente_cuenta`) REFERENCES `cuenta` (`id`),
  CONSTRAINT `fk_movtipo` FOREIGN KEY (`id_movimiento_tipo`) REFERENCES `movimientotipo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=59 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of cuentamovimiento
-- ----------------------------
INSERT INTO `cuentamovimiento` VALUES ('1', '1', '1', '1', '500.5', '2017-09-14 14:22:14', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('2', '1', '1', '1', '352.8', '2017-09-14 09:21:22', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('4', '1', '2', '1', '100.1', '2017-09-14 10:00:00', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('5', '1', '1', '2', '400.9', '2017-09-14 11:00:00', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('6', '1', '1', '2', '33.3', '2017-09-14 11:00:00', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('7', '1', '1', '2', '33', '2017-09-14 14:13:51', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('8', '1', '1', '2', '100', '2017-09-15 10:49:46', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('9', '1', '1', '2', '6', '2017-09-15 11:00:48', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('10', '1', '1', '2', '80', '2017-09-15 11:08:10', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('11', '1', '1', '2', '2', '2017-09-15 11:09:48', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('12', '1', '1', '2', '1', '2017-09-15 11:11:44', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('13', '1', '1', '2', '7', '2017-09-15 11:17:03', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('14', '1', '1', '2', '10', '2017-09-15 11:24:58', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('15', '1', '1', '2', '11', '2017-09-17 09:23:38', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('16', '1', '1', '2', '77', '2017-09-17 09:48:18', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('19', '1', '1', '1', '7', '0000-00-00 00:00:00', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('20', '1', '1', '1', '1', '2017-09-22 16:02:29', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('21', '1', '1', '1', '20', '2017-09-22 23:05:13', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('22', '1', '2', '1', '7', '2017-09-24 13:41:55', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('23', '1', '2', '1', '5', '2017-09-25 23:39:50', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('24', '1', '2', '1', '4', '2017-09-25 23:41:08', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('25', '1', '2', '1', '3', '2017-09-25 23:42:01', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('26', '1', '2', '1', '30', '2017-09-26 00:07:36', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('27', '1', '2', '1', '5', '2017-09-26 00:43:20', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('28', '1', '2', '1', '2', '2017-09-26 00:46:07', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('29', '1', '2', '1', '2', '2017-09-26 00:47:22', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('30', '1', '2', '1', '2', '2017-09-26 00:47:51', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('31', '1', '2', '2', '100', '2017-09-26 00:51:52', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('33', '1', '2', '1', '4', '2017-09-26 01:03:42', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('34', '1', '2', '1', '150', '2017-09-26 01:04:31', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('35', '1', '2', '2', '133', '2017-09-26 01:05:03', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('36', '1', '2', '1', '10', '2017-09-26 01:17:31', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('37', '1', '2', '1', '11', '2017-09-26 01:40:33', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('38', '1', '2', '1', '5', '2017-09-26 11:41:52', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('39', '1', '2', '1', '339', '2017-09-27 15:33:55', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('40', '1', '2', '2', '61', '2017-09-27 15:34:36', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('41', '1', '2', '1', '3851', '2017-09-27 15:35:03', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('42', '1', '2', '1', '4236', '2017-09-27 15:35:26', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('43', '1', '2', '2', '847210', '2017-09-27 15:36:08', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('44', '1', '2', '1', '900000', '2017-09-27 15:37:44', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('45', '1', '2', '2', '60000', '2017-09-27 15:38:43', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('46', '1', '2', '1', '200', '2017-09-28 14:44:57', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('47', '1', '2', '1', '6210', '2017-09-28 14:45:16', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('48', '1', '2', '1', '12', '2017-09-28 14:57:41', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('49', '1', '2', '1', '4.9', '2017-09-28 15:00:47', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('50', '1', '2', '1', '55.2', '2017-09-28 15:02:56', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('51', '1', '2', '1', '44.2', '2017-09-28 15:15:16', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('52', '1', '1', '2', '200', '2017-09-28 15:19:54', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('53', '1', '2', '2', '12', '2017-09-29 11:10:03', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('54', '1', '2', '2', '12', '2017-09-29 11:13:38', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('55', '1', '2', '2', '700', '2017-09-29 13:55:11', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('56', '1', '2', '1', '500', '2017-10-02 01:08:47', 'N', '0');
INSERT INTO `cuentamovimiento` VALUES ('57', '1', '3', '1', '1500', '2017-11-12 20:55:47', 'N', '1');
INSERT INTO `cuentamovimiento` VALUES ('58', '1', '1', '1', '100', '2017-11-12 20:56:26', 'N', '1');

-- ----------------------------
-- Table structure for cuentaproveedor
-- ----------------------------
DROP TABLE IF EXISTS `cuentaproveedor`;
CREATE TABLE `cuentaproveedor` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cbu` varchar(40) NOT NULL,
  `nro_cuenta` varchar(50) NOT NULL,
  `saldo_actual` double(10,2) NOT NULL,
  `id_proveedor` int(11) DEFAULT NULL,
  `fecha_updated` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of cuentaproveedor
-- ----------------------------
INSERT INTO `cuentaproveedor` VALUES ('1', '1238238923892234', '12-1238238923892234', '-200.85', '1', '2017-09-30 14:54:58', '1', null);
INSERT INTO `cuentaproveedor` VALUES ('2', '1238238923892236', '12-1238238923893434', '500.85', '2', '2017-09-30 14:54:58', '1', null);
INSERT INTO `cuentaproveedor` VALUES ('3', '2222', '22222', '252.52', '1', '2017-10-24 20:52:55', '0', null);
INSERT INTO `cuentaproveedor` VALUES ('4', 'aaa', '12312', '123243.00', '6', '2017-10-24 20:55:13', '0', null);

-- ----------------------------
-- Table structure for garron
-- ----------------------------
DROP TABLE IF EXISTS `garron`;
CREATE TABLE `garron` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `numero` varchar(5) DEFAULT NULL,
  `id_tipo_garron` int(11) DEFAULT NULL,
  `id_tipo_estado` int(11) DEFAULT NULL,
  `fecha_entrada` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `peso` decimal(10,3) DEFAULT NULL,
  `mes` varchar(2) DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of garron
-- ----------------------------
INSERT INTO `garron` VALUES ('1', '230', '1', '1', '2017-11-04 20:08:45', '75.421', '10', '1', null);
INSERT INTO `garron` VALUES ('2', '231', '1', '2', '2017-11-04 20:08:45', '76.496', '10', '1', null);
INSERT INTO `garron` VALUES ('3', '254', '4', '1', '2017-11-17 00:00:00', '75.854', '11', '1', null);
INSERT INTO `garron` VALUES ('4', '745', '1', '1', '2017-11-04 00:00:00', '78.520', '11', '1', null);
INSERT INTO `garron` VALUES ('5', '123', '1', '1', '2017-11-04 00:00:00', '78.245', '11', '1', null);
INSERT INTO `garron` VALUES ('6', '66', '1', '1', '2017-11-04 00:00:00', '98.245', '11', '1', null);
INSERT INTO `garron` VALUES ('7', '542', '1', '1', '2017-11-04 00:00:00', '65.250', '11', '1', null);
INSERT INTO `garron` VALUES ('8', '321', '1', '1', '2017-11-04 00:00:00', '88.250', '11', '1', null);
INSERT INTO `garron` VALUES ('9', '11', '1', '1', '2017-11-04 00:00:00', '98.250', '11', '1', null);
INSERT INTO `garron` VALUES ('10', '111', '1', '1', '2017-11-04 00:00:00', '78.525', '11', '1', null);
INSERT INTO `garron` VALUES ('11', '652', '1', '1', '2017-11-04 00:00:00', '88.000', '12', '1', null);
INSERT INTO `garron` VALUES ('12', '111', '1', '1', '2017-11-04 00:00:00', '11.000', '11', '1', null);
INSERT INTO `garron` VALUES ('13', '425', '1', '1', '2017-11-06 00:00:00', '142.250', '11', '1', null);
INSERT INTO `garron` VALUES ('14', '458', '1', '1', '2017-11-06 00:00:00', '14.256', '11', '1', null);

-- ----------------------------
-- Table structure for garrondeposteparcial
-- ----------------------------
DROP TABLE IF EXISTS `garrondeposteparcial`;
CREATE TABLE `garrondeposteparcial` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_garron` int(11) NOT NULL,
  `id_producto` int(11) NOT NULL,
  `peso` decimal(10,3) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of garrondeposteparcial
-- ----------------------------
INSERT INTO `garrondeposteparcial` VALUES ('1', '2', '6', '10.256');
INSERT INTO `garrondeposteparcial` VALUES ('2', '2', '7', '18.620');
INSERT INTO `garrondeposteparcial` VALUES ('3', '2', '8', '20.680');

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
-- Table structure for garronproductodef
-- ----------------------------
DROP TABLE IF EXISTS `garronproductodef`;
CREATE TABLE `garronproductodef` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_tipo_garron` int(11) NOT NULL,
  `id_producto` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of garronproductodef
-- ----------------------------
INSERT INTO `garronproductodef` VALUES ('2', '1', '6');
INSERT INTO `garronproductodef` VALUES ('3', '1', '7');
INSERT INTO `garronproductodef` VALUES ('4', '1', '8');
INSERT INTO `garronproductodef` VALUES ('5', '1', '9');
INSERT INTO `garronproductodef` VALUES ('6', '1', '10');
INSERT INTO `garronproductodef` VALUES ('7', '1', '11');
INSERT INTO `garronproductodef` VALUES ('8', '1', '12');
INSERT INTO `garronproductodef` VALUES ('9', '1', '13');
INSERT INTO `garronproductodef` VALUES ('10', '1', '14');
INSERT INTO `garronproductodef` VALUES ('11', '1', '15');
INSERT INTO `garronproductodef` VALUES ('12', '1', '16');
INSERT INTO `garronproductodef` VALUES ('13', '1', '17');
INSERT INTO `garronproductodef` VALUES ('14', '1', '18');
INSERT INTO `garronproductodef` VALUES ('15', '1', '19');
INSERT INTO `garronproductodef` VALUES ('16', '2', '6');
INSERT INTO `garronproductodef` VALUES ('17', '2', '7');
INSERT INTO `garronproductodef` VALUES ('18', '2', '8');
INSERT INTO `garronproductodef` VALUES ('19', '2', '9');
INSERT INTO `garronproductodef` VALUES ('20', '2', '10');
INSERT INTO `garronproductodef` VALUES ('21', '2', '11');
INSERT INTO `garronproductodef` VALUES ('22', '2', '12');
INSERT INTO `garronproductodef` VALUES ('23', '2', '13');
INSERT INTO `garronproductodef` VALUES ('24', '2', '14');
INSERT INTO `garronproductodef` VALUES ('25', '2', '15');
INSERT INTO `garronproductodef` VALUES ('26', '2', '16');
INSERT INTO `garronproductodef` VALUES ('27', '2', '17');
INSERT INTO `garronproductodef` VALUES ('28', '2', '18');
INSERT INTO `garronproductodef` VALUES ('29', '2', '19');
INSERT INTO `garronproductodef` VALUES ('30', '3', '6');
INSERT INTO `garronproductodef` VALUES ('31', '3', '7');
INSERT INTO `garronproductodef` VALUES ('32', '3', '8');
INSERT INTO `garronproductodef` VALUES ('33', '3', '9');
INSERT INTO `garronproductodef` VALUES ('34', '3', '10');
INSERT INTO `garronproductodef` VALUES ('35', '3', '11');
INSERT INTO `garronproductodef` VALUES ('36', '3', '12');
INSERT INTO `garronproductodef` VALUES ('37', '3', '13');
INSERT INTO `garronproductodef` VALUES ('38', '3', '14');
INSERT INTO `garronproductodef` VALUES ('39', '3', '15');

-- ----------------------------
-- Table structure for garrontipo
-- ----------------------------
DROP TABLE IF EXISTS `garrontipo`;
CREATE TABLE `garrontipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

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
-- Table structure for gestorcuentas
-- ----------------------------
DROP TABLE IF EXISTS `gestorcuentas`;
CREATE TABLE `gestorcuentas` (
  `id` int(11) NOT NULL,
  `id_cuenta` int(11) NOT NULL,
  `id_cliente` int(11) DEFAULT NULL,
  `id_proveedor` int(11) DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_clientes` (`id_cliente`),
  KEY `fk_cuenta` (`id_cuenta`),
  CONSTRAINT `fk_clientes` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_cuenta` FOREIGN KEY (`id_cuenta`) REFERENCES `cuenta` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of gestorcuentas
-- ----------------------------
INSERT INTO `gestorcuentas` VALUES ('1', '1', '1', null, null, null);
INSERT INTO `gestorcuentas` VALUES ('2', '2', null, '1', null, null);

-- ----------------------------
-- Table structure for medida
-- ----------------------------
DROP TABLE IF EXISTS `medida`;
CREATE TABLE `medida` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of medida
-- ----------------------------
INSERT INTO `medida` VALUES ('1', 'cm');
INSERT INTO `medida` VALUES ('2', 'kg');
INSERT INTO `medida` VALUES ('3', 'lts');

-- ----------------------------
-- Table structure for modulo
-- ----------------------------
DROP TABLE IF EXISTS `modulo`;
CREATE TABLE `modulo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of modulo
-- ----------------------------
INSERT INTO `modulo` VALUES ('1', 'Clientes');
INSERT INTO `modulo` VALUES ('2', 'Proveedores');
INSERT INTO `modulo` VALUES ('3', 'Stock');
INSERT INTO `modulo` VALUES ('4', 'Caja');
INSERT INTO `modulo` VALUES ('5', 'Ventas');
INSERT INTO `modulo` VALUES ('6', 'Compras');
INSERT INTO `modulo` VALUES ('7', 'Movimiento Cuentas');
INSERT INTO `modulo` VALUES ('8', 'Gestion Usuarios');
INSERT INTO `modulo` VALUES ('9', 'Productos');
INSERT INTO `modulo` VALUES ('10', 'Ventas Caja');
INSERT INTO `modulo` VALUES ('11', 'Movimiento Cuentas Proveedores');
INSERT INTO `modulo` VALUES ('12', 'Carga Garron');

-- ----------------------------
-- Table structure for movimientotipo
-- ----------------------------
DROP TABLE IF EXISTS `movimientotipo`;
CREATE TABLE `movimientotipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of movimientotipo
-- ----------------------------
INSERT INTO `movimientotipo` VALUES ('1', 'DEBE');
INSERT INTO `movimientotipo` VALUES ('2', 'PAGO');

-- ----------------------------
-- Table structure for preciotipo
-- ----------------------------
DROP TABLE IF EXISTS `preciotipo`;
CREATE TABLE `preciotipo` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of preciotipo
-- ----------------------------
INSERT INTO `preciotipo` VALUES ('1', 'por kg');
INSERT INTO `preciotipo` VALUES ('2', 'por unidad');

-- ----------------------------
-- Table structure for producto
-- ----------------------------
DROP TABLE IF EXISTS `producto`;
CREATE TABLE `producto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_producto_tipo` int(11) NOT NULL,
  `id_codigo_barra` varchar(6) NOT NULL,
  `precio` decimal(10,3) NOT NULL,
  `cantidad` double(10,2) NOT NULL,
  `descripcion_breve` varchar(50) NOT NULL,
  `descripcion_larga` varchar(100) NOT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_precio` (`precio`)
) ENGINE=InnoDB AUTO_INCREMENT=79 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of producto
-- ----------------------------
INSERT INTO `producto` VALUES ('5', '1', '010990', '115.000', '1.00', 'CHORIZO ESPECIAL', 'CHORIZO ESPECIAL', '0', null);
INSERT INTO `producto` VALUES ('6', '1', '011000', '85.000', '1.00', 'CHORIZO PARRILLERO', 'CHORIZO PARRILLERO', '0', null);
INSERT INTO `producto` VALUES ('7', '1', '011010', '0.000', '1.00', 'CHORIZO DE CERDO', 'CHORIZO DE CERDO', '0', null);
INSERT INTO `producto` VALUES ('8', '1', '011020', '115.000', '1.00', 'CHORIZO COLORADO', 'CHORIZO COLORADO', '0', null);
INSERT INTO `producto` VALUES ('9', '1', '011030', '98.000', '1.00', 'SALCHICHA PARRILLERA', 'SALCHICHA PARRILLERA', '0', null);
INSERT INTO `producto` VALUES ('10', '1', '011040', '90.000', '1.00', 'MORCILLA', 'MORCILLA', '0', null);
INSERT INTO `producto` VALUES ('11', '1', '011050', '90.000', '1.00', 'MORCILLA', 'MORCILLA BOMBON', '0', null);
INSERT INTO `producto` VALUES ('12', '1', '011060', '90.000', '1.00', 'SALCHICHAS SNACK', 'SALCHICHAS SNACK', '0', null);
INSERT INTO `producto` VALUES ('13', '1', '011070', '80.000', '1.00', 'PATE', 'PATE', '0', null);
INSERT INTO `producto` VALUES ('14', '1', '011080', '80.000', '1.00', 'QUESO DE CERDO', 'QUESO DE CERDO', '0', null);
INSERT INTO `producto` VALUES ('15', '1', '011100', '90.000', '1.00', 'PICADA COMUN', 'PICADA COMUN', '0', null);
INSERT INTO `producto` VALUES ('16', '1', '011110', '100.000', '1.00', 'PICADA INTERMEDIA', 'PICADA INTERMEDIA', '0', null);
INSERT INTO `producto` VALUES ('17', '1', '011120', '135.000', '1.00', 'PICADA ESPECIAL', 'PICADA ESPECIAL', '0', null);
INSERT INTO `producto` VALUES ('18', '1', '011130', '50.000', '1.00', 'PUCHERO COMUN', 'PUCHERO COMUN', '0', null);
INSERT INTO `producto` VALUES ('19', '1', '011140', '89.000', '1.00', 'PUCHERO ESPECIAL', 'PUCHERO ESPECIAL', '0', null);
INSERT INTO `producto` VALUES ('20', '1', '011150', '10.000', '1.00', 'CANINO', 'CANINO', '0', null);
INSERT INTO `producto` VALUES ('21', '1', '011160', '145.000', '1.00', 'MATAMBRE', 'MATAMBRE', '0', null);
INSERT INTO `producto` VALUES ('22', '1', '011170', '140.000', '1.00', 'VACIO', 'VACIO', '0', null);
INSERT INTO `producto` VALUES ('23', '1', '011180', '135.000', '1.00', 'ALA DE PECHO', 'ALA DE PECHO', '0', null);
INSERT INTO `producto` VALUES ('24', '1', '011190', '140.000', '1.00', 'COSTILLA', 'COSTILLA', '0', null);
INSERT INTO `producto` VALUES ('25', '1', '011200', '125.000', '1.00', 'MARUCHA', 'MARUCHA', '0', null);
INSERT INTO `producto` VALUES ('26', '1', '011210', '135.000', '1.00', 'TAPA DE NALGA', 'TAPA DE NALGA', '0', null);
INSERT INTO `producto` VALUES ('27', '1', '011220', '160.000', '1.00', 'CORTE MALVINA', 'CORTE MALVINA', '0', null);
INSERT INTO `producto` VALUES ('28', '1', '011230', '92.000', '1.00', 'FALDA', 'FALDA', '0', null);
INSERT INTO `producto` VALUES ('29', '1', '011240', '125.000', '1.00', 'COSTELETAS', 'COSTELETAS', '0', null);
INSERT INTO `producto` VALUES ('30', '1', '011250', '99.000', '1.00', 'AGUJA', 'AGUJA', '0', null);
INSERT INTO `producto` VALUES ('31', '1', '011260', '125.000', '1.00', 'BRAZUELO', 'BRAZUELO', '0', null);
INSERT INTO `producto` VALUES ('32', '1', '011270', '170.000', '1.00', 'BIFE ANCHO/ANGOSTO', 'BIFE ANCHO/ANGOSTO', '0', null);
INSERT INTO `producto` VALUES ('33', '1', '011280', '170.000', '1.00', 'ENTRECOT', 'ENTRECOT', '0', null);
INSERT INTO `producto` VALUES ('34', '1', '011290', '180.000', '1.00', 'ROAST BEEF', 'ROAST BEEF', '0', null);
INSERT INTO `producto` VALUES ('35', '1', '011300', '145.000', '1.00', 'NALGAS', 'NALGAS', '0', null);
INSERT INTO `producto` VALUES ('36', '1', '011310', '180.000', '1.00', 'LOMO', 'LOMO', '0', null);
INSERT INTO `producto` VALUES ('37', '1', '011320', '145.000', '1.00', 'PECETO', 'PECETO', '0', null);
INSERT INTO `producto` VALUES ('38', '1', '011330', '145.000', '1.00', 'CUADRIL', 'CUADRIL', '0', null);
INSERT INTO `producto` VALUES ('39', '1', '011340', '145.000', '1.00', 'PALOMITA', 'PALOMITA', '0', null);
INSERT INTO `producto` VALUES ('40', '1', '011350', '145.000', '1.00', 'JAMON CUADRADO', 'JAMON CUADRADO', '0', null);
INSERT INTO `producto` VALUES ('41', '1', '011360', '140.000', '1.00', 'CABEZA DE LOMO', 'CABEZA DE LOMO', '0', null);
INSERT INTO `producto` VALUES ('42', '1', '011370', '140.000', '1.00', 'PULPA BRAZUELO', 'PULPA BRAZUELO', '0', null);
INSERT INTO `producto` VALUES ('43', '1', '011380', '135.000', '1.00', 'PULPA PALETA', 'PULPA PALETA', '0', null);
INSERT INTO `producto` VALUES ('44', '1', '011390', '140.000', '1.00', 'TORTUGUITA', 'TORTUGUITA', '0', null);
INSERT INTO `producto` VALUES ('45', '1', '011400', '120.000', '1.00', 'MILANESAS DE CARNE', 'MILANESAS DE CARNE', '0', null);
INSERT INTO `producto` VALUES ('46', '1', '011410', '89.000', '1.00', 'MILANESAS DE POLLO', 'MILANESAS DE POLLO', '0', null);
INSERT INTO `producto` VALUES ('47', '1', '011420', '99.000', '1.00', 'HAMBURGUESAS', 'HAMBURGUESAS', '0', null);
INSERT INTO `producto` VALUES ('48', '1', '011430', '99.000', '1.00', 'ALBONDIGAS', 'ALBONDIGAS', '0', null);
INSERT INTO `producto` VALUES ('49', '1', '011440', '0.000', '1.00', 'COSTELETAS', 'COSTELETAS', '0', null);
INSERT INTO `producto` VALUES ('50', '1', '011450', '0.000', '1.00', 'BONDIOLA', 'BONDIOLA', '0', null);
INSERT INTO `producto` VALUES ('51', '1', '011460', '0.000', '1.00', 'MATAMBRITO', 'MATAMBRITO', '0', null);
INSERT INTO `producto` VALUES ('52', '1', '011470', '0.000', '1.00', 'COSTILLA/PECHITO', 'COSTILLA/PECHITO', '0', null);
INSERT INTO `producto` VALUES ('53', '1', '011480', '0.000', '1.00', 'PULPAS', 'PULPAS', '0', null);
INSERT INTO `producto` VALUES ('54', '1', '011490', '0.000', '1.00', 'MARUCHA', 'MARUCHA', '0', null);
INSERT INTO `producto` VALUES ('55', '1', '011500', '0.000', '1.00', 'CARACU', 'CARACU', '0', null);
INSERT INTO `producto` VALUES ('56', '1', '011510', '0.000', '1.00', 'PATITAS/HUESITOS/CUERITO', 'PATITAS/HUESITOS/CUERITO', '0', null);
INSERT INTO `producto` VALUES ('57', '1', '011520', '0.000', '1.00', 'MILANESAS', 'MILANESAS', '0', null);
INSERT INTO `producto` VALUES ('58', '1', '011530', '0.000', '1.00', 'HAMBURGUESAS', 'HAMBURGUESAS', '0', null);
INSERT INTO `producto` VALUES ('59', '1', '011540', '0.000', '1.00', 'PATAMUSLO', 'PATAMUSLO', '0', null);
INSERT INTO `producto` VALUES ('60', '1', '011550', '0.000', '1.00', 'TROZADO', 'TROZADO', '0', null);
INSERT INTO `producto` VALUES ('61', '1', '011560', '0.000', '1.00', 'PECHUGA', 'PECHUGA', '0', null);
INSERT INTO `producto` VALUES ('62', '1', '011570', '0.000', '1.00', 'FILET', 'FILET', '0', null);
INSERT INTO `producto` VALUES ('63', '1', '011580', '0.000', '1.00', 'BROCHET', 'BROCHET', '0', null);
INSERT INTO `producto` VALUES ('64', '1', '011590', '0.000', '1.00', 'BONDIOLA', 'BONDIOLA', '0', null);
INSERT INTO `producto` VALUES ('65', '1', '011600', '0.000', '1.00', 'PALETA', 'PALETA', '0', null);
INSERT INTO `producto` VALUES ('66', '1', '011610', '0.000', '1.00', 'JAMON COCIDO', 'JAMON COCIDO', '0', null);
INSERT INTO `producto` VALUES ('67', '1', '011620', '0.000', '1.00', 'JAMON CRUDO', 'JAMON CRUDO', '0', null);
INSERT INTO `producto` VALUES ('68', '1', '011630', '0.000', '1.00', 'SALAME MILAN', 'SALAME MILAN', '0', null);
INSERT INTO `producto` VALUES ('69', '1', '011640', '0.000', '1.00', 'SALAMIN', 'SALAMIN', '0', null);
INSERT INTO `producto` VALUES ('70', '1', '011650', '0.000', '1.00', 'QUESO BARRA', 'QUESO BARRA', '0', null);
INSERT INTO `producto` VALUES ('71', '1', '011660', '0.000', '1.00', 'CREMOSO', 'CREMOSO', '0', null);
INSERT INTO `producto` VALUES ('72', '1', '011670', '0.000', '1.00', 'CASCARA COLORADA', 'CASCARA COLORADA', '0', null);
INSERT INTO `producto` VALUES ('73', '1', '011680', '0.000', '1.00', 'QUESO CRE', 'QUESO CREMOSO', '0', null);
INSERT INTO `producto` VALUES ('74', '1', '011690', '0.000', '1.00', 'QUESO TREEMBLAY', 'QUESO TREEMBLAY', '0', null);
INSERT INTO `producto` VALUES ('75', '1', '011700', '0.000', '1.00', 'QUESO PROVOLETA', 'QUESO PROVOLETA', '0', null);
INSERT INTO `producto` VALUES ('76', '1', '011710', '0.000', '1.00', 'QUESO SARDO', 'QUESO SARDO', '0', null);
INSERT INTO `producto` VALUES ('77', '1', '011720', '0.000', '1.00', 'MORTADELA', 'MORTADELA', '0', null);
INSERT INTO `producto` VALUES ('78', '1', '011730', '0.000', '1.00', 'MORTADELA', 'MORTADELA', '0', null);

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
INSERT INTO `productotipo` VALUES ('1', 'CARNE');
INSERT INTO `productotipo` VALUES ('2', 'EMBUTIDO');
INSERT INTO `productotipo` VALUES ('3', 'ALGO');

-- ----------------------------
-- Table structure for productoubicacion
-- ----------------------------
DROP TABLE IF EXISTS `productoubicacion`;
CREATE TABLE `productoubicacion` (
  `id` int(11) NOT NULL,
  `id_producto` int(11) NOT NULL,
  `id_ubicacion` int(11) NOT NULL,
  `fecha_egreso` datetime DEFAULT NULL,
  `fecha_ingreso` datetime DEFAULT NULL,
  `id_usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UQ_InventarioUbicacion_id_ubicacion` (`id`),
  KEY `id_producto` (`id_producto`),
  KEY `fk_ubi` (`id_ubicacion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of productoubicacion
-- ----------------------------

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of proveedor
-- ----------------------------
INSERT INTO `proveedor` VALUES ('1', 'Friar', 'santiago del estero 1234', 'santa fe', 'RI', 'Friar S.A.', '20-12345678-1', '034212345678', 'Federico Lopez', null, null, null);

-- ----------------------------
-- Table structure for proveedorcuenta
-- ----------------------------
DROP TABLE IF EXISTS `proveedorcuenta`;
CREATE TABLE `proveedorcuenta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cbu` varchar(40) NOT NULL,
  `nro_cuenta` varchar(50) NOT NULL,
  `saldo_actual` double(10,2) NOT NULL,
  `id_proveedor` int(11) DEFAULT NULL,
  `fecha_updated` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `id_banco` int(11) DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of proveedorcuenta
-- ----------------------------
INSERT INTO `proveedorcuenta` VALUES ('1', '1238238923892234', '12-1238238923892234', '-200.85', '1', '2017-11-12 19:53:42', '1', '1', null);
INSERT INTO `proveedorcuenta` VALUES ('2', '1238238923892236', '12-1238238923893434', '500.85', '2', '2017-11-12 19:53:39', '2', '1', null);
INSERT INTO `proveedorcuenta` VALUES ('3', '2222', '22222', '252.52', '1', '2017-11-12 19:53:29', '4', '0', null);
INSERT INTO `proveedorcuenta` VALUES ('4', 'aaa', '12312', '123243.00', '6', '2017-11-12 19:53:32', '3', '0', null);

-- ----------------------------
-- Table structure for proveedorcuentamovimiento
-- ----------------------------
DROP TABLE IF EXISTS `proveedorcuentamovimiento`;
CREATE TABLE `proveedorcuentamovimiento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `vob` char(1) NOT NULL COMMENT '(V)arias o (B)ancarias',
  `id_cuenta` int(11) NOT NULL,
  `id_movimiento_tipo` int(11) NOT NULL COMMENT '1 - DEBE| 2 - HABER',
  `monto` double NOT NULL,
  `fecha` datetime NOT NULL,
  `cobrado` char(1) NOT NULL DEFAULT 'N',
  `usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_movtipo` (`id_movimiento_tipo`),
  CONSTRAINT `proveedorcuentamovimiento_ibfk_2` FOREIGN KEY (`id_movimiento_tipo`) REFERENCES `movimientotipo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of proveedorcuentamovimiento
-- ----------------------------
INSERT INTO `proveedorcuentamovimiento` VALUES ('1', '1', '1', '1', '600', '2017-11-14 17:24:30', 'N', '0');
INSERT INTO `proveedorcuentamovimiento` VALUES ('2', '1', '1', '2', '600', '2017-11-15 11:54:13', 'N', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('3', '1', '3', '1', '500', '2017-11-15 11:55:15', 'N', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('4', '1', '3', '2', '1000', '2017-11-15 12:00:06', 'N', '1');

-- ----------------------------
-- Table structure for proveedortipo
-- ----------------------------
DROP TABLE IF EXISTS `proveedortipo`;
CREATE TABLE `proveedortipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of proveedortipo
-- ----------------------------
INSERT INTO `proveedortipo` VALUES ('1', 'Grande');

-- ----------------------------
-- Table structure for ubicacion
-- ----------------------------
DROP TABLE IF EXISTS `ubicacion`;
CREATE TABLE `ubicacion` (
  `id` int(11) NOT NULL,
  `id_ubicacion_tipo` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `id_usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `fk_ubi_tipo` (`id_ubicacion_tipo`),
  CONSTRAINT `fk_ubi_tipo` FOREIGN KEY (`id_ubicacion_tipo`) REFERENCES `ubicaciontipo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of ubicacion
-- ----------------------------
INSERT INTO `ubicacion` VALUES ('1', '1', 'ALA ESTE', null, null);
INSERT INTO `ubicacion` VALUES ('2', '1', 'ALA OESTE', null, null);
INSERT INTO `ubicacion` VALUES ('3', '2', 'ALA SUROESTE', null, '2017-10-11 17:33:43');

-- ----------------------------
-- Table structure for ubicaciontipo
-- ----------------------------
DROP TABLE IF EXISTS `ubicaciontipo`;
CREATE TABLE `ubicaciontipo` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of ubicaciontipo
-- ----------------------------
INSERT INTO `ubicaciontipo` VALUES ('1', 'FRIGORIFICO');
INSERT INTO `ubicaciontipo` VALUES ('2', 'DEPOSITO');

-- ----------------------------
-- Table structure for usuario
-- ----------------------------
DROP TABLE IF EXISTS `usuario`;
CREATE TABLE `usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(20) NOT NULL,
  `pass` varchar(20) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

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
INSERT INTO `usuariomodulo` VALUES ('9', '2', '1');
INSERT INTO `usuariomodulo` VALUES ('10', '2', '2');
INSERT INTO `usuariomodulo` VALUES ('11', '2', '4');
INSERT INTO `usuariomodulo` VALUES ('12', '2', '7');
INSERT INTO `usuariomodulo` VALUES ('13', '2', '8');
INSERT INTO `usuariomodulo` VALUES ('14', '2', '11');
INSERT INTO `usuariomodulo` VALUES ('15', '1', '12');

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
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of venta
-- ----------------------------
INSERT INTO `venta` VALUES ('1', '1108.000', '2017-10-23 20:04:26', '0', null);
INSERT INTO `venta` VALUES ('2', '1108.000', '2017-10-23 20:07:48', '0', null);
INSERT INTO `venta` VALUES ('3', '1108.000', '2017-10-23 20:08:00', '0', null);
INSERT INTO `venta` VALUES ('4', '1108.000', '2017-10-23 20:18:15', '0', null);
INSERT INTO `venta` VALUES ('5', '1108.000', '2017-10-23 20:20:11', '0', null);
INSERT INTO `venta` VALUES ('6', '1108.004', '2017-10-23 20:22:11', '0', null);
INSERT INTO `venta` VALUES ('7', '1110.042', '2017-10-24 19:45:11', '0', null);
INSERT INTO `venta` VALUES ('8', '1858.994', '2017-10-24 20:10:55', '0', null);
INSERT INTO `venta` VALUES ('9', '630.780', '2017-10-26 20:25:29', '0', null);
INSERT INTO `venta` VALUES ('10', '1261.560', '2017-10-26 20:25:35', '0', null);
INSERT INTO `venta` VALUES ('11', '1787.210', '2017-10-26 20:25:40', '0', null);
INSERT INTO `venta` VALUES ('12', '2069.254', '2017-10-27 18:55:55', '0', null);
INSERT INTO `venta` VALUES ('13', '2307.482', '2017-10-30 18:56:35', '0', null);
INSERT INTO `venta` VALUES ('14', '2152.872', '2017-11-02 21:17:32', '0', null);
INSERT INTO `venta` VALUES ('24', '4493.712', '2017-11-10 19:57:18', '0', null);
INSERT INTO `venta` VALUES ('25', '2495.296', '2017-11-10 20:01:24', '0', null);
INSERT INTO `venta` VALUES ('26', '1658.880', '2017-11-10 20:15:42', '0', null);
INSERT INTO `venta` VALUES ('27', '1871.472', '2017-11-10 20:20:55', '0', null);
INSERT INTO `venta` VALUES ('28', '3086.878', '2017-11-10 20:25:17', '0', null);
INSERT INTO `venta` VALUES ('29', '1244.160', '2017-11-10 20:27:03', '0', null);
INSERT INTO `venta` VALUES ('30', '3744.760', '2017-11-11 10:38:21', '0', null);

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
  `fecha_baja` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `fk_liquidacion` (`id_venta`),
  KEY `fk_produ` (`id_producto`)
) ENGINE=InnoDB AUTO_INCREMENT=203 DEFAULT CHARSET=latin1;

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
