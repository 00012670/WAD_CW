use WadDB
go



INSERT INTO Habits ( Name, Frequency, Repeat, StartDate) 
VALUES ( '1 Habit', 3, 1, '2023-02-23')

INSERT INTO Progresses(  [HabitProgress], [IsCompleted], [Note], [HabitID], [EndDate]  ) 
VALUES (  50, 0, 'AlmostDone', 2, '2023-02-23')