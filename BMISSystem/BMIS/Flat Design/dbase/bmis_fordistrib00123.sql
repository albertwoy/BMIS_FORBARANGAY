/*
 Navicat Premium Data Transfer

 Source Server         : localdata
 Source Server Type    : MySQL
 Source Server Version : 100140
 Source Host           : localhost:3306
 Source Schema         : bmis_fordistrib00123

 Target Server Type    : MySQL
 Target Server Version : 100140
 File Encoding         : 65001

 Date: 26/08/2023 20:28:34
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for bmis_user_trail_001
-- ----------------------------
DROP TABLE IF EXISTS `bmis_user_trail_001`;
CREATE TABLE `bmis_user_trail_001`  (
  `trailid` bigint(50) UNSIGNED NOT NULL AUTO_INCREMENT,
  `userid` int(20) NULL DEFAULT NULL,
  `trans` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `dsaved` date NULL DEFAULT NULL,
  `dtmp` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`trailid`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 18 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of bmis_user_trail_001
-- ----------------------------
INSERT INTO `bmis_user_trail_001` VALUES (1, 1, 'Login to BMIS succeeded --admin', '2023-08-24', '2023-08-24 18:55:53');
INSERT INTO `bmis_user_trail_001` VALUES (2, 1, 'Login to BMIS succeeded --admin', '2023-08-24', '2023-08-24 18:56:19');
INSERT INTO `bmis_user_trail_001` VALUES (3, 1, 'Viewed list of students for insurance--admin', '2023-08-24', '2023-08-24 18:56:22');
INSERT INTO `bmis_user_trail_001` VALUES (4, 1, 'Viewed list of students for insurance--admin', '2023-08-24', '2023-08-24 18:56:36');
INSERT INTO `bmis_user_trail_001` VALUES (5, 1, 'Viewed list of students for insurance--admin', '2023-08-24', '2023-08-24 18:56:49');
INSERT INTO `bmis_user_trail_001` VALUES (6, 1, 'Login to BMIS succeeded --admin', '2023-08-24', '2023-08-24 18:57:49');
INSERT INTO `bmis_user_trail_001` VALUES (7, 1, 'Viewed list of students for insurance--admin', '2023-08-24', '2023-08-24 18:57:55');
INSERT INTO `bmis_user_trail_001` VALUES (8, 1, 'LogOut to MU Insurance Generator --admin', '2023-08-24', '2023-08-24 18:58:14');
INSERT INTO `bmis_user_trail_001` VALUES (9, 1, 'Login to BMIS succeeded --admin', '2023-08-24', '2023-08-24 19:01:17');
INSERT INTO `bmis_user_trail_001` VALUES (10, 1, 'Viewed list of students for insurance--admin', '2023-08-24', '2023-08-24 19:02:08');
INSERT INTO `bmis_user_trail_001` VALUES (11, 1, 'LogOut to MU Insurance Generator --admin', '2023-08-24', '2023-08-24 19:02:43');
INSERT INTO `bmis_user_trail_001` VALUES (12, 1, 'Login to BMIS succeeded --admin', '2023-08-24', '2023-08-24 19:03:35');
INSERT INTO `bmis_user_trail_001` VALUES (13, 1, 'LogOut to MU Insurance Generator --admin', '2023-08-24', '2023-08-24 19:03:47');
INSERT INTO `bmis_user_trail_001` VALUES (14, 1, 'Failed Login --admin', '2023-08-24', '2023-08-24 19:04:45');
INSERT INTO `bmis_user_trail_001` VALUES (15, 1, 'Login to BMIS succeeded --admin', '2023-08-24', '2023-08-24 19:04:48');
INSERT INTO `bmis_user_trail_001` VALUES (16, 1, 'Viewed list of students for insurance--admin', '2023-08-24', '2023-08-24 19:04:59');
INSERT INTO `bmis_user_trail_001` VALUES (17, 1, 'LogOut to MU Insurance Generator --admin', '2023-08-24', '2023-08-24 19:07:49');

-- ----------------------------
-- Table structure for bmis_useraccout001
-- ----------------------------
DROP TABLE IF EXISTS `bmis_useraccout001`;
CREATE TABLE `bmis_useraccout001`  (
  `user_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `username1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `password1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `user_cname` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `usertype` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`user_id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of bmis_useraccout001
-- ----------------------------
INSERT INTO `bmis_useraccout001` VALUES (1, 'admin', 'yoxjBi/VtbXGkvGlmHFI9g==', 'Administrator', 'Administrator');
INSERT INTO `bmis_useraccout001` VALUES (2, 'toping', 'yoxjBi/VtbXGkvGlmHFI9g==', 'TOPING COY', 'Administrator');
INSERT INTO `bmis_useraccout001` VALUES (3, 'nurse1', 'yoxjBi/VtbXGkvGlmHFI9g==', 'NURSE 1', 'Staff Nurse');

SET FOREIGN_KEY_CHECKS = 1;
