BuildDirectory="/tmp/gh-pages"

# Clean temp folder if already exist
if [ -d $BuildDirectory ]; then
  rm -rfv $BuildDirectory
fi
mkdir $BuildDirectory

# Clone repository
git clone -b "gh-pages" https://github.com/mauragas/mauragas.github.io.git $BuildDirectory

# Clean repository
rm -rfv $BuildDirectory/*

# Publish files
git clean -fdx
dotnet build ./Application/Client -c Release
dotnet publish ./Application/Client -c Release
cp -r ./Application/Client/bin/Release/net6.0/publish/wwwroot/* $BuildDirectory
mv $BuildDirectory/index.html $BuildDirectory/404.html
mv $BuildDirectory/index.html.br $BuildDirectory/404.html.br
mv $BuildDirectory/index.html.gz $BuildDirectory/404.html.gz

# Open in VS Code
code $BuildDirectory
