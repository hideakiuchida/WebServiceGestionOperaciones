INSERT INTO `gestion_operaciones_db`.`usuario` 
VALUES (1, 'ALONSO', 'UCHIDA', 'alonso.uchida@gmail.com', '12345', '4236492', 1);
INSERT INTO `gestion_operaciones_db`.`usuario` 
VALUES (2, 'JAMESON', 'LOPEZ', 'jameson.lopez@gmail.com', '12345', '4236492', 1);
-- ----------------------------
-- Records of autoridad
-- ----------------------------

INSERT INTO `gestion_operaciones_db`.`rol` 
VALUES (1, 'INSPECTOR');
INSERT INTO `gestion_operaciones_db`.`rol` 
VALUES (2, 'SUPERVISOR');

INSERT INTO `gestion_operaciones_db`.`usuario_rol` 
VALUES (1, 1);
INSERT INTO `gestion_operaciones_db`.`usuario_rol` 
VALUES (2, 2);

INSERT INTO `gestion_operaciones_db`.`orden` (`id`, `descripcion`, `cliente`, `latitud`, `longitud`, `nro_orden`, `id_usuario`) VALUES ('1', 'orden 1', 'cliente 1', '-54.234234324', '-54.45646454', '4GAAA1-12310', '1');
INSERT INTO `gestion_operaciones_db`.`orden` (`id`, `descripcion`, `cliente`, `latitud`, `longitud`,  `nro_orden`,`id_usuario`) VALUES ('2', 'orden 2', 'cliente 1', '-54.234234324', '-54.45646454', '4GAAA1-12311', '1');
INSERT INTO `gestion_operaciones_db`.`orden` (`id`, `descripcion`, `cliente`, `latitud`, `longitud`, `nro_orden`,`id_usuario`) VALUES ('3', 'orden 3', 'cliente 1', '-54.234234324', '-54.45646454', '4GAAA1-12312', '1');
INSERT INTO `gestion_operaciones_db`.`orden` (`id`, `descripcion`, `cliente`, `latitud`, `longitud`, `nro_orden`,`id_usuario`) VALUES ('4', 'orden 4', 'cliente 1', '-54.234234324', '-54.45646454',  '4GAAA1-12313', '1');
INSERT INTO `gestion_operaciones_db`.`orden` (`id`, `descripcion`, `cliente`, `latitud`, `longitud`,  `nro_orden`,`id_usuario`) VALUES ('5', 'orden 5', 'cliente 1', '-54.234234324', '-54.45646454',  '4GAAA1-12314', '1');

INSERT INTO `gestion_operaciones_db`.`inspeccion` (`id`, `nro_inspeccion`, `fecha`, `cantida_muestra`, `lugar`, `id_orden`) 
VALUES ('1', '234234243', now(), '34', 'Chorrillos',  '1');
INSERT INTO `gestion_operaciones_db`.`inspeccion` (`id`, `nro_inspeccion`, `fecha`, `cantida_muestra`, `lugar`, `id_orden`) 
VALUES ('2', '234234243', now(), '35', 'Chorrillos', '1');
