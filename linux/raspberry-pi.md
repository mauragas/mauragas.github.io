# Raspberry Pi

Using Raspberry Pi single-board computer for various projects.

## Pi-hole installation on Raspberry Pi

Setup your own network wide ad blocker using Raspberry Pi device and Pi-hole.

### Steps

Download [Raspberry Pi OS Lite](https://www.raspberrypi.org/software/operating-systems) image file.
Insert memory card into your computer and identify device using command `sudo parted -l`.
Execute below command to copy extracted `.img` image file content into memory card.

```bash
sudo dd bs=4M if=raspios-buster-armhf-lite.img of=/dev/mmcblk0 status=progress oflag=sync
```

To enable [SSH](https://www.raspberrypi.org/documentation/remote-access/ssh) create empty `ssh` file on `boot` partition.
Take out memory card from computer, insert card into Raspberry Pi device and turn it on.
To connect to Raspberry Pi from your computer on the same network execute below command:

```bash
ssh pi@192.168.0.1
```

**NOTE:** Change to your Raspberry Pi device IP address. Default password for `pi` user is `raspberry`.

To change default password execute command `passwd`.
Update and upgrade system:

```bash
sudo apt update && sudo apt upgrade -y
```

To install Pi-hole execute [command](https://github.com/pi-hole/pi-hole/#one-step-automated-install):

```bash
curl -sSL https://install.pi-hole.net | sudo bash
```

**NOTE:** After installation you will get generated admin password for Pi-hole WEB interface and you will be able to access it using device IP address `http://192.168.0.1/admin`.

To enable ad blocking you need to change your router DNS server IP address to your Raspberry Pi IP address.

You can update Pi-hole with command `pihole -up`.

You can find some host files in [firebog.net](https://firebog.net).

### Securing your Raspberry Pi

#### Change SSH default port

To change default SSH port `22` modify line with text `Port 22`:

```bash
sudo nano /etc/ssh/sshd_config &&
sudo systemctl restart sshd.service
```

**NOTE:** After SSH service is restarted you will need to specify port explicitly `ssh -p 1234 pi@192.168.0.1`.

#### Install and setup firewall

Command to install and configure firewall to allow traffic only from internal subnet `192.168.2.0/24`:

```bash
sudo apt install ufw -y &&
sudo ufw default deny incoming &&
sudo ufw default allow outgoing &&
sudo ufw allow from 192.168.2.0/24 to any port 1234 proto tcp comment 'Allow SSH from local subnet' &&
sudo ufw allow from 192.168.2.0/24 to any port 53 proto tcp comment 'Allow DNS for TCP packages from local subnet' &&
sudo ufw allow from 192.168.2.0/24 to any port 53 proto udp comment 'Allow DNS for UDP packages from local subnet' &&
sudo ufw allow proto tcp from 192.168.2.0/24 to any port 80,443 comment 'Allow access to Pi-hole WEB interface from local subnet' &&
sudo ufw enable
```

**NOTE:** Replace `192.168.2.0/24` to your local network subnet.

Check all rules with command `sudo ufw status numbered` and delete `sudo ufw delete <number>` if needed.

#### Prevent SSH logins

To prevent someone trying to login you can install package `fail2ban`:

```bash
sudo apt install fail2ban -y &&
sudo cp /etc/fail2ban/fail2ban.conf /etc/fail2ban/fail2ban.local
```

Add configuration to file `/etc/fail2ban/fail2ban.local`:

```txt
[sshd]
enabled = true
port = ssh
banaction = iptables-allports
bantime = 600
maxretry = 3
```

Enable service:

```bash
sudo systemctl enable fail2ban.service &&
sudo systemctl restart fail2ban.service
```

Un-ban IP address manually if needed:

```bash
sudo fail2ban-client status sshd
sudo fail2ban-client set sshd unbanip 192.168.0.123
```

#### Enable automated updates

Run below commands to ensure that [unattended upgrades](https://help.ubuntu.com/16.04/serverguide/automatic-updates.html) enabled:

```bash
sudo apt install unattended-upgrades -y &&
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

And add the following lines in the `Unattended-Upgrade::Origins-Pattern` section if you running Raspberry OS:

```txt
"origin=Raspbian,codename=${distro_codename},label=Raspbian";
"origin=Raspberry Pi Foundation,codename=${distro_codename},label=Raspberry Pi Foundation";
```

Test unattended-upgrades and show update logs:

```bash
sudo unattended-upgrades --debug &&
sudo cat /var/log/unattended-upgrades/unattended-upgrades.log
```

### References

[Raspberry Pi Linux usage](https://www.raspberrypi.org/documentation/linux/usage)
[Securing your Raspberry Pi](https://www.raspberrypi.org/documentation/configuration/security.md)
[Top 5 Raspberry Pi Network Security Tips for Beginners](https://www.raspberrypistarterkits.com/guide/top-raspberry-pi-network-security-tips-beginners)
[Pi-hole - Network-wide protection](https://pi-hole.net)

## Ubuntu server on Raspberry Pi

You can follow [instructions](https://ubuntu.com/tutorials/how-to-install-ubuntu-on-your-raspberry-pi) to install Ubuntu on your Raspberry Pi.
Download Ubuntu image file from office [WEB site](https://ubuntu.com/download/raspberry-pi) or use [Raspberry Pi Imager](https://www.raspberrypi.org/software) to write image to SD card. Insert memory card and connect to it using ssh with user `ubuntu` and password `ubuntu`.

To detect IP address install `net-tools` and execute:

```bash
sudo apt install net-tools &&
arp -na
```

Check processor temperature and overall system info:

```bash
landscape-sysinfo
```

### Change default host and user name

To change host name you can use `hostnamectl`:

```bash
sudo hostnamectl set-hostname new-host-name
```

Add new user and enable it to perform administrative tasks:

```bash
sudo adduser newusername &&
sudo usermod -aG sudo newusername
```

Logout and login with new user. Remove old user `ubuntu` and its files:

```bash
sudo deluser --remove-home ubuntu
```

### Install .NET

Follow [instructions](https://dotnet.microsoft.com/download/dotnet) or execute below command (for `ZSH`):

```bash
wget https://dot.net/v1/dotnet-install.sh &&
chmod +x dotnet-install.sh &&
./dotnet-install.sh --architecture arm64 --channel Current --no-path --install-dir $HOME/.dotnet && 
rm ./dotnet-install.sh &&
export DOTNET_ROOT=$HOME/.dotnet &&
export PATH=$PATH:$HOME/.dotnet &&
echo "DOTNET_ROOT=$HOME/.dotnet" >> $HOME/.zshrc &&
echo "PATH=$PATH:$HOME/.dotnet" >> $HOME/.zshrc
```

Remove last four lines if PATH statement is already included in `.zshrc` file. You can change `channel` to LTS instead Current.

### Remotely connect using VS Code

Creating SSH Keys and copy to Raspberry Pi device:

```bash
ssh-keygen -t rsa &&
ssh-copy-id ubuntu@192.168.1.123 -p 1234
```

Edit file `~/.ssh/config` on local computer and add text (change to your settings):

```txt
Host 192.168.1.123
    HostName 192.168.1.123
    User ubuntu
    Port 1234
```

Install extension `Remote - SSH` for VS Code.
Follow [instructions](https://github.com/OmniSharp/omnisharp-vscode/wiki/Remote-Debugging-On-Linux-Arm) for remote debugging.

Install [bpytop](https://snapcraft.io/bpytop) for resource monitoring:

```bash
sudo snap install bpytop &&
sudo snap connect bpytop:mount-observe &&
sudo snap connect bpytop:network-control &&
sudo snap connect bpytop:hardware-observe &&
sudo snap connect bpytop:system-observe &&
sudo snap connect bpytop:process-control &&
sudo snap connect bpytop:physical-memory-observe
```

[![remote-raspberry-pi-blazor-app.png](https://www.snapagogo.com/images/2020/12/24/remote-raspberry-pi-blazor-app.png)](https://www.snapagogo.com/image/c4qjQR)

### Install Docker

You can follow standard [steps](https://docs.docker.com/engine/install/ubuntu) for Ubuntu or execute below command:

```bash
curl -fsSL https://get.docker.com -o get-docker.sh &&
sudo sh get-docker.sh &&
sudo usermod -aG docker $USER &&
docker version
```

Create Ubuntu container:

```bash
docker run -it ubuntu bash
```

### Make router / gateway from Raspberry Pi 4

You can make your own router from Raspberry Pi device. You will need extra Ethernet port (e.g USB-A to Gigabit Ethernet Adapter).
In this project I used [Uni](https://uniaccessories.io/products/usb-to-ethernet-adapter-3-usb) adapter and tested on Ubuntu 20.04.

- WAN `eth0` - plugged into external network.
- LAN `eth1` - plugged into internal network.

Edit file `/etc/netplan/50-cloud-init.yaml`, in my case scenario I used `10.10.10.1` IP for internal network, because I will plug wireless router with internal network IP range `192.168.2.0/24`:

```yaml
network:
    ethernets:
        eth0:
            dhcp4: true
        eth1:
            addresses:
                - 10.10.10.1/24
    version: 2
    renderer: networkd
```

Execute:

```bash
sudo netplan generate &&
sudo netplan apply
```

#### Option 1 - Use Suricata to route packages (Intrusion Prevention System)

Run below command to install [Suricata](https://suricata.readthedocs.io/en/latest/quickstart.html) on Ubuntu 20.04:

```bash
sudo apt-get install software-properties-common -y &&
sudo add-apt-repository ppa:oisf/suricata-stable &&
sudo apt-get update &&
sudo apt-get install suricata -y &&
suricata -V &&
sudo suricata --build-info &&
sudo systemctl status suricata.service
```

Search `af-packet` in file `/etc/suricata/suricata.yaml` and set [configuration](https://suricata.readthedocs.io/en/suricata-6.0.0/setting-up-ipsinline-for-linux.html#settings-up-ips-at-layer-2):

```yaml
af-packet:
  - interface: eth0
    threads: 1
    defrag: no
    cluster-type: cluster_flow
    cluster-id: 98
    copy-mode: ips
    copy-iface: eth1
    buffer-size: 64535
    use-mmap: yes
  - interface: eth1
    threads: 1
    cluster-id: 97
    defrag: no
    cluster-type: cluster_flow
    copy-mode: ips
    copy-iface: eth0
    buffer-size: 64535
    use-mmap: yes
```

Run update, restart service and output statistics to terminal:

```bash
sudo suricata-update &&
sudo systemctl restart suricata &&
sudo tail -f /var/log/suricata/stats.log
```

**NOTE:** Probably you will need to reboot Raspberry Pi to make it functional. Network will be transparent through Raspberry Pi, therefore you could lost SSH connection. You may need to reconfigure your router settings which is plugged into Raspberry Pi LAN port, the gateway IP address will be router plugged into Raspberry Pi WAN port (e.g. 192.168.1.1).

#### Option 2 - Use iptables to route packages (without DHCP)

Modify files:

- `/etc/sysctl.conf` - uncomment line with text `net.ipv4.ip_forward=1`.
- `/etc/default/ufw` - update line to `DEFAULT_FORWARD_POLICY="ACCEPT"`.
- `/etc/ufw/sysctl.conf` and uncomment line `net/ipv4/ip_forward=1`.

With below script you can configure network and firewall. Create file (e.g. setup-router.sh) and make it executable `chmod +x ./setup-router.sh` and later run `sudo ./setup-router.sh`:

```bash
#!/usr/bin/env sh

# Flush all existing tables
iptables -F

# Default rules
iptables -P INPUT DROP
iptables -P FORWARD DROP

# Accept incoming packets from localhost
iptables -A INPUT -i lo -j ACCEPT

# Accept incoming packets from LAN interface eth1
iptables -A INPUT -i eth1 -j ACCEPT

# Accept incoming packets from the WAN eth0 if the router initiated the connection
iptables -A INPUT -i eth0 -m conntrack --ctstate ESTABLISHED,RELATED -j ACCEPT

# Forward LAN packets to the WAN
iptables -A FORWARD -i eth1 -o eth0 -j ACCEPT

# Forward WAN packets to the LAN if the LAN initiated the connection
iptables -A FORWARD -i eth0 -o eth1 -m conntrack --ctstate ESTABLISHED,RELATED -j ACCEPT

# NAT traffic going out the WAN interface
iptables -t nat -A POSTROUTING -o eth0 -j MASQUERADE

# Allow SSH from interface `eth1`, IP range `10.10.10.0/24` and port `1234` (remember to change it):
iptables -A INPUT -d 10.10.10.0/24 -i eth1 -m state --state NEW -m tcp -p tcp --dport 1234 -j ACCEPT

# Install tool which will automatically restore iptables rules after reboot
apt install iptables-persistent -y

# Save iptables rules
iptables-save
iptables-save > /etc/iptables/rules.v4

# Enable firewall
ufw enable

# List all rules
iptables -L
```

In case you get error `unable to resolve host ubuntu: Temporary failure in name resolution` edit file `/etc/hosts` and add line `127.0.0.1 ubuntu`.

Configure DNS server in case you have issues with default configuration in file `/etc/resolv.conf`:

```bash
sudo apt install resolvconf &&
sudo systemctl status resolvconf.service
```

If service `resolvconf` is active add to file `/etc/resolvconf/resolv.conf.d/head` [AdGuard](https://adguard.com/en/adguard-dns/overview.html) or other DNS server IPs:

```txt
nameserver 94.140.15.15
nameserver 94.140.14.14
```

Restart `resolvconf.service`:

```bash
sudo systemctl restart resolvconf.service
```

##### Setup Intrusion Detection System using Suricata

Install Suricata as in previous steps. Search for `af-packet` in file `/etc/suricata/suricata.yaml` and set [basic setup](https://suricata.readthedocs.io/en/suricata-6.0.0/quickstart.html#basic-setup):

```yaml
af-packet:
    - interface: enp1s0
      cluster-id: 99
      cluster-type: cluster_flow
      defrag: yes
      use-mmap: yes
      tpacket-v3: yes
```

Follow [instructions](https://suricata.readthedocs.io/en/suricata-6.0.0/rule-management/suricata-update.html#rule-management-with-suricata-update) to add or remove rule lists.

Run update, restart service and output statistics to terminal:

```bash
sudo suricata-update &&
sudo systemctl restart suricata &&
sudo tail -f /var/log/suricata/stats.log
```

Setup daily (default weekly) log rotation for suricata, rotate logs older than 3 days (rotations), create file `/etc/logrotate.d/suricata` with [content](https://suricata.readthedocs.io/en/suricata-6.0.1/output/log-rotation.html):

```bash
/var/log/suricata/*.log /var/log/suricata/*.json
{
    daily
    rotate 3
    missingok
    nocompress
    create
    sharedscripts
    postrotate
        /bin/kill -HUP `cat /var/run/suricata.pid 2>/dev/null` 2>/dev/null || true
    endscript
}
```

Print debug messages without rotation (see what going to happen after rotation):

```bash
logrotate -d /etc/logrotate.d/suricata
```

Run rotation now (ignore `daily` configuration):

```bash
sudo logrotate -f /etc/logrotate.d/suricata -v
```

### Install Nextcloud

You can easily install [Nextcloud](https://github.com/nextcloud/nextcloud-snap) from [snapcraft](https://snapcraft.io/nextcloud):

```bash
sudo snap install nextcloud &&
sudo snap connect nextcloud:network-observe && # Access to the system monitoring
sudo snap connect nextcloud:removable-media && # Access removable media
sudo snap set nextcloud php.memory-limit=-1 && # Set PHP Memory limit to be unlimited
sudo snap set nextcloud ports.https=444 && # Set port 444 (example) for HTTPS
sudo nextcloud.enable-https self-signed # Generate key and self-signed certificate
```

If firewall is enable you need to allow HTTPS on port 444 (example):

```bash
sudo iptables -A INPUT -d 10.10.10.0/24 -i eth1 -m state --state NEW -m tcp -p tcp --dport 444 -j ACCEPT &&
sudo iptables-save &&
sudo sh -c "iptables-save > /etc/iptables/rules.v4" # Package iptables-persistent must be installed
```

Admin user can be created through WEB interface during first login and other users can be created using command:

```bash
sudo nextcloud.occ user:add SomeUserName --display-name="SomeUserName" --group="Users"
```

**NOTE:** Group "Users" can be created by admin in WEB interface.

#### Mount external USB drive

Mount manually `sudo mount /dev/sda1 /media/usb0` or configure auto mount in `/etc/fstab`. Find device using `sudo lsblk` or `sudo parted -l` and UUID using command `sudo blkid`.

Create mount folder and add permissions:

```bash
FOLDER="/media/USB3-32GB" &&
sudo groupadd data &&
sudo usermod -aG data $USER &&
sudo mkdir $FOLDER &&
sudo chown -R :data $FOLDER &&
sudo chown -R :data $FOLDER
```

Append file with UUID file `/etc/fstab`:

```bash
sudo sh -c 'echo "UUID=234cf34c-bd67-4567-4567-a567c4c4567 /media/USB3-32GB    auto nosuid,nodev,nofail,x-gvfs-show 0 0" >> /etc/fstab' &&
cat /etc/fstab
```

Device will be mounted on folder `/media/USB3-32GB` after restart, you can verify using `sudo lsblk`.

**NOTE:** If you mount storage for use in Nextcloud, change folder `/media/USB3-32GB` ownership to root `sudo chown -R root:root /media/USB3-32GB`.

### Boot Ubuntu 20.04 from USB drive

After flashing external drive update file `config.txt` located on partition `system-boot` with text:

```txt
[pi4]
max_framebuffers=2
dtoverlay=vc4-fkms-v3d
boot_delay
kernel=vmlinux
initramfs initrd.img followkernel
```

Extract kernel on the same partition `system-boot`:

```bash
zcat vmlinuz > vmlinux 
```

Also create script file `sudo nano auto_decompress_kernel` with content:

```bash
#!/bin/bash -e

# Set Variables
BTPATH=/boot/firmware
CKPATH=$BTPATH/vmlinuz
DKPATH=$BTPATH/vmlinux

# Check if compression is needs
if [ -e $BTPATH/check.md5 ]; then
    if md5sum --status --ignore-missing -c $BTPATH/check.md5; then
    echo -e "\e[32mFiles have not changed, Decompression not needed\e[0m"
    exit 0
    else echo -e "\e[31mHash failed, kernel will be compressed\e[0m"
    fi
fi

# Backup the old decompressed kernel
mv $DKPATH $DKPATH.bak

if [ ! $? == 0 ]; then
    echo -e "\e[31mDECOMPRESSED KERNEL BACKUP FAILED!\e[0m"
    exit 1
else echo -e "\e[32mDecompressed kernel backup was successful\e[0m"
fi

# Decompress the new kernel
echo "Decompressing kernel: "$CKPATH".............."

zcat $CKPATH > $DKPATH

if [ ! $? == 0 ]; then
    echo -e "\e[31mKERNEL FAILED TO DECOMPRESS!\e[0m"
    exit 1
else
    echo -e "\e[32mKernel Decompressed Succesfully\e[0m"
fi

# Hash the new kernel for checking
md5sum $CKPATH $DKPATH > $BTPATH/check.md5

if [ ! $? == 0 ]; then
    echo -e "\e[31mMD5 GENERATION FAILED!\e[0m"
    else echo -e "\e[32mMD5 generated Succesfully\e[0m"
fi

exit 0
```

Make script executable `sudo chmod +x auto_decompress_kernel`

Navigate to second partition `writable` and create file `sudo nano ./etc/apt/apt.conf.d/999_decompress_rpi_kernel` and add content:

```bash
DPkg::Post-Invoke {"/bin/bash /boot/firmware/auto_decompress_kernel"; };
```

Make script executable `sudo chmod +x ./etc/apt/apt.conf.d/999_decompress_rpi_kernel`

Now you can plug USB drive without SD card and start device.

**NOTE:** You may need to [update firmware](https://www.raspberrypi.org/documentation/hardware/raspberrypi/booteeprom.md) to `stable` to make it work.

### Backup storage drive

Download and install [PiShrink](https://github.com/Drewsif/PiShrink):

```bash
wget https://raw.githubusercontent.com/Drewsif/PiShrink/master/pishrink.sh
chmod +x pishrink.sh
sudo mv pishrink.sh /usr/local/bin
```

Idetify plugged in drive `sudo parted -l` and execute:

```bash
# Copy storage mounted on /dev/mmcblk0 to file ubuntu-server-sd-card.iso
sudo dd if=/dev/mmcblk0 of=./ubuntu-server-sd-card.img status=progress bs=4M

# Shrink img file
sudo pishrink.sh ./ubuntu-server-sd-card.img

# Change file owner (optional)
sudo chown $USER:$USER ./ubuntu-server-ssd.img
```

### Automated reboots

You can configure automated reboots using `cron`. Append to file text after executing command `sudo crontab -e`:

```txt
# Reboot every morning at 03:00 
0 3 * * * /usr/sbin/reboot
```

**NOTE:** You can find path to `reboot` executable with command `which reboot`. Check last reboot with command `last reboot` and up time `uptime`.

### Move log folder to RAM

You can use RAM as log storage by implementing tool [log2ram](https://github.com/azlux/log2ram):

```bash
echo "deb http://packages.azlux.fr/debian/ buster main" | sudo tee /etc/apt/sources.list.d/azlux.list &&
wget -qO - https://azlux.fr/repo.gpg.key | sudo apt-key add - &&
sudo apt update &&
sudo apt install log2ram
```

By default storage for logs is 40MB, it is good idea to icrease it by editing file `/etc/log2ram.conf` and modify line with:

```txt
SIZE=768M
```

By default logs are written to disk every day, if you want overwrite it execute `sudo systemctl edit log2ram-daily.timer` and add text:

```txt
[Timer]
OnCalendar=hourly
```

After you overwrite default timer value reload Systemd daemon `sudo systemctl daemon-reload` (optional). If you want to execute every 2 hours use `00/2:00` instead of value `hourly`.

After device is rebooted you can verify mounted device with command `df -h`. Check logs if tool is working correctly `sudo journalctl -t log2ram`. You can also check time left until next execution `sudo systemctl status log2ram-daily.timer`.

Other configuration values (instead `OnCalendar`):

> `OnBootSec` - time relative to the system boot time.
>
> `OnStartupSec` - time relative to the time when systemd started.
>
> `OnActiveSec` - time relative to the time when the timer unit itself is activated.

### Move tmp folder to RAM

All you need to do is to enable `tmp.mount`:

```bash
sudo cp /usr/share/systemd/tmp.mount /etc/systemd/system/tmp.mount &&
sudo systemctl enable tmp.mount &&
sudo systemctl start tmp.mount
```

### Change swappiness (if swap partition / file exist)

Default swappiness value in file `/proc/sys/vm/swappiness` is 60, to change it execute command:

```bash
# Minimum amount of swap will be used
sudo sysctl -w vm.swappiness=1 &&
echo "vm.swappiness = 1" | sudo tee /etc/sysctl.d/90-swappiness.conf &&
sudo sysctl --load /etc/sysctl.d/90-swappiness.conf &&
sudo sysctl --system
```

### Increase RAM usage

Set value [/proc/sys/vm/vfs_cache_pressure](https://sysctl-explorer.net/vm/vfs_cache_pressure) to 10 (default 100):

```bash
sudo sysctl vm.vfs_cache_pressure=10 &&
sudo sh -c 'echo "vm.vfs_cache_pressure=10" >> /etc/sysctl.conf'
```

Set [/proc/sys/vm/dirty_ratio](https://sysctl-explorer.net/vm/dirty_ratio/), [/proc/sys/vm/dirty_background_ratio](https://sysctl-explorer.net/vm/dirty_background_ratio/) and [/proc/sys/vm/dirty_expire_centisecs](https://sysctl-explorer.net/vm/dirty_expire_centisecs/):

```bash
# Use up to 80% of the RAM as cache for writes - default 20%
sudo sysctl vm.dirty_ratio=80 &&
sudo sh -c 'echo "vm.dirty_ratio=80" >> /etc/sysctl.conf' &&

# Use up to 50% of RAM before slowing down the process - default 10%
sudo sysctl vm.dirty_background_ratio=50 &&
sudo sh -c 'echo "vm.dirty_background_ratio=50" >> /etc/sysctl.conf' &&

# Set how long something can be in cache before it needs to be written - default 3000 (30 seconds)
sudo sysctl vm.dirty_expire_centisecs=30000 &&
sudo sh -c 'echo "vm.dirty_expire_centisecs=30000" >> /etc/sysctl.conf'
```

**NOTE:** These setting potentially can increase performance, but it can add some risk of data loss.

### Overclock Raspberry Pi 4 processor

You can safely [overclock](https://www.raspberrypi.org/documentation/configuration/config-txt/overclocking.md) processor from 1.5GHz to 2GHz by modifying file `/boot/firmware/usercfg.txt` on Ubuntu 20.04:

```txt
# Overclock processor to 2GHz
over_voltage=6
arm_freq=2000
```

**NOTE:** Ensure that you have proper cooling, otherwise processor will throttle.

### Synchronize the system time

Print out current time with command `timedatectl` and install [chrony](https://ubuntu.com/blog/ubuntu-bionic-using-chrony-to-configure-ntp).

```bash
sudo apt install chrony -y &&

# Check how much your system time varies from the internet server
sudo chronyd -Q &&

# Synchronize the clock
sudo chronyd –q
```

You can find configuration in file `/etc/chrony/chrony.conf`, restart service after modification `sudo systemctl restart chrony.service`.

### Configure Argon case

Install [script](https://download.argon40.com/argon1.sh) for [Argon case](https://www.argon40.com/argon-one-v-2-case-for-raspberry-pi-5.html) and configure fan speed:

```bash
curl https://download.argon40.com/argon1.sh | sudo bash &&
sudo argonone-config
```

### Troubleshooting

Fallow more detailed [guide](https://help.ubuntu.com/community/TroubleShootingGuide) for more information.

All logs are stored in folder `/var/log` and can be printed out manually.

Show system info (list hardware):

```bash
sudo lshw
```

Show storage devices and empty space:

```bash
df -l
```

#### Boot logs

Show most recent boot logs:

```bash
sudo journalctl -b
```

List all boots `sudo journalctl --list-boots` and list logs of specific boot:

```bash
journalctl --boot=p6kgjh12345fdj1234ur1234567jk4f9
```
