# My Pop OS setup

My workstation setup process steps, commands, application list and various configurations.

[![Screenshot](https://www.snapagogo.com/images/2020/05/30/Screenshot-from-2020-05-30-20-07-47.jpg)](https://www.snapagogo.com/image/cmb5SK)

## First steps

Download ISO file from Pop OS [WEB site](https://system76.com/pop). Check USB device using command `sudo fdisk -l` and execute below command:

```bash
dd bs=4M if=path/to/pop-os-linux.iso of=/dev/sdx status=progress oflag=sync
```

Update all packages after installation

```bash
sudo apt update &&
sudo apt upgrade
```

## Applications

Applications installed using terminal

- Gnome Tweaks `gnome-tweaks`
- Spotify `spotify-client spotify-client-gnome-support`
- Visual Studio Code `code`
- Zim `zim`
- Deepin terminal `deepin-terminal`
- Zsh `zsh`
- VirtualBox `virtualbox virtualbox-ext-pack virtualbox-guest-additions-iso`
- Equalizer `pulseeffects`

Install all in one command

```bash
sudo apt install spotify-client spotify-client-gnome-support code gnome-tweaks zim deepin-terminal zsh virtualbox virtualbox-ext-pack virtualbox-guest-additions-iso pulseaudio-equalizer
```

Other applications

- [Dotnet](https://dotnet.microsoft.com/download/dotnet-core)
- [Azure Data Studio](https://docs.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio)
- [Mega sync](https://mega.nz/sync)
- [Typora](https://typora.io)

## Nicer terminal

Install `zsh` package and afterward [Oh-My-Zsh](https://ohmyz.sh). Edit `~/.zshrc` and change variable `ZSH_THEME` to `fox`.

```bash
gedit ~/.zshrc
```

## Extensions

Extensions installed using terminal

```bash
sudo apt install gnome-shell-extension-dash-to-panel &&
sudo apt install gnome-shell-extension-do-not-disturb &&
sudo apt install gnome-shell-extension-top-icons-plus &&
sudo apt install gnome-shell-extension-weather &&
sudo apt install gnome-shell-extension-bluetooth-quick-connect
```

Other extensions can be install from [WEB site:](https://extensions.gnome.org)

- Dash to panel
- Coverflow Alt-Tab
- Openweather
- Workplaces to dock
- User Themes

## Icons and themes

Flat-remix

```bash
sudo add-apt-repository ppa:daniruiz/flat-remix
sudo apt-get update
sudo apt-get install flat-remix-gnome flat-remix flat-remix-gtk
```

## Shrink title bar

To shrink application title bar create below file with content:

```bash
gedit ~/.config/gtk-3.0/gtk.css
```

```css
headerbar.default-decoration {
 padding-top: 0;
 padding-bottom: 0;
 min-height: 0;
 font-size: 0.8em;
}

headerbar.default-decoration button.titlebutton {
 padding: 0;
 min-height: 0;
}
```

## Default terminal

Change default to deepin terminal

```bash
gsettings set org.gnome.desktop.default-applications.terminal exec 'deepin-terminal'
```
