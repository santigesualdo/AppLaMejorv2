/*
Navicat MySQL Data Transfer

Source Server         : carniceria
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : bdlamejor_dev

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2018-05-26 12:44:46
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
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of cliente
-- ----------------------------
INSERT INTO `cliente` VALUES ('1', 'ZR', 'JUAN CARLOS MARECO', 'BLAS PARERA 10290', 'SANTA FE', 'R.I', '1', 'J.M', '3424274573', '20-31669513-3', 'JUAN CARLOS MARECO', '2017-11-22', null, '1');
INSERT INTO `cliente` VALUES ('2', 'MR', 'ZANUTIGH MARIANO GERMAN', 'BV. PELEGRINI 3065', 'SANTA FE', 'R.I', '1', 'SANTA ANA', '20-24995216-9', '3424463794', 'ZANUTIGH MARIANO GERMAN', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('3', 'N', 'GUTIERREZ NERINA GUADALUPE', 'MARCIAL CANDIOTI 3285 ', 'SANTO TOME', 'R.I', '1', 'SUPER JUACO', '30-71423952-6', '342-156311029', 'GUTIERREZ NERINA GUADALUPE', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('4', 'BOSS', 'BOSSA EDGARDO OMAR', 'PTE FRONDIZZI 245- ', 'SUNCHALES', 'R.I', '1', ' ', '20-20320603-9', '3493-498525', 'BOSSA EDGARDO OMAR', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('5', 'E', 'HEINEN NORMA ESTELA', 'AUSTRIA Y RUTA 110', 'SAUCE VIEJO', 'R.I', '1', 'SAN CAYETANO', '27-13708517-3', '342-4995649', 'HEINEN NORMA ESTELA', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('6', 'LP', 'LÓPEZ JESABEL GUADALUPE ', 'MARCO CANDIOTI 1.756', 'CANDIOTI', 'MON', '1', 'CARNES LÓPEZ', '27-33468480-1', '342-156988763', 'LÓPEZ JESABEL GUADALUPE', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('7', 'ALL', 'ALLIONE ALBERTO ROQUE', 'RUTA 11 Km 427 S/N', 'CORONDA', 'MON', '1', 'CARNES ALLIONE', '20-21650528-0', '342-5023223', 'ALLIONE ALBERTO ROQUE', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('8', 'M2', 'RANIERI MIGUEL ANTONIO', 'ZONA RURAL 0', 'MONTE VERA', 'R.I', '1', 'CARNES RANIERI', '20-22763018-4', '342-155210956', 'RAINERI MIGUEL ANTONIO', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('9', 'GALL', 'CANALIS MARIA ROSA', 'TACUARI 8154', 'SANTA FE', 'R.I', '1', 'LA GALLEGA', '27-05947629-2', '342-469190/ 342-1569', 'CANALIS MARIA ROSA', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('10', 'EZ', 'MUÑOZ MILENA BETIANA', 'FACUNDO ZUVIRIA 5724', 'SANTA FE', 'R.I', '1', 'CARNES ENRIQUEZ', '27-37685347-6', '342-155194480', 'MUÑOZ MILENA BETIANA', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('11', 'RM', 'ROMANO MARIO ALBERTO', 'PADRE QUIROGA 2350', 'SANTA FE', 'R.I', '1', 'CARNES ROMANO', '20-17619634-4', '342-155150517', 'ROMANO MARIO ALBERTO', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('12', 'BL', 'BELLOMO MATIAS AUGUSTO', 'SANTIAGO DE CHILE 2.408', 'SANTA FE', 'R.I', '1', 'CARNES BELLOMO', '20-27719403-2', '342-154769177', 'BELLOMO MATIAS AUGUSTO', '2017-11-23', null, '1');
INSERT INTO `cliente` VALUES ('13', 'CL', 'PISATTI CECILIA', '', '', '', '1', 'CARNES PASATTI', '342-155036481', '', 'PISATTI CECILIA', '2017-11-23', '2018-01-19 00:00:00', '1');

-- ----------------------------
-- Table structure for clientecuenta
-- ----------------------------
DROP TABLE IF EXISTS `clientecuenta`;
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
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of clientecuenta
-- ----------------------------
INSERT INTO `clientecuenta` VALUES ('1', '-', 'EFECTIVO', '1', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('2', '-', 'EFECTIVO', '2', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('3', '-', 'EFECTIVO', '3', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('4', '-', 'EFECTIVO', '4', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('5', '-', 'EFECTIVO', '5', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('6', '-', 'EFECTIVO', '6', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('7', '-', 'EFECTIVO', '7', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('8', '-', 'EFECTIVO', '8', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('9', '-', 'EFECTIVO', '9', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('10', '-', 'EFECTIVO', '10', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('11', '-', 'EFECTIVO', '11', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('12', '-', 'EFECTIVO', '12', null, '1', null, '5');
INSERT INTO `clientecuenta` VALUES ('13', '-', 'EFECTIVO', '13', null, '1', null, '5');

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of clientecuentamovimiento
-- ----------------------------

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of compra
-- ----------------------------
INSERT INTO `compra` VALUES ('2', null, '2', '2018-05-26 12:00:08', '25.387', '25.387', '1', null);

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of compradetalle
-- ----------------------------
INSERT INTO `compradetalle` VALUES ('2', '2', null, '36', '25.387', '20.000', '0.000', '1', null);

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of garron
-- ----------------------------

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of garrondeposte
-- ----------------------------

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
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of modulo
-- ----------------------------
INSERT INTO `modulo` VALUES ('1', 'Productos');
INSERT INTO `modulo` VALUES ('2', 'Ubicacion de Productos');
INSERT INTO `modulo` VALUES ('3', 'Clientes');
INSERT INTO `modulo` VALUES ('4', 'Movimiento Cuentas Clientes');
INSERT INTO `modulo` VALUES ('5', 'Proveedores');
INSERT INTO `modulo` VALUES ('6', 'Movimiento Cuentas Proveedores');
INSERT INTO `modulo` VALUES ('7', 'Caja');
INSERT INTO `modulo` VALUES ('8', 'Caja Mayorista');
INSERT INTO `modulo` VALUES ('9', 'Ventas');
INSERT INTO `modulo` VALUES ('10', 'Carga Nueva Compra');
INSERT INTO `modulo` VALUES ('11', 'Compras');
INSERT INTO `modulo` VALUES ('12', 'Compras con Productos a Entregar');
INSERT INTO `modulo` VALUES ('13', 'Carga Garron');
INSERT INTO `modulo` VALUES ('14', 'Deposte');
INSERT INTO `modulo` VALUES ('15', 'Gestion Usuarios');
INSERT INTO `modulo` VALUES ('16', 'Ubicacion');
INSERT INTO `modulo` VALUES ('17', 'Reportes');

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
) ENGINE=InnoDB AUTO_INCREMENT=117 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of movimientomercaderia
-- ----------------------------
INSERT INTO `movimientomercaderia` VALUES ('116', '2018-05-26 12:00:18', '4', '2', '20.000', '36', null, '1', null);

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of operacion
-- ----------------------------

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of operacionproveedor
-- ----------------------------
INSERT INTO `operacionproveedor` VALUES ('2', '3', '0', '2018-05-26 12:00:08', '1');

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of preciohistorico
-- ----------------------------

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
  `descripcion_breve` varchar(50) NOT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_precio` (`precio`)
) ENGINE=InnoDB AUTO_INCREMENT=108 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of producto
-- ----------------------------
INSERT INTO `producto` VALUES ('1', '2', '1750', '0.000', '0.00', 'TRIPA', '1', null);
INSERT INTO `producto` VALUES ('2', '2', '1760', '0.000', '0.00', 'CHINCHULÍN', '1', null);
INSERT INTO `producto` VALUES ('3', '2', '1770', '0.000', '0.00', 'RIÑON', '1', null);
INSERT INTO `producto` VALUES ('4', '2', '1780', '0.000', '0.00', 'CORAZÓN', '1', null);
INSERT INTO `producto` VALUES ('5', '2', '1790', '0.000', '0.00', 'ENTRAÑA', '1', null);
INSERT INTO `producto` VALUES ('6', '2', '1800', '0.000', '0.00', 'RABO', '1', null);
INSERT INTO `producto` VALUES ('7', '2', '1810', '0.000', '0.00', 'MONDONGO', '1', null);
INSERT INTO `producto` VALUES ('8', '2', '1820', '0.000', '0.00', 'HÍGADO', '1', null);
INSERT INTO `producto` VALUES ('9', '2', '1830', '0.000', '0.00', 'MOLLEJAS', '1', null);
INSERT INTO `producto` VALUES ('10', '2', '1850', '0.000', '0.00', 'LENGUA', '1', null);
INSERT INTO `producto` VALUES ('11', '2', '1860', '0.000', '0.00', 'QUIJADA', '1', null);
INSERT INTO `producto` VALUES ('12', '2', '1870', '0.000', '0.00', 'DUOS', '1', null);
INSERT INTO `producto` VALUES ('13', '2', '1880', '0.000', '0.00', 'CARRE ', '1', null);
INSERT INTO `producto` VALUES ('14', '2', '1890', '0.000', '0.00', 'PECHITO', '1', null);
INSERT INTO `producto` VALUES ('15', '2', '1900', '0.000', '0.00', 'JAMON ENTERO', '1', null);
INSERT INTO `producto` VALUES ('16', '2', '1910', '0.000', '0.00', 'CHURRASQUITO', '1', null);
INSERT INTO `producto` VALUES ('17', '2', '1920', '0.000', '0.00', 'PALETA ENTERA', '1', null);
INSERT INTO `producto` VALUES ('18', '2', '1930', '0.000', '0.00', 'PAPADA', '1', null);
INSERT INTO `producto` VALUES ('19', '2', '1940', '0.000', '0.00', 'TOCINO', '1', null);
INSERT INTO `producto` VALUES ('20', '2', '1950', '0.000', '0.00', 'MATAMBRITOS', '1', null);
INSERT INTO `producto` VALUES ('21', '2', '1960', '0.000', '0.00', 'BONDIOLA', '1', null);
INSERT INTO `producto` VALUES ('22', '3', null, '0.000', '0.00', '1/2 RESES', '1', null);
INSERT INTO `producto` VALUES ('23', '3', null, '0.000', '0.00', '1/4 RUEDA', '1', null);
INSERT INTO `producto` VALUES ('24', '3', null, '0.000', '0.00', '1/4 PISTOLA', '1', null);
INSERT INTO `producto` VALUES ('25', '3', null, '0.000', '0.00', ' 1/4 DELANTERO ', '1', null);
INSERT INTO `producto` VALUES ('26', '3', null, '0.000', '0.00', 'BARRAS', '1', null);
INSERT INTO `producto` VALUES ('27', '3', null, '0.000', '0.00', 'MOCHITOS', '1', null);
INSERT INTO `producto` VALUES ('28', '3', null, '0.000', '0.00', 'MANTAS', '1', null);
INSERT INTO `producto` VALUES ('29', '3', null, '0.000', '0.00', 'RECORTE', '1', null);
INSERT INTO `producto` VALUES ('30', '3', null, '0.000', '0.00', 'PARRILLERO', '1', null);
INSERT INTO `producto` VALUES ('31', '3', null, '0.000', '0.00', 'JUEGOS DE ACHURAS', '1', null);
INSERT INTO `producto` VALUES ('32', '3', null, '0.000', '0.00', 'RECORTE DE 1', '1', null);
INSERT INTO `producto` VALUES ('33', '3', null, '0.000', '0.00', 'RECORTE DE 2°', '1', null);
INSERT INTO `producto` VALUES ('34', '1', '0990', '0.000', '0.00', 'CHORIZO ESPECIAL', '1', null);
INSERT INTO `producto` VALUES ('35', '1', '1000', '0.000', '0.00', 'CHORIZO PARRILLERO', '1', null);
INSERT INTO `producto` VALUES ('36', '1', '1010', '0.000', '20.00', 'CHORIZO DE CERDO', '1', null);
INSERT INTO `producto` VALUES ('37', '1', '1020', '0.000', '0.00', 'CHORIZO COLORADO', '1', null);
INSERT INTO `producto` VALUES ('38', '1', '1030', '0.000', '0.00', 'SALCHICHA PARRILL.', '1', null);
INSERT INTO `producto` VALUES ('39', '1', '1040', '0.000', '0.00', 'MORCILLA', '1', null);
INSERT INTO `producto` VALUES ('40', '1', '1050', '0.000', '0.00', 'MORCILLA', '1', null);
INSERT INTO `producto` VALUES ('41', '1', '1060', '0.000', '0.00', 'SALCHICHAS SNACK', '1', null);
INSERT INTO `producto` VALUES ('42', '1', '1070', '0.000', '0.00', 'PATE', '1', null);
INSERT INTO `producto` VALUES ('43', '1', '1080', '0.000', '0.00', 'QUESO DE CERDO', '1', null);
INSERT INTO `producto` VALUES ('44', '1', '1100', '0.000', '0.00', 'PICADA COMUN', '1', null);
INSERT INTO `producto` VALUES ('45', '1', '1110', '0.000', '0.00', 'PICADA INTERMEDIA', '1', null);
INSERT INTO `producto` VALUES ('46', '1', '1120', '0.000', '0.00', 'PICADA ESPECIAL', '1', null);
INSERT INTO `producto` VALUES ('47', '1', '1130', '0.000', '0.00', 'PUCHERO COMUN', '1', null);
INSERT INTO `producto` VALUES ('48', '1', '1140', '0.000', '0.00', 'PUCHERO ESPECIAL', '1', null);
INSERT INTO `producto` VALUES ('49', '1', '1150', '0.000', '0.00', 'CANINO', '1', null);
INSERT INTO `producto` VALUES ('50', '1', '1160', '0.000', '0.00', 'MATAMBRE', '1', null);
INSERT INTO `producto` VALUES ('51', '1', '1170', '0.000', '0.00', 'VACIO', '1', null);
INSERT INTO `producto` VALUES ('52', '1', '1180', '0.000', '0.00', 'ALA DE PECHO', '1', null);
INSERT INTO `producto` VALUES ('53', '1', '1190', '0.000', '0.00', 'COSTILLA', '1', null);
INSERT INTO `producto` VALUES ('54', '1', '1200', '0.000', '0.00', 'MARUCHA', '1', null);
INSERT INTO `producto` VALUES ('55', '1', '1210', '0.000', '0.00', 'TAPA DE NALGA', '1', null);
INSERT INTO `producto` VALUES ('56', '1', '1220', '0.000', '0.00', 'CORTE MALVINA', '1', null);
INSERT INTO `producto` VALUES ('57', '1', '1230', '0.000', '0.00', 'FALDA', '1', null);
INSERT INTO `producto` VALUES ('58', '1', '1240', '0.000', '0.00', 'COSTELETAS', '1', null);
INSERT INTO `producto` VALUES ('59', '1', '1250', '0.000', '0.00', 'AGUJA', '1', null);
INSERT INTO `producto` VALUES ('60', '1', '1260', '0.000', '0.00', 'BRAZUELO', '1', null);
INSERT INTO `producto` VALUES ('61', '1', '1270', '0.000', '0.00', 'BIFE ANCHO/ANGOSTO', '1', null);
INSERT INTO `producto` VALUES ('62', '1', '1280', '0.000', '0.00', 'ENTRECOT', '1', null);
INSERT INTO `producto` VALUES ('63', '1', '1290', '0.000', '0.00', 'ROAST BEEF', '1', null);
INSERT INTO `producto` VALUES ('64', '1', '1300', '0.000', '0.00', 'NALGAS', '1', null);
INSERT INTO `producto` VALUES ('65', '1', '1310', '0.000', '0.00', 'LOMO', '1', null);
INSERT INTO `producto` VALUES ('66', '1', '1320', '0.000', '0.00', 'PECETO', '1', null);
INSERT INTO `producto` VALUES ('67', '1', '1330', '0.000', '0.00', 'CUADRIL', '1', null);
INSERT INTO `producto` VALUES ('68', '1', '1340', '0.000', '0.00', 'PALOMITA', '1', null);
INSERT INTO `producto` VALUES ('69', '1', '1350', '0.000', '0.00', 'JAMON CUADRADO', '1', null);
INSERT INTO `producto` VALUES ('70', '1', '1360', '0.000', '0.00', 'CABEZA DE LOMO', '1', null);
INSERT INTO `producto` VALUES ('71', '1', '1370', '0.000', '0.00', 'PULPA BRAZUELO', '1', null);
INSERT INTO `producto` VALUES ('72', '1', '1380', '0.000', '0.00', 'PULPA PALETA', '1', null);
INSERT INTO `producto` VALUES ('73', '1', '1390', '0.000', '0.00', 'TORTUGUITA', '1', null);
INSERT INTO `producto` VALUES ('74', '1', '1400', '0.000', '0.00', 'MILANESAS DE CARNE', '1', null);
INSERT INTO `producto` VALUES ('75', '1', '1410', '0.000', '0.00', 'MILANESAS DE POLLO', '1', null);
INSERT INTO `producto` VALUES ('76', '1', '1420', '0.000', '0.00', 'HAMBURGUESAS', '1', null);
INSERT INTO `producto` VALUES ('77', '1', '1430', '0.000', '0.00', 'ALBONDIGAS', '1', null);
INSERT INTO `producto` VALUES ('78', '1', '1440', '0.000', '0.00', 'COSTELETAS', '1', null);
INSERT INTO `producto` VALUES ('79', '1', '1450', '0.000', '0.00', 'BONDIOLA', '1', null);
INSERT INTO `producto` VALUES ('80', '1', '1460', '0.000', '0.00', 'MATAMBRITO', '1', null);
INSERT INTO `producto` VALUES ('81', '1', '1470', '0.000', '0.00', 'COSTILLA/PECHITO', '1', null);
INSERT INTO `producto` VALUES ('82', '1', '1480', '0.000', '0.00', 'PULPAS', '1', null);
INSERT INTO `producto` VALUES ('83', '1', '1490', '0.000', '0.00', 'MARUCHA', '1', null);
INSERT INTO `producto` VALUES ('84', '1', '1500', '0.000', '0.00', 'CARACU', '1', null);
INSERT INTO `producto` VALUES ('85', '1', '1510', '0.000', '0.00', 'PAT./HUE./CUE.', '1', null);
INSERT INTO `producto` VALUES ('86', '1', '1520', '0.000', '0.00', 'MILANESAS', '1', null);
INSERT INTO `producto` VALUES ('87', '1', '1530', '0.000', '0.00', 'HAMBURGUESAS', '1', null);
INSERT INTO `producto` VALUES ('88', '1', '1540', '0.000', '0.00', 'PATAMUSLO', '1', null);
INSERT INTO `producto` VALUES ('89', '1', '1550', '0.000', '0.00', 'TROZADO', '1', null);
INSERT INTO `producto` VALUES ('90', '1', '1560', '0.000', '0.00', 'PECHUGA', '1', null);
INSERT INTO `producto` VALUES ('91', '1', '1570', '0.000', '0.00', 'FILET', '1', null);
INSERT INTO `producto` VALUES ('92', '1', '1580', '0.000', '0.00', 'BROCHET', '1', null);
INSERT INTO `producto` VALUES ('93', '1', '1590', '0.000', '0.00', 'BONDIOLA', '1', null);
INSERT INTO `producto` VALUES ('94', '1', '1600', '0.000', '0.00', 'PALETA', '1', null);
INSERT INTO `producto` VALUES ('95', '1', '1610', '0.000', '0.00', 'JAMON COCIDO', '1', null);
INSERT INTO `producto` VALUES ('96', '1', '1620', '0.000', '0.00', 'JAMON CRUDO', '1', null);
INSERT INTO `producto` VALUES ('97', '1', '1630', '0.000', '0.00', 'SALAME MILAN', '1', null);
INSERT INTO `producto` VALUES ('98', '1', '1640', '0.000', '0.00', 'SALAMIN', '1', null);
INSERT INTO `producto` VALUES ('99', '1', '1650', '0.000', '0.00', 'QUESO BARRA', '1', null);
INSERT INTO `producto` VALUES ('100', '1', '1660', '0.000', '0.00', 'CREMOSO', '1', null);
INSERT INTO `producto` VALUES ('101', '1', '1670', '0.000', '0.00', 'CASCARA COLORADA', '1', null);
INSERT INTO `producto` VALUES ('102', '1', '1680', '0.000', '0.00', 'QUESO CRE', '1', null);
INSERT INTO `producto` VALUES ('103', '1', '1690', '0.000', '0.00', 'QUESO TREEMBLAY', '1', null);
INSERT INTO `producto` VALUES ('104', '1', '1700', '0.000', '0.00', 'QUESO PROVOLETA', '1', null);
INSERT INTO `producto` VALUES ('105', '1', '1710', '0.000', '0.00', 'QUESO SARDO', '1', null);
INSERT INTO `producto` VALUES ('106', '1', '1720', '0.000', '0.00', 'MORTADELA', '1', null);
INSERT INTO `producto` VALUES ('107', '1', '1730', '0.000', '0.00', 'MORTADELA', '1', null);

-- ----------------------------
-- Table structure for productotipo
-- ----------------------------
DROP TABLE IF EXISTS `productotipo`;
CREATE TABLE `productotipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of productotipo
-- ----------------------------
INSERT INTO `productotipo` VALUES ('1', 'CAJA');
INSERT INTO `productotipo` VALUES ('2', 'MINORISTA');
INSERT INTO `productotipo` VALUES ('3', 'MAYORISTA');
INSERT INTO `productotipo` VALUES ('4', 'KIOSCO');

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of productoubicacion
-- ----------------------------
INSERT INTO `productoubicacion` VALUES ('1', '36', null, '4', '0.000', '2018-05-26 12:00:18', '2018-05-26 12:00:08', '1', null);
INSERT INTO `productoubicacion` VALUES ('2', '36', null, '2', '20.000', null, '2018-05-26 12:00:18', '1', null);

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of proveedor
-- ----------------------------

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of proveedorcuenta
-- ----------------------------

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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of proveedorcuentamovimiento
-- ----------------------------
INSERT INTO `proveedorcuentamovimiento` VALUES ('3', '2', '0', '1', '25.387', '2018-05-26 12:00:08', 'N', '1');
INSERT INTO `proveedorcuentamovimiento` VALUES ('4', '2', '0', '2', '25.387', '2018-05-26 12:00:08', 'S', '1');

-- ----------------------------
-- Table structure for ubicacion
-- ----------------------------
DROP TABLE IF EXISTS `ubicacion`;
CREATE TABLE `ubicacion` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `entrada` int(1) DEFAULT NULL,
  `salida` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of ubicacion
-- ----------------------------
INSERT INTO `ubicacion` VALUES ('1', 'SALON DE VENTAS', '0', '1');
INSERT INTO `ubicacion` VALUES ('2', 'CAMARA GRANDE', '0', '0');
INSERT INTO `ubicacion` VALUES ('3', 'CAMARA CHICA', '0', '0');
INSERT INTO `ubicacion` VALUES ('4', 'DEPOSITO', '1', '0');

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
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of usuariomodulo
-- ----------------------------
INSERT INTO `usuariomodulo` VALUES ('1', '1', '1');
INSERT INTO `usuariomodulo` VALUES ('2', '1', '2');
INSERT INTO `usuariomodulo` VALUES ('3', '1', '3');
INSERT INTO `usuariomodulo` VALUES ('4', '1', '4');
INSERT INTO `usuariomodulo` VALUES ('5', '1', '5');
INSERT INTO `usuariomodulo` VALUES ('6', '1', '6');
INSERT INTO `usuariomodulo` VALUES ('7', '1', '7');
INSERT INTO `usuariomodulo` VALUES ('8', '1', '8');
INSERT INTO `usuariomodulo` VALUES ('9', '1', '9');
INSERT INTO `usuariomodulo` VALUES ('10', '1', '10');
INSERT INTO `usuariomodulo` VALUES ('11', '1', '11');
INSERT INTO `usuariomodulo` VALUES ('12', '1', '12');
INSERT INTO `usuariomodulo` VALUES ('13', '1', '13');
INSERT INTO `usuariomodulo` VALUES ('14', '1', '14');
INSERT INTO `usuariomodulo` VALUES ('15', '1', '15');
INSERT INTO `usuariomodulo` VALUES ('16', '1', '16');
INSERT INTO `usuariomodulo` VALUES ('17', '1', '17');

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of venta
-- ----------------------------

-- ----------------------------
-- Table structure for ventadetalle
-- ----------------------------
DROP TABLE IF EXISTS `ventadetalle`;
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of ventadetalle
-- ----------------------------

-- ----------------------------
-- View structure for vistacompra
-- ----------------------------
DROP VIEW IF EXISTS `vistacompra`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `vistacompra` AS select `v`.`id` AS `id`,`v`.`id_operacion` AS `id_operacion`,`p`.`id_codigo_barra` AS `codigo`,`p`.`descripcion_breve` AS `descripcion`,`vd`.`peso` AS `peso`,`vd`.`monto` AS `monto`,`v`.`monto_total` AS `monto_total` from (((`compra` `v` join `compradetalle` `vd` on((`v`.`id` = `vd`.`id_compra`))) join `producto` `p` on((`vd`.`id_producto` = `p`.`id`))) join `operacionproveedor` `o` on((`v`.`id_operacion` = `o`.`id`))) where (`v`.`id` = 10) ;

-- ----------------------------
-- View structure for vistacompraseleccionada
-- ----------------------------
DROP VIEW IF EXISTS `vistacompraseleccionada`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `vistacompraseleccionada` AS SELECT v.id AS id, v.id_operacion AS id_operacion, o.id_proveedor AS id_proveedor, p.id_codigo_barra AS codigo,  (CASE WHEN isnull(p.id) THEN concat('Garron #', g.numero, ' ID:', g.id )  ELSE p.descripcion_breve END ) AS descripcion, vd.peso AS peso, vd.monto AS monto, v.monto_total AS monto_total  FROM compra v  JOIN compradetalle vd ON v.id = vd.id_compra  LEFT JOIN producto p ON vd.id_producto = p.id AND p.id IS NOT NULL  LEFT JOIN garron g ON vd.id_garron = g.id AND g.id IS NOT NULL  JOIN operacionproveedor o ON v.id_operacion = o.id WHERE v.id =8 ;

-- ----------------------------
-- View structure for vistalistadomovimientosclientes
-- ----------------------------
DROP VIEW IF EXISTS `vistalistadomovimientosclientes`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost`  VIEW `vistalistadomovimientosclientes` AS SELECT
             cm.id,

            dayofmonth(cm.`fecha`) AS `dia`,

            ELT(
            DATE_FORMAT(cm.fecha, '%m'),
             'Enero',
             'Febrero',
             'Marzo',
             'Abril',
             'Mayo',
             'Junio',
             'Julio',
             'Agosto',
             'Septiembre',
             'Octubre',
             'Noviembre',
             'Diciembre'
             ) AS mes,
             YEAR (cm.fecha) AS año,
             DATE_FORMAT(cm.fecha, '%d-%m-%Y') AS fecha,
             DATE_FORMAT(cm.fecha, '%H:%i') AS hora,
             c.razon_social,
             c.cuit,
             gc.descripcion,
             cm.id_cuenta AS cuenta,
             cm.id_movimiento_tipo AS id_tipo,
             mt.descripcion AS tipo,
             gc.id_banco,
             cm.id_operacion AS operacion,
             IF((`cm`.`id_movimiento_tipo` = 2),
             `cm`.`monto`,(`cm`.`monto` *-(1))) AS `monto`
             FROM
             clientecuentamovimiento cm
             INNER JOIN clientecuenta gc ON cm.id_cuenta = gc.id
             INNER JOIN movimientotipo mt ON cm.id_movimiento_tipo = mt.id
             INNER JOIN cliente c ON gc.id_cliente = c.id
             WHERE gc.id_cliente IS NOT NULL AND  
             cm.`fecha` BETWEEN '2018-01-01' AND DATE_ADD('2018-01-02',INTERVAL 1 DAY)  
             ORDER BY cm.id DESC ;

-- ----------------------------
-- View structure for vistalistadomovimientosproveedores
-- ----------------------------
DROP VIEW IF EXISTS `vistalistadomovimientosproveedores`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost`  VIEW `vistalistadomovimientosproveedores` AS SELECT 
	`cm`.`id` AS `id`, 
    dayofmonth(`cm`.`fecha`) AS `dia`, 
    elt(date_format(`cm`.`fecha`, '%m'), 
        'Enero', 
        'Febrero', 
        'Marzo', 
        'Abril', 
        'Mayo', 
        'Junio', 
        'Julio', 
        'Agosto', 
        'Septiembre', 
        'Octubre', 
        'Noviembre', 
        'Diciembre' 
    ) AS `mes`, 
    YEAR(`cm`.`fecha`) AS `año`, 
    date_format(`cm`.`fecha`, '%d-%m-%Y') AS `fecha`, 
    date_format(`cm`.`fecha`, '%H:%i') AS `hora`, 
    `c`.`razon_social` AS `razon_social`, 
    `c`.`cuit` AS `cuit`, 
    `gc`.`descripcion` AS `descripcion`, 
    `cm`.`id_cuenta` AS `cuenta`, 
    `cm`.`id_movimiento_tipo` AS `id_tipo`, 
    `mt`.`descripcion` AS `tipo`, 
    `gc`.`id_banco` AS `id_banco`, 
    `cm`.`id_operacion` AS `operacion`, 
    IF ((`cm`.`id_movimiento_tipo` = 2),`cm`.`monto`,(`cm`.`monto` * -(1))) AS `monto` 
    FROM 
         (((`proveedorcuentamovimiento` `cm` 
                JOIN `proveedorcuenta` `gc` ON ((`cm`.`id_cuenta` = `gc`.`id`))) 
             JOIN `movimientotipo` `mt` ON((`cm`.`id_movimiento_tipo` = `mt`.`id`))) 
         JOIN `proveedor` `c` ON((`gc`.`id_proveedor` = `c`.`id`))) 
     WHERE 
     `gc`.`id_proveedor` IS NOT NULL AND `cm`.`fecha` BETWEEN '2018-01-01' AND DATE_ADD('2018-01-02',INTERVAL 1 DAY)
             ORDER BY cm.id DESC ;

-- ----------------------------
-- View structure for vistalistadoventas
-- ----------------------------
DROP VIEW IF EXISTS `vistalistadoventas`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost`  VIEW `vistalistadoventas` AS SELECT  
	 `v`.`id` AS `id`, 
     dayofmonth(`v`.`fecha`) AS `dia`, 
     ELT(DATE_FORMAT(`v`.`fecha`, '%m'), 
        'Enero', 
        'Febrero', 
        'Marzo', 
        'Abril', 
        'Mayo', 
        'Junio', 
        'Julio', 
        'Agosto', 
        'Septiembre', 
        'Octubre', 
        'Noviembre',  
		'Diciembre') AS `mes`, 
                     YEAR(`v`.`fecha`) AS `año`,  
	 date_format(`v`.`fecha`, '%d/%m/%Y') AS `fecha`, 
     date_format(`v`.`fecha`, '%H:%i') AS `hora`, 
	 `v`.`monto_total` AS `monto`, 
	 `v`.`id_operacion` AS `operacion`, 
	 `c`.`razon_social` AS `cliente`, 
               `c`.`cuit` AS `cuit` 
     FROM    ((	`venta` `v`   JOIN `operacion` `o` ON((	`o`.`id` = `v`.`id_operacion`))) 
        JOIN `cliente` `c` ON((`o`.`id_cliente` = `c`.`id`))) 
	 WHERE    (		`v`.`fecha` BETWEEN '2018-01-01' AND DATE_ADD('2018-01-02',INTERVAL 1 DAY)) ;

-- ----------------------------
-- View structure for vistasaldocliente
-- ----------------------------
DROP VIEW IF EXISTS `vistasaldocliente`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `vistasaldocliente` AS SELECT   `id`, `razon_social`, SUM(`saldo`) AS 'saldo' FROM   `vistasaldoporidcliente` GROUP BY   `id` ;

-- ----------------------------
-- View structure for vistasaldoporidcliente
-- ----------------------------
DROP VIEW IF EXISTS `vistasaldoporidcliente`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `vistasaldoporidcliente` AS SELECT   `c`.`id`,   `c`.`cod_cliente`,   `c`.`razon_social`,   `c`.`cuit`,   `cc`.`id` AS 'id_cliente_cuenta',   `cc`.`descripcion`,   `cc`.`id_banco`, `ccm`.`id_operacion`,   `mt`.`descripcion` AS 'tipo',   `ccm`.`fecha`,   IF((`ccm`.`id_movimiento_tipo` = 2), `ccm`.`monto`, (`ccm`.`monto` *-(1))) AS 'saldo'  FROM(((`clientecuenta` cc    JOIN `cliente` c ON ((`cc`.`id_cliente` = `c`.`id`)))    JOIN `clientecuentamovimiento` ccm ON ((`ccm`.`id_cuenta` = `cc`.`id`)))    JOIN `movimientotipo` mt ON ((`ccm`.`id_movimiento_tipo` = `mt`.`id`)))  WHERE(`c`.`id` = 42) ;

-- ----------------------------
-- View structure for vistasaldoporidproveedor
-- ----------------------------
DROP VIEW IF EXISTS `vistasaldoporidproveedor`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost`  VIEW `vistasaldoporidproveedor` AS SELECT
  `c`.`id`,
  `c`.`razon_social`,
  `c`.`cuit`,
  `cc`.`id` AS 'id_proveedor_cuenta',
  `cc`.`descripcion`,
  `cc`.`id_banco`,
  `ccm`.`id_operacion`,
  `mt`.`descripcion` AS 'tipo',
  `ccm`.`fecha`,
  IF((`ccm`.`id_movimiento_tipo` = 2), `ccm`.`monto`, (`ccm`.`monto` * -(1))) AS 'saldo'
FROM
  (((`proveedorcuenta` cc
    JOIN `proveedor` c ON ((`cc`.`id_proveedor` = `c`.`id`)))
    JOIN `proveedorcuentamovimiento` ccm ON ((`ccm`.`id_cuenta` = `cc`.`id`)))
    JOIN `movimientotipo` mt ON ((`ccm`.`id_movimiento_tipo` = `mt`.`id`)))
WHERE
  (`c`.`id` = 1) ;

-- ----------------------------
-- View structure for vistasaldoproveedor
-- ----------------------------
DROP VIEW IF EXISTS `vistasaldoproveedor`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost`  VIEW `vistasaldoproveedor` AS SELECT
  `id`, `razon_social`, SUM(`saldo`) AS 'saldo'
FROM
  `vistasaldoporidproveedor`
GROUP BY
  `id` ;

-- ----------------------------
-- View structure for vistaultimacompra
-- ----------------------------
DROP VIEW IF EXISTS `vistaultimacompra`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost`  VIEW `vistaultimacompra` AS SELECT
  `c`.`id`,
  `c`.`razon_social`,
  `c`.`domicilio`,
  `c`.`cuit`,
  `cc`.`id` AS 'id_proveedor_cuenta',
  `cc`.`descripcion`,
  `cc`.`id_banco`,
  `ccm`.`id_operacion`,
  `mt`.`descripcion` AS 'tipo',
  `ccm`.`fecha`,
  IF((`ccm`.`id_movimiento_tipo` = 2), `ccm`.`monto`, (`ccm`.`monto` * -(1))) AS 'saldo'
FROM
  (((`proveedorcuenta` cc
    JOIN `proveedor` c ON ((`cc`.`id_proveedor` = `c`.`id`)))
    JOIN `proveedorcuentamovimiento` ccm ON ((`ccm`.`id_cuenta` = `cc`.`id`)))
    JOIN `movimientotipo` mt ON ((`ccm`.`id_movimiento_tipo` = `mt`.`id`)))
WHERE
  (`ccm`.`id_operacion` = 1) ;

-- ----------------------------
-- View structure for vistaultimaventa
-- ----------------------------
DROP VIEW IF EXISTS `vistaultimaventa`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `vistaultimaventa` AS SELECT   `c`.`id`,   `c`.`cod_cliente`,   `c`.`razon_social`,  	`c`.`domicilio`,  `c`.`cuit`,   `cc`.`id` AS 'id_cliente_cuenta',   `cc`.`descripcion`,   `cc`.`id_banco`,   `ccm`.`id_operacion`,  `mt`.`descripcion` AS 'tipo',   `ccm`.`fecha`,   IF((`ccm`.`id_movimiento_tipo` = 2), `ccm`.`monto`, (`ccm`.`monto` *-(1))) AS 'saldo'  FROM       (((`clientecuenta` cc     JOIN `cliente` c ON((`cc`.`id_cliente` = `c`.`id`)))     JOIN `clientecuentamovimiento` ccm ON ((`ccm`.`id_cuenta` = `cc`.`id`)))     JOIN `movimientotipo` mt ON ((`ccm`.`id_movimiento_tipo` = `mt`.`id`))) WHERE  (`ccm`.`id_operacion` = 13) ;

-- ----------------------------
-- View structure for vistaultimaventaporcliente
-- ----------------------------
DROP VIEW IF EXISTS `vistaultimaventaporcliente`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `vistaultimaventaporcliente` AS SELECT  `v`.`id`, `v`.`id_operacion`,  o.id_cliente, `p`.`id_codigo_barra` AS 'codigo',   `p`.`descripcion_breve` AS 'descripcion',  `vd`.`peso`,   `vd`.`monto`, `v`.`monto_total` FROM(((`venta` v JOIN `ventadetalle` vd ON((`v`.`id` = `vd`.`id_venta`)))     JOIN `producto` p ON((`vd`.`id_producto` = `p`.`id`)))  JOIN `operacion` o ON((`v`.`id_operacion` = `o`.`id`))) where v.id =( SELECT  `v`.`id` AS id_ultima_venta FROM  (((`venta` v JOIN `ventadetalle` vd ON((`v`.`id` = `vd`.`id_venta`)))     JOIN `producto` p ON((`vd`.`id_producto` = `p`.`id`)))  JOIN `operacion` o ON((`v`.`id_operacion` = `o`.`id`))) where o.id_cliente = 42 order by v.id desc limit 1) ;

-- ----------------------------
-- View structure for vistaventa
-- ----------------------------
DROP VIEW IF EXISTS `vistaventa`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `vistaventa` AS SELECT
  `v`.`id`,
  `v`.`id_operacion`,
  `p`.`id_codigo_barra` AS 'codigo',
  `p`.`descripcion_breve` AS 'descripcion',
  `vd`.`peso`,
  `vd`.`monto`,
  `v`.`monto_total`
FROM
  (((`venta` v
    JOIN `ventadetalle` vd ON ((`v`.`id` = `vd`.`id_venta`)))
    JOIN `producto` p ON ((`vd`.`id_producto` = `p`.`id`)))
    JOIN `operacion` o ON ((`v`.`id_operacion` = `o`.`id`)))
WHERE
  (`v`.`id` = 16) ;

-- ----------------------------
-- View structure for vistaventaseleccionada
-- ----------------------------
DROP VIEW IF EXISTS `vistaventaseleccionada`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `vistaventaseleccionada` AS SELECT  `v`.`id`, `v`.`id_operacion`, o.id_cliente, `p`.`id_codigo_barra` AS 'codigo',  `p`.`descripcion_breve` AS 'descripcion', `vd`.`peso`,  `vd`.`monto`,  `v`.`monto_total` FROM(((`venta` v JOIN `ventadetalle` vd ON((`v`.`id` = `vd`.`id_venta`)))    JOIN `producto` p ON((`vd`.`id_producto` = `p`.`id`)))  JOIN `operacion` o ON((`v`.`id_operacion` = `o`.`id`))) where v.id = 15 ;

-- ----------------------------
-- View structure for vistaventasumatotal
-- ----------------------------
DROP VIEW IF EXISTS `vistaventasumatotal`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost`  VIEW `vistaventasumatotal` AS select vsc.id, vvs.monto_total + vsc.saldo as total
from vistaventaseleccionada vvs
inner join vistasaldocliente vsc on vvs.id_cliente = vsc.id ;

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
cc.nro_cuenta,
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
SELECT cm.id, cm.id_operacion,  gc.id,gc.id_cliente,cm.id_cuenta, cm.id_movimiento_tipo, mt.descripcion, 

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
cuenta.nro_cuenta, 
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
banco.descripcion as Banco, 
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
