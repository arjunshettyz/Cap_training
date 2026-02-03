CREATE TABLE Users (
    Id INT PRIMARY KEY,
    Email VARCHAR(100)
);
INSERT INTO Users (Id, Email) VALUES
(1, 'arjun@gmail.com'),
(2, 'test@gmail.com'),
(3, 'arjun@gmail.com'),
(4, 'user@yahoo.com'),
(5, 'test@gmail.com'),
(6, 'test@gmail.com'),
(7, 'hello@outlook.com'),
(8, 'user@yahoo.com');

SELECT 
    Email,
    COUNT(*) AS DuplicateCount
FROM Users
GROUP BY Email
HAVING COUNT(*) > 1;

