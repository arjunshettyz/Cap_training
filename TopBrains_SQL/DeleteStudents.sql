create table StudentInfo(
 StudentId INT PRIMARY KEY,
    StudentName VARCHAR(100)
)

create table marks (
MarkId INT PRIMARY KEY,
    StudentId INT,
    Subject VARCHAR(50),
    Score INT,
    FOREIGN KEY (StudentId) REFERENCES StudentInfo(StudentId)
)


INSERT INTO StudentInfo (StudentId, StudentName) VALUES
(1, 'Arjun'),
(2, 'Rahul'),
(3, 'Priya'),
(4, 'Sneha'),
(5, 'Kiran');

INSERT INTO Marks (MarkId, StudentId, Subject, Score) VALUES
(101, 1, 'Math', 85),
(102, 2, 'Science', 90),
(103, 4, 'English', 75);


delete from studentinfo
where not exists (
select 1  from marks 
where marks.StudentId = StudentInfo.StudentId
);

select * from studentinfo