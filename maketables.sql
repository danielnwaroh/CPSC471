create table Volunteer (
	VolunteerID int not null primary key auto_increment,
    Name varchar(50) not null,
    Role varchar(50) not null,
    Address varchar(50) not null,
    PhoneNumber varchar(10) not null 
);

create table Donation (
	DonationDate date not null,
    PointsEarned int not null
);

create table BloodStorage (
	BID int not null primary key auto_increment,
    ShelfLife date not null,
    BloodType varchar(3) not null,
    Shipped boolean not null
);

create table Events (
	EventDate date not null primary key,
    EventLocation varchar(50) not null
);

create table Hospital (
	HID int not null primary key auto_increment,
    HospitalLocation varchar(50) not null,
    HospitalName varchar(50) not null
);

create table Request (
	RequestID int not null primary key auto_increment,
    DateBy date not null,
    DateReq date not null,
    DateCompleted date not null
);

create table Prize (
	PID int not null primary key auto_increment,
    Quantity int not null,
    PointsPrice int not null
);

create table Donor (
	DonorID int not null primary key auto_increment,
    Name varchar(50) not null,
    BloodType varchar(3) not null,
    RHFactor varchar(10) not null,
    Points int not null
);

create table Employee (
	EmployeeID int not null primary key auto_increment,
    Address varchar(50) not null,
    PhoneNumber varchar(10) not null,
    Name varchar(50) not null,
    Role varchar(50) not null
);

create table Clinic (
	PhoneNumber int not null,
	ClinicID int not null primary key auto_increment,
    ClinicLocation varchar(50) not null
);