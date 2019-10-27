# Raspberry Pi DOTNET 3.0 IoT Hub Console Application 
## TEMPLATE

1. Copy the contents of this folder into a new folder
2. Make changes to the following files:
   - .vscode/launch.json
   - .vscode/tasks.json
   - publish.bat
   - {{PROJECTNAME}}.csproj
        |REPLACE|WITH|
        |--|--|
        |{{USERNAME}}|User with permissions to the installation folder on the raspberry Pi|
        |{{PASSWORD}}|Password of that user|
        |{{DEVICENAME}}|The name of the Raspberry Pi device (or the IP address)|
        |{{ROOTPASSWORD}}|Password of the root user on the Raspberry Pi|
        |{{PIFOLDER}}|The installation folder on the Raspberry Pi (from root)|
        |{{PROJECTNAME}}|The name of the project folder (as so the name of the dll created)
3. Assumes that
   - dotnet is installed in /usr/local/bin/dotnet
   - dotnet debugger is installed in /home/pi/vsdbg/vsdbg