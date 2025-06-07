
INSERT INTO StudentAreas (StudentId, AreaId) VALUES
(1, 8),
(5, 8),
(15, 8),
(17, 8);

INSERT INTO StudentAreas (StudentId, AreaId) VALUES
(2, 8),  
(3, 3), 
(4, 6),  
(6, 6), 
(7, 7), 
(8, 2), 
(9, 1),  
(10, 8); 

INSERT INTO StudentAreas (StudentId, AreaId) VALUES
(1, 2),
(1, 4),
(1, 7);

INSERT INTO StudentAreas (StudentId, AreaId) VALUES
(10, 16),
(10, 9),
(11, 1),
(12, 8),
(13, 3),
(14, 6),
(16, 6),
(17, 7),
(18, 2),
(19, 1),
(20, 8);

INSERT INTO StudentAreas (StudentId, AreaId) VALUES
(21, 9),
(22, 7),
(23, 10),
(24, 4),
(25, 8),
(26, 1),
(27, 2),
(28, 17),
(29, 3),
(30, 6);

INSERT INTO StudentAreas (StudentId, AreaId) VALUES
(31, 5),
(32, 16),
(33, 1),
(34, 9),
(35, 7),
(36, 17),
(37, 10),
(38, 11),
(39, 8),
(40, 6),
(41, 5),
(42, 16),
(43, 1),
(44, 9),
(45, 7),
(46, 1),
(47, 16),
(48, 3),
(49, 17),
(50, 6);

SELECT * FROM StudentAreas

INSERT INTO StudentAreas (StudentId, AreaId) VALUES
(1, 16);

SELECT 
    s.StudentID, 
    s.Name AS Student, 
    a.AreaId, 
    a.Name AS Area
FROM 
    Students s
JOIN 
    StudentAreas sa ON s.StudentID = sa.StudentId
JOIN 
    Areas a ON sa.AreaId = a.AreaId
ORDER BY 
    s.StudentID, a.AreaId;
