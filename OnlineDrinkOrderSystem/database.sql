-- MySQL dump 10.17  Distrib 10.3.17-MariaDB, for debian-linux-gnueabihf (armv7l)
--
-- Host: localhost    Database: shop
-- ------------------------------------------------------
-- Server version	10.3.17-MariaDB-0+deb10u1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `shop`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `shop` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `shop`;

--
-- Table structure for table `Cart`
--

DROP TABLE IF EXISTS `Cart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Cart` (
  `Cart_ID` int(11) NOT NULL AUTO_INCREMENT,
  `User_ID` int(11) NOT NULL,
  `Item_ID` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL,
  PRIMARY KEY (`Cart_ID`),
  KEY `User_ID` (`User_ID`),
  KEY `Item_ID` (`Item_ID`),
  CONSTRAINT `Cart_ibfk_1` FOREIGN KEY (`User_ID`) REFERENCES `User` (`User_ID`),
  CONSTRAINT `Cart_ibfk_2` FOREIGN KEY (`Item_ID`) REFERENCES `Item` (`Item_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=360 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Cart`
--

LOCK TABLES `Cart` WRITE;
/*!40000 ALTER TABLE `Cart` DISABLE KEYS */;
INSERT INTO `Cart` VALUES (220,15,1039,3),(221,15,1037,1),(222,15,1014,1),(223,15,1016,1),(304,16,1039,2),(305,16,1014,7),(306,16,1023,2),(307,16,1022,1),(308,16,1015,4),(309,16,1044,2),(310,16,1041,1),(311,16,1031,11),(312,16,1018,7),(313,16,1040,4),(314,16,1016,3);
/*!40000 ALTER TABLE `Cart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Category`
--

DROP TABLE IF EXISTS `Category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Category` (
  `Category_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Category_Name` varchar(255) NOT NULL,
  PRIMARY KEY (`Category_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Category`
--

LOCK TABLES `Category` WRITE;
/*!40000 ALTER TABLE `Category` DISABLE KEYS */;
INSERT INTO `Category` VALUES (1,'奶茶'),(2,'果汁'),(3,'冰沙'),(4,'咖啡'),(5,'冰淇淋'),(6,'其他商品');
/*!40000 ALTER TABLE `Category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Item`
--

DROP TABLE IF EXISTS `Item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Item` (
  `Item_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Item_Name` varchar(255) NOT NULL,
  `Image_Url` varchar(255) DEFAULT NULL,
  `Description` varchar(255) NOT NULL,
  `Item_Price` double NOT NULL,
  `Category_ID` int(11) NOT NULL,
  `Click_Counts` int(11) NOT NULL,
  `Stock` int(11) NOT NULL,
  `Date_added` datetime NOT NULL,
  `Cost` double NOT NULL,
  `Sold` int(11) NOT NULL,
  `Discount` int(11) NOT NULL,
  PRIMARY KEY (`Item_ID`),
  KEY `Category_ID` (`Category_ID`),
  CONSTRAINT `Item_ibfk_1` FOREIGN KEY (`Category_ID`) REFERENCES `Category` (`Category_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1058 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Item`
--

LOCK TABLES `Item` WRITE;
/*!40000 ALTER TABLE `Item` DISABLE KEYS */;
INSERT INTO `Item` VALUES (1012,'甜筒冰淇淋','/img/item/001.jpg','因其難以描述的美味、無法抵擋的魅力，而聞名天下，其甜美爽滑的口感、迷幻怡人的外觀，受到食客的好評。',45,5,980,90,'2019-10-14 04:00:00',20,71,10),(1013,'藍莓冰淇淋','/img/item/002.jpg','以新鮮牛奶為原料，配以各式調味醬，口感細膩滑順，爽口不膩健康自然。',40,5,593,89,'2018-10-07 04:00:00',20,24,0),(1014,'浪漫巴菲冰淇淋','/img/item/003.jpg','甜度較高，奶味濃郁，入口香滑綿密，如\"絲綢\"壹般的柔順濃郁。',40,5,850,76,'2019-12-03 04:00:00',20,78,0),(1015,'草莓冰淇淋','/img/item/004.jpg','因其高貴誘人的外形、難以描述的美味、無法抵擋的魅力，而聞名天下，給人帶來的是嬌艷欲滴、楚楚動人般的奇妙感受，其甜美爽滑的口感、迷幻怡人的外觀，受到食客的好評。',40,5,559,26,'2018-08-09 04:00:00',20,20,0),(1016,'美式冰淇淋','/img/item/005.jpg','冰淇淋中的基本款。甜度較高，它總有各式各樣的口味和裝飾配料。如果妳喜歡用料狠甜度高且不怕膩，美式冰淇淋就很適合妳。',40,5,271,83,'2017-04-14 04:00:00',20,51,0),(1017,'法式冰淇淋','/img/item/006.jpg','用新鮮牛奶為基底料搭配最濃厚的各式調味原料，直接攪拌冷凍而成，它的質地會比較厚，口感也更粘稠，但同時又十分絲滑。',40,5,437,25,'2019-05-31 04:00:00',20,50,0),(1018,'芒果冰沙','/img/item/007.jpg','原料主要有芒果、冰塊、蜂蜜等，味道香甜可口，品色上乘，口味甜酸。',50,3,588,21,'2018-03-04 04:01:00',25,76,0),(1019,'抹茶冰沙','/img/item/008.jpg','口感比較淡然，不會過分甜，抹茶的味道也不會過分的濃，是一種熟悉的夏日飲料的感覺。',40,3,656,20,'2019-11-09 04:01:00',20,85,0),(1020,'椰子冰沙','/img/item/009.jpg','味道非常不錯，吃下去甜中帶砂，有明顯椰子的味道。',40,3,724,13,'2018-10-21 04:01:00',20,94,0),(1021,'奇異果冰沙','/img/item/010.jpg','香甜奇異果製作的冰沙，是口碑極佳的美容聖品喔。',50,3,591,16,'2018-03-15 04:01:00',25,11,0),(1022,'葡萄冰沙','/img/item/011.jpg','采用無籽葡萄作為原料，一口下去酸酸甜甜， 回味無窮。',40,3,218,79,'2017-11-09 04:01:00',20,76,0),(1023,'木瓜奶茶','/img/item/012.jpg','選用新鮮木瓜為原料，營養豐富，口感醇厚。',50,1,287,67,'2019-07-17 04:01:00',25,85,0),(1024,'咖啡慕斯冰沙','/img/item/013.jpg','表面上尖尖的咖啡冰，大口大口享用，融化在嘴裏的那一刻，非常美妙',50,3,452,31,'2018-12-06 04:01:00',25,84,0),(1025,'花生冰沙','/img/item/014.jpg','口感綿密，花生味道濃郁，分量很足。',40,3,615,67,'2018-04-26 04:01:00',20,82,0),(1026,'巧克力冰沙','/img/item/015.jpg','香濃的巧克力冰沙配上滿滿慕斯和奧利奧碎片，給你帶來不一樣的口感。',50,3,867,72,'2019-06-22 04:01:00',25,47,0),(1027,'荔枝冰沙','/img/item/016.jpg','甜美荔枝做出來的冰沙，喝起来酸酸甜甜超清爽',50,3,849,96,'2019-05-23 04:01:00',25,89,0),(1028,'橙汁','/img/item/017.jpg','是以柳丁為原料經過榨汁機壓榨得到的果汁飲料。新鮮而營養價值高，可經過冷凍的方法飲用或直接飲用 ',40,2,828,89,'2018-01-27 04:02:00',20,10,0),(1029,'獼猴桃汁','/img/item/018.jpg','是以獼猴桃為原料經過榨汁機壓榨得到的果汁。新鮮而營養價值高，可經過冷凍的方法飲用或直接飲用 [1]  ，食療作用是 清熱生津，健脾止瀉，止渴利尿',30,2,984,49,'2018-10-16 04:02:00',15,74,0),(1030,'葡萄汁','/img/item/019.jpg','是由葡萄果肉榨出的果汁。葡萄含有大量易於消化和吸收的糖分，碳水化合物含量高達16%，其中大部分是葡萄糖。含有的抗氧化劑例如類黃酮，這些抗氧化劑被證明有益於皮膚。',30,2,695,92,'2017-06-22 04:02:00',15,17,0),(1031,'蘋果汁','/img/item/020.jpg','一種廉價的改善身體健康的飲品。是天然的抗氧化食物，可降低因氧化引起的代謝疾病的風險 ，在一定程度上起到預防冠也病 、 免疫系統損失及糖尿病等疾病的作用 。',30,2,680,14,'2017-05-23 04:02:00',15,59,0),(1032,'西瓜汁','/img/item/021.jpg','以西瓜為原經過物理方法如壓榨、離心、萃取等得到的汁液產品料，具有解暑功效。口味清甜細膩，冰鎮之後口感更好，夏季倍受人青睞。不添加任何防腐劑。',30,2,361,17,'2017-04-27 04:02:00',15,21,0),(1033,'濃縮咖啡','/img/item/022.jpg','是俗稱的義大利特濃咖啡。濃縮咖啡是利用高壓，讓沸水在短短幾秒裡迅速通過咖啡粉，得到約1/4盎司的咖啡，味苦而濃香。',30,4,413,55,'2018-04-29 04:02:00',15,24,0),(1034,'瑪奇朵','/img/item/023.jpg','瑪奇朵是在濃咖啡上加上薄薄一層熱奶泡以保持咖啡溫度，細膩香甜的奶泡能緩衝濃縮咖啡帶來的苦澀衝擊，想喝咖啡但又無法捨棄甜味的你，可以選擇瑪奇朵。',30,4,752,28,'2018-07-05 04:02:00',15,44,0),(1035,'美式咖啡','/img/item/024.jpg','使用滴濾式咖啡壺、虹吸壺、法壓壺之類的器具所製作出的黑咖啡，又或者是在義大利濃縮咖啡中加入大量的水製成。口味比較淡，但因為萃取時間長，所以咖啡因含量高。具有提神醒腦的作用，如果精神不佳，可以喝美式咖啡。',30,4,111,27,'2019-08-31 04:02:00',15,97,0),(1036,'白咖啡','/img/item/025.jpg','馬來西亞土特產，約有100多年的歷史。白咖啡並不是指咖啡的顏色是白色的，而是採用特等咖啡豆及特級脫脂奶精原料，經特殊工藝加工後得到的咖啡，甘醇芳香不傷腸胃，保留了咖啡原有的色澤和香味，顏色比普通咖啡更清淡柔和，故得名為白咖啡。',40,4,149,59,'2019-11-10 04:02:00',20,37,0),(1037,'拿鐵','/img/item/026.jpg','拿鐵咖啡做法極其簡單，就是在剛剛做好的義大利濃縮咖啡中倒入接近沸騰的牛奶。事實上，加入多少牛奶沒有一定之規，可依個人口味自由調配。',30,4,401,61,'2018-04-11 04:02:00',15,90,0),(1038,'康寶藍','/img/item/027.jpg','即意式濃縮咖啡加上鮮奶油。有一種說法是，正宗的康寶藍要配一顆巧克力或太妃糖，先將巧克力或太妃糖含在嘴裡，再喝咖啡，讓美味一起在口中綻放。',30,4,199,74,'2018-09-22 04:02:00',15,88,0),(1039,'半拿鐵','/img/item/028.jpg','很像拿鐵，不同是加入了的不是牛奶，而是半牛奶、半奶油的混合物，有時會再加少許奶泡',40,4,454,49,'2019-11-18 04:02:00',20,53,0),(1040,'卡布奇諾','/img/item/029.jpg','統的卡布奇諾咖啡是三分之一濃縮咖啡，三分之一蒸汽牛奶和三分之一泡沫牛奶。卡布奇諾分為幹和濕兩種。幹卡布奇諾(Dry Cappuccino)是指奶泡較多，牛奶較少的調理法，喝起來咖啡味濃過奶香。濕卡布奇諾(Wet Cappuccino)則指奶泡較少，牛奶量較多的做法，奶香蓋過濃嗆的咖啡味，適合口味清淡者。',40,4,163,31,'2018-07-25 04:02:00',20,84,0),(1041,'珍珠奶茶','/img/item/030.jpg','香醇濃郁的奶茶加入香Q彈牙、嚼勁十足的珍珠，經典飲品好喝不簡單，是超高人氣飲品喔。',40,1,605,60,'2018-03-13 04:03:00',20,71,0),(1042,'原味奶茶','/img/item/031.jpg','當清新的茶香遇上濃郁的奶香，滑順濃郁的口鹹觸動著味蕾，單純又美味。',30,1,320,0,'2019-08-14 04:03:00',15,13,0),(1043,'巧克力奶茶','/img/item/032.jpg','香濃巧克力與濃醇奶茶自然融合，香甜濃醇，給妳口口幸福感受。',40,1,568,21,'2018-01-12 04:03:00',20,67,0),(1044,'慕斯奶蓋茶','/img/item/033.jpg','綿密細致的慕斯，覆蓋在淡雅的茉莉茶香上，壹口啜入，香甜甘醇的雙重口感，融合出絕佳風味。',30,1,909,73,'2018-03-21 04:03:00',15,87,0),(1046,'测试商品','/img/item/test.jpg','测试商品，请勿购买',100,6,104,995,'2019-12-22 04:06:00',0,0,33);
/*!40000 ALTER TABLE `Item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `Item_Top`
--

DROP TABLE IF EXISTS `Item_Top`;
/*!50001 DROP VIEW IF EXISTS `Item_Top`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `Item_Top` (
  `Item_ID` tinyint NOT NULL,
  `Item_Name` tinyint NOT NULL,
  `Description` tinyint NOT NULL,
  `Item_Price` tinyint NOT NULL,
  `Discount` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `Order_Detail`
--

DROP TABLE IF EXISTS `Order_Detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Order_Detail` (
  `Order_ID` int(11) NOT NULL AUTO_INCREMENT,
  `User_ID` int(11) DEFAULT NULL,
  `Order_Sum` double NOT NULL,
  `Order_Cost` double NOT NULL,
  `Delivery` int(11) NOT NULL,
  `Shipment` int(11) NOT NULL,
  `Address` varchar(255) NOT NULL,
  `Order_Date` datetime NOT NULL,
  PRIMARY KEY (`Order_ID`),
  KEY `User_ID` (`User_ID`),
  CONSTRAINT `Order_Detail_ibfk_1` FOREIGN KEY (`User_ID`) REFERENCES `User` (`User_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=92308761 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Order_Detail`
--

LOCK TABLES `Order_Detail` WRITE;
/*!40000 ALTER TABLE `Order_Detail` DISABLE KEYS */;
INSERT INTO `Order_Detail` VALUES (8831576,5,70,20,1,1,'admin test address','2019-12-24 11:39:18'),(12717557,16,550,260,1,1,'台北科技大学二舍','2019-12-24 12:05:01'),(19526691,16,1720,860,2,2,'台北科技大学二舍','2019-12-24 12:06:47'),(26518667,NULL,270,120,1,2,'address for test','2019-12-24 22:53:09'),(31455309,5,190,80,1,1,'admin test address','2019-12-22 21:38:09'),(47900529,NULL,335,0,2,1,'address for abc','2019-12-24 22:48:16'),(50320768,5,70,20,1,1,'admin test address','2019-12-24 11:58:17'),(50974248,5,300,135,1,1,'admin test address','2019-12-25 16:30:11'),(66750075,5,70,20,1,1,'admin test address','2019-12-24 11:55:59'),(73946568,5,110,40,1,1,'admin test address','2019-12-24 21:27:58'),(85357890,NULL,210,105,2,2,'address for test','2019-12-24 22:53:50'),(86479936,NULL,310,140,1,1,'address for abc','2019-12-24 22:47:46');
/*!40000 ALTER TABLE `Order_Detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Order_List`
--

DROP TABLE IF EXISTS `Order_List`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Order_List` (
  `Order_ID` int(11) NOT NULL,
  `Item_ID` int(11) DEFAULT NULL,
  `Order_Price` double NOT NULL,
  `Order_Cost` double NOT NULL,
  `Quantity` int(11) NOT NULL,
  KEY `Order_ID` (`Order_ID`),
  KEY `Item_ID` (`Item_ID`),
  CONSTRAINT `Order_List_ibfk_1` FOREIGN KEY (`Order_ID`) REFERENCES `Order_Detail` (`Order_ID`),
  CONSTRAINT `Order_List_ibfk_2` FOREIGN KEY (`Item_ID`) REFERENCES `Item` (`Item_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Order_List`
--

LOCK TABLES `Order_List` WRITE;
/*!40000 ALTER TABLE `Order_List` DISABLE KEYS */;
INSERT INTO `Order_List` VALUES (31455309,1039,40,20,1),(31455309,1019,40,20,1),(31455309,1012,40,20,1),(31455309,1017,40,20,1),(8831576,1017,40,20,1),(66750075,1017,40,20,1),(50320768,1017,40,20,1),(12717557,1039,40,20,2),(12717557,1014,40,20,1),(12717557,1023,50,25,2),(12717557,1022,40,20,1),(12717557,1015,40,20,4),(12717557,1044,30,15,2),(12717557,1041,40,20,1),(19526691,1039,40,20,2),(19526691,1014,40,20,7),(19526691,1023,50,25,2),(19526691,1022,40,20,1),(19526691,1015,40,20,4),(19526691,1044,30,15,2),(19526691,1041,40,20,1),(19526691,1031,30,15,11),(19526691,1018,50,25,7),(19526691,1040,40,20,4),(19526691,1016,40,20,3),(73946568,1017,40,20,2),(86479936,1014,40,20,3),(86479936,1023,50,25,2),(86479936,1044,30,15,2),(47900529,1046,67,0,5),(26518667,1039,40,20,3),(26518667,1017,40,20,3),(85357890,1023,50,25,3),(85357890,1038,30,15,2),(50974248,1022,40,20,1),(50974248,1018,50,25,1),(50974248,1015,40,20,3),(50974248,1031,30,15,2);
/*!40000 ALTER TABLE `Order_List` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `Order_Top`
--

DROP TABLE IF EXISTS `Order_Top`;
/*!50001 DROP VIEW IF EXISTS `Order_Top`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `Order_Top` (
  `User_ID` tinyint NOT NULL,
  `User_Name` tinyint NOT NULL,
  `Order_ID` tinyint NOT NULL,
  `Order_Date` tinyint NOT NULL,
  `Order_Sum` tinyint NOT NULL,
  `Order_Cost` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `Review`
--

DROP TABLE IF EXISTS `Review`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Review` (
  `Review_ID` int(11) NOT NULL AUTO_INCREMENT,
  `User_ID` int(11) DEFAULT NULL,
  `Item_ID` int(11) NOT NULL,
  `Content` varchar(255) NOT NULL,
  `Recommend` tinyint(1) NOT NULL,
  `Date` datetime NOT NULL,
  PRIMARY KEY (`Review_ID`),
  KEY `User_ID` (`User_ID`),
  KEY `Item_ID` (`Item_ID`),
  CONSTRAINT `Review_ibfk_1` FOREIGN KEY (`User_ID`) REFERENCES `User` (`User_ID`),
  CONSTRAINT `Review_ibfk_2` FOREIGN KEY (`Item_ID`) REFERENCES `Item` (`Item_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Review`
--

LOCK TABLES `Review` WRITE;
/*!40000 ALTER TABLE `Review` DISABLE KEYS */;
/*!40000 ALTER TABLE `Review` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `Trace_Info`
--

DROP TABLE IF EXISTS `Trace_Info`;
/*!50001 DROP VIEW IF EXISTS `Trace_Info`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `Trace_Info` (
  `User_ID` tinyint NOT NULL,
  `User_Name` tinyint NOT NULL,
  `Item_ID` tinyint NOT NULL,
  `Item_Name` tinyint NOT NULL,
  `Item_Price` tinyint NOT NULL,
  `Discount` tinyint NOT NULL,
  `Trace_Price` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `Trace_List`
--

DROP TABLE IF EXISTS `Trace_List`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Trace_List` (
  `User_ID` int(11) NOT NULL,
  `Item_ID` int(11) DEFAULT NULL,
  `Trace_Price` double NOT NULL,
  UNIQUE KEY `User_ID` (`User_ID`,`Item_ID`),
  KEY `Item_ID` (`Item_ID`),
  CONSTRAINT `Trace_List_ibfk_1` FOREIGN KEY (`User_ID`) REFERENCES `User` (`User_ID`),
  CONSTRAINT `Trace_List_ibfk_2` FOREIGN KEY (`Item_ID`) REFERENCES `Item` (`Item_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Trace_List`
--

LOCK TABLES `Trace_List` WRITE;
/*!40000 ALTER TABLE `Trace_List` DISABLE KEYS */;
INSERT INTO `Trace_List` VALUES (5,1014,50),(15,1042,30),(15,1019,40),(15,1023,50),(16,1030,30),(16,1028,40),(16,1031,30),(16,1037,30),(16,1040,40),(16,1015,40),(16,1016,40),(16,1021,50),(15,1021,50),(16,1023,50),(15,1012,40),(16,1012,40),(16,1019,40),(16,1020,40),(16,1026,50),(16,1029,30),(16,1032,30),(16,1036,40),(16,1043,40),(16,1044,30),(16,1041,40),(5,NULL,500),(5,1046,100),(19,1012,40);
/*!40000 ALTER TABLE `Trace_List` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `User`
--

DROP TABLE IF EXISTS `User`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `User` (
  `User_ID` int(11) NOT NULL AUTO_INCREMENT,
  `User_Name` varchar(255) NOT NULL,
  `User_Password` varchar(255) NOT NULL,
  `First_Name` varchar(255) NOT NULL,
  `Last_Name` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `Address` varchar(255) NOT NULL,
  `Admin` tinyint(1) NOT NULL,
  PRIMARY KEY (`User_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `User`
--

LOCK TABLES `User` WRITE;
/*!40000 ALTER TABLE `User` DISABLE KEYS */;
INSERT INTO `User` VALUES (5,'admin','root','用户','管理员','admin@test.com','admin test address',1),(15,'test1','123','n','lin','1@qq.com','taipei',1),(16,'leo108','lushuang226','爽','盧','1369297565@qq.com','台北科技大学二舍',1),(19,'test','123456','BBB','AAA','test@test.com','Address for test user',0);
/*!40000 ALTER TABLE `User` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Current Database: `shop`
--

USE `shop`;

--
-- Final view structure for view `Item_Top`
--

/*!50001 DROP TABLE IF EXISTS `Item_Top`*/;
/*!50001 DROP VIEW IF EXISTS `Item_Top`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `Item_Top` AS select `Item`.`Item_ID` AS `Item_ID`,`Item`.`Item_Name` AS `Item_Name`,`Item`.`Description` AS `Description`,`Item`.`Item_Price` AS `Item_Price`,`Item`.`Discount` AS `Discount` from `Item` order by `Item`.`Cost` desc limit 0,10 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `Order_Top`
--

/*!50001 DROP TABLE IF EXISTS `Order_Top`*/;
/*!50001 DROP VIEW IF EXISTS `Order_Top`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `Order_Top` AS select `User`.`User_ID` AS `User_ID`,`User`.`User_Name` AS `User_Name`,`Order_Detail`.`Order_ID` AS `Order_ID`,`Order_Detail`.`Order_Date` AS `Order_Date`,`Order_Detail`.`Order_Sum` AS `Order_Sum`,`Order_Detail`.`Order_Cost` AS `Order_Cost` from (`Order_Detail` left join `User` on(`Order_Detail`.`User_ID` = `User`.`User_ID`)) order by `Order_Detail`.`Order_Sum` desc limit 0,5 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `Trace_Info`
--

/*!50001 DROP TABLE IF EXISTS `Trace_Info`*/;
/*!50001 DROP VIEW IF EXISTS `Trace_Info`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `Trace_Info` AS select `Trace_List`.`User_ID` AS `User_ID`,`User`.`User_Name` AS `User_Name`,`Item`.`Item_ID` AS `Item_ID`,`Item`.`Item_Name` AS `Item_Name`,`Item`.`Item_Price` AS `Item_Price`,`Item`.`Discount` AS `Discount`,`Trace_List`.`Trace_Price` AS `Trace_Price` from ((`Trace_List` left join `User` on(`Trace_List`.`User_ID` = `User`.`User_ID`)) left join `Item` on(`Trace_List`.`Item_ID` = `Item`.`Item_ID`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-12-25 21:23:18
