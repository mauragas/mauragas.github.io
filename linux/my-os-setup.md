# My OS setup

My workstation setup process steps, commands, application list and various configurations.

[![pop-os-2020-05-30.jpg](https://www.snapagogo.com/images/2020/11/02/pop-os-2020-05-30.jpg)](https://www.snapagogo.com/image/cwCI49)

## First steps

Download ISO file:

- [Pop OS](https://system76.com/pop)
- [Ubuntu](https://ubuntu.com/download/desktop)

Check USB device using command `sudo parted -l` and execute below command:

```bash
dd bs=4M if=path/to/os.iso of=/dev/sdx status=progress oflag=sync
```

Update all packages after installation:

```bash
sudo apt update && sudo apt upgrade -y && sudo apt autoremove -y && sudo apt autoclean && sudo snap refresh
```

## Repositories

Icons and themes

```bash
sudo add-apt-repository ppa:daniruiz/flat-remix
```

Install [Dotnet](https://dotnet.microsoft.com/download/dotnet-core) core:

```bash
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb &&
sudo dpkg -i packages-microsoft-prod.deb &&
rm packages-microsoft-prod.deb &&
sudo apt update
```

## Applications

### APT

```bash
sudo apt install -y nvidia-driver-465 curl make git gnome-tweaks tilix python3-nautilus zsh pulseeffects transmission apt-transport-https adb gnome-shell-extension-bluetooth-quick-connect gnome-shell-extension-system-monitor xbindkeys flat-remix flat-remix-gtk flat-remix-gnome vlc ufw gufw azdata-cli azure-functions-core-tools-3 stacer
```

In case you will get any issues installing packages you can try to fix it with commands:

```bash
sudo apt clean &&
sudo apt update &&
sudo apt --fix-broken install &&
sudo apt dist-upgrade &&
sudo dpkg -a --configure &&
sudo apt install -f &&
sudo apt autoremove -y
```

### Snaps

- [Microsoft Azure Storage Explorer](https://snapcraft.io/storage-explorer)
- [Postman](https://snapcraft.io/postman)
- [Resource monitor for your terminal](https://snapcraft.io/bpytop)
- [OBS Studio](https://snapcraft.io/obs-studio)
- [Kdenlive video editor](https://snapcraft.io/kdenlive)
- [GNU Image Manipulation Program](https://snapcraft.io/gimp)
- [Spotify](https://snapcraft.io/spotify)
- [Joplin](https://snapcraft.io/joplin-desktop)
- [Signal](https://snapcraft.io/signal-desktop)
- [.NET SDK](https://snapcraft.io/dotnet-sdk)

```bash
sudo snap install storage-explorer postman bpytop obs-studio kdenlive gimp spotify joplin-desktop signal-desktop &&
sudo snap install dotnet-sdk --classic
```

**NOTE:** Spotify (or any other snap package) will be faster if installed as [DEB package](https://www.spotify.com/us/download/linux).

### Azure CLI

Install Azure CLI using predefined script:

```bash
curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash
```

Oh-My-Zsh

```bash
sh -c "$(wget https://raw.github.com/ohmyzsh/ohmyzsh/master/tools/install.sh -O -)"
```

### Docker

Follow standard [steps](https://docs.docker.com/engine/install/ubuntu) for Ubuntu or execute below command:

```bash
curl -fsSL https://get.docker.com -o get-docker.sh &&
sudo sh get-docker.sh &&
sudo usermod -aG docker $USER &&
docker version
```

### Other

- [Azure Data Studio](https://docs.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio)
- [Mega sync](https://mega.nz/linux/MEGAsync/xUbuntu_20.04/amd64)
- [GitHub CLI](https://github.com/cli/cli/blob/trunk/docs/install_linux.md)
- [Azure Data CLI (azdata)](https://docs.microsoft.com/en-us/sql/azdata/install/deploy-install-azdata-linux-package?view=sql-server-ver15)
- [VS Code](https://code.visualstudio.com/download)
- [Typora](https://support.typora.io/Typora-on-Linux/)

## Extensions

Extensions can be install from [WEB site](https://extensions.gnome.org):

- [User Themes](https://extensions.gnome.org/extension/19/user-themes)
- [Openweather](https://extensions.gnome.org/extension/750/openweather)
- [ShellTile](https://extensions.gnome.org/extension/657/shelltile)
- [Dash to panel](https://extensions.gnome.org/extension/1160/dash-to-panel)
- [Coverflow Alt-Tab](https://extensions.gnome.org/extension/97/coverflow-alt-tab)
- [Bluetooth quick connect](https://extensions.gnome.org/extension/1401/bluetooth-quick-connect)
- [ArcMenu](https://extensions.gnome.org/extension/3628/arcmenu)
- [Compiz alike magic lamp effect](https://extensions.gnome.org/extension/3740/compiz-alike-magic-lamp-effect)
- [Sound Input & Output Device Chooser](https://extensions.gnome.org/extension/906/sound-output-device-chooser)
- [Clipboard Indicator](https://extensions.gnome.org/extension/779/clipboard-indicator)
- [CPU Power Manager](https://extensions.gnome.org/extension/945/cpu-power-manager)
- [Workspaces to Dock](https://extensions.gnome.org/extension/427/workspaces-to-dock)
- [Steal My Focus](https://extensions.gnome.org/extension/234/steal-my-focus)
- [Impatience](https://extensions.gnome.org/extension/277/impatience)

## Configurations

### Configure locales

```bash
sudo dpkg-reconfigure locales
```

### Set default terminal

```bash
gsettings set org.gnome.desktop.default-applications.terminal exec 'tilix'
```

### Set default shell

```bash
chsh -s $(which zsh)
```

### Set favorite applications

```bash
gsettings set org.gnome.shell favorite-apps "['firefox.desktop', 'org.gnome.Nautilus.desktop', 'com.gexperts.Tilix.desktop', 'spotify_spotify.desktop', 'code_code.desktop']"
```

Get existing apps with command:

```bash
gsettings get org.gnome.shell favorite-apps
```

### ZSH shell

Download and install `MesloLGS NF Regular` font:

```bash
wget -O "MesloLGS NF Regular.ttf" https://github.com/romkatv/powerlevel10k-media/raw/master/MesloLGS%20NF%20Regular.ttf
```

Install Powerlevel10k theme:

```bash
git clone --depth=1 https://github.com/romkatv/powerlevel10k.git ${ZSH_CUSTOM:-~.oh-my-zsh/custom}/themes/powerlevel10k
```

Edit `~/.zshrc` and change variable `ZSH_THEME` to `powerlevel10k/powerlevel10k`. To configure manually run command `p10k configure`.

### A Python-based resource monitor for your terminal

Additional configuration for [bpytop](https://snapcraft.io/bpytop):

```bash
sudo snap connect bpytop:mount-observe &&
sudo snap connect bpytop:network-control &&
sudo snap connect bpytop:hardware-observe &&
sudo snap connect bpytop:system-observe &&
sudo snap connect bpytop:process-control &&
sudo snap connect bpytop:physical-memory-observe
```

### Dotnet

Additional configuration for [.NET SDK](https://docs.microsoft.com/en-us/dotnet/core/install/linux-snap#install-the-sdk):

```bash
sudo snap alias dotnet-sdk.dotnet dotnet
```

**NOTE:** [Export](https://docs.microsoft.com/en-us/dotnet/core/install/linux-snap#export-the-install-location) the install dotnet location to `.zshrc` or `.profile`.

```bash
export DOTNET_ROOT=/snap/dotnet-sdk/current
```

#### Enable TAB completion for the .NET CLI

Fallow [steps](https://docs.microsoft.com/en-us/dotnet/core/tools/enable-tab-autocomplete#zsh) for zsh.

### Nvidia maximum performance

Create file `~/.config/autostart/nvidia-settings.desktop` with content:

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

### Default sound device (optional)

List all available audio sinks (output) or sources (inputs):

```bash
pactl list short sinks
pactl list short sources
```

Create file `~/.config/autostart/pactl.desktop` with content:

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

### PulseEffects autostart

Start desktop application `PulseEffects` and enable `Start Service at Login`. Open file `~/.config/autostart/pulseeffects-service.desktop` and append line (optional):

```txt
X-GNOME-Autostart-Delay=10
```

**NOTE:** Delay allows to load all needed components before starting PulseEffects service.

### Remap mouse keys for Logitech MX Master 3 mouse

Due to issue with conflicting button mapping with ThinkPad TrackPoint and Logitech mouse I use workaround to map thumb wheel button number 20 and 19 instead of 7 and 6.

Create file `~/.xbindkeysrc` with content:

```txt
# Thumb wheel up - increase volume
"amixer -D pulse sset Master 3%+"
   b:20 # b:7

# Thumb wheel down - lower volume
"amixer -D pulse sset Master 3%-"
   b:19 # b:6
```

Execute command:

```bash
xbindkeys -f ~/.xbindkeysrc
```

Create startup script to execute below script. Only needed in case of workaround to replace button number 6 and 7 to 19 and 20.

```bash
sh -c "sleep 3 && xinput --set-button-map $(xinput list --id-only 'pointer:Logitech MX Master 3') 1 2 3 4 5 19 20 8 9 10 11 12 13 14 15 16 17 18"
```

### Special key mapping for Logitech MX Master 3 mouse

Install [logid](https://github.com/PixlOne/logiops):

```bash
sudo apt install cmake libevdev-dev libudev-dev libconfig++-dev &&
git clone https://github.com/PixlOne/logiops.git --depth=1 &&
cd logiops/src/logid &&
mkdir build &&
cd build &&
cmake .. &&
make &&
sudo make install &&
sudo systemctl enable logid.service &&
sudo systemctl start logid.service &&
sudo systemctl status logid.service
```

Create file `/etc/logid.cfg` with content:

```cfg
devices: ({
  name: "Wireless Mouse MX Master 3";

  // A lower threshold number makes the wheel switch to free-spin mode quicker when scrolling fast
  smartshift: { on: true; threshold: 15; };

  // Higher numbers make the mouse more sensitive (cursor moves faster), 4000 max for MX Master 3
  dpi: 1000;

  buttons: (
    // Configure thumb forward button 9 to next song key
    { cid: 0x56; action = { type: "Keypress"; keys: ["KEY_NEXTSONG"]; }; },

    // Configure bottom thumb button 10 to META key
    { cid: 0xc3; action = { type: "Keypress"; keys: ["KEY_LEFTMETA"]; }; },

    // Configure top button 11 to Play / Pause
    { cid: 0xc4; action = { type: "Keypress"; keys: ["KEY_PLAYPAUSE"]; }; }
  );
});
```

If there is issue with scroll wheel replace `hiresscroll` with:

```cfg
  hiresscroll: {
    hires: true;
      invert: false;
      target: true;
      up: {
        mode: "Axis";
        axis: "REL_WHEEL_HI_RES";
        axis_multiplier: 3;
      },
      down: {
        mode: "Axis";
        axis: "REL_WHEEL_HI_RES";
        axis_multiplier: -3;
      }
  };
```

Restart `logid` service:

```bash
sudo systemctl restart logid.service
```

### Enable firewall

```bash
sudo ufw enable &&
sudo systemctl status ufw.service
```

### Firefox

#### Use backspace as back button

Open page `about:config` and set value `browser.backspace_action` to `0`;

#### Open links in different Firefox profile

To fix issue when Firefox open external links in different profile execute command `firefox -P` and remove second profile.

### Automated updates

Run below commands to ensure that [unattended upgrades](https://help.ubuntu.com/16.04/serverguide/automatic-updates.html) enabled:

```bash
sudo apt install unattended-upgrades update-notifier-common -y &&
sudo dpkg-reconfigure -plow unattended-upgrades
```

Modify file `/etc/apt/apt.conf.d/20auto-upgrades` to configure update frequency (in days):

```txt
APT::Periodic::Update-Package-Lists "1";
APT::Periodic::Download-Upgradeable-Packages "1";
APT::Periodic::AutocleanInterval "1";
APT::Periodic::Unattended-Upgrade "1";
```

Modify file `/etc/apt/apt.conf.d/50unattended-upgrades` and remove `//` before lines:

```txt
"${distro_id}:${distro_codename}-updates";
Unattended-Upgrade::AutoFixInterruptedDpkg "true";
Unattended-Upgrade::Remove-Unused-Kernel-Packages "true";
Unattended-Upgrade::Remove-Unused-Dependencies "true";
```

Run unattended-upgrades and show update logs:

```bash
sudo unattended-upgrades --debug &&
cat /var/log/unattended-upgrades/unattended-upgrades.log
```

#### Run updates on startup with script

Create script `/usr/bin/upgrade-all` with content:

```bash
apt update && apt full-upgrade -y && apt autoremove -y && apt autoclean && snap refresh
```

Make file executable `sudo chmod +x /usr/bin/upgrade-all`.

Add line `<current user name> ALL=(ALL) NOPASSWD:/usr/bin/upgrade-all` to the file `/etc/sudoers`.

Setup [Startup Application](https://help.ubuntu.com/stable/ubuntu-help/startup-applications.html.en) to run updates after 10 seconds:

```bash
sh -c "sleep 5 && sudo upgrade-all"
```

### Change GRUB boot menu timeout for Ubuntu 20.04

Add line `GRUB_RECORDFAIL_TIMEOUT=3` to file `/etc/default/grub` and execute below command:

sudo update-grub

### Set charge thresholds for laptop battery

You can improve battery life in Ubuntu with TLP. Install package `tlp` and set start thresholds to 45% and stop when 75% is reached:

```bash
sudo apt install tlp &&
sudo tlp setcharge 45 75 &&
sudo tlp start &&
sudo tlp-stat -s &&
sudo tlp-stat -b
```

### Ad blocker

Add hosts to `/etc/hosts` from [firebog.net](https://firebog.net) to block ads:

```bash
git clone --depth=1 https://github.com/mauragas/ToolsAndExamples.git &&
sudo dotnet run --project ToolsAndExamples/Tools/AdAwayHost/src/AdAwayHost.Console/ &&
sudo rm -r ToolsAndExamples &&
sudo dotnet nuget locals all --clear
```
