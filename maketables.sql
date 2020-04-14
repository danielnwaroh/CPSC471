create database if not exists bloodstorageapi;

create table bloodstorageapi.employee (
    EmployeeID int not null primary key auto_increment,
    Address varchar(50) not null,
    PhoneNumber varchar(10) not null,
    Name varchar(50) not null,
    Role varchar(50) not null,
    ClinicID int not null
);

create table bloodstorageapi.clinic (
    PhoneNumber int not null,
    ClinicID int not null primary key auto_increment,
    ClinicLocation varchar(50) not null,
    ManagerID int not null,
    foreign key (ManagerID) references bloodstorageapi.employee(EmployeeID)
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
    ClinicID int not null,
    ManagerID int not null,
    foreign key (ClinicID) references bloodstorageapi.clinic(ClinicID),
    foreign key (ManagerID) references bloodstorageapi.employee(EmployeeID)
);

create table bloodstorageapi.eventVolunteers (
    EventDate date not null,
    VolunteerID int not null,
    foreign key (EventDate) references bloodstorageapi.events(EventDate),
    foreign key (VolunteerID) references bloodstorageapi.volunteer(VolunteerID)
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
    DateCompleted date,
    HospitalID int not null,
    foreign key (ClinicID) references bloodstorageapi.clinic(ClinicID),
    foreign key (HospitalID) references bloodstorageapi.hospital(HID)
);

create table bloodstorageapi.prize (
	PID int not null primary key auto_increment,
    Quantity int not null,
    PointsPrice int not null
);

create table bloodstorageapi.prizetransaction (
    TID int not null primary key auto_increment,
    donorID int not null,
    PID int not null,
    foreign key (donorID) references bloodstorageapi.donor(DonorID),
    foreign key (PID) references bloodstorageapi.prize(PID)
);

use bloodstorageapi;

delete from employee;
alter table employee auto_increment = 1;

insert into employee (Address, PhoneNumber, Name, Role, ClinicID) values ('1234 Rainbow Rd', '123456789', 'Employee One', 'Employee', 1);
insert into employee (Address, PhoneNumber, Name, Role, ClinicID) values ('1234 Rainbow Rd', '123456789', 'Employee Two', 'Employee', 1);
insert into employee (Address, PhoneNumber, Name, Role, ClinicID) values ('1234 Rainbow Rd', '123456789', 'Employee Three', 'Employee', 1);
insert into employee (Address, PhoneNumber, Name, Role, ClinicID) values ('1234 Rainbow Rd', '123456789', 'Employee Four', 'Employee', 1);
insert into employee (Address, PhoneNumber, Name, Role, ClinicID) values ('1234 Rainbow Rd', '123456789', 'Big Boss', 'Supervisor', 1);

delete from clinic;
alter table clinic auto_increment = 1;

insert into clinic (PhoneNumber, ClinicLocation, ManagerID) values ('403737373', 'Calgary', 5);
insert into clinic (PhoneNumber, ClinicLocation, ManagerID) values ('403737313', 'Edmonton', 5);
insert into clinic (PhoneNumber, ClinicLocation, ManagerID) values ('403731111', 'Toronto', 5);
insert into clinic (PhoneNumber, ClinicLocation, ManagerID) values ('403213273', 'Vancouver', 5);
insert into clinic (PhoneNumber, ClinicLocation, ManagerID) values ('915232232', 'Banff', 5);


delete from volunteer;
alter table volunteer auto_increment = 1;

insert into volunteer (Name, Role, Address, PhoneNumber, ClinicID) values ('Daniel Nwaroh', 'Volunteer', '123 Some Rd NW', '123456789', 1);
insert into volunteer (Name, Role, Address, PhoneNumber, ClinicID) values ('Lebron James', 'Supervisor', '123 Some Rd NW', '123456789', 1);
insert into volunteer (Name, Role, Address, PhoneNumber, ClinicID) values ('Donald Trump', 'Supervisor', '123 White House Ave', '98765431', 1);
insert into volunteer (Name, Role, Address, PhoneNumber, ClinicID) values ('Clark Kent', 'Volunteer', 'Kyrpton Street', '11111111', 1);
insert into volunteer (Name, Role, Address, PhoneNumber, ClinicID) values ('Bruce Wayne', 'Volunteer', '50 Gotham Road', '99999999', 1);

delete from bloodstorage;
alter table bloodstorage auto_increment = 1;

insert into bloodstorage (ShelfLife, BloodType, Shipped) values ('2020-07-16', 'A+', TRUE);
insert into bloodstorage (ShelfLife, BloodType, Shipped) values ('2020-06-16', 'O+', TRUE);
insert into bloodstorage (ShelfLife, BloodType, Shipped) values ('2020-05-16', 'B+', TRUE);
insert into bloodstorage (ShelfLife, BloodType, Shipped) values ('2020-08-16', 'O-', FALSE);
insert into bloodstorage (ShelfLife, BloodType, Shipped) values ('2020-09-16', 'A+', FALSE);

delete from donor;
alter table donor auto_increment = 1;

