publish:
	dotnet build -c Release
	dotnet publish -c Release
	mv ./Server/bin/Release/netcoreapp3.1/publish/Application.Client/dist/index.html ./Server/bin/Release/netcoreapp3.1/publish/Application.Client/dist/404.html
	cp -r ./Server/bin/Release/netcoreapp3.1/publish/Application.Client/dist/* ../../Mauragas.github.io-Master
