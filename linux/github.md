# GitHub

Various GitHub configurations and terminal commands.

## Access token

Set local repository to be able to access origin with generated token

```bash
git remote rm origin
git remote add origin https://`user`:`token`@github.com/`user`/`repository`.git
git remote add origin https://mauragas:1234567890@github.com/mauragas/Mauragas.github.io.git
```

## Command line interface

To install GitHub CLI follow [instructions](https://cli.github.com/manual/installation) 

View detail on any command

```bash
gh `command` `subcommand` --help
```

## Show

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

## Checkout

Checkout pull request

```bash
gh pr checkout `branch`
gh pr checkout `pull-request-number`
```

## Create

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
