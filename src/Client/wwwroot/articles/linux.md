# Linux

## My Pop OS setup

Download ISO file from Pop OS [WEB site](https://system76.com/pop). Check USB device using command `sudo fdisk -l` and execute below command:

```bash
dd bs=4M if=path/to/pop-os-linux.iso of=/dev/sdx status=progress oflag=sync
```

Update all packages after installation

```bash
sudo apt update &&
sudo apt upgrade
```

### Applications

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

### Nicer terminal

Install `zsh` package and afterward [Oh-My-Zsh](https://ohmyz.sh). Edit `~/.zshrc` and change variable `ZSH_THEME` to `fox`.

```bash
gedit ~/.zshrc
```

### Extensions

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

### Icons and themes

Flat-remix

```bash
sudo add-apt-repository ppa:daniruiz/flat-remix
sudo apt-get update
sudo apt-get install flat-remix-gnome flat-remix flat-remix-gtk
```

### Shrink title bar

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

### Default terminal

Change default to deepin terminal

```bash
gsettings set org.gnome.desktop.default-applications.terminal exec 'deepin-terminal'
```

## Terminal commands

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

## Git

### Configuration

Sets the name you want atached to your commit transactions

```bash
git config --global user.name "`name`"
```

Sets the email you want atached to your commit transactions

```bash
git config --global user.email "`email`"
```

Change editor to `vim` or Visual Studio Code

```bash
git config --global core.editor vim
git config --global core.editor "code --wait"
```

Open editor for git configuration file

```bash
git config --global -e
```

To change `difftool` add to configuration file

```gitconfig
[diff]
    tool = default-difftool
[difftool "default-difftool"]
    cmd = code --wait --diff $LOCAL $REMOTE
```

List configurations

```bash
git config --list
```

Show user name

```bash
git config user.name
```

Enables helpful colorization of command line output

```bash
git config --global color.ui auto
```

### Repository

Creates a new local repository with the specified name

```bash
git init `project-name`
```

Downloads a project and its entire version history

```bash
git clone `url`
```

### Branch

List all local branches

```bash
git branch
```

Create new branch

```bash
git branch `branch`
```

Switch to branch

```bash
git checkout `branch`
```

Delete specified branch

```bash
git branch -d `branch`
```

Push branch to origin and setup tracking

```bash
git push -u origin `branch`
```

Set tracking information for this branch

```bash
git branch --set-upstream-to=origin/`branch` master
git branch --set-upstream-to=origin/master master
```

### Commit

Get status by listing all new or modified files

```bash
git status
```

Show not yet staged or staged file differences in terminal

```bash
git diff
git diff --staged
```

Show file differences in `difftool`

```bash
git difftool
```

Stage file or all pending files

```bash
git add `file`
git add *
```

Unstage file

```bash
git reset `file`
git reset HEAD `file`
```

Discard changes in working directory

```bash
git reset HEAD `file`
git reset `file`
```

Commit

```bash
git commit -m "`message`"
```

### Synchronization

Download all history from origin repository bookmark

```bash
git fetch `bookmark`
```

Update the state to the latest remote master state

```bash
git pull
git pull `remote` `branch`
```

Bring changes from specified branch to currently checkout one

```bash
git merge `branch`
```

Get changes from `bookmark` branch to current local branch

```bash
git merge `bookmark`/`branch`
git merge origin/`branch`
```

Merge changes and squash commits to master branch *(At third command use `-m` if you want to edit messages from squashed commits)*

```bash
git checkout master
git merge --squash `branch`
git commit
```

Upload local branch commits to origin

```bash
git push
git push `alias` `branch`
git push origin master
```

### Stash

Temporary save changes

```bash
git stash
```

List all stashed changes

```bash
git stash list
```

Reapply most recent stashed files

```bash
git stash pop
```

Remove the most recent stash

```bash
git stash drop
```

### History

Get version history for the current branch

```bash
git log
```

Get version history for a file

```bash
git log --follow `file`
```

Show differences between two branches

```bash
git diff `branch`..`branch`
git diff `branch`...`branch`
```

Show metadata and changes of specified commit

```bash
git show `commit`
```

### Redo

Undo all commits after `commit` while preserving changes locally

```bash
git reset `commit`
```

Discard all changes back to specified commit

```bash
git reset --hard `commit`
```

Discard all local changes/commits and reset to origin branch

```bash
git reset --hard origin/master
```

### File names

Remove file and stage deletion

```bash
git rm `file`
```

Remove file from source control system but keep it locally

```bash
git rm --cached `file`
```

Rename file and prepare it for commit

```bash
git mv `file-name` `new-file-name`
```

### Repository maintenance

Clean up git repository

```bash
git clean -fdx
```

**-f** Force
**-d** Remove directories
**-x** Add `.gitignore` files

### Tracking

List all ignored files

```bash
git ls-files --other --ignored --exclude-standard
```

To be able to ignore files or directories from source control tracking specify rules in `.gitignore` file

```gitignore
*.log
build/
```

### Other commands

Turn of login pop-ups

```bash
git config --global credential.modalPrompt false
```

## GitHub

Set local repository to be able to access origin with generated token

```bash
git remote rm origin
git remote add origin https://`user`:`token`@github.com/`user`/`repository`.git
git remote add origin https://mauragas:1234567890@github.com/mauragas/Mauragas.github.io.git
```

### Command line interface

To install GitHub CLI follow [instructions](https://cli.github.com/manual/installation) 

View detail on any command

```bash
gh `command` `subcommand` --help
```

### Show

List issues

```bash
gh issue list
```

List pull requests with flags

```bash
gh pr list --state closed --assignee user
```

Show PR or issue status in terminal

```bash
gh pr status
gh issue status
```

Open PR in browser

```bash
gh pr view `pull-request-number`
```

View issue in terminal

```bash
gh issue view `pull-request-number` --preview
```

### Checkout

Checkout pull request

```bash
gh pr checkout `branch`
gh pr checkout `pull-request-number`
```

### Create

Create pull request

```bash
gh pr create
```

Create issue

```bash
gh issue create -t "`title`" -b "`body`"
```

Open pull request creation page

```bash
gh pr create -w
```
