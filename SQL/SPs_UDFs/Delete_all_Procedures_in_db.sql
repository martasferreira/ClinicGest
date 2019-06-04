DECLARE @name AS VARCHAR(255);
DECLARE procs cursor for
SELECT name FROM sys.procedures 

OPEN procs

FETCH NEXT FROM procs
INTO @name

WHILE @@FETCH_STATUS = 0
BEGIN

    EXECUTE (' DROP PROCEDURE ' + @name + ';');

END

CLOSE procs;
DEALLOCATE procs;

-- Referencia tirada de https://stackoverflow.com/questions/28102871/how-to-delete-all-stored-procedures-in-sql-server-using-t-sql