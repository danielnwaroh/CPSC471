DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `new_procedure`(IN con CHAR(20))
BEGIN
	SELECT Name, BloodType FROM donor
    WHERE RHFactor = con;
END //

DELIMITER ;