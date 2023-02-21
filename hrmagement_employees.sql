CREATE DATABASE  IF NOT EXISTS `hrmagement` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `hrmagement`;
-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: hrmagement
-- ------------------------------------------------------
-- Server version	8.0.30

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
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `id_roles` int NOT NULL AUTO_INCREMENT,
  `rol_description` varchar(45) NOT NULL,
  PRIMARY KEY (`id_roles`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Worker'),(2,'Specialist'),(3,'Manager');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employees` (
  `emp_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `last_name` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `personal_address` varchar(60) NOT NULL,
  `phone` int DEFAULT NULL,
  `workin_start_date` date NOT NULL,
  `picture` enum('JPG','PNG') NOT NULL,
  `fk_rol` int NOT NULL,
  `salary` float NOT NULL,
  PRIMARY KEY (`emp_id`),
  KEY `fk_rol` (`fk_rol`),
  CONSTRAINT `fk_rol` FOREIGN KEY (`fk_rol`) REFERENCES `roles` (`id_roles`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;

DROP TABLE IF EXISTS `salary_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `salary_history` (
  `id_salary_history` int NOT NULL AUTO_INCREMENT,
  `salary_period` float NOT NULL,
  `date_salary_initial` date NOT NULL,
  `date_salary_end` date NOT NULL,
  `fk_id_employee` int NOT NULL,
  PRIMARY KEY (`id_salary_history`),
  KEY `fk_id_employee` (`fk_id_employee`),
  CONSTRAINT `fk_id_employee` FOREIGN KEY (`fk_id_employee`) REFERENCES `employees` (`emp_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salary_history`
--

LOCK TABLES `salary_history` WRITE;

--  HHHHHHHHHHHHHHHH DISPARADOR PARA INCERTAR EL PRIMER DATO EN  SALARY HISTORY
DELIMITER $$
CREATE TRIGGER incertFirstSalaryHistory
AFTER Insert ON hrmagement.employees
FOR EACH ROW
BEGIN
	INSERT INTO salary_history (salary_period,date_salary_initial,date_salary_end,fk_id_employee)
	VALUES (NEW.salary, NEW.workin_start_date, NEW.workin_start_date, NEW.emp_id);
END$$
DELIMITER ;



-- insert employees
DELIMITER //
CREATE PROCEDURE spInsertEmployee(IN p_name VARCHAR(45), in p_lastName VARCHAR(45), in p_email varchar(45), in p_personalAddres varchar (45), 
in p_phone int, in p_workStartDate date, in p_picture ENUM('PNG','JPG'), in p_rol int , p_salary float)
BEGIN
	insert into employees(name, last_name, email, personal_address, phone, workin_start_date, picture, fk_rol, salary) 
    values(p_name, p_lastName, p_email, p_personalAddres, p_phone, p_workStartDate, p_picture, p_Fk_rol, p_salary);
END//
DELIMITER ;
 CALL spInsertEmployee('Jose', 'Perez', 'perejo@hotmail.com', 'calle 12 2332', 32133332, '2020-03-25', 'JPG', 1, 1200);
 CALL spInsertEmployee('Mario', 'Casas', 'mariocas@gmail.com', 'calle 3 123', 3214152,	'2020-03-25', 'PNG', 1,	1200);  -- Worker
 CALL spInsertEmployee('Camila', 'Villegas', 'camiville@gmail.com', 'calle 2 321', 3204162,	'2021-02-20', 'PNG', 1,	1200);
 CALL spInsertEmployee('Martina', 'Cabello', 'marticab@gmail.com', 'carrera 1 3n 21', 30012322,	'2023-01-12', 'JPG', 1,	1200);
 CALL spInsertEmployee('Camilo', 'Cadena', 'camcam@gmail.com', 'carrera 3 1234',, '2019-02-20', 'JPG' ,2 , 3457	);-- Specialist
 CALL spInsertEmployee('Iban', 'Restrepo', 'ibares@gmail.com', 'calle 3 14 34',3212212, '2022-10-11', 'PNG' ,2 , 3457);
 CALL spInsertEmployee('Blanca', 'Orejuela', 'blancaore@gmail.com', 'calle 8 12-34',3212823, '2012-02-20', 'JPG' ,2 , 3457);
 CALL spInsertEmployee('Ester', 'Ortiz', 'esteorti@gmail.com', 'calle 12 20-18',30012345, '2020-09-18', 'PNG' ,2 , 3457);
 CALL spInsertEmployee('Rodrigo', 'Castro', 'rocas@gmail.com', 'carrera 10 04-08',31754867, '2021-03-16', 'PNG' ,3 , 5660);
 CALL spInsertEmployee('Ester', 'Ortiz', 'esteorti@gmail.com', 'calle 05 40-38',31690234, '2022-09-18', 'JPG' ,3 , 5660);
 
 -- actualizar empleado 
 DELIMITER //
CREATE PROCEDURE spUpdateEmployees(IN id_emp int, IN p_name VARCHAR(45), in p_lastName VARCHAR(45), in p_email varchar(45), in p_personalAddres varchar (45), 
in p_phone int, in p_workStartDate date, in p_picture ENUM('PNG','JPG'), in p_rol int , p_salary float)
BEGIN
	update employees
	set usu_correo=p_mail, usu_contraseña=p_password, usu_salt=p_salt, usu_estado=p_state
    where usu_id=p_id;
END//
DELIMITER ;
-- consultar todos los empleados
DELIMITER //
CREATE PROCEDURE spExportEmployees()
Begin 
	SELECT employees.name,employees.last_name, employees.personal_address, employees.phone, employees.workin_start_date, employees.picture,
	 roles.rol_description, employees.salary
	 FROM hrmagement.employees
	 inner join hrmagement.roles
	 where roles.id_roles= employees.fk_rol;
END//
DELIMITER ;

-- eliminar empleado
DELIMITER //
CREATE PROCEDURE spDeleteEmployee(IN p_emp_id INT)
BEGIN
delete from employees where employees.emp_id = p_emp_id;
END//
DELIMITER ;

-- exportar datos de empleados
DELIMITER //
CREATE PROCEDURE spExport_dataEmployees()
BEGIN
   SELECT  employees.name,employees.last_name, employees.personal_address, employees.phone, employees.workin_start_date, employees.picture,
	 roles.rol_description, employees.salary
   INTO OUTFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/exportData.csv' -- Ruta donde se genera el archivo csv
   FIELDS TERMINATED BY ','
   LINES TERMINATED BY '\n'
   FROM employees
   inner join hrmagement.roles
	 where roles.id_roles= employees.fk_rol;
END//
DELIMITER ;


-- exportar datos de aumentos de salario 
DELIMITER //
CREATE PROCEDURE spExport_data_salary(IN id_employ int)
BEGIN

   SELECT  salary_period, date_salary_initial, date_salary_end, employees.name, employees.last_name, 
	  roles.rol_description
   INTO OUTFILE  'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/exportData.csv' -- se cambia por el nombre del archibo
   FIELDS TERMINATED BY ','
   LINES TERMINATED BY '\n'
   FROM salary_history
   inner join hrmagement.employees
   inner join hrmagement.roles
   where salary_history.fk_id_employee=employees.emp_id and roles.id_roles= employees.fk_rol  and employees.emp_id=id_employ;
END//
DELIMITER ;

-- recalcular salario.

DELIMITER //

CREATE PROCEDURE sp_recalculate_salary(IN sp_Emp_id INT)
BEGIN
  DECLARE today DATE;
  DECLARE elapsed_months INT; -- transcurrido elapsted
  DECLARE salary_increase DECIMAL(10, 2);
  DECLARE current_salary DECIMAL(10, 2);
  
  
  select employees.emp_id, employees.salary, employees.workin_start_date, roles.rol_description
  INTO @emp_id, @salary, @workin_start_datespExport_data_salarysp_recalculate_salarysp_recalculate_salary, @rol_description
  from employees
  inner join roles
  where roles.id_roles=employees.fk_rol and emp_id=sp_Emp_id;
  
  Select date_salary_end 
  into @date_salary_end
  from salary_history
	WHERE date_salary_end  = (
    SELECT MAX(date_salary_end) 
    FROM salary_history 
	) and salary_history.fk_id_employee=sp_Emp_id;
  
  
  SELECT CURDATE() INTO today;
  
  SET elapsed_months = TIMESTAMPDIFF(MONTH, @date_salary_end, today);  -- last revision
  
  IF elapsed_months < 3 THEN
    SELECT 'No salary update necessary.';
  ELSE
    SET salary_increase = CASE @rol_description
      WHEN 'Worker' THEN 0.05
      WHEN 'Specialist' THEN 0.08
      WHEN 'Manager' THEN 0.12
    END;
    
    SET current_salary = @salary;
    
    WHILE elapsed_months >= 3 DO
      SET current_salary = current_salary * (1 + salary_increase);
      SET elapsed_months = elapsed_months - 3;
    END WHILE;
    
    UPDATE employees
    SET salary = current_salary
    WHERE employees.emp_id = sp_Emp_id;
    
    insert into salary_history (salary_period,date_salary_initial,date_salary_end,fk_id_employee )
			values(current_salary, @date_salary_end, today, sp_Emp_id);
    
    SELECT CONCAT('Salary updated to ', FORMAT(current_salary, 2));
  END IF;
END //
DELIMITER ;

-- call sp_recalculate_salary(1)


-- Dump completed on 2023-02-19  8:57:45
