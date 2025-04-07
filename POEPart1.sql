USE master
CREATE DATABASE EventEase;

use EventEase;




-- Create Venue table with constraints
CREATE TABLE Venue (
    VenueId INT PRIMARY KEY IDENTITY(1,1),
    VenueName NVARCHAR(100) NOT NULL,
    Location NVARCHAR(200) NOT NULL,
    Capacity INT NOT NULL CHECK (Capacity > 0),
    ImageUrl NVARCHAR(500) NULL DEFAULT 'https://via.placeholder.com/300'
);

-- Create Event table with constraints
CREATE TABLE Events (
    EventId INT PRIMARY KEY IDENTITY(1,1),
    EventName NVARCHAR(100) NOT NULL,
    EventDate DATETIME2 NOT NULL CHECK (EventDate > GETDATE()),
    Description NVARCHAR(500) NULL,
    VenueId INT NULL,
    CONSTRAINT FK_Event_Venue FOREIGN KEY (VenueId) 
        REFERENCES Venue(VenueId) ON DELETE SET NULL
);

-- Create Booking table with composite unique constraint
CREATE TABLE Booking (
    BookingId INT PRIMARY KEY IDENTITY(1,1),
    EventId INT NOT NULL,
    VenueId INT NOT NULL,
    BookingDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Booking_Event FOREIGN KEY (EventId) 
        REFERENCES Event(EventId) ON DELETE CASCADE,
    CONSTRAINT FK_Booking_Venue FOREIGN KEY (VenueId) 
        REFERENCES Venue(VenueId) ON DELETE CASCADE,
    CONSTRAINT UQ_Event_Venue_Date UNIQUE (EventId, VenueId, BookingDate)
);

-- Sample data insertion
INSERT INTO Venue (VenueName, Location, Capacity)
VALUES 
('Grand Ballroom', '123 Main St', 500),
('Conference Center', '456 Oak Ave', 200);

INSERT INTO Events (EventName, EventDate, Description, VenueID)
VALUES
('Tech Conference', '2025-06-15', 'Annual technology summit', 1),
('Music Festival', '2025-07-20', 'Summer music celebration', 2);

INSERT INTO Booking (EventId, VenueID, BookingDate)
VALUES
(1, 1, '2025-05-24'),
(2, 2, '2025-03-12')


SELECT * FROM Venue
SELECT * FROM Events
SELECT * FROM Booking