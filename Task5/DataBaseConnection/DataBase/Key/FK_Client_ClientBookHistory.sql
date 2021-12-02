ALTER TABLE ClientBookHistory
ADD CONSTRAINT FK_Client_ClientBookHistory
FOREIGN KEY (ClientId) 
REFERENCES Client (Id)
