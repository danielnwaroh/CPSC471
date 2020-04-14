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

DELIMITER ;

DROP procedure IF EXISTS `getEvent`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `getEvent`(IN paramEventDate date)
BEGIN
    select * from events
    where EventDate = paramEventDate;
        
END //

DELIMITER ;

DROP procedure IF EXISTS `addEvent`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `addEvent`(IN paramEventDate date, paramEventLocation varchar(50), paramClinicID int, paramManagerID int)
BEGIN
    INSERT into events (EventDate, EventLocation, ClinicID, EmployeeID) values (paramEventDate, paramEventLocation,paramClinicID, paramManagerID);
END //

DELIMITER ;

DROP procedure IF EXISTS `addPrizeTransaction`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `addPrizeTransaction`(IN paramDonorID int, paramPID int, OUT paramWork int)
BEGIN
    Set @pointsreq = (select PointsPrice from prize where prize.PID = paramPID);
    Set @pointshave = (select Points from donor where donor.DonorID = paramDonorID);
    Set @qty = (Select Quantity from prize where prize.PID = paramPID);
    
    If (@pointsreq<=@pointshave AND (@pointsreq != 0) AND (@qty > 0)) THEN
        Insert into prizetransaction (donorID, PID) values (paramDonorID, paramPID);
        Set paramWork = 1;
        CALL updateDonorQty(@pointsreq,@pointshave, paramDonorID, paramPID, @qty);
    Else 
        set ParamWork = 0;
    end if;
    
    set @pointsreq = null;
    set @pointshave = null;
    set @qty = null;
    
END //

DELIMITER ;

DROP procedure IF EXISTS `updateDonorQty`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `updateDonorQty`(IN paramrequired int, paramhave int, paramDonorID int, parampID int, paramqty int)
BEGIN
    UPDATE prize, donor
    set
        prize.Quantity = paramqty - 1, donor.Points = paramhave - paramrequired
    Where prize.PID = parampID AND donor.DonorID = paramDonorID;
END //

DELIMITER ;

DROP procedure  IF EXISTS `UpdatePrize`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdatePrize`(IN paramPID int, paramQuantity int, paramPointsPrice int)
BEGIN 
    UPDATE prize
        set prize.Quantity = paramQuantity, prize.PointsPrice = paramPointsPrice
    where prize.PID = paramPID;
end //

DELIMITER ;

DROP procedure  IF EXISTS `AddPrize`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddPrize`(IN paramQuantity int, paramPointsPrice int)
BEGIN
    Insert into prize (Quantity, PointsPrice) values (paramQuantity, paramPointsPrice);
end //

DELIMITER ;

DROP procedure  IF EXISTS `AddRequest`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddRequest`(IN paramDateBy date, paramDateReq date, paramClinicID int, paramHID int)
BEGIN
    Insert Into request (DateBy, DateReq, ClinicID, HospitalID, isApproved)
    values (paramDateBy, paramDateReq, paramClinicID, paramHID, false);
end //