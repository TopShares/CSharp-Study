/*
Navicat MySQL Data Transfer

Source Server         : 192.168.23.167
Source Server Version : 50723
Source Host           : 192.168.23.167:3306
Source Database       : datamip

Target Server Type    : MYSQL
Target Server Version : 50723
File Encoding         : 65001

Date: 2018-08-25 12:13:44
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `users`
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `UserNick` varchar(255) DEFAULT NULL,
  `LoginIP` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES ('1', '新晖图书专营店', '10.12.33.22', '1@qq.com');
INSERT INTO `users` VALUES ('2', '畅想之星图书专营店', '10.22.123.234', 'zzzz@qq.com');
