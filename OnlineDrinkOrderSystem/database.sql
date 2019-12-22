/*
 Navicat Premium Data Transfer

 Source Server         : pi
 Source Server Type    : MariaDB
 Source Server Version : 100317
 Source Host           : pi.katyusha.net:3306
 Source Schema         : shop

 Target Server Type    : MariaDB
 Target Server Version : 100317
 File Encoding         : 65001

 Date: 22/12/2019 19:11:22
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for Cart
-- ----------------------------
DROP TABLE IF EXISTS `Cart`;
CREATE TABLE `Cart`  (
  `Cart_ID` int(11) NOT NULL AUTO_INCREMENT,
  `User_ID` int(11) NOT NULL,
  `Item_ID` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL,
  PRIMARY KEY (`Cart_ID`) USING BTREE,
  INDEX `User_ID`(`User_ID`) USING BTREE,
  INDEX `Item_ID`(`Item_ID`) USING BTREE,
  CONSTRAINT `Cart_ibfk_1` FOREIGN KEY (`User_ID`) REFERENCES `User` (`User_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `Cart_ibfk_2` FOREIGN KEY (`Item_ID`) REFERENCES `Item` (`Item_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 169 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Cart
-- ----------------------------
INSERT INTO `Cart` VALUES (167, 5, 1039, 1);
INSERT INTO `Cart` VALUES (168, 5, 1019, 1);

-- ----------------------------
-- Table structure for Category
-- ----------------------------
DROP TABLE IF EXISTS `Category`;
CREATE TABLE `Category`  (
  `Category_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Category_Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`Category_ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Category
-- ----------------------------
INSERT INTO `Category` VALUES (1, '奶茶');
INSERT INTO `Category` VALUES (2, '果汁');
INSERT INTO `Category` VALUES (3, '冰沙');
INSERT INTO `Category` VALUES (4, '咖啡');
INSERT INTO `Category` VALUES (5, '冰淇淋');
INSERT INTO `Category` VALUES (6, '其他商品');

-- ----------------------------
-- Table structure for Item
-- ----------------------------
DROP TABLE IF EXISTS `Item`;
CREATE TABLE `Item`  (
  `Item_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Item_Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Image_Url` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Item_Price` double NOT NULL,
  `Category_ID` int(11) NOT NULL,
  `Click_Counts` int(11) NOT NULL,
  `Stock` int(11) NOT NULL,
  `Date_added` datetime(0) NOT NULL,
  `Cost` double NOT NULL,
  `Sold` int(11) NOT NULL,
  `Discount` int(11) NOT NULL,
  PRIMARY KEY (`Item_ID`) USING BTREE,
  INDEX `Category_ID`(`Category_ID`) USING BTREE,
  CONSTRAINT `Item_ibfk_1` FOREIGN KEY (`Category_ID`) REFERENCES `Category` (`Category_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1047 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Item
-- ----------------------------
INSERT INTO `Item` VALUES (1012, '冰淇淋559438', '/img/item/001.jpg', '此处为 冰淇淋559438 的商品描述', 40, 5, 978, 91, '2017-10-14 16:00:36', 20, 71, 0);
INSERT INTO `Item` VALUES (1013, '冰淇淋224557', '/img/item/002.jpg', '此处为 冰淇淋224557 的商品描述', 40, 5, 593, 89, '2018-10-07 16:00:36', 20, 24, 0);
INSERT INTO `Item` VALUES (1014, '冰淇淋158030', '/img/item/003.jpg', '此处为 冰淇淋158030 的商品描述', 40, 5, 845, 94, '2019-12-03 16:00:36', 20, 78, 0);
INSERT INTO `Item` VALUES (1015, '冰淇淋131868', '/img/item/004.jpg', '此处为 冰淇淋131868 的商品描述', 40, 5, 557, 48, '2018-08-09 16:00:36', 20, 20, 0);
INSERT INTO `Item` VALUES (1016, '冰淇淋105707', '/img/item/005.jpg', '此处为 冰淇淋105707 的商品描述', 40, 5, 268, 91, '2017-04-14 16:00:36', 20, 51, 0);
INSERT INTO `Item` VALUES (1017, '冰淇淋428631', '/img/item/006.jpg', '此处为 冰淇淋428631 的商品描述', 40, 5, 433, 39, '2019-05-31 16:00:36', 20, 50, 0);
INSERT INTO `Item` VALUES (1018, '冰沙507695', '/img/item/007.jpg', '此处为 冰沙507695 的商品描述', 50, 3, 586, 29, '2018-03-04 16:01:22', 25, 76, 0);
INSERT INTO `Item` VALUES (1019, '冰沙521899', '/img/item/008.jpg', '此处为 冰沙521899 的商品描述', 40, 3, 656, 21, '2019-11-09 16:01:22', 20, 85, 0);
INSERT INTO `Item` VALUES (1020, '冰沙536103', '/img/item/009.jpg', '此处为 冰沙536103 的商品描述', 40, 3, 724, 13, '2018-10-21 16:01:22', 20, 94, 0);
INSERT INTO `Item` VALUES (1021, '冰沙134694', '/img/item/010.jpg', '此处为 冰沙134694 的商品描述', 50, 3, 591, 16, '2018-03-15 16:01:22', 25, 11, 0);
INSERT INTO `Item` VALUES (1022, '冰沙497984', '/img/item/011.jpg', '此处为 冰沙497984 的商品描述', 40, 3, 215, 91, '2017-11-09 16:01:22', 20, 76, 0);
INSERT INTO `Item` VALUES (1023, '冰沙512188', '/img/item/012.jpg', '此处为 冰沙512188 的商品描述', 50, 3, 284, 83, '2019-07-17 16:01:22', 25, 85, 0);
INSERT INTO `Item` VALUES (1024, '冰沙835112', '/img/item/013.jpg', '此处为 冰沙835112 的商品描述', 50, 3, 450, 31, '2018-12-06 16:01:22', 25, 84, 0);
INSERT INTO `Item` VALUES (1025, '冰沙258037', '/img/item/014.jpg', '此处为 冰沙258037 的商品描述', 40, 3, 615, 67, '2018-04-26 16:01:22', 20, 82, 0);
INSERT INTO `Item` VALUES (1026, '冰沙191510', '/img/item/015.jpg', '此处为 冰沙191510 的商品描述', 50, 3, 867, 72, '2019-06-22 16:01:23', 25, 47, 0);
INSERT INTO `Item` VALUES (1027, '冰沙595166', '/img/item/016.jpg', '此处为 冰沙595166 的商品描述', 50, 3, 849, 96, '2019-05-23 16:01:23', 25, 89, 0);
INSERT INTO `Item` VALUES (1028, '果汁576626', '/img/item/017.jpg', '此处为 果汁576626 的商品描述', 40, 2, 828, 89, '2018-01-27 16:02:02', 20, 10, 0);
INSERT INTO `Item` VALUES (1029, '果汁201379', '/img/item/018.jpg', '此处为 果汁201379 的商品描述', 30, 2, 984, 49, '2018-10-16 16:02:02', 15, 74, 0);
INSERT INTO `Item` VALUES (1030, '果汁175217', '/img/item/019.jpg', '此处为 果汁175217 的商品描述', 30, 2, 695, 92, '2017-06-22 16:02:02', 15, 17, 0);
INSERT INTO `Item` VALUES (1031, '果汁578872', '/img/item/020.jpg', '此处为 果汁578872 的商品描述', 30, 2, 677, 27, '2017-05-23 16:02:02', 15, 59, 0);
INSERT INTO `Item` VALUES (1032, '果汁258195', '/img/item/021.jpg', '此处为 果汁258195 的商品描述', 30, 2, 361, 17, '2017-04-27 16:02:02', 15, 21, 0);
INSERT INTO `Item` VALUES (1033, '咖啡728455', '/img/item/022.jpg', '此处为 咖啡728455 的商品描述', 30, 4, 413, 55, '2018-04-29 16:02:41', 15, 24, 0);
INSERT INTO `Item` VALUES (1034, '咖啡272477', '/img/item/023.jpg', '此处为 咖啡272477 的商品描述', 30, 4, 752, 28, '2018-07-05 16:02:42', 15, 44, 0);
INSERT INTO `Item` VALUES (1035, '咖啡205950', '/img/item/024.jpg', '此处为 咖啡205950 的商品描述', 30, 4, 106, 32, '2019-08-31 16:02:42', 15, 97, 0);
INSERT INTO `Item` VALUES (1036, '咖啡825637', '/img/item/025.jpg', '此处为 咖啡825637 的商品描述', 40, 4, 147, 60, '2019-11-10 16:02:42', 20, 37, 0);
INSERT INTO `Item` VALUES (1037, '咖啡759110', '/img/item/026.jpg', '此处为 咖啡759110 的商品描述', 30, 4, 400, 65, '2018-04-11 16:02:42', 15, 90, 0);
INSERT INTO `Item` VALUES (1038, '咖啡343497', '/img/item/027.jpg', '此处为 咖啡343497 的商品描述', 30, 4, 198, 76, '2018-09-22 16:02:42', 15, 88, 0);
INSERT INTO `Item` VALUES (1039, '咖啡276970', '/img/item/028.jpg', '此处为 咖啡276970 的商品描述', 40, 4, 451, 81, '2019-11-18 16:02:42', 20, 53, 0);
INSERT INTO `Item` VALUES (1040, '咖啡250809', '/img/item/029.jpg', '此处为 咖啡250809 的商品描述', 40, 4, 162, 35, '2018-07-25 16:02:42', 20, 84, 0);
INSERT INTO `Item` VALUES (1041, '奶茶419117', '/img/item/030.jpg', '此处为 奶茶419117 的商品描述', 40, 1, 604, 62, '2018-03-13 16:03:08', 20, 71, 0);
INSERT INTO `Item` VALUES (1042, '奶茶392956', '/img/item/031.jpg', '此处为 奶茶392956 的商品描述', 30, 1, 315, 16, '2019-08-14 16:03:08', 15, 13, 0);
INSERT INTO `Item` VALUES (1043, '奶茶326429', '/img/item/032.jpg', '此处为 奶茶326429 的商品描述', 40, 1, 568, 21, '2018-01-12 16:03:08', 20, 67, 0);
INSERT INTO `Item` VALUES (1044, '奶茶770450', '/img/item/033.jpg', '此处为 奶茶770450 的商品描述', 30, 1, 907, 83, '2018-03-21 16:03:08', 15, 87, 0);
INSERT INTO `Item` VALUES (1046, '测试商品', '/img/item/test.jpg', '测试商品，请勿购买', 100, 6, 100, 1000, '2019-12-22 04:06:00', 0, 0, 50);

-- ----------------------------
-- Table structure for Order_Detail
-- ----------------------------
DROP TABLE IF EXISTS `Order_Detail`;
CREATE TABLE `Order_Detail`  (
  `Order_ID` int(11) NOT NULL AUTO_INCREMENT,
  `User_ID` int(11) NULL DEFAULT NULL,
  `Order_Sum` double NOT NULL,
  `Order_Cost` double NOT NULL,
  `Delivery` int(11) NOT NULL,
  `Shipment` int(11) NOT NULL,
  `Address` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Order_Date` datetime(0) NOT NULL,
  PRIMARY KEY (`Order_ID`) USING BTREE,
  INDEX `User_ID`(`User_ID`) USING BTREE,
  CONSTRAINT `Order_Detail_ibfk_1` FOREIGN KEY (`User_ID`) REFERENCES `User` (`User_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 92308761 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for Order_List
-- ----------------------------
DROP TABLE IF EXISTS `Order_List`;
CREATE TABLE `Order_List`  (
  `Order_ID` int(11) NOT NULL,
  `Item_ID` int(11) NULL DEFAULT NULL,
  `Order_Price` double NOT NULL,
  `Order_Cost` double NOT NULL,
  `Quantity` int(11) NOT NULL,
  INDEX `Order_ID`(`Order_ID`) USING BTREE,
  INDEX `Item_ID`(`Item_ID`) USING BTREE,
  CONSTRAINT `Order_List_ibfk_1` FOREIGN KEY (`Order_ID`) REFERENCES `Order_Detail` (`Order_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `Order_List_ibfk_2` FOREIGN KEY (`Item_ID`) REFERENCES `Item` (`Item_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for Review
-- ----------------------------
DROP TABLE IF EXISTS `Review`;
CREATE TABLE `Review`  (
  `Review_ID` int(11) NOT NULL AUTO_INCREMENT,
  `User_ID` int(11) NULL DEFAULT NULL,
  `Item_ID` int(11) NOT NULL,
  `Content` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Recommend` tinyint(1) NOT NULL,
  `Date` datetime(0) NOT NULL,
  PRIMARY KEY (`Review_ID`) USING BTREE,
  INDEX `User_ID`(`User_ID`) USING BTREE,
  INDEX `Item_ID`(`Item_ID`) USING BTREE,
  CONSTRAINT `Review_ibfk_1` FOREIGN KEY (`User_ID`) REFERENCES `User` (`User_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `Review_ibfk_2` FOREIGN KEY (`Item_ID`) REFERENCES `Item` (`Item_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for Trace_List
-- ----------------------------
DROP TABLE IF EXISTS `Trace_List`;
CREATE TABLE `Trace_List`  (
  `User_ID` int(11) NOT NULL,
  `Item_ID` int(11) NULL DEFAULT NULL,
  `Trace_Price` double NOT NULL,
  UNIQUE INDEX `User_ID`(`User_ID`, `Item_ID`) USING BTREE,
  INDEX `Item_ID`(`Item_ID`) USING BTREE,
  CONSTRAINT `Trace_List_ibfk_1` FOREIGN KEY (`User_ID`) REFERENCES `User` (`User_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `Trace_List_ibfk_2` FOREIGN KEY (`Item_ID`) REFERENCES `Item` (`Item_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of Trace_List
-- ----------------------------
INSERT INTO `Trace_List` VALUES (5, 1014, 50);

-- ----------------------------
-- Table structure for User
-- ----------------------------
DROP TABLE IF EXISTS `User`;
CREATE TABLE `User`  (
  `User_ID` int(11) NOT NULL AUTO_INCREMENT,
  `User_Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `User_Password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `First_Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Last_Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Address` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Admin` tinyint(1) NOT NULL,
  PRIMARY KEY (`User_ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 15 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of User
-- ----------------------------
INSERT INTO `User` VALUES (5, 'admin', 'root', '用户', '管理员', 'admin@test.com', 'admin test address', 1);
INSERT INTO `User` VALUES (13, 'test', '123456', '用户', '测试', 'test@test.com', 'test address', 0);

SET FOREIGN_KEY_CHECKS = 1;
