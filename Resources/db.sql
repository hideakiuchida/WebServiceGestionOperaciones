-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema CMS_VALMAR_DB
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `GESTION_OPERACIONES_DB` ;

-- -----------------------------------------------------
-- Schema CMS_VALMAR_DB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `GESTION_OPERACIONES_DB` DEFAULT CHARACTER SET latin1 ;
USE `GESTION_OPERACIONES_DB` ;

-- -----------------------------------------------------
-- Table `CMS_VALMAR_DB`.`autoridad`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `GESTION_OPERACIONES_DB`.`autoridad` ;

CREATE TABLE IF NOT EXISTS `GESTION_OPERACIONES_DB`.`autoridad` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = latin1;

-- -----------------------------------------------------
-- Table `CMS_VALMAR_DB`.`usuario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `GESTION_OPERACIONES_DB`.`usuario` ;

CREATE TABLE IF NOT EXISTS `GESTION_OPERACIONES_DB`.`usuario` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(100) NULL DEFAULT NULL,
  `apellido` VARCHAR(200) NULL DEFAULT NULL,
  `correo` VARCHAR(200) NULL DEFAULT NULL,
  `password` VARCHAR(250) NULL DEFAULT NULL,
  `telefono` VARCHAR(45) NULL,
  `estado` INT(1) NOT NULL,
  `fecha_registro` DATETIME NOT NULL,
  `fecha_modificacion` DATETIME NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `CMS_VALMAR_DB`.`token`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `GESTION_OPERACIONES_DB`.`token` ;

CREATE TABLE IF NOT EXISTS `GESTION_OPERACIONES_DB`.`token` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `authToken` VARCHAR(500) NULL DEFAULT NULL,
  `issuedOn` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `expiresOn` TIMESTAMP NULL DEFAULT NULL,
  `userId` INT(3) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `FK_TOKENXUSUARIO` (`userId` ASC),
  CONSTRAINT `FK_TOKENXUSUARIO`
    FOREIGN KEY (`userId`)
    REFERENCES `GESTION_OPERACIONES_DB`.`usuario` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;

DROP TABLE IF EXISTS `GESTION_OPERACIONES_DB`.`usuario_autoridad` ;

CREATE TABLE IF NOT EXISTS `GESTION_OPERACIONES_DB`.`usuario_autoridad` (
  `id_usuario` INT(11) NOT NULL,
  `id_autoridad` INT(11) NOT NULL,
  INDEX `usuario_id` (`id_usuario` ASC),
  INDEX `autoridad_id` (`id_autoridad` ASC),
  CONSTRAINT `usuario_autoridad_ibfk_1`
    FOREIGN KEY (`id_usuario`)
    REFERENCES `GESTION_OPERACIONES_DB`.`usuario` (`id`),
  CONSTRAINT `usuario_autoridad_ibfk_2`
    FOREIGN KEY (`id_autoridad`)
    REFERENCES `GESTION_OPERACIONES_DB`.`autoridad` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;