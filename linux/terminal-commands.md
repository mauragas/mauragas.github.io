# Terminal commands

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

Install packages from ubuntu make

[Ubuntu Make](https://wiki.ubuntu.com/ubuntu-make)

```bash
sudo add-apt-repository ppa:lyzardking/ubuntu-make &&
sudo apt-get update &&
sudo apt-get install ubuntu-make
```

Install Firefox using `umake`

```bash
umake web firefox-dev
```

Install packages from Snap

```bash
sudo apt install snapd
sudo snap install "application-name"
sudo snap remove "application-name"
```

Create bootable USB drive

```bash
dd bs=4M if=linux.iso of=/dev/sdx status=progress oflag=sync
```

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
