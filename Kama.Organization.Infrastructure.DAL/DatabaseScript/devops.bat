@echo off

 set connectionString="Data Source=94.139.162.23;Initial Catalog=Kama.Sm.Organization;User ID=kama; Password=kama@@1389"


echo ----------------------------------------- Convert SPs
Kama.DevOps.exe -convertSPs "Procedures" "db-devops"

echo ----------------------------------------- Drop objects from db
rem Kama.DevOps.exe -dropAllScripts %connectionString%

echo ----------------------------------------- Execute All scripts on db
rem Kama.DevOps.exe -executeScripts "Updates" %connectionString%
rem Kama.DevOps.exe -executeScripts "Synonyms" %connectionString%
rem Kama.DevOps.exe -executeScripts "functions" %connectionString%
rem Kama.DevOps.exe -executeScripts "views" %connectionString%
Kama.DevOps.exe -executeScripts "db-devops" %connectionString%

pause