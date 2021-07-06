Create database HunterMovies;

Create table Actors (

	ID int identity(1,1) Primary key, 
	Nombre varchar (55) not null,
	BirthDay varchar (50), 
	Sex varchar (10), 
	Photo varchar (255)
);

Create table Gender (

	ID int identity(1,1) Primary key,
	Gender varchar (255) not null,
	Constraint N_Gender Unique(Gender)
);

Create table Movies(

	ID int identity(1,1) Primary key, 
	Title varchar(60),
	Gender int Foreign key references Gender(ID),
	ReleaseDate varchar (50),
	Photo varchar (255)

);

Create table ActorsMovies (

	ActorID int Foreign key references Actors(ID),
	MovieID int	Foreign key references Movies(ID)


);

