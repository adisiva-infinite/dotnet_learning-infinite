use Railway_Reservation

-- creating trains table
create table Trains
(
Train_no int primary key,
TrainName varchar(25) not null,
FirstClass int,
Available_1A int,
SecondClass int,
Available_2A int,
SleeperClass int,
Available_Sleeper int,
TSource varchar(25) not null,
Destination varchar(25) not null,
IsActive varchar(15)
)

select * from Trains

drop table Trains

-- creating a procedure for checking train id for adding train

create or alter procedure sp_checktrain
@train_id int
as
  begin
     if exists (select * from Trains where Train_no = @train_id)
	  begin
	    raiserror ('Train id is already Exists..',16,1);
		return;
	  end;
end;
-- creating procedure for addtrains

create or alter procedure sp_AddTrains
@trainno int,
@trainname varchar(25),
@fclass int,
@Ticket_1A int,
@sclass int,
@Ticket_2A int,
@sleeperclass int,
@Ticket_sleeper int,
@from varchar(25),
@to varchar(25)
as
begin
	insert into Trains(Train_no,TrainName,FirstClass,Available_1A,SecondClass,Available_2A,SleeperClass,Available_Sleeper,TSource,Destination,IsActive) 
	values(@trainno,@trainname,@fclass,@Ticket_1A,@sclass,@Ticket_2A,@sleeperclass,@Ticket_sleeper,@from,@to,'Actice')
	begin
	   raiserror ('Train Added Successfully....',16,1);
	   return;
	end;
end;


-- creating procedure for modify trains

create or alter procedure sp_modify
@train_id int
as
  begin
     if not exists (select * from Trains where Train_no = @train_id)
	   begin
	     raiserror ('Train not exists...',16,1);
	   end;
end;


-- creating procedure for modify trains

create or alter procedure sp_updateTrain
@trainno int,
@from varchar(25),
@to varchar(25)
as 
  begin
	 update Trains set TSource = @from, Destination = @to, IsActive = 'Active' where Train_no = @trainno;
	   begin
	     raiserror ('Train Details Modified Successfully....',16,1);
		 return;
	end;
end;

--creating procedure for Softdeletetrain

create or alter procedure sp_deleteTrain
@trainno int
as
begin
	if not exists (select * from Trains where Train_no = @trainno)
	begin
	  raiserror ('Train is not exists',16,1);
	  return;
    end;
	else if exists (select * from Trains where Train_no = @trainno and IsActive ='InActive')
	  begin
	     raiserror ('Train Already Deleted...',16,1);
		 return;
	  end;
	else update Trains set IsActive='InActive' where Train_no = @trainno
	begin
	   raiserror('Train details Deleted Successfully....',16,1);
	   return;
	end;
end;

-- Procedure for Show Route 

create or alter procedure sp_route
as
  begin
      select distinct TSource,Destination from Trains 
end;




select * from Trains
select * from Bookings


