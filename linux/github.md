# GitHub

Various GitHub configurations and terminal commands.

![github](https://images.unsplash.com/photo-1590595906931-81f04f0ccebb?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1350&q=80)

## Access token

Set local repository to be able to access origin with generated token

```bash
git remote rm origin
git remote add origin https://user:token@github.com/user/repository.git
git remote add origin https://mauragas:1234567890@github.com/mauragas/Mauragas.github.io.git
```

## Command line interface

To install GitHub CLI follow [instructions](https://cli.github.com/manual/installation)

View detail on any command

```bash
gh command sub-command --help
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
gh pr view pull-request-number
```

View issue in terminal

```bash
gh issue view pull-request-number --preview
```

## Checkout

Checkout pull request

```bash
gh pr checkout branch-name
gh pr checkout pull-request-number
```

## Create

Create pull request

```bash
gh pr create
```

Create issue

```bash
gh issue create -t "title" -b "body"
```

Open pull request creation page

```bash
gh pr create -w
```
