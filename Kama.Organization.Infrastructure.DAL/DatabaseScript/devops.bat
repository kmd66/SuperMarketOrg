@echo off

 set connectionString="Data Source=94.139.162.23\sql2019,1433;Initial Catalog=Kama.Bonyad.OmranShomal;User ID=kama; Password=K@maPMGs@dUL98"
rem set connectionString="Data Source=193.141.126.149:8023/;Initial Catalog=Kama.Bonyad.OmranShomal;User ID=kama; Password=K@maPMGs@dUL98"


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