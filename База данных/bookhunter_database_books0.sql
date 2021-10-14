-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: localhost    Database: bookhunter_database
-- ------------------------------------------------------
-- Server version	8.0.18

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `books`
--

DROP TABLE IF EXISTS `books`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `books` (
  `book_code` int(11) NOT NULL AUTO_INCREMENT,
  `book_name` varchar(60) NOT NULL,
  `book_genre` int(11) NOT NULL,
  `book_author` int(11) NOT NULL,
  `book_count_in_storage` int(11) NOT NULL,
  `book_cost` int(11) NOT NULL,
  `publishing_house` int(11) NOT NULL,
  `age_restriction` int(11) NOT NULL,
  `publishing_year` int(11) NOT NULL,
  `pages_count` int(11) NOT NULL,
  `book_circulation` int(11) NOT NULL,
  `book_image_path` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`book_code`),
  KEY `author_key_idx` (`book_author`),
  KEY `publishing_house_key_idx` (`publishing_house`),
  KEY `restriction_key_idx` (`age_restriction`),
  KEY `genre_key_idx` (`book_genre`),
  CONSTRAINT `author_key` FOREIGN KEY (`book_author`) REFERENCES `authors` (`author_code`),
  CONSTRAINT `genre_key` FOREIGN KEY (`book_genre`) REFERENCES `genres` (`genre_code`),
  CONSTRAINT `publishing_house_key` FOREIGN KEY (`publishing_house`) REFERENCES `publishing_houses` (`publishing_house_code`),
  CONSTRAINT `restriction_key` FOREIGN KEY (`age_restriction`) REFERENCES `age_restrictions` (`restriction_code`)
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `books`
--

LOCK TABLES `books` WRITE;
/*!40000 ALTER TABLE `books` DISABLE KEYS */;
INSERT INTO `books` VALUES (1,'Алиса в зазеркалье',8,26,592,155,0,0,1998,85,12000,NULL),(2,'Хоббит Толкин',15,16,100,211,6,2,2012,198,5000,NULL),(3,'Виноваты звезды',5,10,264,512,9,2,2019,258,11500,NULL),(4,'Денискины рассказы',9,0,175,376,4,1,2011,275,15000,NULL),(5,'Зажечь небеса',0,6,75,417,15,2,2016,167,7500,NULL),(6,'Букварь',6,7,400,292,13,0,2000,54,15000,NULL),(7,'Как научить ребенка читать',3,28,363,155,10,0,2008,127,3500,NULL),(8,'Один на льдине',11,22,185,562,2,1,1978,293,12300,NULL),(9,'Мертвец',2,1,93,298,14,3,2014,186,2700,NULL),(10,'Оригами',9,24,312,945,13,0,2003,127,4500,NULL),(11,'Подсознание может все!',2,7,682,428,5,1,2018,87,7000,NULL),(12,'Русские пословицы и поговорки в иллюстрациях',4,8,723,568,12,0,2000,228,3000,NULL),(13,'Война и мир',6,3,935,211,5,2,1999,907,5000,NULL),(14,'Ведьмак',5,7,56,816,7,2,2008,765,6000,NULL),(15,'Пелагия и черный монах',10,13,78,248,1,1,2001,472,7500,NULL),(16,'Сердце сумрака',8,15,764,350,7,2,2007,832,5000,NULL),(17,'НЕ НОЙ',10,6,257,594,3,2,2012,287,5800,NULL),(18,'Гарри Поттер и Кубок Огня',1,5,678,676,0,1,2003,794,13400,NULL),(19,'Текст',7,4,876,562,4,3,2017,486,3500,NULL),(20,'Метро 2033',5,25,784,1729,8,2,2021,285,10000,NULL),(21,'Очень странные дела',7,2,542,396,2,1,2019,185,12400,NULL),(22,'Кира и секрет бублика',6,8,215,289,12,0,2005,124,2000,NULL),(23,'Всё хренова',9,21,175,545,6,3,2016,231,4300,NULL),(24,'Буря мечей',15,16,200,145,11,1,2008,146,3500,NULL),(25,'Iphuck 10',12,4,164,395,3,2,2019,218,5400,NULL),(26,'Горе от ума',4,12,137,177,7,0,1994,85,7000,NULL),(27,'Волшебная гора',3,18,374,287,5,1,2005,173,3500,NULL),(28,'Коран',1,23,284,1562,8,0,1999,418,6000,NULL),(29,'Школьные приколы',14,9,216,127,1,0,2004,123,2000,NULL),(30,'Отцы и дети',12,14,679,195,3,1,2005,562,4500,NULL),(31,'На пятьдесят оттенков темнее',9,2,472,254,5,3,2009,678,3000,NULL),(32,'3000 заданий по английскому языку',6,3,489,90,4,0,2015,193,4800,NULL),(33,'Безмолвный пациент',10,2,579,380,1,2,2020,405,6700,NULL),(34,'Легкий способ выучить Java',1,4,532,781,3,1,2021,348,12000,NULL),(35,'Наука о сексе',9,6,666,784,14,3,2018,69,69000,NULL),(36,'Библия',1,4,228,997,12,0,1998,234,12000,NULL),(37,'Внутри убийцы',0,6,753,457,4,3,2007,491,4700,NULL),(38,'Гнев ангелов',6,7,256,155,3,2,1996,647,3800,NULL),(39,'Муха с татухой',2,3,637,151,7,3,2003,596,11000,NULL),(40,'Голодный дом',5,2,317,150,6,2,2015,160,5000,NULL),(41,'Лисичкин хлеб',11,8,182,126,2,0,2000,75,2500,NULL),(42,'Обратная сторона успеха',4,25,263,155,15,3,2018,152,7300,NULL),(43,'Отец',0,24,184,714,8,3,2019,998,5258,NULL),(44,'Гарри Поттер и Тайная комната',1,5,800,567,12,1,2001,642,10000,NULL);
/*!40000 ALTER TABLE `books` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-10-13 16:39:52
