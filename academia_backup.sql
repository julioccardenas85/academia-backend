-- MySQL dump 10.13  Distrib 8.0.25, for Win64 (x86_64)
--
-- Host: localhost    Database: academia
-- ------------------------------------------------------
-- Server version	8.0.25

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `academias`
--

DROP TABLE IF EXISTS `academias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `academias` (
  `idacademias` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `idDirecciones` int DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idacademias`),
  KEY `idDirecciones_idx` (`idDirecciones`),
  CONSTRAINT `idDirecciones3` FOREIGN KEY (`idDirecciones`) REFERENCES `direcciones` (`iddirecciones`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `academias`
--

LOCK TABLES `academias` WRITE;
/*!40000 ALTER TABLE `academias` DISABLE KEYS */;
INSERT INTO `academias` VALUES (1,'Danzmov',2,'3310482094'),(2,'Tudanzza',NULL,'3395820348'),(3,'R Evolution',NULL,'3301842983'),(4,'Cantare',NULL,'3364028402'),(5,'Pole Heart',NULL,'3374019483'),(6,'Inside Studio',NULL,'3395720472'),(7,'Gold Gym',NULL,'3302745932'),(8,'DanzCorp',NULL,'3395720948'),(9,'BailArte',NULL,'3302849203'),(10,'Evolución Latina',NULL,'3385937294');
/*!40000 ALTER TABLE `academias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `colonias`
--

DROP TABLE IF EXISTS `colonias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `colonias` (
  `idcolonias` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `idCPs` int NOT NULL,
  PRIMARY KEY (`idcolonias`),
  KEY `idCPs_idx` (`idCPs`),
  CONSTRAINT `idCPs` FOREIGN KEY (`idCPs`) REFERENCES `cps` (`idCPs`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `colonias`
--

LOCK TABLES `colonias` WRITE;
/*!40000 ALTER TABLE `colonias` DISABLE KEYS */;
INSERT INTO `colonias` VALUES (1,'Santa María Tequepexpan',1),(2,'San Sebastianito',1),(3,'Coto Arezzo',1),(4,'El Real',1),(5,'Geovillas Los Olivos',1),(6,'Hacienda Del Real',1),(7,'Jardines de Miraflores',1),(8,'La Gigantera',1),(9,'Prados de Santa María',1),(10,'Los Olivos de Tlaquepaque',1);
/*!40000 ALTER TABLE `colonias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cps`
--

DROP TABLE IF EXISTS `cps`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cps` (
  `idCPs` int NOT NULL AUTO_INCREMENT,
  `CP` varchar(10) NOT NULL,
  `idMunicipios` int NOT NULL,
  PRIMARY KEY (`idCPs`),
  KEY `idMunicipios_idx` (`idMunicipios`),
  CONSTRAINT `idMunicipios` FOREIGN KEY (`idMunicipios`) REFERENCES `municipios` (`idmunicipios`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cps`
--

LOCK TABLES `cps` WRITE;
/*!40000 ALTER TABLE `cps` DISABLE KEYS */;
INSERT INTO `cps` VALUES (1,'45601',2),(2,'45500',2),(3,'45629',2),(4,'45630',2),(5,'44970',1),(6,'44960',1),(7,'44820',1),(8,'44910',1),(9,'45235',3),(10,'45150',3);
/*!40000 ALTER TABLE `cps` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dias`
--

DROP TABLE IF EXISTS `dias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dias` (
  `iddias` int NOT NULL AUTO_INCREMENT,
  `dias` varchar(45) NOT NULL,
  PRIMARY KEY (`iddias`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dias`
--

LOCK TABLES `dias` WRITE;
/*!40000 ALTER TABLE `dias` DISABLE KEYS */;
INSERT INTO `dias` VALUES (1,'Lunes'),(2,'Martes'),(3,'Miércoles'),(4,'Jueves'),(5,'Viernes'),(6,'Sábado'),(7,'Domingo');
/*!40000 ALTER TABLE `dias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `direcciones`
--

DROP TABLE IF EXISTS `direcciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `direcciones` (
  `iddirecciones` int NOT NULL AUTO_INCREMENT,
  `calle` varchar(50) NOT NULL,
  `numero` varchar(50) NOT NULL,
  `idColonias` int NOT NULL,
  PRIMARY KEY (`iddirecciones`),
  KEY `idColonias_idx` (`idColonias`),
  CONSTRAINT `idColonias` FOREIGN KEY (`idColonias`) REFERENCES `colonias` (`idcolonias`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `direcciones`
--

LOCK TABLES `direcciones` WRITE;
/*!40000 ALTER TABLE `direcciones` DISABLE KEYS */;
INSERT INTO `direcciones` VALUES (1,'Hidalgo','179',1),(2,'Comonfort','270',1),(3,'Independencia','351',1),(4,'Zaragoza','532',1),(5,'Álvaro Obregón','364',1),(6,'16 de septiembre','342',1),(7,'Benito Juárez','23',2),(8,'Emiliano Zapata','53',2),(9,'Azaleas','35',7),(10,'Rosal','24',7);
/*!40000 ALTER TABLE `direcciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estados`
--

DROP TABLE IF EXISTS `estados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `estados` (
  `idestados` int NOT NULL AUTO_INCREMENT,
  `estado` varchar(45) NOT NULL,
  `idPaises` int NOT NULL,
  PRIMARY KEY (`idestados`),
  KEY `idPaises_idx` (`idPaises`),
  CONSTRAINT `idPaises` FOREIGN KEY (`idPaises`) REFERENCES `paises` (`idpaises`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estados`
--

LOCK TABLES `estados` WRITE;
/*!40000 ALTER TABLE `estados` DISABLE KEYS */;
INSERT INTO `estados` VALUES (1,'Jalisco',1),(2,'CDMX',1),(3,'Nuevo Leon',1),(4,'Estado de México',1),(5,'Baja California',1),(6,'Chihuahua',1),(7,'Sinaloa',1),(8,'Michoacán',1),(9,'Colima',1),(10,'Nayarit',1);
/*!40000 ALTER TABLE `estados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupos`
--

DROP TABLE IF EXISTS `grupos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `grupos` (
  `idgrupos` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `idInstructores` int DEFAULT NULL,
  PRIMARY KEY (`idgrupos`),
  KEY `idInstructores_idx` (`idInstructores`),
  CONSTRAINT `idInstructores` FOREIGN KEY (`idInstructores`) REFERENCES `instructores` (`idinstructores`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupos`
--

LOCK TABLES `grupos` WRITE;
/*!40000 ALTER TABLE `grupos` DISABLE KEYS */;
INSERT INTO `grupos` VALUES (1,'Hip Hop',1),(2,'Ritmos Latinos',1),(3,'Ballet',3),(4,'Jazz',4),(5,'Pole Dance',5),(6,'Gimnasia',9),(7,'Samba',8),(8,'Poms',4),(9,'Yoga',6),(10,'Belly Dance',7);
/*!40000 ALTER TABLE `grupos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `grupos_view`
--

DROP TABLE IF EXISTS `grupos_view`;
/*!50001 DROP VIEW IF EXISTS `grupos_view`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `grupos_view` AS SELECT 
 1 AS `idgrupos`,
 1 AS `nombre`,
 1 AS `idInstructores`,
 1 AS `instructor`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `horario_clases2`
--

DROP TABLE IF EXISTS `horario_clases2`;
/*!50001 DROP VIEW IF EXISTS `horario_clases2`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `horario_clases2` AS SELECT 
 1 AS `Día`,
 1 AS `Clase`,
 1 AS `hora`,
 1 AS `Nombre del Instructor`,
 1 AS `Apellido del Instructor`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `horarios`
--

DROP TABLE IF EXISTS `horarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `horarios` (
  `idhorarios` int NOT NULL AUTO_INCREMENT,
  `idGrupos` int NOT NULL,
  `idDias` int NOT NULL,
  `hora` time NOT NULL,
  `salon` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idhorarios`),
  KEY `idGrupos_idx` (`idGrupos`),
  KEY `idGrupos2_idx` (`idGrupos`),
  KEY `idDias_idx` (`idDias`),
  CONSTRAINT `idDias` FOREIGN KEY (`idDias`) REFERENCES `dias` (`iddias`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `idGrupos2` FOREIGN KEY (`idGrupos`) REFERENCES `grupos` (`idgrupos`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `horarios`
--

LOCK TABLES `horarios` WRITE;
/*!40000 ALTER TABLE `horarios` DISABLE KEYS */;
INSERT INTO `horarios` VALUES (1,1,1,'17:00:00',NULL),(2,1,3,'17:00:00',NULL),(3,2,1,'20:00:00',NULL),(4,2,2,'20:00:00',NULL),(5,2,3,'20:00:00',NULL),(6,2,4,'20:00:00',NULL),(7,2,5,'20:00:00',NULL),(8,3,2,'17:00:00',NULL),(9,3,4,'17:00:00',NULL),(10,4,2,'18:00:00',NULL),(11,4,4,'18:00:00',NULL);
/*!40000 ALTER TABLE `horarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instructores`
--

DROP TABLE IF EXISTS `instructores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `instructores` (
  `idinstructores` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `apellidos` varchar(45) NOT NULL,
  `fechaNacimiento` date DEFAULT NULL,
  `idDirecciones` int DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `usuario` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idinstructores`),
  UNIQUE KEY `usuario_UNIQUE` (`usuario`),
  KEY `idDirecciones4_idx` (`idDirecciones`),
  CONSTRAINT `idDirecciones4` FOREIGN KEY (`idDirecciones`) REFERENCES `direcciones` (`iddirecciones`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instructores`
--

LOCK TABLES `instructores` WRITE;
/*!40000 ALTER TABLE `instructores` DISABLE KEYS */;
INSERT INTO `instructores` VALUES (1,'JulioX','CardenasX','1985-12-08',1,'3314179351','jcardenasX'),(2,'Xochitl','Méndez','1995-06-15',NULL,'3395038592',NULL),(3,'Yahuitzin','Agraz','1996-02-20',NULL,'3395038520',NULL),(4,'Eduardo','Reyes','1994-03-13',NULL,'3392749204',NULL),(5,'Diana','Sánchez','1993-09-30',NULL,'3382648392',NULL),(6,'Claudia','Velarde','1979-05-10',NULL,'3352520759',NULL),(7,'Alejandra','Ochoa','1995-07-29',NULL,'3352694729',NULL),(8,'Ariel','García','1986-08-03',NULL,'3395729482',NULL),(9,'Christian','Bermudez','1990-02-25',NULL,'3359193027',NULL),(10,'Fabiola','Valencia','1983-10-23',NULL,'3301746282',NULL);
/*!40000 ALTER TABLE `instructores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `log_alumnos`
--

DROP TABLE IF EXISTS `log_alumnos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `log_alumnos` (
  `idlog_alumnos` int NOT NULL AUTO_INCREMENT,
  `accion` varchar(200) NOT NULL,
  `fecha` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idlog_alumnos`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log_alumnos`
--

LOCK TABLES `log_alumnos` WRITE;
/*!40000 ALTER TABLE `log_alumnos` DISABLE KEYS */;
INSERT INTO `log_alumnos` VALUES (1,'Se ingresó al alumno Alejandro Famoso','2022-05-18 05:28:49'),(3,'Se ingresó al alumno Gibran Ruiz','2022-05-18 05:46:16'),(4,'Se ingresó al alumno JULIO CARDENAS','2022-05-18 19:53:50'),(5,'Se ingresó al alumno Jesús Pérez Sánchez','2022-06-14 22:41:01'),(7,'Se ingresó al alumno test test','2024-04-03 01:42:02'),(17,'Se ingresó al alumno Julio Cesar Alvarado','2024-04-03 03:18:39'),(18,'Se ingresó al alumno Julio Cesar test','2024-04-03 03:30:43'),(19,'Se ingresó al alumno Arturo Zambrano','2024-07-06 20:06:48');
/*!40000 ALTER TABLE `log_alumnos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `matriculas`
--

DROP TABLE IF EXISTS `matriculas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `matriculas` (
  `idmatriculas` int NOT NULL AUTO_INCREMENT,
  `idUsuarios` int NOT NULL,
  `idGrupos` int NOT NULL,
  `fechaIngreso` date DEFAULT NULL,
  PRIMARY KEY (`idmatriculas`),
  KEY `idGrupos_idx` (`idGrupos`),
  CONSTRAINT `idGrupos` FOREIGN KEY (`idGrupos`) REFERENCES `grupos` (`idgrupos`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `matriculas`
--

LOCK TABLES `matriculas` WRITE;
/*!40000 ALTER TABLE `matriculas` DISABLE KEYS */;
INSERT INTO `matriculas` VALUES (1,3,3,'2021-06-01'),(2,3,4,'2021-06-01'),(3,3,8,'2021-06-01'),(4,4,3,'2021-08-02'),(5,4,4,'2021-08-02'),(6,4,8,'2021-08-02'),(7,5,3,'2021-11-03'),(8,5,4,'2021-11-03'),(9,5,8,'2021-11-03'),(10,8,1,'2022-01-04');
/*!40000 ALTER TABLE `matriculas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `matriculas_view`
--

DROP TABLE IF EXISTS `matriculas_view`;
/*!50001 DROP VIEW IF EXISTS `matriculas_view`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `matriculas_view` AS SELECT 
 1 AS `idmatriculas`,
 1 AS `idUsuarios`,
 1 AS `nombreAlumno`,
 1 AS `apellidos`,
 1 AS `idGrupos`,
 1 AS `nombreGrupo`,
 1 AS `fechaIngreso`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `municipios`
--

DROP TABLE IF EXISTS `municipios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `municipios` (
  `idmunicipios` int NOT NULL AUTO_INCREMENT,
  `municipio` varchar(45) NOT NULL,
  `idEstados` int NOT NULL,
  PRIMARY KEY (`idmunicipios`),
  KEY `idEstados_idx` (`idEstados`),
  CONSTRAINT `idEstados` FOREIGN KEY (`idEstados`) REFERENCES `estados` (`idestados`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `municipios`
--

LOCK TABLES `municipios` WRITE;
/*!40000 ALTER TABLE `municipios` DISABLE KEYS */;
INSERT INTO `municipios` VALUES (1,'Guadalajara',1),(2,'Tlaquepaque',1),(3,'Zapopan',1),(4,'Tonalá',1),(5,'Tlajomulco',1),(6,'El Salto',1),(7,'Monterrey',3),(8,'Apodaca',3),(9,'San Pedro Garza García',3),(10,'Tijuana',5);
/*!40000 ALTER TABLE `municipios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `padres`
--

DROP TABLE IF EXISTS `padres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `padres` (
  `idpadres` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `apellidos` varchar(50) NOT NULL,
  `idDirecciones` int DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idpadres`),
  KEY `idDirecciones_idx` (`idDirecciones`),
  CONSTRAINT `idDirecciones2` FOREIGN KEY (`idDirecciones`) REFERENCES `direcciones` (`iddirecciones`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `padres`
--

LOCK TABLES `padres` WRITE;
/*!40000 ALTER TABLE `padres` DISABLE KEYS */;
INSERT INTO `padres` VALUES (1,'Viridiana','Cárdenas',1,'3385939204'),(2,'Mayra','Hernández',9,'3393582048'),(3,'Cecilia','Pedroza',3,'3365354624'),(4,'Delia','Alvarado',1,'3376635895'),(5,'José','Gallardo',10,'3385368045'),(6,'Guadalupe','Sánchez',4,'3375357976'),(7,'Julia','Ochoa',5,'3374894510'),(8,'Cecilia','Haro',6,'3310297539'),(9,'Luz','Sahagún',7,'3374245234'),(10,'Rosalva','Alvarado',8,'3357326890');
/*!40000 ALTER TABLE `padres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagos`
--

DROP TABLE IF EXISTS `pagos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pagos` (
  `idpagos` int NOT NULL AUTO_INCREMENT,
  `idUsuarios` int NOT NULL,
  `fecha` date NOT NULL,
  `importe` float NOT NULL,
  `concepto` varchar(100) NOT NULL,
  `medioPago` varchar(20) NOT NULL,
  PRIMARY KEY (`idpagos`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagos`
--

LOCK TABLES `pagos` WRITE;
/*!40000 ALTER TABLE `pagos` DISABLE KEYS */;
INSERT INTO `pagos` VALUES (1,1,'2022-01-08',500,'Mensualidad','Efectivo'),(2,1,'2022-02-03',500,'Mensualidad','Efectivo'),(3,1,'2022-03-10',500,'Mensualidad','Efectivo'),(4,2,'2022-02-01',250,'Inscripción','TDC'),(5,2,'2022-02-01',500,'Mensualidad','TDC'),(6,2,'2022-03-04',500,'Mensualidad','TDC'),(7,3,'2022-03-01',250,'Inscripción','Efectivo'),(8,3,'2022-03-01',750,'Mensualidad','Efectivo'),(9,3,'2022-04-03',60,'Clase suelta','TDC'),(10,4,'2022-04-01',60,'Clase suelta','Efectivo');
/*!40000 ALTER TABLE `pagos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paises`
--

DROP TABLE IF EXISTS `paises`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paises` (
  `idpaises` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`idpaises`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paises`
--

LOCK TABLES `paises` WRITE;
/*!40000 ALTER TABLE `paises` DISABLE KEYS */;
INSERT INTO `paises` VALUES (1,'Mexico'),(2,'Estados Unidos'),(3,'España'),(4,'Colombia'),(5,'Cuba'),(6,'Canada'),(7,'Peru'),(8,'Brasil'),(9,'Francia'),(10,'Italia');
/*!40000 ALTER TABLE `paises` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `idroles` int NOT NULL AUTO_INCREMENT,
  `rol` varchar(45) NOT NULL,
  PRIMARY KEY (`idroles`),
  UNIQUE KEY `idroles_UNIQUE` (`idroles`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Administrador'),(2,'Instructor'),(3,'Alumno');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usernames`
--

DROP TABLE IF EXISTS `usernames`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usernames` (
  `idusernames` int NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `idUsuarios` int NOT NULL,
  PRIMARY KEY (`idusernames`),
  UNIQUE KEY `username_UNIQUE` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usernames`
--

LOCK TABLES `usernames` WRITE;
/*!40000 ALTER TABLE `usernames` DISABLE KEYS */;
INSERT INTO `usernames` VALUES (1,'Gib.Rui',13),(2,'JUL.CAR',14),(3,'Jes.Pér',15),(5,'tes.tes',17),(15,'Jul.Alv',27),(16,'Jul.tes',28),(17,'Art.Zam',29);
/*!40000 ALTER TABLE `usernames` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `idUsuarios` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `apellidos` varchar(50) NOT NULL,
  `fechaNacimiento` date DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `user` varchar(45) DEFAULT NULL,
  `contacto` varchar(45) DEFAULT NULL,
  `telefonoContacto` varchar(45) DEFAULT NULL,
  `idRoles` int DEFAULT NULL,
  PRIMARY KEY (`idUsuarios`),
  UNIQUE KEY `user_UNIQUE` (`user`),
  KEY `roles_idx` (`idRoles`),
  CONSTRAINT `roles` FOREIGN KEY (`idRoles`) REFERENCES `roles` (`idroles`)
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'Octavio','Alvarado','1995-12-28','3305784378','oalvarado',NULL,NULL,3),(2,'Pablo','Pérez','2016-09-02',NULL,NULL,NULL,NULL,3),(3,'Valeria','Pérez','2007-01-01',NULL,NULL,NULL,NULL,3),(4,'Daniela','González','2008-05-24',NULL,NULL,NULL,NULL,3),(5,'Evvy','Hernández','2008-09-10',NULL,NULL,NULL,NULL,3),(6,'Saori','Calles','2008-11-05',NULL,NULL,NULL,NULL,3),(7,'Lourdes','Alatorre','1992-05-30','3368456704',NULL,NULL,NULL,3),(8,'Jocelyn','Barragán','2000-12-12','3363136834',NULL,NULL,NULL,3),(9,'Fátima','Aguayo','2001-06-15','3315704683',NULL,NULL,NULL,3),(10,'Monserrat','Gutiérrez','2002-10-20','3320831941',NULL,NULL,NULL,3),(11,'Alejandro','Famoso','1992-04-27','3382048392',NULL,NULL,NULL,3),(13,'Gibran','Ruiz','1986-02-17','3327493748',NULL,NULL,NULL,3),(14,'JULIO','CARDENAS','1985-12-08','3333333333',NULL,'delia',NULL,1),(29,'Arturo','Zambrano','1986-12-30','3350493845',NULL,NULL,NULL,2);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `log_alumnos` AFTER INSERT ON `usuarios` FOR EACH ROW begin
	insert into log_alumnos(accion)
    value (concat('Se ingresó al alumno ', NEW.nombre, ' ', NEW.apellidos));
end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `user_name` AFTER INSERT ON `usuarios` FOR EACH ROW begin
	insert into usernames(username, idAlumnos)
    value (concat(LEFT(NEW.nombre,3), '.', LEFT(NEW.apellidos,3)), new.idalumnos);
end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `grupos_view`
--

/*!50001 DROP VIEW IF EXISTS `grupos_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `grupos_view` AS select `g`.`idgrupos` AS `idgrupos`,`g`.`nombre` AS `nombre`,`g`.`idInstructores` AS `idInstructores`,concat(`i`.`nombre`,' ',`i`.`apellidos`) AS `instructor` from (`grupos` `g` join `instructores` `i` on((`g`.`idInstructores` = `i`.`idinstructores`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `horario_clases2`
--

/*!50001 DROP VIEW IF EXISTS `horario_clases2`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `horario_clases2` AS select 1 AS `Día`,1 AS `Clase`,1 AS `hora`,1 AS `Nombre del Instructor`,1 AS `Apellido del Instructor` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `matriculas_view`
--

/*!50001 DROP VIEW IF EXISTS `matriculas_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `matriculas_view` AS select `m`.`idmatriculas` AS `idmatriculas`,`m`.`idUsuarios` AS `idUsuarios`,`a`.`nombre` AS `nombreAlumno`,`a`.`apellidos` AS `apellidos`,`m`.`idGrupos` AS `idGrupos`,`g`.`nombre` AS `nombreGrupo`,`m`.`fechaIngreso` AS `fechaIngreso` from ((`matriculas` `m` join `usuarios` `a` on((`m`.`idUsuarios` = `a`.`idUsuarios`))) join `grupos` `g` on((`m`.`idGrupos` = `g`.`idgrupos`))) */;
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

-- Dump completed on 2024-08-02  3:23:48
