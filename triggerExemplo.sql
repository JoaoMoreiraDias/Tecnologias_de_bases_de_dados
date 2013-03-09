CREATE TRIGGER G
AFTER UPDATE OF budget ON Departments
UPDATE Departments SET budget = <value>;