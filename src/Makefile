publish:
	dotnet build ./Application/Client -c Release 
	dotnet publish ./Application/Client -c Release
	cp ./Application/Client/bin/Release/netstandard2.1/publish/wwwroot/index.html ./Application/Client/bin/Release/netstandard2.1/publish/wwwroot/404.html
	cp -r ./Application/Client/bin/Release/netstandard2.1/publish/wwwroot/* ../../Master
