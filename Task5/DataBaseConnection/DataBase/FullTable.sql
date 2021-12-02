INSERT Author (Name, Surname, Patronymic)
VALUES (N'Stephen', N'King', null),
	   (N'Alexandre', N'Dumas', null),
	   (N'Elizabeth', N'Hun', N'Schmidt'),
	   (N'Harper', N'Lee', null),

	   (N'Shel', N'Silverstein', null),
	   (N'Homer', null, null),
	   (N'John', N'Milton', null),

	   (N'Dale', N'Carnegie', null),
	   (N'Stephen', N'Covey', null),
	   (N'Napoleon', N'Hill', null)

INSERT Genre(Name)
VALUES (N'Action and Adventure'),
	   (N'Horror'),
	   (N'Classic'),
	   (N'Anthology'),
	   (N'Poetry'),
	   (N'Self-help Book')

INSERT Book (Name, AuthorId, GenreId)
VALUES (N'The Shining', 1, 2),
	   (N'The Three Musketeers', 2, 1),
	   (N'The Poets Laureate Anthology', 3, 4),
	   (N'To Kill a Mockingbird', 4, 3),
	   (N'Where The Sidewalk Ends', 5, 5),
	   (N'The Odyssey', 6, 5),
	   (N'Paradise Los', 7, 5),
	   (N'How to Win Friends and Influence People', 7, 6),
	   (N'The 7 Habits of Highly Effective People', 8, 6),
	   (N'Think And Grow Rich', 9, 6)

INSERT Client (FullName, Gender, BirthYear)
VALUES (N'Smith Abramson Roman', N'Male', CAST(N'2000-11-17' AS Date)),
	   (N'Williams Carter Philipp', N'Male', CAST(N'1999-06-26' AS Date)),
	   (N'Taylor Eve Lvovna', N'Female', CAST(N'2001-05-08' AS Date)),
	   (N'Anderson Taft Guryevich', N'Male', CAST(N'2000-07-13' AS Date)),
	   (N'Martin Oldman Guryevich', N'Female', CAST(N'1998-10-01' AS Date)),
	   (N'Garcia Lulu Lee', N'Female', CAST(N'2001-05-08' AS Date)),
	   (N'Walker Wallace Chingizovich', N'Male', CAST(N'2000-07-13' AS Date)),
	   (N'Hernandez Vanessa Antonovna', N'Female', CAST(N'1998-10-01' AS Date))

INSERT ClientBookHistory (ReceivingDate, BookId, ClientId, IsReturn, BookCondition)
VALUES (CAST(N'2021-08-22' AS Date), 2, 2, 1, N'New'),
	   (CAST(N'2021-11-12' AS Date), 1, 4, 0, null),
	   (CAST(N'2021-10-23' AS Date), 2, 4, 0, N'New'),
	   (CAST(N'2021-10-26' AS Date), 4, 3, 1, N'Worn out'),
	   (CAST(N'2021-09-21' AS Date), 3, 5, 0, N'Worn out'),
	   (CAST(N'2021-10-27' AS Date), 2, 5, 0, null),
	   (CAST(N'2021-11-30' AS Date), 5, 3, 0, N'New'),
	   (CAST(N'2021-11-03' AS Date), 5, 4, 0, N'New'),
	   (CAST(N'2021-10-09' AS Date), 5, 4, 1, null),
	   (CAST(N'2021-11-11' AS Date), 5, 1, 0, N'Worn out'),
	   (CAST(N'2021-11-30' AS Date), 6, 7, 0, N'Worn out'),
	   (CAST(N'2021-11-30' AS Date), 6, 7, 1, N'New'),
	   (CAST(N'2021-11-30' AS Date), 6, 3, 0, N'New'),
	   (CAST(N'2021-11-03' AS Date), 7, 4, 1, N'New'),
	   (CAST(N'2021-10-09' AS Date), 8, 6, 0, null),
	   (CAST(N'2021-11-11' AS Date), 9, 1, 0, N'Worn out'),
	   (CAST(N'2021-11-11' AS Date), 10, 8, 0, N'Worn out')