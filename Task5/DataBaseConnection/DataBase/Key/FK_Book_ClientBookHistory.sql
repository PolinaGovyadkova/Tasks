ALTER TABLE ClientBookHistory
ADD CONSTRAINT FK_Book_ClientBookHistory
FOREIGN KEY (BookId) 
REFERENCES Book(Id)
