use Railway_Reservation

-- creating table for Ticketbooking
create table Bookings
(
Train_id int references Trains(Train_no),
PNR_No int primary key,
Passenger_name varchar(20),
Age int,
Gender varchar(12),
Class varchar(30),
Berth varchar(20),
Source varchar(20),
Destination varchar(20),
Status varchar(20)
)

select * from Bookings

-- procedure for ticket booking enter train no incorrect

create or alter procedure sp_validtrain
@train_id int
as
  begin
     if not exists (select * from Trains where Train_no = @train_id)
	 begin
	   raiserror ('Train id is not valid enter valid train id...',16,1);
	   return;
	end;
end;

-- creating procedure for ticketbooking

create or alter procedure sp_tktbooking
@train_id int,
@seats int,
@pname varchar(20),
@p_age int,
@gender varchar(15),
@Typeofclass varchar(20),
@berth varchar(10),
@from varchar(20),
@to varchar(20),
@printStatus varchar(20) output
as
 begin
	declare @pnr int;
	declare @status varchar(15);
    declare @availabletkts int;

	if not exists (select * from Trains where TSource = @from and Destination = @to)
	  begin
	     raiserror ('There is no train for these route...',16,1);
		 return;
		 end;
    -- Generate PNR
	     select @pnr = ISNULL(MAX(PNR_No), 1020) + 1 from Bookings;
    if @Typeofclass = '1A'
    begin
        select @availabletkts = Available_1A from Trains where Train_no = @train_id;
        if @availabletkts >= @seats
        begin
            -- Insert booking
             insert into Bookings values (@train_id, @pnr, @pname, @p_age, @gender, @Typeofclass, @berth, @from, @to,'Booked');
 
            -- Update base column for computed value
            update Trains set Available_1A = Available_1A - @seats where Train_no = @train_id;
            set @printStatus = 'Booking Success';
        end
        else
        begin
            set @printStatus = 'Not Booked';
        end
    end
    else if @Typeofclass = '2A'
    begin
        select @availabletkts = Available_2A from Trains where Train_no = @train_id;
 
        if @availabletkts >= @seats
        begin
            insert into Bookings values (@train_id, @pnr, @pname, @p_age, @gender, @Typeofclass, @berth, @from, @to,'Booked');
 
            update Trains set Available_2A = Available_2A - @seats where Train_no = @train_id;
            set @printStatus = 'Booking Success ';
        end
        else
        begin
            set @printStatus = 'Not Booked...';
       end
    end
    else if @Typeofclass = 'Sleeper'
    begin
        select @availabletkts = Available_Sleeper from Trains where Train_no = @train_id;
 
        if @availabletkts >= @seats
        begin
            insert into Bookings values (@train_id, @pnr, @pname, @p_age, @gender, @Typeofclass, @berth, @from, @to, 'Booked');
 
            update Trains set Available_Sleeper = Available_Sleeper - @seats where Train_no = @train_id;
 
            set @printStatus= 'Booking Success';
        end
        else
        begin
            set @printStatus = 'Not Booked...';
        end
    end
	else set @printStatus = 'Not Booked...';
end;

select * from Trains
select * from Bookings

--creating procedure for user to display available trains

create or alter procedure sp_showTrains
@Source varchar(30),@Destination varchar(30)
as
begin 
	if not exists (select * from Trains where TSource = @Source and Destination = @Destination)
	  begin
	     raiserror ('Train is Not Exists for this route',16,1);
	     return;
	  end;
	else select * from Trains where TSource = @Source and Destination=@Destination
end;

-- creacting procedure for checking trains is available for user from address to destination

create or alter procedure sp_check
@Source varchar(30),@Destination varchar(30)
as
begin
select * from Trains where TSource = @Source and Destination = @Destination and IsActive <> 'InActive'
end;

select * from Trains

-- creating procedure for show booking details for user using pnr number

create or alter procedure sp_showTicket
@pnr_no int
as
  begin
    if not exists (select * from Bookings where PNR_No = @pnr_no)
	  begin
	    raiserror ('There is no ticket for this PNR No',16,1);
		return;
	end;
     select * from Bookings where PNR_No = @pnr_no;
end;


-- creating procedure for show all booking details for admin

create or alter procedure sp_booking
@source varchar(25),@destination varchar(25)
as
  begin
  
  -- if train is not available to source to destination returning no trains
	 if not exists (select * from Trains where TSource = @source and Destination = @destination)
	   begin
		  raiserror ('No Trains Available in this route',16,1);
		  return;
	   end;
  -- if Bookings are not available to source to destination returning no bookings
	if not exists (select * from Bookings where status ='Booked' and Source = @source and Destination = @destination)
	   begin
		  raiserror ('No Bookings Available in this route',16,1);
		  return;
	   end;
	select * from Bookings where status = 'Booked' and Source = @source and Destination = @destination;
end;


-- creating procedure for displaying cancelled passengers details for admin

create or alter procedure sp_cancel
@source varchar(25),@destination varchar(25)
as
  begin
	if not exists (select * from Trains where TSource = @source and Destination = @destination)
	begin
	   raiserror ('Train is not exist for this route',16,1)
	   return
	end;
	if not exists (select * from Bookings where Source = @source and Destination = @destination)
	 begin
	   raiserror ('Train is available no one is cancel their ticket',16,1)
	 end;
    select * from Bookings where status = 'Cancelled' and Source = @source and Destination = @destination;
end;

-- creating procedure for cancel tickets to user

create or alter procedure sp_Cancelticket
@pnr int
as
  begin
	declare @trainid int;
	declare @class varchar(20);
	if exists (select * from Bookings where PNR_No = @pnr and Status='Cancelled')
	   begin
	     raiserror ('Ticket Already Cancelled...',16,1);
		 return;
	end;
     select @trainid = Train_id, @class = Class from Bookings where PNR_No = @pnr and status = 'Booked'
	 if @class = '1A'
	   begin
		 update Bookings set Status = 'Cancelled' where PNR_No = @pnr;
		 update Trains set Available_1A = Available_1A + 1;
		 raiserror('Ticket Cancelled Successfully...',16,1);
		 return;
	   end;

	 else if @class = '2A'
	   begin
		update Bookings set Status = 'Cancelled' where PNR_No = @pnr;
		update Trains set Available_2A = Available_2A + 1;
		raiserror('Ticket Cancelled Successfully...',16,1);
		 return;
	   end

	 else if @class = 'Sleeper'
	   begin
		update Bookings set Status = 'Cancelled' where PNR_No = @pnr;
		update Trains set Available_Sleeper = Available_Sleeper + 1;
		raiserror('Ticket Cancelled Successfully...',16,1);
		 return;
	   end;
	   else raiserror('Incorrect PNR no',16,1);
		 return;
  end;

select * from Trains	
select * from Bookings