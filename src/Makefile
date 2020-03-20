publish:
	dotnet build -c Release
	dotnet publish -c Release
	mv ./Server/bin/Release/netcoreapp3.1/publish/wwwroot/index.html ./Server/bin/Release/netcoreapp3.1/publish/wwwroot/404.html
	cp -r ./Server/bin/Release/netcoreapp3.1/publish/wwwroot/* ../../Mauragas.github.io-Master
