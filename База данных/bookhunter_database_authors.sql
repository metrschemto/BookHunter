CREATE DATABASE  IF NOT EXISTS `bookhunter_database` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `bookhunter_database`;
-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: bookhunter_database
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `authors`
--

DROP TABLE IF EXISTS `authors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `authors` (
  `author_code` int NOT NULL AUTO_INCREMENT,
  `author_name` varchar(60) NOT NULL,
  `author_surname` varchar(60) NOT NULL,
  `author_patronymic` varchar(60) NOT NULL,
  PRIMARY KEY (`author_code`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `authors`
--

LOCK TABLES `authors` WRITE;
/*!40000 ALTER TABLE `authors` DISABLE KEYS */;
INSERT INTO `authors` VALUES (0,'Евгений','Водолазкин','Кимович'),(1,'Остап','Мясников','Кимович'),(2,'Май','Архипов','Константинович'),(3,'Абрам','Назаров','Геннадьевич'),(4,'Лавр','Мясников','Платонович'),(5,'Виталий','Воронов','Тихонович'),(6,'Рудольф','Архипов','Кимович'),(7,'Панкратий','Воронов','Тихонович'),(8,'Евдоким','Комаров','Антонович'),(9,'Велор','Фролов','Игнатьевич'),(10,'Севастьян','Буров','Пантелеймонович'),(11,'Константин','Князев','Денисович'),(12,'Флор','Савзонов','Серапионович'),(13,'Мстислав','Тихонов','Максович'),(14,'Марк','Маслов','Рубенович'),(15,'Леонтий','Тетерин','Федорович'),(16,'Жаклин','Архипова','Эдуардовна'),(17,'Фрида','Капустина','Дмитрьевна'),(18,'Уля','Воронова','Улебовна'),(19,'Алёна','Крюкова','Степановна'),(20,'Полина','Шарова','Григорьевна'),(21,'Гелла','Ширяева','Александровна'),(22,'Виталина','Колесникова','Святославовна'),(23,'Валентина','Семёновна','Данииловна'),(24,'Алина','Панфилова','Мироновна'),(25,'Каролина','Зыкова','Святославовна'),(26,'Фаня','Афанасьева','Богдановна'),(27,'Эжени','Панова','Дмитриевна'),(28,'Анжелика','Быкова','Германовна');
/*!40000 ALTER TABLE `authors` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-11-09 13:03:32