insert into donor (Name, BloodType, RHFactor, Points) values ('Peter Parker', 'A+', 'positive', 50);
insert into donor (Name, BloodType, RHFactor, Points) values ('Tony Stark', 'A-', 'negative', 50);
insert into donor (Name, BloodType, RHFactor, Points) values ('Barack Obama', 'O+', 'positive', 50);
insert into donor (Name, BloodType, RHFactor, Points) values ('Kanye West', 'A+', 'positive', 50);
insert into donor (Name, BloodType, RHFactor, Points) values ('Kevin Durant', 'B+', 'positive', 50);


delete from donation;

insert into donation (DonationDate, PointsEarned, DonorID) values ('2020-04-09', 100, 1);
insert into donation (DonationDate, PointsEarned, DonorID) values ('2020-04-09', 50, 2);
insert into donation (DonationDate, PointsEarned, DonorID) values ('2020-04-09', 1020, 3);
insert into donation (DonationDate, PointsEarned, DonorID) values ('2020-04-09', 11, 4);
insert into donation (DonationDate, PointsEarned, DonorID) values ('2020-04-09', 0, 5);


delete from events;

insert into events (EventDate, EventLocation, ClinicID, ManagerID) values ('2020-04-09', 'Calgary', 1, 1);
insert into events (EventDate, EventLocation, ClinicID, ManagerID) values ('2020-05-09', 'Calgary', 2, 2);
insert into events (EventDate, EventLocation, ClinicID, ManagerID) values ('2020-06-09', 'Calgary', 3, 3);
insert into events (EventDate, EventLocation, ClinicID, ManagerID) values ('2020-07-09', 'Calgary', 4, 4);
insert into events (EventDate, EventLocation, ClinicID, ManagerID) values ('2020-08-09', 'Calgary', 5, 5);

delete from eventVolunteers;

insert into eventVolunteers (EventDate, VolunteerID) values ('2020-04-09', 1);
insert into eventVolunteers (EventDate, VolunteerID) values ('2020-04-09', 2);
insert into eventVolunteers (EventDate, VolunteerID) values ('2020-05-09', 1);
insert into eventVolunteers (EventDate, VolunteerID) values ('2020-05-09', 2);
insert into eventVolunteers (EventDate, VolunteerID) values ('2020-05-09', 3);
insert into eventVolunteers (EventDate, VolunteerID) values ('2020-06-09', 4);
insert into eventVolunteers (EventDate, VolunteerID) values ('2020-06-09', 5);
insert into eventVolunteers (EventDate, VolunteerID) values ('2020-07-09', 1);
insert into eventVolunteers (EventDate, VolunteerID) values ('2020-07-09', 2);
insert into eventVolunteers (EventDate, VolunteerID) values ('2020-07-09', 4);
insert into eventVolunteers (EventDate, VolunteerID) values ('2020-08-09', 4);
insert into eventVolunteers (EventDate, VolunteerID) values ('2020-08-09', 5);

delete from hospital;
alter table hospital auto_increment = 1;

insert into hospital (HospitalLocation, HospitalName) values ('Calgary', 'Foothills Hospital');
insert into hospital (HospitalLocation, HospitalName) values ('Calgary', 'Childrens Hospital');
insert into hospital (HospitalLocation, HospitalName) values ('Toronto', 'St Johns Hospital');
insert into hospital (HospitalLocation, HospitalName) values ('Edmonton', 'Edmonton Hospital');
insert into hospital (HospitalLocation, HospitalName) values ('Calgary', 'Nenshi Hospital');

delete from prize;
alter table prize auto_increment = 1;

insert into prize (Quantity, PointsPrice) values (100, 100);
insert into prize (Quantity, PointsPrice) values (50, 100);
insert into prize (Quantity, PointsPrice) values (1, 1000);
insert into prize (Quantity, PointsPrice) values (100, 100);
insert into prize (Quantity, PointsPrice) values (100, 100);

delete from request;
alter table request auto_increment = 1;

insert into request (DateBy, DateReq, DateCompleted, ClinicID, HospitalID) values ('2020-06-01', '2020-04-09', null, 1, 1);
insert into request (DateBy, DateReq, DateCompleted, ClinicID, HospitalID) values ('2020-06-02', '2020-04-09', null, 2, 2);
insert into request (DateBy, DateReq, DateCompleted, ClinicID, HospitalID) values ('2020-09-03', '2020-04-09', null, 3, 3);
insert into request (DateBy, DateReq, DateCompleted, ClinicID, HospitalID) values ('2020-07-04', '2020-04-09', null, 4, 4);
insert into request (DateBy, DateReq, DateCompleted, ClinicID, HospitalID) values ('2020-08-05', '2020-04-09', null, 5, 5);

delete from prizetransaction;
alter table prizetransaction auto_increment = 1;

insert into prizetransaction (donorid, pid) values (1,3);
insert into prizetransaction (donorid, pid) values (2,1);
insert into prizetransaction (donorid, pid) values (2,2);
insert into prizetransaction (donorid, pid) values (3,5);
insert into prizetransaction (donorid, pid) values (5,2);