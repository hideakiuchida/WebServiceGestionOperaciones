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

INSERT INTO `gestion_operaciones_db`.`inspeccion` (`id`, `nro_orden`, `fecha`, `cantida_muestra`, `lugar`, `latitud`, `longitud`, `id_orden`) 
VALUES ('1', '234234243', now(), '34', 'Chorrillos', '-34.234234234', '-34.234234234', '1');
INSERT INTO `gestion_operaciones_db`.`inspeccion` (`id`, `nro_orden`, `fecha`, `cantida_muestra`, `lugar`, `latitud`, `longitud`, `id_orden`) 
VALUES ('2', '234234243', now(), '35', 'Chorrillos', '-34.234234234', '-34.234234234', '1');
