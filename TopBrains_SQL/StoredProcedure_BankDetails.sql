
CREATE TABLE Customers
(
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    PhoneNumber VARCHAR(15),
    City VARCHAR(50),
    CreatedDate DATE
);


CREATE TABLE Accounts
(
    AccountID INT PRIMARY KEY,
    CustomerID INT,
    AccountNumber VARCHAR(20),
    AccountType VARCHAR(20), 
    OpeningBalance DECIMAL(12,2),

    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE Transactions
(
    TransactionID INT PRIMARY KEY,
    AccountID INT,
    TransactionDate DATE,
    TransactionType VARCHAR(10), 
    Amount DECIMAL(12,2),

    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);

CREATE TABLE Bonus
(
    BonusID INT PRIMARY KEY,
    AccountID INT,
    BonusMonth INT,
    BonusYear INT,
    BonusAmount DECIMAL(10,2),
    CreatedDate DATE,

    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);

INSERT INTO Customers VALUES
(1, 'Ravi Kumar', '9876543210', 'Chennai', '2023-01-10'),
(2, 'Priya Sharma', '9123456789', 'Bangalore', '2023-03-15'),
(3, 'John Peter', '9988776655', 'Hyderabad', '2023-06-20');

INSERT INTO Accounts VALUES
(101, 1, 'SB1001', 'Savings', 20000),
(102, 2, 'SB1002', 'Savings', 15000),
(103, 3, 'SB1003', 'Savings', 30000);

INSERT INTO Transactions VALUES
(1, 101, '2024-01-05', 'Deposit', 30000),
(2, 101, '2024-01-18', 'Withdraw', 5000),
(3, 101, '2024-02-10', 'Deposit', 25000),

(4, 102, '2024-01-07', 'Deposit', 20000),
(5, 102, '2024-01-25', 'Deposit', 35000),
(6, 102, '2024-02-05', 'Withdraw', 10000),

(7, 103, '2024-01-10', 'Deposit', 15000),
(8, 103, '2024-01-20', 'Withdraw', 5000);


-- Q1
CREATE PROCEDURE GetTransactionSummary(
@StartDate DATE,
@EndDate DATE,
@AccountID INT
)
As begin 
select sum(case when TransactionType = 'Deposit' then Amount else 0 end) as TotalDeposited,
 sum(case when TransactionType = 'Withdraw' then Amount else 0  end ) As TotalWithdrawn

 from Transactions 
 where AccountID = @AccountID and TransactionDate between @StartDate and @EndDate;
 end;

 EXEC GetTransactionSummary '2024-01-01', '2024-01-31', 101;



 -- Q2
 CREATE PROCEDURE InsertMonthlyBonus
AS
BEGIN
    INSERT INTO Bonus (BonusID, AccountID, BonusMonth, BonusYear, BonusAmount, CreatedDate)

    SELECT 
        ROW_NUMBER() OVER (ORDER BY AccountID)
        + ISNULL((SELECT MAX(BonusID) FROM Bonus),0),

        AccountID,
        MONTH(TransactionDate),
        YEAR(TransactionDate),
        1000,
        GETDATE()

    FROM Transactions
    WHERE TransactionType = 'Deposit'

    GROUP BY AccountID, MONTH(TransactionDate), YEAR(TransactionDate)

    HAVING SUM(Amount) > 50000

    AND NOT EXISTS (
        SELECT 1 FROM Bonus B
        WHERE B.AccountID = Transactions.AccountID
          AND B.BonusMonth = MONTH(TransactionDate)
          AND B.BonusYear = YEAR(TransactionDate)
    );
END;


EXEC InsertMonthlyBonus;
SELECT * FROM Bonus;



-- Q3
SELECT 
    C.CustomerName,
    A.AccountNumber,

    A.OpeningBalance
    + ISNULL(SUM(CASE WHEN T.TransactionType = 'Deposit' 
                      THEN T.Amount ELSE 0 END),0)

    - ISNULL(SUM(CASE WHEN T.TransactionType = 'Withdraw' 
                      THEN T.Amount ELSE 0 END),0)

    + ISNULL((SELECT SUM(BonusAmount) 
              FROM Bonus B 
              WHERE B.AccountID = A.AccountID),0)

    AS CurrentBalance

FROM Customers C
JOIN Accounts A 
    ON C.CustomerID = A.CustomerID

LEFT JOIN Transactions T
    ON A.AccountID = T.AccountID

GROUP BY 
    C.CustomerName,
    A.AccountNumber,
    A.OpeningBalance,
    A.AccountID;




SELECT * FROM Customers;
SELECT * FROM Accounts;
SELECT * FROM Transactions;
SELECT * FROM Bonus;


