publish:
	dotnet build ./Client -c Release 
	dotnet publish ./Client -c Release
	mv ./Client/bin/Release/netstandard2.1/publish/wwwroot/index.html ./Client/bin/Release/netstandard2.1/publish/wwwroot/404.html
	cp -r ./Client/bin/Release/netstandard2.1/publish/wwwroot/* ../../Mauragas.github.io-Master
