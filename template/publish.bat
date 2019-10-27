dotnet publish -r linux-arm /p:ShowLinkerSizeComparison=true 
pushd .\bin\Debug\netcoreapp3.0\linux-arm\publish
pscp -pw {{PASSWORD}} -v -r .\* {{USERNAME}}@{{DEVICENAME}}:{{PIFOLDER}}
popd
