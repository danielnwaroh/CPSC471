create database if not exists bloodstorageapi;

create table bloodstorageapi.volunteer (
	VolunteerID int not null primary key auto_increment,
    Name varchar(50) not null,
    Role varchar(50) not null,
    Address varchar(50) not null,
    PhoneNumber varchar(10) not null 
);

create table bloodstorageapi.donation (
	DonationDate date not null,
    PointsEarned int not null
);

create table bloodstorageapi.bloodstorage (
	BID int not null primary key auto_increment,
    ShelfLife date not null,
    BloodType varchar(3) not null,
    Shipped boolean not null
);

create table bloodstorageapi.events (
	EventDate date not null primary key,
    EventLocation varchar(50) not null
);

create table bloodstorageapi.hospital (
	HID int not null primary key auto_increment,
    HospitalLocation varchar(50) not null,
    HospitalName varchar(50) not null
);

create table bloodstorageapi.request (
	RequestID int not null primary key auto_increment,
    DateBy date not null,
    DateReq date not null,
    DateCompleted date
);

create table bloodstorageapi.prize (
	PID int not null primary key auto_increment,
    Quantity int not null,
    PointsPrice int not null
);

create table bloodstorageapi.donor (
	DonorID int not null primary key auto_increment,
    Name varchar(50) not null,
    BloodType varchar(3) not null,
    RHFactor varchar(10) not null,
    Points int not null
);

create table bloodstorageapi.employee (
	EmployeeID int not null primary key auto_increment,
    Address varchar(50) not null,
    PhoneNumber varchar(10) not null,
    Name varchar(50) not null,
    Role varchar(50) not null
);

create table bloodstorageapi.clinic (
	PhoneNumber int not null,
	ClinicID int not null primary key auto_increment,
    ClinicLocation varchar(50) not null
);