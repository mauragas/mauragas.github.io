# My OS setup

My workstation setup process steps, commands, application list and various configurations.

[![Screenshot](https://www.snapagogo.com/images/2020/05/30/Screenshot-from-2020-05-30-20-07-47.jpg)](https://www.snapagogo.com/image/cmb5SK)

## First steps

Download ISO file

- [Pop OS](https://system76.com/pop)
- [Ubuntu](https://ubuntu.com/download/desktop)

Check USB device using command `sudo fdisk -l` and execute below command

```bash
dd bs=4M if=path/to/os.iso of=/dev/sdx status=progress oflag=sync
```

Update all packages after installation

```bash
sudo apt update && sudo apt upgrade -y && sudo apt autoremove -y && sudo apt autoclean && sudo snap refresh
```

## Repositories

Icons and themes

```bash
add-apt-repository ppa:daniruiz/flat-remix
```

[Dotnet](https://dotnet.microsoft.com/download/dotnet-core) core

```bash
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb &&
sudo dpkg -i packages-microsoft-prod.deb &&
rm packages-microsoft-prod.deb
```

## Applications

APT applications

```bash
sudo apt install -y curl make git gnome-tweaks tilix python3-nautilus zsh zim pulseeffects transmission apt-transport-https dotnet-sdk-3.1 virtualbox virtualbox-ext-pack virtualbox-guest-additions-iso adb gnome-shell-extension-bluetooth-quick-connect xbindkeys firewalld flat-remix flat-remix-gtk flat-remix-gnome
```

Snap applications

```bash
sudo snap install storage-explorer postman bpytop scrcpy obs-studio kdenlive vlc gimp spotify &&
sudo snap install slack --classic &&
sudo snap install powershell --classic &&
sudo snap install code --classic &&
sudo snap install android-studio --classic
```

Azure CLI

curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash

Oh-My-Zsh

```bash
sh -c "$(wget https://raw.github.com/ohmyzsh/ohmyzsh/master/tools/install.sh -O -)"
```

Other applications

- [Azure Data Studio](https://docs.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio)
- [Mega sync](https://mega.nz/linux/MEGAsync/xUbuntu_20.04/amd64)

## Extensions

Extensions can be install from [WEB site](https://extensions.gnome.org)

- [User Themes](https://extensions.gnome.org/extension/19/user-themes)
- [Openweather](https://extensions.gnome.org/extension/750/openweather)
- [ShellTile](https://extensions.gnome.org/extension/657/shelltile)
- [Dash to panel](https://extensions.gnome.org/extension/1160/dash-to-panel)
- [Coverflow Alt-Tab](https://extensions.gnome.org/extension/97/coverflow-alt-tab)
- [Bluetooth quick connect](https://extensions.gnome.org/extension/1401/bluetooth-quick-connect)
- [ArcMenu](https://extensions.gnome.org/extension/3628/arcmenu)
- [Compiz alike magic lamp effect](https://extensions.gnome.org/extension/3740/compiz-alike-magic-lamp-effect)
- [Sound Input & Output Device Chooser](https://extensions.gnome.org/extension/906/sound-output-device-chooser)

### Configurations

#### Set default terminal

```bash
gsettings set org.gnome.desktop.default-applications.terminal exec 'tilix'
```

#### Set default shell

```bash
chsh -s $(which zsh)
```

#### Set icons and themes

gsettings set org.gnome.desktop.interface gtk-theme "Flat-Remix-GTK-Blue-Darker" &&
gsettings set org.gnome.desktop.interface icon-theme "Flat-Remix-Yellow-Light" &&
gsettings set org.gnome.shell.extensions.user-theme name  "Flat-Remix-Blue-Darkest-fullPanel"

#### Set favorite applications

```bash
gsettings set org.gnome.shell favorite-apps "['firefox.desktop', 'org.gnome.Nautilus.desktop', 'com.gexperts.Tilix.desktop', 'spotify_spotify.desktop', 'code_code.desktop']"
```

Get existing apps with command:

```bash
gsettings get org.gnome.shell favorite-apps
```

#### ZSH shell

Download and install `MesloLGS NF Regular` font:

```bash
wget -O "MesloLGS NF Regular.ttf" https://github.com/romkatv/powerlevel10k-media/raw/master/MesloLGS%20NF%20Regular.ttf
```

Install Powerlevel10k theme

```bash
git clone --depth=1 https://github.com/romkatv/powerlevel10k.git ${ZSH_CUSTOM:-~.oh-my-zsh/custom}/themes/powerlevel10k
```

Edit `~/.zshrc` and change variable `ZSH_THEME` to `powerlevel10k/powerlevel10k`. To configure manually run command `p10k configure`.

#### Nvidia maximum performance

Create file `~/.config/autostart/nvidia-settings.desktop`

```txt
[Desktop Entry]
Type=Application
Exec=nvidia-settings -a "[gpu:0]/GpuPowerMizerMode=1"
Hidden=false
NoDisplay=false
X-GNOME-Autostart-enabled=true
Name[en_US]=nvidia-prefer-maximum-performance
Name=nvidia-prefer-maximum-performance
```

#### Default sound device

List all available audio sinks (output) or sources (inputs):

```bash
pactl list short sinks
pactl list short sources
```

Create file `~/.config/autostart/pactl.desktop`

```txt
[Desktop Entry]
Type=Application
Exec=pactl set-default-sink alsa_output.pci-0000_00_1b.0.analog-stereo
Hidden=false
NoDisplay=false
X-GNOME-Autostart-enabled=true
Name[en_US]=default-audio-device
Name=default-audio-device
```

#### Pulseeffects autostart

Create file `~/.config/autostart/pulseeffects-service.desktop`

```txt
[Desktop Entry]
Name=PulseEffects
Comment=PulseEffects Service
Exec=pulseeffects --gapplication-service
Icon=pulseeffects
StartupNotify=false
Terminal=false
Type=Application
```

#### Remap mouse keys

Change forward button to Spotify next song. Create file `~/.xbindkeysrc` with content:

```txt
"dbus-send --print-reply --dest=org.mpris.MediaPlayer2.spotify /org/mpris/MediaPlayer2 org.mpris.MediaPlayer2.Player.Next"
b:9
```

```bash
xbindkeys -f ~/.xbindkeysrc
```

#### Enable firewall

```bash
systemctl enable firewalld &&
systemctl start firewalld
```
