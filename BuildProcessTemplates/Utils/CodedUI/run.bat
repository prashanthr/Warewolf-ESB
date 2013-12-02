REM == START ENV ==

rmdir /S /Q C:\CodedUI\Merge
mkdir C:\CodedUI\Merge
xcopy /Q /E /Y "\\RSAKLFSVRTFSBLD\Automated Builds\DevMergeStaging" "C:\CodedUI\Merge"

REM Copy the CodedUI configuration over

copy /Y "UI-Warewolf Server.exe.config" "C:\CodedUI\Merge\Warewolf Server.exe.config"

REM Start things up

start "" /B "C:\CodedUI\Merge\Warewolf Server.exe"
timeout 10
start "" /B "C:\CodedUI\Merge\Warewolf Studio.exe"
REM timeout 60
REM ping -n 10000 127.0.0.1