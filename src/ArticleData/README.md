# Article data generator

## Deployment for Ubuntu

```bash
dotnet clean
dotnet restore
dotnet publish -c Release -f netcoreapp3.1 -r ubuntu.18.04-x64
dotnet deb --no-restore -c Release -f netcoreapp3.1 -r ubuntu.18.04-x64
sudo dpkg -i ./bin/Release/netcoreapp3.1/ubuntu.18.04-x64/ArticleData.1.0.0.ubuntu.18.04-x64.deb
```

If you have issue with `libicu` package download from [page](http://ftp.us.debian.org/debian/pool/main/i/icu/) and install it.

## Deployment for Windows

```bash
dotnet publish -c Release -r win10-x64 /p:PublishSingleFile=true /p:PublishTrimmed=true
```

File should be placed in `./bin/Release/netcoreapp3.1/win10-x64/publish/ArticleData.exe`.
