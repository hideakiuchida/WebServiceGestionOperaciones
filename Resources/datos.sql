INSERT INTO `usuario` VALUES (1, 'ALONSO', 'UCHIDA', 'javier.uchida@valmar.com.pe', '12345', '4236492', 1,  NOW(), NOW());
-- ----------------------------
-- Records of autoridad
-- ----------------------------

INSERT INTO `autoridad` VALUES (1, 'INSPECTOR');
INSERT INTO `autoridad` VALUES (2, 'SUPERVISOR');

INSERT INTO `usuario_autoridad` VALUES (1, 1)