publish:
	dotnet clean ./Application/Client -c Release
	rm -r ./Application/Client/bin -f
	rm -r ../docs/* -f
	dotnet build ./Application/Client -c Release
	dotnet publish ./Application/Client -c Release
	cp -r ./Application/Client/bin/Release/net5.0/publish/wwwroot/* ../docs
