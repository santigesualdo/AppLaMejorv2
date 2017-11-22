/*
MySQL Backup
Source Server Version: 5.6.28
Source Database: u570713702_jjdev
Date: 22/11/2017 14:24:17
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
--  Table structure for `banco`
-- ----------------------------
DROP TABLE IF EXISTS `banco`;
CREATE TABLE `banco` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `cliente`
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
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `clientecuenta`
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
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `clientecuentamovimiento`
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
) ENGINE=InnoDB AUTO_INCREMENT=71 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `clientetipo`
-- ----------------------------
DROP TABLE IF EXISTS `clientetipo`;
CREATE TABLE `clientetipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `compra`
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
--  Table structure for `compradetalle`
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
--  Table structure for `compraestado`
-- ----------------------------
DROP TABLE IF EXISTS `compraestado`;
CREATE TABLE `compraestado` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `cuenta`
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
--  Table structure for `cuentamovimiento`
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
--  Table structure for `cuentamovimientoproveedor`
-- ----------------------------
DROP TABLE IF EXISTS `cuentamovimientoproveedor`;
CREATE TABLE `cuentamovimientoproveedor` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `vob` char(1) NOT NULL COMMENT '(V)arias o (B)ancarias',
  `id_cliente_cuenta` int(11) NOT NULL,
  `id_movimiento_tipo` int(11) NOT NULL COMMENT '1 - DEBE| 2 - HABER',
  `monto` double NOT NULL,
  `fecha` datetime NOT NULL,
  `cobrado` char(1) NOT NULL DEFAULT 'N',
  `usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_movtipo` (`id_movimiento_tipo`),
  CONSTRAINT `cuentamovimientoproveedor_ibfk_2` FOREIGN KEY (`id_movimiento_tipo`) REFERENCES `movimientotipo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `cuentaproveedor`
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
--  Table structure for `garron`
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
--  Table structure for `garrondeposteparcial`
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
--  Table structure for `garronestado`
-- ----------------------------
DROP TABLE IF EXISTS `garronestado`;
CREATE TABLE `garronestado` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `garronproductodef`
-- ----------------------------
DROP TABLE IF EXISTS `garronproductodef`;
CREATE TABLE `garronproductodef` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_tipo_garron` int(11) NOT NULL,
  `id_producto` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `garrontipo`
-- ----------------------------
DROP TABLE IF EXISTS `garrontipo`;
CREATE TABLE `garrontipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `gestorcuentas`
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
--  Table structure for `medida`
-- ----------------------------
DROP TABLE IF EXISTS `medida`;
CREATE TABLE `medida` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `modulo`
-- ----------------------------
DROP TABLE IF EXISTS `modulo`;
CREATE TABLE `modulo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `movimientotipo`
-- ----------------------------
DROP TABLE IF EXISTS `movimientotipo`;
CREATE TABLE `movimientotipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `precio`
-- ----------------------------
DROP TABLE IF EXISTS `precio`;
CREATE TABLE `precio` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_tipo_precio` int(11) NOT NULL,
  `monto` double NOT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_tipo_pre` (`id_tipo_precio`),
  CONSTRAINT `fk_tipo_pre` FOREIGN KEY (`id_tipo_precio`) REFERENCES `preciotipo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `preciotipo`
-- ----------------------------
DROP TABLE IF EXISTS `preciotipo`;
CREATE TABLE `preciotipo` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `producto`
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
--  Table structure for `productoestado`
-- ----------------------------
DROP TABLE IF EXISTS `productoestado`;
CREATE TABLE `productoestado` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `productoestadotipo`
-- ----------------------------
DROP TABLE IF EXISTS `productoestadotipo`;
CREATE TABLE `productoestadotipo` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `productotipo`
-- ----------------------------
DROP TABLE IF EXISTS `productotipo`;
CREATE TABLE `productotipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `productoubicacion`
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
--  Table structure for `proveedor`
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `proveedorcuenta`
-- ----------------------------
DROP TABLE IF EXISTS `proveedorcuenta`;
CREATE TABLE `proveedorcuenta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cbu` varchar(40) NOT NULL,
  `nro_cuenta` varchar(50) NOT NULL,
  `id_proveedor` int(11) DEFAULT NULL,
  `fecha_updated` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `id_banco` int(11) DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `proveedorcuentamovimiento`
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
--  Table structure for `proveedores_eliminar_esta_tabla`
-- ----------------------------
DROP TABLE IF EXISTS `proveedores_eliminar_esta_tabla`;
CREATE TABLE `proveedores_eliminar_esta_tabla` (
  `id` int(11) NOT NULL,
  `razon_social` varchar(50) NOT NULL,
  `cuit` varchar(12) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `direccion_adjunto` varchar(50) DEFAULT NULL,
  `telefono` varchar(50) NOT NULL,
  `nombre_persona_contacto` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `proveedortipo`
-- ----------------------------
DROP TABLE IF EXISTS `proveedortipo`;
CREATE TABLE `proveedortipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `ubicacion`
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
--  Table structure for `ubicaciontipo`
-- ----------------------------
DROP TABLE IF EXISTS `ubicaciontipo`;
CREATE TABLE `ubicaciontipo` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `usuario`
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
--  Table structure for `usuarioingreso`
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
--  Table structure for `usuariomodulo`
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
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;

-- ----------------------------
--  Table structure for `venta`
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
--  Table structure for `ventadetalle`
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
--  Procedure definition for `ActualizarCliente`
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
--  Procedure definition for `actualizarProveedor`
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
--  Procedure definition for `borrarProveedor`
-- ----------------------------
DROP PROCEDURE IF EXISTS `borrarProveedor`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `borrarProveedor`(id_ int, fecha_ date)
update proveedor set fecha_baja = fecha_ where id = id_
;;
DELIMITER ;

-- ----------------------------
--  Procedure definition for `grabarNuevoCliente`
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
--  Procedure definition for `grabarNuevoProveedor`
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
--  Procedure definition for `listarClienteCuentaConSaldo`
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
--  Procedure definition for `listarCuentasByIdCliente`
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
--  Procedure definition for `listarMovimientoTipo`
-- ----------------------------
DROP PROCEDURE IF EXISTS `listarMovimientoTipo`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarMovimientoTipo`()
select * from movimientotipo order by id
;;
DELIMITER ;

-- ----------------------------
--  Procedure definition for `listarTipoCliente`
-- ----------------------------
DROP PROCEDURE IF EXISTS `listarTipoCliente`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarTipoCliente`()
select * from clientetipo order by id
;;
DELIMITER ;

-- ----------------------------
--  Procedure definition for `listarTipoProducto`
-- ----------------------------
DROP PROCEDURE IF EXISTS `listarTipoProducto`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `listarTipoProducto`()
select * from productotipo order by id
;;
DELIMITER ;

-- ----------------------------
--  Procedure definition for `obtenerClienteConCuentasPorIdCliente`
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
--  Procedure definition for `obtenerClientes`
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerClientes`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClientes`()
SELECT * FROM cliente ORDER BY razon_social
;;
DELIMITER ;

-- ----------------------------
--  Procedure definition for `obtenerClientesData`
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
--  Procedure definition for `obtenerClientesPorId`
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerClientesPorId`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClientesPorId`(id_ int)
SELECT * FROM cliente  WHERE id = id_ ORDER BY razon_social
;;
DELIMITER ;

-- ----------------------------
--  Procedure definition for `obtenerMovCuentasClientes`
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
--  Procedure definition for `obtenerProveedores`
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerProveedores`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedores`()
SELECT * FROM proveedor ORDER BY razon_social
;;
DELIMITER ;

-- ----------------------------
--  Procedure definition for `obtenerProveedoresData`
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
--  Procedure definition for `obtenerProveedoresPorId`
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerProveedoresPorId`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedoresPorId`(id_ int)
SELECT * FROM proveedor WHERE id = id_ ORDER BY razon_social
;;
DELIMITER ;

-- ----------------------------
--  Procedure definition for `obtenerProveedoresSaldoActual`
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
--  Procedure definition for `obtenerProveedorPorNombre`
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
--  Procedure definition for `obtenerTipoClientePorIdCliente`
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerTipoClientePorIdCliente`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerTipoClientePorIdCliente`(id_ int)
select id_tipo_cliente from cliente where id = id_
;;
DELIMITER ;

-- ----------------------------
--  Procedure definition for `obtenerTipoProdutoPorIdProducto`
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerTipoProdutoPorIdProducto`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerTipoProdutoPorIdProducto`(id_ int)
select id_producto_tipo from producto where id = id_
;;
DELIMITER ;

-- ----------------------------
--  Procedure definition for `obtenerUsuarioPorNombre`
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerUsuarioPorNombre`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerUsuarioPorNombre`(name_ VARCHAR(20))
select * from usuario where username like name_
;;
DELIMITER ;

-- ----------------------------
--  Procedure definition for `obtenerUsuariosModulos`
-- ----------------------------
DROP PROCEDURE IF EXISTS `obtenerUsuariosModulos`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerUsuariosModulos`(id_ int)
SELECT m.* FROM usuariomodulo um inner join modulo m on m.id = um.id_modulo where um.id_usuario = id_
;;
DELIMITER ;

-- ----------------------------
--  Records 
-- ----------------------------
INSERT INTO `banco` VALUES ('1','Macro'), ('2','Santander'), ('3','Santa Fe'), ('4','Nación');
INSERT INTO `cliente` VALUES ('1','111','WTF','asd','asd','asd','1','asd','asd','asd','asd','2017-09-05',NULL,'1'), ('2','nke','Juanjo','j de la rosa 1252','santa fe','CF','2','DESAROLLO SANTA','2','1','3','2017-09-05',NULL,'1'), ('3','kkk','A.D.U.L.','Pje. Martinez 26661','Santa Fe','CF','4','defaultLocal','30-55597562-3','4553992','NombreResponsable','2017-09-05',NULL,'1'), ('4','114','A.N.S.E.S.','SAN MARTIN N 2533','Santa Fe','CF','1','defaultLocal','33-63761744-9','4156256','NombreResponsable','2017-09-05',NULL,'1'), ('5','115','A.PE.L - Asoc.Pers.Legislativo','San Jeronimo N  1.791','Santa Fe','CF','1','defaultLocal','30-64955281-5','4598277','NombreResponsable','2017-09-05',NULL,'1'), ('6','116','ACANTILADOS S.A. (VALMOTORS)','SAN LUIS N 3102','Santa Fe','CF','1','defaultLocal','30-70941478-6','4530606','NombreResponsable','2017-09-06',NULL,'1'), ('7','117','ACOSTA MARTIN SEBASTIAN','Pje. E.del Crespo N 7103/Berutti 5725','Santa Fe','CF','2','defaultLocal','30-64955281-5','4530606','NombreResponsable','2017-09-06',NULL,'1'), ('8','118','AdministraciÂ¢n Provincial de Impuestos-A.P.I','AVDA.PTE.ILLIA NÂ§ 1.151','Santa Fe','CF','2','defaultLocal','30-65520017-3','4557996','NombreResponsable','2017-09-06',NULL,'0'), ('9','119','Agencia Provincial de Seguridad Vial','25 DE MAYO N  2.208','Santa Fe','CF','1','defaultLocal','30-99901844-7','4574822','NombreResponsable','2017-09-06',NULL,'1'), ('10','120','AGOSTINI OSVALDO OMAR','AVDA. GORRITI N 3014','Santa Fe','CF','2','defaultLocal','20-05261057-6','4695406','NombreResponsable','2017-09-06','2001-01-01 00:00:00','1'), ('11','121','AICACYP-Ente Cooperador Ley 23.979','Moreno N 1420  (p/Facturar)','Santa Fe','CF','2','defaultLocal','30-55597562-3','4574822','NombreResponsable','2017-09-07',NULL,'1'), ('12','122','AICACYP-Ente Cooperador Ley 23.979','RENAR: Francia N 3550 - Santa Fe','Santa Fe','CF','2','defaultLocal','011-4384-7900','4557996','NombreResponsable','2017-09-07',NULL,'1'), ('13','123','ALBERTO J. MACUA S.A.','LOPEZ Y PLANES N 4250','Santa Fe','CF','2','defaultLocal','30-60541628-0','4555070','NombreResponsable','2017-09-07','2001-01-01 00:00:00','1'), ('14','124','ALMEIDA JUAN CARLOS F.','RUPERTO PEREZ 1944','Santa Fe','CF','2','defaultLocal','24-06218372-8','4553228','NombreResponsable','2017-09-07',NULL,'1'), ('15','125','ALONSO EDGARDO JAVIER','SAN MARTÃ–N N 3364-Piso 10-Dpto B','Santa Fe','CF','2','defaultLocal','20-13925831-3','4585068','NombreResponsable','2017-09-07',NULL,'1'), ('16','126','ALONSO  GRACIELA CRISTINA','MARTIN ZAPATA 3870','Santa Fe','CF','2','defaultLocal','27-13163585-6','4537003','NombreResponsable','2017-09-07','2001-01-01 00:00:00','1'), ('17','127','ALLOATTI ROBERTO','SAN MARTIN N 2088','Santa Fe','CF','2','defaultLocal','30-60541628-0','4537003','NombreResponsable','2017-09-07',NULL,'1'), ('18','128','AMATTI  CLAUDIO','SAN MARTIN N 2088','Santa Fe','CF','3','defaultLocal','30-60541628-0','4537003','NombreResponsable','2017-09-10',NULL,'1'), ('19','129','AMRAD S. H. de Liponezky Virginia  Victor y Santiago ','Salvador del Carril N 968','Santa Fe','CF','3','defaultLocal','30-71120617-1','4537003','NombreResponsable','2017-09-10',NULL,'1'), ('20','130','ANGEL BOSCARINO Construcciones S.A.','MARCIAL CANDIOTI  N 5180','Santa Fe','CF','3','defaultLocal','30-60541628-0','4538585','NombreResponsable','2017-09-10',NULL,'1'), ('21','131','ANSKOHL  RICARDO','E. ZEBALLOS 4334','Santa Fe','CF','3','defaultLocal','20-06264349-9','4537003','NombreResponsable','2017-09-10',NULL,'1'), ('22','132','ANTONIAZZI HNOS.','PIETRANERA n 3350','Santa Fe','CF','4','defaultLocal','30-55418898-9','4592295','NombreResponsable','2017-09-10',NULL,'1'), ('23','133','ANTONIAZZI  GERMAN','RIVADAVIA N 3396','Santa Fe','CF','4','defaultLocal','20-26460065-1','4500162','NombreResponsable','2017-09-10',NULL,'1'), ('24','134','ARCINI MARTÃ–N','9 DE JULIO N 2722','Santa Fe','CF','4','defaultLocal','20-06264349-9','4537003','NombreResponsable','2017-09-10',NULL,'1'), ('25','135','ARCOLEN S.A.','SUIPACHA 2695','Santa Fe','CF','4','defaultLocal','30-64385640-5','4561538','NombreResponsable','2017-09-10',NULL,'1'), ('26','136','Cliente 1','La Rioja 2081','Santa Fe','CF','1','asd','203295621342','asd','sd','2017-11-09',NULL,'0'), ('27','aaa','aaa','aaa','aaa','aaa','2','aaa','aaa','aaa','aaa','2017-11-22',NULL,'1'), ('28','aab','bbb','bbb','bbb','bbb','1','bbb','bbb','bbb','bbb','2017-11-22',NULL,'1');
INSERT INTO `clientecuenta` VALUES ('1','1238238923892234','12-1238238923892234','1','2017-11-06 21:07:59','1',NULL,'1'), ('2','1238238923892236','12-1238238923893434','2','2017-11-06 21:08:00','1',NULL,'1'), ('3','2222','22222','1','2017-11-06 21:08:00','0',NULL,'2'), ('4','aaa','12312','6','2017-11-06 21:08:01','0',NULL,'3'), ('5','11111111','11111111','17','2017-11-06 21:08:02','0',NULL,'4'), ('6','22222','22222','2','2017-11-06 21:08:03','0',NULL,'1'), ('7','4444','4444','2','2017-11-08 22:04:46','0',NULL,'2'), ('8','555','555','3','2017-11-06 21:08:03','0',NULL,'3'), ('9','123','','14','2017-11-06 21:08:04','0',NULL,'4'), ('10','11','11','25','2017-11-06 21:08:05','0',NULL,'1'), ('11','14524521452','14552/142','22','2017-11-15 23:45:05','0',NULL,NULL), ('12','1233213','333112','1','2017-11-15 23:47:45','0',NULL,NULL), ('13','aaa122','123123','26','2017-11-16 00:15:28','0',NULL,NULL), ('14','aa','22','4','2017-11-16 00:17:29','0',NULL,NULL), ('15','142541232','21452','4','2017-11-16 00:43:22','0',NULL,NULL), ('16','0316541561','13216546','4','2017-11-16 00:50:54','0',NULL,'2'), ('17','13213','1231','22','2017-11-16 00:53:54','0',NULL,'2'), ('18','132132','0321132','22','2017-11-16 16:36:07','0',NULL,'1'), ('19','13513','132132','26','2017-11-16 16:36:47','0',NULL,'1');
INSERT INTO `clientecuentamovimiento` VALUES ('1','1','1','1','500.5','2017-09-14 14:22:14','N','1'), ('2','1','1','1','352.8','2017-09-14 09:21:22','N','1'), ('4','1','2','1','100.1','2017-09-14 10:00:00','N','1'), ('5','1','1','2','400.9','2017-09-14 11:00:00','N','1'), ('6','1','1','2','33.3','2017-09-14 11:00:00','N','1'), ('7','1','1','2','33','2017-09-14 14:13:51','N','1'), ('8','1','1','2','100','2017-09-15 10:49:46','N','1'), ('9','1','1','2','6','2017-09-15 11:00:48','N','1'), ('10','1','1','2','80','2017-09-15 11:08:10','N','1'), ('11','1','1','2','2','2017-09-15 11:09:48','N','1'), ('12','1','1','2','1','2017-09-15 11:11:44','N','1'), ('13','1','1','2','7','2017-09-15 11:17:03','N','1'), ('14','1','1','2','10','2017-09-15 11:24:58','N','1'), ('15','1','1','2','11','2017-09-17 09:23:38','N','1'), ('16','1','1','2','77','2017-09-17 09:48:18','N','1'), ('19','1','1','1','7','0000-00-00 00:00:00','N','1'), ('20','1','1','1','1','2017-09-22 16:02:29','N','1'), ('21','1','1','1','20','2017-09-22 23:05:13','N','1'), ('22','1','2','1','7','2017-09-24 13:41:55','N','1'), ('23','1','2','1','5','2017-09-25 23:39:50','N','1'), ('24','1','2','1','4','2017-09-25 23:41:08','N','1'), ('25','1','2','1','3','2017-09-25 23:42:01','N','1'), ('26','1','2','1','30','2017-09-26 00:07:36','N','1'), ('27','1','2','1','5','2017-09-26 00:43:20','N','1'), ('28','1','2','1','2','2017-09-26 00:46:07','N','1'), ('29','1','2','1','2','2017-09-26 00:47:22','N','1'), ('30','1','2','1','2','2017-09-26 00:47:51','N','1'), ('31','1','2','2','100','2017-09-26 00:51:52','N','1'), ('33','1','2','1','4','2017-09-26 01:03:42','N','1'), ('34','1','2','1','150','2017-09-26 01:04:31','N','1'), ('35','1','2','2','133','2017-09-26 01:05:03','N','1'), ('36','1','2','1','10','2017-09-26 01:17:31','N','1'), ('37','1','2','1','11','2017-09-26 01:40:33','N','1'), ('38','1','2','1','5','2017-09-26 11:41:52','N','1'), ('39','1','2','1','339','2017-09-27 15:33:55','N','1'), ('40','1','2','2','61','2017-09-27 15:34:36','N','1'), ('41','1','2','1','3851','2017-09-27 15:35:03','N','1'), ('42','1','2','1','4236','2017-09-27 15:35:26','N','1'), ('43','1','2','2','847210','2017-09-27 15:36:08','N','1'), ('44','1','2','1','900000','2017-09-27 15:37:44','N','1'), ('45','1','2','2','60000','2017-09-27 15:38:43','N','1'), ('46','1','2','1','200','2017-09-28 14:44:57','N','1'), ('47','1','2','1','6210','2017-09-28 14:45:16','N','1'), ('48','1','2','1','12','2017-09-28 14:57:41','N','1'), ('49','1','2','1','4.9','2017-09-28 15:00:47','N','1'), ('50','1','2','1','55.2','2017-09-28 15:02:56','N','1'), ('51','1','2','1','44.2','2017-09-28 15:15:16','N','1'), ('52','1','1','2','200','2017-09-28 15:19:54','N','1'), ('53','1','2','2','12','2017-09-29 11:10:03','N','1'), ('54','1','2','2','12','2017-09-29 11:13:38','N','1'), ('55','1','2','2','700','2017-09-29 13:55:11','N','1'), ('56','1','2','1','500','2017-10-02 01:08:47','N','0'), ('57','1','2','2','8000','2017-11-06 20:52:46','N','0'), ('58','1','7','1','1000','2017-11-08 22:04:46','N','0'), ('59','1','7','1','22','2017-11-10 17:44:56','N','0'), ('60','1','1','2','600','2017-11-10 18:24:57','N','0'), ('61','1','1','1','700','2017-11-10 19:55:10','N','0'), ('62','1','1','2','222','2017-11-10 19:56:19','N','0'), ('63','1','6','2','123','2017-11-10 20:02:10','N','0'), ('64','1','1','1','14785','2017-11-15 00:26:03','N','0'), ('65','1','7','1','1000','2017-11-15 10:18:40','N','0'), ('66','1','2','2','1000','2017-11-15 10:21:38','N','0'), ('67','1','2','2','500','2017-11-15 10:21:45','N','0'), ('68','1','1','1','1000','2017-11-16 00:54:50','N','1'), ('69','1','19','1','850','2017-11-16 16:37:28','N','1'), ('70','1','19','2','5555','2017-11-16 16:37:36','N','1');
INSERT INTO `clientetipo` VALUES ('1','Mayorista'), ('2','Minorista'), ('3','TipoCliente'), ('4','ClienteTipo');
INSERT INTO `cuenta` VALUES ('1','1238238923892234','1','12-1238238923892234','-200.85','1','2017-11-12 20:55:11','1',NULL), ('2','1238238923892236','1','12-1238238923893434','500.85','2','2017-11-12 20:55:12','1',NULL), ('3','2222','1','22222','252.52','1','2017-11-12 20:55:13','0',NULL), ('4','aaa','1','12312','123243.00','6','2017-11-12 20:55:18','0',NULL);
INSERT INTO `cuentamovimiento` VALUES ('1','1','1','1','500.5','2017-09-14 14:22:14','N','1'), ('2','1','1','1','352.8','2017-09-14 09:21:22','N','1'), ('4','1','2','1','100.1','2017-09-14 10:00:00','N','1'), ('5','1','1','2','400.9','2017-09-14 11:00:00','N','1'), ('6','1','1','2','33.3','2017-09-14 11:00:00','N','1'), ('7','1','1','2','33','2017-09-14 14:13:51','N','1'), ('8','1','1','2','100','2017-09-15 10:49:46','N','1'), ('9','1','1','2','6','2017-09-15 11:00:48','N','1'), ('10','1','1','2','80','2017-09-15 11:08:10','N','1'), ('11','1','1','2','2','2017-09-15 11:09:48','N','1'), ('12','1','1','2','1','2017-09-15 11:11:44','N','1'), ('13','1','1','2','7','2017-09-15 11:17:03','N','1'), ('14','1','1','2','10','2017-09-15 11:24:58','N','1'), ('15','1','1','2','11','2017-09-17 09:23:38','N','1'), ('16','1','1','2','77','2017-09-17 09:48:18','N','1'), ('19','1','1','1','7','0000-00-00 00:00:00','N','1'), ('20','1','1','1','1','2017-09-22 16:02:29','N','1'), ('21','1','1','1','20','2017-09-22 23:05:13','N','1'), ('22','1','2','1','7','2017-09-24 13:41:55','N','1'), ('23','1','2','1','5','2017-09-25 23:39:50','N','1'), ('24','1','2','1','4','2017-09-25 23:41:08','N','1'), ('25','1','2','1','3','2017-09-25 23:42:01','N','1'), ('26','1','2','1','30','2017-09-26 00:07:36','N','1'), ('27','1','2','1','5','2017-09-26 00:43:20','N','1'), ('28','1','2','1','2','2017-09-26 00:46:07','N','1'), ('29','1','2','1','2','2017-09-26 00:47:22','N','1'), ('30','1','2','1','2','2017-09-26 00:47:51','N','1'), ('31','1','2','2','100','2017-09-26 00:51:52','N','1'), ('33','1','2','1','4','2017-09-26 01:03:42','N','1'), ('34','1','2','1','150','2017-09-26 01:04:31','N','1'), ('35','1','2','2','133','2017-09-26 01:05:03','N','1'), ('36','1','2','1','10','2017-09-26 01:17:31','N','1'), ('37','1','2','1','11','2017-09-26 01:40:33','N','1'), ('38','1','2','1','5','2017-09-26 11:41:52','N','1'), ('39','1','2','1','339','2017-09-27 15:33:55','N','1'), ('40','1','2','2','61','2017-09-27 15:34:36','N','1'), ('41','1','2','1','3851','2017-09-27 15:35:03','N','1'), ('42','1','2','1','4236','2017-09-27 15:35:26','N','1'), ('43','1','2','2','847210','2017-09-27 15:36:08','N','1'), ('44','1','2','1','900000','2017-09-27 15:37:44','N','1'), ('45','1','2','2','60000','2017-09-27 15:38:43','N','1'), ('46','1','2','1','200','2017-09-28 14:44:57','N','1'), ('47','1','2','1','6210','2017-09-28 14:45:16','N','1'), ('48','1','2','1','12','2017-09-28 14:57:41','N','1'), ('49','1','2','1','4.9','2017-09-28 15:00:47','N','1'), ('50','1','2','1','55.2','2017-09-28 15:02:56','N','1'), ('51','1','2','1','44.2','2017-09-28 15:15:16','N','1'), ('52','1','1','2','200','2017-09-28 15:19:54','N','1'), ('53','1','2','2','12','2017-09-29 11:10:03','N','1'), ('54','1','2','2','12','2017-09-29 11:13:38','N','1'), ('55','1','2','2','700','2017-09-29 13:55:11','N','1'), ('56','1','2','1','500','2017-10-02 01:08:47','N','0'), ('57','1','3','1','1500','2017-11-12 20:55:47','N','1'), ('58','1','1','1','100','2017-11-12 20:56:26','N','1');
INSERT INTO `cuentaproveedor` VALUES ('1','1238238923892234','12-1238238923892234','-200.85','1','2017-09-30 14:54:58','1',NULL), ('2','1238238923892236','12-1238238923893434','500.85','2','2017-09-30 14:54:58','1',NULL), ('3','2222','22222','252.52','1','2017-10-24 20:52:55','0',NULL), ('4','aaa','12312','123243.00','6','2017-10-24 20:55:13','0',NULL);
INSERT INTO `garron` VALUES ('1','230','1','1','2017-11-04 20:08:45','75.421','10','1',NULL), ('2','231','1','2','2017-11-04 20:08:45','76.496','10','1',NULL), ('3','254','4','1','2017-11-17 00:00:00','75.854','11','1',NULL), ('4','745','1','1','2017-11-04 00:00:00','78.520','11','1',NULL), ('5','123','1','1','2017-11-04 00:00:00','78.245','11','1',NULL), ('6','66','1','1','2017-11-04 00:00:00','98.245','11','1',NULL), ('7','542','1','1','2017-11-04 00:00:00','65.250','11','1',NULL), ('8','321','1','1','2017-11-04 00:00:00','88.250','11','1',NULL), ('9','11','1','1','2017-11-04 00:00:00','98.250','11','1',NULL), ('10','111','1','1','2017-11-04 00:00:00','78.525','11','1',NULL), ('11','652','1','1','2017-11-04 00:00:00','88.000','12','1',NULL), ('12','111','1','1','2017-11-04 00:00:00','11.000','11','1',NULL), ('13','425','1','1','2017-11-06 00:00:00','142.250','11','1',NULL), ('14','458','1','1','2017-11-06 00:00:00','14.256','11','1',NULL);
INSERT INTO `garrondeposteparcial` VALUES ('1','2','6','10.256'), ('2','2','7','18.620'), ('3','2','8','20.680');
INSERT INTO `garronestado` VALUES ('1','COMPLETO'), ('2','DEPOSTE PARCIAL'), ('3','DEPOSTADO');
INSERT INTO `garronproductodef` VALUES ('2','1','6'), ('3','1','7'), ('4','1','8'), ('5','1','9'), ('6','1','10'), ('7','1','11'), ('8','1','12'), ('9','1','13'), ('10','1','14'), ('11','1','15'), ('12','1','16'), ('13','1','17'), ('14','1','18'), ('15','1','19'), ('16','2','6'), ('17','2','7'), ('18','2','8'), ('19','2','9'), ('20','2','10'), ('21','2','11'), ('22','2','12'), ('23','2','13'), ('24','2','14'), ('25','2','15'), ('26','2','16'), ('27','2','17'), ('28','2','18'), ('29','2','19'), ('30','3','6'), ('31','3','7'), ('32','3','8'), ('33','3','9'), ('34','3','10'), ('35','3','11'), ('36','3','12'), ('37','3','13'), ('38','3','14'), ('39','3','15');
INSERT INTO `garrontipo` VALUES ('1','TERNERA'), ('2','NOVILLITO'), ('3','NOVILLO'), ('4','VAQUILLONA'), ('5','VACA'), ('6','TORO');
INSERT INTO `gestorcuentas` VALUES ('1','1','1',NULL,NULL,NULL), ('2','2',NULL,'1',NULL,NULL);
INSERT INTO `medida` VALUES ('1','cm'), ('2','kg'), ('3','lts');
INSERT INTO `modulo` VALUES ('1','Clientes'), ('2','Proveedores'), ('3','Stock'), ('4','Caja'), ('5','Ventas'), ('6','Compras'), ('7','Movimiento Cuentas'), ('8','Gestion Usuarios'), ('9','Productos'), ('10','Ventas Caja'), ('11','Movimiento Cuentas Proveedores'), ('12','Carga Garron');
INSERT INTO `movimientotipo` VALUES ('1','DEBE'), ('2','PAGO');
INSERT INTO `precio` VALUES ('1','1','145',NULL,NULL), ('2','1','500',NULL,NULL), ('3','1','425',NULL,NULL);
INSERT INTO `preciotipo` VALUES ('1','por kg'), ('2','por unidad');
INSERT INTO `producto` VALUES ('5','1','010990','115.000','1.00','CHORIZO ESPECIAL','CHORIZO ESPECIAL','0',NULL), ('6','1','011000','85.000','1.00','CHORIZO PARRILLERO','CHORIZO PARRILLERO','0',NULL), ('7','1','011010','0.000','1.00','CHORIZO DE CERDO','CHORIZO DE CERDO','0',NULL), ('8','1','011020','115.000','1.00','CHORIZO COLORADO','CHORIZO COLORADO','0',NULL), ('9','1','011030','98.000','1.00','SALCHICHA PARRILLERA','SALCHICHA PARRILLERA','0',NULL), ('10','1','011040','90.000','1.00','MORCILLA','MORCILLA','0',NULL), ('11','1','011050','90.000','1.00','MORCILLA','MORCILLA BOMBON','0',NULL), ('12','1','011060','90.000','1.00','SALCHICHAS SNACK','SALCHICHAS SNACK','0',NULL), ('13','1','011070','80.000','1.00','PATE','PATE','0',NULL), ('14','1','011080','80.000','1.00','QUESO DE CERDO','QUESO DE CERDO','0',NULL), ('15','1','011100','90.000','1.00','PICADA COMUN','PICADA COMUN','0',NULL), ('16','1','011110','100.000','1.00','PICADA INTERMEDIA','PICADA INTERMEDIA','0',NULL), ('17','1','011120','135.000','1.00','PICADA ESPECIAL','PICADA ESPECIAL','0',NULL), ('18','1','011130','50.000','1.00','PUCHERO COMUN','PUCHERO COMUN','0',NULL), ('19','1','011140','89.000','1.00','PUCHERO ESPECIAL','PUCHERO ESPECIAL','0',NULL), ('20','1','011150','10.000','1.00','CANINO','CANINO','0',NULL), ('21','1','011160','145.000','1.00','MATAMBRE','MATAMBRE','0',NULL), ('22','1','011170','140.000','1.00','VACIO','VACIO','0',NULL), ('23','1','011180','135.000','1.00','ALA DE PECHO','ALA DE PECHO','0',NULL), ('24','1','011190','140.000','1.00','COSTILLA','COSTILLA','0',NULL), ('25','1','011200','125.000','1.00','MARUCHA','MARUCHA','0',NULL), ('26','1','011210','135.000','1.00','TAPA DE NALGA','TAPA DE NALGA','0',NULL), ('27','1','011220','160.000','1.00','CORTE MALVINA','CORTE MALVINA','0',NULL), ('28','1','011230','92.000','1.00','FALDA','FALDA','0',NULL), ('29','1','011240','125.000','1.00','COSTELETAS','COSTELETAS','0',NULL), ('30','1','011250','99.000','1.00','AGUJA','AGUJA','0',NULL), ('31','1','011260','125.000','1.00','BRAZUELO','BRAZUELO','0',NULL), ('32','1','011270','170.000','1.00','BIFE ANCHO/ANGOSTO','BIFE ANCHO/ANGOSTO','0',NULL), ('33','1','011280','170.000','1.00','ENTRECOT','ENTRECOT','0',NULL), ('34','1','011290','180.000','1.00','ROAST BEEF','ROAST BEEF','0',NULL), ('35','1','011300','145.000','1.00','NALGAS','NALGAS','0',NULL), ('36','1','011310','180.000','1.00','LOMO','LOMO','0',NULL), ('37','1','011320','145.000','1.00','PECETO','PECETO','0',NULL), ('38','1','011330','145.000','1.00','CUADRIL','CUADRIL','0',NULL), ('39','1','011340','145.000','1.00','PALOMITA','PALOMITA','0',NULL), ('40','1','011350','145.000','1.00','JAMON CUADRADO','JAMON CUADRADO','0',NULL), ('41','1','011360','140.000','1.00','CABEZA DE LOMO','CABEZA DE LOMO','0',NULL), ('42','1','011370','140.000','1.00','PULPA BRAZUELO','PULPA BRAZUELO','0',NULL), ('43','1','011380','135.000','1.00','PULPA PALETA','PULPA PALETA','0',NULL), ('44','1','011390','140.000','1.00','TORTUGUITA','TORTUGUITA','0',NULL), ('45','1','011400','120.000','1.00','MILANESAS DE CARNE','MILANESAS DE CARNE','0',NULL), ('46','1','011410','89.000','1.00','MILANESAS DE POLLO','MILANESAS DE POLLO','0',NULL), ('47','1','011420','99.000','1.00','HAMBURGUESAS','HAMBURGUESAS','0',NULL), ('48','1','011430','99.000','1.00','ALBONDIGAS','ALBONDIGAS','0',NULL), ('49','1','011440','0.000','1.00','COSTELETAS','COSTELETAS','0',NULL), ('50','1','011450','0.000','1.00','BONDIOLA','BONDIOLA','0',NULL), ('51','1','011460','0.000','1.00','MATAMBRITO','MATAMBRITO','0',NULL), ('52','1','011470','0.000','1.00','COSTILLA/PECHITO','COSTILLA/PECHITO','0',NULL), ('53','1','011480','0.000','1.00','PULPAS','PULPAS','0',NULL), ('54','1','011490','0.000','1.00','MARUCHA','MARUCHA','0',NULL), ('55','1','011500','0.000','1.00','CARACU','CARACU','0',NULL), ('56','1','011510','0.000','1.00','PATITAS/HUESITOS/CUERITO','PATITAS/HUESITOS/CUERITO','0',NULL), ('57','1','011520','0.000','1.00','MILANESAS','MILANESAS','0',NULL), ('58','1','011530','0.000','1.00','HAMBURGUESAS','HAMBURGUESAS','0',NULL), ('59','1','011540','0.000','1.00','PATAMUSLO','PATAMUSLO','0',NULL), ('60','1','011550','0.000','1.00','TROZADO','TROZADO','0',NULL), ('61','1','011560','0.000','1.00','PECHUGA','PECHUGA','0',NULL), ('62','1','011570','0.000','1.00','FILET','FILET','0',NULL), ('63','1','011580','0.000','1.00','BROCHET','BROCHET','0',NULL), ('64','1','011590','0.000','1.00','BONDIOLA','BONDIOLA','0',NULL), ('65','1','011600','0.000','1.00','PALETA','PALETA','0',NULL), ('66','1','011610','0.000','1.00','JAMON COCIDO','JAMON COCIDO','0',NULL), ('67','1','011620','0.000','1.00','JAMON CRUDO','JAMON CRUDO','0',NULL), ('68','1','011630','0.000','1.00','SALAME MILAN','SALAME MILAN','0',NULL), ('69','1','011640','0.000','1.00','SALAMIN','SALAMIN','0',NULL), ('70','1','011650','0.000','1.00','QUESO BARRA','QUESO BARRA','0',NULL), ('71','1','011660','0.000','1.00','CREMOSO','CREMOSO','0',NULL), ('72','1','011670','0.000','1.00','CASCARA COLORADA','CASCARA COLORADA','0',NULL), ('73','1','011680','0.000','1.00','QUESO CRE','QUESO CREMOSO','0',NULL), ('74','1','011690','0.000','1.00','QUESO TREEMBLAY','QUESO TREEMBLAY','0',NULL), ('75','1','011700','0.000','1.00','QUESO PROVOLETA','QUESO PROVOLETA','0',NULL), ('76','1','011710','0.000','1.00','QUESO SARDO','QUESO SARDO','0',NULL), ('77','1','011720','0.000','1.00','MORTADELA','MORTADELA','0',NULL), ('78','1','011730','0.000','1.00','MORTADELA','MORTADELA','0',NULL);
INSERT INTO `productoestado` VALUES ('1','CONGELADO'), ('2','NORMAL');
INSERT INTO `productoestadotipo` VALUES ('1','CONGELADO'), ('2','NORMAL');
INSERT INTO `productotipo` VALUES ('1','CARNE'), ('2','EMBUTIDO'), ('3','ALGO');
INSERT INTO `proveedor` VALUES ('1','Friar','santiago del estero 1234','santa fe','RI','Friar S.A.','20-12345678-1','034212345678','Federico Lopez','2017-11-16',NULL,NULL), ('2','Frigar','urquiza 1810','santa fe','CF','LOCAL','20315634231','3239487','HUGO','2017-11-17',NULL,'0'), ('3','este proveedor','provsad','prov','poa','orpo','ops','por','poasdp','2017-11-24',NULL,'0');
INSERT INTO `proveedorcuenta` VALUES ('1','1238238923892234','12-1238238923892234','1','2017-11-12 19:53:42','1','1',NULL), ('2','1238238923892236','12-1238238923893434','2','2017-11-12 19:53:39','2','1',NULL), ('3','2222','22222','1','2017-11-12 19:53:29','4','0',NULL), ('4','aaa','12312','6','2017-11-12 19:53:32','3','0',NULL), ('5','52145312','2312156432','0','2017-11-16 17:36:32',NULL,'0',NULL), ('6','12313','123123','0','2017-11-16 17:51:57',NULL,'0',NULL);
INSERT INTO `proveedorcuentamovimiento` VALUES ('1','1','1','1','600','2017-11-14 17:24:30','N','0'), ('2','1','1','2','600','2017-11-15 11:54:13','N','1'), ('3','1','3','1','500','2017-11-15 11:55:15','N','1'), ('4','1','3','2','1000','2017-11-15 12:00:06','N','1');
INSERT INTO `proveedores_eliminar_esta_tabla` VALUES ('1','DSA','DSA','DSA','DSA','DSA','DSA');
INSERT INTO `proveedortipo` VALUES ('1','Grande');
INSERT INTO `ubicacion` VALUES ('1','1','ALA ESTE',NULL,NULL), ('2','1','ALA OESTE',NULL,NULL), ('3','2','ALA SUROESTE',NULL,'2017-10-11 17:33:43');
INSERT INTO `ubicaciontipo` VALUES ('1','FRIGORIFICO'), ('2','DEPOSITO');
INSERT INTO `usuario` VALUES ('1','a','a','aa'), ('2','prueba','prueba','prueba');
INSERT INTO `usuarioingreso` VALUES ('1','1','2017-09-02','11:26:00');
INSERT INTO `usuariomodulo` VALUES ('1','1','1'), ('2','1','2'), ('3','1','3'), ('4','1','4'), ('5','1','7'), ('6','1','9'), ('7','1','10'), ('8','1','11'), ('15','2','12'), ('16','2','1'), ('17','2','2'), ('18','2','4'), ('19','2','9'), ('20','2','11'), ('21','2','12');
INSERT INTO `venta` VALUES ('1','1108.000','2017-10-23 20:04:26','0',NULL), ('2','1108.000','2017-10-23 20:07:48','0',NULL), ('3','1108.000','2017-10-23 20:08:00','0',NULL), ('4','1108.000','2017-10-23 20:18:15','0',NULL), ('5','1108.000','2017-10-23 20:20:11','0',NULL), ('6','1108.004','2017-10-23 20:22:11','0',NULL), ('7','1110.042','2017-10-24 19:45:11','0',NULL), ('8','1858.994','2017-10-24 20:10:55','0',NULL), ('9','630.780','2017-10-26 20:25:29','0',NULL), ('10','1261.560','2017-10-26 20:25:35','0',NULL), ('11','1787.210','2017-10-26 20:25:40','0',NULL), ('12','2069.254','2017-10-27 18:55:55','0',NULL), ('13','2307.482','2017-10-30 18:56:35','0',NULL), ('14','2152.872','2017-11-02 21:17:32','0',NULL), ('24','4493.712','2017-11-10 19:57:18','0',NULL), ('25','2495.296','2017-11-10 20:01:24','0',NULL), ('26','1658.880','2017-11-10 20:15:42','0',NULL), ('27','1871.472','2017-11-10 20:20:55','0',NULL), ('28','3086.878','2017-11-10 20:25:17','0',NULL), ('29','1244.160','2017-11-10 20:27:03','0',NULL), ('30','3744.760','2017-11-11 10:38:21','0',NULL);
INSERT INTO `ventadetalle` VALUES ('4','0','1','105.000','0.000','1',NULL), ('5','0','2','328.000','1.000','1',NULL), ('6','0','3','674.000','3.000','1',NULL), ('7','0','3','674.000','3.000','1',NULL), ('8','0','2','328.000','1.000','1',NULL), ('9','0','1','105.000','0.000','1',NULL), ('10','0','3','674.000','3.000','1',NULL), ('11','0','2','328.000','1.000','1',NULL), ('12','0','1','105.000','0.000','1',NULL), ('13','4','3','674.000','3.000','1',NULL), ('14','4','2','328.000','1.000','1',NULL), ('15','4','1','105.000','0.000','1',NULL), ('16','5','1','105.000','0.000','1',NULL), ('17','6','3','674.525','3.646','1',NULL), ('18','6','2','328.349','1.427','1',NULL), ('19','6','1','105.130','0.725','1',NULL), ('20','7','1','105.130','0.725','1',NULL), ('21','7','2','451.294','1.962','1',NULL), ('22','7','3','553.618','2.992','1',NULL), ('23','8','2','451.294','1.962','1',NULL), ('24','8','3','553.618','2.992','1',NULL), ('25','8','2','748.952','3.256','1',NULL), ('26','8','1','105.130','0.725','1',NULL), ('27','9','1','105.130','0.725','1',NULL), ('28','9','1','105.130','0.725','1',NULL), ('29','9','1','105.130','0.725','1',NULL), ('30','9','1','105.130','0.725','1',NULL), ('31','9','1','105.130','0.725','1',NULL), ('32','9','1','105.130','0.725','1',NULL), ('33','10','1','105.130','0.725','1',NULL), ('34','10','1','105.130','0.725','1',NULL), ('35','10','1','105.130','0.725','1',NULL), ('36','10','1','105.130','0.725','1',NULL), ('37','10','1','105.130','0.725','1',NULL), ('38','10','1','105.130','0.725','1',NULL), ('39','10','1','105.130','0.725','1',NULL), ('40','10','1','105.130','0.725','1',NULL), ('41','10','1','105.130','0.725','1',NULL), ('42','10','1','105.130','0.725','1',NULL), ('43','10','1','105.130','0.725','1',NULL), ('44','10','1','105.130','0.725','1',NULL), ('45','11','1','105.130','0.725','1',NULL), ('46','11','1','105.130','0.725','1',NULL), ('47','11','1','105.130','0.725','1',NULL), ('48','11','1','105.130','0.725','1',NULL), ('49','11','1','105.130','0.725','1',NULL), ('50','11','1','105.130','0.725','1',NULL), ('51','11','1','105.130','0.725','1',NULL), ('52','11','1','105.130','0.725','1',NULL), ('53','11','1','105.130','0.725','1',NULL), ('54','11','1','105.130','0.725','1',NULL), ('55','11','1','105.130','0.725','1',NULL), ('56','11','1','105.130','0.725','1',NULL), ('57','11','1','105.130','0.725','1',NULL), ('58','11','1','105.130','0.725','1',NULL), ('59','11','1','105.130','0.725','1',NULL), ('60','11','1','105.130','0.725','1',NULL), ('61','11','1','105.130','0.725','1',NULL), ('62','12','1','105.130','0.725','1',NULL), ('63','12','1','105.130','0.725','1',NULL), ('64','12','1','105.130','0.725','1',NULL), ('65','12','2','451.294','1.962','1',NULL), ('66','12','3','553.618','2.992','1',NULL), ('67','12','2','748.952','3.256','1',NULL), ('68','13','2','748.952','3.256','1',NULL), ('69','13','2','451.294','1.962','1',NULL), ('70','13','3','553.618','2.992','1',NULL), ('71','13','3','553.618','2.992','1',NULL), ('72','14','35','105.130','0.725','1',NULL), ('73','14','35','105.130','0.725','1',NULL), ('74','14','39','703.127','4.849','1',NULL), ('75','14','35','311.912','2.151','1',NULL), ('76','14','23','748.952','5.547','1',NULL), ('77','14','6','178.621','2.101','1',NULL), ('78','15','6','178.621','2.101','1',NULL), ('79','15','6','178.621','2.101','1',NULL), ('80','15','6','178.621','2.101','1',NULL), ('81','15','6','178.621','2.101','1',NULL), ('82','15','6','178.621','2.101','1',NULL), ('83','15','6','178.621','2.101','1',NULL), ('84','15','6','178.621','2.101','1',NULL), ('85','15','6','178.621','2.101','1',NULL), ('86','15','6','178.621','2.101','1',NULL), ('87','15','6','178.621','2.101','1',NULL), ('88','15','6','178.621','2.101','1',NULL), ('89','15','6','178.621','2.101','1',NULL), ('90','15','6','178.621','2.101','1',NULL), ('91','15','6','451.294','5.309','1',NULL), ('92','15','6','451.294','5.309','1',NULL), ('93','15','6','451.294','5.309','1',NULL), ('94','15','6','451.294','5.309','1',NULL), ('95','15','6','451.294','5.309','1',NULL), ('96','15','6','451.294','5.309','1',NULL), ('97','15','6','451.294','5.309','1',NULL), ('98','15','23','748.952','5.547','1',NULL), ('99','15','23','748.952','5.547','1',NULL), ('100','15','23','748.952','5.547','1',NULL), ('101','15','23','748.952','5.547','1',NULL), ('102','15','23','748.952','5.547','1',NULL), ('103','15','23','748.952','5.547','1',NULL);
INSERT INTO `ventadetalle` VALUES ('104','15','23','748.952','5.547','1',NULL), ('105','15','23','748.952','5.547','1',NULL), ('106','15','23','748.952','5.547','1',NULL), ('107','15','23','748.952','5.547','1',NULL), ('108','15','23','748.952','5.547','1',NULL), ('109','15','23','748.952','5.547','1',NULL), ('110','15','23','748.952','5.547','1',NULL), ('111','15','23','748.952','5.547','1',NULL), ('112','15','23','748.952','5.547','1',NULL), ('113','15','23','748.952','5.547','1',NULL), ('114','15','23','748.952','5.547','1',NULL), ('115','15','23','748.952','5.547','1',NULL), ('116','15','35','311.912','2.151','1',NULL), ('117','15','35','311.912','2.151','1',NULL), ('118','15','35','311.912','2.151','1',NULL), ('119','15','35','311.912','2.151','1',NULL), ('120','15','35','311.912','2.151','1',NULL), ('121','15','35','311.912','2.151','1',NULL), ('122','15','23','748.952','5.547','1',NULL), ('123','15','23','748.952','5.547','1',NULL), ('124','15','23','748.952','5.547','1',NULL), ('125','15','23','748.952','5.547','1',NULL), ('126','15','23','748.952','5.547','1',NULL), ('127','15','23','748.952','5.547','1',NULL), ('128','15','23','748.952','5.547','1',NULL), ('129','15','23','748.952','5.547','1',NULL), ('130','15','23','748.952','5.547','1',NULL), ('131','15','39','703.127','4.849','1',NULL), ('132','15','39','703.127','4.849','1',NULL), ('133','15','39','703.127','4.849','1',NULL), ('134','15','39','703.127','4.849','1',NULL), ('135','15','39','703.127','4.849','1',NULL), ('136','15','39','703.127','4.849','1',NULL), ('137','15','39','703.127','4.849','1',NULL), ('138','15','39','703.127','4.849','1',NULL), ('139','15','39','703.127','4.849','1',NULL), ('140','15','39','703.127','4.849','1',NULL), ('141','15','23','748.952','5.547','1',NULL), ('142','15','23','748.952','5.547','1',NULL), ('143','15','23','748.952','5.547','1',NULL), ('144','15','23','748.952','5.547','1',NULL), ('145','15','23','748.952','5.547','1',NULL), ('146','15','23','748.952','5.547','1',NULL), ('147','15','23','748.952','5.547','1',NULL), ('148','15','23','748.952','5.547','1',NULL), ('149','15','35','311.912','2.151','1',NULL), ('150','15','35','311.912','2.151','1',NULL), ('151','15','35','311.912','2.151','1',NULL), ('152','15','35','311.912','2.151','1',NULL), ('153','15','35','311.912','2.151','1',NULL), ('154','15','35','311.912','2.151','1',NULL), ('155','15','35','311.912','2.151','1',NULL), ('156','15','35','311.912','2.151','1',NULL), ('157','15','35','311.912','2.151','1',NULL), ('158','15','23','748.952','5.547','1',NULL), ('159','15','23','748.952','5.547','1',NULL), ('160','15','23','748.952','5.547','1',NULL), ('161','15','23','748.952','5.547','1',NULL), ('162','15','23','748.952','5.547','1',NULL), ('163','15','23','748.952','5.547','1',NULL), ('164','25','35','311.912','2.151','1',NULL), ('165','25','35','311.912','2.151','1',NULL), ('166','25','35','311.912','2.151','1',NULL), ('167','25','35','311.912','2.151','1',NULL), ('168','25','35','311.912','2.151','1',NULL), ('169','25','35','311.912','2.151','1',NULL), ('170','25','35','311.912','2.151','1',NULL), ('171','25','35','311.912','2.151','1',NULL), ('172','26','24','207.360','1.481','1',NULL), ('173','26','24','207.360','1.481','1',NULL), ('174','26','24','207.360','1.481','1',NULL), ('175','26','24','207.360','1.481','1',NULL), ('176','26','24','207.360','1.481','1',NULL), ('177','26','24','207.360','1.481','1',NULL), ('178','26','24','207.360','1.481','1',NULL), ('179','26','24','207.360','1.481','1',NULL), ('180','27','35','311.912','2.151','1',NULL), ('181','27','35','311.912','2.151','1',NULL), ('182','27','35','311.912','2.151','1',NULL), ('183','27','35','311.912','2.151','1',NULL), ('184','27','35','311.912','2.151','1',NULL), ('185','27','35','311.912','2.151','1',NULL), ('186','28','39','703.127','4.849','1',NULL), ('187','28','39','703.127','4.849','1',NULL), ('188','28','24','207.360','1.481','1',NULL), ('189','28','24','207.360','1.481','1',NULL), ('190','28','5','632.952','5.503','1',NULL), ('191','28','5','632.952','5.503','1',NULL), ('192','29','24','207.360','1.481','1',NULL), ('193','29','24','207.360','1.481','1',NULL), ('194','29','24','207.360','1.481','1',NULL), ('195','29','24','207.360','1.481','1',NULL), ('196','29','24','207.360','1.481','1',NULL), ('197','29','24','207.360','1.481','1',NULL), ('198','30','23','748.952','5.547','1',NULL), ('199','30','23','748.952','5.547','1',NULL), ('200','30','23','748.952','5.547','1',NULL), ('201','30','23','748.952','5.547','1',NULL), ('202','30','23','748.952','5.547','1',NULL);
