USE FirstCrud

Create Table Customer(id int primary key identity(1,1),name varchar(20), location varchar(20),phone bigint)

insert into Customer values ('Georgi' , 'Haskovo', '0899897079')
insert into Customer values ('Persiana' , 'Haskovo', '0898671558')
insert into Customer values ('Nikola' , 'Haskovo', '0885826990')

Select * From Customer

CREATE PROCEDURE sp_viewAllCustomer
AS 
BEGIN
select id, name, location, phone from Customer
END

/*Creating stored procedure*/
CREATE PROCEDURE sp_insertupdate_customer(
@id int,
@name varchar(20),
@location varchar(20),
@phone bigint,
@idout int out
)
as
begin
if(@id=0)
begin
insert into Customer values (@name, @location, @phone)
set @idout=@@IDENTITY
end
else
begin
update customer set name=@name, location=@location, phone=@phone where id=@id
set @id=@idout
end
END

CREATE PROCEDURE sp_viewCustomerById
(@id int)
AS 
BEGIN
SELECT * FROM Customer where id = @id
END

CREATE PROCEDURE sp_customerDelete
(@id int)
AS
BEGIN
DELETE FROM Customer WHERE id = @id
END