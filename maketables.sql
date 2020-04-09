create database bloodstorageapi;

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
    ClinicLocation varchar(50) not null,
    EmployeeID int not null,
    foreign key (EmployeeID) references bloodstorageapi.employee(EmployeeID)
);

create table bloodstorageapi.donor (
    DonorID int not null primary key auto_increment,
    Name varchar(50) not null,
    BloodType varchar(3) not null,
    RHFactor varchar(10) not null,
    Points int not null
);

create table bloodstorageapi.volunteer (
	VolunteerID int not null primary key auto_increment,
    Name varchar(50) not null,
    Role varchar(50) not null,
    Address varchar(50) not null,
    PhoneNumber varchar(10) not null,
    ClinicID int not null,
    foreign key (ClinicID) references bloodstorageapi.clinic(ClinicID)
);

create table bloodstorageapi.donation (
	DonationDate date not null,
    PointsEarned int not null,
    DonorID int not null,
    foreign key (DonorID) references bloodstorageapi.donor(DonorID)                           
);

create table bloodstorageapi.bloodstorage (
	BID int not null primary key auto_increment,
    ShelfLife date not null,
    BloodType varchar(3) not null,
    Shipped boolean not null
);

create table bloodstorageapi.events (
	EventDate date not null primary key,
    EventLocation varchar(50) not null,
    VolunteerID int,
    ClinicID int not null,
    EmployeeID int not null,
    foreign key (VolunteerID) references bloodstorageapi.volunteer(VolunteerID),
    foreign key (ClinicID) references bloodstorageapi.clinic(ClinicID),
    foreign key (EmployeeID) references bloodstorageapi.employee(EmployeeID)                                   
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
    ClinicID int not null,
    DateCompleted date not null,
    foreign key (ClinicID) references bloodstorageapi.clinic(ClinicID)
);

create table bloodstorageapi.prize (
	PID int not null primary key auto_increment,
    Quantity int not null,
    PointsPrice int not null
);



