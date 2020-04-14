DROP procedure IF EXISTS `getDonorByRHF`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `getDonorByRHF`(IN rhf CHAR(20))
BEGIN
    SELECT Name, BloodType FROM donor
    WHERE RHFactor = rhf;
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

DROP procedure IF EXISTS `getAllEmployeesOfClinic`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllEmployeesOfClinic`(IN paramClinicID int)
BEGIN
    SELECT * FROM employee
    WHERE ClinicID = paramClinicID;
END //

DELIMITER ;

DROP procedure IF EXISTS `addHospital`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `addHospital`(IN paramHospitalLocation varchar(50), paramHospitalName varchar(50))
BEGIN
    insert into hospital (HospitalLocation, HospitalName) values (paramHospitalLocation, paramHospitalName);
END //

DELIMITER ;

DROP procedure IF EXISTS `addEmployee`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `addEmployee`(IN paramAddress varchar(50), paramPhoneNumber varchar(50), paramName varchar(50), paramRole varchar(50), paramClinicID int)
BEGIN
    insert into employee (Address, PhoneNumber, Name, Role, ClinicID) values (paramAddress, paramPhoneNumber, paramName, paramRole, paramClinicID);
END //

DELIMITER ;

DROP procedure IF EXISTS `addBloodStorage`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `addBloodStorage`(IN paramShelfLife varchar(50), paramBloodType varchar(3), paramShipped boolean)
BEGIN
    SET @newid = (SELECT CAST(paramShelfLife AS date));
    insert into bloodstorage (ShelfLife, BloodType, Shipped) values (@newid, paramBloodType, paramShipped);
END //

DELIMITER ;

DROP procedure IF EXISTS `getAllEmployees`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllEmployees`()
BEGIN
    SELECT * FROM employee;
END //

DELIMITER ;

DROP procedure IF EXISTS `getAllDonors`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllDonors`()
BEGIN
    SELECT * FROM donor;
END //

DELIMITER ;

DROP procedure IF EXISTS `addDonor`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `addDonor`(IN paramName varchar(50), paramBloodType varchar(3), paramRHFactor varchar(10), paramPoints int)
BEGIN
    insert into donor (Name, BloodType, RHFactor, Points) values (paramName, paramBloodType, paramRHFactor, paramPoints);
END //

DELIMITER ;

DROP procedure IF EXISTS `updateHospitalName`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `updateHospitalName`(IN paramHID int, paramHospitalName varchar(50))
BEGIN
    update hospital
    set HospitalName = paramHospitalName
    where HID = paramHID;
END //

DELIMITER ;

DROP procedure IF EXISTS `updateDonorName`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `updateDonorName`(IN paramDonorID int, paramDonorName varchar(50))
BEGIN
    update donor
    set Name = paramDonorName
    where donorID = paramDonorID;
END //

DELIMITER ;

DROP procedure IF EXISTS `addDonorPoints`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `addDonorPoints`(IN paramDonorID int, paramDonorPoints int)
BEGIN
    update donor
    set Points = Points + paramDonorPoints
    where donorID = paramDonorID;
END //

DELIMITER ;

DROP procedure IF EXISTS `updateBloodStorage`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `updateBloodStorage`(IN paramBID int, paramShipped boolean)
BEGIN
    update bloodstorage
    set Shipped = paramShipped
    where BID = paramBID;
END //



DROP procedure IF EXISTS `getEvent`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `getEvent` (IN paramEventDate date)
BEGIN
    select * from events
    where EventDate = paramEventDate;
END //

DELIMITER ;

DROP procedure IF EXISTS `addEvent`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `addEvent` (IN paramEventDate date, paramEventLocation varchar(50), paramClinicID int, paramMangerID int)
BEGIN
    insert into events (eventdate, eventlocation, clinicid, ManagerID)
    values (paramEventDate,paramEventLocation,paramClinicID, paramMangerID);
END //

DELIMITER ;

DROP procedure IF EXISTS `addPrizeTransaction`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `addPrizeTransaction` (IN paramDonorID int, paramPID int)
BEGIN
    insert into prizeTransaction (donorID, PID)
    values (paramDonorID, paramPID);
END //

DELIMITER ;