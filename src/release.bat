@echo OFF

if "%~1"=="" goto blank

SET FOLDER=MacroPad.%1.bin

rmdir RSoft.MacroPad\bin\publish

dotnet publish -c Release -p:PublishProfile=FolderProfile

mkdir %FOLDER%
copy /Y RSoft.MacroPad\bin\publish\* %FOLDER%
del %FOLDER%\*.deps.json
del %FOLDER%\*.pdb

cd %FOLDER%
7z a ..\..\..\Releases\RSoft.MacroPad.%1.7z *
cd ..

rmdir /S /Q %FOLDER%

echo ----
echo Release MacroPad.%1 done
echo ----
goto end

:blank
echo ----
echo Set release name!
echo ----

:end