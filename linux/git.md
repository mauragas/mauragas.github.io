# Git

Git terminal commands and various configurations.

## Configuration

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

## Repository

Creates a new local repository with the specified name

```bash
git init `project-name`
```

Downloads a project and its entire version history

```bash
git clone `url`
```

## Branch

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

## Commit

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

## Synchronization

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

Merge changes and squash commits to master branch _(At third command use `-m` if you want to edit messages from squashed commits)_

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

## Stash

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

## History

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

## Redo

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

## File names

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

## Repository maintenance

Clean up git repository

```bash
git clean -fdx
```

**-f** Force
**-d** Remove directories
**-x** Add `.gitignore` files

## Tracking

List all ignored files

```bash
git ls-files --other --ignored --exclude-standard
```

To be able to ignore files or directories from source control tracking specify rules in `.gitignore` file

```gitignore
*.log
build/
```

## Other commands

Turn of login pop-ups

```bash
git config --global credential.modalPrompt false
```
