use bloodstorageapi;

delete from volunteer;
alter table volunteer auto_increment = 1;

insert into volunteer (Name, Role, Address, PhoneNumber) values ('Daniel Nwaroh', 'Volunteer', '123 Some Rd NW', '123456789');
insert into volunteer (Name, Role, Address, PhoneNumber) values ('Lebron James', 'Supervisor', '123 Some Rd NW', '123456789');
insert into volunteer (Name, Role, Address, PhoneNumber) values ('Donald Trump', 'Supervisor', '123 White House Ave', '98765431');
insert into volunteer (Name, Role, Address, PhoneNumber) values ('Clark Kent', 'Volunteer', 'Kyrpton Street', '11111111');
insert into volunteer (Name, Role, Address, PhoneNumber) values ('Bruce Wayne', 'Volunteer', '50 Gotham Road', '99999999');

delete from bloodstorage;
alter table bloodstorage auto_increment = 1;

insert into bloodstorage (ShelfLife, BloodType, Shipped) values ('2020-07-16', 'A+', TRUE);
insert into bloodstorage (ShelfLife, BloodType, Shipped) values ('2020-06-16', 'O+', TRUE);
insert into bloodstorage (ShelfLife, BloodType, Shipped) values ('2020-05-16', 'B+', TRUE);
insert into bloodstorage (ShelfLife, BloodType, Shipped) values ('2020-08-16', 'O-', FALSE);
insert into bloodstorage (ShelfLife, BloodType, Shipped) values ('2020-09-16', 'A+', FALSE);

delete from clinic;
alter table clinic auto_increment = 1;

insert into clinic (PhoneNumber, ClinicLocation) values ('403737373', 'Calgary');
insert into clinic (PhoneNumber, ClinicLocation) values ('403737313', 'Edmonton');
insert into clinic (PhoneNumber, ClinicLocation) values ('403731111', 'Toronto');
insert into clinic (PhoneNumber, ClinicLocation) values ('403213273', 'Vancouver');
insert into clinic (PhoneNumber, ClinicLocation) values ('915232232', 'Banff');

delete from donation;

insert into donation (DonationDate, PointsEarned) values ('2020-04-09', 100);
insert into donation (DonationDate, PointsEarned) values ('2020-04-09', 50);
insert into donation (DonationDate, PointsEarned) values ('2020-04-09', 1020);
insert into donation (DonationDate, PointsEarned) values ('2020-04-09', 11);
insert into donation (DonationDate, PointsEarned) values ('2020-04-09', 0);

delete from donor;
alter table donor auto_increment = 1;

insert into donor (Name, BloodType, RHFactor, Points) values ('Peter Parker', 'A+', 'positive', 50);
insert into donor (Name, BloodType, RHFactor, Points) values ('Tony Stark', 'A-', 'negative', 50);
insert into donor (Name, BloodType, RHFactor, Points) values ('Barack Obama', 'O+', 'positive', 50);
insert into donor (Name, BloodType, RHFactor, Points) values ('Kanye West', 'A+', 'positive', 50);
insert into donor (Name, BloodType, RHFactor, Points) values ('Kevin Durant', 'B+', 'positive', 50);

delete from employee;
alter table employee auto_increment = 1;

insert into employee (Address, PhoneNumber, Name, Role) values ('1234 Rainbow Rd', '123456789', 'Employee One', 'Employee');
insert into employee (Address, PhoneNumber, Name, Role) values ('1234 Rainbow Rd', '123456789', 'Employee Two', 'Employee');
insert into employee (Address, PhoneNumber, Name, Role) values ('1234 Rainbow Rd', '123456789', 'Employee Three', 'Employee');
insert into employee (Address, PhoneNumber, Name, Role) values ('1234 Rainbow Rd', '123456789', 'Employee Four', 'Employee');
insert into employee (Address, PhoneNumber, Name, Role) values ('1234 Rainbow Rd', '123456789', 'Big Boss', 'Supervisor');

delete from events;

insert into events (EventDate, EventLocation) values ('2020-04-09', 'Calgary');
insert into events (EventDate, EventLocation) values ('2020-05-09', 'Calgary');
insert into events (EventDate, EventLocation) values ('2020-06-09', 'Calgary');
insert into events (EventDate, EventLocation) values ('2020-07-09', 'Calgary');
insert into events (EventDate, EventLocation) values ('2020-08-09', 'Calgary');

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

insert into request (DateBy, DateReq, DateCompleted) values ('2020-06-01', '2020-04-09', null);
insert into request (DateBy, DateReq, DateCompleted) values ('2020-06-02', '2020-04-09', null);
insert into request (DateBy, DateReq, DateCompleted) values ('2020-09-03', '2020-04-09', null);
insert into request (DateBy, DateReq, DateCompleted) values ('2020-07-04', '2020-04-09', null);
insert into request (DateBy, DateReq, DateCompleted) values ('2020-08-05', '2020-04-09', null);