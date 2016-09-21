-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema gestion_operaciones_db
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `gestion_operaciones_db` ;

-- -----------------------------------------------------
-- Schema gestion_operaciones_db
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `gestion_operaciones_db` DEFAULT CHARACTER SET latin1 ;
USE `gestion_operaciones_db` ;

-- -----------------------------------------------------
-- Table `gestion_operaciones_db`.`Rol`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gestion_operaciones_db`.`Rol` ;

CREATE TABLE IF NOT EXISTS `gestion_operaciones_db`.`Rol` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `gestion_operaciones_db`.`Usuario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gestion_operaciones_db`.`Usuario` ;

CREATE TABLE IF NOT EXISTS `gestion_operaciones_db`.`Usuario` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(100) NULL DEFAULT NULL,
  `apellido` VARCHAR(200) NULL DEFAULT NULL,
  `correo` VARCHAR(200) NULL DEFAULT NULL,
  `password` VARCHAR(250) NULL DEFAULT NULL,
  `telefono` VARCHAR(45) NULL DEFAULT NULL,
  `estado` INT(1) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `gestion_operaciones_db`.`Token`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gestion_operaciones_db`.`Token` ;

CREATE TABLE IF NOT EXISTS `gestion_operaciones_db`.`Token` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `authToken` VARCHAR(500) NULL DEFAULT NULL,
  `issuedOn` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `expiresOn` TIMESTAMP NULL DEFAULT NULL,
  `userId` INT(3) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `FK_TOKENXUSUARIO` (`userId` ASC),
  CONSTRAINT `FK_TOKENXUSUARIO`
    FOREIGN KEY (`userId`)
    REFERENCES `gestion_operaciones_db`.`Usuario` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `gestion_operaciones_db`.`Usuario_Rol`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gestion_operaciones_db`.`Usuario_Rol` ;

CREATE TABLE IF NOT EXISTS `gestion_operaciones_db`.`Usuario_Rol` (
  `id_usuario` INT(11) NOT NULL,
  `id_rol` INT(11) NOT NULL,
  INDEX `usuario_id` (`id_usuario` ASC),
  INDEX `autoridad_id` (`id_rol` ASC),
  CONSTRAINT `usuario_autoridad_ibfk_1`
    FOREIGN KEY (`id_usuario`)
    REFERENCES `gestion_operaciones_db`.`Usuario` (`id`),
  CONSTRAINT `usuario_autoridad_ibfk_2`
    FOREIGN KEY (`id_rol`)
    REFERENCES `gestion_operaciones_db`.`Rol` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `gestion_operaciones_db`.`Orden`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gestion_operaciones_db`.`Orden` ;

CREATE TABLE IF NOT EXISTS `gestion_operaciones_db`.`Orden` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `descripcion` VARCHAR(200) NULL,
  `cliente` VARCHAR(200) NULL,
  `latitud` VARCHAR(100) NULL,
  `longitud` VARCHAR(100) NULL,
  `estado_pendiente` INT NULL,
  `id_usuario` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_ou_id_idx` (`id_usuario` ASC),
  CONSTRAINT `fk_ou_id`
    FOREIGN KEY (`id_usuario`)
    REFERENCES `gestion_operaciones_db`.`Usuario` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gestion_operaciones_db`.`Inspeccion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gestion_operaciones_db`.`Inspeccion` ;

CREATE TABLE IF NOT EXISTS `gestion_operaciones_db`.`Inspeccion` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nro_orden` VARCHAR(45) NULL,
  `fecha` DATETIME NULL,
  `cantida_muestra` INT NULL,
  `lugar` VARCHAR(200) NULL,
  `latitud` VARCHAR(100) NULL,
  `longitud` VARCHAR(100) NULL,
  `id_orden` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_io_id_idx` (`id_orden` ASC),
  CONSTRAINT `fk_io_id`
    FOREIGN KEY (`id_orden`)
    REFERENCES `gestion_operaciones_db`.`Orden` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `gestion_operaciones_db`.`Foto`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gestion_operaciones_db`.`Foto` ;

CREATE TABLE IF NOT EXISTS `gestion_operaciones_db`.`Foto` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `foto` LONGTEXT NULL,
  `id_inspeccion` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_fi_inspeccion_idx` (`id_inspeccion` ASC),
  CONSTRAINT `fk_fi_inspeccion`
    FOREIGN KEY (`id_inspeccion`)
    REFERENCES `gestion_operaciones_db`.`Inspeccion` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
