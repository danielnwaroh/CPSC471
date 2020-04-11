DROP procedure IF EXISTS `new_procedure`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `new_procedure`(IN con CHAR(20))
BEGIN
	SELECT Name, BloodType FROM donor
    WHERE RHFactor = con;
END //

DELIMITER ;

DROP procedure IF EXISTS `getBloodStorage`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `getBloodStorage`()
BEGIN
	SELECT * FROM bloodstorage;
END //

DELIMITER ;

DROP procedure IF EXISTS `getDonorInfo`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `getDonorInfo`(IN potentialdonorID int)
BEGIN
	SELECT * FROM donor
    WHERE DonorID = potentialdonorID;
END //

DELIMITER ;

DROP procedure IF EXISTS `getHospitalInfo`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `getHospitalInfo`(IN paramHID int)
BEGIN
	SELECT * FROM hospital
    WHERE HID = paramHID;
END //

DELIMITER ;

DROP procedure IF EXISTS `getEmployeeInfo`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `getEmployeeInfo`(IN paramEmployeeID int)
BEGIN
	SELECT * FROM employee
    WHERE EmployeeID = paramEmployeeID;
END //

DELIMITER ;