# Terminal commands for Ubuntu based distributions

Various terminal commands for Ubuntu based Linux distributions.

## Packages

Update and clean

```bash
sudo apt update &&
sudo apt upgrade -y --allow-downgrades &&
sudo apt autoremove -y &&
sudo apt autoclean
```

Uninstall all from PPA

```bash
sudo apt-get install ppa-purge
sudo ppa-purge ppa:ubuntu-mozilla-daily/firefox-aurora
```

### [Ubuntu Make](https://wiki.ubuntu.com/ubuntu-make)

Install packages from ubuntu make

```bash
sudo add-apt-repository ppa:lyzardking/ubuntu-make &&
sudo apt-get update &&
sudo apt-get install ubuntu-make
```

Install Firefox using `umake`

```bash
umake web firefox-dev
```

### Snap

Install packages from Snap

```bash
sudo apt install snapd
sudo snap install "application-name"
sudo snap remove "application-name"
```

## Various commands

Change default terminal applications

```bash
sudo apt install dconf-editor
dconf-editor
```

Navigate to `org.gnome.desktop.applications.terminal` and change default value to `deepin-terminal`.

To turn off / on caps lock key

```bash
setxkbmap -option ctrl:nocaps
setxkbmap -option
```
